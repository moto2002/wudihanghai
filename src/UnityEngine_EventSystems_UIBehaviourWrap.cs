using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnityEngine_EventSystems_UIBehaviourWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIBehaviour), typeof(MonoBehaviour), null);
		L.RegFunction("IsActive", new LuaCSFunction(UnityEngine_EventSystems_UIBehaviourWrap.IsActive));
		L.RegFunction("IsDestroyed", new LuaCSFunction(UnityEngine_EventSystems_UIBehaviourWrap.IsDestroyed));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_EventSystems_UIBehaviourWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsActive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIBehaviour uIBehaviour = (UIBehaviour)ToLua.CheckObject(L, 1, typeof(UIBehaviour));
			bool value = uIBehaviour.IsActive();
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
	private static int IsDestroyed(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIBehaviour uIBehaviour = (UIBehaviour)ToLua.CheckObject(L, 1, typeof(UIBehaviour));
			bool value = uIBehaviour.IsDestroyed();
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
