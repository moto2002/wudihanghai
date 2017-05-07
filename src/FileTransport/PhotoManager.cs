using System;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

namespace FileTransport
{
	public class PhotoManager
	{
		private static PhotoManager instance;

		private static char[] UC_ENCRYPT_CHARS = new char[]
		{
			'M',
			'D',
			'X',
			'U',
			'P',
			'I',
			'B',
			'E',
			'J',
			'C',
			'T',
			'N',
			'K',
			'O',
			'G',
			'W',
			'R',
			'S',
			'F',
			'Y',
			'V',
			'L',
			'Z',
			'Q',
			'A',
			'H'
		};

		private static char[] LC_ENCRYPT_CHARS = new char[]
		{
			'm',
			'd',
			'x',
			'u',
			'p',
			'i',
			'b',
			'e',
			'j',
			'c',
			't',
			'n',
			'k',
			'o',
			'g',
			'w',
			'r',
			's',
			'f',
			'y',
			'v',
			'l',
			'z',
			'q',
			'a',
			'h'
		};

		public static PhotoManager GetInstance()
		{
			if (PhotoManager.instance == null)
			{
				PhotoManager.instance = new PhotoManager();
			}
			return PhotoManager.instance;
		}

		public void ExePhotoForUpload(string[] photoFiles, int serverId, int playerId, Action<string> completeCallback)
		{
			Loom.RunAsync(delegate
			{
				this.UploadPhotos(photoFiles, serverId, playerId, completeCallback);
			});
		}

		public void ExePhotoForDownload(string photoName, string savePhotoFile, int serverId, int playerId, int type, Action<string> completeCallback)
		{
			Loom.RunAsync(delegate
			{
				this.DownloadPhoto(photoName, savePhotoFile, serverId, playerId, type, completeCallback);
			});
		}

		public void ExePhotoForDelete(string photoName, string savePhotoPath, int serverId, int playerId)
		{
			Loom.RunAsync(delegate
			{
				this.DeletePhoto(photoName, savePhotoPath, serverId, playerId);
			});
		}

		private void UploadPhotos(string[] photoFiles, int serverId, int playerId, Action<string> completeCallback)
		{
			string text = string.Format("server_id={0}&id={1}", serverId, playerId);
			text = this.encrypt(Convert.ToBase64String(Encoding.Default.GetBytes(text)));
			text = "?data=" + text;
			string uri = "http://14.17.120.214:8090/storage/save_avatar" + text;
			HttpWebRequest httpWebRequest = WebRequest.Create(PhotoManager.AppendTimestampWithUri(uri)) as HttpWebRequest;
			httpWebRequest.ContentType = "image/x-png";
			httpWebRequest.Method = "POST";
			httpWebRequest.KeepAlive = true;
			httpWebRequest.Timeout = 20000;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
			using (Stream stream = new MemoryStream())
			{
				for (int i = 0; i < photoFiles.Length; i++)
				{
					using (FileStream fileStream = new FileStream(photoFiles[i], FileMode.Open, FileAccess.Read))
					{
						byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(fileStream.Length));
						stream.Write(bytes, 0, bytes.Length);
						byte[] array = new byte[1024];
						int count;
						while ((count = fileStream.Read(array, 0, array.Length)) != 0)
						{
							stream.Write(array, 0, count);
						}
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
				Debug.LogWarning(string.Format("上传照片失败: {0}", ex.Message));
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
				Debug.Log(" 上传照片成功 fileName = " + fileName);
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
				Debug.LogWarning(string.Format("上传照片失败: {0}", httpWebResponse.StatusCode.ToString()));
				Loom.QueueOnMainThread(delegate
				{
					if (completeCallback != null)
					{
						completeCallback(string.Empty);
					}
				});
			}
		}

		private void DownloadPhoto(string photoName, string savePhotoFile, int serverId, int playerId, int type, Action<string> completeCallback)
		{
			string str = string.Format("?server_id={0}&id={1}&file_name={2}&type={3}", new object[]
			{
				serverId,
				playerId,
				photoName,
				type
			});
			string uri = "http://14.17.120.214:8090/storage/get_avatar" + str;
			HttpWebRequest httpWebRequest = WebRequest.Create(PhotoManager.AppendTimestampWithUri(uri)) as HttpWebRequest;
			httpWebRequest.Timeout = 20000;
			HttpWebResponse httpWebResponse;
			try
			{
				httpWebResponse = (httpWebRequest.GetResponse() as HttpWebResponse);
			}
			catch (Exception ex)
			{
				Debug.LogWarning(string.Format("下载照片{0}失败: {1}", photoName, ex.Message));
				Loom.QueueOnMainThread(delegate
				{
					if (completeCallback != null)
					{
						completeCallback(string.Empty);
					}
				});
				return;
			}
			if (httpWebResponse.StatusCode == HttpStatusCode.OK && httpWebResponse.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
			{
				string text = httpWebResponse.Headers.Get("file_name");
				if (text != null && text.Equals("default"))
				{
					savePhotoFile += "_error";
				}
				savePhotoFile += ".png";
				using (Stream responseStream = httpWebResponse.GetResponseStream())
				{
					using (Stream stream = File.OpenWrite(savePhotoFile))
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
				Debug.Log("下载照片成功 photoName = " + photoName);
				Loom.QueueOnMainThread(delegate
				{
					if (completeCallback != null)
					{
						completeCallback(photoName + ";" + savePhotoFile);
					}
				});
			}
			else
			{
				Debug.LogWarning(string.Format("下载照片{0}失败: {1}", photoName, httpWebResponse.StatusCode.ToString()));
				Loom.QueueOnMainThread(delegate
				{
					if (completeCallback != null)
					{
						completeCallback(string.Empty);
					}
				});
			}
		}

		private bool DeletePhoto(string photoName, string savePhotoPath, int serverId, int playerId)
		{
			string text = string.Format("server_id={0}&id={1}&file_name={2}", serverId, playerId, photoName);
			text = this.encrypt(Convert.ToBase64String(Encoding.Default.GetBytes(text)));
			text = "?data=" + text;
			string uri = "http://14.17.120.214:8090/storage/delete_avatar" + text;
			HttpWebRequest httpWebRequest = WebRequest.Create(PhotoManager.AppendTimestampWithUri(uri)) as HttpWebRequest;
			httpWebRequest.Timeout = 20000;
			HttpWebResponse httpWebResponse;
			try
			{
				httpWebResponse = (httpWebRequest.GetResponse() as HttpWebResponse);
			}
			catch (Exception ex)
			{
				Debug.LogWarning(string.Format("删除照片{0}失败: {1}", photoName, ex.Message));
				bool result = false;
				return result;
			}
			if (httpWebResponse.StatusCode == HttpStatusCode.OK)
			{
				Debug.Log("删除照片成功 photoName = " + photoName);
				string[] array = photoName.Split(new char[]
				{
					':'
				}, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					File.Delete(Path.Combine(savePhotoPath, array[i] + ".png"));
					File.Delete(Path.Combine(savePhotoPath, array[i] + "_small.png"));
				}
				return true;
			}
			Debug.LogWarning(string.Format("删除照片{0}失败: {1}", photoName, httpWebResponse.StatusCode.ToString()));
			return false;
		}

		private char encrypt(char b)
		{
			if (b >= 'A' && b <= 'Z')
			{
				return PhotoManager.UC_ENCRYPT_CHARS[(int)(b - 'A')];
			}
			if (b >= 'a' && b <= 'z')
			{
				return PhotoManager.LC_ENCRYPT_CHARS[(int)(b - 'a')];
			}
			return b;
		}

		private string encrypt(string input)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < input.Length; i++)
			{
				stringBuilder.Append(this.encrypt(input[i]));
			}
			return stringBuilder.ToString();
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
