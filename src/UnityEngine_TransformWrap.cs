using LuaInterface;
using System;
using System.Collections;
using UnityEngine;

public class UnityEngine_TransformWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Transform), typeof(Component), null);
		L.RegFunction("SetParent", new LuaCSFunction(UnityEngine_TransformWrap.SetParent));
		L.RegFunction("Translate", new LuaCSFunction(UnityEngine_TransformWrap.Translate));
		L.RegFunction("Rotate", new LuaCSFunction(UnityEngine_TransformWrap.Rotate));
		L.RegFunction("RotateAround", new LuaCSFunction(UnityEngine_TransformWrap.RotateAround));
		L.RegFunction("LookAt", new LuaCSFunction(UnityEngine_TransformWrap.LookAt));
		L.RegFunction("TransformDirection", new LuaCSFunction(UnityEngine_TransformWrap.TransformDirection));
		L.RegFunction("InverseTransformDirection", new LuaCSFunction(UnityEngine_TransformWrap.InverseTransformDirection));
		L.RegFunction("TransformVector", new LuaCSFunction(UnityEngine_TransformWrap.TransformVector));
		L.RegFunction("InverseTransformVector", new LuaCSFunction(UnityEngine_TransformWrap.InverseTransformVector));
		L.RegFunction("TransformPoint", new LuaCSFunction(UnityEngine_TransformWrap.TransformPoint));
		L.RegFunction("InverseTransformPoint", new LuaCSFunction(UnityEngine_TransformWrap.InverseTransformPoint));
		L.RegFunction("DetachChildren", new LuaCSFunction(UnityEngine_TransformWrap.DetachChildren));
		L.RegFunction("SetAsFirstSibling", new LuaCSFunction(UnityEngine_TransformWrap.SetAsFirstSibling));
		L.RegFunction("SetAsLastSibling", new LuaCSFunction(UnityEngine_TransformWrap.SetAsLastSibling));
		L.RegFunction("SetSiblingIndex", new LuaCSFunction(UnityEngine_TransformWrap.SetSiblingIndex));
		L.RegFunction("GetSiblingIndex", new LuaCSFunction(UnityEngine_TransformWrap.GetSiblingIndex));
		L.RegFunction("Find", new LuaCSFunction(UnityEngine_TransformWrap.Find));
		L.RegFunction("IsChildOf", new LuaCSFunction(UnityEngine_TransformWrap.IsChildOf));
		L.RegFunction("FindChild", new LuaCSFunction(UnityEngine_TransformWrap.FindChild));
		L.RegFunction("GetEnumerator", new LuaCSFunction(UnityEngine_TransformWrap.GetEnumerator));
		L.RegFunction("GetChild", new LuaCSFunction(UnityEngine_TransformWrap.GetChild));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_TransformWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("position", new LuaCSFunction(UnityEngine_TransformWrap.get_position), new LuaCSFunction(UnityEngine_TransformWrap.set_position));
		L.RegVar("localPosition", new LuaCSFunction(UnityEngine_TransformWrap.get_localPosition), new LuaCSFunction(UnityEngine_TransformWrap.set_localPosition));
		L.RegVar("eulerAngles", new LuaCSFunction(UnityEngine_TransformWrap.get_eulerAngles), new LuaCSFunction(UnityEngine_TransformWrap.set_eulerAngles));
		L.RegVar("localEulerAngles", new LuaCSFunction(UnityEngine_TransformWrap.get_localEulerAngles), new LuaCSFunction(UnityEngine_TransformWrap.set_localEulerAngles));
		L.RegVar("right", new LuaCSFunction(UnityEngine_TransformWrap.get_right), new LuaCSFunction(UnityEngine_TransformWrap.set_right));
		L.RegVar("up", new LuaCSFunction(UnityEngine_TransformWrap.get_up), new LuaCSFunction(UnityEngine_TransformWrap.set_up));
		L.RegVar("forward", new LuaCSFunction(UnityEngine_TransformWrap.get_forward), new LuaCSFunction(UnityEngine_TransformWrap.set_forward));
		L.RegVar("rotation", new LuaCSFunction(UnityEngine_TransformWrap.get_rotation), new LuaCSFunction(UnityEngine_TransformWrap.set_rotation));
		L.RegVar("localRotation", new LuaCSFunction(UnityEngine_TransformWrap.get_localRotation), new LuaCSFunction(UnityEngine_TransformWrap.set_localRotation));
		L.RegVar("localScale", new LuaCSFunction(UnityEngine_TransformWrap.get_localScale), new LuaCSFunction(UnityEngine_TransformWrap.set_localScale));
		L.RegVar("parent", new LuaCSFunction(UnityEngine_TransformWrap.get_parent), new LuaCSFunction(UnityEngine_TransformWrap.set_parent));
		L.RegVar("worldToLocalMatrix", new LuaCSFunction(UnityEngine_TransformWrap.get_worldToLocalMatrix), null);
		L.RegVar("localToWorldMatrix", new LuaCSFunction(UnityEngine_TransformWrap.get_localToWorldMatrix), null);
		L.RegVar("root", new LuaCSFunction(UnityEngine_TransformWrap.get_root), null);
		L.RegVar("childCount", new LuaCSFunction(UnityEngine_TransformWrap.get_childCount), null);
		L.RegVar("lossyScale", new LuaCSFunction(UnityEngine_TransformWrap.get_lossyScale), null);
		L.RegVar("hasChanged", new LuaCSFunction(UnityEngine_TransformWrap.get_hasChanged), new LuaCSFunction(UnityEngine_TransformWrap.set_hasChanged));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetParent(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Transform)))
			{
				Transform transform = (Transform)ToLua.ToObject(L, 1);
				Transform parent = (Transform)ToLua.ToObject(L, 2);
				transform.SetParent(parent);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Transform), typeof(bool)))
			{
				Transform transform2 = (Transform)ToLua.ToObject(L, 1);
				Transform parent2 = (Transform)ToLua.ToObject(L, 2);
				bool worldPositionStays = LuaDLL.lua_toboolean(L, 3);
				transform2.SetParent(parent2, worldPositionStays);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Transform.SetParent");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Translate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3)))
			{
				Transform transform = (Transform)ToLua.ToObject(L, 1);
				Vector3 translation = ToLua.ToVector3(L, 2);
				transform.Translate(translation);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3), typeof(Transform)))
			{
				Transform transform2 = (Transform)ToLua.ToObject(L, 1);
				Vector3 translation2 = ToLua.ToVector3(L, 2);
				Transform relativeTo = (Transform)ToLua.ToObject(L, 3);
				transform2.Translate(translation2, relativeTo);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3), typeof(Space)))
			{
				Transform transform3 = (Transform)ToLua.ToObject(L, 1);
				Vector3 translation3 = ToLua.ToVector3(L, 2);
				Space relativeTo2 = (Space)((int)ToLua.ToObject(L, 3));
				transform3.Translate(translation3, relativeTo2);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float)))
			{
				Transform transform4 = (Transform)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				transform4.Translate(x, y, z);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float), typeof(Transform)))
			{
				Transform transform5 = (Transform)ToLua.ToObject(L, 1);
				float x2 = (float)LuaDLL.lua_tonumber(L, 2);
				float y2 = (float)LuaDLL.lua_tonumber(L, 3);
				float z2 = (float)LuaDLL.lua_tonumber(L, 4);
				Transform relativeTo3 = (Transform)ToLua.ToObject(L, 5);
				transform5.Translate(x2, y2, z2, relativeTo3);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float), typeof(Space)))
			{
				Transform transform6 = (Transform)ToLua.ToObject(L, 1);
				float x3 = (float)LuaDLL.lua_tonumber(L, 2);
				float y3 = (float)LuaDLL.lua_tonumber(L, 3);
				float z3 = (float)LuaDLL.lua_tonumber(L, 4);
				Space relativeTo4 = (Space)((int)ToLua.ToObject(L, 5));
				transform6.Translate(x3, y3, z3, relativeTo4);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Transform.Translate");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Rotate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3)))
			{
				Transform transform = (Transform)ToLua.ToObject(L, 1);
				Vector3 eulerAngles = ToLua.ToVector3(L, 2);
				transform.Rotate(eulerAngles);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3), typeof(float)))
			{
				Transform transform2 = (Transform)ToLua.ToObject(L, 1);
				Vector3 axis = ToLua.ToVector3(L, 2);
				float angle = (float)LuaDLL.lua_tonumber(L, 3);
				transform2.Rotate(axis, angle);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3), typeof(Space)))
			{
				Transform transform3 = (Transform)ToLua.ToObject(L, 1);
				Vector3 eulerAngles2 = ToLua.ToVector3(L, 2);
				Space relativeTo = (Space)((int)ToLua.ToObject(L, 3));
				transform3.Rotate(eulerAngles2, relativeTo);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3), typeof(float), typeof(Space)))
			{
				Transform transform4 = (Transform)ToLua.ToObject(L, 1);
				Vector3 axis2 = ToLua.ToVector3(L, 2);
				float angle2 = (float)LuaDLL.lua_tonumber(L, 3);
				Space relativeTo2 = (Space)((int)ToLua.ToObject(L, 4));
				transform4.Rotate(axis2, angle2, relativeTo2);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float)))
			{
				Transform transform5 = (Transform)ToLua.ToObject(L, 1);
				float xAngle = (float)LuaDLL.lua_tonumber(L, 2);
				float yAngle = (float)LuaDLL.lua_tonumber(L, 3);
				float zAngle = (float)LuaDLL.lua_tonumber(L, 4);
				transform5.Rotate(xAngle, yAngle, zAngle);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float), typeof(Space)))
			{
				Transform transform6 = (Transform)ToLua.ToObject(L, 1);
				float xAngle2 = (float)LuaDLL.lua_tonumber(L, 2);
				float yAngle2 = (float)LuaDLL.lua_tonumber(L, 3);
				float zAngle2 = (float)LuaDLL.lua_tonumber(L, 4);
				Space relativeTo3 = (Space)((int)ToLua.ToObject(L, 5));
				transform6.Rotate(xAngle2, yAngle2, zAngle2, relativeTo3);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Transform.Rotate");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RotateAround(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			Vector3 point = ToLua.ToVector3(L, 2);
			Vector3 axis = ToLua.ToVector3(L, 3);
			float angle = (float)LuaDLL.luaL_checknumber(L, 4);
			transform.RotateAround(point, axis, angle);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LookAt(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3)))
			{
				Transform transform = (Transform)ToLua.ToObject(L, 1);
				Vector3 worldPosition = ToLua.ToVector3(L, 2);
				transform.LookAt(worldPosition);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Transform)))
			{
				Transform transform2 = (Transform)ToLua.ToObject(L, 1);
				Transform target = (Transform)ToLua.ToObject(L, 2);
				transform2.LookAt(target);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3), typeof(Vector3)))
			{
				Transform transform3 = (Transform)ToLua.ToObject(L, 1);
				Vector3 worldPosition2 = ToLua.ToVector3(L, 2);
				Vector3 worldUp = ToLua.ToVector3(L, 3);
				transform3.LookAt(worldPosition2, worldUp);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Transform), typeof(Vector3)))
			{
				Transform transform4 = (Transform)ToLua.ToObject(L, 1);
				Transform target2 = (Transform)ToLua.ToObject(L, 2);
				Vector3 worldUp2 = ToLua.ToVector3(L, 3);
				transform4.LookAt(target2, worldUp2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Transform.LookAt");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TransformDirection(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3)))
			{
				Transform transform = (Transform)ToLua.ToObject(L, 1);
				Vector3 direction = ToLua.ToVector3(L, 2);
				Vector3 v = transform.TransformDirection(direction);
				ToLua.Push(L, v);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float)))
			{
				Transform transform2 = (Transform)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				Vector3 v2 = transform2.TransformDirection(x, y, z);
				ToLua.Push(L, v2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Transform.TransformDirection");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InverseTransformDirection(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3)))
			{
				Transform transform = (Transform)ToLua.ToObject(L, 1);
				Vector3 direction = ToLua.ToVector3(L, 2);
				Vector3 v = transform.InverseTransformDirection(direction);
				ToLua.Push(L, v);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float)))
			{
				Transform transform2 = (Transform)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				Vector3 v2 = transform2.InverseTransformDirection(x, y, z);
				ToLua.Push(L, v2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Transform.InverseTransformDirection");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TransformVector(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3)))
			{
				Transform transform = (Transform)ToLua.ToObject(L, 1);
				Vector3 vector = ToLua.ToVector3(L, 2);
				Vector3 v = transform.TransformVector(vector);
				ToLua.Push(L, v);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float)))
			{
				Transform transform2 = (Transform)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				Vector3 v2 = transform2.TransformVector(x, y, z);
				ToLua.Push(L, v2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Transform.TransformVector");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InverseTransformVector(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3)))
			{
				Transform transform = (Transform)ToLua.ToObject(L, 1);
				Vector3 vector = ToLua.ToVector3(L, 2);
				Vector3 v = transform.InverseTransformVector(vector);
				ToLua.Push(L, v);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float)))
			{
				Transform transform2 = (Transform)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				Vector3 v2 = transform2.InverseTransformVector(x, y, z);
				ToLua.Push(L, v2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Transform.InverseTransformVector");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TransformPoint(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3)))
			{
				Transform transform = (Transform)ToLua.ToObject(L, 1);
				Vector3 position = ToLua.ToVector3(L, 2);
				Vector3 v = transform.TransformPoint(position);
				ToLua.Push(L, v);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float)))
			{
				Transform transform2 = (Transform)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				Vector3 v2 = transform2.TransformPoint(x, y, z);
				ToLua.Push(L, v2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Transform.TransformPoint");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InverseTransformPoint(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3)))
			{
				Transform transform = (Transform)ToLua.ToObject(L, 1);
				Vector3 position = ToLua.ToVector3(L, 2);
				Vector3 v = transform.InverseTransformPoint(position);
				ToLua.Push(L, v);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(float), typeof(float), typeof(float)))
			{
				Transform transform2 = (Transform)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				Vector3 v2 = transform2.InverseTransformPoint(x, y, z);
				ToLua.Push(L, v2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Transform.InverseTransformPoint");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DetachChildren(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			transform.DetachChildren();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAsFirstSibling(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			transform.SetAsFirstSibling();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAsLastSibling(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			transform.SetAsLastSibling();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetSiblingIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			int siblingIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			transform.SetSiblingIndex(siblingIndex);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSiblingIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			int siblingIndex = transform.GetSiblingIndex();
			LuaDLL.lua_pushinteger(L, siblingIndex);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Find(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			string name = ToLua.CheckString(L, 2);
			Transform obj = transform.Find(name);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsChildOf(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			bool value = transform.IsChildOf(parent);
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
	private static int FindChild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			string name = ToLua.CheckString(L, 2);
			Transform obj = transform.FindChild(name);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEnumerator(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			IEnumerator enumerator = transform.GetEnumerator();
			ToLua.Push(L, enumerator);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform transform = (Transform)ToLua.CheckObject(L, 1, typeof(Transform));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			Transform child = transform.GetChild(index);
			ToLua.Push(L, child);
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
	private static int get_position(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 position = transform.position;
			ToLua.Push(L, position);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index position on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 localPosition = transform.localPosition;
			ToLua.Push(L, localPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eulerAngles(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 eulerAngles = transform.eulerAngles;
			ToLua.Push(L, eulerAngles);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eulerAngles on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localEulerAngles(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 localEulerAngles = transform.localEulerAngles;
			ToLua.Push(L, localEulerAngles);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localEulerAngles on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_right(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 right = transform.right;
			ToLua.Push(L, right);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index right on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_up(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 up = transform.up;
			ToLua.Push(L, up);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index up on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_forward(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 forward = transform.forward;
			ToLua.Push(L, forward);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index forward on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Quaternion rotation = transform.rotation;
			ToLua.Push(L, rotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Quaternion localRotation = transform.localRotation;
			ToLua.Push(L, localRotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 localScale = transform.localScale;
			ToLua.Push(L, localScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_parent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Transform parent = transform.parent;
			ToLua.Push(L, parent);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldToLocalMatrix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Matrix4x4 worldToLocalMatrix = transform.worldToLocalMatrix;
			ToLua.PushValue(L, worldToLocalMatrix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldToLocalMatrix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localToWorldMatrix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
			ToLua.PushValue(L, localToWorldMatrix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localToWorldMatrix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_root(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Transform root = transform.root;
			ToLua.Push(L, root);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index root on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_childCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			int childCount = transform.childCount;
			LuaDLL.lua_pushinteger(L, childCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index childCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lossyScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 lossyScale = transform.lossyScale;
			ToLua.Push(L, lossyScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lossyScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hasChanged(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			bool hasChanged = transform.hasChanged;
			LuaDLL.lua_pushboolean(L, hasChanged);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasChanged on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_position(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 position = ToLua.ToVector3(L, 2);
			transform.position = position;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index position on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 localPosition = ToLua.ToVector3(L, 2);
			transform.localPosition = localPosition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eulerAngles(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 eulerAngles = ToLua.ToVector3(L, 2);
			transform.eulerAngles = eulerAngles;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eulerAngles on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localEulerAngles(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 localEulerAngles = ToLua.ToVector3(L, 2);
			transform.localEulerAngles = localEulerAngles;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localEulerAngles on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_right(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 right = ToLua.ToVector3(L, 2);
			transform.right = right;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index right on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_up(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 up = ToLua.ToVector3(L, 2);
			transform.up = up;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index up on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_forward(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 forward = ToLua.ToVector3(L, 2);
			transform.forward = forward;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index forward on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Quaternion rotation = ToLua.ToQuaternion(L, 2);
			transform.rotation = rotation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Quaternion localRotation = ToLua.ToQuaternion(L, 2);
			transform.localRotation = localRotation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Vector3 localScale = ToLua.ToVector3(L, 2);
			transform.localScale = localScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_parent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			transform.parent = parent;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hasChanged(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Transform transform = (Transform)obj;
			bool hasChanged = LuaDLL.luaL_checkboolean(L, 2);
			transform.hasChanged = hasChanged;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasChanged on a nil value");
		}
		return result;
	}
}
