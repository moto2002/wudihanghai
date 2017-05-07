using LuaInterface;
using System;
using UnityEngine;

public class ViewWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(View), typeof(Base), null);
		L.RegFunction("OnMessage", new LuaCSFunction(ViewWrap.OnMessage));
		L.RegFunction("__eq", new LuaCSFunction(ViewWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnMessage(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			View view = (View)ToLua.CheckObject(L, 1, typeof(View));
			IMessage message = (IMessage)ToLua.CheckObject(L, 2, typeof(IMessage));
			view.OnMessage(message);
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
