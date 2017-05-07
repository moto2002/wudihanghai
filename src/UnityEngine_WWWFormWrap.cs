using LuaInterface;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UnityEngine_WWWFormWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(WWWForm), typeof(object), null);
		L.RegFunction("AddField", new LuaCSFunction(UnityEngine_WWWFormWrap.AddField));
		L.RegFunction("AddBinaryData", new LuaCSFunction(UnityEngine_WWWFormWrap.AddBinaryData));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_WWWFormWrap._CreateUnityEngine_WWWForm));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("headers", new LuaCSFunction(UnityEngine_WWWFormWrap.get_headers), null);
		L.RegVar("data", new LuaCSFunction(UnityEngine_WWWFormWrap.get_data), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_WWWForm(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				WWWForm o = new WWWForm();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.WWWForm.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddField(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(WWWForm), typeof(string), typeof(int)))
			{
				WWWForm wWWForm = (WWWForm)ToLua.ToObject(L, 1);
				string fieldName = ToLua.ToString(L, 2);
				int i = (int)LuaDLL.lua_tonumber(L, 3);
				wWWForm.AddField(fieldName, i);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(WWWForm), typeof(string), typeof(string)))
			{
				WWWForm wWWForm2 = (WWWForm)ToLua.ToObject(L, 1);
				string fieldName2 = ToLua.ToString(L, 2);
				string value = ToLua.ToString(L, 3);
				wWWForm2.AddField(fieldName2, value);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(WWWForm), typeof(string), typeof(string), typeof(Encoding)))
			{
				WWWForm wWWForm3 = (WWWForm)ToLua.ToObject(L, 1);
				string fieldName3 = ToLua.ToString(L, 2);
				string value2 = ToLua.ToString(L, 3);
				Encoding e = (Encoding)ToLua.ToObject(L, 4);
				wWWForm3.AddField(fieldName3, value2, e);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.WWWForm.AddField");
			}
		}
		catch (Exception e2)
		{
			result = LuaDLL.toluaL_exception(L, e2, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddBinaryData(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(WWWForm), typeof(string), typeof(byte[])))
			{
				WWWForm wWWForm = (WWWForm)ToLua.ToObject(L, 1);
				string fieldName = ToLua.ToString(L, 2);
				byte[] contents = ToLua.CheckByteBuffer(L, 3);
				wWWForm.AddBinaryData(fieldName, contents);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(WWWForm), typeof(string), typeof(byte[]), typeof(string)))
			{
				WWWForm wWWForm2 = (WWWForm)ToLua.ToObject(L, 1);
				string fieldName2 = ToLua.ToString(L, 2);
				byte[] contents2 = ToLua.CheckByteBuffer(L, 3);
				string fileName = ToLua.ToString(L, 4);
				wWWForm2.AddBinaryData(fieldName2, contents2, fileName);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(WWWForm), typeof(string), typeof(byte[]), typeof(string), typeof(string)))
			{
				WWWForm wWWForm3 = (WWWForm)ToLua.ToObject(L, 1);
				string fieldName3 = ToLua.ToString(L, 2);
				byte[] contents3 = ToLua.CheckByteBuffer(L, 3);
				string fileName2 = ToLua.ToString(L, 4);
				string mimeType = ToLua.ToString(L, 5);
				wWWForm3.AddBinaryData(fieldName3, contents3, fileName2, mimeType);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.WWWForm.AddBinaryData");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_headers(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWWForm wWWForm = (WWWForm)obj;
			Dictionary<string, string> headers = wWWForm.headers;
			ToLua.PushObject(L, headers);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index headers on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_data(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWWForm wWWForm = (WWWForm)obj;
			byte[] data = wWWForm.data;
			ToLua.Push(L, data);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index data on a nil value");
		}
		return result;
	}
}
