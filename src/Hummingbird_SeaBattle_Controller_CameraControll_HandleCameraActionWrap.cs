using Hummingbird.SeaBattle.Controller.CameraControll;
using LuaInterface;
using System;
using UnityEngine;

public class Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(HandleCameraAction), typeof(MonoBehaviour), null);
		L.RegFunction("AddTouchScreen", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.AddTouchScreen));
		L.RegFunction("MoveTo", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.MoveTo));
		L.RegFunction("SmoothTo", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.SmoothTo));
		L.RegFunction("Init", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.Init));
		L.RegFunction("SmoothPinch", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.SmoothPinch));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Camera", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.get_Camera), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.set_Camera));
		L.RegVar("PinchSmoothTime", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.get_PinchSmoothTime), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.set_PinchSmoothTime));
		L.RegVar("PinchSpeed", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.get_PinchSpeed), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.set_PinchSpeed));
		L.RegVar("PinchPower", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.get_PinchPower), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.set_PinchPower));
		L.RegVar("MoveSmoothTime", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.get_MoveSmoothTime), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.set_MoveSmoothTime));
		L.RegVar("MovePosSpeed", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.get_MovePosSpeed), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.set_MovePosSpeed));
		L.RegVar("ClampOffsetAngle", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.get_ClampOffsetAngle), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.set_ClampOffsetAngle));
		L.RegVar("ClampRatio", new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.get_ClampRatio), new LuaCSFunction(Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.set_ClampRatio));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddTouchScreen(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			HandleCameraAction handleCameraAction = (HandleCameraAction)ToLua.CheckObject(L, 1, typeof(HandleCameraAction));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 2);
			handleCameraAction.AddTouchScreen(luafunc);
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
			HandleCameraAction handleCameraAction = (HandleCameraAction)ToLua.CheckObject(L, 1, typeof(HandleCameraAction));
			Vector3 point = ToLua.ToVector3(L, 2);
			handleCameraAction.MoveTo(point);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SmoothTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			HandleCameraAction handleCameraAction = (HandleCameraAction)ToLua.CheckObject(L, 1, typeof(HandleCameraAction));
			Vector3 point = ToLua.ToVector3(L, 2);
			handleCameraAction.SmoothTo(point);
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
			HandleCameraAction handleCameraAction = (HandleCameraAction)ToLua.CheckObject(L, 1, typeof(HandleCameraAction));
			Vector3 initPoint = ToLua.ToVector3(L, 2);
			handleCameraAction.Init(initPoint);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SmoothPinch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			HandleCameraAction handleCameraAction = (HandleCameraAction)ToLua.CheckObject(L, 1, typeof(HandleCameraAction));
			float val = (float)LuaDLL.luaL_checknumber(L, 2);
			handleCameraAction.SmoothPinch(val);
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
	private static int get_Camera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			Camera camera = handleCameraAction.Camera;
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
	private static int get_PinchSmoothTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float pinchSmoothTime = handleCameraAction.PinchSmoothTime;
			LuaDLL.lua_pushnumber(L, (double)pinchSmoothTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index PinchSmoothTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_PinchSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float pinchSpeed = handleCameraAction.PinchSpeed;
			LuaDLL.lua_pushnumber(L, (double)pinchSpeed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index PinchSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_PinchPower(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float pinchPower = handleCameraAction.PinchPower;
			LuaDLL.lua_pushnumber(L, (double)pinchPower);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index PinchPower on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MoveSmoothTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float moveSmoothTime = handleCameraAction.MoveSmoothTime;
			LuaDLL.lua_pushnumber(L, (double)moveSmoothTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MoveSmoothTime on a nil value");
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
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float movePosSpeed = handleCameraAction.MovePosSpeed;
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
	private static int get_ClampOffsetAngle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float clampOffsetAngle = handleCameraAction.ClampOffsetAngle;
			LuaDLL.lua_pushnumber(L, (double)clampOffsetAngle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ClampOffsetAngle on a nil value");
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
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			Vector2 clampRatio = handleCameraAction.ClampRatio;
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
	private static int set_Camera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			Camera camera = (Camera)ToLua.CheckUnityObject(L, 2, typeof(Camera));
			handleCameraAction.Camera = camera;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Camera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_PinchSmoothTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float pinchSmoothTime = (float)LuaDLL.luaL_checknumber(L, 2);
			handleCameraAction.PinchSmoothTime = pinchSmoothTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index PinchSmoothTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_PinchSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float pinchSpeed = (float)LuaDLL.luaL_checknumber(L, 2);
			handleCameraAction.PinchSpeed = pinchSpeed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index PinchSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_PinchPower(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float pinchPower = (float)LuaDLL.luaL_checknumber(L, 2);
			handleCameraAction.PinchPower = pinchPower;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index PinchPower on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_MoveSmoothTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float moveSmoothTime = (float)LuaDLL.luaL_checknumber(L, 2);
			handleCameraAction.MoveSmoothTime = moveSmoothTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MoveSmoothTime on a nil value");
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
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float movePosSpeed = (float)LuaDLL.luaL_checknumber(L, 2);
			handleCameraAction.MovePosSpeed = movePosSpeed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MovePosSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ClampOffsetAngle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			float clampOffsetAngle = (float)LuaDLL.luaL_checknumber(L, 2);
			handleCameraAction.ClampOffsetAngle = clampOffsetAngle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ClampOffsetAngle on a nil value");
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
			HandleCameraAction handleCameraAction = (HandleCameraAction)obj;
			Vector2 clampRatio = ToLua.ToVector2(L, 2);
			handleCameraAction.ClampRatio = clampRatio;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ClampRatio on a nil value");
		}
		return result;
	}
}
