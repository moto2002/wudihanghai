using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class System_Collections_Generic_DictionaryWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Dictionary<, >), typeof(object), "Dictionary");
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.get_Item));
		L.RegFunction("set_Item", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.set_Item));
		L.RegFunction(".geti", new LuaCSFunction(System_Collections_Generic_DictionaryWrap._geti));
		L.RegFunction(".seti", new LuaCSFunction(System_Collections_Generic_DictionaryWrap._seti));
		L.RegFunction("Add", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.Add));
		L.RegFunction("Clear", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.Clear));
		L.RegFunction("ContainsKey", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.ContainsKey));
		L.RegFunction("ContainsValue", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.ContainsValue));
		L.RegFunction("GetObjectData", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.GetObjectData));
		L.RegFunction("OnDeserialization", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.OnDeserialization));
		L.RegFunction("Remove", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.Remove));
		L.RegFunction("TryGetValue", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.TryGetValue));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.GetEnumerator));
		L.RegVar("this", new LuaCSFunction(System_Collections_Generic_DictionaryWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.get_Count), null);
		L.RegVar("Comparer", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.get_Comparer), null);
		L.RegVar("Keys", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.get_Keys), null);
		L.RegVar("Values", new LuaCSFunction(System_Collections_Generic_DictionaryWrap.get_Values), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _get_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type t = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out t);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			object obj3 = LuaMethodCache.CallSingleMethod("get_Item", obj, new object[]
			{
				obj2
			});
			ToLua.Push(L, obj3);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _set_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type t;
			Type t2;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out t, out t2);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			object obj3 = ToLua.CheckVarObject(L, 2, t2);
			LuaMethodCache.CallSingleMethod("set_Item", obj, new object[]
			{
				obj2,
				obj3
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
	private static int _this(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushvalue(L, 1);
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(System_Collections_Generic_DictionaryWrap._get_this), new LuaCSFunction(System_Collections_Generic_DictionaryWrap._set_this));
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
			Type t = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out t);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			object obj3 = LuaMethodCache.CallSingleMethod("get_Item", obj, new object[]
			{
				obj2
			});
			ToLua.Push(L, obj3);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type t;
			Type t2;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out t, out t2);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			object obj3 = ToLua.CheckVarObject(L, 2, t2);
			LuaMethodCache.CallSingleMethod("set_Item", obj, new object[]
			{
				obj2,
				obj3
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
	private static int _geti(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out type);
			if (type != typeof(int))
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				object obj2 = ToLua.CheckVarObject(L, 2, type);
				object obj3 = LuaMethodCache.CallSingleMethod("get_Item", obj, new object[]
				{
					obj2
				});
				ToLua.Push(L, obj3);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _seti(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type type;
			Type t;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out type, out t);
			if (type == typeof(int))
			{
				object obj2 = ToLua.CheckVarObject(L, 2, type);
				object obj3 = ToLua.CheckVarObject(L, 2, t);
				LuaMethodCache.CallSingleMethod("set_Item", obj, new object[]
				{
					obj2,
					obj3
				});
			}
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Add(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type t;
			Type t2;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out t, out t2);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			object obj3 = ToLua.CheckVarObject(L, 2, t2);
			LuaMethodCache.CallSingleMethod("Add", obj, new object[]
			{
				obj2,
				obj3
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
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >));
			LuaMethodCache.CallSingleMethod("Clear", obj, new object[0]);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ContainsKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type t;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out t);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			bool value = (bool)LuaMethodCache.CallSingleMethod("ContainsKey", obj, new object[]
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
	private static int ContainsValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type;
			Type t;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out type, out t);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			bool value = (bool)LuaMethodCache.CallSingleMethod("ContainsValue", obj, new object[]
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
	private static int GetObjectData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >));
			SerializationInfo serializationInfo = (SerializationInfo)ToLua.CheckObject(L, 2, typeof(SerializationInfo));
			StreamingContext streamingContext = (StreamingContext)ToLua.CheckObject(L, 3, typeof(StreamingContext));
			LuaMethodCache.CallSingleMethod("GetObjectData", obj, new object[]
			{
				serializationInfo,
				streamingContext
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
	private static int OnDeserialization(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >));
			object obj2 = ToLua.ToVarObject(L, 2);
			LuaMethodCache.CallSingleMethod("OnDeserialization", obj, new object[]
			{
				obj2
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
	private static int Remove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type t;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out t);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			bool value = (bool)LuaMethodCache.CallSingleMethod("Remove", obj, new object[]
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
	private static int TryGetValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type t;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >), out t);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			object obj3 = null;
			object[] array = new object[]
			{
				obj2,
				obj3
			};
			bool value = (bool)LuaMethodCache.CallSingleMethod("TryGetValue", obj, array);
			LuaDLL.lua_pushboolean(L, value);
			ToLua.Push(L, array[1]);
			result = 2;
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
			object obj = ToLua.CheckGenericObject(L, 1, typeof(Dictionary<, >));
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Comparer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			object o = LuaMethodCache.CallSingleMethod("get_Comparer", obj, new object[0]);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Comparer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Keys(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			object o = LuaMethodCache.CallSingleMethod("get_Keys", obj, new object[0]);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Keys on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Values(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			object o = LuaMethodCache.CallSingleMethod("get_Values", obj, new object[0]);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Values on a nil value");
		}
		return result;
	}
}
