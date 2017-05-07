using Hummingbird.SeaBattle.Controller.Map;
using LuaInterface;
using System;
using UnityEngine;

public class Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(BusinessSysMapController), typeof(MonoBehaviour), null);
		L.RegFunction("InitRenderTextureCamera", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.InitRenderTextureCamera));
		L.RegFunction("GetRenderTexture", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.GetRenderTexture));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("RenderTextureCamera", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.get_RenderTextureCamera), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.set_RenderTextureCamera));
		L.RegVar("Depth", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.get_Depth), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.set_Depth));
		L.RegVar("RenderTextureWidth", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.get_RenderTextureWidth), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.set_RenderTextureWidth));
		L.RegVar("RenderTextureHeight", new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.get_RenderTextureHeight), new LuaCSFunction(Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.set_RenderTextureHeight));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitRenderTextureCamera(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BusinessSysMapController businessSysMapController = (BusinessSysMapController)ToLua.CheckObject(L, 1, typeof(BusinessSysMapController));
			businessSysMapController.InitRenderTextureCamera();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRenderTexture(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BusinessSysMapController businessSysMapController = (BusinessSysMapController)ToLua.CheckObject(L, 1, typeof(BusinessSysMapController));
			Texture renderTexture = businessSysMapController.GetRenderTexture();
			ToLua.Push(L, renderTexture);
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
	private static int get_RenderTextureCamera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BusinessSysMapController businessSysMapController = (BusinessSysMapController)obj;
			Camera renderTextureCamera = businessSysMapController.RenderTextureCamera;
			ToLua.Push(L, renderTextureCamera);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RenderTextureCamera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BusinessSysMapController businessSysMapController = (BusinessSysMapController)obj;
			int depth = businessSysMapController.Depth;
			LuaDLL.lua_pushinteger(L, depth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_RenderTextureWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BusinessSysMapController businessSysMapController = (BusinessSysMapController)obj;
			int renderTextureWidth = businessSysMapController.RenderTextureWidth;
			LuaDLL.lua_pushinteger(L, renderTextureWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RenderTextureWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_RenderTextureHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BusinessSysMapController businessSysMapController = (BusinessSysMapController)obj;
			int renderTextureHeight = businessSysMapController.RenderTextureHeight;
			LuaDLL.lua_pushinteger(L, renderTextureHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RenderTextureHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_RenderTextureCamera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BusinessSysMapController businessSysMapController = (BusinessSysMapController)obj;
			Camera renderTextureCamera = (Camera)ToLua.CheckUnityObject(L, 2, typeof(Camera));
			businessSysMapController.RenderTextureCamera = renderTextureCamera;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RenderTextureCamera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BusinessSysMapController businessSysMapController = (BusinessSysMapController)obj;
			int depth = (int)LuaDLL.luaL_checknumber(L, 2);
			businessSysMapController.Depth = depth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_RenderTextureWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BusinessSysMapController businessSysMapController = (BusinessSysMapController)obj;
			int renderTextureWidth = (int)LuaDLL.luaL_checknumber(L, 2);
			businessSysMapController.RenderTextureWidth = renderTextureWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RenderTextureWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_RenderTextureHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BusinessSysMapController businessSysMapController = (BusinessSysMapController)obj;
			int renderTextureHeight = (int)LuaDLL.luaL_checknumber(L, 2);
			businessSysMapController.RenderTextureHeight = renderTextureHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RenderTextureHeight on a nil value");
		}
		return result;
	}
}
