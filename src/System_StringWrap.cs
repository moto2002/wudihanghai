using LuaInterface;
using System;
using System.Globalization;
using System.Text;

public class System_StringWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(string), typeof(object), null);
		L.RegFunction("Equals", new LuaCSFunction(System_StringWrap.Equals));
		L.RegFunction("Clone", new LuaCSFunction(System_StringWrap.Clone));
		L.RegFunction("GetTypeCode", new LuaCSFunction(System_StringWrap.GetTypeCode));
		L.RegFunction("CopyTo", new LuaCSFunction(System_StringWrap.CopyTo));
		L.RegFunction("ToCharArray", new LuaCSFunction(System_StringWrap.ToCharArray));
		L.RegFunction("Split", new LuaCSFunction(System_StringWrap.Split));
		L.RegFunction("Substring", new LuaCSFunction(System_StringWrap.Substring));
		L.RegFunction("Trim", new LuaCSFunction(System_StringWrap.Trim));
		L.RegFunction("TrimStart", new LuaCSFunction(System_StringWrap.TrimStart));
		L.RegFunction("TrimEnd", new LuaCSFunction(System_StringWrap.TrimEnd));
		L.RegFunction("Compare", new LuaCSFunction(System_StringWrap.Compare));
		L.RegFunction("CompareTo", new LuaCSFunction(System_StringWrap.CompareTo));
		L.RegFunction("CompareOrdinal", new LuaCSFunction(System_StringWrap.CompareOrdinal));
		L.RegFunction("EndsWith", new LuaCSFunction(System_StringWrap.EndsWith));
		L.RegFunction("IndexOfAny", new LuaCSFunction(System_StringWrap.IndexOfAny));
		L.RegFunction("IndexOf", new LuaCSFunction(System_StringWrap.IndexOf));
		L.RegFunction("LastIndexOf", new LuaCSFunction(System_StringWrap.LastIndexOf));
		L.RegFunction("LastIndexOfAny", new LuaCSFunction(System_StringWrap.LastIndexOfAny));
		L.RegFunction("Contains", new LuaCSFunction(System_StringWrap.Contains));
		L.RegFunction("IsNullOrEmpty", new LuaCSFunction(System_StringWrap.IsNullOrEmpty));
		L.RegFunction("Normalize", new LuaCSFunction(System_StringWrap.Normalize));
		L.RegFunction("IsNormalized", new LuaCSFunction(System_StringWrap.IsNormalized));
		L.RegFunction("Remove", new LuaCSFunction(System_StringWrap.Remove));
		L.RegFunction("PadLeft", new LuaCSFunction(System_StringWrap.PadLeft));
		L.RegFunction("PadRight", new LuaCSFunction(System_StringWrap.PadRight));
		L.RegFunction("StartsWith", new LuaCSFunction(System_StringWrap.StartsWith));
		L.RegFunction("Replace", new LuaCSFunction(System_StringWrap.Replace));
		L.RegFunction("ToLower", new LuaCSFunction(System_StringWrap.ToLower));
		L.RegFunction("ToLowerInvariant", new LuaCSFunction(System_StringWrap.ToLowerInvariant));
		L.RegFunction("ToUpper", new LuaCSFunction(System_StringWrap.ToUpper));
		L.RegFunction("ToUpperInvariant", new LuaCSFunction(System_StringWrap.ToUpperInvariant));
		L.RegFunction("ToString", new LuaCSFunction(System_StringWrap.ToString));
		L.RegFunction("Format", new LuaCSFunction(System_StringWrap.Format));
		L.RegFunction("Copy", new LuaCSFunction(System_StringWrap.Copy));
		L.RegFunction("Concat", new LuaCSFunction(System_StringWrap.Concat));
		L.RegFunction("Insert", new LuaCSFunction(System_StringWrap.Insert));
		L.RegFunction("Intern", new LuaCSFunction(System_StringWrap.Intern));
		L.RegFunction("IsInterned", new LuaCSFunction(System_StringWrap.IsInterned));
		L.RegFunction("Join", new LuaCSFunction(System_StringWrap.Join));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_StringWrap.GetEnumerator));
		L.RegFunction("GetHashCode", new LuaCSFunction(System_StringWrap.GetHashCode));
		L.RegFunction("New", new LuaCSFunction(System_StringWrap._CreateSystem_String));
		L.RegFunction("__eq", new LuaCSFunction(System_StringWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(System_StringWrap.Lua_ToString));
		L.RegVar("Empty", new LuaCSFunction(System_StringWrap.get_Empty), null);
		L.RegVar("Length", new LuaCSFunction(System_StringWrap.get_Length), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_String(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TSTRING)
			{
				string o = LuaDLL.lua_tostring(L, 1);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to string's ctor method");
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				string text2 = ToLua.ToString(L, 2);
				bool value = (text == null) ? (text2 == null) : text.Equals(text2);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(object)))
			{
				string text3 = (string)ToLua.ToObject(L, 1);
				object obj = ToLua.ToVarObject(L, 2);
				bool value2 = (text3 == null) ? (obj == null) : text3.Equals(obj);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(StringComparison)))
			{
				string text4 = (string)ToLua.ToObject(L, 1);
				string text5 = ToLua.ToString(L, 2);
				StringComparison comparisonType = (StringComparison)((int)ToLua.ToObject(L, 3));
				bool value3 = (text4 == null) ? (text5 == null) : text4.Equals(text5, comparisonType);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Equals");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clone(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			object obj = text.Clone();
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
	private static int GetTypeCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			TypeCode typeCode = text.GetTypeCode();
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
	private static int CopyTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			int sourceIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			char[] destination = ToLua.CheckCharBuffer(L, 3);
			int destinationIndex = (int)LuaDLL.luaL_checknumber(L, 4);
			int count = (int)LuaDLL.luaL_checknumber(L, 5);
			text.CopyTo(sourceIndex, destination, destinationIndex, count);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToCharArray(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				char[] array = text.ToCharArray();
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(int)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				int length = (int)LuaDLL.lua_tonumber(L, 3);
				char[] array2 = text2.ToCharArray(startIndex, length);
				ToLua.Push(L, array2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.ToCharArray");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Split(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char[]), typeof(StringSplitOptions)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				char[] separator = ToLua.CheckCharBuffer(L, 2);
				StringSplitOptions options = (StringSplitOptions)((int)ToLua.ToObject(L, 3));
				string[] array = text.Split(separator, options);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char[]), typeof(int)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				char[] separator2 = ToLua.CheckCharBuffer(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				string[] array2 = text2.Split(separator2, count);
				ToLua.Push(L, array2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string[]), typeof(StringSplitOptions)))
			{
				string text3 = (string)ToLua.ToObject(L, 1);
				string[] separator3 = ToLua.CheckStringArray(L, 2);
				StringSplitOptions options2 = (StringSplitOptions)((int)ToLua.ToObject(L, 3));
				string[] array3 = text3.Split(separator3, options2);
				ToLua.Push(L, array3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string[]), typeof(int), typeof(StringSplitOptions)))
			{
				string text4 = (string)ToLua.ToObject(L, 1);
				string[] separator4 = ToLua.CheckStringArray(L, 2);
				int count2 = (int)LuaDLL.lua_tonumber(L, 3);
				StringSplitOptions options3 = (StringSplitOptions)((int)ToLua.ToObject(L, 4));
				string[] array4 = text4.Split(separator4, count2, options3);
				ToLua.Push(L, array4);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char[]), typeof(int), typeof(StringSplitOptions)))
			{
				string text5 = (string)ToLua.ToObject(L, 1);
				char[] separator5 = ToLua.CheckCharBuffer(L, 2);
				int count3 = (int)LuaDLL.lua_tonumber(L, 3);
				StringSplitOptions options4 = (StringSplitOptions)((int)ToLua.ToObject(L, 4));
				string[] array5 = text5.Split(separator5, count3, options4);
				ToLua.Push(L, array5);
				result = 1;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(char), 2, num - 1))
			{
				string text6 = (string)ToLua.ToObject(L, 1);
				char[] separator6 = ToLua.ToParamsChar(L, 2, num - 1);
				string[] array6 = text6.Split(separator6);
				ToLua.Push(L, array6);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Split");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Substring(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				string str = text.Substring(startIndex);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(int)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int length = (int)LuaDLL.lua_tonumber(L, 3);
				string str2 = text2.Substring(startIndex2, length);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Substring");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Trim(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				string str = text.Trim();
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(char), 2, num - 1))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				char[] trimChars = ToLua.ToParamsChar(L, 2, num - 1);
				string str2 = text2.Trim(trimChars);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Trim");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TrimStart(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			char[] trimChars = ToLua.CheckParamsChar(L, 2, num - 1);
			string str = text.TrimStart(trimChars);
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
	private static int TrimEnd(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			char[] trimChars = ToLua.CheckParamsChar(L, 2, num - 1);
			string str = text.TrimEnd(trimChars);
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
	private static int Compare(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string strA = ToLua.ToString(L, 1);
				string strB = ToLua.ToString(L, 2);
				int n = string.Compare(strA, strB);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(StringComparison)))
			{
				string strA2 = ToLua.ToString(L, 1);
				string strB2 = ToLua.ToString(L, 2);
				StringComparison comparisonType = (StringComparison)((int)ToLua.ToObject(L, 3));
				int n2 = string.Compare(strA2, strB2, comparisonType);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(bool)))
			{
				string strA3 = ToLua.ToString(L, 1);
				string strB3 = ToLua.ToString(L, 2);
				bool ignoreCase = LuaDLL.lua_toboolean(L, 3);
				int n3 = string.Compare(strA3, strB3, ignoreCase);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(CultureInfo), typeof(CompareOptions)))
			{
				string strA4 = ToLua.ToString(L, 1);
				string strB4 = ToLua.ToString(L, 2);
				CultureInfo culture = (CultureInfo)ToLua.ToObject(L, 3);
				CompareOptions options = (CompareOptions)((int)ToLua.ToObject(L, 4));
				int n4 = string.Compare(strA4, strB4, culture, options);
				LuaDLL.lua_pushinteger(L, n4);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(bool), typeof(CultureInfo)))
			{
				string strA5 = ToLua.ToString(L, 1);
				string strB5 = ToLua.ToString(L, 2);
				bool ignoreCase2 = LuaDLL.lua_toboolean(L, 3);
				CultureInfo culture2 = (CultureInfo)ToLua.ToObject(L, 4);
				int n5 = string.Compare(strA5, strB5, ignoreCase2, culture2);
				LuaDLL.lua_pushinteger(L, n5);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(string), typeof(int), typeof(int)))
			{
				string strA6 = ToLua.ToString(L, 1);
				int indexA = (int)LuaDLL.lua_tonumber(L, 2);
				string strB6 = ToLua.ToString(L, 3);
				int indexB = (int)LuaDLL.lua_tonumber(L, 4);
				int length = (int)LuaDLL.lua_tonumber(L, 5);
				int n6 = string.Compare(strA6, indexA, strB6, indexB, length);
				LuaDLL.lua_pushinteger(L, n6);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(StringComparison)))
			{
				string strA7 = ToLua.ToString(L, 1);
				int indexA2 = (int)LuaDLL.lua_tonumber(L, 2);
				string strB7 = ToLua.ToString(L, 3);
				int indexB2 = (int)LuaDLL.lua_tonumber(L, 4);
				int length2 = (int)LuaDLL.lua_tonumber(L, 5);
				StringComparison comparisonType2 = (StringComparison)((int)ToLua.ToObject(L, 6));
				int n7 = string.Compare(strA7, indexA2, strB7, indexB2, length2, comparisonType2);
				LuaDLL.lua_pushinteger(L, n7);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(bool)))
			{
				string strA8 = ToLua.ToString(L, 1);
				int indexA3 = (int)LuaDLL.lua_tonumber(L, 2);
				string strB8 = ToLua.ToString(L, 3);
				int indexB3 = (int)LuaDLL.lua_tonumber(L, 4);
				int length3 = (int)LuaDLL.lua_tonumber(L, 5);
				bool ignoreCase3 = LuaDLL.lua_toboolean(L, 6);
				int n8 = string.Compare(strA8, indexA3, strB8, indexB3, length3, ignoreCase3);
				LuaDLL.lua_pushinteger(L, n8);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(CultureInfo), typeof(CompareOptions)))
			{
				string strA9 = ToLua.ToString(L, 1);
				int indexA4 = (int)LuaDLL.lua_tonumber(L, 2);
				string strB9 = ToLua.ToString(L, 3);
				int indexB4 = (int)LuaDLL.lua_tonumber(L, 4);
				int length4 = (int)LuaDLL.lua_tonumber(L, 5);
				CultureInfo culture3 = (CultureInfo)ToLua.ToObject(L, 6);
				CompareOptions options2 = (CompareOptions)((int)ToLua.ToObject(L, 7));
				int n9 = string.Compare(strA9, indexA4, strB9, indexB4, length4, culture3, options2);
				LuaDLL.lua_pushinteger(L, n9);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(bool), typeof(CultureInfo)))
			{
				string strA10 = ToLua.ToString(L, 1);
				int indexA5 = (int)LuaDLL.lua_tonumber(L, 2);
				string strB10 = ToLua.ToString(L, 3);
				int indexB5 = (int)LuaDLL.lua_tonumber(L, 4);
				int length5 = (int)LuaDLL.lua_tonumber(L, 5);
				bool ignoreCase4 = LuaDLL.lua_toboolean(L, 6);
				CultureInfo culture4 = (CultureInfo)ToLua.ToObject(L, 7);
				int n10 = string.Compare(strA10, indexA5, strB10, indexB5, length5, ignoreCase4, culture4);
				LuaDLL.lua_pushinteger(L, n10);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Compare");
			}
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				string strB = ToLua.ToString(L, 2);
				int n = text.CompareTo(strB);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(object)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				object value = ToLua.ToVarObject(L, 2);
				int n2 = text2.CompareTo(value);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.CompareTo");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CompareOrdinal(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string strA = ToLua.ToString(L, 1);
				string strB = ToLua.ToString(L, 2);
				int n = string.CompareOrdinal(strA, strB);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(string), typeof(int), typeof(int)))
			{
				string strA2 = ToLua.ToString(L, 1);
				int indexA = (int)LuaDLL.lua_tonumber(L, 2);
				string strB2 = ToLua.ToString(L, 3);
				int indexB = (int)LuaDLL.lua_tonumber(L, 4);
				int length = (int)LuaDLL.lua_tonumber(L, 5);
				int n2 = string.CompareOrdinal(strA2, indexA, strB2, indexB, length);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.CompareOrdinal");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EndsWith(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				string value = ToLua.ToString(L, 2);
				bool value2 = text.EndsWith(value);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(StringComparison)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				string value3 = ToLua.ToString(L, 2);
				StringComparison comparisonType = (StringComparison)((int)ToLua.ToObject(L, 3));
				bool value4 = text2.EndsWith(value3, comparisonType);
				LuaDLL.lua_pushboolean(L, value4);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(bool), typeof(CultureInfo)))
			{
				string text3 = (string)ToLua.ToObject(L, 1);
				string value5 = ToLua.ToString(L, 2);
				bool ignoreCase = LuaDLL.lua_toboolean(L, 3);
				CultureInfo culture = (CultureInfo)ToLua.ToObject(L, 4);
				bool value6 = text3.EndsWith(value5, ignoreCase, culture);
				LuaDLL.lua_pushboolean(L, value6);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.EndsWith");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IndexOfAny(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char[])))
			{
				string text = (string)ToLua.ToObject(L, 1);
				char[] anyOf = ToLua.CheckCharBuffer(L, 2);
				int n = text.IndexOfAny(anyOf);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char[]), typeof(int)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				char[] anyOf2 = ToLua.CheckCharBuffer(L, 2);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = text2.IndexOfAny(anyOf2, startIndex);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char[]), typeof(int), typeof(int)))
			{
				string text3 = (string)ToLua.ToObject(L, 1);
				char[] anyOf3 = ToLua.CheckCharBuffer(L, 2);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = text3.IndexOfAny(anyOf3, startIndex2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.IndexOfAny");
			}
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				char value = (char)LuaDLL.lua_tonumber(L, 2);
				int n = text.IndexOf(value);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				string value2 = ToLua.ToString(L, 2);
				int n2 = text2.IndexOf(value2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(int)))
			{
				string text3 = (string)ToLua.ToObject(L, 1);
				string value3 = ToLua.ToString(L, 2);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 3);
				int n3 = text3.IndexOf(value3, startIndex);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char), typeof(int)))
			{
				string text4 = (string)ToLua.ToObject(L, 1);
				char value4 = (char)LuaDLL.lua_tonumber(L, 2);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 3);
				int n4 = text4.IndexOf(value4, startIndex2);
				LuaDLL.lua_pushinteger(L, n4);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(StringComparison)))
			{
				string text5 = (string)ToLua.ToObject(L, 1);
				string value5 = ToLua.ToString(L, 2);
				StringComparison comparisonType = (StringComparison)((int)ToLua.ToObject(L, 3));
				int n5 = text5.IndexOf(value5, comparisonType);
				LuaDLL.lua_pushinteger(L, n5);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(int), typeof(int)))
			{
				string text6 = (string)ToLua.ToObject(L, 1);
				string value6 = ToLua.ToString(L, 2);
				int startIndex3 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n6 = text6.IndexOf(value6, startIndex3, count);
				LuaDLL.lua_pushinteger(L, n6);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(int), typeof(StringComparison)))
			{
				string text7 = (string)ToLua.ToObject(L, 1);
				string value7 = ToLua.ToString(L, 2);
				int startIndex4 = (int)LuaDLL.lua_tonumber(L, 3);
				StringComparison comparisonType2 = (StringComparison)((int)ToLua.ToObject(L, 4));
				int n7 = text7.IndexOf(value7, startIndex4, comparisonType2);
				LuaDLL.lua_pushinteger(L, n7);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char), typeof(int), typeof(int)))
			{
				string text8 = (string)ToLua.ToObject(L, 1);
				char value8 = (char)LuaDLL.lua_tonumber(L, 2);
				int startIndex5 = (int)LuaDLL.lua_tonumber(L, 3);
				int count2 = (int)LuaDLL.lua_tonumber(L, 4);
				int n8 = text8.IndexOf(value8, startIndex5, count2);
				LuaDLL.lua_pushinteger(L, n8);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(int), typeof(int), typeof(StringComparison)))
			{
				string text9 = (string)ToLua.ToObject(L, 1);
				string value9 = ToLua.ToString(L, 2);
				int startIndex6 = (int)LuaDLL.lua_tonumber(L, 3);
				int count3 = (int)LuaDLL.lua_tonumber(L, 4);
				StringComparison comparisonType3 = (StringComparison)((int)ToLua.ToObject(L, 5));
				int n9 = text9.IndexOf(value9, startIndex6, count3, comparisonType3);
				LuaDLL.lua_pushinteger(L, n9);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.IndexOf");
			}
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				char value = (char)LuaDLL.lua_tonumber(L, 2);
				int n = text.LastIndexOf(value);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				string value2 = ToLua.ToString(L, 2);
				int n2 = text2.LastIndexOf(value2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(int)))
			{
				string text3 = (string)ToLua.ToObject(L, 1);
				string value3 = ToLua.ToString(L, 2);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 3);
				int n3 = text3.LastIndexOf(value3, startIndex);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char), typeof(int)))
			{
				string text4 = (string)ToLua.ToObject(L, 1);
				char value4 = (char)LuaDLL.lua_tonumber(L, 2);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 3);
				int n4 = text4.LastIndexOf(value4, startIndex2);
				LuaDLL.lua_pushinteger(L, n4);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(StringComparison)))
			{
				string text5 = (string)ToLua.ToObject(L, 1);
				string value5 = ToLua.ToString(L, 2);
				StringComparison comparisonType = (StringComparison)((int)ToLua.ToObject(L, 3));
				int n5 = text5.LastIndexOf(value5, comparisonType);
				LuaDLL.lua_pushinteger(L, n5);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(int), typeof(int)))
			{
				string text6 = (string)ToLua.ToObject(L, 1);
				string value6 = ToLua.ToString(L, 2);
				int startIndex3 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n6 = text6.LastIndexOf(value6, startIndex3, count);
				LuaDLL.lua_pushinteger(L, n6);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(int), typeof(StringComparison)))
			{
				string text7 = (string)ToLua.ToObject(L, 1);
				string value7 = ToLua.ToString(L, 2);
				int startIndex4 = (int)LuaDLL.lua_tonumber(L, 3);
				StringComparison comparisonType2 = (StringComparison)((int)ToLua.ToObject(L, 4));
				int n7 = text7.LastIndexOf(value7, startIndex4, comparisonType2);
				LuaDLL.lua_pushinteger(L, n7);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char), typeof(int), typeof(int)))
			{
				string text8 = (string)ToLua.ToObject(L, 1);
				char value8 = (char)LuaDLL.lua_tonumber(L, 2);
				int startIndex5 = (int)LuaDLL.lua_tonumber(L, 3);
				int count2 = (int)LuaDLL.lua_tonumber(L, 4);
				int n8 = text8.LastIndexOf(value8, startIndex5, count2);
				LuaDLL.lua_pushinteger(L, n8);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(int), typeof(int), typeof(StringComparison)))
			{
				string text9 = (string)ToLua.ToObject(L, 1);
				string value9 = ToLua.ToString(L, 2);
				int startIndex6 = (int)LuaDLL.lua_tonumber(L, 3);
				int count3 = (int)LuaDLL.lua_tonumber(L, 4);
				StringComparison comparisonType3 = (StringComparison)((int)ToLua.ToObject(L, 5));
				int n9 = text9.LastIndexOf(value9, startIndex6, count3, comparisonType3);
				LuaDLL.lua_pushinteger(L, n9);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.LastIndexOf");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LastIndexOfAny(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char[])))
			{
				string text = (string)ToLua.ToObject(L, 1);
				char[] anyOf = ToLua.CheckCharBuffer(L, 2);
				int n = text.LastIndexOfAny(anyOf);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char[]), typeof(int)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				char[] anyOf2 = ToLua.CheckCharBuffer(L, 2);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = text2.LastIndexOfAny(anyOf2, startIndex);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char[]), typeof(int), typeof(int)))
			{
				string text3 = (string)ToLua.ToObject(L, 1);
				char[] anyOf3 = ToLua.CheckCharBuffer(L, 2);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = text3.LastIndexOfAny(anyOf3, startIndex2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.LastIndexOfAny");
			}
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
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			string value = ToLua.CheckString(L, 2);
			bool value2 = text.Contains(value);
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
	private static int IsNullOrEmpty(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string value = ToLua.CheckString(L, 1);
			bool value2 = string.IsNullOrEmpty(value);
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
	private static int Normalize(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				string str = text.Normalize();
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(NormalizationForm)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				NormalizationForm normalizationForm = (NormalizationForm)((int)ToLua.ToObject(L, 2));
				string str2 = text2.Normalize(normalizationForm);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Normalize");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsNormalized(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				bool value = text.IsNormalized();
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(NormalizationForm)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				NormalizationForm normalizationForm = (NormalizationForm)((int)ToLua.ToObject(L, 2));
				bool value2 = text2.IsNormalized(normalizationForm);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.IsNormalized");
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				string str = text.Remove(startIndex);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(int)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				string str2 = text2.Remove(startIndex2, count);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Remove");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PadLeft(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				int totalWidth = (int)LuaDLL.lua_tonumber(L, 2);
				string str = text.PadLeft(totalWidth);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(char)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				int totalWidth2 = (int)LuaDLL.lua_tonumber(L, 2);
				char paddingChar = (char)LuaDLL.lua_tonumber(L, 3);
				string str2 = text2.PadLeft(totalWidth2, paddingChar);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.PadLeft");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PadRight(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				int totalWidth = (int)LuaDLL.lua_tonumber(L, 2);
				string str = text.PadRight(totalWidth);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(char)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				int totalWidth2 = (int)LuaDLL.lua_tonumber(L, 2);
				char paddingChar = (char)LuaDLL.lua_tonumber(L, 3);
				string str2 = text2.PadRight(totalWidth2, paddingChar);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.PadRight");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartsWith(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				string value = ToLua.ToString(L, 2);
				bool value2 = text.StartsWith(value);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(StringComparison)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				string value3 = ToLua.ToString(L, 2);
				StringComparison comparisonType = (StringComparison)((int)ToLua.ToObject(L, 3));
				bool value4 = text2.StartsWith(value3, comparisonType);
				LuaDLL.lua_pushboolean(L, value4);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(bool), typeof(CultureInfo)))
			{
				string text3 = (string)ToLua.ToObject(L, 1);
				string value5 = ToLua.ToString(L, 2);
				bool ignoreCase = LuaDLL.lua_toboolean(L, 3);
				CultureInfo culture = (CultureInfo)ToLua.ToObject(L, 4);
				bool value6 = text3.StartsWith(value5, ignoreCase, culture);
				LuaDLL.lua_pushboolean(L, value6);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.StartsWith");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Replace(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				string oldValue = ToLua.ToString(L, 2);
				string newValue = ToLua.ToString(L, 3);
				string str = text.Replace(oldValue, newValue);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(char), typeof(char)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				char oldChar = (char)LuaDLL.lua_tonumber(L, 2);
				char newChar = (char)LuaDLL.lua_tonumber(L, 3);
				string str2 = text2.Replace(oldChar, newChar);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Replace");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToLower(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				string str = text.ToLower();
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(CultureInfo)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				CultureInfo culture = (CultureInfo)ToLua.ToObject(L, 2);
				string str2 = text2.ToLower(culture);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.ToLower");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToLowerInvariant(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			string str = text.ToLowerInvariant();
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
	private static int ToUpper(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				string str = text.ToUpper();
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(CultureInfo)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				CultureInfo culture = (CultureInfo)ToLua.ToObject(L, 2);
				string str2 = text2.ToUpper(culture);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.ToUpper");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToUpperInvariant(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			string str = text.ToUpperInvariant();
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
	private static int ToString(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string text = (string)ToLua.ToObject(L, 1);
				string str = text.ToString();
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(IFormatProvider)))
			{
				string text2 = (string)ToLua.ToObject(L, 1);
				IFormatProvider provider = (IFormatProvider)ToLua.ToObject(L, 2);
				string str2 = text2.ToString(provider);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.ToString");
			}
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(object)))
			{
				string format = ToLua.ToString(L, 1);
				object arg = ToLua.ToVarObject(L, 2);
				string str = string.Format(format, arg);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(object), typeof(object)))
			{
				string format2 = ToLua.ToString(L, 1);
				object arg2 = ToLua.ToVarObject(L, 2);
				object arg3 = ToLua.ToVarObject(L, 3);
				string str2 = string.Format(format2, arg2, arg3);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(object), typeof(object), typeof(object)))
			{
				string format3 = ToLua.ToString(L, 1);
				object arg4 = ToLua.ToVarObject(L, 2);
				object arg5 = ToLua.ToVarObject(L, 3);
				object arg6 = ToLua.ToVarObject(L, 4);
				string str3 = string.Format(format3, arg4, arg5, arg6);
				LuaDLL.lua_pushstring(L, str3);
				result = 1;
			}
			else if (TypeChecker.CheckTypes(L, 1, typeof(IFormatProvider), typeof(string)) && TypeChecker.CheckParamsType(L, typeof(object), 3, num - 2))
			{
				IFormatProvider provider = (IFormatProvider)ToLua.ToObject(L, 1);
				string format4 = ToLua.ToString(L, 2);
				object[] args = ToLua.ToParamsObject(L, 3, num - 2);
				string str4 = string.Format(provider, format4, args);
				LuaDLL.lua_pushstring(L, str4);
				result = 1;
			}
			else if (TypeChecker.CheckTypes(L, 1, typeof(string)) && TypeChecker.CheckParamsType(L, typeof(object), 2, num - 1))
			{
				string format5 = ToLua.ToString(L, 1);
				object[] args2 = ToLua.ToParamsObject(L, 2, num - 1);
				string str5 = string.Format(format5, args2);
				LuaDLL.lua_pushstring(L, str5);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Format");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Copy(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			string str2 = string.Copy(str);
			LuaDLL.lua_pushstring(L, str2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Concat(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(object)))
			{
				object arg = ToLua.ToVarObject(L, 1);
				string str = string.Concat(arg);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string str2 = ToLua.ToString(L, 1);
				string str3 = ToLua.ToString(L, 2);
				string str4 = str2 + str3;
				LuaDLL.lua_pushstring(L, str4);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(object), typeof(object)))
			{
				object arg2 = ToLua.ToVarObject(L, 1);
				object arg3 = ToLua.ToVarObject(L, 2);
				string str5 = arg2 + arg3;
				LuaDLL.lua_pushstring(L, str5);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(string)))
			{
				string str6 = ToLua.ToString(L, 1);
				string str7 = ToLua.ToString(L, 2);
				string str8 = ToLua.ToString(L, 3);
				string str9 = str6 + str7 + str8;
				LuaDLL.lua_pushstring(L, str9);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(object), typeof(object), typeof(object)))
			{
				object arg4 = ToLua.ToVarObject(L, 1);
				object arg5 = ToLua.ToVarObject(L, 2);
				object arg6 = ToLua.ToVarObject(L, 3);
				string str10 = arg4 + arg5 + arg6;
				LuaDLL.lua_pushstring(L, str10);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(string), typeof(string)))
			{
				string str11 = ToLua.ToString(L, 1);
				string str12 = ToLua.ToString(L, 2);
				string str13 = ToLua.ToString(L, 3);
				string str14 = ToLua.ToString(L, 4);
				string str15 = str11 + str12 + str13 + str14;
				LuaDLL.lua_pushstring(L, str15);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(object), typeof(object), typeof(object), typeof(object)))
			{
				object obj = ToLua.ToVarObject(L, 1);
				object obj2 = ToLua.ToVarObject(L, 2);
				object obj3 = ToLua.ToVarObject(L, 3);
				object obj4 = ToLua.ToVarObject(L, 4);
				string str16 = string.Concat(new object[]
				{
					obj,
					obj2,
					obj3,
					obj4
				});
				LuaDLL.lua_pushstring(L, str16);
				result = 1;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(string), 1, num))
			{
				string[] values = ToLua.ToParamsString(L, 1, num);
				string str17 = string.Concat(values);
				LuaDLL.lua_pushstring(L, str17);
				result = 1;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(object), 1, num))
			{
				object[] args = ToLua.ToParamsObject(L, 1, num);
				string str18 = string.Concat(args);
				LuaDLL.lua_pushstring(L, str18);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Concat");
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
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			int startIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			string value = ToLua.CheckString(L, 3);
			string str = text.Insert(startIndex, value);
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
	private static int Intern(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			string str2 = string.Intern(str);
			LuaDLL.lua_pushstring(L, str2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsInterned(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			string str2 = string.IsInterned(str);
			LuaDLL.lua_pushstring(L, str2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Join(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string[])))
			{
				string separator = ToLua.ToString(L, 1);
				string[] value = ToLua.CheckStringArray(L, 2);
				string str = string.Join(separator, value);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string[]), typeof(int), typeof(int)))
			{
				string separator2 = ToLua.ToString(L, 1);
				string[] value2 = ToLua.CheckStringArray(L, 2);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				string str2 = string.Join(separator2, value2, startIndex, count);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.String.Join");
			}
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
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			CharEnumerator enumerator = text.GetEnumerator();
			ToLua.Push(L, enumerator);
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
			string text = (string)ToLua.CheckObject(L, 1, typeof(string));
			int hashCode = text.GetHashCode();
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
	private static int op_Equality(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string a = ToLua.ToString(L, 1);
			string b = ToLua.ToString(L, 2);
			bool value = a == b;
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
	private static int get_Empty(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, string.Empty);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Length(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			string text = (string)obj;
			int length = text.Length;
			LuaDLL.lua_pushinteger(L, length);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Length on a nil value");
		}
		return result;
	}
}
