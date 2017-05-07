using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnityEngine_UI_TextWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Text), typeof(MaskableGraphic), null);
		L.RegFunction("FontTextureChanged", new LuaCSFunction(UnityEngine_UI_TextWrap.FontTextureChanged));
		L.RegFunction("GetGenerationSettings", new LuaCSFunction(UnityEngine_UI_TextWrap.GetGenerationSettings));
		L.RegFunction("GetTextAnchorPivot", new LuaCSFunction(UnityEngine_UI_TextWrap.GetTextAnchorPivot));
		L.RegFunction("CalculateLayoutInputHorizontal", new LuaCSFunction(UnityEngine_UI_TextWrap.CalculateLayoutInputHorizontal));
		L.RegFunction("CalculateLayoutInputVertical", new LuaCSFunction(UnityEngine_UI_TextWrap.CalculateLayoutInputVertical));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_TextWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("cachedTextGenerator", new LuaCSFunction(UnityEngine_UI_TextWrap.get_cachedTextGenerator), null);
		L.RegVar("cachedTextGeneratorForLayout", new LuaCSFunction(UnityEngine_UI_TextWrap.get_cachedTextGeneratorForLayout), null);
		L.RegVar("mainTexture", new LuaCSFunction(UnityEngine_UI_TextWrap.get_mainTexture), null);
		L.RegVar("font", new LuaCSFunction(UnityEngine_UI_TextWrap.get_font), new LuaCSFunction(UnityEngine_UI_TextWrap.set_font));
		L.RegVar("text", new LuaCSFunction(UnityEngine_UI_TextWrap.get_text), new LuaCSFunction(UnityEngine_UI_TextWrap.set_text));
		L.RegVar("supportRichText", new LuaCSFunction(UnityEngine_UI_TextWrap.get_supportRichText), new LuaCSFunction(UnityEngine_UI_TextWrap.set_supportRichText));
		L.RegVar("resizeTextForBestFit", new LuaCSFunction(UnityEngine_UI_TextWrap.get_resizeTextForBestFit), new LuaCSFunction(UnityEngine_UI_TextWrap.set_resizeTextForBestFit));
		L.RegVar("resizeTextMinSize", new LuaCSFunction(UnityEngine_UI_TextWrap.get_resizeTextMinSize), new LuaCSFunction(UnityEngine_UI_TextWrap.set_resizeTextMinSize));
		L.RegVar("resizeTextMaxSize", new LuaCSFunction(UnityEngine_UI_TextWrap.get_resizeTextMaxSize), new LuaCSFunction(UnityEngine_UI_TextWrap.set_resizeTextMaxSize));
		L.RegVar("alignment", new LuaCSFunction(UnityEngine_UI_TextWrap.get_alignment), new LuaCSFunction(UnityEngine_UI_TextWrap.set_alignment));
		L.RegVar("fontSize", new LuaCSFunction(UnityEngine_UI_TextWrap.get_fontSize), new LuaCSFunction(UnityEngine_UI_TextWrap.set_fontSize));
		L.RegVar("horizontalOverflow", new LuaCSFunction(UnityEngine_UI_TextWrap.get_horizontalOverflow), new LuaCSFunction(UnityEngine_UI_TextWrap.set_horizontalOverflow));
		L.RegVar("verticalOverflow", new LuaCSFunction(UnityEngine_UI_TextWrap.get_verticalOverflow), new LuaCSFunction(UnityEngine_UI_TextWrap.set_verticalOverflow));
		L.RegVar("lineSpacing", new LuaCSFunction(UnityEngine_UI_TextWrap.get_lineSpacing), new LuaCSFunction(UnityEngine_UI_TextWrap.set_lineSpacing));
		L.RegVar("fontStyle", new LuaCSFunction(UnityEngine_UI_TextWrap.get_fontStyle), new LuaCSFunction(UnityEngine_UI_TextWrap.set_fontStyle));
		L.RegVar("pixelsPerUnit", new LuaCSFunction(UnityEngine_UI_TextWrap.get_pixelsPerUnit), null);
		L.RegVar("minWidth", new LuaCSFunction(UnityEngine_UI_TextWrap.get_minWidth), null);
		L.RegVar("preferredWidth", new LuaCSFunction(UnityEngine_UI_TextWrap.get_preferredWidth), null);
		L.RegVar("flexibleWidth", new LuaCSFunction(UnityEngine_UI_TextWrap.get_flexibleWidth), null);
		L.RegVar("minHeight", new LuaCSFunction(UnityEngine_UI_TextWrap.get_minHeight), null);
		L.RegVar("preferredHeight", new LuaCSFunction(UnityEngine_UI_TextWrap.get_preferredHeight), null);
		L.RegVar("flexibleHeight", new LuaCSFunction(UnityEngine_UI_TextWrap.get_flexibleHeight), null);
		L.RegVar("layoutPriority", new LuaCSFunction(UnityEngine_UI_TextWrap.get_layoutPriority), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FontTextureChanged(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Text text = (Text)ToLua.CheckObject(L, 1, typeof(Text));
			text.FontTextureChanged();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetGenerationSettings(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Text text = (Text)ToLua.CheckObject(L, 1, typeof(Text));
			Vector2 extents = ToLua.ToVector2(L, 2);
			TextGenerationSettings generationSettings = text.GetGenerationSettings(extents);
			ToLua.PushValue(L, generationSettings);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTextAnchorPivot(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TextAnchor anchor = (TextAnchor)((int)ToLua.CheckObject(L, 1, typeof(TextAnchor)));
			Vector2 textAnchorPivot = Text.GetTextAnchorPivot(anchor);
			ToLua.Push(L, textAnchorPivot);
			result = 1;
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
			Text text = (Text)ToLua.CheckObject(L, 1, typeof(Text));
			text.CalculateLayoutInputHorizontal();
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
			Text text = (Text)ToLua.CheckObject(L, 1, typeof(Text));
			text.CalculateLayoutInputVertical();
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
	private static int get_cachedTextGenerator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			TextGenerator cachedTextGenerator = text.cachedTextGenerator;
			ToLua.PushObject(L, cachedTextGenerator);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cachedTextGenerator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedTextGeneratorForLayout(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			TextGenerator cachedTextGeneratorForLayout = text.cachedTextGeneratorForLayout;
			ToLua.PushObject(L, cachedTextGeneratorForLayout);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cachedTextGeneratorForLayout on a nil value");
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
			Text text = (Text)obj;
			Texture mainTexture = text.mainTexture;
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
	private static int get_font(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			Font font = text.font;
			ToLua.Push(L, font);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index font on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_text(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			string text2 = text.text;
			LuaDLL.lua_pushstring(L, text2);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index text on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportRichText(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			bool supportRichText = text.supportRichText;
			LuaDLL.lua_pushboolean(L, supportRichText);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index supportRichText on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resizeTextForBestFit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			bool resizeTextForBestFit = text.resizeTextForBestFit;
			LuaDLL.lua_pushboolean(L, resizeTextForBestFit);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resizeTextForBestFit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resizeTextMinSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			int resizeTextMinSize = text.resizeTextMinSize;
			LuaDLL.lua_pushinteger(L, resizeTextMinSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resizeTextMinSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resizeTextMaxSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			int resizeTextMaxSize = text.resizeTextMaxSize;
			LuaDLL.lua_pushinteger(L, resizeTextMaxSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resizeTextMaxSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			TextAnchor alignment = text.alignment;
			ToLua.Push(L, alignment);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alignment on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			int fontSize = text.fontSize;
			LuaDLL.lua_pushinteger(L, fontSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horizontalOverflow(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			HorizontalWrapMode horizontalOverflow = text.horizontalOverflow;
			ToLua.Push(L, horizontalOverflow);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizontalOverflow on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_verticalOverflow(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			VerticalWrapMode verticalOverflow = text.verticalOverflow;
			ToLua.Push(L, verticalOverflow);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verticalOverflow on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lineSpacing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			float lineSpacing = text.lineSpacing;
			LuaDLL.lua_pushnumber(L, (double)lineSpacing);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lineSpacing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			FontStyle fontStyle = text.fontStyle;
			ToLua.Push(L, fontStyle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontStyle on a nil value");
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
			Text text = (Text)obj;
			float pixelsPerUnit = text.pixelsPerUnit;
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
			Text text = (Text)obj;
			float minWidth = text.minWidth;
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
			Text text = (Text)obj;
			float preferredWidth = text.preferredWidth;
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
			Text text = (Text)obj;
			float flexibleWidth = text.flexibleWidth;
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
			Text text = (Text)obj;
			float minHeight = text.minHeight;
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
			Text text = (Text)obj;
			float preferredHeight = text.preferredHeight;
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
			Text text = (Text)obj;
			float flexibleHeight = text.flexibleHeight;
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
			Text text = (Text)obj;
			int layoutPriority = text.layoutPriority;
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
	private static int set_font(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			Font font = (Font)ToLua.CheckUnityObject(L, 2, typeof(Font));
			text.font = font;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index font on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_text(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			string text2 = ToLua.CheckString(L, 2);
			text.text = text2;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index text on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_supportRichText(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			bool supportRichText = LuaDLL.luaL_checkboolean(L, 2);
			text.supportRichText = supportRichText;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index supportRichText on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_resizeTextForBestFit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			bool resizeTextForBestFit = LuaDLL.luaL_checkboolean(L, 2);
			text.resizeTextForBestFit = resizeTextForBestFit;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resizeTextForBestFit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_resizeTextMinSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			int resizeTextMinSize = (int)LuaDLL.luaL_checknumber(L, 2);
			text.resizeTextMinSize = resizeTextMinSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resizeTextMinSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_resizeTextMaxSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			int resizeTextMaxSize = (int)LuaDLL.luaL_checknumber(L, 2);
			text.resizeTextMaxSize = resizeTextMaxSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resizeTextMaxSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			TextAnchor alignment = (TextAnchor)((int)ToLua.CheckObject(L, 2, typeof(TextAnchor)));
			text.alignment = alignment;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alignment on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			int fontSize = (int)LuaDLL.luaL_checknumber(L, 2);
			text.fontSize = fontSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horizontalOverflow(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			HorizontalWrapMode horizontalOverflow = (HorizontalWrapMode)((int)ToLua.CheckObject(L, 2, typeof(HorizontalWrapMode)));
			text.horizontalOverflow = horizontalOverflow;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizontalOverflow on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_verticalOverflow(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			VerticalWrapMode verticalOverflow = (VerticalWrapMode)((int)ToLua.CheckObject(L, 2, typeof(VerticalWrapMode)));
			text.verticalOverflow = verticalOverflow;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verticalOverflow on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lineSpacing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			float lineSpacing = (float)LuaDLL.luaL_checknumber(L, 2);
			text.lineSpacing = lineSpacing;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lineSpacing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Text text = (Text)obj;
			FontStyle fontStyle = (FontStyle)((int)ToLua.CheckObject(L, 2, typeof(FontStyle)));
			text.fontStyle = fontStyle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontStyle on a nil value");
		}
		return result;
	}
}
