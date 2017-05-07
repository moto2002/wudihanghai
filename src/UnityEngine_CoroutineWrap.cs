using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_CoroutineWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Coroutine), null, null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}
}
