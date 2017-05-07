using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnityEngine_UI_GraphicRaycasterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GraphicRaycaster), typeof(BaseRaycaster), null);
		L.RegFunction("Raycast", new LuaCSFunction(UnityEngine_UI_GraphicRaycasterWrap.Raycast));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_GraphicRaycasterWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("sortOrderPriority", new LuaCSFunction(UnityEngine_UI_GraphicRaycasterWrap.get_sortOrderPriority), null);
		L.RegVar("renderOrderPriority", new LuaCSFunction(UnityEngine_UI_GraphicRaycasterWrap.get_renderOrderPriority), null);
		L.RegVar("ignoreReversedGraphics", new LuaCSFunction(UnityEngine_UI_GraphicRaycasterWrap.get_ignoreReversedGraphics), new LuaCSFunction(UnityEngine_UI_GraphicRaycasterWrap.set_ignoreReversedGraphics));
		L.RegVar("blockingObjects", new LuaCSFunction(UnityEngine_UI_GraphicRaycasterWrap.get_blockingObjects), new LuaCSFunction(UnityEngine_UI_GraphicRaycasterWrap.set_blockingObjects));
		L.RegVar("eventCamera", new LuaCSFunction(UnityEngine_UI_GraphicRaycasterWrap.get_eventCamera), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Raycast(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GraphicRaycaster graphicRaycaster = (GraphicRaycaster)ToLua.CheckObject(L, 1, typeof(GraphicRaycaster));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			List<RaycastResult> resultAppendList = (List<RaycastResult>)ToLua.CheckObject(L, 3, typeof(List<RaycastResult>));
			graphicRaycaster.Raycast(eventData, resultAppendList);
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
	private static int get_sortOrderPriority(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphicRaycaster graphicRaycaster = (GraphicRaycaster)obj;
			int sortOrderPriority = graphicRaycaster.sortOrderPriority;
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
			GraphicRaycaster graphicRaycaster = (GraphicRaycaster)obj;
			int renderOrderPriority = graphicRaycaster.renderOrderPriority;
			LuaDLL.lua_pushinteger(L, renderOrderPriority);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderOrderPriority on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ignoreReversedGraphics(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphicRaycaster graphicRaycaster = (GraphicRaycaster)obj;
			bool ignoreReversedGraphics = graphicRaycaster.ignoreReversedGraphics;
			LuaDLL.lua_pushboolean(L, ignoreReversedGraphics);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreReversedGraphics on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blockingObjects(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphicRaycaster graphicRaycaster = (GraphicRaycaster)obj;
			GraphicRaycaster.BlockingObjects blockingObjects = graphicRaycaster.blockingObjects;
			ToLua.Push(L, blockingObjects);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blockingObjects on a nil value");
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
			GraphicRaycaster graphicRaycaster = (GraphicRaycaster)obj;
			Camera eventCamera = graphicRaycaster.eventCamera;
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
	private static int set_ignoreReversedGraphics(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphicRaycaster graphicRaycaster = (GraphicRaycaster)obj;
			bool ignoreReversedGraphics = LuaDLL.luaL_checkboolean(L, 2);
			graphicRaycaster.ignoreReversedGraphics = ignoreReversedGraphics;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreReversedGraphics on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blockingObjects(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphicRaycaster graphicRaycaster = (GraphicRaycaster)obj;
			GraphicRaycaster.BlockingObjects blockingObjects = (GraphicRaycaster.BlockingObjects)((int)ToLua.CheckObject(L, 2, typeof(GraphicRaycaster.BlockingObjects)));
			graphicRaycaster.blockingObjects = blockingObjects;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blockingObjects on a nil value");
		}
		return result;
	}
}
