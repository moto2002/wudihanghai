using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnityEngine_UI_SliderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Slider), typeof(Selectable), null);
		L.RegFunction("Rebuild", new LuaCSFunction(UnityEngine_UI_SliderWrap.Rebuild));
		L.RegFunction("LayoutComplete", new LuaCSFunction(UnityEngine_UI_SliderWrap.LayoutComplete));
		L.RegFunction("GraphicUpdateComplete", new LuaCSFunction(UnityEngine_UI_SliderWrap.GraphicUpdateComplete));
		L.RegFunction("OnPointerDown", new LuaCSFunction(UnityEngine_UI_SliderWrap.OnPointerDown));
		L.RegFunction("OnDrag", new LuaCSFunction(UnityEngine_UI_SliderWrap.OnDrag));
		L.RegFunction("OnMove", new LuaCSFunction(UnityEngine_UI_SliderWrap.OnMove));
		L.RegFunction("FindSelectableOnLeft", new LuaCSFunction(UnityEngine_UI_SliderWrap.FindSelectableOnLeft));
		L.RegFunction("FindSelectableOnRight", new LuaCSFunction(UnityEngine_UI_SliderWrap.FindSelectableOnRight));
		L.RegFunction("FindSelectableOnUp", new LuaCSFunction(UnityEngine_UI_SliderWrap.FindSelectableOnUp));
		L.RegFunction("FindSelectableOnDown", new LuaCSFunction(UnityEngine_UI_SliderWrap.FindSelectableOnDown));
		L.RegFunction("OnInitializePotentialDrag", new LuaCSFunction(UnityEngine_UI_SliderWrap.OnInitializePotentialDrag));
		L.RegFunction("SetDirection", new LuaCSFunction(UnityEngine_UI_SliderWrap.SetDirection));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_SliderWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("fillRect", new LuaCSFunction(UnityEngine_UI_SliderWrap.get_fillRect), new LuaCSFunction(UnityEngine_UI_SliderWrap.set_fillRect));
		L.RegVar("handleRect", new LuaCSFunction(UnityEngine_UI_SliderWrap.get_handleRect), new LuaCSFunction(UnityEngine_UI_SliderWrap.set_handleRect));
		L.RegVar("direction", new LuaCSFunction(UnityEngine_UI_SliderWrap.get_direction), new LuaCSFunction(UnityEngine_UI_SliderWrap.set_direction));
		L.RegVar("minValue", new LuaCSFunction(UnityEngine_UI_SliderWrap.get_minValue), new LuaCSFunction(UnityEngine_UI_SliderWrap.set_minValue));
		L.RegVar("maxValue", new LuaCSFunction(UnityEngine_UI_SliderWrap.get_maxValue), new LuaCSFunction(UnityEngine_UI_SliderWrap.set_maxValue));
		L.RegVar("wholeNumbers", new LuaCSFunction(UnityEngine_UI_SliderWrap.get_wholeNumbers), new LuaCSFunction(UnityEngine_UI_SliderWrap.set_wholeNumbers));
		L.RegVar("value", new LuaCSFunction(UnityEngine_UI_SliderWrap.get_value), new LuaCSFunction(UnityEngine_UI_SliderWrap.set_value));
		L.RegVar("normalizedValue", new LuaCSFunction(UnityEngine_UI_SliderWrap.get_normalizedValue), new LuaCSFunction(UnityEngine_UI_SliderWrap.set_normalizedValue));
		L.RegVar("onValueChanged", new LuaCSFunction(UnityEngine_UI_SliderWrap.get_onValueChanged), new LuaCSFunction(UnityEngine_UI_SliderWrap.set_onValueChanged));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Rebuild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			CanvasUpdate executing = (CanvasUpdate)((int)ToLua.CheckObject(L, 2, typeof(CanvasUpdate)));
			slider.Rebuild(executing);
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
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			slider.LayoutComplete();
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
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			slider.GraphicUpdateComplete();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPointerDown(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			slider.OnPointerDown(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDrag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			slider.OnDrag(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnMove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			AxisEventData eventData = (AxisEventData)ToLua.CheckObject(L, 2, typeof(AxisEventData));
			slider.OnMove(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindSelectableOnLeft(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			Selectable obj = slider.FindSelectableOnLeft();
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindSelectableOnRight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			Selectable obj = slider.FindSelectableOnRight();
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindSelectableOnUp(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			Selectable obj = slider.FindSelectableOnUp();
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindSelectableOnDown(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			Selectable obj = slider.FindSelectableOnDown();
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnInitializePotentialDrag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			slider.OnInitializePotentialDrag(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDirection(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Slider slider = (Slider)ToLua.CheckObject(L, 1, typeof(Slider));
			Slider.Direction direction = (Slider.Direction)((int)ToLua.CheckObject(L, 2, typeof(Slider.Direction)));
			bool includeRectLayouts = LuaDLL.luaL_checkboolean(L, 3);
			slider.SetDirection(direction, includeRectLayouts);
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
	private static int get_fillRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			RectTransform fillRect = slider.fillRect;
			ToLua.Push(L, fillRect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillRect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_handleRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			RectTransform handleRect = slider.handleRect;
			ToLua.Push(L, handleRect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index handleRect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_direction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			Slider.Direction direction = slider.direction;
			ToLua.Push(L, direction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index direction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			float minValue = slider.minValue;
			LuaDLL.lua_pushnumber(L, (double)minValue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			float maxValue = slider.maxValue;
			LuaDLL.lua_pushnumber(L, (double)maxValue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_wholeNumbers(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			bool wholeNumbers = slider.wholeNumbers;
			LuaDLL.lua_pushboolean(L, wholeNumbers);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wholeNumbers on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			float value = slider.value;
			LuaDLL.lua_pushnumber(L, (double)value);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_normalizedValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			float normalizedValue = slider.normalizedValue;
			LuaDLL.lua_pushnumber(L, (double)normalizedValue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index normalizedValue on a nil value");
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
			Slider slider = (Slider)obj;
			Slider.SliderEvent onValueChanged = slider.onValueChanged;
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
	private static int set_fillRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			RectTransform fillRect = (RectTransform)ToLua.CheckUnityObject(L, 2, typeof(RectTransform));
			slider.fillRect = fillRect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillRect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_handleRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			RectTransform handleRect = (RectTransform)ToLua.CheckUnityObject(L, 2, typeof(RectTransform));
			slider.handleRect = handleRect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index handleRect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_direction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			Slider.Direction direction = (Slider.Direction)((int)ToLua.CheckObject(L, 2, typeof(Slider.Direction)));
			slider.direction = direction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index direction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_minValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			float minValue = (float)LuaDLL.luaL_checknumber(L, 2);
			slider.minValue = minValue;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			float maxValue = (float)LuaDLL.luaL_checknumber(L, 2);
			slider.maxValue = maxValue;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_wholeNumbers(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			bool wholeNumbers = LuaDLL.luaL_checkboolean(L, 2);
			slider.wholeNumbers = wholeNumbers;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wholeNumbers on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			float value = (float)LuaDLL.luaL_checknumber(L, 2);
			slider.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_normalizedValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Slider slider = (Slider)obj;
			float normalizedValue = (float)LuaDLL.luaL_checknumber(L, 2);
			slider.normalizedValue = normalizedValue;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index normalizedValue on a nil value");
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
			Slider slider = (Slider)obj;
			Slider.SliderEvent onValueChanged = (Slider.SliderEvent)ToLua.CheckObject(L, 2, typeof(Slider.SliderEvent));
			slider.onValueChanged = onValueChanged;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onValueChanged on a nil value");
		}
		return result;
	}
}
