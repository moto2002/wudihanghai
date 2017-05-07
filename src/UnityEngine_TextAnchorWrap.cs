using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_TextAnchorWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(TextAnchor));
		L.RegVar("UpperLeft", new LuaCSFunction(UnityEngine_TextAnchorWrap.get_UpperLeft), null);
		L.RegVar("UpperCenter", new LuaCSFunction(UnityEngine_TextAnchorWrap.get_UpperCenter), null);
		L.RegVar("UpperRight", new LuaCSFunction(UnityEngine_TextAnchorWrap.get_UpperRight), null);
		L.RegVar("MiddleLeft", new LuaCSFunction(UnityEngine_TextAnchorWrap.get_MiddleLeft), null);
		L.RegVar("MiddleCenter", new LuaCSFunction(UnityEngine_TextAnchorWrap.get_MiddleCenter), null);
		L.RegVar("MiddleRight", new LuaCSFunction(UnityEngine_TextAnchorWrap.get_MiddleRight), null);
		L.RegVar("LowerLeft", new LuaCSFunction(UnityEngine_TextAnchorWrap.get_LowerLeft), null);
		L.RegVar("LowerCenter", new LuaCSFunction(UnityEngine_TextAnchorWrap.get_LowerCenter), null);
		L.RegVar("LowerRight", new LuaCSFunction(UnityEngine_TextAnchorWrap.get_LowerRight), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(UnityEngine_TextAnchorWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UpperLeft(IntPtr L)
	{
		ToLua.Push(L, TextAnchor.UpperLeft);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UpperCenter(IntPtr L)
	{
		ToLua.Push(L, TextAnchor.UpperCenter);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UpperRight(IntPtr L)
	{
		ToLua.Push(L, TextAnchor.UpperRight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MiddleLeft(IntPtr L)
	{
		ToLua.Push(L, TextAnchor.MiddleLeft);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MiddleCenter(IntPtr L)
	{
		ToLua.Push(L, TextAnchor.MiddleCenter);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MiddleRight(IntPtr L)
	{
		ToLua.Push(L, TextAnchor.MiddleRight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LowerLeft(IntPtr L)
	{
		ToLua.Push(L, TextAnchor.LowerLeft);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LowerCenter(IntPtr L)
	{
		ToLua.Push(L, TextAnchor.LowerCenter);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LowerRight(IntPtr L)
	{
		ToLua.Push(L, TextAnchor.LowerRight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		TextAnchor textAnchor = (TextAnchor)num;
		ToLua.Push(L, textAnchor);
		return 1;
	}
}
