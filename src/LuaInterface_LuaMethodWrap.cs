using LuaInterface;
using System;

public class LuaInterface_LuaMethodWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaMethod), typeof(object), null);
		L.RegFunction("Destroy", new LuaCSFunction(LuaInterface_LuaMethodWrap.Destroy));
		L.RegFunction("Call", new LuaCSFunction(LuaInterface_LuaMethodWrap.Call));
		L.RegFunction("__tostring", new LuaCSFunction(LuaInterface_LuaMethodWrap.Lua_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Destroy(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaMethod luaMethod = (LuaMethod)ToLua.CheckObject(L, 1, typeof(LuaMethod));
			luaMethod.Destroy();
			ToLua.Destroy(L);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Call(IntPtr L)
	{
		int result;
		try
		{
			LuaMethod luaMethod = (LuaMethod)ToLua.CheckObject(L, 1, typeof(LuaMethod));
			result = luaMethod.Call(L);
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_ToString(IntPtr L)
	{
		object obj = ToLua.ToObject(L, 1);
		if (obj != null)
		{
			LuaDLL.lua_pushstring(L, obj.ToString());
		}
		else
		{
			LuaDLL.lua_pushnil(L);
		}
		return 1;
	}
}
