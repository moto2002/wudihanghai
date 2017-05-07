using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnityEngine_UI_ToggleWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Toggle), typeof(Selectable), null);
		L.RegFunction("Rebuild", new LuaCSFunction(UnityEngine_UI_ToggleWrap.Rebuild));
		L.RegFunction("LayoutComplete", new LuaCSFunction(UnityEngine_UI_ToggleWrap.LayoutComplete));
		L.RegFunction("GraphicUpdateComplete", new LuaCSFunction(UnityEngine_UI_ToggleWrap.GraphicUpdateComplete));
		L.RegFunction("OnPointerClick", new LuaCSFunction(UnityEngine_UI_ToggleWrap.OnPointerClick));
		L.RegFunction("OnSubmit", new LuaCSFunction(UnityEngine_UI_ToggleWrap.OnSubmit));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_ToggleWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("toggleTransition", new LuaCSFunction(UnityEngine_UI_ToggleWrap.get_toggleTransition), new LuaCSFunction(UnityEngine_UI_ToggleWrap.set_toggleTransition));
		L.RegVar("graphic", new LuaCSFunction(UnityEngine_UI_ToggleWrap.get_graphic), new LuaCSFunction(UnityEngine_UI_ToggleWrap.set_graphic));
		L.RegVar("onValueChanged", new LuaCSFunction(UnityEngine_UI_ToggleWrap.get_onValueChanged), new LuaCSFunction(UnityEngine_UI_ToggleWrap.set_onValueChanged));
		L.RegVar("group", new LuaCSFunction(UnityEngine_UI_ToggleWrap.get_group), new LuaCSFunction(UnityEngine_UI_ToggleWrap.set_group));
		L.RegVar("isOn", new LuaCSFunction(UnityEngine_UI_ToggleWrap.get_isOn), new LuaCSFunction(UnityEngine_UI_ToggleWrap.set_isOn));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Rebuild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Toggle toggle = (Toggle)ToLua.CheckObject(L, 1, typeof(Toggle));
			CanvasUpdate executing = (CanvasUpdate)((int)ToLua.CheckObject(L, 2, typeof(CanvasUpdate)));
			toggle.Rebuild(executing);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LayoutComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Toggle toggle = (Toggle)ToLua.CheckObject(L, 1, typeof(Toggle));
			toggle.LayoutComplete();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GraphicUpdateComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Toggle toggle = (Toggle)ToLua.CheckObject(L, 1, typeof(Toggle));
			toggle.GraphicUpdateComplete();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPointerClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Toggle toggle = (Toggle)ToLua.CheckObject(L, 1, typeof(Toggle));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			toggle.OnPointerClick(eventData);
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
			Toggle toggle = (Toggle)ToLua.CheckObject(L, 1, typeof(Toggle));
			BaseEventData eventData = (BaseEventData)ToLua.CheckObject(L, 2, typeof(BaseEventData));
			toggle.OnSubmit(eventData);
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
	private static int get_toggleTransition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Toggle toggle = (Toggle)obj;
			Toggle.ToggleTransition toggleTransition = toggle.toggleTransition;
			ToLua.Push(L, toggleTransition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index toggleTransition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Toggle toggle = (Toggle)obj;
			Graphic graphic = toggle.graphic;
			ToLua.Push(L, graphic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index graphic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onValueChanged(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Toggle toggle = (Toggle)obj;
			Toggle.ToggleEvent onValueChanged = toggle.onValueChanged;
			ToLua.PushObject(L, onValueChanged);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onValueChanged on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_group(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Toggle toggle = (Toggle)obj;
			ToggleGroup group = toggle.group;
			ToLua.Push(L, group);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index group on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isOn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Toggle toggle = (Toggle)obj;
			bool isOn = toggle.isOn;
			LuaDLL.lua_pushboolean(L, isOn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isOn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_toggleTransition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Toggle toggle = (Toggle)obj;
			Toggle.ToggleTransition toggleTransition = (Toggle.ToggleTransition)((int)ToLua.CheckObject(L, 2, typeof(Toggle.ToggleTransition)));
			toggle.toggleTransition = toggleTransition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index toggleTransition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_graphic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Toggle toggle = (Toggle)obj;
			Graphic graphic = (Graphic)ToLua.CheckUnityObject(L, 2, typeof(Graphic));
			toggle.graphic = graphic;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index graphic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onValueChanged(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Toggle toggle = (Toggle)obj;
			Toggle.ToggleEvent onValueChanged = (Toggle.ToggleEvent)ToLua.CheckObject(L, 2, typeof(Toggle.ToggleEvent));
			toggle.onValueChanged = onValueChanged;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onValueChanged on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_group(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Toggle toggle = (Toggle)obj;
			ToggleGroup group = (ToggleGroup)ToLua.CheckUnityObject(L, 2, typeof(ToggleGroup));
			toggle.group = group;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index group on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isOn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Toggle toggle = (Toggle)obj;
			bool isOn = LuaDLL.luaL_checkboolean(L, 2);
			toggle.isOn = isOn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isOn on a nil value");
		}
		return result;
	}
}
