using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_ColliderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Collider), typeof(Component), null);
		L.RegFunction("ClosestPointOnBounds", new LuaCSFunction(UnityEngine_ColliderWrap.ClosestPointOnBounds));
		L.RegFunction("Raycast", new LuaCSFunction(UnityEngine_ColliderWrap.Raycast));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_ColliderWrap._CreateUnityEngine_Collider));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_ColliderWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("enabled", new LuaCSFunction(UnityEngine_ColliderWrap.get_enabled), new LuaCSFunction(UnityEngine_ColliderWrap.set_enabled));
		L.RegVar("attachedRigidbody", new LuaCSFunction(UnityEngine_ColliderWrap.get_attachedRigidbody), null);
		L.RegVar("isTrigger", new LuaCSFunction(UnityEngine_ColliderWrap.get_isTrigger), new LuaCSFunction(UnityEngine_ColliderWrap.set_isTrigger));
		L.RegVar("contactOffset", new LuaCSFunction(UnityEngine_ColliderWrap.get_contactOffset), new LuaCSFunction(UnityEngine_ColliderWrap.set_contactOffset));
		L.RegVar("material", new LuaCSFunction(UnityEngine_ColliderWrap.get_material), new LuaCSFunction(UnityEngine_ColliderWrap.set_material));
		L.RegVar("sharedMaterial", new LuaCSFunction(UnityEngine_ColliderWrap.get_sharedMaterial), new LuaCSFunction(UnityEngine_ColliderWrap.set_sharedMaterial));
		L.RegVar("bounds", new LuaCSFunction(UnityEngine_ColliderWrap.get_bounds), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Collider(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Collider obj = new Collider();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Collider.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClosestPointOnBounds(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Collider collider = (Collider)ToLua.CheckObject(L, 1, typeof(Collider));
			Vector3 position = ToLua.ToVector3(L, 2);
			Vector3 v = collider.ClosestPointOnBounds(position);
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
	private static int Raycast(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Collider collider = (Collider)ToLua.CheckObject(L, 1, typeof(Collider));
			Ray ray = ToLua.ToRay(L, 2);
			float maxDistance = (float)LuaDLL.luaL_checknumber(L, 4);
			RaycastHit hit;
			bool value = collider.Raycast(ray, out hit, maxDistance);
			LuaDLL.lua_pushboolean(L, value);
			ToLua.Push(L, hit);
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
	private static int get_enabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Collider collider = (Collider)obj;
			bool enabled = collider.enabled;
			LuaDLL.lua_pushboolean(L, enabled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_attachedRigidbody(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Collider collider = (Collider)obj;
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			ToLua.Push(L, attachedRigidbody);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index attachedRigidbody on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isTrigger(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Collider collider = (Collider)obj;
			bool isTrigger = collider.isTrigger;
			LuaDLL.lua_pushboolean(L, isTrigger);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isTrigger on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_contactOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Collider collider = (Collider)obj;
			float contactOffset = collider.contactOffset;
			LuaDLL.lua_pushnumber(L, (double)contactOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index contactOffset on a nil value");
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
			Collider collider = (Collider)obj;
			PhysicMaterial material = collider.material;
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
	private static int get_sharedMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Collider collider = (Collider)obj;
			PhysicMaterial sharedMaterial = collider.sharedMaterial;
			ToLua.Push(L, sharedMaterial);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sharedMaterial on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bounds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Collider collider = (Collider)obj;
			Bounds bounds = collider.bounds;
			ToLua.Push(L, bounds);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bounds on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_enabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Collider collider = (Collider)obj;
			bool enabled = LuaDLL.luaL_checkboolean(L, 2);
			collider.enabled = enabled;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isTrigger(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Collider collider = (Collider)obj;
			bool isTrigger = LuaDLL.luaL_checkboolean(L, 2);
			collider.isTrigger = isTrigger;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isTrigger on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_contactOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Collider collider = (Collider)obj;
			float contactOffset = (float)LuaDLL.luaL_checknumber(L, 2);
			collider.contactOffset = contactOffset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index contactOffset on a nil value");
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
			Collider collider = (Collider)obj;
			PhysicMaterial material = (PhysicMaterial)ToLua.CheckUnityObject(L, 2, typeof(PhysicMaterial));
			collider.material = material;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sharedMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Collider collider = (Collider)obj;
			PhysicMaterial sharedMaterial = (PhysicMaterial)ToLua.CheckUnityObject(L, 2, typeof(PhysicMaterial));
			collider.sharedMaterial = sharedMaterial;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sharedMaterial on a nil value");
		}
		return result;
	}
}
