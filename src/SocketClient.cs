using LuaFramework;
using LuaInterface;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class SocketClient
{
	private const int MSG_HEAD_LENGTH = 4;

	private const int MAX_READ = 8192;

	private TcpClient client;

	private NetworkStream outStream;

	private MemoryStream memStream;

	private BinaryReader reader;

	private byte[] byteBuffer = new byte[8192];

	public static bool loggedIn;

	public void OnRegister()
	{
		this.memStream = new MemoryStream();
		this.reader = new BinaryReader(this.memStream);
	}

	public void OnRemove()
	{
		this.Close();
		this.reader.Close();
		this.memStream.Close();
	}

	private void ConnectServer(string host, int port)
	{
		this.client = null;
		try
		{
			IPAddress[] hostAddresses = Dns.GetHostAddresses(host);
			if (hostAddresses[0].AddressFamily == AddressFamily.InterNetworkV6 && Socket.OSSupportsIPv6)
			{
				this.client = new TcpClient(AddressFamily.InterNetworkV6);
			}
			else
			{
				this.client = new TcpClient(AddressFamily.InterNetwork);
			}
			this.client.SendTimeout = 1000;
			this.client.ReceiveTimeout = 1000;
			this.client.NoDelay = true;
			this.client.BeginConnect(hostAddresses, port, new AsyncCallback(this.OnConnect), null);
		}
		catch (Exception ex)
		{
			this.OnDisconnected(DisType.Disconnect, ex.Message);
			Debug.LogError(ex.Message);
		}
	}

	private void OnConnect(IAsyncResult asr)
	{
		if (this.client.Connected)
		{
			this.outStream = this.client.GetStream();
			this.client.GetStream().BeginRead(this.byteBuffer, 0, 8192, new AsyncCallback(this.OnRead), null);
			NetworkManager.AddEvent(101, new LuaByteBuffer(Encoding.Default.GetBytes("true")));
		}
		else
		{
			NetworkManager.AddEvent(101, new LuaByteBuffer(Encoding.Default.GetBytes("false")));
		}
		this.client.EndConnect(asr);
	}

	private void WriteMessage(byte[] message)
	{
		MemoryStream memoryStream2;
		MemoryStream memoryStream = memoryStream2 = new MemoryStream();
		try
		{
			memoryStream.Position = 0L;
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.Int2ByteArray(message.Length + 4));
			binaryWriter.Write(message);
			binaryWriter.Flush();
			if (this.client != null && this.client.Connected)
			{
				byte[] array = memoryStream.ToArray();
				this.outStream.BeginWrite(array, 0, array.Length, new AsyncCallback(this.OnWrite), null);
			}
			else
			{
				this.OnDisconnected(DisType.Disconnect, "WriteMessage client.Connected = false");
				Debug.LogError("client.connected----->>false");
			}
		}
		finally
		{
			if (memoryStream2 != null)
			{
				((IDisposable)memoryStream2).Dispose();
			}
		}
	}

	private void OnRead(IAsyncResult asr)
	{
		int num = 0;
		try
		{
			NetworkStream stream = this.client.GetStream();
			lock (stream)
			{
				num = this.client.GetStream().EndRead(asr);
			}
			if (num < 1)
			{
				this.OnDisconnected(DisType.Disconnect, "bytesRead < 1");
			}
			else
			{
				this.OnReceive(this.byteBuffer, num);
				NetworkStream stream2 = this.client.GetStream();
				lock (stream2)
				{
					Array.Clear(this.byteBuffer, 0, this.byteBuffer.Length);
					this.client.GetStream().BeginRead(this.byteBuffer, 0, 8192, new AsyncCallback(this.OnRead), null);
				}
			}
		}
		catch (Exception ex)
		{
			if (this.client != null)
			{
				this.OnDisconnected(DisType.Exception, ex.Message);
			}
		}
	}

	private void OnDisconnected(DisType dis, string msg)
	{
		this.Close();
		int @event = (dis != DisType.Exception) ? 103 : 102;
		NetworkManager.AddEvent(@event, new LuaByteBuffer(Encoding.Default.GetBytes(msg)));
		Debug.LogWarning(string.Concat(new object[]
		{
			"Connection was closed by the server:>",
			msg,
			" Distype:>",
			dis
		}));
	}

	private void PrintBytes()
	{
		string text = string.Empty;
		for (int i = 0; i < this.byteBuffer.Length; i++)
		{
			text += this.byteBuffer[i].ToString("X2");
		}
		Debug.LogError(text);
	}

	private void OnWrite(IAsyncResult r)
	{
		try
		{
			this.outStream.EndWrite(r);
		}
		catch (Exception ex)
		{
			Debug.LogError("OnWrite--->>>" + ex.Message);
		}
	}

	private void OnReceive(byte[] bytes, int length)
	{
		this.memStream.Seek(0L, SeekOrigin.End);
		this.memStream.Write(bytes, 0, length);
		this.memStream.Seek(0L, SeekOrigin.Begin);
		while (this.RemainingBytes() > 4L)
		{
			int num = this.ByteArray2Int(this.reader.ReadBytes(4)) - 4;
			if (this.RemainingBytes() < (long)num)
			{
				this.memStream.Position = this.memStream.Position - 4L;
				break;
			}
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.reader.ReadBytes(num));
			memoryStream.Seek(0L, SeekOrigin.Begin);
			this.OnReceivedMessage(memoryStream);
		}
		byte[] array = this.reader.ReadBytes((int)this.RemainingBytes());
		this.memStream.SetLength(0L);
		this.memStream.Write(array, 0, array.Length);
	}

	private long RemainingBytes()
	{
		return this.memStream.Length - this.memStream.Position;
	}

	private void OnReceivedMessage(MemoryStream ms)
	{
		BinaryReader binaryReader = new BinaryReader(ms);
		byte[] buf = binaryReader.ReadBytes((int)(ms.Length - ms.Position));
		NetworkManager.AddEvent(104, new LuaByteBuffer(buf));
	}

	private void SessionSend(byte[] bytes)
	{
		this.WriteMessage(bytes);
	}

	public void Close()
	{
		if (this.client != null)
		{
			if (this.client.Connected)
			{
				this.client.Close();
			}
			this.client = null;
		}
		SocketClient.loggedIn = false;
	}

	public void SendConnect()
	{
		this.ConnectServer(AppConst.SocketAddress, AppConst.SocketPort);
	}

	public void SendMessage(ByteBuffer buffer)
	{
		this.SessionSend(buffer.ToBytes());
		buffer.Close();
	}

	private int ByteArray2Int(byte[] data)
	{
		int num = 0;
		for (int i = 3; i >= 0; i--)
		{
			int num2 = (int)(data[i] - 28);
			num += (int)((float)num2 * Mathf.Pow(100f, (float)(3 - i)));
		}
		return num;
	}

	private byte[] Int2ByteArray(int number)
	{
		byte[] array = new byte[4];
		int num = number;
		int num2 = 4;
		for (int i = 1; i <= 4; i++)
		{
			if (num > 0)
			{
				array[--num2] = (byte)(num % 100 + 28);
				num /= 100;
			}
			else
			{
				array[--num2] = 28;
			}
		}
		return array;
	}
}
