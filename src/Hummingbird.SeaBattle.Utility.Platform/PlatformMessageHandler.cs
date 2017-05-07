using LuaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hummingbird.SeaBattle.Utility.Platform
{
	public class PlatformMessageHandler : MonoBehaviour
	{
		public void HandleUnzipResult(string msg)
		{
			string obj = this.ParseMsgFromPlatform(msg)["result"];
			if (PlatformUtil.GetInstance().unzipFileCallback != null)
			{
				PlatformUtil.GetInstance().unzipFileCallback(obj);
			}
		}

		public void HandleClickDeviceTips(string msg)
		{
			string text = this.ParseMsgFromPlatform(msg)["result"];
			if (PlatformUtil.GetInstance().clickDeviceTipsCallback != null)
			{
				PlatformUtil.GetInstance().clickDeviceTipsCallback(text.Equals("1"));
			}
		}

		public void HandleOpenWebView(string msg)
		{
			Util.Log("打开WebView，接收到平台发送过来的消息 : " + msg);
			if (PlatformUtil.GetInstance().openWebViewCallback != null)
			{
				string value = this.ParseMsgFromPlatform(msg)["success"];
				PlatformUtil.GetInstance().openWebViewCallback(bool.Parse(value));
			}
		}

		public void HandleBatteryChanged(string msg)
		{
			Util.Log("接收到平台发送过来的电量信息 : " + msg);
			PlatformUtil.GetInstance().SendBatteryLowerEvent();
		}

		public void HandleSdkLogin(string msg)
		{
			Util.Log("sdk登录，接收到平台发送过来的消息 : " + msg);
			Dictionary<string, string> dictionary = this.ParseMsgFromPlatform(msg);
			if (dictionary.ContainsKey("viewName"))
			{
				PlatformUtil.GetInstance().SendLoginResult(dictionary["viewName"]);
			}
			else
			{
				LuaHelper.GetDeviceDrainModel().RecordSDKLoginResult(this.ParseMsgFromPlatform(msg));
				PlatformUtil.GetInstance().SendLoginResult(msg);
			}
		}

		public void HandleSdkLogout(string msg)
		{
			Util.Log("sdk登出，接收到平台发送过来的消息 : " + msg);
			PlatformUtil.GetInstance().SendLogoutResult();
		}

		public void HandleSdkSwitchAccount(string msg)
		{
			Util.Log("sdk切换帐号，接收到平台发送过来的消息 : " + msg);
			PlatformUtil.GetInstance().SendSwitchAccountResult();
		}

		public void HandleExitApp(string msg)
		{
			Util.Log("接收平台返回的退出游戏事件 : " + msg);
			LuaHelper.GetNetManager().Disconnect();
			PlatformUtil.GetInstance().ExitApp();
		}

		public void HandleSendRequestAfterSDKInit(string msg)
		{
			Util.Log("接收平台返回的SDK初始化信息事件 : " + msg);
			int status = Convert.ToInt32(this.ParseMsgFromPlatform(msg)["status"]);
			LuaHelper.GetDeviceDrainModel().RecordSDKInitResult(status);
		}

		public void HandleSendRequestAfterDownload(string msg)
		{
			Util.Log("接收平台返回的整包下载完后事件 : " + msg);
			Dictionary<string, string> dictionary = this.ParseMsgFromPlatform(msg);
			if (dictionary.ContainsKey("msg"))
			{
				LuaHelper.GetDeviceDrainModel().RecordAfterDownloadUpdate(0, dictionary["msg"]);
			}
			else
			{
				LuaHelper.GetDeviceDrainModel().RecordAfterDownloadUpdate(1, string.Empty);
			}
		}

		public void HandleSendGameGuide(string msg)
		{
			Util.Log("接收平台返回的2分钟不操作事件 : " + msg);
			Util.CallMethod("Game", "ShowGameGuideWhenNoOperateFor120s", new object[0]);
		}

		private Dictionary<string, string> ParseMsgFromPlatform(string msg)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (msg != null && msg.Length > 0)
			{
				string[] array = msg.Split(new char[]
				{
					'&'
				});
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(new char[]
					{
						'='
					});
					dictionary.Add(array2[0], array2[1]);
				}
			}
			return dictionary;
		}
	}
}
