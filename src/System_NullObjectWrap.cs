using LuaInterface;
using System;

public class System_NullObjectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(NullObject), null, "null");
		L.EndClass();
	}
}
