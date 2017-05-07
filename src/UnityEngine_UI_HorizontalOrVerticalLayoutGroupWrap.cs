using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnityEngine_UI_HorizontalOrVerticalLayoutGroupWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(HorizontalOrVerticalLayoutGroup), typeof(LayoutGroup), null);
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_HorizontalOrVerticalLayoutGroupWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("spacing", new LuaCSFunction(UnityEngine_UI_HorizontalOrVerticalLayoutGroupWrap.get_spacing), new LuaCSFunction(UnityEngine_UI_HorizontalOrVerticalLayoutGroupWrap.set_spacing));
		L.RegVar("childForceExpandWidth", new LuaCSFunction(UnityEngine_UI_HorizontalOrVerticalLayoutGroupWrap.get_childForceExpandWidth), new LuaCSFunction(UnityEngine_UI_HorizontalOrVerticalLayoutGroupWrap.set_childForceExpandWidth));
		L.RegVar("childForceExpandHeight", new LuaCSFunction(UnityEngine_UI_HorizontalOrVerticalLayoutGroupWrap.get_childForceExpandHeight), new LuaCSFunction(UnityEngine_UI_HorizontalOrVerticalLayoutGroupWrap.set_childForceExpandHeight));
		L.EndClass();
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
	private static int get_spacing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HorizontalOrVerticalLayoutGroup horizontalOrVerticalLayoutGroup = (HorizontalOrVerticalLayoutGroup)obj;
			float spacing = horizontalOrVerticalLayoutGroup.spacing;
			LuaDLL.lua_pushnumber(L, (double)spacing);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spacing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_childForceExpandWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HorizontalOrVerticalLayoutGroup horizontalOrVerticalLayoutGroup = (HorizontalOrVerticalLayoutGroup)obj;
			bool childForceExpandWidth = horizontalOrVerticalLayoutGroup.childForceExpandWidth;
			LuaDLL.lua_pushboolean(L, childForceExpandWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index childForceExpandWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_childForceExpandHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HorizontalOrVerticalLayoutGroup horizontalOrVerticalLayoutGroup = (HorizontalOrVerticalLayoutGroup)obj;
			bool childForceExpandHeight = horizontalOrVerticalLayoutGroup.childForceExpandHeight;
			LuaDLL.lua_pushboolean(L, childForceExpandHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index childForceExpandHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spacing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HorizontalOrVerticalLayoutGroup horizontalOrVerticalLayoutGroup = (HorizontalOrVerticalLayoutGroup)obj;
			float spacing = (float)LuaDLL.luaL_checknumber(L, 2);
			horizontalOrVerticalLayoutGroup.spacing = spacing;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spacing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_childForceExpandWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HorizontalOrVerticalLayoutGroup horizontalOrVerticalLayoutGroup = (HorizontalOrVerticalLayoutGroup)obj;
			bool childForceExpandWidth = LuaDLL.luaL_checkboolean(L, 2);
			horizontalOrVerticalLayoutGroup.childForceExpandWidth = childForceExpandWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index childForceExpandWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_childForceExpandHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HorizontalOrVerticalLayoutGroup horizontalOrVerticalLayoutGroup = (HorizontalOrVerticalLayoutGroup)obj;
			bool childForceExpandHeight = LuaDLL.luaL_checkboolean(L, 2);
			horizontalOrVerticalLayoutGroup.childForceExpandHeight = childForceExpandHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index childForceExpandHeight on a nil value");
		}
		return result;
	}
}
