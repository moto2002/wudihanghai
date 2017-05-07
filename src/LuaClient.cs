using LuaInterface;
using System;
using System.IO;
using UnityEngine;

public class LuaClient : MonoBehaviour
{
	protected LuaState luaState;

	protected LuaLooper loop;

	protected LuaFunction levelLoaded;

	protected bool openLuaSocket;

	protected bool beZbStart;

	public static LuaClient Instance
	{
		get;
		protected set;
	}

	protected virtual LuaFileUtils InitLoader()
	{
		if (LuaFileUtils.Instance != null)
		{
			return LuaFileUtils.Instance;
		}
		return new LuaFileUtils();
	}

	protected virtual void LoadLuaFiles()
	{
		this.OnLoadFinished();
	}

	protected virtual void OpenLibs()
	{
		this.luaState.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_pb));
		this.luaState.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_struct));
		this.luaState.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_lpeg));
		if (LuaConst.openLuaSocket)
		{
			this.OpenLuaSocket();
		}
		if (LuaConst.openZbsDebugger)
		{
			this.OpenZbsDebugger("localhost");
		}
	}

	public void OpenZbsDebugger(string ip = "localhost")
	{
		if (!Directory.Exists(LuaConst.zbsDir))
		{
			Debugger.LogWarning("ZeroBraneStudio not install or LuaConst.zbsDir not right");
			return;
		}
		if (!LuaConst.openLuaSocket)
		{
			this.OpenLuaSocket();
		}
		if (!string.IsNullOrEmpty(LuaConst.zbsDir))
		{
			this.luaState.AddSearchPath(LuaConst.zbsDir);
		}
		this.luaState.LuaDoString(string.Format("DebugServerIp = '{0}'", ip), "LuaStatePtr.cs");
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaOpen_Socket_Core(IntPtr L)
	{
		return LuaDLL.luaopen_socket_core(L);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaOpen_Mime_Core(IntPtr L)
	{
		return LuaDLL.luaopen_mime_core(L);
	}

	protected void OpenLuaSocket()
	{
		LuaConst.openLuaSocket = true;
		this.luaState.BeginPreLoad();
		this.luaState.RegFunction("socket.core", new LuaCSFunction(LuaClient.LuaOpen_Socket_Core));
		this.luaState.RegFunction("mime.core", new LuaCSFunction(LuaClient.LuaOpen_Mime_Core));
		this.luaState.EndPreLoad();
	}

	protected void OpenCJson()
	{
		this.luaState.LuaGetField(LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
		this.luaState.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_cjson));
		this.luaState.LuaSetField(-2, "cjson");
		this.luaState.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_cjson_safe));
		this.luaState.LuaSetField(-2, "cjson.safe");
	}

	protected virtual void CallMain()
	{
		LuaFunction function = this.luaState.GetFunction("Main", true);
		function.Call();
		function.Dispose();
	}

	protected virtual void StartMain()
	{
		this.luaState.DoFile("Main.lua");
		this.levelLoaded = this.luaState.GetFunction("OnLevelWasLoaded", true);
		this.CallMain();
	}

	protected void StartLooper()
	{
		this.loop = base.gameObject.AddComponent<LuaLooper>();
		this.loop.luaState = this.luaState;
	}

	protected virtual void Bind()
	{
		LuaBinder.Bind(this.luaState);
		LuaCoroutine.Register(this.luaState, this);
	}

	protected void Init()
	{
		this.InitLoader();
		this.luaState = new LuaState();
		this.OpenLibs();
		this.luaState.LuaSetTop(0);
		this.Bind();
		this.LoadLuaFiles();
	}

	protected void Awake()
	{
		LuaClient.Instance = this;
		this.Init();
	}

	protected virtual void OnLoadFinished()
	{
		this.luaState.Start();
		this.StartLooper();
		this.StartMain();
	}

	private void OnLevelLoaded(int level)
	{
		if (this.levelLoaded != null)
		{
			this.levelLoaded.BeginPCall();
			this.levelLoaded.Push(level);
			this.levelLoaded.PCall();
			this.levelLoaded.EndPCall();
		}
		if (this.luaState != null)
		{
			this.luaState.RefreshDelegateMap();
		}
	}

	protected void OnLevelWasLoaded(int level)
	{
		this.OnLevelLoaded(level);
	}

	public virtual void Destroy()
	{
		if (this.luaState != null)
		{
			LuaState luaState = this.luaState;
			this.luaState = null;
			if (this.levelLoaded != null)
			{
				this.levelLoaded.Dispose();
				this.levelLoaded = null;
			}
			if (this.loop != null)
			{
				this.loop.Destroy();
				this.loop = null;
			}
			luaState.Dispose();
			LuaClient.Instance = null;
		}
	}

	protected void OnDestroy()
	{
		this.Destroy();
	}

	protected void OnApplicationQuit()
	{
		this.Destroy();
	}

	public static LuaState GetMainState()
	{
		return LuaClient.Instance.luaState;
	}

	public LuaLooper GetLooper()
	{
		return this.loop;
	}
}
