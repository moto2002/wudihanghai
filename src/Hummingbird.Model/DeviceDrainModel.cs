using Hummingbird.SeaBattle.Utility.Platform;
using LuaFramework;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace Hummingbird.Model
{
	public class DeviceDrainModel : MonoBehaviour
	{
		private string sessionId = string.Empty;

		private string accountOpenId = string.Empty;

		private bool isFirstLogin = true;

		private int nRelogin;

		private int nReloginGame;

		private int fromBackstage;

		private List<string> saveErrorLogArray = new List<string>();

		public void GenerateSessionId()
		{
			this.sessionId = PlatformUtil.GetInstance().GetSessionId(true);
		}

		[NoToLua]
		public void RecordSDKInitResult(int status)
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("status", status);
			wWWForm.AddField("eventType", "SdkInit");
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		[NoToLua]
		public void RecordUpgradeInfoResult()
		{
			int num = -1;
			int i = -1;
			string @string = Util.GetString("datarecord_updatetype");
			if (!string.IsNullOrEmpty(@string))
			{
				int @int = Util.GetInt("datarecord_currentversion");
				if (@int == AppConst.GameVerCode)
				{
					if (!@string.Equals("null"))
					{
						num = 0;
						i = 1;
					}
				}
				else if (@string.Equals("null"))
				{
					num = 1;
					i = 2;
				}
				else
				{
					num = 1;
					i = 1;
				}
			}
			if (num != -1)
			{
				WWWForm wWWForm = new WWWForm();
				wWWForm.AddField("status", num);
				wWWForm.AddField("upgradeType", i);
				wWWForm.AddField("eventType", "UpgradeInfo");
				base.StartCoroutine(this.SendRequest(wWWForm, false));
			}
			Util.SetString("datarecord_updatetype", "null");
			Util.SetInt("datarecord_currentversion", AppConst.GameVerCode);
		}

		[NoToLua]
		public void RecordGetGameConfigResult(int status, string msg)
		{
			if (status == 1 && GameConfigInfo.GetInstance().dictExtendConfig.ContainsKey("backupip"))
			{
				string value = Convert.ToString(GameConfigInfo.GetInstance().dictExtendConfig["backupip"]);
				string @string = Util.GetString("backupip");
				if (string.IsNullOrEmpty(@string) || !@string.Equals(value))
				{
					Util.SetString("backupip", value);
				}
			}
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("status", status);
			wWWForm.AddField("msg", msg);
			wWWForm.AddField("eventType", "GetGameConfig");
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		[NoToLua]
		public void RecordReleaseResource()
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("eventType", "ReleaseResource");
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		[NoToLua]
		public void RecordBeforeUpgrade(int upgradeType, string targetVersion)
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("upgradeType", upgradeType);
			wWWForm.AddField("targetVersion", this.GetVersionNumber(targetVersion));
			wWWForm.AddField("eventType", "BeforeUpgrade");
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		[NoToLua]
		public void RecordAfterDownloadUpdate(int status, string msg = "")
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("eventType", "AfterDownload");
			wWWForm.AddField("status", status);
			wWWForm.AddField("msg", msg);
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		[NoToLua]
		public void RecordSmallPackageUpdateStatus(int status, string msg)
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("status", status);
			wWWForm.AddField("msg", msg);
			wWWForm.AddField("eventType", "AfterUpgrade");
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		[NoToLua]
		public void RecordCallSDKLogin()
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("eventType", "BeforeSDKLogin");
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		[NoToLua]
		public void RecordSDKLoginResult(Dictionary<string, string> dictLoginInfo)
		{
			string value = string.Empty;
			if (dictLoginInfo.ContainsKey("openId"))
			{
				value = dictLoginInfo["openId"];
				if (!string.IsNullOrEmpty(this.accountOpenId) && !this.accountOpenId.Equals(value))
				{
					this.nRelogin = 1;
				}
			}
			else if (dictLoginInfo.ContainsKey("sign"))
			{
				value = "token:" + dictLoginInfo["sign"];
				this.nRelogin = 2;
			}
			this.accountOpenId = value;
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("openId", value);
			wWWForm.AddField("relogin", this.nRelogin);
			wWWForm.AddField("eventType", "AfterSDKLogin");
			wWWForm.AddField("status", (!dictLoginInfo["result"].Equals("true")) ? 0 : 1);
			wWWForm.AddField("msg", (!dictLoginInfo.ContainsKey("msg")) ? string.Empty : dictLoginInfo["msg"]);
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		public void RecordGetServerListResult(int status, string msg, int relogin)
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("status", status);
			wWWForm.AddField("msg", msg);
			wWWForm.AddField("relogin", relogin);
			wWWForm.AddField("eventType", "GetServerList");
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		public void RecordLoginCheckResult(int status, string msg, string openId)
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("openId", openId);
			wWWForm.AddField("status", status);
			wWWForm.AddField("msg", msg);
			wWWForm.AddField("reloginGame", this.nReloginGame);
			wWWForm.AddField("eventType", "AfterGameLogin");
			if (this.nReloginGame == 0)
			{
				this.nReloginGame = 1;
			}
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		public void RecordConnectGameServerResult(int status, int serverId, string openId)
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("status", status);
			wWWForm.AddField("openId", openId);
			wWWForm.AddField("serverId", serverId);
			wWWForm.AddField("eventType", "ConnectServer");
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		public void RecordEnterGame(int serverId, int playerId, string openId)
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("openId", openId);
			wWWForm.AddField("serverId", serverId);
			wWWForm.AddField("playerId", playerId);
			wWWForm.AddField("eventType", "EnterGame");
			base.StartCoroutine(this.SendRequest(wWWForm, false));
			this.SetFromBackstage(-1);
		}

		public void RecordLogEvent(string eventInfo)
		{
			string[] array = eventInfo.Split(new char[]
			{
				'&'
			});
			WWWForm wWWForm = new WWWForm();
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'='
				});
				wWWForm.AddField(array2[0], array2[1]);
			}
			base.StartCoroutine(this.SendRequest(wWWForm, false));
		}

		[DebuggerHidden]
		private IEnumerator SendRequest(WWWForm dataForm, bool reSend = false)
		{
			DeviceDrainModel.<SendRequest>c__Iterator13 <SendRequest>c__Iterator = new DeviceDrainModel.<SendRequest>c__Iterator13();
			<SendRequest>c__Iterator.reSend = reSend;
			<SendRequest>c__Iterator.dataForm = dataForm;
			<SendRequest>c__Iterator.<$>reSend = reSend;
			<SendRequest>c__Iterator.<$>dataForm = dataForm;
			<SendRequest>c__Iterator.<>f__this = this;
			return <SendRequest>c__Iterator;
		}

		private int GetVersionNumber(string versionName)
		{
			string[] array = versionName.Split(new char[]
			{
				'.'
			});
			if (array.Length == 3)
			{
				int num = Convert.ToInt32(array[1]);
				int num2 = Convert.ToInt32(array[2]);
				return Convert.ToInt32(string.Format("{0}{1:D2}{2:D2}", array[0], num, num2));
			}
			return 0;
		}

		[NoToLua]
		public void WriteErrorLogToFile(string errorTxt)
		{
			string path = Util.DataPath + "errorlog";
			bool flag = false;
			if (File.Exists(path))
			{
				string text = File.ReadAllText(path);
				if (text.Length > 0)
				{
					flag = true;
					string[] array = text.Split(new string[]
					{
						"|^_^|"
					}, StringSplitOptions.None);
					UnityEngine.Debug.Log("读取到错误日志条目数：  " + array.Length.ToString());
					if (array.Length > 100)
					{
						List<string> list = new List<string>();
						for (int i = 10; i < array.Length; i++)
						{
							list.Add(array[i]);
						}
						File.WriteAllText(path, string.Join("|^_^|", list.ToArray()));
					}
				}
			}
			using (StreamWriter streamWriter = new StreamWriter(path, true))
			{
				if (flag)
				{
					streamWriter.Write("|^_^|");
				}
				streamWriter.Write(errorTxt.Replace("\n", "\\n"));
			}
		}

		[NoToLua]
		public void SendErrorLogRequest()
		{
			string text = Util.DataPath + "errorlog";
			if (File.Exists(text))
			{
				string text2 = File.ReadAllText(text);
				if (!string.IsNullOrEmpty(text2))
				{
					string[] array = text2.Split(new string[]
					{
						"|^_^|"
					}, StringSplitOptions.None);
					this.saveErrorLogArray.Clear();
					if (array.Length > 5)
					{
						List<string> list = new List<string>();
						for (int i = 0; i < array.Length; i++)
						{
							if (i < 5)
							{
								list.Add(array[i]);
							}
							else
							{
								this.saveErrorLogArray.Add(array[i]);
							}
						}
						base.StartCoroutine(this.OnSendErrorLogRequest(text, string.Join("\n", list.ToArray())));
					}
					else
					{
						base.StartCoroutine(this.OnSendErrorLogRequest(text, string.Join("\n", array)));
					}
				}
			}
		}

		[DebuggerHidden]
		private IEnumerator OnSendErrorLogRequest(string errorLogFile, string content)
		{
			DeviceDrainModel.<OnSendErrorLogRequest>c__Iterator14 <OnSendErrorLogRequest>c__Iterator = new DeviceDrainModel.<OnSendErrorLogRequest>c__Iterator14();
			<OnSendErrorLogRequest>c__Iterator.content = content;
			<OnSendErrorLogRequest>c__Iterator.errorLogFile = errorLogFile;
			<OnSendErrorLogRequest>c__Iterator.<$>content = content;
			<OnSendErrorLogRequest>c__Iterator.<$>errorLogFile = errorLogFile;
			<OnSendErrorLogRequest>c__Iterator.<>f__this = this;
			return <OnSendErrorLogRequest>c__Iterator;
		}

		[NoToLua]
		public void SetFromBackstage(int fromBack)
		{
			if (this.fromBackstage < 0)
			{
				return;
			}
			this.fromBackstage = fromBack;
		}
	}
}
