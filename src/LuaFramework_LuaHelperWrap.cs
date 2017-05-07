using Hummingbird.Model;
using LuaFramework;
using LuaInterface;
using System;

public class LuaFramework_LuaHelperWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("LuaHelper");
		L.RegFunction("GetType", new LuaCSFunction(LuaFramework_LuaHelperWrap.GetType));
		L.RegFunction("GetPrefabLoader", new LuaCSFunction(LuaFramework_LuaHelperWrap.GetPrefabLoader));
		L.RegFunction("GetResManager", new LuaCSFunction(LuaFramework_LuaHelperWrap.GetResManager));
		L.RegFunction("GetNetManager", new LuaCSFunction(LuaFramework_LuaHelperWrap.GetNetManager));
		L.RegFunction("GetSoundManager", new LuaCSFunction(LuaFramework_LuaHelperWrap.GetSoundManager));
		L.RegFunction("GetDeviceDrainModel", new LuaCSFunction(LuaFramework_LuaHelperWrap.GetDeviceDrainModel));
		L.RegFunction("OnCallLuaFunc", new LuaCSFunction(LuaFramework_LuaHelperWrap.OnCallLuaFunc));
		L.RegFunction("OnJsonCallFunc", new LuaCSFunction(LuaFramework_LuaHelperWrap.OnJsonCallFunc));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string classname = ToLua.CheckString(L, 1);
			Type type = LuaHelper.GetType(classname);
			ToLua.Push(L, type);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPrefabLoader(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			PrefabLoader prefabLoader = LuaHelper.GetPrefabLoader();
			ToLua.Push(L, prefabLoader);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetResManager(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			ResourceManager resManager = LuaHelper.GetResManager();
			ToLua.Push(L, resManager);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNetManager(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			NetworkManager netManager = LuaHelper.GetNetManager();
			ToLua.Push(L, netManager);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSoundManager(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			SoundManager soundManager = LuaHelper.GetSoundManager();
			ToLua.Push(L, soundManager);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDeviceDrainModel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			DeviceDrainModel deviceDrainModel = LuaHelper.GetDeviceDrainModel();
			ToLua.Push(L, deviceDrainModel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnCallLuaFunc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaByteBuffer data = new LuaByteBuffer(ToLua.CheckByteBuffer(L, 1));
			LuaFunction func = ToLua.CheckLuaFunction(L, 2);
			LuaHelper.OnCallLuaFunc(data, func);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnJsonCallFunc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string data = ToLua.CheckString(L, 1);
			LuaFunction func = ToLua.CheckLuaFunction(L, 2);
			LuaHelper.OnJsonCallFunc(data, func);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
