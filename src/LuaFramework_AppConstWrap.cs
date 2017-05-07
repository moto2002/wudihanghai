using LuaFramework;
using LuaInterface;
using System;

public class LuaFramework_AppConstWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AppConst), typeof(object), null);
		L.RegFunction("New", new LuaCSFunction(LuaFramework_AppConstWrap._CreateLuaFramework_AppConst));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("GameVerCode", new LuaCSFunction(LuaFramework_AppConstWrap.get_GameVerCode), new LuaCSFunction(LuaFramework_AppConstWrap.set_GameVerCode));
		L.RegVar("GameVerName", new LuaCSFunction(LuaFramework_AppConstWrap.get_GameVerName), new LuaCSFunction(LuaFramework_AppConstWrap.set_GameVerName));
		L.RegVar("UserId", new LuaCSFunction(LuaFramework_AppConstWrap.get_UserId), new LuaCSFunction(LuaFramework_AppConstWrap.set_UserId));
		L.RegVar("SocketPort", new LuaCSFunction(LuaFramework_AppConstWrap.get_SocketPort), new LuaCSFunction(LuaFramework_AppConstWrap.set_SocketPort));
		L.RegVar("SocketAddress", new LuaCSFunction(LuaFramework_AppConstWrap.get_SocketAddress), new LuaCSFunction(LuaFramework_AppConstWrap.set_SocketAddress));
		L.RegVar("FrameworkRoot", new LuaCSFunction(LuaFramework_AppConstWrap.get_FrameworkRoot), null);
		L.RegVar("PbPath", new LuaCSFunction(LuaFramework_AppConstWrap.get_PbPath), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLuaFramework_AppConst(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				AppConst o = new AppConst();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: LuaFramework.AppConst.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GameVerCode(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, AppConst.GameVerCode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GameVerName(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.GameVerName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UserId(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.UserId);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_SocketPort(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, AppConst.SocketPort);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_SocketAddress(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.SocketAddress);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FrameworkRoot(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.FrameworkRoot);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_PbPath(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.PbPath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GameVerCode(IntPtr L)
	{
		int result;
		try
		{
			int gameVerCode = (int)LuaDLL.luaL_checknumber(L, 2);
			AppConst.GameVerCode = gameVerCode;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GameVerName(IntPtr L)
	{
		int result;
		try
		{
			string gameVerName = ToLua.CheckString(L, 2);
			AppConst.GameVerName = gameVerName;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_UserId(IntPtr L)
	{
		int result;
		try
		{
			string userId = ToLua.CheckString(L, 2);
			AppConst.UserId = userId;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_SocketPort(IntPtr L)
	{
		int result;
		try
		{
			int socketPort = (int)LuaDLL.luaL_checknumber(L, 2);
			AppConst.SocketPort = socketPort;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_SocketAddress(IntPtr L)
	{
		int result;
		try
		{
			string socketAddress = ToLua.CheckString(L, 2);
			AppConst.SocketAddress = socketAddress;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
