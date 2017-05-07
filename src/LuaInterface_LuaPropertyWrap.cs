using LuaInterface;
using System;

public class LuaInterface_LuaPropertyWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaProperty), typeof(object), null);
		L.RegFunction("Get", new LuaCSFunction(LuaInterface_LuaPropertyWrap.Get));
		L.RegFunction("Set", new LuaCSFunction(LuaInterface_LuaPropertyWrap.Set));
		L.RegFunction("__tostring", new LuaCSFunction(LuaInterface_LuaPropertyWrap.Lua_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Get(IntPtr L)
	{
		int result;
		try
		{
			LuaProperty luaProperty = (LuaProperty)ToLua.CheckObject(L, 1, typeof(LuaProperty));
			result = luaProperty.Get(L);
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Set(IntPtr L)
	{
		int result;
		try
		{
			LuaProperty luaProperty = (LuaProperty)ToLua.CheckObject(L, 1, typeof(LuaProperty));
			result = luaProperty.Set(L);
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
