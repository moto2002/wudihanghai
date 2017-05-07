using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnityEngine_UI_ImageWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Image), typeof(MaskableGraphic), null);
		L.RegFunction("OnBeforeSerialize", new LuaCSFunction(UnityEngine_UI_ImageWrap.OnBeforeSerialize));
		L.RegFunction("OnAfterDeserialize", new LuaCSFunction(UnityEngine_UI_ImageWrap.OnAfterDeserialize));
		L.RegFunction("SetNativeSize", new LuaCSFunction(UnityEngine_UI_ImageWrap.SetNativeSize));
		L.RegFunction("CalculateLayoutInputHorizontal", new LuaCSFunction(UnityEngine_UI_ImageWrap.CalculateLayoutInputHorizontal));
		L.RegFunction("CalculateLayoutInputVertical", new LuaCSFunction(UnityEngine_UI_ImageWrap.CalculateLayoutInputVertical));
		L.RegFunction("IsRaycastLocationValid", new LuaCSFunction(UnityEngine_UI_ImageWrap.IsRaycastLocationValid));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_ImageWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("sprite", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_sprite), new LuaCSFunction(UnityEngine_UI_ImageWrap.set_sprite));
		L.RegVar("overrideSprite", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_overrideSprite), new LuaCSFunction(UnityEngine_UI_ImageWrap.set_overrideSprite));
		L.RegVar("type", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_type), new LuaCSFunction(UnityEngine_UI_ImageWrap.set_type));
		L.RegVar("preserveAspect", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_preserveAspect), new LuaCSFunction(UnityEngine_UI_ImageWrap.set_preserveAspect));
		L.RegVar("fillCenter", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_fillCenter), new LuaCSFunction(UnityEngine_UI_ImageWrap.set_fillCenter));
		L.RegVar("fillMethod", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_fillMethod), new LuaCSFunction(UnityEngine_UI_ImageWrap.set_fillMethod));
		L.RegVar("fillAmount", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_fillAmount), new LuaCSFunction(UnityEngine_UI_ImageWrap.set_fillAmount));
		L.RegVar("fillClockwise", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_fillClockwise), new LuaCSFunction(UnityEngine_UI_ImageWrap.set_fillClockwise));
		L.RegVar("fillOrigin", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_fillOrigin), new LuaCSFunction(UnityEngine_UI_ImageWrap.set_fillOrigin));
		L.RegVar("eventAlphaThreshold", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_eventAlphaThreshold), new LuaCSFunction(UnityEngine_UI_ImageWrap.set_eventAlphaThreshold));
		L.RegVar("mainTexture", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_mainTexture), null);
		L.RegVar("hasBorder", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_hasBorder), null);
		L.RegVar("pixelsPerUnit", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_pixelsPerUnit), null);
		L.RegVar("minWidth", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_minWidth), null);
		L.RegVar("preferredWidth", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_preferredWidth), null);
		L.RegVar("flexibleWidth", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_flexibleWidth), null);
		L.RegVar("minHeight", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_minHeight), null);
		L.RegVar("preferredHeight", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_preferredHeight), null);
		L.RegVar("flexibleHeight", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_flexibleHeight), null);
		L.RegVar("layoutPriority", new LuaCSFunction(UnityEngine_UI_ImageWrap.get_layoutPriority), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnBeforeSerialize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Image image = (Image)ToLua.CheckObject(L, 1, typeof(Image));
			image.OnBeforeSerialize();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnAfterDeserialize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Image image = (Image)ToLua.CheckObject(L, 1, typeof(Image));
			image.OnAfterDeserialize();
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
			Image image = (Image)ToLua.CheckObject(L, 1, typeof(Image));
			image.SetNativeSize();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateLayoutInputHorizontal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Image image = (Image)ToLua.CheckObject(L, 1, typeof(Image));
			image.CalculateLayoutInputHorizontal();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateLayoutInputVertical(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Image image = (Image)ToLua.CheckObject(L, 1, typeof(Image));
			image.CalculateLayoutInputVertical();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsRaycastLocationValid(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Image image = (Image)ToLua.CheckObject(L, 1, typeof(Image));
			Vector2 screenPoint = ToLua.ToVector2(L, 2);
			Camera eventCamera = (Camera)ToLua.CheckUnityObject(L, 3, typeof(Camera));
			bool value = image.IsRaycastLocationValid(screenPoint, eventCamera);
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
	private static int get_sprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			Sprite sprite = image.sprite;
			ToLua.Push(L, sprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_overrideSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			Sprite overrideSprite = image.overrideSprite;
			ToLua.Push(L, overrideSprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index overrideSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_type(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			Image.Type type = image.type;
			ToLua.Push(L, type);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index type on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_preserveAspect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			bool preserveAspect = image.preserveAspect;
			LuaDLL.lua_pushboolean(L, preserveAspect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index preserveAspect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			bool fillCenter = image.fillCenter;
			LuaDLL.lua_pushboolean(L, fillCenter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillMethod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			Image.FillMethod fillMethod = image.fillMethod;
			ToLua.Push(L, fillMethod);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillMethod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillAmount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float fillAmount = image.fillAmount;
			LuaDLL.lua_pushnumber(L, (double)fillAmount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillAmount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillClockwise(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			bool fillClockwise = image.fillClockwise;
			LuaDLL.lua_pushboolean(L, fillClockwise);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillClockwise on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillOrigin(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			int fillOrigin = image.fillOrigin;
			LuaDLL.lua_pushinteger(L, fillOrigin);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillOrigin on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventAlphaThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float eventAlphaThreshold = image.eventAlphaThreshold;
			LuaDLL.lua_pushnumber(L, (double)eventAlphaThreshold);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventAlphaThreshold on a nil value");
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
			Image image = (Image)obj;
			Texture mainTexture = image.mainTexture;
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
	private static int get_hasBorder(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			bool hasBorder = image.hasBorder;
			LuaDLL.lua_pushboolean(L, hasBorder);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasBorder on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelsPerUnit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float pixelsPerUnit = image.pixelsPerUnit;
			LuaDLL.lua_pushnumber(L, (double)pixelsPerUnit);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelsPerUnit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float minWidth = image.minWidth;
			LuaDLL.lua_pushnumber(L, (double)minWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_preferredWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float preferredWidth = image.preferredWidth;
			LuaDLL.lua_pushnumber(L, (double)preferredWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index preferredWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_flexibleWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float flexibleWidth = image.flexibleWidth;
			LuaDLL.lua_pushnumber(L, (double)flexibleWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index flexibleWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float minHeight = image.minHeight;
			LuaDLL.lua_pushnumber(L, (double)minHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_preferredHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float preferredHeight = image.preferredHeight;
			LuaDLL.lua_pushnumber(L, (double)preferredHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index preferredHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_flexibleHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float flexibleHeight = image.flexibleHeight;
			LuaDLL.lua_pushnumber(L, (double)flexibleHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index flexibleHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_layoutPriority(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			int layoutPriority = image.layoutPriority;
			LuaDLL.lua_pushinteger(L, layoutPriority);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layoutPriority on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			Sprite sprite = (Sprite)ToLua.CheckUnityObject(L, 2, typeof(Sprite));
			image.sprite = sprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_overrideSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			Sprite overrideSprite = (Sprite)ToLua.CheckUnityObject(L, 2, typeof(Sprite));
			image.overrideSprite = overrideSprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index overrideSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_type(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			Image.Type type = (Image.Type)((int)ToLua.CheckObject(L, 2, typeof(Image.Type)));
			image.type = type;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index type on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_preserveAspect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			bool preserveAspect = LuaDLL.luaL_checkboolean(L, 2);
			image.preserveAspect = preserveAspect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index preserveAspect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			bool fillCenter = LuaDLL.luaL_checkboolean(L, 2);
			image.fillCenter = fillCenter;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillMethod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			Image.FillMethod fillMethod = (Image.FillMethod)((int)ToLua.CheckObject(L, 2, typeof(Image.FillMethod)));
			image.fillMethod = fillMethod;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillMethod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillAmount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float fillAmount = (float)LuaDLL.luaL_checknumber(L, 2);
			image.fillAmount = fillAmount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillAmount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillClockwise(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			bool fillClockwise = LuaDLL.luaL_checkboolean(L, 2);
			image.fillClockwise = fillClockwise;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillClockwise on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillOrigin(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			int fillOrigin = (int)LuaDLL.luaL_checknumber(L, 2);
			image.fillOrigin = fillOrigin;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillOrigin on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventAlphaThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Image image = (Image)obj;
			float eventAlphaThreshold = (float)LuaDLL.luaL_checknumber(L, 2);
			image.eventAlphaThreshold = eventAlphaThreshold;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventAlphaThreshold on a nil value");
		}
		return result;
	}
}
