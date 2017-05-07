using Hummingbird.Model;
using LuaInterface;
using System;
using UnityEngine;

namespace Hummingbird.SeaBattle.Utility.Platform
{
	public abstract class PlatformUtil
	{
		private static PlatformUtil instance;

		[NoToLua]
		public Action<string> unzipFileCallback;

		[NoToLua]
		public Action<bool> clickDeviceTipsCallback;

		[NoToLua]
		public Action<string> pickPhotoCallback;

		[NoToLua]
		public Action<string> pickAudioCallback;

		[NoToLua]
		public Action<int> getAudioDurationCallback;

		[NoToLua]
		public Action<string> translateAudioCallback;

		[NoToLua]
		public Action<bool> openWebViewCallback;

		protected LuaFunction loginLuaFunction;

		protected LuaFunction logoutLuaFunction;

		protected LuaFunction switchAccountLuaFunction;

		protected LuaFunction batteryLuaFunction;

		protected string channelCode = string.Empty;

		protected string deviceUUID = string.Empty;

		protected string sdkLoginInfo = string.Empty;

		public static PlatformUtil GetInstance()
		{
			if (PlatformUtil.instance == null)
			{
				PlatformUtil.instance = new PlatformUtilAndroid();
			}
			return PlatformUtil.instance;
		}

		public abstract int GetAppVersionCode();

		public abstract string GetAppVersionName();

		public abstract string GetPlatformName();

		public abstract string GetProvidersName();

		public abstract string GetIMEI();

		public abstract string GetAndroidID();

		public abstract string GetIDFA();

		public abstract string GetSimSerialNumber();

		public abstract string GetLocalIpAddress();

		public abstract string GetDeviceMacAddress();

		public abstract string GetDeviceNetworkType();

		public abstract string GetDeviceManufacturer();

		public abstract string GetDeviceModel();

		public abstract string GetScreenSize();

		public abstract string GetDeviceSystemVersion();

		public abstract string GetDeviceTotalMemorySize();

		public abstract string GetDeviceAvailableMemorySize();

		public abstract string GetTotalInternalBlockSize();

		public abstract string GetAvailableInternalBlockSize();

		public abstract string IsExistSDCard();

		public abstract string GetTotalSDCardBlockSize();

		public abstract string GetAvailableSDCardBlockSize();

		public abstract string GetUUID();

		public abstract bool IsNetworkConnected(bool isShowTips);

		[NoToLua]
		public abstract void ShowDeviceTips(string title, string content, Action<bool> completeCallback);

		[NoToLua]
		public abstract void UpdateFullPackage(string pkgUrl);

		[NoToLua]
		public abstract void ExtractFile(string zipFilePath, string location, Action<string> completeCallback);

		public abstract void OpenPhotoAlbum(Action<string> completeCallback);

		public abstract void OpenCamera(Action<string> completeCallback);

		public abstract void StartRecording(Action<string> completeCallback);

		public abstract void FinishRecording();

		public abstract void PlayAudio(string audioFile);

		public abstract void StopAudio();

		public abstract void TranslateAudio(string audioFile, Action<string> completeCallback);

		public abstract void GetAudioDuration(string audioFile, Action<int> completeCallback);

		public abstract void InitXGPush();

		public abstract string GetXGPushToken();

		[NoToLua]
		public abstract void ExitApp();

		[NoToLua]
		public abstract void OpenWebView(string url, Rect viewRect, Action<bool> completeCallback);

		[NoToLua]
		public abstract void CloseWebView();

		public abstract string GetLocalFileInfo();

		public abstract void SetLocalFileInfo(string key, string value);

		public abstract void RegisterBatteryReceiver(LuaFunction luaFunc);

		public abstract string GetSessionId(bool reGenerate);

		[NoToLua]
		public abstract string GetChannelId();

		public abstract void Login(string customParam, LuaFunction luaFunc);

		public abstract void Pay(string jsonPayData);

		public abstract void SubmitRoleData(string jsonRoleData);

		public abstract bool HasChannelCenter();

		public abstract void OpenChannelCenter();

		public abstract void CallSdkEvent(string jsonData);

		public abstract void SwitchAccount(LuaFunction luaFunc);

		public void SetLogoutListener(LuaFunction luaFunc)
		{
			if (this.logoutLuaFunction != null)
			{
				this.logoutLuaFunction.Dispose();
				this.logoutLuaFunction = null;
			}
			this.logoutLuaFunction = luaFunc;
		}

		[NoToLua]
		public bool NeedCallSDK()
		{
			return !GameConfigInfo.GetInstance().channelCode.Equals("youai01") && !GameConfigInfo.GetInstance().channelCode.Equals("youaiios01");
		}

		[NoToLua]
		public void SendLoginResult(string loginInfo)
		{
			if (this.loginLuaFunction != null)
			{
				this.sdkLoginInfo = string.Empty;
				this.loginLuaFunction.Call(new object[]
				{
					loginInfo
				});
				this.loginLuaFunction.Dispose();
				this.loginLuaFunction = null;
			}
			else
			{
				this.sdkLoginInfo = loginInfo;
			}
		}

		[NoToLua]
		public void SendSwitchAccountResult()
		{
			if (this.switchAccountLuaFunction != null)
			{
				this.switchAccountLuaFunction.Call();
				this.switchAccountLuaFunction.Dispose();
				this.switchAccountLuaFunction = null;
			}
		}

		[NoToLua]
		public void SendLogoutResult()
		{
			if (this.logoutLuaFunction != null)
			{
				this.logoutLuaFunction.Call();
			}
		}

		[NoToLua]
		public void SendBatteryLowerEvent()
		{
			if (this.batteryLuaFunction != null)
			{
				this.batteryLuaFunction.Call();
				this.batteryLuaFunction.Dispose();
				this.batteryLuaFunction = null;
			}
		}
	}
}
