using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;

public class System_Collections_Generic_ListWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(List<>), typeof(object), "List");
		L.RegFunction("Add", new LuaCSFunction(System_Collections_Generic_ListWrap.Add));
		L.RegFunction("AddRange", new LuaCSFunction(System_Collections_Generic_ListWrap.AddRange));
		L.RegFunction("AsReadOnly", new LuaCSFunction(System_Collections_Generic_ListWrap.AsReadOnly));
		L.RegFunction("BinarySearch", new LuaCSFunction(System_Collections_Generic_ListWrap.BinarySearch));
		L.RegFunction("Clear", new LuaCSFunction(System_Collections_Generic_ListWrap.Clear));
		L.RegFunction("Contains", new LuaCSFunction(System_Collections_Generic_ListWrap.Contains));
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_Generic_ListWrap.CopyTo));
		L.RegFunction("Exists", new LuaCSFunction(System_Collections_Generic_ListWrap.Exists));
		L.RegFunction("Find", new LuaCSFunction(System_Collections_Generic_ListWrap.Find));
		L.RegFunction("FindAll", new LuaCSFunction(System_Collections_Generic_ListWrap.FindAll));
		L.RegFunction("FindIndex", new LuaCSFunction(System_Collections_Generic_ListWrap.FindIndex));
		L.RegFunction("FindLast", new LuaCSFunction(System_Collections_Generic_ListWrap.FindLast));
		L.RegFunction("FindLastIndex", new LuaCSFunction(System_Collections_Generic_ListWrap.FindLastIndex));
		L.RegFunction("ForEach", new LuaCSFunction(System_Collections_Generic_ListWrap.ForEach));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_ListWrap.GetEnumerator));
		L.RegFunction("GetRange", new LuaCSFunction(System_Collections_Generic_ListWrap.GetRange));
		L.RegFunction("IndexOf", new LuaCSFunction(System_Collections_Generic_ListWrap.IndexOf));
		L.RegFunction("Insert", new LuaCSFunction(System_Collections_Generic_ListWrap.Insert));
		L.RegFunction("InsertRange", new LuaCSFunction(System_Collections_Generic_ListWrap.InsertRange));
		L.RegFunction("LastIndexOf", new LuaCSFunction(System_Collections_Generic_ListWrap.LastIndexOf));
		L.RegFunction("Remove", new LuaCSFunction(System_Collections_Generic_ListWrap.Remove));
		L.RegFunction("RemoveAll", new LuaCSFunction(System_Collections_Generic_ListWrap.RemoveAll));
		L.RegFunction("RemoveAt", new LuaCSFunction(System_Collections_Generic_ListWrap.RemoveAt));
		L.RegFunction("RemoveRange", new LuaCSFunction(System_Collections_Generic_ListWrap.RemoveRange));
		L.RegFunction("Reverse", new LuaCSFunction(System_Collections_Generic_ListWrap.Reverse));
		L.RegFunction("Sort", new LuaCSFunction(System_Collections_Generic_ListWrap.Sort));
		L.RegFunction("ToArray", new LuaCSFunction(System_Collections_Generic_ListWrap.ToArray));
		L.RegFunction("TrimExcess", new LuaCSFunction(System_Collections_Generic_ListWrap.TrimExcess));
		L.RegFunction("TrueForAll", new LuaCSFunction(System_Collections_Generic_ListWrap.TrueForAll));
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_Generic_ListWrap.get_Item));
		L.RegFunction("set_Item", new LuaCSFunction(System_Collections_Generic_ListWrap.set_Item));
		L.RegFunction(".geti", new LuaCSFunction(System_Collections_Generic_ListWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(System_Collections_Generic_ListWrap.set_Item));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Capacity", new LuaCSFunction(System_Collections_Generic_ListWrap.get_Capacity), new LuaCSFunction(System_Collections_Generic_ListWrap.set_Capacity));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_ListWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Add(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type t = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out t);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			LuaMethodCache.CallSingleMethod("Add", obj, new object[]
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
	private static int AddRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			object obj2 = ToLua.CheckObject(L, 2, typeof(IEnumerable<>).MakeGenericType(new Type[]
			{
				type
			}));
			LuaMethodCache.CallSingleMethod("AddRange", obj, new object[]
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
	private static int AsReadOnly(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			object obj2 = LuaMethodCache.CallSingleMethod("AsReadOnly", obj, new object[0]);
			ToLua.Push(L, obj2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BinarySearch(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			if (num == 2 && TypeChecker.CheckTypes(L, 2, type))
			{
				object obj2 = ToLua.ToVarObject(L, 2, type);
				int n = (int)LuaMethodCache.CallMethod("BinarySearch", obj, new object[]
				{
					obj2
				});
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 2, type, typeof(IComparer<>).MakeGenericType(new Type[]
			{
				type
			})))
			{
				object obj3 = ToLua.ToVarObject(L, 2, type);
				object obj4 = ToLua.ToObject(L, 3);
				int n2 = (int)LuaMethodCache.CallMethod("BinarySearch", obj, new object[]
				{
					obj3,
					obj4
				});
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 2, typeof(int), typeof(int), type, typeof(IComparer<>).MakeGenericType(new Type[]
			{
				type
			})))
			{
				int num2 = (int)LuaDLL.lua_tonumber(L, 2);
				int num3 = (int)LuaDLL.lua_tonumber(L, 3);
				object obj5 = ToLua.ToVarObject(L, 4, type);
				object obj6 = ToLua.ToObject(L, 5);
				int n3 = (int)LuaMethodCache.CallMethod("BinarySearch", obj, new object[]
				{
					num2,
					num3,
					obj5,
					obj6
				});
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, string.Format("invalid arguments to method: List<{0}>.BinarySearch", LuaMisc.GetTypeName(type)));
			}
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
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>));
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
	private static int Contains(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type t = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out t);
			object obj2 = ToLua.CheckVarObject(L, 2, t);
			object obj3 = LuaMethodCache.CallSingleMethod("Contains", obj, new object[]
			{
				obj2
			});
			LuaDLL.lua_pushboolean(L, (bool)obj3);
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
			int num = LuaDLL.lua_gettop(L);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			if (num == 2 && TypeChecker.CheckTypes(L, 2, type.MakeArrayType()))
			{
				object obj2 = ToLua.ToObject(L, 2);
				LuaMethodCache.CallMethod("CopyTo", obj, new object[]
				{
					obj2
				});
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 2, type.MakeArrayType(), typeof(int)))
			{
				object obj3 = ToLua.ToObject(L, 2);
				int num2 = (int)LuaDLL.lua_tonumber(L, 3);
				LuaMethodCache.CallMethod("CopyTo", obj, new object[]
				{
					obj3,
					num2
				});
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 2, typeof(int), type.MakeArrayType(), typeof(int), typeof(int)))
			{
				int num3 = (int)LuaDLL.lua_tonumber(L, 2);
				object obj4 = ToLua.ToObject(L, 3);
				int num4 = (int)LuaDLL.lua_tonumber(L, 4);
				int num5 = (int)LuaDLL.lua_tonumber(L, 5);
				LuaMethodCache.CallMethod("CopyTo", obj, new object[]
				{
					num3,
					obj4,
					num4,
					num5
				});
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, string.Format("invalid arguments to method: List<{0}>.CopyTo", LuaMisc.GetTypeName(type)));
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Exists(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Delegate @delegate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				@delegate = (Delegate)ToLua.CheckObject(L, 2, typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				@delegate = DelegateFactory.CreateDelegate(typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}), func);
			}
			bool value = (bool)LuaMethodCache.CallMethod("Exists", obj, new object[]
			{
				@delegate
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
	private static int Find(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Delegate @delegate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				@delegate = (Delegate)ToLua.CheckObject(L, 2, typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				@delegate = DelegateFactory.CreateDelegate(typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}), func);
			}
			object obj2 = LuaMethodCache.CallMethod("Find", obj, new object[]
			{
				@delegate
			});
			ToLua.Push(L, obj2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Delegate @delegate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				@delegate = (Delegate)ToLua.CheckObject(L, 2, typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				@delegate = DelegateFactory.CreateDelegate(typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}), func);
			}
			object obj2 = LuaMethodCache.CallMethod("FindAll", obj, new object[]
			{
				@delegate
			});
			ToLua.Push(L, obj2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindIndex(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			if (num == 2 && TypeChecker.CheckTypes(L, 2, typeof(Predicate<>).MakeGenericType(new Type[]
			{
				type
			})))
			{
				Delegate @delegate = (Delegate)ToLua.ToObject(L, 2);
				int n = (int)LuaMethodCache.CallMethod("FindIndex", obj, new object[]
				{
					@delegate
				});
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 2, typeof(int), typeof(Predicate<>).MakeGenericType(new Type[]
			{
				type
			})))
			{
				int num2 = (int)LuaDLL.lua_tonumber(L, 2);
				Delegate delegate2 = (Delegate)ToLua.ToObject(L, 3);
				int n2 = (int)LuaMethodCache.CallMethod("FindIndex", obj, new object[]
				{
					num2,
					delegate2
				});
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 2, typeof(int), typeof(int), typeof(Predicate<>).MakeGenericType(new Type[]
			{
				type
			})))
			{
				int num3 = (int)LuaDLL.lua_tonumber(L, 2);
				int num4 = (int)LuaDLL.lua_tonumber(L, 3);
				Delegate delegate3 = (Delegate)ToLua.ToObject(L, 4);
				int n3 = (int)LuaMethodCache.CallMethod("FindIndex", obj, new object[]
				{
					num3,
					num4,
					delegate3
				});
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, string.Format("invalid arguments to method: List<{0}>.FindIndex", LuaMisc.GetTypeName(type)));
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindLast(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Delegate @delegate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				@delegate = (Delegate)ToLua.CheckObject(L, 2, typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				@delegate = DelegateFactory.CreateDelegate(typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}), func);
			}
			object obj2 = LuaMethodCache.CallSingleMethod("FindLast", obj, new object[]
			{
				@delegate
			});
			ToLua.Push(L, obj2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindLastIndex(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			if (num == 2 && TypeChecker.CheckTypes(L, 2, typeof(Predicate<>).MakeGenericType(new Type[]
			{
				type
			})))
			{
				Delegate @delegate = (Delegate)ToLua.ToObject(L, 2);
				int n = (int)LuaMethodCache.CallMethod("FindLastIndex", obj, new object[]
				{
					@delegate
				});
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 2, typeof(int), typeof(Predicate<>).MakeGenericType(new Type[]
			{
				type
			})))
			{
				int num2 = (int)LuaDLL.lua_tonumber(L, 2);
				Delegate delegate2 = (Delegate)ToLua.ToObject(L, 3);
				int n2 = (int)LuaMethodCache.CallMethod("FindLastIndex", obj, new object[]
				{
					num2,
					delegate2
				});
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 2, typeof(int), typeof(int), typeof(Predicate<int>)))
			{
				int num3 = (int)LuaDLL.lua_tonumber(L, 2);
				int num4 = (int)LuaDLL.lua_tonumber(L, 3);
				Delegate delegate3 = (Delegate)ToLua.ToObject(L, 4);
				int n3 = (int)LuaMethodCache.CallMethod("FindLastIndex", obj, new object[]
				{
					num3,
					num4,
					delegate3
				});
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, string.Format("invalid arguments to method: List<{0}>.FindLastIndex", LuaMisc.GetTypeName(type)));
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ForEach(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Delegate @delegate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				@delegate = (Delegate)ToLua.CheckObject(L, 2, typeof(Action<>).MakeGenericType(new Type[]
				{
					type
				}));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				@delegate = DelegateFactory.CreateDelegate(typeof(Action<>).MakeGenericType(new Type[]
				{
					type
				}), func);
			}
			LuaMethodCache.CallSingleMethod("ForEach", obj, new object[]
			{
				@delegate
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
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>));
			IEnumerator iter = LuaMethodCache.CallSingleMethod("GetEnumerator", obj, new object[0]) as IEnumerator;
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
	private static int GetRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>));
			int num = (int)LuaDLL.luaL_checknumber(L, 2);
			int num2 = (int)LuaDLL.luaL_checknumber(L, 3);
			object o = LuaMethodCache.CallSingleMethod("GetRange", obj, new object[]
			{
				num,
				num2
			});
			ToLua.PushObject(L, o);
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
			int num = LuaDLL.lua_gettop(L);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			if (num == 2 && TypeChecker.CheckTypes(L, 2, type))
			{
				object obj2 = ToLua.ToVarObject(L, 2, type);
				int n = (int)LuaMethodCache.CallMethod("IndexOf", obj, new object[]
				{
					obj2
				});
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 2, type, typeof(int)))
			{
				object obj3 = ToLua.ToVarObject(L, 2, type);
				int num2 = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = (int)LuaMethodCache.CallMethod("IndexOf", obj, new object[]
				{
					obj3,
					num2
				});
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 2, type, typeof(int), typeof(int)))
			{
				object obj4 = ToLua.ToVarObject(L, 2, type);
				int num3 = (int)LuaDLL.lua_tonumber(L, 3);
				int num4 = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = (int)LuaMethodCache.CallMethod("IndexOf", obj, new object[]
				{
					obj4,
					num3,
					num4
				});
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, string.Format("invalid arguments to method: List<{0}>.IndexOf", LuaMisc.GetTypeName(type)));
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Insert(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type t = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out t);
			int num = (int)LuaDLL.luaL_checknumber(L, 2);
			object obj2 = ToLua.CheckVarObject(L, 3, t);
			LuaMethodCache.CallSingleMethod("Insert", obj, new object[]
			{
				num,
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
	private static int InsertRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			int num = (int)LuaDLL.luaL_checknumber(L, 2);
			IEnumerable enumerable = (IEnumerable)ToLua.CheckObject(L, 3, typeof(IEnumerable<>).MakeGenericType(new Type[]
			{
				type
			}));
			LuaMethodCache.CallSingleMethod("InsertRange", obj, new object[]
			{
				num,
				enumerable
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
	private static int LastIndexOf(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			if (num == 2 && TypeChecker.CheckTypes(L, 2, type))
			{
				object obj2 = ToLua.ToVarObject(L, 2, type);
				int n = (int)LuaMethodCache.CallMethod("LastIndexOf", obj, new object[]
				{
					obj2
				});
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 2, type, typeof(int)))
			{
				object obj3 = ToLua.ToVarObject(L, 2, type);
				int num2 = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = (int)LuaMethodCache.CallMethod("LastIndexOf", obj, new object[]
				{
					obj3,
					num2
				});
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 2, type, typeof(int), typeof(int)))
			{
				object obj4 = ToLua.ToVarObject(L, 2, type);
				int num3 = (int)LuaDLL.lua_tonumber(L, 3);
				int num4 = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = (int)LuaMethodCache.CallMethod("LastIndexOf", obj, new object[]
				{
					obj4,
					num3,
					num4
				});
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, string.Format("invalid arguments to method: List<{0}>.LastIndexOf", LuaMisc.GetTypeName(type)));
			}
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
			Type t = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out t);
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
	private static int RemoveAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Delegate @delegate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				@delegate = (Delegate)ToLua.CheckObject(L, 2, typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				@delegate = DelegateFactory.CreateDelegate(typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}), func);
			}
			int n = (int)LuaMethodCache.CallSingleMethod("RemoveAll", obj, new object[]
			{
				@delegate
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
	private static int RemoveAt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>));
			int num = (int)LuaDLL.luaL_checknumber(L, 2);
			LuaMethodCache.CallSingleMethod("RemoveAt", obj, new object[]
			{
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
	private static int RemoveRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>));
			int num = (int)LuaDLL.luaL_checknumber(L, 2);
			int num2 = (int)LuaDLL.luaL_checknumber(L, 3);
			LuaMethodCache.CallSingleMethod("RemoveRange", obj, new object[]
			{
				num,
				num2
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
	private static int Reverse(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			Type t = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out t);
			if (num == 1)
			{
				LuaMethodCache.CallMethod("Reverse", obj, new object[0]);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 2, typeof(int), typeof(int)))
			{
				int num2 = (int)LuaDLL.lua_tonumber(L, 2);
				int num3 = (int)LuaDLL.lua_tonumber(L, 3);
				LuaMethodCache.CallMethod("Reverse", obj, new object[]
				{
					num2,
					num3
				});
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, string.Format("invalid arguments to method: List<{0}>.LastIndexOf", LuaMisc.GetTypeName(t)));
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Sort(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			if (num == 1)
			{
				LuaMethodCache.CallMethod("Sort", obj, new object[0]);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 2, typeof(Comparison<>).MakeGenericType(new Type[]
			{
				type
			})))
			{
				Delegate @delegate = (Delegate)ToLua.ToObject(L, 2);
				LuaMethodCache.CallMethod("Sort", obj, new object[]
				{
					@delegate
				});
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 2, typeof(IComparer<>).MakeGenericType(new Type[]
			{
				type
			})))
			{
				object obj2 = ToLua.ToObject(L, 2);
				LuaMethodCache.CallMethod("Sort", obj, new object[]
				{
					obj2
				});
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 2, typeof(int), typeof(int), typeof(IComparer<>).MakeGenericType(new Type[]
			{
				type
			})))
			{
				int num2 = (int)LuaDLL.lua_tonumber(L, 2);
				int num3 = (int)LuaDLL.lua_tonumber(L, 3);
				object obj3 = ToLua.ToObject(L, 4);
				LuaMethodCache.CallMethod("Sort", obj, new object[]
				{
					num2,
					num3,
					obj3
				});
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, string.Format("invalid arguments to method: List<{0}>.LastIndexOf", LuaMisc.GetTypeName(type)));
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToArray(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>));
			Array array = (Array)LuaMethodCache.CallSingleMethod("ToArray", obj, new object[0]);
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TrimExcess(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>));
			LuaMethodCache.CallSingleMethod("TrimExcess", obj, new object[0]);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TrueForAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Delegate @delegate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				@delegate = (Delegate)ToLua.CheckObject(L, 2, typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				@delegate = DelegateFactory.CreateDelegate(typeof(Predicate<>).MakeGenericType(new Type[]
				{
					type
				}), func);
			}
			bool value = (bool)LuaMethodCache.CallSingleMethod("TrueForAll", obj, new object[]
			{
				@delegate
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
	private static int get_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>));
			int num = (int)LuaDLL.luaL_checknumber(L, 2);
			object obj2 = LuaMethodCache.CallSingleMethod("get_Item", obj, new object[]
			{
				num
			});
			ToLua.Push(L, obj2);
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
			Type type = null;
			object obj = ToLua.CheckGenericObject(L, 1, typeof(List<>), out type);
			int num = (int)LuaDLL.luaL_checknumber(L, 2);
			object obj2 = ToLua.CheckObject(L, 3, type);
			LuaMethodCache.CallSingleMethod("set_Item", obj, new object[]
			{
				num,
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
	private static int get_Capacity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int n = (int)LuaMethodCache.CallSingleMethod("get_Capacity", obj, new object[0]);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Capacity on a nil value");
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
	private static int set_Capacity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int num = (int)LuaDLL.luaL_checknumber(L, 2);
			LuaMethodCache.CallSingleMethod("set_Capacity", obj, new object[]
			{
				num
			});
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Capacity on a nil value");
		}
		return result;
	}
}
