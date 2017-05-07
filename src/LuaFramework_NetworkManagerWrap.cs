using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_NetworkManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(NetworkManager), typeof(Manager), null);
		L.RegFunction("OnInit", new LuaCSFunction(LuaFramework_NetworkManagerWrap.OnInit));
		L.RegFunction("Unload", new LuaCSFunction(LuaFramework_NetworkManagerWrap.Unload));
		L.RegFunction("CallMethod", new LuaCSFunction(LuaFramework_NetworkManagerWrap.CallMethod));
		L.RegFunction("AddEvent", new LuaCSFunction(LuaFramework_NetworkManagerWrap.AddEvent));
		L.RegFunction("SendConnect", new LuaCSFunction(LuaFramework_NetworkManagerWrap.SendConnect));
		L.RegFunction("Disconnect", new LuaCSFunction(LuaFramework_NetworkManagerWrap.Disconnect));
		L.RegFunction("SendMessage", new LuaCSFunction(LuaFramework_NetworkManagerWrap.SendMessage));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_NetworkManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnInit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			NetworkManager networkManager = (NetworkManager)ToLua.CheckObject(L, 1, typeof(NetworkManager));
			networkManager.OnInit();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Unload(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			NetworkManager networkManager = (NetworkManager)ToLua.CheckObject(L, 1, typeof(NetworkManager));
			networkManager.Unload();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallMethod(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			NetworkManager networkManager = (NetworkManager)ToLua.CheckObject(L, 1, typeof(NetworkManager));
			string func = ToLua.CheckString(L, 2);
			object[] args = ToLua.ToParamsObject(L, 3, num - 2);
			object[] array = networkManager.CallMethod(func, args);
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
	private static int AddEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int @event = (int)LuaDLL.luaL_checknumber(L, 1);
			LuaByteBuffer data = new LuaByteBuffer(ToLua.CheckByteBuffer(L, 2));
			NetworkManager.AddEvent(@event, data);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendConnect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			NetworkManager networkManager = (NetworkManager)ToLua.CheckObject(L, 1, typeof(NetworkManager));
			networkManager.SendConnect();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Disconnect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			NetworkManager networkManager = (NetworkManager)ToLua.CheckObject(L, 1, typeof(NetworkManager));
			networkManager.Disconnect();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendMessage(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(NetworkManager), typeof(string)))
			{
				NetworkManager networkManager = (NetworkManager)ToLua.ToObject(L, 1);
				string methodName = ToLua.ToString(L, 2);
				networkManager.SendMessage(methodName);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(NetworkManager), typeof(ByteBuffer)))
			{
				NetworkManager networkManager2 = (NetworkManager)ToLua.ToObject(L, 1);
				ByteBuffer buffer = (ByteBuffer)ToLua.ToObject(L, 2);
				networkManager2.SendMessage(buffer);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(NetworkManager), typeof(string), typeof(SendMessageOptions)))
			{
				NetworkManager networkManager3 = (NetworkManager)ToLua.ToObject(L, 1);
				string methodName2 = ToLua.ToString(L, 2);
				SendMessageOptions options = (SendMessageOptions)((int)ToLua.ToObject(L, 3));
				networkManager3.SendMessage(methodName2, options);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(NetworkManager), typeof(string), typeof(object)))
			{
				NetworkManager networkManager4 = (NetworkManager)ToLua.ToObject(L, 1);
				string methodName3 = ToLua.ToString(L, 2);
				object value = ToLua.ToVarObject(L, 3);
				networkManager4.SendMessage(methodName3, value);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(NetworkManager), typeof(string), typeof(object), typeof(SendMessageOptions)))
			{
				NetworkManager networkManager5 = (NetworkManager)ToLua.ToObject(L, 1);
				string methodName4 = ToLua.ToString(L, 2);
				object value2 = ToLua.ToVarObject(L, 3);
				SendMessageOptions options2 = (SendMessageOptions)((int)ToLua.ToObject(L, 4));
				networkManager5.SendMessage(methodName4, value2, options2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.NetworkManager.SendMessage");
			}
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
}
