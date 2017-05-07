using LuaInterface;
using System;
using UnityEngine;

namespace Hummingbird.SeaBattle.Utility.Platform
{
	public class PlatformUtilDefault : PlatformUtil
	{
		private int iFileIndex = 1;

		public override int GetAppVersionCode()
		{
			return 0;
		}

		public override string GetAppVersionName()
		{
			return "0";
		}

		public override string GetPlatformName()
		{
			return "windows";
		}

		public override string GetLocalIpAddress()
		{
			return "ip";
		}

		public override string GetDeviceMacAddress()
		{
			return "macaddress";
		}

		public override string GetDeviceNetworkType()
		{
			return "networktype";
		}

		public override string GetDeviceManufacturer()
		{
			return string.Empty;
		}

		public override string GetDeviceModel()
		{
			return "windows";
		}

		public override string GetDeviceSystemVersion()
		{
			return "windows";
		}

		public override string GetUUID()
		{
			return "windows_uuid";
		}

		public override string GetProvidersName()
		{
			return string.Empty;
		}

		public override string GetIMEI()
		{
			return "deviceId";
		}

		public override string GetIDFA()
		{
			return string.Empty;
		}

		public override string GetSimSerialNumber()
		{
			return string.Empty;
		}

		public override string GetAndroidID()
		{
			return "androidID";
		}

		public override string GetScreenSize()
		{
			return "0";
		}

		public override string GetDeviceTotalMemorySize()
		{
			return "0";
		}

		public override string GetDeviceAvailableMemorySize()
		{
			return "0";
		}

		public override string GetTotalInternalBlockSize()
		{
			return "0";
		}

		public override string GetAvailableInternalBlockSize()
		{
			return "0";
		}

		public override string IsExistSDCard()
		{
			return "0";
		}

		public override string GetTotalSDCardBlockSize()
		{
			return "0";
		}

		public override string GetAvailableSDCardBlockSize()
		{
			return "0";
		}

		public override bool IsNetworkConnected(bool isShowTips)
		{
			return true;
		}

		public override void ShowDeviceTips(string title, string content, Action<bool> completeCallback)
		{
			completeCallback(true);
		}

		public override void UpdateFullPackage(string pkgUrl)
		{
		}

		public override string GetChannelId()
		{
			return "youai01";
		}

		public override void ExtractFile(string zipFilePath, string location, Action<string> completeCallback)
		{
		}

		public override void OpenPhotoAlbum(Action<string> completeCallback)
		{
		}

		public override void OpenCamera(Action<string> completeCallback)
		{
			this.OpenPhotoAlbum(completeCallback);
		}

		public override void StartRecording(Action<string> completeCallback)
		{
		}

		public override void FinishRecording()
		{
		}

		public override void PlayAudio(string audioFile)
		{
		}

		public override void StopAudio()
		{
		}

		public override void TranslateAudio(string audioFile, Action<string> completeCallback)
		{
		}

		public override void GetAudioDuration(string audioFile, Action<int> completeCallback)
		{
		}

		public override void InitXGPush()
		{
		}

		public override string GetXGPushToken()
		{
			return string.Empty;
		}

		public override void OpenWebView(string url, Rect viewRect, Action<bool> completeCallback)
		{
		}

		public override void CloseWebView()
		{
		}

		public override string GetLocalFileInfo()
		{
			return "{}";
		}

		public override void SetLocalFileInfo(string key, string value)
		{
		}

		public override void RegisterBatteryReceiver(LuaFunction luaFunc)
		{
		}

		public override string GetSessionId(bool reGenerate)
		{
			return Convert.ToString(DateTime.Now.Ticks);
		}

		public override void Login(string customParam, LuaFunction luaFunc)
		{
			this.loginLuaFunction = luaFunc;
			base.SendLoginResult(null);
		}

		public override void Pay(string jsonPayData)
		{
		}

		public override void SubmitRoleData(string jsonRoleData)
		{
		}

		public override bool HasChannelCenter()
		{
			return false;
		}

		public override void OpenChannelCenter()
		{
		}

		public override void CallSdkEvent(string jsonData)
		{
		}

		public override void SwitchAccount(LuaFunction luaFunc)
		{
			this.switchAccountLuaFunction = luaFunc;
			base.SendSwitchAccountResult();
		}

		public override void ExitApp()
		{
		}
	}
}
