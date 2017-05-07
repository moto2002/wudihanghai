using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnityEngine_UI_LayoutGroupWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LayoutGroup), typeof(UIBehaviour), null);
		L.RegFunction("CalculateLayoutInputHorizontal", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.CalculateLayoutInputHorizontal));
		L.RegFunction("CalculateLayoutInputVertical", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.CalculateLayoutInputVertical));
		L.RegFunction("SetLayoutHorizontal", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.SetLayoutHorizontal));
		L.RegFunction("SetLayoutVertical", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.SetLayoutVertical));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("padding", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.get_padding), new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.set_padding));
		L.RegVar("childAlignment", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.get_childAlignment), new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.set_childAlignment));
		L.RegVar("minWidth", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.get_minWidth), null);
		L.RegVar("preferredWidth", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.get_preferredWidth), null);
		L.RegVar("flexibleWidth", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.get_flexibleWidth), null);
		L.RegVar("minHeight", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.get_minHeight), null);
		L.RegVar("preferredHeight", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.get_preferredHeight), null);
		L.RegVar("flexibleHeight", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.get_flexibleHeight), null);
		L.RegVar("layoutPriority", new LuaCSFunction(UnityEngine_UI_LayoutGroupWrap.get_layoutPriority), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateLayoutInputHorizontal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LayoutGroup layoutGroup = (LayoutGroup)ToLua.CheckObject(L, 1, typeof(LayoutGroup));
			layoutGroup.CalculateLayoutInputHorizontal();
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
			LayoutGroup layoutGroup = (LayoutGroup)ToLua.CheckObject(L, 1, typeof(LayoutGroup));
			layoutGroup.CalculateLayoutInputVertical();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayoutHorizontal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LayoutGroup layoutGroup = (LayoutGroup)ToLua.CheckObject(L, 1, typeof(LayoutGroup));
			layoutGroup.SetLayoutHorizontal();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayoutVertical(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LayoutGroup layoutGroup = (LayoutGroup)ToLua.CheckObject(L, 1, typeof(LayoutGroup));
			layoutGroup.SetLayoutVertical();
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
	private static int get_padding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			RectOffset padding = layoutGroup.padding;
			ToLua.PushObject(L, padding);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index padding on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_childAlignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			TextAnchor childAlignment = layoutGroup.childAlignment;
			ToLua.Push(L, childAlignment);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index childAlignment on a nil value");
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
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			float minWidth = layoutGroup.minWidth;
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
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			float preferredWidth = layoutGroup.preferredWidth;
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
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			float flexibleWidth = layoutGroup.flexibleWidth;
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
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			float minHeight = layoutGroup.minHeight;
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
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			float preferredHeight = layoutGroup.preferredHeight;
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
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			float flexibleHeight = layoutGroup.flexibleHeight;
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
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			int layoutPriority = layoutGroup.layoutPriority;
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
	private static int set_padding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			RectOffset padding = (RectOffset)ToLua.CheckObject(L, 2, typeof(RectOffset));
			layoutGroup.padding = padding;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index padding on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_childAlignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LayoutGroup layoutGroup = (LayoutGroup)obj;
			TextAnchor childAlignment = (TextAnchor)((int)ToLua.CheckObject(L, 2, typeof(TextAnchor)));
			layoutGroup.childAlignment = childAlignment;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index childAlignment on a nil value");
		}
		return result;
	}
}
