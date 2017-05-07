using Hummingbird.Model;
using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

namespace Hummingbird.SeaBattle.Utility.Platform
{
	public class PlatformUtilAndroid : PlatformUtil
	{
		private AndroidJavaObject javaObject;

		public PlatformUtilAndroid()
		{
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				this.javaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			}
		}

		public override string GetPlatformName()
		{
			return "Android";
		}

		public override int GetAppVersionCode()
		{
			return this.JavaCall<int>("getAppVersionCode", new object[0]);
		}

		public override string GetAppVersionName()
		{
			return this.JavaCall<string>("getAppVersionName", new object[0]);
		}

		public override string GetLocalIpAddress()
		{
			return this.JavaCall<string>("getLocalIpAddress", new object[0]);
		}

		public override string GetDeviceMacAddress()
		{
			return this.JavaCall<string>("getDeviceMacAddress", new object[0]);
		}

		public override string GetDeviceNetworkType()
		{
			return this.JavaCall<string>("getDeviceNetworkType", new object[0]);
		}

		public override string GetDeviceManufacturer()
		{
			return this.JavaCall<string>("getDeviceManufacturer", new object[0]);
		}

		public override string GetDeviceModel()
		{
			return this.JavaCall<string>("getDeviceModel", new object[0]);
		}

		public override string GetDeviceSystemVersion()
		{
			return this.JavaCall<string>("getDeviceSystemVersion", new object[0]);
		}

		public override string GetUUID()
		{
			if (string.IsNullOrEmpty(this.deviceUUID))
			{
				return this.JavaCall<string>("getUUID", new object[0]);
			}
			return this.deviceUUID;
		}

		public override string GetProvidersName()
		{
			return this.JavaCall<string>("getProvidersName", new object[0]);
		}

		public override string GetIMEI()
		{
			return this.JavaCall<string>("getIMEI", new object[0]);
		}

		public override string GetIDFA()
		{
			return string.Empty;
		}

		public override string GetSimSerialNumber()
		{
			return this.JavaCall<string>("getSimSerialNumber", new object[0]);
		}

		public override string GetAndroidID()
		{
			return this.JavaCall<string>("getAndroidID", new object[0]);
		}

		public override string GetScreenSize()
		{
			return this.JavaCall<string>("getScreenSize", new object[0]);
		}

		public override string GetDeviceTotalMemorySize()
		{
			return this.JavaCall<string>("getDeviceTotalMemorySize", new object[0]);
		}

		public override string GetDeviceAvailableMemorySize()
		{
			return this.JavaCall<string>("getDeviceAvailableMemorySize", new object[0]);
		}

		public override string GetTotalInternalBlockSize()
		{
			return this.JavaCall<string>("getTotalInternalBlockSize", new object[0]);
		}

		public override string GetAvailableInternalBlockSize()
		{
			return this.JavaCall<string>("getAvailableInternalBlockSize", new object[0]);
		}

		public override string IsExistSDCard()
		{
			return this.JavaCall<string>("isExistSDCard", new object[0]);
		}

		public override string GetTotalSDCardBlockSize()
		{
			return this.JavaCall<string>("getTotalSDCardBlockSize", new object[0]);
		}

		public override string GetAvailableSDCardBlockSize()
		{
			return this.JavaCall<string>("getAvailableSDCardBlockSize", new object[0]);
		}

		public override bool IsNetworkConnected(bool isShowTips)
		{
			return this.JavaCall<bool>("isNetworkConnected", new object[]
			{
				isShowTips
			});
		}

		public override void ShowDeviceTips(string title, string content, Action<bool> completeCallback)
		{
			this.clickDeviceTipsCallback = completeCallback;
			this.JavaCall("showAndroidTips", new object[]
			{
				title,
				content
			});
		}

		public override void UpdateFullPackage(string pkgUrl)
		{
			this.JavaCall("updateApk", new object[]
			{
				pkgUrl,
				GameConfigInfo.GetInstance().dictExtendConfig.ContainsKey("isGooglePlay")
			});
		}

		public override string GetChannelId()
		{
			if (string.IsNullOrEmpty(this.channelCode))
			{
				this.channelCode = this.JavaCall<string>("getChannelId", new object[0]);
			}
			return this.channelCode;
		}

		public override void ExtractFile(string zipFilePath, string location, Action<string> completeCallback)
		{
			this.unzipFileCallback = completeCallback;
			this.JavaCall("extractFile", new object[]
			{
				zipFilePath,
				location
			});
		}

		public override void OpenPhotoAlbum(Action<string> completeCallback)
		{
			this.pickPhotoCallback = completeCallback;
			this.JavaCall("openPhotoAlbum", new object[0]);
		}

		public override void OpenCamera(Action<string> completeCallback)
		{
			this.pickPhotoCallback = completeCallback;
			this.JavaCall("openCamera", new object[0]);
		}

		public override void StartRecording(Action<string> completeCallback)
		{
			this.pickAudioCallback = completeCallback;
			this.JavaCall("startRecording", new object[0]);
		}

		public override void FinishRecording()
		{
			this.JavaCall("finishRecording", new object[0]);
		}

		public override void PlayAudio(string audioFile)
		{
			this.JavaCall("playAudio", new object[]
			{
				audioFile
			});
		}

		public override void StopAudio()
		{
			this.JavaCall("stopAudio", new object[0]);
		}

		public override void TranslateAudio(string audioFile, Action<string> completeCallback)
		{
			this.translateAudioCallback = completeCallback;
			this.JavaCall("translateAudio", new object[]
			{
				audioFile
			});
		}

		public override void GetAudioDuration(string audioFile, Action<int> completeCallback)
		{
			this.getAudioDurationCallback = completeCallback;
			this.JavaCall("getAudioDuration", new object[]
			{
				audioFile
			});
		}

		public override void InitXGPush()
		{
			this.JavaCall("initXgPush", new object[0]);
		}

		public override string GetXGPushToken()
		{
			return this.JavaCall<string>("getPushToken", new object[0]);
		}

		public override void OpenWebView(string url, Rect viewRect, Action<bool> completeCallback)
		{
			this.openWebViewCallback = completeCallback;
			string text = Util.AppendTimestampForUri(url);
			this.JavaCall("openWebView", new object[]
			{
				text,
				(int)viewRect.xMin,
				(int)viewRect.yMin,
				(int)viewRect.width,
				(int)viewRect.height
			});
		}

		public override void CloseWebView()
		{
			this.JavaCall("closeWebView", new object[0]);
		}

		public override string GetLocalFileInfo()
		{
			string text = this.JavaCall<string>("getLocalFileInfo", new object[0]);
			if (string.IsNullOrEmpty(text))
			{
				return "{}";
			}
			return text;
		}

		public override void SetLocalFileInfo(string key, string value)
		{
			this.JavaCall("setLocalFileInfo", new object[]
			{
				key,
				value
			});
		}

		public override void RegisterBatteryReceiver(LuaFunction luaFunc)
		{
			if (this.batteryLuaFunction != null)
			{
				this.batteryLuaFunction.Dispose();
				this.batteryLuaFunction = null;
			}
			this.batteryLuaFunction = luaFunc;
			this.JavaCall("registerBatteryReceiver", new object[0]);
		}

		public override string GetSessionId(bool reGenerate)
		{
			return this.JavaCall<string>("getSessionId", new object[]
			{
				reGenerate
			});
		}

		public override void Login(string customParam, LuaFunction luaFunc)
		{
			this.loginLuaFunction = luaFunc;
			if (base.NeedCallSDK())
			{
				LuaHelper.GetDeviceDrainModel().RecordCallSDKLogin();
				if (string.IsNullOrEmpty(this.sdkLoginInfo))
				{
					this.JavaCall("login", new object[]
					{
						customParam
					});
				}
				else
				{
					base.SendLoginResult(this.sdkLoginInfo);
				}
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
				this.JavaCall("pay", new object[]
				{
					jsonPayData
				});
			}
		}

		public override void SubmitRoleData(string jsonRoleData)
		{
			if (base.NeedCallSDK())
			{
				this.JavaCall("submitRoleData", new object[]
				{
					jsonRoleData
				});
			}
		}

		public override bool HasChannelCenter()
		{
			return this.JavaCall<bool>("hasChannelCenter", new object[0]);
		}

		public override void OpenChannelCenter()
		{
			this.JavaCall("openChannelCenter", new object[0]);
		}

		public override void CallSdkEvent(string jsonData)
		{
			this.JavaCall("callSdkEvent", new object[]
			{
				jsonData
			});
		}

		public override void SwitchAccount(LuaFunction luaFunc)
		{
			this.switchAccountLuaFunction = luaFunc;
			if (base.NeedCallSDK())
			{
				this.JavaCall("switchAccount", new object[0]);
			}
			else
			{
				base.SendSwitchAccountResult();
			}
		}

		public override void ExitApp()
		{
			this.JavaCall("exitApp", new object[0]);
		}

		private void JavaCall(string javaMethodName, params object[] args)
		{
			try
			{
				this.javaObject.Call(javaMethodName, args);
			}
			catch (Exception ex)
			{
				Debug.LogWarning(string.Format("调用java方法{0}出现异常:{1}", javaMethodName, ex.Message));
			}
		}

		private ReturnType JavaCall<ReturnType>(string javaMethodName, params object[] args)
		{
			ReturnType result;
			try
			{
				result = this.javaObject.Call<ReturnType>(javaMethodName, args);
			}
			catch (Exception ex)
			{
				Debug.LogWarning(string.Format("调用java方法{0}出现异常:{1}", javaMethodName, ex.Message));
				result = default(ReturnType);
			}
			return result;
		}
	}
}
