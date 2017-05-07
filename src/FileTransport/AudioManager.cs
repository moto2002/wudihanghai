using System;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

namespace FileTransport
{
	public class AudioManager
	{
		private static AudioManager instance;

		public static AudioManager GetInstance()
		{
			if (AudioManager.instance == null)
			{
				AudioManager.instance = new AudioManager();
			}
			return AudioManager.instance;
		}

		public void ExeAudioForUpload(string audioFile, Action<string> completeCallback)
		{
			Loom.RunAsync(delegate
			{
				this.UploadAudio(audioFile, completeCallback);
			});
		}

		public void ExeAudioForDownload(string audioName, string saveAudioFile, Action<string> completeCallback)
		{
			Loom.RunAsync(delegate
			{
				this.DownloadAudio(audioName, saveAudioFile, completeCallback);
			});
		}

		private void UploadAudio(string audioFile, Action<string> completeCallback)
		{
			string uri = "http://14.17.120.214:8090/storage/save_voice";
			HttpWebRequest httpWebRequest = WebRequest.Create(AudioManager.AppendTimestampWithUri(uri)) as HttpWebRequest;
			httpWebRequest.ContentType = "image/x-png";
			httpWebRequest.Method = "POST";
			httpWebRequest.KeepAlive = true;
			httpWebRequest.Timeout = 20000;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
			using (Stream stream = new MemoryStream())
			{
				using (FileStream fileStream = new FileStream(audioFile, FileMode.Open, FileAccess.Read))
				{
					byte[] array = new byte[1024];
					int count;
					while ((count = fileStream.Read(array, 0, array.Length)) != 0)
					{
						stream.Write(array, 0, count);
					}
				}
				httpWebRequest.ContentLength = stream.Length;
				using (Stream requestStream = httpWebRequest.GetRequestStream())
				{
					stream.Position = 0L;
					byte[] array2 = new byte[stream.Length];
					stream.Read(array2, 0, array2.Length);
					requestStream.Write(array2, 0, array2.Length);
				}
			}
			HttpWebResponse httpWebResponse;
			try
			{
				httpWebResponse = (httpWebRequest.GetResponse() as HttpWebResponse);
			}
			catch (Exception ex)
			{
				Debug.LogWarning(string.Format("上传音频失败: {0}", ex.Message));
				Loom.QueueOnMainThread(delegate
				{
					if (completeCallback != null)
					{
						completeCallback(string.Empty);
					}
				});
				return;
			}
			if (httpWebResponse.StatusCode == HttpStatusCode.OK)
			{
				string fileName = httpWebResponse.Headers.Get("file_name");
				Debug.Log(" 上传音频成功 fileName = " + fileName);
				Loom.QueueOnMainThread(delegate
				{
					if (completeCallback != null)
					{
						completeCallback(fileName);
					}
				});
			}
			else
			{
				Debug.LogWarning(string.Format("上传音频失败: {0}", httpWebResponse.StatusCode.ToString()));
				Loom.QueueOnMainThread(delegate
				{
					if (completeCallback != null)
					{
						completeCallback(string.Empty);
					}
				});
			}
		}

		private void DownloadAudio(string audioName, string saveAudioFile, Action<string> completeCallback)
		{
			string str = string.Format("?file_name={0}", audioName);
			string uri = "http://14.17.120.214:8090/storage/get_voice" + str;
			HttpWebRequest httpWebRequest = WebRequest.Create(AudioManager.AppendTimestampWithUri(uri)) as HttpWebRequest;
			httpWebRequest.Timeout = 20000;
			HttpWebResponse httpWebResponse;
			try
			{
				httpWebResponse = (httpWebRequest.GetResponse() as HttpWebResponse);
			}
			catch (Exception ex)
			{
				Debug.LogWarning(string.Format("下载音频{0}失败: {1}", audioName, ex.Message));
				Loom.QueueOnMainThread(delegate
				{
					if (completeCallback != null)
					{
						completeCallback(string.Empty);
					}
				});
				return;
			}
			if (httpWebResponse.StatusCode == HttpStatusCode.OK && httpWebResponse.ContentType.StartsWith("audio", StringComparison.OrdinalIgnoreCase))
			{
				using (Stream responseStream = httpWebResponse.GetResponseStream())
				{
					using (Stream stream = File.OpenWrite(saveAudioFile))
					{
						byte[] array = new byte[1024];
						int num;
						do
						{
							num = responseStream.Read(array, 0, array.Length);
							stream.Write(array, 0, num);
						}
						while (num != 0);
					}
				}
				Debug.Log("下载音频成功 audioName = " + audioName);
				Loom.QueueOnMainThread(delegate
				{
					if (completeCallback != null)
					{
						completeCallback(audioName + ";" + saveAudioFile);
					}
				});
			}
			else
			{
				Debug.LogWarning(string.Format("下载音频{0}失败: {1}", audioName, httpWebResponse.StatusCode.ToString()));
				Loom.QueueOnMainThread(delegate
				{
					if (completeCallback != null)
					{
						completeCallback(string.Empty);
					}
				});
			}
		}

		public static string AppendTimestampWithUri(string uri)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(uri);
			stringBuilder.Append((!uri.Contains("?")) ? "?oltimestamp=" : "&oltimestamp=");
			stringBuilder.Append(DateTime.Now.Ticks);
			return stringBuilder.ToString();
		}
	}
}
