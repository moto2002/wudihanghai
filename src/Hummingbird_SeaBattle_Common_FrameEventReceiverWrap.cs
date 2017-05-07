using Hummingbird.SeaBattle.Common;
using LuaInterface;
using System;
using UnityEngine;

public class Hummingbird_SeaBattle_Common_FrameEventReceiverWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FrameEventReceiver), typeof(MonoBehaviour), null);
		L.RegFunction("AddLuaCallbackEvent", new LuaCSFunction(Hummingbird_SeaBattle_Common_FrameEventReceiverWrap.AddLuaCallbackEvent));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_SeaBattle_Common_FrameEventReceiverWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddLuaCallbackEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FrameEventReceiver frameEventReceiver = (FrameEventReceiver)ToLua.CheckObject(L, 1, typeof(FrameEventReceiver));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 2);
			frameEventReceiver.AddLuaCallbackEvent(luafunc);
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
