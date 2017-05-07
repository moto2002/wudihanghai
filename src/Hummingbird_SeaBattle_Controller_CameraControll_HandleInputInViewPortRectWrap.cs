using Hummingbird.SeaBattle.Controller.CameraControll;
using LuaInterface;
using System;
using UnityEngine;

public class Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(HandleInputInViewPortRect), typeof(MonoBehaviour), null);
		L.RegFunction("CutViewPortRect", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.CutViewPortRect));
		L.RegFunction("Handle", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.Handle));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("MatchHeight", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.get_MatchHeight), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.set_MatchHeight));
		L.RegVar("DisplayWidth", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.get_DisplayWidth), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.set_DisplayWidth));
		L.RegVar("Camera", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.get_Camera), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.set_Camera));
		L.RegVar("CameraActionCtrl", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.get_CameraActionCtrl), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.set_CameraActionCtrl));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CutViewPortRect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			HandleInputInViewPortRect handleInputInViewPortRect = (HandleInputInViewPortRect)ToLua.CheckObject(L, 1, typeof(HandleInputInViewPortRect));
			float displayWidth = (float)LuaDLL.luaL_checknumber(L, 2);
			float rectYRatio = (float)LuaDLL.luaL_checknumber(L, 3);
			float rectHeightRatio = (float)LuaDLL.luaL_checknumber(L, 4);
			handleInputInViewPortRect.CutViewPortRect(displayWidth, rectYRatio, rectHeightRatio);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Handle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			HandleInputInViewPortRect handleInputInViewPortRect = (HandleInputInViewPortRect)ToLua.CheckObject(L, 1, typeof(HandleInputInViewPortRect));
			bool isHandle = LuaDLL.luaL_checkboolean(L, 2);
			handleInputInViewPortRect.Handle(isHandle);
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
	private static int get_MatchHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleInputInViewPortRect handleInputInViewPortRect = (HandleInputInViewPortRect)obj;
			float matchHeight = handleInputInViewPortRect.MatchHeight;
			LuaDLL.lua_pushnumber(L, (double)matchHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MatchHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DisplayWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleInputInViewPortRect handleInputInViewPortRect = (HandleInputInViewPortRect)obj;
			float displayWidth = handleInputInViewPortRect.DisplayWidth;
			LuaDLL.lua_pushnumber(L, (double)displayWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DisplayWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Camera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleInputInViewPortRect handleInputInViewPortRect = (HandleInputInViewPortRect)obj;
			Camera camera = handleInputInViewPortRect.Camera;
			ToLua.Push(L, camera);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Camera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CameraActionCtrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleInputInViewPortRect handleInputInViewPortRect = (HandleInputInViewPortRect)obj;
			HandleCameraAction cameraActionCtrl = handleInputInViewPortRect.CameraActionCtrl;
			ToLua.Push(L, cameraActionCtrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CameraActionCtrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_MatchHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleInputInViewPortRect handleInputInViewPortRect = (HandleInputInViewPortRect)obj;
			float matchHeight = (float)LuaDLL.luaL_checknumber(L, 2);
			handleInputInViewPortRect.MatchHeight = matchHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MatchHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DisplayWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleInputInViewPortRect handleInputInViewPortRect = (HandleInputInViewPortRect)obj;
			float displayWidth = (float)LuaDLL.luaL_checknumber(L, 2);
			handleInputInViewPortRect.DisplayWidth = displayWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DisplayWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Camera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleInputInViewPortRect handleInputInViewPortRect = (HandleInputInViewPortRect)obj;
			Camera camera = (Camera)ToLua.CheckUnityObject(L, 2, typeof(Camera));
			handleInputInViewPortRect.Camera = camera;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Camera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CameraActionCtrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleInputInViewPortRect handleInputInViewPortRect = (HandleInputInViewPortRect)obj;
			HandleCameraAction cameraActionCtrl = (HandleCameraAction)ToLua.CheckUnityObject(L, 2, typeof(HandleCameraAction));
			handleInputInViewPortRect.CameraActionCtrl = cameraActionCtrl;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CameraActionCtrl on a nil value");
		}
		return result;
	}
}
