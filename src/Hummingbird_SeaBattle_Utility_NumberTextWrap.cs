using Hummingbird.SeaBattle.Utility;
using LuaInterface;
using System;
using UnityEngine;

public class Hummingbird_SeaBattle_Utility_NumberTextWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(NumberText), typeof(MonoBehaviour), null);
		L.RegFunction("SetText", new LuaCSFunction(Hummingbird_SeaBattle_Utility_NumberTextWrap.SetText));
		L.RegFunction("GetNumberWidth", new LuaCSFunction(Hummingbird_SeaBattle_Utility_NumberTextWrap.GetNumberWidth));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_SeaBattle_Utility_NumberTextWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Color", new LuaCSFunction(Hummingbird_SeaBattle_Utility_NumberTextWrap.get_Color), new LuaCSFunction(Hummingbird_SeaBattle_Utility_NumberTextWrap.set_Color));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetText(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			NumberText numberText = (NumberText)ToLua.CheckObject(L, 1, typeof(NumberText));
			string text = ToLua.CheckString(L, 2);
			string imagePath = ToLua.CheckString(L, 3);
			numberText.SetText(text, imagePath);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNumberWidth(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			NumberText numberText = (NumberText)ToLua.CheckObject(L, 1, typeof(NumberText));
			float numberWidth = numberText.GetNumberWidth();
			LuaDLL.lua_pushnumber(L, (double)numberWidth);
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
	private static int get_Color(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NumberText numberText = (NumberText)obj;
			Color color = numberText.Color;
			ToLua.Push(L, color);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Color on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Color(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NumberText numberText = (NumberText)obj;
			Color color = ToLua.ToColor(L, 2);
			numberText.Color = color;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Color on a nil value");
		}
		return result;
	}
}
