using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LuaInterface
{
	public class LuaStatePtr
	{
		protected IntPtr L;

		public int LuaUpValueIndex(int i)
		{
			return LuaIndexes.LUA_GLOBALSINDEX - i;
		}

		public IntPtr LuaNewState()
		{
			return LuaDLL.luaL_newstate();
		}

		public void LuaClose()
		{
			LuaDLL.lua_close(this.L);
			this.L = IntPtr.Zero;
		}

		public IntPtr LuaNewThread()
		{
			return LuaDLL.lua_newthread(this.L);
		}

		public IntPtr LuaAtPanic(IntPtr panic)
		{
			return LuaDLL.lua_atpanic(this.L, panic);
		}

		public int LuaGetTop()
		{
			return LuaDLL.lua_gettop(this.L);
		}

		public void LuaSetTop(int newTop)
		{
			LuaDLL.lua_settop(this.L, newTop);
		}

		public void LuaPushValue(int idx)
		{
			LuaDLL.lua_pushvalue(this.L, idx);
		}

		public void LuaRemove(int index)
		{
			LuaDLL.lua_remove(this.L, index);
		}

		public void LuaInsert(int idx)
		{
			LuaDLL.lua_insert(this.L, idx);
		}

		public void LuaReplace(int idx)
		{
			LuaDLL.lua_replace(this.L, idx);
		}

		public bool LuaCheckStack(int args)
		{
			return LuaDLL.lua_checkstack(this.L, args) != 0;
		}

		public void LuaXMove(IntPtr to, int n)
		{
			LuaDLL.lua_xmove(this.L, to, n);
		}

		public bool LuaIsNumber(int idx)
		{
			return LuaDLL.lua_isnumber(this.L, idx) != 0;
		}

		public bool LuaIsString(int index)
		{
			return LuaDLL.lua_isstring(this.L, index) != 0;
		}

		public bool LuaIsCFunction(int index)
		{
			return LuaDLL.lua_iscfunction(this.L, index) != 0;
		}

		public bool LuaIsUserData(int index)
		{
			return LuaDLL.lua_isuserdata(this.L, index) != 0;
		}

		public bool LuaIsNil(int n)
		{
			return LuaDLL.lua_isnil(this.L, n);
		}

		public LuaTypes LuaType(int index)
		{
			return LuaDLL.lua_type(this.L, index);
		}

		public string LuaTypeName(LuaTypes type)
		{
			return LuaDLL.lua_typename(this.L, type);
		}

		public string LuaTypeName(int idx)
		{
			return LuaDLL.luaL_typename(this.L, idx);
		}

		public bool LuaEqual(int idx1, int idx2)
		{
			return LuaDLL.lua_equal(this.L, idx1, idx2) != 0;
		}

		public bool LuaRawEqual(int idx1, int idx2)
		{
			return LuaDLL.lua_rawequal(this.L, idx1, idx2) != 0;
		}

		public bool LuaLessThan(int idx1, int idx2)
		{
			return LuaDLL.lua_lessthan(this.L, idx1, idx2) != 0;
		}

		public double LuaToNumber(int idx)
		{
			return LuaDLL.lua_tonumber(this.L, idx);
		}

		public int LuaToInteger(int idx)
		{
			return LuaDLL.lua_tointeger(this.L, idx);
		}

		public bool LuaToBoolean(int idx)
		{
			return LuaDLL.lua_toboolean(this.L, idx);
		}

		public string LuaToString(int index)
		{
			return LuaDLL.lua_tostring(this.L, index);
		}

		public IntPtr LuaToLString(int index, out int len)
		{
			return LuaDLL.tolua_tolstring(this.L, index, out len);
		}

		public IntPtr LuaToCFunction(int idx)
		{
			return LuaDLL.lua_tocfunction(this.L, idx);
		}

		public IntPtr LuaToUserData(int idx)
		{
			return LuaDLL.lua_touserdata(this.L, idx);
		}

		public IntPtr LuaToThread(int idx)
		{
			return LuaDLL.lua_tothread(this.L, idx);
		}

		public IntPtr LuaToPointer(int idx)
		{
			return LuaDLL.lua_topointer(this.L, idx);
		}

		public int LuaObjLen(int index)
		{
			return LuaDLL.tolua_objlen(this.L, index);
		}

		public void LuaPushNil()
		{
			LuaDLL.lua_pushnil(this.L);
		}

		public void LuaPushNumber(double number)
		{
			LuaDLL.lua_pushnumber(this.L, number);
		}

		public void LuaPushInteger(int n)
		{
			LuaDLL.lua_pushnumber(this.L, (double)n);
		}

		public void LuaPushLString(byte[] str, int size)
		{
			LuaDLL.lua_pushlstring(this.L, str, size);
		}

		public void LuaPushString(string str)
		{
			LuaDLL.lua_pushstring(this.L, str);
		}

		public void LuaPushCClosure(IntPtr fn, int n)
		{
			LuaDLL.lua_pushcclosure(this.L, fn, n);
		}

		public void LuaPushBoolean(bool value)
		{
			LuaDLL.lua_pushboolean(this.L, (!value) ? 0 : 1);
		}

		public void LuaPushLightUserData(IntPtr udata)
		{
			LuaDLL.lua_pushlightuserdata(this.L, udata);
		}

		public int LuaPushThread()
		{
			return LuaDLL.lua_pushthread(this.L);
		}

		public void LuaGetTable(int idx)
		{
			LuaDLL.lua_gettable(this.L, idx);
		}

		public void LuaGetField(int index, string key)
		{
			LuaDLL.lua_getfield(this.L, index, key);
		}

		public void LuaRawGet(int idx)
		{
			LuaDLL.lua_rawget(this.L, idx);
		}

		public void LuaRawGetI(int tableIndex, int index)
		{
			LuaDLL.lua_rawgeti(this.L, tableIndex, index);
		}

		public void LuaCreateTable(int narr = 0, int nec = 0)
		{
			LuaDLL.lua_createtable(this.L, narr, nec);
		}

		public IntPtr LuaNewUserData(int size)
		{
			return LuaDLL.tolua_newuserdata(this.L, size);
		}

		public int LuaGetMetaTable(int idx)
		{
			return LuaDLL.lua_getmetatable(this.L, idx);
		}

		public void LuaGetEnv(int idx)
		{
			LuaDLL.lua_getfenv(this.L, idx);
		}

		public void LuaSetTable(int idx)
		{
			LuaDLL.lua_settable(this.L, idx);
		}

		public void LuaSetField(int idx, string key)
		{
			LuaDLL.lua_setfield(this.L, idx, key);
		}

		public void LuaRawSet(int idx)
		{
			LuaDLL.lua_rawset(this.L, idx);
		}

		public void LuaRawSetI(int tableIndex, int index)
		{
			LuaDLL.lua_rawseti(this.L, tableIndex, index);
		}

		public void LuaSetMetaTable(int objIndex)
		{
			LuaDLL.lua_setmetatable(this.L, objIndex);
		}

		public void LuaSetEnv(int idx)
		{
			LuaDLL.lua_setfenv(this.L, idx);
		}

		public void LuaCall(int nArgs, int nResults)
		{
			LuaDLL.lua_call(this.L, nArgs, nResults);
		}

		public int LuaPCall(int nArgs, int nResults, int errfunc)
		{
			return LuaDLL.lua_pcall(this.L, nArgs, nResults, errfunc);
		}

		public int LuaYield(int nresults)
		{
			return LuaDLL.lua_yield(this.L, nresults);
		}

		public int LuaResume(int narg)
		{
			return LuaDLL.lua_resume(this.L, narg);
		}

		public int LuaStatus()
		{
			return LuaDLL.lua_status(this.L);
		}

		public void LuaGC(LuaGCOptions what, int data = 0)
		{
			LuaDLL.lua_gc(this.L, what, data);
		}

		public bool LuaNext(int index)
		{
			return LuaDLL.lua_next(this.L, index) != 0;
		}

		public void LuaConcat(int n)
		{
			LuaDLL.lua_concat(this.L, n);
		}

		public void LuaPop(int amount)
		{
			LuaDLL.lua_pop(this.L, amount);
		}

		public void LuaNewTable()
		{
			LuaDLL.lua_createtable(this.L, 0, 0);
		}

		public void LuaPushFunction(LuaCSFunction func)
		{
			IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(func);
			LuaDLL.lua_pushcclosure(this.L, functionPointerForDelegate, 0);
		}

		public bool lua_isfunction(int n)
		{
			return LuaDLL.lua_type(this.L, n) == LuaTypes.LUA_TFUNCTION;
		}

		public bool lua_istable(int n)
		{
			return LuaDLL.lua_type(this.L, n) == LuaTypes.LUA_TTABLE;
		}

		public bool lua_islightuserdata(int n)
		{
			return LuaDLL.lua_type(this.L, n) == LuaTypes.LUA_TLIGHTUSERDATA;
		}

		public bool lua_isnil(int n)
		{
			return LuaDLL.lua_type(this.L, n) == LuaTypes.LUA_TNIL;
		}

		public bool lua_isboolean(int n)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(this.L, n);
			return luaTypes == LuaTypes.LUA_TBOOLEAN || luaTypes == LuaTypes.LUA_TNIL;
		}

		public bool lua_isthread(int n)
		{
			return LuaDLL.lua_type(this.L, n) == LuaTypes.LUA_TTHREAD;
		}

		public bool lua_isnone(int n)
		{
			return LuaDLL.lua_type(this.L, n) == LuaTypes.LUA_TNONE;
		}

		public bool lua_isnoneornil(int n)
		{
			return LuaDLL.lua_type(this.L, n) <= LuaTypes.LUA_TNIL;
		}

		public void LuaRawGlobal(string name)
		{
			LuaDLL.lua_pushstring(this.L, name);
			LuaDLL.lua_rawget(this.L, LuaIndexes.LUA_GLOBALSINDEX);
		}

		public void LuaSetGlobal(string name)
		{
			LuaDLL.lua_setglobal(this.L, name);
		}

		public void LuaGetGlobal(string name)
		{
			LuaDLL.lua_getglobal(this.L, name);
		}

		public void LuaOpenLibs()
		{
			LuaDLL.luaL_openlibs(this.L);
		}

		public int AbsIndex(int i)
		{
			return (i <= 0 && i > LuaIndexes.LUA_REGISTRYINDEX) ? (LuaDLL.lua_gettop(this.L) + i + 1) : i;
		}

		public int LuaGetN(int i)
		{
			return LuaDLL.luaL_getn(this.L, i);
		}

		public double LuaCheckNumber(int stackPos)
		{
			return LuaDLL.luaL_checknumber(this.L, stackPos);
		}

		public int LuaCheckInteger(int idx)
		{
			return LuaDLL.luaL_checkinteger(this.L, idx);
		}

		public bool LuaCheckBoolean(int stackPos)
		{
			return LuaDLL.luaL_checkboolean(this.L, stackPos);
		}

		public string LuaCheckLString(int numArg, out int len)
		{
			return LuaDLL.luaL_checklstring(this.L, numArg, out len);
		}

		public int LuaLoadBuffer(byte[] buff, int size, string name)
		{
			return LuaDLL.luaL_loadbuffer(this.L, buff, size, name);
		}

		public IntPtr LuaFindTable(int idx, string fname, int szhint = 1)
		{
			return LuaDLL.luaL_findtable(this.L, idx, fname, szhint);
		}

		public int LuaTypeError(int stackPos, string tname, string t2 = null)
		{
			return LuaDLL.luaL_typerror(this.L, stackPos, tname, t2);
		}

		public bool LuaDoString(string chunk, string chunkName = "LuaStatePtr.cs")
		{
			byte[] bytes = Encoding.UTF8.GetBytes(chunk);
			int num = LuaDLL.luaL_loadbuffer(this.L, bytes, bytes.Length, chunkName);
			return num == 0 && LuaDLL.lua_pcall(this.L, 0, LuaDLL.LUA_MULTRET, 0) == 0;
		}

		public bool LuaDoFile(string fileName)
		{
			int newTop = this.LuaGetTop();
			if (LuaDLL.luaL_dofile(this.L, fileName))
			{
				return true;
			}
			string msg = this.LuaToString(-1);
			this.LuaSetTop(newTop);
			throw new LuaException(msg, LuaException.GetLastError(), 1);
		}

		public void LuaGetMetaTable(string meta)
		{
			LuaDLL.luaL_getmetatable(this.L, meta);
		}

		public int LuaRef(int t)
		{
			return LuaDLL.luaL_ref(this.L, t);
		}

		public void LuaGetRef(int reference)
		{
			LuaDLL.lua_getref(this.L, reference);
		}

		public void LuaUnRef(int reference)
		{
			LuaDLL.lua_unref(this.L, reference);
		}

		public int LuaRequire(string fileName)
		{
			return LuaDLL.tolua_require(this.L, fileName);
		}

		public void ThrowLuaException(Exception e)
		{
			if (LuaException.InstantiateCount > 0 || LuaException.SendMsgCount > 0)
			{
				LuaDLL.toluaL_exception(this.L, e, null);
				return;
			}
			throw e;
		}

		public int ToLuaRef()
		{
			return LuaDLL.toluaL_ref(this.L);
		}

		public int LuaUpdate(float delta, float unscaled)
		{
			return LuaDLL.tolua_update(this.L, delta, unscaled);
		}

		public int LuaLateUpdate()
		{
			return LuaDLL.tolua_lateupdate(this.L);
		}

		public int LuaFixedUpdate(float fixedTime)
		{
			return LuaDLL.tolua_fixedupdate(this.L, fixedTime);
		}

		public void OpenToLuaLibs()
		{
			LuaDLL.tolua_openlibs(this.L);
		}

		public void ToLuaPushTraceback()
		{
			LuaDLL.tolua_pushtraceback(this.L);
		}

		public void ToLuaUnRef(int reference)
		{
			LuaDLL.toluaL_unref(this.L, reference);
		}
	}
}
