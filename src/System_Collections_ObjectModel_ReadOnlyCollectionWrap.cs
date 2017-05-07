using LuaInterface;
using System;
using System.Collections;
using System.Collections.ObjectModel;

public class System_Collections_ObjectModel_ReadOnlyCollectionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ReadOnlyCollection<>), typeof(object), "ReadOnlyCollection");
		L.RegFunction("Contains", new LuaCSFunction(System_Collections_ObjectModel_ReadOnlyCollectionWrap.Contains));
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_ObjectModel_ReadOnlyCollectionWrap.CopyTo));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_ObjectModel_ReadOnlyCollectionWrap.GetEnumerator));
		L.RegFunction("IndexOf", new LuaCSFunction(System_Collections_ObjectModel_ReadOnlyCollectionWrap.IndexOf));
		L.RegFunction(".geti", new LuaCSFunction(System_Collections_ObjectModel_ReadOnlyCollectionWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_ObjectModel_ReadOnlyCollectionWrap.get_Item));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Count", new LuaCSFunction(System_Collections_ObjectModel_ReadOnlyCollectionWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Contains(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type t = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(ReadOnlyCollection<>), out t);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			bool value = (bool)LuaMethodCache.CallSingleMethod("Contains", obj, new object[]
			{
				obj2
			});
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
	private static int CopyTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(ReadOnlyCollection<>), out type);
			object obj2 = ToLua.CheckObject(L, 2, type.MakeArrayType());
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
			object obj = ToLua.CheckGenericObject(L, 1, typeof(ReadOnlyCollection<>));
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
	private static int IndexOf(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type t = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(ReadOnlyCollection<>), out t);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			int n = (int)LuaMethodCache.CallSingleMethod("IndexOf", obj, new object[]
			{
				obj2
			});
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(ReadOnlyCollection<>));
			int num = (int)LuaDLL.luaL_checknumber(L, 2);
			int n = (int)LuaMethodCache.CallSingleMethod("get_Item", obj, new object[]
			{
				num
			});
			LuaDLL.lua_pushinteger(L, n);
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
