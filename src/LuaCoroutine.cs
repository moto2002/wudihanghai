using LuaInterface;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public static class LuaCoroutine
{
	private static MonoBehaviour mb;

	private static string strCo = "\n        local _WaitForSeconds, _WaitForFixedUpdate, _WaitForEndOfFrame, _Yield, _StopCoroutine = WaitForSeconds, WaitForFixedUpdate, WaitForEndOfFrame, Yield, StopCoroutine        \n        local error = error\n        local debug = debug\n        local coroutine = coroutine\n        local comap = {}\n        setmetatable(comap, {__mode = 'k'})\n\n        function _resume(co)\n            if comap[co] then\n                comap[co] = nil\n                local flag, msg = coroutine.resume(co)\n                    \n                if not flag then\n                    msg = debug.traceback(co, msg)\n                    error(msg)\n                end\n            end        \n        end\n\n        function WaitForSeconds(t)\n            local co = coroutine.running()\n            local resume = function()                    \n                _resume(co)                     \n            end\n            \n            comap[co] = _WaitForSeconds(t, resume)\n            return coroutine.yield()\n        end\n\n        function WaitForFixedUpdate()\n            local co = coroutine.running()\n            local resume = function()          \n                _resume(co)     \n            end\n        \n            comap[co] = _WaitForFixedUpdate(resume)\n            return coroutine.yield()\n        end\n\n        function WaitForEndOfFrame()\n            local co = coroutine.running()\n            local resume = function()        \n                _resume(co)     \n            end\n        \n            comap[co] = _WaitForEndOfFrame(resume)\n            return coroutine.yield()\n        end\n\n        function Yield(o)\n            local co = coroutine.running()\n            local resume = function()        \n                _resume(co)     \n            end\n        \n            comap[co] = _Yield(o, resume)\n            return coroutine.yield()\n        end\n\n        function StartCoroutine(func)\n            local co = coroutine.create(func)                       \n            coroutine.resume(co)\n            return co\n        end\n\n        function StopCoroutine(co)\n            local _co = comap[co]\n\n            if _co == nil then\n                return\n            end\n\n            comap[co] = nil\n            _StopCoroutine(_co)\n        end\n        ";

	public static void Register(LuaState state, MonoBehaviour behaviour)
	{
		state.BeginModule(null);
		state.RegFunction("WaitForSeconds", new LuaCSFunction(LuaCoroutine.WaitForSeconds));
		state.RegFunction("WaitForFixedUpdate", new LuaCSFunction(LuaCoroutine.WaitForFixedUpdate));
		state.RegFunction("WaitForEndOfFrame", new LuaCSFunction(LuaCoroutine.WaitForEndOfFrame));
		state.RegFunction("Yield", new LuaCSFunction(LuaCoroutine.Yield));
		state.RegFunction("StopCoroutine", new LuaCSFunction(LuaCoroutine.StopCoroutine));
		state.EndModule();
		state.LuaDoString(LuaCoroutine.strCo, "LuaCoroutine.cs");
		LuaCoroutine.mb = behaviour;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForSeconds(IntPtr L)
	{
		int result;
		try
		{
			float sec = (float)LuaDLL.luaL_checknumber(L, 1);
			LuaFunction func = ToLua.ToLuaFunction(L, 2);
			Coroutine o = LuaCoroutine.mb.StartCoroutine(LuaCoroutine.CoWaitForSeconds(sec, func));
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[DebuggerHidden]
	private static IEnumerator CoWaitForSeconds(float sec, LuaFunction func)
	{
		LuaCoroutine.<CoWaitForSeconds>c__Iterator18 <CoWaitForSeconds>c__Iterator = new LuaCoroutine.<CoWaitForSeconds>c__Iterator18();
		<CoWaitForSeconds>c__Iterator.sec = sec;
		<CoWaitForSeconds>c__Iterator.func = func;
		<CoWaitForSeconds>c__Iterator.<$>sec = sec;
		<CoWaitForSeconds>c__Iterator.<$>func = func;
		return <CoWaitForSeconds>c__Iterator;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForFixedUpdate(IntPtr L)
	{
		int result;
		try
		{
			LuaFunction func = ToLua.ToLuaFunction(L, 1);
			Coroutine o = LuaCoroutine.mb.StartCoroutine(LuaCoroutine.CoWaitForFixedUpdate(func));
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[DebuggerHidden]
	private static IEnumerator CoWaitForFixedUpdate(LuaFunction func)
	{
		LuaCoroutine.<CoWaitForFixedUpdate>c__Iterator19 <CoWaitForFixedUpdate>c__Iterator = new LuaCoroutine.<CoWaitForFixedUpdate>c__Iterator19();
		<CoWaitForFixedUpdate>c__Iterator.func = func;
		<CoWaitForFixedUpdate>c__Iterator.<$>func = func;
		return <CoWaitForFixedUpdate>c__Iterator;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForEndOfFrame(IntPtr L)
	{
		int result;
		try
		{
			LuaFunction func = ToLua.ToLuaFunction(L, 1);
			Coroutine o = LuaCoroutine.mb.StartCoroutine(LuaCoroutine.CoWaitForEndOfFrame(func));
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[DebuggerHidden]
	private static IEnumerator CoWaitForEndOfFrame(LuaFunction func)
	{
		LuaCoroutine.<CoWaitForEndOfFrame>c__Iterator1A <CoWaitForEndOfFrame>c__Iterator1A = new LuaCoroutine.<CoWaitForEndOfFrame>c__Iterator1A();
		<CoWaitForEndOfFrame>c__Iterator1A.func = func;
		<CoWaitForEndOfFrame>c__Iterator1A.<$>func = func;
		return <CoWaitForEndOfFrame>c__Iterator1A;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Yield(IntPtr L)
	{
		int result;
		try
		{
			object o = ToLua.ToVarObject(L, 1);
			LuaFunction func = ToLua.ToLuaFunction(L, 2);
			Coroutine o2 = LuaCoroutine.mb.StartCoroutine(LuaCoroutine.CoYield(o, func));
			ToLua.PushObject(L, o2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[DebuggerHidden]
	private static IEnumerator CoYield(object o, LuaFunction func)
	{
		LuaCoroutine.<CoYield>c__Iterator1B <CoYield>c__Iterator1B = new LuaCoroutine.<CoYield>c__Iterator1B();
		<CoYield>c__Iterator1B.o = o;
		<CoYield>c__Iterator1B.func = func;
		<CoYield>c__Iterator1B.<$>o = o;
		<CoYield>c__Iterator1B.<$>func = func;
		return <CoYield>c__Iterator1B;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopCoroutine(IntPtr L)
	{
		int result;
		try
		{
			Coroutine routine = (Coroutine)ToLua.CheckObject(L, 1, typeof(Coroutine));
			LuaCoroutine.mb.StopCoroutine(routine);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
