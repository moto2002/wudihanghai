using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LuaFramework
{
	public class NetworkManager : Manager
	{
		private SocketClient socket;

		private static readonly object m_lockObject = new object();

		private static Queue<KeyValuePair<int, LuaByteBuffer>> sEvents = new Queue<KeyValuePair<int, LuaByteBuffer>>();

		private SocketClient SocketClient
		{
			get
			{
				if (this.socket == null)
				{
					this.socket = new SocketClient();
				}
				return this.socket;
			}
		}

		private void Awake()
		{
			this.Init();
		}

		private void Init()
		{
			this.SocketClient.OnRegister();
		}

		public void OnInit()
		{
			this.CallMethod("Start", new object[0]);
		}

		public void Unload()
		{
			this.CallMethod("Unload", new object[0]);
		}

		public object[] CallMethod(string func, params object[] args)
		{
			return Util.CallMethod("Network", func, args);
		}

		public static void AddEvent(int _event, LuaByteBuffer data)
		{
			object lockObject = NetworkManager.m_lockObject;
			lock (lockObject)
			{
				NetworkManager.sEvents.Enqueue(new KeyValuePair<int, LuaByteBuffer>(_event, data));
			}
		}

		private void Update()
		{
			if (NetworkManager.sEvents.Count > 0)
			{
				while (NetworkManager.sEvents.Count > 0)
				{
					KeyValuePair<int, LuaByteBuffer> keyValuePair = NetworkManager.sEvents.Dequeue();
					base.facade.SendMessageCommand("DispatchMessage", keyValuePair);
				}
			}
		}

		public void SendConnect()
		{
			this.SocketClient.SendConnect();
		}

		public void Disconnect()
		{
			this.SocketClient.Close();
		}

		public void SendMessage(ByteBuffer buffer)
		{
			this.SocketClient.SendMessage(buffer);
		}

		private void OnDestroy()
		{
			this.SocketClient.OnRemove();
			Debug.Log("~NetworkManager was destroy");
		}
	}
}
