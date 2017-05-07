using Hummingbird.Model;
using LuaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
	private AppFacade m_Facade;

	private LuaManager m_LuaMgr;

	private ResourceManager m_ResMgr;

	private NetworkManager m_NetMgr;

	private SoundManager m_SoundMgr;

	private ThreadManager m_ThreadMgr;

	private DeviceDrainModel m_DeviceModel;

	protected AppFacade facade
	{
		get
		{
			if (this.m_Facade == null)
			{
				this.m_Facade = AppFacade.Instance;
			}
			return this.m_Facade;
		}
	}

	protected LuaManager LuaManager
	{
		get
		{
			if (this.m_LuaMgr == null)
			{
				this.m_LuaMgr = this.facade.GetManager<LuaManager>("LuaManager");
			}
			return this.m_LuaMgr;
		}
	}

	protected ResourceManager ResManager
	{
		get
		{
			if (this.m_ResMgr == null)
			{
				this.m_ResMgr = this.facade.GetManager<ResourceManager>("ResourceManager");
			}
			return this.m_ResMgr;
		}
	}

	protected NetworkManager NetManager
	{
		get
		{
			if (this.m_NetMgr == null)
			{
				this.m_NetMgr = this.facade.GetManager<NetworkManager>("NetworkManager");
			}
			return this.m_NetMgr;
		}
	}

	protected SoundManager SoundManager
	{
		get
		{
			if (this.m_SoundMgr == null)
			{
				this.m_SoundMgr = this.facade.GetManager<SoundManager>("SoundManager");
			}
			return this.m_SoundMgr;
		}
	}

	protected ThreadManager ThreadManager
	{
		get
		{
			if (this.m_ThreadMgr == null)
			{
				this.m_ThreadMgr = this.facade.GetManager<ThreadManager>("ThreadManager");
			}
			return this.m_ThreadMgr;
		}
	}

	protected DeviceDrainModel DeviceDrainModel
	{
		get
		{
			if (this.m_DeviceModel == null)
			{
				this.m_DeviceModel = this.facade.GetManager<DeviceDrainModel>("DeviceDrainModel");
			}
			return this.m_DeviceModel;
		}
	}

	protected void RegisterMessage(IView view, List<string> messages)
	{
		if (messages == null || messages.Count == 0)
		{
			return;
		}
		Controller.Instance.RegisterViewCommand(view, messages.ToArray());
	}

	protected void RemoveMessage(IView view, List<string> messages)
	{
		if (messages == null || messages.Count == 0)
		{
			return;
		}
		Controller.Instance.RemoveViewCommand(view, messages.ToArray());
	}
}
