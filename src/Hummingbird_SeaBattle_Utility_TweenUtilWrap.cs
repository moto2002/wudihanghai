using Hummingbird.SeaBattle.Utility;
using LuaInterface;
using System;
using UnityEngine;

public class Hummingbird_SeaBattle_Utility_TweenUtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenUtil), typeof(object), null);
		L.RegFunction("Move", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.Move));
		L.RegFunction("MoveLocal", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.MoveLocal));
		L.RegFunction("Scale", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.Scale));
		L.RegFunction("ScaleUGUI", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.ScaleUGUI));
		L.RegFunction("AlphaUGUI", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.AlphaUGUI));
		L.RegFunction("PlayGroupTween", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.PlayGroupTween));
		L.RegFunction("SetTweenPositionInfo", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.SetTweenPositionInfo));
		L.RegFunction("SetTweenPositionInfoByTweenGroup", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.SetTweenPositionInfoByTweenGroup));
		L.RegFunction("SetTweenUGUITextInfo", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.SetTweenUGUITextInfo));
		L.RegFunction("SetTweenSpriteInfo", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.SetTweenSpriteInfo));
		L.RegFunction("SetTweenRotationInfo", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.SetTweenRotationInfo));
		L.RegFunction("SetTweenAlphaInfo", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.SetTweenAlphaInfo));
		L.RegFunction("SetTweenAlphaInfoByTweenGroup", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.SetTweenAlphaInfoByTweenGroup));
		L.RegFunction("SetTweenScaleInfo", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.SetTweenScaleInfo));
		L.RegFunction("PlayTween", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.PlayTween));
		L.RegFunction("StopTween", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.StopTween));
		L.RegFunction("DestroyTween", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.DestroyTween));
		L.RegFunction("StopiTween", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.StopiTween));
		L.RegFunction("ITweenMoveTo", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.ITweenMoveTo));
		L.RegFunction("ITweenValueTo", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap.ITweenValueTo));
		L.RegFunction("New", new LuaCSFunction(Hummingbird_SeaBattle_Utility_TweenUtilWrap._CreateHummingbird_SeaBattle_Utility_TweenUtil));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateHummingbird_SeaBattle_Utility_TweenUtil(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				TweenUtil o = new TweenUtil();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Hummingbird.SeaBattle.Utility.TweenUtil.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Move(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 7);
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Vector3 to = ToLua.ToVector3(L, 2);
			float time = (float)LuaDLL.luaL_checknumber(L, 3);
			int type = (int)LuaDLL.luaL_checknumber(L, 4);
			float delay = (float)LuaDLL.luaL_checknumber(L, 5);
			LuaFunction finishToDo = ToLua.CheckLuaFunction(L, 6);
			object para = ToLua.ToVarObject(L, 7);
			TweenUtil.Move(gameObject, to, time, type, delay, finishToDo, para);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveLocal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 7);
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Vector3 to = ToLua.ToVector3(L, 2);
			float time = (float)LuaDLL.luaL_checknumber(L, 3);
			int type = (int)LuaDLL.luaL_checknumber(L, 4);
			float delay = (float)LuaDLL.luaL_checknumber(L, 5);
			LuaFunction finishToDo = ToLua.CheckLuaFunction(L, 6);
			object para = ToLua.ToVarObject(L, 7);
			TweenUtil.MoveLocal(gameObject, to, time, type, delay, finishToDo, para);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Scale(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 7);
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Vector3 to = ToLua.ToVector3(L, 2);
			float time = (float)LuaDLL.luaL_checknumber(L, 3);
			int type = (int)LuaDLL.luaL_checknumber(L, 4);
			float delay = (float)LuaDLL.luaL_checknumber(L, 5);
			LuaFunction finishToDo = ToLua.CheckLuaFunction(L, 6);
			object para = ToLua.ToVarObject(L, 7);
			TweenUtil.Scale(gameObject, to, time, type, delay, finishToDo, para);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ScaleUGUI(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 7);
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Vector2 to = ToLua.ToVector2(L, 2);
			float time = (float)LuaDLL.luaL_checknumber(L, 3);
			int type = (int)LuaDLL.luaL_checknumber(L, 4);
			float delay = (float)LuaDLL.luaL_checknumber(L, 5);
			LuaFunction finishToDo = ToLua.CheckLuaFunction(L, 6);
			object para = ToLua.ToVarObject(L, 7);
			TweenUtil.ScaleUGUI(gameObject, to, time, type, delay, finishToDo, para);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AlphaUGUI(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 7);
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			float time = (float)LuaDLL.luaL_checknumber(L, 3);
			int type = (int)LuaDLL.luaL_checknumber(L, 4);
			float delay = (float)LuaDLL.luaL_checknumber(L, 5);
			LuaFunction finishToDo = ToLua.CheckLuaFunction(L, 6);
			object para = ToLua.ToVarObject(L, 7);
			TweenUtil.AlphaUGUI(gameObject, to, time, type, delay, finishToDo, para);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayGroupTween(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			int tweenGroup = (int)LuaDLL.luaL_checknumber(L, 2);
			bool isForward = LuaDLL.luaL_checkboolean(L, 3);
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 4);
			TweenUtil.PlayGroupTween(go, tweenGroup, isForward, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTweenPositionInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Vector3 from = ToLua.ToVector3(L, 2);
			Vector3 to = ToLua.ToVector3(L, 3);
			float duration = (float)LuaDLL.luaL_checknumber(L, 4);
			float delay = (float)LuaDLL.luaL_checknumber(L, 5);
			TweenUtil.SetTweenPositionInfo(go, from, to, duration, delay);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTweenPositionInfoByTweenGroup(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			int tweenGroup = (int)LuaDLL.luaL_checknumber(L, 2);
			Vector3 from = ToLua.ToVector3(L, 3);
			Vector3 to = ToLua.ToVector3(L, 4);
			float duration = (float)LuaDLL.luaL_checknumber(L, 5);
			float delay = (float)LuaDLL.luaL_checknumber(L, 6);
			TweenUtil.SetTweenPositionInfoByTweenGroup(go, tweenGroup, from, to, duration, delay);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTweenUGUITextInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			double from = LuaDLL.luaL_checknumber(L, 2);
			double to = LuaDLL.luaL_checknumber(L, 3);
			float duration = (float)LuaDLL.luaL_checknumber(L, 4);
			TweenUtil.SetTweenUGUITextInfo(go, from, to, duration);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTweenSpriteInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Sprite[] sprites = ToLua.CheckObjectArray<Sprite>(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			float delay = (float)LuaDLL.luaL_checknumber(L, 4);
			TweenUtil.SetTweenSpriteInfo(go, sprites, duration, delay);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTweenRotationInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Vector3 from = ToLua.ToVector3(L, 2);
			Vector3 to = ToLua.ToVector3(L, 3);
			float duration = (float)LuaDLL.luaL_checknumber(L, 4);
			TweenUtil.SetTweenRotationInfo(go, from, to, duration);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTweenAlphaInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			float from = (float)LuaDLL.luaL_checknumber(L, 2);
			float to = (float)LuaDLL.luaL_checknumber(L, 3);
			float duration = (float)LuaDLL.luaL_checknumber(L, 4);
			float delay = (float)LuaDLL.luaL_checknumber(L, 5);
			TweenUtil.SetTweenAlphaInfo(go, from, to, duration, delay);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTweenAlphaInfoByTweenGroup(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			int tweenGroup = (int)LuaDLL.luaL_checknumber(L, 2);
			float from = (float)LuaDLL.luaL_checknumber(L, 3);
			float to = (float)LuaDLL.luaL_checknumber(L, 4);
			float duration = (float)LuaDLL.luaL_checknumber(L, 5);
			float delay = (float)LuaDLL.luaL_checknumber(L, 6);
			TweenUtil.SetTweenAlphaInfoByTweenGroup(go, tweenGroup, from, to, duration, delay);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTweenScaleInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Vector3 from = ToLua.ToVector3(L, 2);
			Vector3 to = ToLua.ToVector3(L, 3);
			float duration = (float)LuaDLL.luaL_checknumber(L, 4);
			float delay = (float)LuaDLL.luaL_checknumber(L, 5);
			Vector2[] keyframes = ToLua.CheckObjectArray<Vector2>(L, 6);
			TweenUtil.SetTweenScaleInfo(go, from, to, duration, delay, keyframes);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayTween(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			bool isForward = LuaDLL.luaL_checkboolean(L, 2);
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			bool isRestart = LuaDLL.luaL_checkboolean(L, 4);
			TweenUtil.PlayTween(go, isForward, luafunc, isRestart);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopTween(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			TweenUtil.StopTween(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DestroyTween(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			TweenUtil.DestroyTween(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopiTween(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject gobj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			TweenUtil.StopiTween(gobj);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ITweenMoveTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 9);
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			object[] path = ToLua.CheckObjectArray(L, 2);
			bool isMovetopath = LuaDLL.luaL_checkboolean(L, 3);
			float speedOrTimeValue = (float)LuaDLL.luaL_checknumber(L, 4);
			string type = ToLua.CheckString(L, 5);
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 6);
			float distance = (float)LuaDLL.luaL_checknumber(L, 7);
			bool isLookAt = LuaDLL.luaL_checkboolean(L, 8);
			bool isUseTime = LuaDLL.luaL_checkboolean(L, 9);
			TweenUtil.ITweenMoveTo(gameObject, path, isMovetopath, speedOrTimeValue, type, luafunc, distance, isLookAt, isUseTime);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ITweenValueTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 7);
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			float from = (float)LuaDLL.luaL_checknumber(L, 2);
			float to = (float)LuaDLL.luaL_checknumber(L, 3);
			float time = (float)LuaDLL.luaL_checknumber(L, 4);
			string type = ToLua.CheckString(L, 5);
			LuaFunction onUpdate = ToLua.CheckLuaFunction(L, 6);
			LuaFunction onComplete = ToLua.CheckLuaFunction(L, 7);
			TweenUtil.ITweenValueTo(gameObject, from, to, time, type, onUpdate, onComplete);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
