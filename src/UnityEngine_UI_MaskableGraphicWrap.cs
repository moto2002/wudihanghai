using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnityEngine_UI_MaskableGraphicWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(MaskableGraphic), typeof(Graphic), null);
		L.RegFunction("GetModifiedMaterial", new LuaCSFunction(UnityEngine_UI_MaskableGraphicWrap.GetModifiedMaterial));
		L.RegFunction("Cull", new LuaCSFunction(UnityEngine_UI_MaskableGraphicWrap.Cull));
		L.RegFunction("SetClipRect", new LuaCSFunction(UnityEngine_UI_MaskableGraphicWrap.SetClipRect));
		L.RegFunction("RecalculateClipping", new LuaCSFunction(UnityEngine_UI_MaskableGraphicWrap.RecalculateClipping));
		L.RegFunction("RecalculateMasking", new LuaCSFunction(UnityEngine_UI_MaskableGraphicWrap.RecalculateMasking));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_MaskableGraphicWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("onCullStateChanged", new LuaCSFunction(UnityEngine_UI_MaskableGraphicWrap.get_onCullStateChanged), new LuaCSFunction(UnityEngine_UI_MaskableGraphicWrap.set_onCullStateChanged));
		L.RegVar("maskable", new LuaCSFunction(UnityEngine_UI_MaskableGraphicWrap.get_maskable), new LuaCSFunction(UnityEngine_UI_MaskableGraphicWrap.set_maskable));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetModifiedMaterial(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			MaskableGraphic maskableGraphic = (MaskableGraphic)ToLua.CheckObject(L, 1, typeof(MaskableGraphic));
			Material baseMaterial = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			Material modifiedMaterial = maskableGraphic.GetModifiedMaterial(baseMaterial);
			ToLua.Push(L, modifiedMaterial);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Cull(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			MaskableGraphic maskableGraphic = (MaskableGraphic)ToLua.CheckObject(L, 1, typeof(MaskableGraphic));
			Rect clipRect = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			bool validRect = LuaDLL.luaL_checkboolean(L, 3);
			maskableGraphic.Cull(clipRect, validRect);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetClipRect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			MaskableGraphic maskableGraphic = (MaskableGraphic)ToLua.CheckObject(L, 1, typeof(MaskableGraphic));
			Rect clipRect = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			bool validRect = LuaDLL.luaL_checkboolean(L, 3);
			maskableGraphic.SetClipRect(clipRect, validRect);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RecalculateClipping(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			MaskableGraphic maskableGraphic = (MaskableGraphic)ToLua.CheckObject(L, 1, typeof(MaskableGraphic));
			maskableGraphic.RecalculateClipping();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RecalculateMasking(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			MaskableGraphic maskableGraphic = (MaskableGraphic)ToLua.CheckObject(L, 1, typeof(MaskableGraphic));
			maskableGraphic.RecalculateMasking();
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
	private static int get_onCullStateChanged(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MaskableGraphic maskableGraphic = (MaskableGraphic)obj;
			MaskableGraphic.CullStateChangedEvent onCullStateChanged = maskableGraphic.onCullStateChanged;
			ToLua.PushObject(L, onCullStateChanged);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onCullStateChanged on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maskable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MaskableGraphic maskableGraphic = (MaskableGraphic)obj;
			bool maskable = maskableGraphic.maskable;
			LuaDLL.lua_pushboolean(L, maskable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maskable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onCullStateChanged(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MaskableGraphic maskableGraphic = (MaskableGraphic)obj;
			MaskableGraphic.CullStateChangedEvent onCullStateChanged = (MaskableGraphic.CullStateChangedEvent)ToLua.CheckObject(L, 2, typeof(MaskableGraphic.CullStateChangedEvent));
			maskableGraphic.onCullStateChanged = onCullStateChanged;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onCullStateChanged on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maskable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MaskableGraphic maskableGraphic = (MaskableGraphic)obj;
			bool maskable = LuaDLL.luaL_checkboolean(L, 2);
			maskableGraphic.maskable = maskable;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maskable on a nil value");
		}
		return result;
	}
}
