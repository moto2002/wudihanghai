using LuaInterface;
using System;
using System.Collections.Generic;

public class System_Collections_Generic_KeyValuePairWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(KeyValuePair<, >), null, "KeyValuePair");
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Key", new LuaCSFunction(System_Collections_Generic_KeyValuePairWrap.get_Key), null);
		L.RegVar("Value", new LuaCSFunction(System_Collections_Generic_KeyValuePairWrap.get_Value), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Key(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			object obj2 = LuaMethodCache.CallSingleMethod("get_Key", obj, new object[0]);
			ToLua.Push(L, obj2);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Key on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			object obj2 = LuaMethodCache.CallSingleMethod("get_Value", obj, new object[0]);
			ToLua.Push(L, obj2);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Value on a nil value");
		}
		return result;
	}
}
