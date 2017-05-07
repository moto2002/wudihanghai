using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnityEngine_UI_RawImageWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(RawImage), typeof(MaskableGraphic), null);
		L.RegFunction("SetNativeSize", new LuaCSFunction(UnityEngine_UI_RawImageWrap.SetNativeSize));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_RawImageWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("mainTexture", new LuaCSFunction(UnityEngine_UI_RawImageWrap.get_mainTexture), null);
		L.RegVar("texture", new LuaCSFunction(UnityEngine_UI_RawImageWrap.get_texture), new LuaCSFunction(UnityEngine_UI_RawImageWrap.set_texture));
		L.RegVar("uvRect", new LuaCSFunction(UnityEngine_UI_RawImageWrap.get_uvRect), new LuaCSFunction(UnityEngine_UI_RawImageWrap.set_uvRect));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetNativeSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RawImage rawImage = (RawImage)ToLua.CheckObject(L, 1, typeof(RawImage));
			rawImage.SetNativeSize();
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RawImage rawImage = (RawImage)obj;
			Texture mainTexture = rawImage.mainTexture;
			ToLua.Push(L, mainTexture);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mainTexture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_texture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RawImage rawImage = (RawImage)obj;
			Texture texture = rawImage.texture;
			ToLua.Push(L, texture);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index texture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_uvRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RawImage rawImage = (RawImage)obj;
			Rect uvRect = rawImage.uvRect;
			ToLua.PushValue(L, uvRect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uvRect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_texture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RawImage rawImage = (RawImage)obj;
			Texture texture = (Texture)ToLua.CheckUnityObject(L, 2, typeof(Texture));
			rawImage.texture = texture;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index texture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_uvRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RawImage rawImage = (RawImage)obj;
			Rect uvRect = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			rawImage.uvRect = uvRect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uvRect on a nil value");
		}
		return result;
	}
}
