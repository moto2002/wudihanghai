using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_BoxColliderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(BoxCollider), typeof(Collider), null);
		L.RegFunction("New", new LuaCSFunction(UnityEngine_BoxColliderWrap._CreateUnityEngine_BoxCollider));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_BoxColliderWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("center", new LuaCSFunction(UnityEngine_BoxColliderWrap.get_center), new LuaCSFunction(UnityEngine_BoxColliderWrap.set_center));
		L.RegVar("size", new LuaCSFunction(UnityEngine_BoxColliderWrap.get_size), new LuaCSFunction(UnityEngine_BoxColliderWrap.set_size));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_BoxCollider(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				BoxCollider obj = new BoxCollider();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.BoxCollider.New");
			}
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
	private static int get_center(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BoxCollider boxCollider = (BoxCollider)obj;
			Vector3 center = boxCollider.center;
			ToLua.Push(L, center);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index center on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_size(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BoxCollider boxCollider = (BoxCollider)obj;
			Vector3 size = boxCollider.size;
			ToLua.Push(L, size);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index size on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_center(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BoxCollider boxCollider = (BoxCollider)obj;
			Vector3 center = ToLua.ToVector3(L, 2);
			boxCollider.center = center;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index center on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_size(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BoxCollider boxCollider = (BoxCollider)obj;
			Vector3 size = ToLua.ToVector3(L, 2);
			boxCollider.size = size;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index size on a nil value");
		}
		return result;
	}
}
