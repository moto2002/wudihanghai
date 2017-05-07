using LuaInterface;
using System;
using UnityEngine;

namespace LuaFramework
{
	public class LuaManager : Manager
	{
		private LuaState lua;

		private LuaLoader loader;

		private LuaLooper loop;

		private bool isInitLuaOk;

		private void Awake()
		{
			this.loader = new LuaLoader();
			this.lua = new LuaState();
			this.OpenLibs();
			this.lua.LuaSetTop(0);
			LuaBinder.Bind(this.lua);
			LuaCoroutine.Register(this.lua, this);
		}

		public void InitStart(Action initOK)
		{
			this.InitLuaBundle(delegate
			{
				this.lua.Start();
				this.StartMain();
				this.StartLooper();
				if (initOK != null)
				{
					initOK();
				}
			});
		}

		private void StartLooper()
		{
			this.loop = base.gameObject.AddComponent<LuaLooper>();
			this.loop.luaState = this.lua;
		}

		public bool IsInitLuaOk()
		{
			return this.isInitLuaOk;
		}

		protected void OpenCJson()
		{
			this.lua.LuaGetField(LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_cjson));
			this.lua.LuaSetField(-2, "cjson");
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_cjson_safe));
			this.lua.LuaSetField(-2, "cjson.safe");
		}

		private void StartMain()
		{
			this.lua.DoFile("Main.lua");
			LuaFunction function = this.lua.GetFunction("Main", true);
			function.Call();
			function.Dispose();
			this.isInitLuaOk = true;
		}

		private void OpenLibs()
		{
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_protobuf_c));
			this.OpenCJson();
		}

		private void InitLuaPath()
		{
			this.lua.AddSearchPath(Application.dataPath + "/Lua");
			this.lua.AddSearchPath(Application.dataPath + "/ToLua/Lua");
		}

		private void InitLuaBundle(Action callback)
		{
			base.ResManager.LoadLuaBundle(delegate(AssetBundle bundle)
			{
				if (bundle != null)
				{
					LuaFileUtils.Instance.AddSearchBundle(bundle);
					if (callback != null)
					{
						callback();
					}
				}
			});
		}

		public object[] DoFile(string filename)
		{
			return this.lua.DoFile(filename);
		}

		public object[] CallFunction(string funcName, params object[] args)
		{
			LuaFunction function = this.lua.GetFunction(funcName, true);
			if (function != null)
			{
				return function.Call(args);
			}
			return null;
		}

		public void LuaGC()
		{
			this.lua.LuaGC(LuaGCOptions.LUA_GCCOLLECT, 0);
		}

		public void Close()
		{
			if (this.loop != null)
			{
				this.loop.Destroy();
				this.loop = null;
			}
			this.lua.Dispose();
			this.lua = null;
			this.loader = null;
		}
	}
}
