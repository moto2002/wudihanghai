using LuaInterface;
using System;

public class LuaInterface_LuaOutWrap
{
	public static void Register(LuaState L)
	{
		L.BeginPreLoad();
		L.RegFunction("tolua.out", new LuaCSFunction(LuaInterface_LuaOutWrap.LuaOpen_ToLua_Out));
		L.EndPreLoad();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaOpen_ToLua_Out(IntPtr L)
	{
		LuaDLL.lua_newtable(L);
		LuaInterface_LuaOutWrap.RawSetOutType<int>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<uint>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<float>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<double>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<long>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<ulong>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<byte>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<sbyte>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<char>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<short>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<ushort>(L);
		LuaInterface_LuaOutWrap.RawSetOutType<bool>(L);
		return 1;
	}

	private static void RawSetOutType<T>(IntPtr L)
	{
		string primitiveStr = LuaMisc.GetPrimitiveStr(typeof(T));
		LuaDLL.lua_pushstring(L, primitiveStr);
		ToLua.PushOut<T>(L, new LuaOut<T>());
		LuaDLL.lua_rawset(L, -3);
	}
}
