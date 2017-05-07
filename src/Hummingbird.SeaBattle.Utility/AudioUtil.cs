using FileTransport;
using Hummingbird.SeaBattle.Utility.Platform;
using System;
using System.IO;
using UnityEngine;

namespace Hummingbird.SeaBattle.Utility
{
	public static class AudioUtil
	{
		public static readonly string AUDIO_RECORDING_ERROR = "error";

		public static void StartRecording(Action<string> completeCallback)
		{
			PlatformUtil.GetInstance().StartRecording(completeCallback);
		}

		public static void FinishRecording()
		{
			PlatformUtil.GetInstance().FinishRecording();
		}

		public static void PlayAudio(string audioFile)
		{
			PlatformUtil.GetInstance().PlayAudio(audioFile);
		}

		public static void StopAduio()
		{
			PlatformUtil.GetInstance().StopAudio();
		}

		public static void TranslateAudio(string audioFile, Action<string> completeCallback)
		{
			PlatformUtil.GetInstance().TranslateAudio(audioFile, completeCallback);
		}

		public static void GetAudioDuration(string audioFile, Action<int> completeCallback)
		{
			PlatformUtil.GetInstance().GetAudioDuration(audioFile, completeCallback);
		}

		public static void UploadAudio(string audioFile, Action<string> completeCallback)
		{
			AudioManager.GetInstance().ExeAudioForUpload(audioFile, completeCallback);
		}

		public static void DownloadAudio(string audioName, Action<string> completeCallback)
		{
			string text = Path.Combine(Application.persistentDataPath, "audios");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, audioName + ".amr");
			if (File.Exists(text2))
			{
				completeCallback(audioName + ";" + text2);
			}
			else
			{
				AudioManager.GetInstance().ExeAudioForDownload(audioName, text2, completeCallback);
			}
		}
	}
}
