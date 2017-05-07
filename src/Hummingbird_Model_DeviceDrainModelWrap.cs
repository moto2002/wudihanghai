using Hummingbird.Model;
using LuaInterface;
using System;
using UnityEngine;

public class Hummingbird_Model_DeviceDrainModelWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(DeviceDrainModel), typeof(MonoBehaviour), null);
		L.RegFunction("GenerateSessionId", new LuaCSFunction(Hummingbird_Model_DeviceDrainModelWrap.GenerateSessionId));
		L.RegFunction("RecordGetServerListResult", new LuaCSFunction(Hummingbird_Model_DeviceDrainModelWrap.RecordGetServerListResult));
		L.RegFunction("RecordLoginCheckResult", new LuaCSFunction(Hummingbird_Model_DeviceDrainModelWrap.RecordLoginCheckResult));
		L.RegFunction("RecordConnectGameServerResult", new LuaCSFunction(Hummingbird_Model_DeviceDrainModelWrap.RecordConnectGameServerResult));
		L.RegFunction("RecordEnterGame", new LuaCSFunction(Hummingbird_Model_DeviceDrainModelWrap.RecordEnterGame));
		L.RegFunction("RecordLogEvent", new LuaCSFunction(Hummingbird_Model_DeviceDrainModelWrap.RecordLogEvent));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_Model_DeviceDrainModelWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GenerateSessionId(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DeviceDrainModel deviceDrainModel = (DeviceDrainModel)ToLua.CheckObject(L, 1, typeof(DeviceDrainModel));
			deviceDrainModel.GenerateSessionId();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RecordGetServerListResult(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			DeviceDrainModel deviceDrainModel = (DeviceDrainModel)ToLua.CheckObject(L, 1, typeof(DeviceDrainModel));
			int status = (int)LuaDLL.luaL_checknumber(L, 2);
			string msg = ToLua.CheckString(L, 3);
			int relogin = (int)LuaDLL.luaL_checknumber(L, 4);
			deviceDrainModel.RecordGetServerListResult(status, msg, relogin);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RecordLoginCheckResult(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			DeviceDrainModel deviceDrainModel = (DeviceDrainModel)ToLua.CheckObject(L, 1, typeof(DeviceDrainModel));
			int status = (int)LuaDLL.luaL_checknumber(L, 2);
			string msg = ToLua.CheckString(L, 3);
			string openId = ToLua.CheckString(L, 4);
			deviceDrainModel.RecordLoginCheckResult(status, msg, openId);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RecordConnectGameServerResult(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			DeviceDrainModel deviceDrainModel = (DeviceDrainModel)ToLua.CheckObject(L, 1, typeof(DeviceDrainModel));
			int status = (int)LuaDLL.luaL_checknumber(L, 2);
			int serverId = (int)LuaDLL.luaL_checknumber(L, 3);
			string openId = ToLua.CheckString(L, 4);
			deviceDrainModel.RecordConnectGameServerResult(status, serverId, openId);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RecordEnterGame(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			DeviceDrainModel deviceDrainModel = (DeviceDrainModel)ToLua.CheckObject(L, 1, typeof(DeviceDrainModel));
			int serverId = (int)LuaDLL.luaL_checknumber(L, 2);
			int playerId = (int)LuaDLL.luaL_checknumber(L, 3);
			string openId = ToLua.CheckString(L, 4);
			deviceDrainModel.RecordEnterGame(serverId, playerId, openId);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RecordLogEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DeviceDrainModel deviceDrainModel = (DeviceDrainModel)ToLua.CheckObject(L, 1, typeof(DeviceDrainModel));
			string eventInfo = ToLua.CheckString(L, 2);
			deviceDrainModel.RecordLogEvent(eventInfo);
			result = 0;
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
