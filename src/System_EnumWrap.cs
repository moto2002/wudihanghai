using LuaInterface;
using System;

public class System_EnumWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Enum), null, null);
		L.RegFunction("GetTypeCode", new LuaCSFunction(System_EnumWrap.GetTypeCode));
		L.RegFunction("GetValues", new LuaCSFunction(System_EnumWrap.GetValues));
		L.RegFunction("GetNames", new LuaCSFunction(System_EnumWrap.GetNames));
		L.RegFunction("GetName", new LuaCSFunction(System_EnumWrap.GetName));
		L.RegFunction("IsDefined", new LuaCSFunction(System_EnumWrap.IsDefined));
		L.RegFunction("GetUnderlyingType", new LuaCSFunction(System_EnumWrap.GetUnderlyingType));
		L.RegFunction("CompareTo", new LuaCSFunction(System_EnumWrap.CompareTo));
		L.RegFunction("ToString", new LuaCSFunction(System_EnumWrap.ToString));
		L.RegFunction("Equals", new LuaCSFunction(System_EnumWrap.Equals));
		L.RegFunction("GetHashCode", new LuaCSFunction(System_EnumWrap.GetHashCode));
		L.RegFunction("Format", new LuaCSFunction(System_EnumWrap.Format));
		L.RegFunction("Parse", new LuaCSFunction(System_EnumWrap.Parse));
		L.RegFunction("ToObject", new LuaCSFunction(System_EnumWrap.ToObject));
		L.RegFunction("ToInt", new LuaCSFunction(System_EnumWrap.ToInt));
		L.RegFunction("__tostring", new LuaCSFunction(System_EnumWrap.Lua_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTypeCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Enum @enum = (Enum)ToLua.CheckObject(L, 1, typeof(Enum));
			TypeCode typeCode = @enum.GetTypeCode();
			ToLua.Push(L, typeCode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetValues(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type enumType = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Array values = Enum.GetValues(enumType);
			ToLua.Push(L, values);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNames(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type enumType = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			string[] names = Enum.GetNames(enumType);
			ToLua.Push(L, names);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type enumType = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			object value = ToLua.ToVarObject(L, 2);
			string name = Enum.GetName(enumType, value);
			LuaDLL.lua_pushstring(L, name);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsDefined(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type enumType = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			object value = ToLua.ToVarObject(L, 2);
			bool value2 = Enum.IsDefined(enumType, value);
			LuaDLL.lua_pushboolean(L, value2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetUnderlyingType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type enumType = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type underlyingType = Enum.GetUnderlyingType(enumType);
			ToLua.Push(L, underlyingType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CompareTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Enum @enum = (Enum)ToLua.CheckObject(L, 1, typeof(Enum));
			object target = ToLua.ToVarObject(L, 2);
			int n = @enum.CompareTo(target);
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
	private static int ToString(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Enum)))
			{
				Enum @enum = (Enum)ToLua.ToObject(L, 1);
				string str = @enum.ToString();
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Enum), typeof(string)))
			{
				Enum enum2 = (Enum)ToLua.ToObject(L, 1);
				string format = ToLua.ToString(L, 2);
				string str2 = enum2.ToString(format);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Enum.ToString");
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
			Enum @enum = (Enum)ToLua.CheckObject(L, 1, typeof(Enum));
			object obj = ToLua.ToVarObject(L, 2);
			bool value = (@enum == null) ? (obj == null) : @enum.Equals(obj);
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
			Enum @enum = (Enum)ToLua.CheckObject(L, 1, typeof(Enum));
			int hashCode = @enum.GetHashCode();
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
	private static int Format(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type enumType = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			object value = ToLua.ToVarObject(L, 2);
			string format = ToLua.CheckString(L, 3);
			string str = Enum.Format(enumType, value, format);
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
	private static int Parse(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string)))
			{
				Type enumType = (Type)ToLua.ToObject(L, 1);
				string value = ToLua.ToString(L, 2);
				object obj = Enum.Parse(enumType, value);
				ToLua.Push(L, (Enum)obj);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(bool)))
			{
				Type enumType2 = (Type)ToLua.ToObject(L, 1);
				string value2 = ToLua.ToString(L, 2);
				bool ignoreCase = LuaDLL.lua_toboolean(L, 3);
				object obj2 = Enum.Parse(enumType2, value2, ignoreCase);
				ToLua.Push(L, (Enum)obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Enum.Parse");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToObject(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(int)))
			{
				Type enumType = (Type)ToLua.ToObject(L, 1);
				int value = (int)LuaDLL.lua_tonumber(L, 2);
				object obj = Enum.ToObject(enumType, value);
				ToLua.Push(L, (Enum)obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(object)))
			{
				Type enumType2 = (Type)ToLua.ToObject(L, 1);
				object value2 = ToLua.ToVarObject(L, 2);
				object obj2 = Enum.ToObject(enumType2, value2);
				ToLua.Push(L, (Enum)obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Enum.ToObject");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToInt(IntPtr L)
	{
		int result;
		try
		{
			object value = ToLua.CheckObject(L, 1, typeof(Enum));
			int n = Convert.ToInt32(value);
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
