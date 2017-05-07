using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class UnityEngine_AudioSourceWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AudioSource), typeof(Behaviour), null);
		L.RegFunction("Play", new LuaCSFunction(UnityEngine_AudioSourceWrap.Play));
		L.RegFunction("PlayDelayed", new LuaCSFunction(UnityEngine_AudioSourceWrap.PlayDelayed));
		L.RegFunction("PlayScheduled", new LuaCSFunction(UnityEngine_AudioSourceWrap.PlayScheduled));
		L.RegFunction("SetScheduledStartTime", new LuaCSFunction(UnityEngine_AudioSourceWrap.SetScheduledStartTime));
		L.RegFunction("SetScheduledEndTime", new LuaCSFunction(UnityEngine_AudioSourceWrap.SetScheduledEndTime));
		L.RegFunction("Stop", new LuaCSFunction(UnityEngine_AudioSourceWrap.Stop));
		L.RegFunction("Pause", new LuaCSFunction(UnityEngine_AudioSourceWrap.Pause));
		L.RegFunction("UnPause", new LuaCSFunction(UnityEngine_AudioSourceWrap.UnPause));
		L.RegFunction("PlayOneShot", new LuaCSFunction(UnityEngine_AudioSourceWrap.PlayOneShot));
		L.RegFunction("PlayClipAtPoint", new LuaCSFunction(UnityEngine_AudioSourceWrap.PlayClipAtPoint));
		L.RegFunction("SetCustomCurve", new LuaCSFunction(UnityEngine_AudioSourceWrap.SetCustomCurve));
		L.RegFunction("GetCustomCurve", new LuaCSFunction(UnityEngine_AudioSourceWrap.GetCustomCurve));
		L.RegFunction("GetOutputData", new LuaCSFunction(UnityEngine_AudioSourceWrap.GetOutputData));
		L.RegFunction("GetSpectrumData", new LuaCSFunction(UnityEngine_AudioSourceWrap.GetSpectrumData));
		L.RegFunction("SetSpatializerFloat", new LuaCSFunction(UnityEngine_AudioSourceWrap.SetSpatializerFloat));
		L.RegFunction("GetSpatializerFloat", new LuaCSFunction(UnityEngine_AudioSourceWrap.GetSpatializerFloat));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_AudioSourceWrap._CreateUnityEngine_AudioSource));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_AudioSourceWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("volume", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_volume), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_volume));
		L.RegVar("pitch", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_pitch), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_pitch));
		L.RegVar("time", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_time), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_time));
		L.RegVar("timeSamples", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_timeSamples), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_timeSamples));
		L.RegVar("clip", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_clip), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_clip));
		L.RegVar("outputAudioMixerGroup", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_outputAudioMixerGroup), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_outputAudioMixerGroup));
		L.RegVar("isPlaying", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_isPlaying), null);
		L.RegVar("loop", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_loop), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_loop));
		L.RegVar("ignoreListenerVolume", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_ignoreListenerVolume), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_ignoreListenerVolume));
		L.RegVar("playOnAwake", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_playOnAwake), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_playOnAwake));
		L.RegVar("ignoreListenerPause", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_ignoreListenerPause), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_ignoreListenerPause));
		L.RegVar("velocityUpdateMode", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_velocityUpdateMode), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_velocityUpdateMode));
		L.RegVar("panStereo", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_panStereo), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_panStereo));
		L.RegVar("spatialBlend", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_spatialBlend), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_spatialBlend));
		L.RegVar("spatialize", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_spatialize), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_spatialize));
		L.RegVar("reverbZoneMix", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_reverbZoneMix), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_reverbZoneMix));
		L.RegVar("bypassEffects", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_bypassEffects), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_bypassEffects));
		L.RegVar("bypassListenerEffects", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_bypassListenerEffects), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_bypassListenerEffects));
		L.RegVar("bypassReverbZones", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_bypassReverbZones), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_bypassReverbZones));
		L.RegVar("dopplerLevel", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_dopplerLevel), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_dopplerLevel));
		L.RegVar("spread", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_spread), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_spread));
		L.RegVar("priority", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_priority), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_priority));
		L.RegVar("mute", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_mute), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_mute));
		L.RegVar("minDistance", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_minDistance), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_minDistance));
		L.RegVar("maxDistance", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_maxDistance), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_maxDistance));
		L.RegVar("rolloffMode", new LuaCSFunction(UnityEngine_AudioSourceWrap.get_rolloffMode), new LuaCSFunction(UnityEngine_AudioSourceWrap.set_rolloffMode));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_AudioSource(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				AudioSource obj = new AudioSource();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.AudioSource.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(AudioSource)))
			{
				AudioSource audioSource = (AudioSource)ToLua.ToObject(L, 1);
				audioSource.Play();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(AudioSource), typeof(ulong)))
			{
				AudioSource audioSource2 = (AudioSource)ToLua.ToObject(L, 1);
				ulong delay = LuaDLL.tolua_touint64(L, 2);
				audioSource2.Play(delay);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AudioSource.Play");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayDelayed(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			float delay = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.PlayDelayed(delay);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayScheduled(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			double time = LuaDLL.luaL_checknumber(L, 2);
			audioSource.PlayScheduled(time);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetScheduledStartTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			double scheduledStartTime = LuaDLL.luaL_checknumber(L, 2);
			audioSource.SetScheduledStartTime(scheduledStartTime);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetScheduledEndTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			double scheduledEndTime = LuaDLL.luaL_checknumber(L, 2);
			audioSource.SetScheduledEndTime(scheduledEndTime);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Stop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			audioSource.Stop();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Pause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			audioSource.Pause();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnPause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			audioSource.UnPause();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayOneShot(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(AudioSource), typeof(AudioClip)))
			{
				AudioSource audioSource = (AudioSource)ToLua.ToObject(L, 1);
				AudioClip clip = (AudioClip)ToLua.ToObject(L, 2);
				audioSource.PlayOneShot(clip);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(AudioSource), typeof(AudioClip), typeof(float)))
			{
				AudioSource audioSource2 = (AudioSource)ToLua.ToObject(L, 1);
				AudioClip clip2 = (AudioClip)ToLua.ToObject(L, 2);
				float volumeScale = (float)LuaDLL.lua_tonumber(L, 3);
				audioSource2.PlayOneShot(clip2, volumeScale);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AudioSource.PlayOneShot");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayClipAtPoint(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(AudioClip), typeof(Vector3)))
			{
				AudioClip clip = (AudioClip)ToLua.ToObject(L, 1);
				Vector3 position = ToLua.ToVector3(L, 2);
				AudioSource.PlayClipAtPoint(clip, position);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(AudioClip), typeof(Vector3), typeof(float)))
			{
				AudioClip clip2 = (AudioClip)ToLua.ToObject(L, 1);
				Vector3 position2 = ToLua.ToVector3(L, 2);
				float volume = (float)LuaDLL.lua_tonumber(L, 3);
				AudioSource.PlayClipAtPoint(clip2, position2, volume);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AudioSource.PlayClipAtPoint");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetCustomCurve(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			AudioSourceCurveType type = (AudioSourceCurveType)((int)ToLua.CheckObject(L, 2, typeof(AudioSourceCurveType)));
			AnimationCurve curve = (AnimationCurve)ToLua.CheckObject(L, 3, typeof(AnimationCurve));
			audioSource.SetCustomCurve(type, curve);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCustomCurve(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			AudioSourceCurveType type = (AudioSourceCurveType)((int)ToLua.CheckObject(L, 2, typeof(AudioSourceCurveType)));
			AnimationCurve customCurve = audioSource.GetCustomCurve(type);
			ToLua.PushObject(L, customCurve);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetOutputData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			float[] samples = ToLua.CheckNumberArray<float>(L, 2);
			int channel = (int)LuaDLL.luaL_checknumber(L, 3);
			audioSource.GetOutputData(samples, channel);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSpectrumData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			float[] samples = ToLua.CheckNumberArray<float>(L, 2);
			int channel = (int)LuaDLL.luaL_checknumber(L, 3);
			FFTWindow window = (FFTWindow)((int)ToLua.CheckObject(L, 4, typeof(FFTWindow)));
			audioSource.GetSpectrumData(samples, channel, window);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetSpatializerFloat(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			float value = (float)LuaDLL.luaL_checknumber(L, 3);
			bool value2 = audioSource.SetSpatializerFloat(index, value);
			LuaDLL.lua_pushboolean(L, value2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSpatializerFloat(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AudioSource audioSource = (AudioSource)ToLua.CheckObject(L, 1, typeof(AudioSource));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			float num;
			bool spatializerFloat = audioSource.GetSpatializerFloat(index, out num);
			LuaDLL.lua_pushboolean(L, spatializerFloat);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 2;
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_volume(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float volume = audioSource.volume;
			LuaDLL.lua_pushnumber(L, (double)volume);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index volume on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pitch(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float pitch = audioSource.pitch;
			LuaDLL.lua_pushnumber(L, (double)pitch);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pitch on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_time(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float time = audioSource.time;
			LuaDLL.lua_pushnumber(L, (double)time);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index time on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_timeSamples(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			int timeSamples = audioSource.timeSamples;
			LuaDLL.lua_pushinteger(L, timeSamples);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index timeSamples on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			AudioClip clip = audioSource.clip;
			ToLua.Push(L, clip);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_outputAudioMixerGroup(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			AudioMixerGroup outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
			ToLua.Push(L, outputAudioMixerGroup);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index outputAudioMixerGroup on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPlaying(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool isPlaying = audioSource.isPlaying;
			LuaDLL.lua_pushboolean(L, isPlaying);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isPlaying on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_loop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool loop = audioSource.loop;
			LuaDLL.lua_pushboolean(L, loop);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index loop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ignoreListenerVolume(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool ignoreListenerVolume = audioSource.ignoreListenerVolume;
			LuaDLL.lua_pushboolean(L, ignoreListenerVolume);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreListenerVolume on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playOnAwake(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool playOnAwake = audioSource.playOnAwake;
			LuaDLL.lua_pushboolean(L, playOnAwake);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playOnAwake on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ignoreListenerPause(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool ignoreListenerPause = audioSource.ignoreListenerPause;
			LuaDLL.lua_pushboolean(L, ignoreListenerPause);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreListenerPause on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_velocityUpdateMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			AudioVelocityUpdateMode velocityUpdateMode = audioSource.velocityUpdateMode;
			ToLua.Push(L, velocityUpdateMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index velocityUpdateMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_panStereo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float panStereo = audioSource.panStereo;
			LuaDLL.lua_pushnumber(L, (double)panStereo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index panStereo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spatialBlend(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float spatialBlend = audioSource.spatialBlend;
			LuaDLL.lua_pushnumber(L, (double)spatialBlend);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spatialBlend on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spatialize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool spatialize = audioSource.spatialize;
			LuaDLL.lua_pushboolean(L, spatialize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spatialize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_reverbZoneMix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float reverbZoneMix = audioSource.reverbZoneMix;
			LuaDLL.lua_pushnumber(L, (double)reverbZoneMix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index reverbZoneMix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bypassEffects(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool bypassEffects = audioSource.bypassEffects;
			LuaDLL.lua_pushboolean(L, bypassEffects);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bypassEffects on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bypassListenerEffects(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool bypassListenerEffects = audioSource.bypassListenerEffects;
			LuaDLL.lua_pushboolean(L, bypassListenerEffects);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bypassListenerEffects on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bypassReverbZones(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool bypassReverbZones = audioSource.bypassReverbZones;
			LuaDLL.lua_pushboolean(L, bypassReverbZones);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bypassReverbZones on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dopplerLevel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float dopplerLevel = audioSource.dopplerLevel;
			LuaDLL.lua_pushnumber(L, (double)dopplerLevel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dopplerLevel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spread(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float spread = audioSource.spread;
			LuaDLL.lua_pushnumber(L, (double)spread);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spread on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_priority(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			int priority = audioSource.priority;
			LuaDLL.lua_pushinteger(L, priority);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index priority on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mute(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool mute = audioSource.mute;
			LuaDLL.lua_pushboolean(L, mute);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mute on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float minDistance = audioSource.minDistance;
			LuaDLL.lua_pushnumber(L, (double)minDistance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float maxDistance = audioSource.maxDistance;
			LuaDLL.lua_pushnumber(L, (double)maxDistance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rolloffMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			AudioRolloffMode rolloffMode = audioSource.rolloffMode;
			ToLua.Push(L, rolloffMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rolloffMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_volume(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float volume = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.volume = volume;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index volume on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pitch(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float pitch = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.pitch = pitch;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pitch on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_time(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float time = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.time = time;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index time on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_timeSamples(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			int timeSamples = (int)LuaDLL.luaL_checknumber(L, 2);
			audioSource.timeSamples = timeSamples;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index timeSamples on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			AudioClip clip = (AudioClip)ToLua.CheckUnityObject(L, 2, typeof(AudioClip));
			audioSource.clip = clip;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_outputAudioMixerGroup(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			AudioMixerGroup outputAudioMixerGroup = (AudioMixerGroup)ToLua.CheckUnityObject(L, 2, typeof(AudioMixerGroup));
			audioSource.outputAudioMixerGroup = outputAudioMixerGroup;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index outputAudioMixerGroup on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_loop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool loop = LuaDLL.luaL_checkboolean(L, 2);
			audioSource.loop = loop;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index loop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ignoreListenerVolume(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool ignoreListenerVolume = LuaDLL.luaL_checkboolean(L, 2);
			audioSource.ignoreListenerVolume = ignoreListenerVolume;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreListenerVolume on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playOnAwake(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool playOnAwake = LuaDLL.luaL_checkboolean(L, 2);
			audioSource.playOnAwake = playOnAwake;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playOnAwake on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ignoreListenerPause(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool ignoreListenerPause = LuaDLL.luaL_checkboolean(L, 2);
			audioSource.ignoreListenerPause = ignoreListenerPause;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreListenerPause on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_velocityUpdateMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			AudioVelocityUpdateMode velocityUpdateMode = (AudioVelocityUpdateMode)((int)ToLua.CheckObject(L, 2, typeof(AudioVelocityUpdateMode)));
			audioSource.velocityUpdateMode = velocityUpdateMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index velocityUpdateMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_panStereo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float panStereo = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.panStereo = panStereo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index panStereo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spatialBlend(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float spatialBlend = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.spatialBlend = spatialBlend;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spatialBlend on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spatialize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool spatialize = LuaDLL.luaL_checkboolean(L, 2);
			audioSource.spatialize = spatialize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spatialize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_reverbZoneMix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float reverbZoneMix = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.reverbZoneMix = reverbZoneMix;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index reverbZoneMix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bypassEffects(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool bypassEffects = LuaDLL.luaL_checkboolean(L, 2);
			audioSource.bypassEffects = bypassEffects;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bypassEffects on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bypassListenerEffects(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool bypassListenerEffects = LuaDLL.luaL_checkboolean(L, 2);
			audioSource.bypassListenerEffects = bypassListenerEffects;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bypassListenerEffects on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bypassReverbZones(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool bypassReverbZones = LuaDLL.luaL_checkboolean(L, 2);
			audioSource.bypassReverbZones = bypassReverbZones;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bypassReverbZones on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dopplerLevel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float dopplerLevel = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.dopplerLevel = dopplerLevel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dopplerLevel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spread(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float spread = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.spread = spread;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spread on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_priority(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			int priority = (int)LuaDLL.luaL_checknumber(L, 2);
			audioSource.priority = priority;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index priority on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mute(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			bool mute = LuaDLL.luaL_checkboolean(L, 2);
			audioSource.mute = mute;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mute on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_minDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float minDistance = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.minDistance = minDistance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			float maxDistance = (float)LuaDLL.luaL_checknumber(L, 2);
			audioSource.maxDistance = maxDistance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rolloffMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioSource audioSource = (AudioSource)obj;
			AudioRolloffMode rolloffMode = (AudioRolloffMode)((int)ToLua.CheckObject(L, 2, typeof(AudioRolloffMode)));
			audioSource.rolloffMode = rolloffMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rolloffMode on a nil value");
		}
		return result;
	}
}
