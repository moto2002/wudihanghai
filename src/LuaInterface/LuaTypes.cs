using System;

namespace LuaInterface
{
	public enum LuaTypes
	{
		LUA_TNONE = -1,
		LUA_TNIL,
		LUA_TBOOLEAN,
		LUA_TLIGHTUSERDATA,
		LUA_TNUMBER,
		LUA_TSTRING,
		LUA_TTABLE,
		LUA_TFUNCTION,
		LUA_TUSERDATA,
		LUA_TTHREAD
	}
}
