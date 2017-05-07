using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_SoundManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SoundManager), typeof(Manager), null);
		L.RegFunction("CleanAudioClip", new LuaCSFunction(LuaFramework_SoundManagerWrap.CleanAudioClip));
		L.RegFunction("CanPlayBackSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.CanPlayBackSound));
		L.RegFunction("SetPlayBackSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.SetPlayBackSound));
		L.RegFunction("SetPlayBackVolume", new LuaCSFunction(LuaFramework_SoundManagerWrap.SetPlayBackVolume));
		L.RegFunction("StopBackSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.StopBackSound));
		L.RegFunction("PauseOrResumeBackSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.PauseOrResumeBackSound));
		L.RegFunction("CanPlaySoundEffect", new LuaCSFunction(LuaFramework_SoundManagerWrap.CanPlaySoundEffect));
		L.RegFunction("SetPlaySoundEffect", new LuaCSFunction(LuaFramework_SoundManagerWrap.SetPlaySoundEffect));
		L.RegFunction("PlayBackSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.PlayBackSound));
		L.RegFunction("PlayOnlySound", new LuaCSFunction(LuaFramework_SoundManagerWrap.PlayOnlySound));
		L.RegFunction("StopOnlySound", new LuaCSFunction(LuaFramework_SoundManagerWrap.StopOnlySound));
		L.RegFunction("PlayActionSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.PlayActionSound));
		L.RegFunction("PlaySound", new LuaCSFunction(LuaFramework_SoundManagerWrap.PlaySound));
		L.RegFunction("PlayBackgroundIntervalPlayAduio", new LuaCSFunction(LuaFramework_SoundManagerWrap.PlayBackgroundIntervalPlayAduio));
		L.RegFunction("Play2DIntervalPlayAduio", new LuaCSFunction(LuaFramework_SoundManagerWrap.Play2DIntervalPlayAduio));
		L.RegFunction("ClearIntervalPlayAduio", new LuaCSFunction(LuaFramework_SoundManagerWrap.ClearIntervalPlayAduio));
		L.RegFunction("Play2DAduio", new LuaCSFunction(LuaFramework_SoundManagerWrap.Play2DAduio));
		L.RegFunction("Stop2DAduio", new LuaCSFunction(LuaFramework_SoundManagerWrap.Stop2DAduio));
		L.RegFunction("ToEnd2DAduio", new LuaCSFunction(LuaFramework_SoundManagerWrap.ToEnd2DAduio));
		L.RegFunction("OpenOrClose2DAduio", new LuaCSFunction(LuaFramework_SoundManagerWrap.OpenOrClose2DAduio));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_SoundManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CleanAudioClip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			soundManager.CleanAudioClip();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CanPlayBackSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			bool value = soundManager.CanPlayBackSound();
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPlayBackSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			bool playBackSound = LuaDLL.luaL_checkboolean(L, 2);
			soundManager.SetPlayBackSound(playBackSound);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPlayBackVolume(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			float playBackVolume = (float)LuaDLL.luaL_checknumber(L, 2);
			soundManager.SetPlayBackVolume(playBackVolume);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopBackSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			soundManager.StopBackSound();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PauseOrResumeBackSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			bool isPause = LuaDLL.luaL_checkboolean(L, 2);
			soundManager.PauseOrResumeBackSound(isPause);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CanPlaySoundEffect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			bool value = soundManager.CanPlaySoundEffect();
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPlaySoundEffect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			bool playSoundEffect = LuaDLL.luaL_checkboolean(L, 2);
			soundManager.SetPlaySoundEffect(playSoundEffect);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayBackSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string path = ToLua.CheckString(L, 2);
			bool isLoop = LuaDLL.luaL_checkboolean(L, 3);
			soundManager.PlayBackSound(path, isLoop);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayOnlySound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string path = ToLua.CheckString(L, 2);
			bool oneShotOrNot = LuaDLL.luaL_checkboolean(L, 3);
			soundManager.PlayOnlySound(path, oneShotOrNot);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopOnlySound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			soundManager.StopOnlySound();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayActionSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string path = ToLua.CheckString(L, 2);
			bool oneShotOrNot = LuaDLL.luaL_checkboolean(L, 3);
			soundManager.PlayActionSound(path, oneShotOrNot);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlaySound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			AudioSource audio = (AudioSource)ToLua.CheckUnityObject(L, 2, typeof(AudioSource));
			string path = ToLua.CheckString(L, 3);
			bool oneShotOrNot = LuaDLL.luaL_checkboolean(L, 4);
			soundManager.PlaySound(audio, path, oneShotOrNot);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayBackgroundIntervalPlayAduio(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string path = ToLua.CheckString(L, 2);
			int intervalTime = (int)LuaDLL.luaL_checknumber(L, 3);
			soundManager.PlayBackgroundIntervalPlayAduio(path, intervalTime);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play2DIntervalPlayAduio(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string path = ToLua.CheckString(L, 2);
			float min = (float)LuaDLL.luaL_checknumber(L, 3);
			float max = (float)LuaDLL.luaL_checknumber(L, 4);
			soundManager.Play2DIntervalPlayAduio(path, min, max);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearIntervalPlayAduio(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			soundManager.ClearIntervalPlayAduio();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play2DAduio(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string path = ToLua.CheckString(L, 2);
			bool isLoop = LuaDLL.luaL_checkboolean(L, 3);
			soundManager.Play2DAduio(path, isLoop);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Stop2DAduio(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			soundManager.Stop2DAduio();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToEnd2DAduio(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			soundManager.ToEnd2DAduio();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OpenOrClose2DAduio(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			bool isOpen = LuaDLL.luaL_checkboolean(L, 2);
			soundManager.OpenOrClose2DAduio(isOpen);
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
