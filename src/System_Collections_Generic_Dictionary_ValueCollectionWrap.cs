using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;

public class System_Collections_Generic_Dictionary_ValueCollectionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Dictionary<, >.ValueCollection), typeof(object), "ValueCollection");
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_Generic_Dictionary_ValueCollectionWrap.CopyTo));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_Dictionary_ValueCollectionWrap.GetEnumerator));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_Dictionary_ValueCollectionWrap._CreateSystem_Collections_Generic_Dictionary_ValueCollection));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_Dictionary_ValueCollectionWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_Dictionary_ValueCollection(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >));
				Type nestedType = obj.GetType().GetNestedType("ValueCollection");
				object o = Activator.CreateInstance(nestedType, new object[]
				{
					obj
				});
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.Dictionary.ValueCollection.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type type;
			Type type2;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >.ValueCollection), out type, out type2);
			object obj2 = ToLua.CheckObject(L, 2, type2.MakeArrayType());
			int num = (int)LuaDLL.luaL_checknumber(L, 3);
			LuaMethodCache.CallSingleMethod("CopyTo", obj, new object[]
			{
				obj2,
				num
			});
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEnumerator(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >.ValueCollection));
			IEnumerator iter = (IEnumerator)LuaMethodCache.CallSingleMethod("GetEnumerator", obj, new object[0]);
			ToLua.Push(L, iter);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Count(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int n = (int)LuaMethodCache.CallSingleMethod("get_Count", obj, new object[0]);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Count on a nil value");
		}
		return result;
	}
}
