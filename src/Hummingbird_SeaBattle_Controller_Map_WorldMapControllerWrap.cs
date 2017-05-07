using Hummingbird.SeaBattle.Controller.Map;
using LuaInterface;
using System;
using UnityEngine;

public class Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(WorldMapController), typeof(MonoBehaviour), null);
		L.RegFunction("FocusTo", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.FocusTo));
		L.RegFunction("SetCamera", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.SetCamera));
		L.RegFunction("SetCallback", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.SetCallback));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Distance", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.get_Distance), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.set_Distance));
		L.RegVar("Offset", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.get_Offset), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.set_Offset));
		L.RegVar("TiledCount", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.get_TiledCount), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.set_TiledCount));
		L.RegVar("TiledWidth", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.get_TiledWidth), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.set_TiledWidth));
		L.RegVar("DragVelocity", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.get_DragVelocity), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.set_DragVelocity));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FocusTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			WorldMapController worldMapController = (WorldMapController)ToLua.CheckObject(L, 1, typeof(WorldMapController));
			int x = (int)LuaDLL.luaL_checknumber(L, 2);
			int y = (int)LuaDLL.luaL_checknumber(L, 3);
			worldMapController.FocusTo(x, y);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetCamera(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			WorldMapController worldMapController = (WorldMapController)ToLua.CheckObject(L, 1, typeof(WorldMapController));
			GameObject objCamera = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			bool bNeedSetPos = LuaDLL.luaL_checkboolean(L, 3);
			worldMapController.SetCamera(objCamera, bNeedSetPos);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			WorldMapController worldMapController = (WorldMapController)ToLua.CheckObject(L, 1, typeof(WorldMapController));
			LuaFunction moveCoordinateLuaFunc = ToLua.CheckLuaFunction(L, 2);
			LuaFunction touchCoordinateLuaFunc = ToLua.CheckLuaFunction(L, 3);
			LuaFunction updateLuaFunc = ToLua.CheckLuaFunction(L, 4);
			worldMapController.SetCallback(moveCoordinateLuaFunc, touchCoordinateLuaFunc, updateLuaFunc);
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
	private static int get_Distance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldMapController worldMapController = (WorldMapController)obj;
			float distance = worldMapController.Distance;
			LuaDLL.lua_pushnumber(L, (double)distance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Distance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Offset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldMapController worldMapController = (WorldMapController)obj;
			Vector3 offset = worldMapController.Offset;
			ToLua.Push(L, offset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Offset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TiledCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldMapController worldMapController = (WorldMapController)obj;
			int tiledCount = worldMapController.TiledCount;
			LuaDLL.lua_pushinteger(L, tiledCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TiledCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TiledWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldMapController worldMapController = (WorldMapController)obj;
			float tiledWidth = worldMapController.TiledWidth;
			LuaDLL.lua_pushnumber(L, (double)tiledWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TiledWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DragVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldMapController worldMapController = (WorldMapController)obj;
			float dragVelocity = worldMapController.DragVelocity;
			LuaDLL.lua_pushnumber(L, (double)dragVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DragVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Distance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldMapController worldMapController = (WorldMapController)obj;
			float distance = (float)LuaDLL.luaL_checknumber(L, 2);
			worldMapController.Distance = distance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Distance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Offset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldMapController worldMapController = (WorldMapController)obj;
			Vector3 offset = ToLua.ToVector3(L, 2);
			worldMapController.Offset = offset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Offset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_TiledCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldMapController worldMapController = (WorldMapController)obj;
			int tiledCount = (int)LuaDLL.luaL_checknumber(L, 2);
			worldMapController.TiledCount = tiledCount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TiledCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_TiledWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldMapController worldMapController = (WorldMapController)obj;
			float tiledWidth = (float)LuaDLL.luaL_checknumber(L, 2);
			worldMapController.TiledWidth = tiledWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TiledWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DragVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldMapController worldMapController = (WorldMapController)obj;
			float dragVelocity = (float)LuaDLL.luaL_checknumber(L, 2);
			worldMapController.DragVelocity = dragVelocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DragVelocity on a nil value");
		}
		return result;
	}
}
