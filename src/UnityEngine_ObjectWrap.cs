using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_ObjectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Object), typeof(object), null);
		L.RegFunction("Equals", new LuaCSFunction(UnityEngine_ObjectWrap.Equals));
		L.RegFunction("GetHashCode", new LuaCSFunction(UnityEngine_ObjectWrap.GetHashCode));
		L.RegFunction("GetInstanceID", new LuaCSFunction(UnityEngine_ObjectWrap.GetInstanceID));
		L.RegFunction("FindObjectsOfType", new LuaCSFunction(UnityEngine_ObjectWrap.FindObjectsOfType));
		L.RegFunction("FindObjectOfType", new LuaCSFunction(UnityEngine_ObjectWrap.FindObjectOfType));
		L.RegFunction("DontDestroyOnLoad", new LuaCSFunction(UnityEngine_ObjectWrap.DontDestroyOnLoad));
		L.RegFunction("ToString", new LuaCSFunction(UnityEngine_ObjectWrap.ToString));
		L.RegFunction("Instantiate", new LuaCSFunction(UnityEngine_ObjectWrap.Instantiate));
		L.RegFunction("DestroyImmediate", new LuaCSFunction(UnityEngine_ObjectWrap.DestroyImmediate));
		L.RegFunction("Destroy", new LuaCSFunction(UnityEngine_ObjectWrap.Destroy));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_ObjectWrap._CreateUnityEngine_Object));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_ObjectWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(UnityEngine_ObjectWrap.Lua_ToString));
		L.RegVar("name", new LuaCSFunction(UnityEngine_ObjectWrap.get_name), new LuaCSFunction(UnityEngine_ObjectWrap.set_name));
		L.RegVar("hideFlags", new LuaCSFunction(UnityEngine_ObjectWrap.get_hideFlags), new LuaCSFunction(UnityEngine_ObjectWrap.set_hideFlags));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Object(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				UnityEngine.Object obj = new UnityEngine.Object();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Object.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Equals(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object @object = (UnityEngine.Object)ToLua.CheckObject(L, 1, typeof(UnityEngine.Object));
			object obj = ToLua.ToVarObject(L, 2);
			bool value = (!(@object != null)) ? (obj == null) : @object.Equals(obj);
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
	private static int GetHashCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Object @object = (UnityEngine.Object)ToLua.CheckObject(L, 1, typeof(UnityEngine.Object));
			int hashCode = @object.GetHashCode();
			LuaDLL.lua_pushinteger(L, hashCode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInstanceID(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Object @object = (UnityEngine.Object)ToLua.CheckObject(L, 1, typeof(UnityEngine.Object));
			int instanceID = @object.GetInstanceID();
			LuaDLL.lua_pushinteger(L, instanceID);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindObjectsOfType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(type);
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
	private static int FindObjectOfType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			UnityEngine.Object obj = UnityEngine.Object.FindObjectOfType(type);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DontDestroyOnLoad(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Object target = ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Object));
			UnityEngine.Object.DontDestroyOnLoad(target);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Object @object = (UnityEngine.Object)ToLua.CheckObject(L, 1, typeof(UnityEngine.Object));
			string str = @object.ToString();
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int op_Equality(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object x = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object y = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool value = x == y;
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
	private static int Instantiate(IntPtr L)
	{
		int result;
		try
		{
			LuaException.InstantiateCount++;
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.Object)))
			{
				UnityEngine.Object original = (UnityEngine.Object)ToLua.ToObject(L, 1);
				UnityEngine.Object obj = UnityEngine.Object.Instantiate(original);
				if (LuaDLL.lua_toboolean(L, LuaDLL.lua_upvalueindex(1)))
				{
					string msg = LuaDLL.lua_tostring(L, -1);
					LuaDLL.lua_pop(L, 1);
					throw new LuaException(msg, LuaException.GetLastError(), 1);
				}
				ToLua.Push(L, obj);
				LuaException.InstantiateCount--;
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.Object), typeof(Vector3), typeof(Quaternion)))
			{
				UnityEngine.Object original2 = (UnityEngine.Object)ToLua.ToObject(L, 1);
				Vector3 position = ToLua.ToVector3(L, 2);
				Quaternion rotation = ToLua.ToQuaternion(L, 3);
				UnityEngine.Object obj2 = UnityEngine.Object.Instantiate(original2, position, rotation);
				if (LuaDLL.lua_toboolean(L, LuaDLL.lua_upvalueindex(1)))
				{
					string msg2 = LuaDLL.lua_tostring(L, -1);
					LuaDLL.lua_pop(L, 1);
					throw new LuaException(msg2, LuaException.GetLastError(), 1);
				}
				ToLua.Push(L, obj2);
				LuaException.InstantiateCount--;
				result = 1;
			}
			else
			{
				LuaException.InstantiateCount--;
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Object.Instantiate");
			}
		}
		catch (Exception e)
		{
			LuaException.InstantiateCount--;
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DestroyImmediate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				UnityEngine.Object obj = (UnityEngine.Object)ToLua.CheckObject(L, 1);
				ToLua.Destroy(L);
				UnityEngine.Object.DestroyImmediate(obj);
				result = 0;
			}
			else if (num == 2)
			{
				UnityEngine.Object obj2 = (UnityEngine.Object)ToLua.CheckObject(L, 1);
				bool allowDestroyingAssets = LuaDLL.luaL_checkboolean(L, 2);
				ToLua.Destroy(L);
				UnityEngine.Object.DestroyImmediate(obj2, allowDestroyingAssets);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Object.DestroyImmediate");
			}
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				UnityEngine.Object obj = (UnityEngine.Object)ToLua.CheckObject(L, 1);
				ToLua.Destroy(L);
				UnityEngine.Object.Destroy(obj);
				result = 0;
			}
			else if (num == 2)
			{
				float time = (float)LuaDLL.luaL_checknumber(L, 2);
				int id = LuaDLL.tolua_rawnetobj(L, 1);
				ObjectTranslator translator = LuaState.GetTranslator(L);
				translator.DelayDestroy(id, time);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Object.Destroy");
			}
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_name(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UnityEngine.Object @object = (UnityEngine.Object)obj;
			string name = @object.name;
			LuaDLL.lua_pushstring(L, name);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index name on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hideFlags(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UnityEngine.Object @object = (UnityEngine.Object)obj;
			HideFlags hideFlags = @object.hideFlags;
			ToLua.Push(L, hideFlags);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hideFlags on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_name(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UnityEngine.Object @object = (UnityEngine.Object)obj;
			string name = ToLua.CheckString(L, 2);
			@object.name = name;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index name on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hideFlags(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UnityEngine.Object @object = (UnityEngine.Object)obj;
			HideFlags hideFlags = (HideFlags)((int)ToLua.CheckObject(L, 2, typeof(HideFlags)));
			@object.hideFlags = hideFlags;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hideFlags on a nil value");
		}
		return result;
	}
}
