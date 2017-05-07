using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnityEngine_EventSystems_BaseRaycasterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(BaseRaycaster), typeof(UIBehaviour), null);
		L.RegFunction("Raycast", new LuaCSFunction(UnityEngine_EventSystems_BaseRaycasterWrap.Raycast));
		L.RegFunction("ToString", new LuaCSFunction(UnityEngine_EventSystems_BaseRaycasterWrap.ToString));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_EventSystems_BaseRaycasterWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("eventCamera", new LuaCSFunction(UnityEngine_EventSystems_BaseRaycasterWrap.get_eventCamera), null);
		L.RegVar("sortOrderPriority", new LuaCSFunction(UnityEngine_EventSystems_BaseRaycasterWrap.get_sortOrderPriority), null);
		L.RegVar("renderOrderPriority", new LuaCSFunction(UnityEngine_EventSystems_BaseRaycasterWrap.get_renderOrderPriority), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Raycast(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			BaseRaycaster baseRaycaster = (BaseRaycaster)ToLua.CheckObject(L, 1, typeof(BaseRaycaster));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			List<RaycastResult> resultAppendList = (List<RaycastResult>)ToLua.CheckObject(L, 3, typeof(List<RaycastResult>));
			baseRaycaster.Raycast(eventData, resultAppendList);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BaseRaycaster baseRaycaster = (BaseRaycaster)ToLua.CheckObject(L, 1, typeof(BaseRaycaster));
			string str = baseRaycaster.ToString();
			LuaDLL.lua_pushstring(L, str);
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventCamera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BaseRaycaster baseRaycaster = (BaseRaycaster)obj;
			Camera eventCamera = baseRaycaster.eventCamera;
			ToLua.Push(L, eventCamera);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventCamera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortOrderPriority(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BaseRaycaster baseRaycaster = (BaseRaycaster)obj;
			int sortOrderPriority = baseRaycaster.sortOrderPriority;
			LuaDLL.lua_pushinteger(L, sortOrderPriority);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortOrderPriority on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_renderOrderPriority(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BaseRaycaster baseRaycaster = (BaseRaycaster)obj;
			int renderOrderPriority = baseRaycaster.renderOrderPriority;
			LuaDLL.lua_pushinteger(L, renderOrderPriority);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderOrderPriority on a nil value");
		}
		return result;
	}
}
