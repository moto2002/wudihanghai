using FileTransport;
using Hummingbird.SeaBattle.Utility.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Hummingbird.SeaBattle.Utility
{
	public static class PhotoUtil
	{
		public enum PhotoType
		{
			THUMBNAILS,
			ORIGINALIMAGE
		}

		private static Dictionary<string, List<Action<string>>> downloadImageDict = new Dictionary<string, List<Action<string>>>();

		public static void OpenPhotoAlbum(Action<string> completeCallback)
		{
			PlatformUtil.GetInstance().OpenPhotoAlbum(completeCallback);
		}

		public static void OpenCamera(Action<string> completeCallback)
		{
			PlatformUtil.GetInstance().OpenCamera(completeCallback);
		}

		public static void UploadPhotos(string[] photoFiles, int serverId, int playerId, Action<string> completeCallback)
		{
			PhotoManager.GetInstance().ExePhotoForUpload(photoFiles, serverId, playerId, completeCallback);
		}

		public static void DownloadPhoto(string photoName, int serverId, int playerId, PhotoUtil.PhotoType type, Action<string> completeCallback)
		{
			if (string.IsNullOrEmpty(photoName))
			{
				return;
			}
			string path = photoName;
			if (type == PhotoUtil.PhotoType.THUMBNAILS)
			{
				path = photoName + "_small";
			}
			string text = Path.Combine(Application.persistentDataPath, "photos");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, path);
			if (File.Exists(text2 + ".png"))
			{
				completeCallback(photoName + ";" + text2 + ".png");
			}
			else if (PhotoUtil.downloadImageDict.ContainsKey(photoName))
			{
				PhotoUtil.downloadImageDict[photoName].Add(completeCallback);
			}
			else
			{
				List<Action<string>> list = new List<Action<string>>();
				list.Add(completeCallback);
				PhotoUtil.downloadImageDict.Add(photoName, list);
				PhotoManager.GetInstance().ExePhotoForDownload(photoName, text2, serverId, playerId, (int)type, delegate(string photo)
				{
					List<Action<string>> list2 = PhotoUtil.downloadImageDict[photoName];
					for (int i = 0; i < list2.Count; i++)
					{
						list2[i](photo);
					}
					PhotoUtil.downloadImageDict.Remove(photoName);
				});
			}
		}

		public static void DownloadPhoto(string photoName, int playerId, PhotoUtil.PhotoType type, Action<string> completeCallback)
		{
			PhotoUtil.DownloadPhoto(photoName, 0, playerId, type, completeCallback);
		}

		public static void DeletePhotos(string[] photoNames, int serverId, int playerId)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < photoNames.Length; i++)
			{
				if (!string.IsNullOrEmpty(photoNames[i]))
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(":");
					}
					stringBuilder.Append(photoNames[i]);
				}
			}
			if (stringBuilder.Length == 0)
			{
				return;
			}
			string text = Path.Combine(Application.persistentDataPath, "photos");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			PhotoManager.GetInstance().ExePhotoForDelete(stringBuilder.ToString(), text, serverId, playerId);
		}
	}
}
