using Hummingbird.Model;
using Hummingbird.SeaBattle.Utility.Platform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace LuaFramework
{
	public class GameManager : Manager
	{
		private Coroutine currentCoroutine;

		private long appExitTime;

		private int appVersionCode;

		private void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			Screen.sleepTimeout = -1;
			Application.targetFrameRate = 30;
			base.gameObject.AddComponent<Loom>();
			base.gameObject.AddComponent<PlatformMessageHandler>();
			Caching.maximumAvailableDiskSpace = 167772160L;
			Caching.expirationDelay = 2592000;
			this.currentCoroutine = base.StartCoroutine(this.OnStartApp());
		}

		[DebuggerHidden]
		private IEnumerator OnStartApp()
		{
			GameManager.<OnStartApp>c__Iterator6 <OnStartApp>c__Iterator = new GameManager.<OnStartApp>c__Iterator6();
			<OnStartApp>c__Iterator.<>f__this = this;
			return <OnStartApp>c__Iterator;
		}

		[DebuggerHidden]
		private IEnumerator OnGetGameConfigJson()
		{
			GameManager.<OnGetGameConfigJson>c__Iterator7 <OnGetGameConfigJson>c__Iterator = new GameManager.<OnGetGameConfigJson>c__Iterator7();
			<OnGetGameConfigJson>c__Iterator.<>f__this = this;
			return <OnGetGameConfigJson>c__Iterator;
		}

		[DebuggerHidden]
		private IEnumerator OnSendAppActiveData()
		{
			return new GameManager.<OnSendAppActiveData>c__Iterator8();
		}

		private bool CheckExtractResource()
		{
			string text = Util.DataPath + "appversioncode";
			this.appVersionCode = PlatformUtil.GetInstance().GetAppVersionCode();
			if (File.Exists(text))
			{
				string value = string.Empty;
				try
				{
					value = File.ReadAllText(text);
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.Log(string.Format(Util.GetDesConfig("readVersionFileError"), text, ex.Message));
					File.Delete(text);
					return true;
				}
				return Convert.ToInt32(value) != this.appVersionCode;
			}
			return true;
		}

		[DebuggerHidden]
		private IEnumerator OnExtractPbFileAndVersionFile()
		{
			GameManager.<OnExtractPbFileAndVersionFile>c__Iterator9 <OnExtractPbFileAndVersionFile>c__Iterator = new GameManager.<OnExtractPbFileAndVersionFile>c__Iterator9();
			<OnExtractPbFileAndVersionFile>c__Iterator.<>f__this = this;
			return <OnExtractPbFileAndVersionFile>c__Iterator;
		}

		[DebuggerHidden]
		private IEnumerator OnHandleUpdateLogic()
		{
			GameManager.<OnHandleUpdateLogic>c__IteratorA <OnHandleUpdateLogic>c__IteratorA = new GameManager.<OnHandleUpdateLogic>c__IteratorA();
			<OnHandleUpdateLogic>c__IteratorA.<>f__this = this;
			return <OnHandleUpdateLogic>c__IteratorA;
		}

		[DebuggerHidden]
		private IEnumerator UpdateFullPackage()
		{
			GameManager.<UpdateFullPackage>c__IteratorB <UpdateFullPackage>c__IteratorB = new GameManager.<UpdateFullPackage>c__IteratorB();
			<UpdateFullPackage>c__IteratorB.<>f__this = this;
			return <UpdateFullPackage>c__IteratorB;
		}

		[DebuggerHidden]
		private IEnumerator UpdateSmallPackage()
		{
			GameManager.<UpdateSmallPackage>c__IteratorC <UpdateSmallPackage>c__IteratorC = new GameManager.<UpdateSmallPackage>c__IteratorC();
			<UpdateSmallPackage>c__IteratorC.<>f__this = this;
			return <UpdateSmallPackage>c__IteratorC;
		}

		[DebuggerHidden]
		private IEnumerator GetUpdateZipFileUrl(List<string> needUpdateResList)
		{
			GameManager.<GetUpdateZipFileUrl>c__IteratorD <GetUpdateZipFileUrl>c__IteratorD = new GameManager.<GetUpdateZipFileUrl>c__IteratorD();
			<GetUpdateZipFileUrl>c__IteratorD.needUpdateResList = needUpdateResList;
			<GetUpdateZipFileUrl>c__IteratorD.<$>needUpdateResList = needUpdateResList;
			<GetUpdateZipFileUrl>c__IteratorD.<>f__this = this;
			return <GetUpdateZipFileUrl>c__IteratorD;
		}

		private List<string> GetNeedUpdateResList(string[] files)
		{
			List<string> list = new List<string>();
			string[] array = File.ReadAllLines(Util.DataPath + "sbf");
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]))
				{
					string[] array2 = array[i].Trim().Split(new char[]
					{
						'|'
					});
					if (!dictionary.ContainsKey(array2[0]))
					{
						dictionary.Add(array2[0], array2[1]);
					}
				}
			}
			for (int j = 0; j < files.Length; j++)
			{
				if (!string.IsNullOrEmpty(files[j]))
				{
					string[] array3 = files[j].Trim().Split(new char[]
					{
						'|'
					});
					if (dictionary.ContainsKey(array3[0]))
					{
						if (!dictionary[array3[0]].Equals(array3[1]))
						{
							list.Add(array3[0]);
						}
					}
					else
					{
						list.Add(array3[0]);
					}
				}
			}
			return list;
		}

		private void BeginDownload(string url, string file)
		{
			if (File.Exists(file))
			{
				File.Delete(file);
			}
			AppFacade.Instance.AddManager<ThreadManager>("ThreadManager");
			object[] collection = new object[]
			{
				url,
				file
			};
			ThreadEvent threadEvent = new ThreadEvent();
			threadEvent.Key = "UpdateDownloadBegin";
			threadEvent.evParams.AddRange(collection);
			base.ThreadManager.AddEvent(threadEvent, new Action<NotiData>(this.OnThreadDownloadCompleted));
		}

		private void OnThreadDownloadCompleted(NotiData data)
		{
			if (data.evName.Equals("UpdateDownloadComplete"))
			{
				base.facade.SendMessageCommand("UpdateTipsContent", Util.GetDesConfig("upzipNewResIng"));
				base.DeviceDrainModel.RecordAfterDownloadUpdate(1, string.Empty);
				Util.Log("更新包下载完成， 开始解压...");
				PlatformUtil.GetInstance().ExtractFile(Util.DataPath + "sb_pkg_temp.zip", Util.DataPath, delegate(string result)
				{
					if (result.Equals("0"))
					{
						this.ExtractZipCompleted();
					}
					else
					{
						UnityEngine.Debug.LogError(result);
						base.DeviceDrainModel.RecordSmallPackageUpdateStatus(0, result);
					}
				});
			}
		}

		private void ExtractZipCompleted()
		{
			string text = Util.DataPath + "sbf_temp";
			string text2 = Util.DataPath + "sbf";
			if (File.Exists(text) && File.Exists(text2))
			{
				File.Delete(text2);
				FileInfo fileInfo = new FileInfo(text);
				fileInfo.MoveTo(text2);
			}
			string path = Util.DataPath + "sb_pkg_temp.zip";
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			string text3 = Util.DataPath + "sbv";
			Util.SetString("dhh_version", string.Format("{0}|{1}", GameConfigInfo.GetInstance().verCode, GameConfigInfo.GetInstance().verName));
			Util.ReadGameVersionInfo();
			Util.SetInt("datarecord_currentversion", AppConst.GameVerCode);
			base.DeviceDrainModel.RecordSmallPackageUpdateStatus(1, string.Empty);
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				Caching.CleanCache();
			}
			this.EnterGame(true);
		}

		private void EnterGame(bool needUpdateVersionInfo = false)
		{
			AppFacade.Instance.RemoveManager("ThreadManager");
			UnityEngine.Object.Destroy(base.gameObject.GetComponent<Loom>());
			base.facade.SendMessageCommand("UpdateCompleteEnterGame", needUpdateVersionInfo);
			base.facade.SendMessageCommand("UpdateTipsContent", Util.GetDesConfig("initResIng"));
			base.ResManager.Initialize("bundles", delegate
			{
				base.facade.SendMessageCommand("UpdateTipsContent", Util.GetDesConfig("initScriptsIng"));
				base.LuaManager.InitStart(delegate
				{
					base.facade.SendMessageCommand("UpdateTipsContent", Util.GetDesConfig("landReading"));
				});
			});
			base.InvokeRepeating("SendErrorLogInfo", 10f, 60f);
		}

		private void SendErrorLogInfo()
		{
			base.DeviceDrainModel.SendErrorLogRequest();
		}

		private void ShowTips(string title, string text, Action callback)
		{
			PlatformUtil.GetInstance().ShowDeviceTips(title, text, delegate(bool result)
			{
				if (result)
				{
					callback();
				}
				else
				{
					Application.Quit();
				}
			});
		}

		private void OnDestroy()
		{
			if (base.NetManager != null)
			{
				base.NetManager.Unload();
			}
			if (base.LuaManager != null)
			{
				base.LuaManager.Close();
			}
			UnityEngine.Debug.Log("~GameManager was destroyed");
		}

		private void OnApplicationPause(bool isPause)
		{
			if (!base.LuaManager.IsInitLuaOk())
			{
				return;
			}
			if (isPause)
			{
				this.appExitTime = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
				Util.ClearMemory();
			}
			else
			{
				long num = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds) - this.appExitTime;
				Util.CallMethod("TimeManager", "BrocastTimerWhenApplicationActive", new object[]
				{
					num
				});
				base.DeviceDrainModel.SetFromBackstage(1);
			}
		}
	}
}
