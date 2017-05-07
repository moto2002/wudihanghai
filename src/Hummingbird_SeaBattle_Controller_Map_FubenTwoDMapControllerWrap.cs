using Hummingbird.SeaBattle.Controller.Map;
using LuaInterface;
using System;
using UnityEngine;

public class Hummingbird_SeaBattle_Controller_Map_FubenTwoDMapControllerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FubenTwoDMapController), typeof(MonoBehaviour), null);
		L.RegFunction("Handle", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_FubenTwoDMapControllerWrap.Handle));
		L.RegFunction("MoveTo", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_FubenTwoDMapControllerWrap.MoveTo));
		L.RegFunction("Init", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_FubenTwoDMapControllerWrap.Init));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_FubenTwoDMapControllerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("MovePosSpeed", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_FubenTwoDMapControllerWrap.get_MovePosSpeed), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_FubenTwoDMapControllerWrap.set_MovePosSpeed));
		L.RegVar("ClampRatio", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_FubenTwoDMapControllerWrap.get_ClampRatio), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_FubenTwoDMapControllerWrap.set_ClampRatio));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Handle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FubenTwoDMapController fubenTwoDMapController = (FubenTwoDMapController)ToLua.CheckObject(L, 1, typeof(FubenTwoDMapController));
			bool isHandle = LuaDLL.luaL_checkboolean(L, 2);
			fubenTwoDMapController.Handle(isHandle);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FubenTwoDMapController fubenTwoDMapController = (FubenTwoDMapController)ToLua.CheckObject(L, 1, typeof(FubenTwoDMapController));
			Vector3 point = ToLua.ToVector3(L, 2);
			fubenTwoDMapController.MoveTo(point);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Init(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FubenTwoDMapController fubenTwoDMapController = (FubenTwoDMapController)ToLua.CheckObject(L, 1, typeof(FubenTwoDMapController));
			Vector3 initPoint = ToLua.ToVector3(L, 2);
			fubenTwoDMapController.Init(initPoint);
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
	private static int get_MovePosSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FubenTwoDMapController fubenTwoDMapController = (FubenTwoDMapController)obj;
			float movePosSpeed = fubenTwoDMapController.MovePosSpeed;
			LuaDLL.lua_pushnumber(L, (double)movePosSpeed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MovePosSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ClampRatio(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FubenTwoDMapController fubenTwoDMapController = (FubenTwoDMapController)obj;
			Vector2 clampRatio = fubenTwoDMapController.ClampRatio;
			ToLua.Push(L, clampRatio);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ClampRatio on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_MovePosSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FubenTwoDMapController fubenTwoDMapController = (FubenTwoDMapController)obj;
			float movePosSpeed = (float)LuaDLL.luaL_checknumber(L, 2);
			fubenTwoDMapController.MovePosSpeed = movePosSpeed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MovePosSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ClampRatio(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FubenTwoDMapController fubenTwoDMapController = (FubenTwoDMapController)obj;
			Vector2 clampRatio = ToLua.ToVector2(L, 2);
			fubenTwoDMapController.ClampRatio = clampRatio;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ClampRatio on a nil value");
		}
		return result;
	}
}
