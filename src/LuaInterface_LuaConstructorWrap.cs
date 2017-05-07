using LuaInterface;
using System;

public class LuaInterface_LuaConstructorWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaConstructor), typeof(object), null);
		L.RegFunction("Call", new LuaCSFunction(LuaInterface_LuaConstructorWrap.Call));
		L.RegFunction("Destroy", new LuaCSFunction(LuaInterface_LuaConstructorWrap.Destroy));
		L.RegFunction("__tostring", new LuaCSFunction(LuaInterface_LuaConstructorWrap.Lua_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Call(IntPtr L)
	{
		int result;
		try
		{
			LuaConstructor luaConstructor = (LuaConstructor)ToLua.CheckObject(L, 1, typeof(LuaConstructor));
			result = luaConstructor.Call(L);
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Destroy(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaConstructor luaConstructor = (LuaConstructor)ToLua.CheckObject(L, 1, typeof(LuaConstructor));
			luaConstructor.Destroy();
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
