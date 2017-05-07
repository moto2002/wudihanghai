using LuaInterface;
using System;

public class LuaInterface_LuaFieldWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaField), typeof(object), null);
		L.RegFunction("Get", new LuaCSFunction(LuaInterface_LuaFieldWrap.Get));
		L.RegFunction("Set", new LuaCSFunction(LuaInterface_LuaFieldWrap.Set));
		L.RegFunction("__tostring", new LuaCSFunction(LuaInterface_LuaFieldWrap.Lua_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Get(IntPtr L)
	{
		int result;
		try
		{
			LuaField luaField = (LuaField)ToLua.CheckObject(L, 1, typeof(LuaField));
			result = luaField.Get(L);
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
			LuaField luaField = (LuaField)ToLua.CheckObject(L, 1, typeof(LuaField));
			result = luaField.Set(L);
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
