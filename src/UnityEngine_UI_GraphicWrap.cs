using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnityEngine_UI_GraphicWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Graphic), typeof(UIBehaviour), null);
		L.RegFunction("SetAllDirty", new LuaCSFunction(UnityEngine_UI_GraphicWrap.SetAllDirty));
		L.RegFunction("SetLayoutDirty", new LuaCSFunction(UnityEngine_UI_GraphicWrap.SetLayoutDirty));
		L.RegFunction("SetVerticesDirty", new LuaCSFunction(UnityEngine_UI_GraphicWrap.SetVerticesDirty));
		L.RegFunction("SetMaterialDirty", new LuaCSFunction(UnityEngine_UI_GraphicWrap.SetMaterialDirty));
		L.RegFunction("Rebuild", new LuaCSFunction(UnityEngine_UI_GraphicWrap.Rebuild));
		L.RegFunction("LayoutComplete", new LuaCSFunction(UnityEngine_UI_GraphicWrap.LayoutComplete));
		L.RegFunction("GraphicUpdateComplete", new LuaCSFunction(UnityEngine_UI_GraphicWrap.GraphicUpdateComplete));
		L.RegFunction("SetNativeSize", new LuaCSFunction(UnityEngine_UI_GraphicWrap.SetNativeSize));
		L.RegFunction("Raycast", new LuaCSFunction(UnityEngine_UI_GraphicWrap.Raycast));
		L.RegFunction("PixelAdjustPoint", new LuaCSFunction(UnityEngine_UI_GraphicWrap.PixelAdjustPoint));
		L.RegFunction("GetPixelAdjustedRect", new LuaCSFunction(UnityEngine_UI_GraphicWrap.GetPixelAdjustedRect));
		L.RegFunction("CrossFadeColor", new LuaCSFunction(UnityEngine_UI_GraphicWrap.CrossFadeColor));
		L.RegFunction("CrossFadeAlpha", new LuaCSFunction(UnityEngine_UI_GraphicWrap.CrossFadeAlpha));
		L.RegFunction("RegisterDirtyLayoutCallback", new LuaCSFunction(UnityEngine_UI_GraphicWrap.RegisterDirtyLayoutCallback));
		L.RegFunction("UnregisterDirtyLayoutCallback", new LuaCSFunction(UnityEngine_UI_GraphicWrap.UnregisterDirtyLayoutCallback));
		L.RegFunction("RegisterDirtyVerticesCallback", new LuaCSFunction(UnityEngine_UI_GraphicWrap.RegisterDirtyVerticesCallback));
		L.RegFunction("UnregisterDirtyVerticesCallback", new LuaCSFunction(UnityEngine_UI_GraphicWrap.UnregisterDirtyVerticesCallback));
		L.RegFunction("RegisterDirtyMaterialCallback", new LuaCSFunction(UnityEngine_UI_GraphicWrap.RegisterDirtyMaterialCallback));
		L.RegFunction("UnregisterDirtyMaterialCallback", new LuaCSFunction(UnityEngine_UI_GraphicWrap.UnregisterDirtyMaterialCallback));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_GraphicWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("defaultGraphicMaterial", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_defaultGraphicMaterial), null);
		L.RegVar("color", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_color), new LuaCSFunction(UnityEngine_UI_GraphicWrap.set_color));
		L.RegVar("raycastTarget", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_raycastTarget), new LuaCSFunction(UnityEngine_UI_GraphicWrap.set_raycastTarget));
		L.RegVar("depth", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_depth), null);
		L.RegVar("rectTransform", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_rectTransform), null);
		L.RegVar("canvas", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_canvas), null);
		L.RegVar("canvasRenderer", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_canvasRenderer), null);
		L.RegVar("defaultMaterial", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_defaultMaterial), null);
		L.RegVar("material", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_material), new LuaCSFunction(UnityEngine_UI_GraphicWrap.set_material));
		L.RegVar("materialForRendering", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_materialForRendering), null);
		L.RegVar("mainTexture", new LuaCSFunction(UnityEngine_UI_GraphicWrap.get_mainTexture), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAllDirty(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			graphic.SetAllDirty();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayoutDirty(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			graphic.SetLayoutDirty();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetVerticesDirty(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			graphic.SetVerticesDirty();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetMaterialDirty(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			graphic.SetMaterialDirty();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Rebuild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			CanvasUpdate update = (CanvasUpdate)((int)ToLua.CheckObject(L, 2, typeof(CanvasUpdate)));
			graphic.Rebuild(update);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LayoutComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			graphic.LayoutComplete();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GraphicUpdateComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			graphic.GraphicUpdateComplete();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetNativeSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			graphic.SetNativeSize();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Raycast(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			Vector2 sp = ToLua.ToVector2(L, 2);
			Camera eventCamera = (Camera)ToLua.CheckUnityObject(L, 3, typeof(Camera));
			bool value = graphic.Raycast(sp, eventCamera);
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
	private static int PixelAdjustPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			Vector2 point = ToLua.ToVector2(L, 2);
			Vector2 v = graphic.PixelAdjustPoint(point);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPixelAdjustedRect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			Rect pixelAdjustedRect = graphic.GetPixelAdjustedRect();
			ToLua.PushValue(L, pixelAdjustedRect);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CrossFadeColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			Color targetColor = ToLua.ToColor(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			bool ignoreTimeScale = LuaDLL.luaL_checkboolean(L, 4);
			bool useAlpha = LuaDLL.luaL_checkboolean(L, 5);
			graphic.CrossFadeColor(targetColor, duration, ignoreTimeScale, useAlpha);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CrossFadeAlpha(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			float alpha = (float)LuaDLL.luaL_checknumber(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			bool ignoreTimeScale = LuaDLL.luaL_checkboolean(L, 4);
			graphic.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterDirtyLayoutCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UnityAction action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (UnityAction)ToLua.CheckObject(L, 2, typeof(UnityAction));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(UnityAction), func) as UnityAction);
			}
			graphic.RegisterDirtyLayoutCallback(action);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnregisterDirtyLayoutCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UnityAction action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (UnityAction)ToLua.CheckObject(L, 2, typeof(UnityAction));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(UnityAction), func) as UnityAction);
			}
			graphic.UnregisterDirtyLayoutCallback(action);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterDirtyVerticesCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UnityAction action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (UnityAction)ToLua.CheckObject(L, 2, typeof(UnityAction));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(UnityAction), func) as UnityAction);
			}
			graphic.RegisterDirtyVerticesCallback(action);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnregisterDirtyVerticesCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UnityAction action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (UnityAction)ToLua.CheckObject(L, 2, typeof(UnityAction));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(UnityAction), func) as UnityAction);
			}
			graphic.UnregisterDirtyVerticesCallback(action);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterDirtyMaterialCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UnityAction action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (UnityAction)ToLua.CheckObject(L, 2, typeof(UnityAction));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(UnityAction), func) as UnityAction);
			}
			graphic.RegisterDirtyMaterialCallback(action);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnregisterDirtyMaterialCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Graphic graphic = (Graphic)ToLua.CheckObject(L, 1, typeof(Graphic));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UnityAction action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (UnityAction)ToLua.CheckObject(L, 2, typeof(UnityAction));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(UnityAction), func) as UnityAction);
			}
			graphic.UnregisterDirtyMaterialCallback(action);
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
	private static int get_defaultGraphicMaterial(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Graphic.defaultGraphicMaterial);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_color(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			Color color = graphic.color;
			ToLua.Push(L, color);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index color on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_raycastTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			bool raycastTarget = graphic.raycastTarget;
			LuaDLL.lua_pushboolean(L, raycastTarget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index raycastTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			int depth = graphic.depth;
			LuaDLL.lua_pushinteger(L, depth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rectTransform(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			RectTransform rectTransform = graphic.rectTransform;
			ToLua.Push(L, rectTransform);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rectTransform on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canvas(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			Canvas canvas = graphic.canvas;
			ToLua.Push(L, canvas);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canvas on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canvasRenderer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			CanvasRenderer canvasRenderer = graphic.canvasRenderer;
			ToLua.Push(L, canvasRenderer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canvasRenderer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			Material defaultMaterial = graphic.defaultMaterial;
			ToLua.Push(L, defaultMaterial);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultMaterial on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			Material material = graphic.material;
			ToLua.Push(L, material);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_materialForRendering(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			Material materialForRendering = graphic.materialForRendering;
			ToLua.Push(L, materialForRendering);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index materialForRendering on a nil value");
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
			Graphic graphic = (Graphic)obj;
			Texture mainTexture = graphic.mainTexture;
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
	private static int set_color(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			Color color = ToLua.ToColor(L, 2);
			graphic.color = color;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index color on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_raycastTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			bool raycastTarget = LuaDLL.luaL_checkboolean(L, 2);
			graphic.raycastTarget = raycastTarget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index raycastTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Graphic graphic = (Graphic)obj;
			Material material = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			graphic.material = material;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}
}
