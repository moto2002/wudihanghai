using Hummingbird.SeaBattle.Utility.FNScrollRect;
using LuaInterface;
using System;
using UnityEngine;

public class Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FNScrollView), typeof(MonoBehaviour), null);
		L.RegFunction("InitScrollView", new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.InitScrollView));
		L.RegFunction("AddCell", new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.AddCell));
		L.RegFunction("IsAtBottom", new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.IsAtBottom));
		L.RegFunction("SetAtBottomCallback", new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.SetAtBottomCallback));
		L.RegFunction("__eq", new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("transViewCell", new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.get_transViewCell), new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.set_transViewCell));
		L.RegVar("cellHeight", new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.get_cellHeight), new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.set_cellHeight));
		L.RegVar("moveTime", new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.get_moveTime), new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.set_moveTime));
		L.RegVar("maxCount", new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.get_maxCount), new LuaCSFunction(Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.set_maxCount));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitScrollView(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			FNScrollView fNScrollView = (FNScrollView)ToLua.CheckObject(L, 1, typeof(FNScrollView));
			int totalCount = (int)LuaDLL.luaL_checknumber(L, 2);
			int nStartCell = (int)LuaDLL.luaL_checknumber(L, 3);
			string cellName = ToLua.CheckString(L, 4);
			fNScrollView.InitScrollView(totalCount, nStartCell, cellName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddCell(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			FNScrollView fNScrollView = (FNScrollView)ToLua.CheckObject(L, 1, typeof(FNScrollView));
			int addCount = (int)LuaDLL.luaL_checknumber(L, 2);
			bool needMoveDown = LuaDLL.luaL_checkboolean(L, 3);
			bool isShowAnimation = LuaDLL.luaL_checkboolean(L, 4);
			fNScrollView.AddCell(addCount, needMoveDown, isShowAnimation);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsAtBottom(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FNScrollView fNScrollView = (FNScrollView)ToLua.CheckObject(L, 1, typeof(FNScrollView));
			bool value = fNScrollView.IsAtBottom();
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
	private static int SetAtBottomCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FNScrollView fNScrollView = (FNScrollView)ToLua.CheckObject(L, 1, typeof(FNScrollView));
			LuaFunction atBottomCallback = ToLua.CheckLuaFunction(L, 2);
			fNScrollView.SetAtBottomCallback(atBottomCallback);
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
	private static int get_transViewCell(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FNScrollView fNScrollView = (FNScrollView)obj;
			Transform transViewCell = fNScrollView.transViewCell;
			ToLua.Push(L, transViewCell);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index transViewCell on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cellHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FNScrollView fNScrollView = (FNScrollView)obj;
			float cellHeight = fNScrollView.cellHeight;
			LuaDLL.lua_pushnumber(L, (double)cellHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cellHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_moveTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FNScrollView fNScrollView = (FNScrollView)obj;
			float moveTime = fNScrollView.moveTime;
			LuaDLL.lua_pushnumber(L, (double)moveTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index moveTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FNScrollView fNScrollView = (FNScrollView)obj;
			int maxCount = fNScrollView.maxCount;
			LuaDLL.lua_pushinteger(L, maxCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_transViewCell(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FNScrollView fNScrollView = (FNScrollView)obj;
			Transform transViewCell = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			fNScrollView.transViewCell = transViewCell;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index transViewCell on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cellHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FNScrollView fNScrollView = (FNScrollView)obj;
			float cellHeight = (float)LuaDLL.luaL_checknumber(L, 2);
			fNScrollView.cellHeight = cellHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cellHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_moveTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FNScrollView fNScrollView = (FNScrollView)obj;
			float moveTime = (float)LuaDLL.luaL_checknumber(L, 2);
			fNScrollView.moveTime = moveTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index moveTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FNScrollView fNScrollView = (FNScrollView)obj;
			int maxCount = (int)LuaDLL.luaL_checknumber(L, 2);
			fNScrollView.maxCount = maxCount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxCount on a nil value");
		}
		return result;
	}
}
