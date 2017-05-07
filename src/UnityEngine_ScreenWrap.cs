using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_ScreenWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("Screen");
		L.RegFunction("SetResolution", new LuaCSFunction(UnityEngine_ScreenWrap.SetResolution));
		L.RegVar("resolutions", new LuaCSFunction(UnityEngine_ScreenWrap.get_resolutions), null);
		L.RegVar("currentResolution", new LuaCSFunction(UnityEngine_ScreenWrap.get_currentResolution), null);
		L.RegVar("width", new LuaCSFunction(UnityEngine_ScreenWrap.get_width), null);
		L.RegVar("height", new LuaCSFunction(UnityEngine_ScreenWrap.get_height), null);
		L.RegVar("dpi", new LuaCSFunction(UnityEngine_ScreenWrap.get_dpi), null);
		L.RegVar("fullScreen", new LuaCSFunction(UnityEngine_ScreenWrap.get_fullScreen), new LuaCSFunction(UnityEngine_ScreenWrap.set_fullScreen));
		L.RegVar("autorotateToPortrait", new LuaCSFunction(UnityEngine_ScreenWrap.get_autorotateToPortrait), new LuaCSFunction(UnityEngine_ScreenWrap.set_autorotateToPortrait));
		L.RegVar("autorotateToPortraitUpsideDown", new LuaCSFunction(UnityEngine_ScreenWrap.get_autorotateToPortraitUpsideDown), new LuaCSFunction(UnityEngine_ScreenWrap.set_autorotateToPortraitUpsideDown));
		L.RegVar("autorotateToLandscapeLeft", new LuaCSFunction(UnityEngine_ScreenWrap.get_autorotateToLandscapeLeft), new LuaCSFunction(UnityEngine_ScreenWrap.set_autorotateToLandscapeLeft));
		L.RegVar("autorotateToLandscapeRight", new LuaCSFunction(UnityEngine_ScreenWrap.get_autorotateToLandscapeRight), new LuaCSFunction(UnityEngine_ScreenWrap.set_autorotateToLandscapeRight));
		L.RegVar("orientation", new LuaCSFunction(UnityEngine_ScreenWrap.get_orientation), new LuaCSFunction(UnityEngine_ScreenWrap.set_orientation));
		L.RegVar("sleepTimeout", new LuaCSFunction(UnityEngine_ScreenWrap.get_sleepTimeout), new LuaCSFunction(UnityEngine_ScreenWrap.set_sleepTimeout));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetResolution(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(bool)))
			{
				int width = (int)LuaDLL.lua_tonumber(L, 1);
				int height = (int)LuaDLL.lua_tonumber(L, 2);
				bool fullscreen = LuaDLL.lua_toboolean(L, 3);
				Screen.SetResolution(width, height, fullscreen);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(bool), typeof(int)))
			{
				int width2 = (int)LuaDLL.lua_tonumber(L, 1);
				int height2 = (int)LuaDLL.lua_tonumber(L, 2);
				bool fullscreen2 = LuaDLL.lua_toboolean(L, 3);
				int preferredRefreshRate = (int)LuaDLL.lua_tonumber(L, 4);
				Screen.SetResolution(width2, height2, fullscreen2, preferredRefreshRate);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Screen.SetResolution");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resolutions(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Screen.resolutions);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentResolution(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushValue(L, Screen.currentResolution);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_width(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Screen.width);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_height(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Screen.height);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dpi(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)Screen.dpi);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fullScreen(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Screen.fullScreen);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autorotateToPortrait(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Screen.autorotateToPortrait);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autorotateToPortraitUpsideDown(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Screen.autorotateToPortraitUpsideDown);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autorotateToLandscapeLeft(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Screen.autorotateToLandscapeLeft);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autorotateToLandscapeRight(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Screen.autorotateToLandscapeRight);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_orientation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Screen.orientation);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sleepTimeout(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Screen.sleepTimeout);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fullScreen(IntPtr L)
	{
		int result;
		try
		{
			bool fullScreen = LuaDLL.luaL_checkboolean(L, 2);
			Screen.fullScreen = fullScreen;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autorotateToPortrait(IntPtr L)
	{
		int result;
		try
		{
			bool autorotateToPortrait = LuaDLL.luaL_checkboolean(L, 2);
			Screen.autorotateToPortrait = autorotateToPortrait;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autorotateToPortraitUpsideDown(IntPtr L)
	{
		int result;
		try
		{
			bool autorotateToPortraitUpsideDown = LuaDLL.luaL_checkboolean(L, 2);
			Screen.autorotateToPortraitUpsideDown = autorotateToPortraitUpsideDown;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autorotateToLandscapeLeft(IntPtr L)
	{
		int result;
		try
		{
			bool autorotateToLandscapeLeft = LuaDLL.luaL_checkboolean(L, 2);
			Screen.autorotateToLandscapeLeft = autorotateToLandscapeLeft;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autorotateToLandscapeRight(IntPtr L)
	{
		int result;
		try
		{
			bool autorotateToLandscapeRight = LuaDLL.luaL_checkboolean(L, 2);
			Screen.autorotateToLandscapeRight = autorotateToLandscapeRight;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_orientation(IntPtr L)
	{
		int result;
		try
		{
			ScreenOrientation orientation = (ScreenOrientation)((int)ToLua.CheckObject(L, 2, typeof(ScreenOrientation)));
			Screen.orientation = orientation;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sleepTimeout(IntPtr L)
	{
		int result;
		try
		{
			int sleepTimeout = (int)LuaDLL.luaL_checknumber(L, 2);
			Screen.sleepTimeout = sleepTimeout;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
