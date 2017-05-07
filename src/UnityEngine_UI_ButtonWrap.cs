using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnityEngine_UI_ButtonWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Button), typeof(Selectable), null);
		L.RegFunction("OnPointerClick", new LuaCSFunction(UnityEngine_UI_ButtonWrap.OnPointerClick));
		L.RegFunction("OnSubmit", new LuaCSFunction(UnityEngine_UI_ButtonWrap.OnSubmit));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_ButtonWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("onClick", new LuaCSFunction(UnityEngine_UI_ButtonWrap.get_onClick), new LuaCSFunction(UnityEngine_UI_ButtonWrap.set_onClick));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPointerClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Button button = (Button)ToLua.CheckObject(L, 1, typeof(Button));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			button.OnPointerClick(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnSubmit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Button button = (Button)ToLua.CheckObject(L, 1, typeof(Button));
			BaseEventData eventData = (BaseEventData)ToLua.CheckObject(L, 2, typeof(BaseEventData));
			button.OnSubmit(eventData);
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
	private static int get_onClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Button button = (Button)obj;
			Button.ButtonClickedEvent onClick = button.onClick;
			ToLua.PushObject(L, onClick);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Button button = (Button)obj;
			Button.ButtonClickedEvent onClick = (Button.ButtonClickedEvent)ToLua.CheckObject(L, 2, typeof(Button.ButtonClickedEvent));
			button.onClick = onClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClick on a nil value");
		}
		return result;
	}
}
