using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_ResourceManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ResourceManager), typeof(Manager), null);
		L.RegFunction("LoadScene", new LuaCSFunction(LuaFramework_ResourceManagerWrap.LoadScene));
		L.RegFunction("LoadSprites", new LuaCSFunction(LuaFramework_ResourceManagerWrap.LoadSprites));
		L.RegFunction("UnloadAssetBundle", new LuaCSFunction(LuaFramework_ResourceManagerWrap.UnloadAssetBundle));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_ResourceManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadScene(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			ResourceManager resourceManager = (ResourceManager)ToLua.CheckObject(L, 1, typeof(ResourceManager));
			string name = ToLua.CheckString(L, 2);
			LuaFunction progressCallback = ToLua.CheckLuaFunction(L, 3);
			LuaFunction completeCallback = ToLua.CheckLuaFunction(L, 4);
			resourceManager.LoadScene(name, progressCallback, completeCallback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadSprites(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			ResourceManager resourceManager = (ResourceManager)ToLua.CheckObject(L, 1, typeof(ResourceManager));
			string path = ToLua.CheckString(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action<UnityEngine.Object[]> action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (Action<UnityEngine.Object[]>)ToLua.CheckObject(L, 3, typeof(Action<UnityEngine.Object[]>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				action = (DelegateFactory.CreateDelegate(typeof(Action<UnityEngine.Object[]>), func) as Action<UnityEngine.Object[]>);
			}
			LuaFunction func2 = ToLua.CheckLuaFunction(L, 4);
			resourceManager.LoadSprites(path, action, func2);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnloadAssetBundle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			ResourceManager resourceManager = (ResourceManager)ToLua.CheckObject(L, 1, typeof(ResourceManager));
			string abName = ToLua.CheckString(L, 2);
			bool abUnload = LuaDLL.luaL_checkboolean(L, 3);
			bool ignoreReferencedCount = LuaDLL.luaL_checkboolean(L, 4);
			resourceManager.UnloadAssetBundle(abName, abUnload, ignoreReferencedCount);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int op_Equality(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object x = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object y = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool value = x == y;
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
