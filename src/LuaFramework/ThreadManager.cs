using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;

namespace LuaFramework
{
	public class ThreadManager : Manager
	{
		private delegate void ThreadSyncEvent(NotiData data);

		private Thread thread;

		private Action<NotiData> func;

		private string currDownFile = string.Empty;

		private static readonly object m_lockObject = new object();

		private static Queue<ThreadEvent> events = new Queue<ThreadEvent>();

		private ThreadManager.ThreadSyncEvent m_SyncEvent;

		private void Awake()
		{
			this.m_SyncEvent = new ThreadManager.ThreadSyncEvent(this.OnSyncEvent);
			this.thread = new Thread(new ThreadStart(this.OnUpdate));
		}

		private void Start()
		{
			this.thread.Start();
		}

		public void AddEvent(ThreadEvent ev, Action<NotiData> func)
		{
			object lockObject = ThreadManager.m_lockObject;
			lock (lockObject)
			{
				this.func = func;
				ThreadManager.events.Enqueue(ev);
			}
		}

		private void OnSyncEvent(NotiData data)
		{
			if (this.func != null)
			{
				this.func(data);
			}
			base.facade.SendMessageCommand(data.evName, data.evParam);
		}

		private void OnUpdate()
		{
			while (true)
			{
				object lockObject = ThreadManager.m_lockObject;
				lock (lockObject)
				{
					if (ThreadManager.events.Count > 0)
					{
						ThreadEvent threadEvent = ThreadManager.events.Dequeue();
						try
						{
							string key = threadEvent.Key;
							if (key != null)
							{
								if (ThreadManager.<>f__switch$map0 == null)
								{
									ThreadManager.<>f__switch$map0 = new Dictionary<string, int>(1)
									{
										{
											"UpdateDownloadBegin",
											0
										}
									};
								}
								int num;
								if (ThreadManager.<>f__switch$map0.TryGetValue(key, out num))
								{
									if (num == 0)
									{
										this.OnDownloadFile(threadEvent.evParams);
									}
								}
							}
						}
						catch (Exception ex)
						{
							Debug.LogError(ex.Message);
						}
					}
				}
				Thread.Sleep(1);
			}
		}

		private void OnDownloadFile(List<object> evParams)
		{
			string uriString = evParams[0].ToString();
			this.currDownFile = evParams[1].ToString();
			using (WebClient webClient = new WebClient())
			{
				webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
				webClient.DownloadFileAsync(new Uri(uriString), this.currDownFile);
			}
		}

		private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			string param = string.Format("{0}|{1}", e.BytesReceived, e.TotalBytesToReceive);
			NotiData progressData = new NotiData("UpdateDownloadProgress", param);
			Loom.QueueOnMainThread(delegate
			{
				this.m_SyncEvent(progressData);
			});
			if (e.ProgressPercentage == 100 && e.BytesReceived == e.TotalBytesToReceive)
			{
				NotiData completeData = new NotiData("UpdateDownloadComplete", this.currDownFile);
				Loom.QueueOnMainThread(delegate
				{
					this.m_SyncEvent(completeData);
				});
			}
		}

		private void OnExtractFile(List<object> evParams)
		{
		}

		private void OnDestroy()
		{
			this.thread.Abort();
		}
	}
}
