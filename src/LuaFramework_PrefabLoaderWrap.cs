using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_PrefabLoaderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PrefabLoader), typeof(Manager), null);
		L.RegFunction("LoadMainCanvas", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.LoadMainCanvas));
		L.RegFunction("IsPlayAnimation", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.IsPlayAnimation));
		L.RegFunction("SetIsPlayAnimation", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.SetIsPlayAnimation));
		L.RegFunction("CreateUIPrefab", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.CreateUIPrefab));
		L.RegFunction("CreateHeroPrefab", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.CreateHeroPrefab));
		L.RegFunction("CloseUIPrefab", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.CloseUIPrefab));
		L.RegFunction("InitScrollView", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.InitScrollView));
		L.RegFunction("ChangeScrollViewCount", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.ChangeScrollViewCount));
		L.RegFunction("ScrollViewFocusOn", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.ScrollViewFocusOn));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Parent", new LuaCSFunction(LuaFramework_PrefabLoaderWrap.get_Parent), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadMainCanvas(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PrefabLoader prefabLoader = (PrefabLoader)ToLua.CheckObject(L, 1, typeof(PrefabLoader));
			LuaFunction func = ToLua.CheckLuaFunction(L, 2);
			prefabLoader.LoadMainCanvas(func);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsPlayAnimation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)ToLua.CheckObject(L, 1, typeof(PrefabLoader));
			bool value = prefabLoader.IsPlayAnimation();
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetIsPlayAnimation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PrefabLoader prefabLoader = (PrefabLoader)ToLua.CheckObject(L, 1, typeof(PrefabLoader));
			bool isPlayAnimation = LuaDLL.luaL_checkboolean(L, 2);
			prefabLoader.SetIsPlayAnimation(isPlayAnimation);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateUIPrefab(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			PrefabLoader prefabLoader = (PrefabLoader)ToLua.CheckObject(L, 1, typeof(PrefabLoader));
			string name = ToLua.CheckString(L, 2);
			string parentName = ToLua.CheckString(L, 3);
			string nameInScene = ToLua.CheckString(L, 4);
			string layerName = ToLua.CheckString(L, 5);
			LuaFunction func = ToLua.CheckLuaFunction(L, 6);
			prefabLoader.CreateUIPrefab(name, parentName, nameInScene, layerName, func);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateHeroPrefab(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 7);
			PrefabLoader prefabLoader = (PrefabLoader)ToLua.CheckObject(L, 1, typeof(PrefabLoader));
			string name = ToLua.CheckString(L, 2);
			string parentName = ToLua.CheckString(L, 3);
			string nameInScene = ToLua.CheckString(L, 4);
			string layerName = ToLua.CheckString(L, 5);
			bool removeBoxCollider = LuaDLL.luaL_checkboolean(L, 6);
			LuaFunction func = ToLua.CheckLuaFunction(L, 7);
			prefabLoader.CreateHeroPrefab(name, parentName, nameInScene, layerName, removeBoxCollider, func);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CloseUIPrefab(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PrefabLoader prefabLoader = (PrefabLoader)ToLua.CheckObject(L, 1, typeof(PrefabLoader));
			string name = ToLua.CheckString(L, 2);
			prefabLoader.CloseUIPrefab(name);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitScrollView(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			PrefabLoader prefabLoader = (PrefabLoader)ToLua.CheckObject(L, 1, typeof(PrefabLoader));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			int count = (int)LuaDLL.luaL_checknumber(L, 3);
			string cellName = ToLua.CheckString(L, 4);
			int focusIndex = (int)LuaDLL.luaL_checknumber(L, 5);
			prefabLoader.InitScrollView(go, count, cellName, focusIndex);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeScrollViewCount(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			PrefabLoader prefabLoader = (PrefabLoader)ToLua.CheckObject(L, 1, typeof(PrefabLoader));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			int num = (int)LuaDLL.luaL_checknumber(L, 3);
			prefabLoader.ChangeScrollViewCount(go, num);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ScrollViewFocusOn(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			PrefabLoader prefabLoader = (PrefabLoader)ToLua.CheckObject(L, 1, typeof(PrefabLoader));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			int index = (int)LuaDLL.luaL_checknumber(L, 3);
			LuaFunction func = ToLua.CheckLuaFunction(L, 4);
			prefabLoader.ScrollViewFocusOn(go, index, func);
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Parent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			Transform parent = prefabLoader.Parent;
			ToLua.Push(L, parent);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Parent on a nil value");
		}
		return result;
	}
}
