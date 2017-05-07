using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnityEngine_UI_HorizontalLayoutGroupWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(HorizontalLayoutGroup), typeof(HorizontalOrVerticalLayoutGroup), null);
		L.RegFunction("CalculateLayoutInputHorizontal", new LuaCSFunction(UnityEngine_UI_HorizontalLayoutGroupWrap.CalculateLayoutInputHorizontal));
		L.RegFunction("CalculateLayoutInputVertical", new LuaCSFunction(UnityEngine_UI_HorizontalLayoutGroupWrap.CalculateLayoutInputVertical));
		L.RegFunction("SetLayoutHorizontal", new LuaCSFunction(UnityEngine_UI_HorizontalLayoutGroupWrap.SetLayoutHorizontal));
		L.RegFunction("SetLayoutVertical", new LuaCSFunction(UnityEngine_UI_HorizontalLayoutGroupWrap.SetLayoutVertical));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_HorizontalLayoutGroupWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateLayoutInputHorizontal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			HorizontalLayoutGroup horizontalLayoutGroup = (HorizontalLayoutGroup)ToLua.CheckObject(L, 1, typeof(HorizontalLayoutGroup));
			horizontalLayoutGroup.CalculateLayoutInputHorizontal();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateLayoutInputVertical(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			HorizontalLayoutGroup horizontalLayoutGroup = (HorizontalLayoutGroup)ToLua.CheckObject(L, 1, typeof(HorizontalLayoutGroup));
			horizontalLayoutGroup.CalculateLayoutInputVertical();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayoutHorizontal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			HorizontalLayoutGroup horizontalLayoutGroup = (HorizontalLayoutGroup)ToLua.CheckObject(L, 1, typeof(HorizontalLayoutGroup));
			horizontalLayoutGroup.SetLayoutHorizontal();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayoutVertical(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			HorizontalLayoutGroup horizontalLayoutGroup = (HorizontalLayoutGroup)ToLua.CheckObject(L, 1, typeof(HorizontalLayoutGroup));
			horizontalLayoutGroup.SetLayoutVertical();
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
