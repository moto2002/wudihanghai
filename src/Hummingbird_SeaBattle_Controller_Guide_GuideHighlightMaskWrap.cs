using Hummingbird.SeaBattle.Controller.Guide;
using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Hummingbird_SeaBattle_Controller_Guide_GuideHighlightMaskWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GuideHighlightMask), typeof(Graphic), null);
		L.RegFunction("SetArrow", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Guide_GuideHighlightMaskWrap.SetArrow));
		L.RegFunction("InitPointerLuaFunction", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Guide_GuideHighlightMaskWrap.InitPointerLuaFunction));
		L.RegFunction("GetScreenPosition", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Guide_GuideHighlightMaskWrap.GetScreenPosition));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Guide_GuideHighlightMaskWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetArrow(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GuideHighlightMask guideHighlightMask = (GuideHighlightMask)ToLua.CheckObject(L, 1, typeof(GuideHighlightMask));
			Transform element = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			Vector2 centerOffset = ToLua.ToVector2(L, 3);
			Vector2 sizeOffset = ToLua.ToVector2(L, 4);
			guideHighlightMask.SetArrow(element, centerOffset, sizeOffset);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitPointerLuaFunction(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GuideHighlightMask guideHighlightMask = (GuideHighlightMask)ToLua.CheckObject(L, 1, typeof(GuideHighlightMask));
			LuaFunction luaOnPointer = ToLua.CheckLuaFunction(L, 2);
			guideHighlightMask.InitPointerLuaFunction(luaOnPointer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetScreenPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GuideHighlightMask guideHighlightMask = (GuideHighlightMask)ToLua.CheckObject(L, 1, typeof(GuideHighlightMask));
			Vector2 screenPosition = guideHighlightMask.GetScreenPosition();
			ToLua.Push(L, screenPosition);
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
