using LuaFramework;
using LuaInterface;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Hummingbird.SeaBattle.Utility.Platform
{
	public class PlatformUtilIOS : PlatformUtil
	{
		[DllImport("__Internal")]
		private static extern int getAppVersionCode();

		[DllImport("__Internal")]
		private static extern string getAppVersionName();

		[DllImport("__Internal")]
		private static extern string getLocalIpAddress();

		[DllImport("__Internal")]
		private static extern string getDeviceNetworkType();

		[DllImport("__Internal")]
		private static extern string getDeviceModel();

		[DllImport("__Internal")]
		private static extern string getDeviceSystemVersion();

		[DllImport("__Internal")]
		private static extern string getUUID();

		[DllImport("__Internal")]
		private static extern string getProvidersName();

		[DllImport("__Internal")]
		private static extern string getIDFA();

		[DllImport("__Internal")]
		private static extern string getScreenSize();

		[DllImport("__Internal")]
		private static extern string getDeviceTotalMemorySize();

		[DllImport("__Internal")]
		private static extern string getDeviceAvailableMemorySize();

		[DllImport("__Internal")]
		private static extern string getTotalInternalBlockSize();

		[DllImport("__Internal")]
		private static extern string getAvailableInternalBlockSize();

		[DllImport("__Internal")]
		private static extern bool isNetworkConnected(bool isShowTips);

		[DllImport("__Internal")]
		private static extern void showIOSTips(string stringId);

		[DllImport("__Internal")]
		private static extern void updateFullPackage(string pkgUrl);

		[DllImport("__Internal")]
		private static extern string getChannelId();

		[DllImport("__Internal")]
		private static extern void extractFile(string zipFilePath, string location);

		[DllImport("__Internal")]
		private static extern void openPhotoAlbum();

		[DllImport("__Internal")]
		private static extern void openCamera();

		[DllImport("__Internal")]
		private static extern void startRecording();

		[DllImport("__Internal")]
		private static extern void finishRecording();

		[DllImport("__Internal")]
		private static extern void playAudio(string audioFile);

		[DllImport("__Internal")]
		private static extern void stopAudio();

		[DllImport("__Internal")]
		private static extern void translateAudio(string audioFile);

		[DllImport("__Internal")]
		private static extern void getAudioDuration(string audioFile);

		[DllImport("__Internal")]
		private static extern void openWebView(string url, int left, int top, int right, int bottom);

		[DllImport("__Internal")]
		private static extern void closeWebView();

		[DllImport("__Internal")]
		private static extern void registerBatteryReceiver();

		[DllImport("__Internal")]
		private static extern string getSessionId(bool reGenerate);

		[DllImport("__Internal")]
		private static extern void login();

		[DllImport("__Internal")]
		private static extern void pay(string payContent);

		[DllImport("__Internal")]
		private static extern void submitRoleData(string roleContent);

		[DllImport("__Internal")]
		private static extern void callSdkEvent(string jsonData);

		[DllImport("__Internal")]
		private static extern void switchAccount();

		[DllImport("__Internal")]
		private static extern bool hasChannelCenter();

		[DllImport("__Internal")]
		private static extern void openChannelCenter();

		[DllImport("__Internal")]
		private static extern void initXGPush();

		[DllImport("__Internal")]
		private static extern string getPushToken();

		public override string GetPlatformName()
		{
			return "iOS";
		}

		public override int GetAppVersionCode()
		{
			return PlatformUtilIOS.getAppVersionCode();
		}

		public override string GetAppVersionName()
		{
			return PlatformUtilIOS.getAppVersionName();
		}

		public override string GetLocalIpAddress()
		{
			return PlatformUtilIOS.getLocalIpAddress();
		}

		public override string GetDeviceMacAddress()
		{
			return string.Empty;
		}

		public override string GetDeviceNetworkType()
		{
			return PlatformUtilIOS.getDeviceNetworkType();
		}

		public override string GetDeviceManufacturer()
		{
			return "Apple";
		}

		public override string GetDeviceModel()
		{
			return PlatformUtilIOS.getDeviceModel();
		}

		public override string GetDeviceSystemVersion()
		{
			return PlatformUtilIOS.getDeviceSystemVersion();
		}

		public override string GetUUID()
		{
			if (string.IsNullOrEmpty(this.deviceUUID))
			{
				return PlatformUtilIOS.getUUID();
			}
			return this.deviceUUID;
		}

		public override string GetProvidersName()
		{
			return PlatformUtilIOS.getProvidersName();
		}

		public override string GetIMEI()
		{
			return string.Empty;
		}

		public override string GetIDFA()
		{
			return PlatformUtilIOS.getIDFA();
		}

		public override string GetSimSerialNumber()
		{
			return string.Empty;
		}

		public override string GetAndroidID()
		{
			return string.Empty;
		}

		public override string GetScreenSize()
		{
			return PlatformUtilIOS.getScreenSize();
		}

		public override string GetDeviceTotalMemorySize()
		{
			return PlatformUtilIOS.getDeviceTotalMemorySize();
		}

		public override string GetDeviceAvailableMemorySize()
		{
			return PlatformUtilIOS.getDeviceAvailableMemorySize();
		}

		public override string GetTotalInternalBlockSize()
		{
			return PlatformUtilIOS.getTotalInternalBlockSize();
		}

		public override string GetAvailableInternalBlockSize()
		{
			return PlatformUtilIOS.getAvailableInternalBlockSize();
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
			return PlatformUtilIOS.isNetworkConnected(isShowTips);
		}

		public override void ShowDeviceTips(string title, string content, Action<bool> completeCallback)
		{
			this.clickDeviceTipsCallback = completeCallback;
			PlatformUtilIOS.showIOSTips(content);
		}

		public override void UpdateFullPackage(string pkgUrl)
		{
			PlatformUtilIOS.updateFullPackage(pkgUrl);
		}

		public override string GetChannelId()
		{
			if (string.IsNullOrEmpty(this.channelCode))
			{
				this.channelCode = PlatformUtilIOS.getChannelId();
			}
			return this.channelCode;
		}

		public override void ExtractFile(string zipFilePath, string location, Action<string> completeCallback)
		{
			this.unzipFileCallback = completeCallback;
			PlatformUtilIOS.extractFile(zipFilePath, location);
		}

		public override void OpenPhotoAlbum(Action<string> completeCallback)
		{
			this.pickPhotoCallback = completeCallback;
			PlatformUtilIOS.openPhotoAlbum();
		}

		public override void OpenCamera(Action<string> completeCallback)
		{
			this.pickPhotoCallback = completeCallback;
			PlatformUtilIOS.openCamera();
		}

		public override void StartRecording(Action<string> completeCallback)
		{
			this.pickAudioCallback = completeCallback;
			PlatformUtilIOS.startRecording();
		}

		public override void FinishRecording()
		{
			PlatformUtilIOS.finishRecording();
		}

		public override void PlayAudio(string audioFile)
		{
			PlatformUtilIOS.playAudio(audioFile);
		}

		public override void StopAudio()
		{
			PlatformUtilIOS.stopAudio();
		}

		public override void TranslateAudio(string audioFile, Action<string> completeCallback)
		{
			this.translateAudioCallback = completeCallback;
			PlatformUtilIOS.translateAudio(audioFile);
		}

		public override void GetAudioDuration(string audioFile, Action<int> completeCallback)
		{
			this.getAudioDurationCallback = completeCallback;
			PlatformUtilIOS.getAudioDuration(audioFile);
		}

		public override void InitXGPush()
		{
			PlatformUtilIOS.initXGPush();
		}

		public override string GetXGPushToken()
		{
			return PlatformUtilIOS.getPushToken();
		}

		public override void OpenWebView(string url, Rect viewRect, Action<bool> completeCallback)
		{
			this.openWebViewCallback = completeCallback;
			string url2 = Util.AppendTimestampForUri(url);
			PlatformUtilIOS.openWebView(url2, (int)viewRect.xMin, (int)viewRect.yMin, (int)viewRect.width, (int)viewRect.height);
		}

		public override void CloseWebView()
		{
			PlatformUtilIOS.closeWebView();
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
			if (this.batteryLuaFunction != null)
			{
				this.batteryLuaFunction.Dispose();
				this.batteryLuaFunction = null;
			}
			this.batteryLuaFunction = luaFunc;
			PlatformUtilIOS.registerBatteryReceiver();
		}

		public override string GetSessionId(bool reGenerate)
		{
			return PlatformUtilIOS.getSessionId(reGenerate);
		}

		public override void Login(string customParam, LuaFunction luaFunc)
		{
			this.loginLuaFunction = luaFunc;
			if (base.NeedCallSDK())
			{
				LuaHelper.GetDeviceDrainModel().RecordCallSDKLogin();
				PlatformUtilIOS.login();
			}
			else
			{
				base.SendLoginResult(null);
			}
		}

		public override void Pay(string jsonPayData)
		{
			if (base.NeedCallSDK())
			{
				PlatformUtilIOS.pay(jsonPayData);
			}
		}

		public override void SubmitRoleData(string jsonRoleData)
		{
			if (base.NeedCallSDK())
			{
				PlatformUtilIOS.submitRoleData(jsonRoleData);
			}
		}

		public override bool HasChannelCenter()
		{
			return PlatformUtilIOS.hasChannelCenter();
		}

		public override void OpenChannelCenter()
		{
			PlatformUtilIOS.openChannelCenter();
		}

		public override void CallSdkEvent(string jsonData)
		{
			PlatformUtilIOS.callSdkEvent(jsonData);
		}

		public override void SwitchAccount(LuaFunction luaFunc)
		{
			this.switchAccountLuaFunction = luaFunc;
			if (base.NeedCallSDK())
			{
				PlatformUtilIOS.switchAccount();
			}
			else
			{
				base.SendSwitchAccountResult();
			}
		}

		public override void ExitApp()
		{
			Application.Quit();
		}
	}
}
