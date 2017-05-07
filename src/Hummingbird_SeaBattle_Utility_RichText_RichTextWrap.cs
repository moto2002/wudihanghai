using Hummingbird.SeaBattle.Utility.RichText;
using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Hummingbird_SeaBattle_Utility_RichText_RichTextWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(RichText), typeof(Text), null);
		L.RegFunction("SetOnHrefClick", new LuaCSFunction(Hummingbird_SeaBattle_Utility_RichText_RichTextWrap.SetOnHrefClick));
		L.RegFunction("GetStandardString", new LuaCSFunction(Hummingbird_SeaBattle_Utility_RichText_RichTextWrap.GetStandardString));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_SeaBattle_Utility_RichText_RichTextWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetOnHrefClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RichText richText = (RichText)ToLua.CheckObject(L, 1, typeof(RichText));
			LuaFunction onHrefClick = ToLua.CheckLuaFunction(L, 2);
			richText.SetOnHrefClick(onHrefClick);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStandardString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RichText richText = (RichText)ToLua.CheckObject(L, 1, typeof(RichText));
			string str = ToLua.CheckString(L, 2);
			RichText standardString = richText.GetStandardString(str);
			ToLua.Push(L, standardString);
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
