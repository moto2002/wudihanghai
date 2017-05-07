using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnityEngine_GameObjectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameObject), typeof(UnityEngine.Object), null);
		L.RegFunction("CreatePrimitive", new LuaCSFunction(UnityEngine_GameObjectWrap.CreatePrimitive));
		L.RegFunction("GetComponent", new LuaCSFunction(UnityEngine_GameObjectWrap.GetComponent));
		L.RegFunction("GetComponentInChildren", new LuaCSFunction(UnityEngine_GameObjectWrap.GetComponentInChildren));
		L.RegFunction("GetComponentInParent", new LuaCSFunction(UnityEngine_GameObjectWrap.GetComponentInParent));
		L.RegFunction("GetComponents", new LuaCSFunction(UnityEngine_GameObjectWrap.GetComponents));
		L.RegFunction("GetComponentsInChildren", new LuaCSFunction(UnityEngine_GameObjectWrap.GetComponentsInChildren));
		L.RegFunction("GetComponentsInParent", new LuaCSFunction(UnityEngine_GameObjectWrap.GetComponentsInParent));
		L.RegFunction("SetActive", new LuaCSFunction(UnityEngine_GameObjectWrap.SetActive));
		L.RegFunction("CompareTag", new LuaCSFunction(UnityEngine_GameObjectWrap.CompareTag));
		L.RegFunction("FindGameObjectWithTag", new LuaCSFunction(UnityEngine_GameObjectWrap.FindGameObjectWithTag));
		L.RegFunction("FindWithTag", new LuaCSFunction(UnityEngine_GameObjectWrap.FindWithTag));
		L.RegFunction("FindGameObjectsWithTag", new LuaCSFunction(UnityEngine_GameObjectWrap.FindGameObjectsWithTag));
		L.RegFunction("SendMessageUpwards", new LuaCSFunction(UnityEngine_GameObjectWrap.SendMessageUpwards));
		L.RegFunction("BroadcastMessage", new LuaCSFunction(UnityEngine_GameObjectWrap.BroadcastMessage));
		L.RegFunction("AddComponent", new LuaCSFunction(UnityEngine_GameObjectWrap.AddComponent));
		L.RegFunction("Find", new LuaCSFunction(UnityEngine_GameObjectWrap.Find));
		L.RegFunction("SendMessage", new LuaCSFunction(UnityEngine_GameObjectWrap.SendMessage));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_GameObjectWrap._CreateUnityEngine_GameObject));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_GameObjectWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("transform", new LuaCSFunction(UnityEngine_GameObjectWrap.get_transform), null);
		L.RegVar("layer", new LuaCSFunction(UnityEngine_GameObjectWrap.get_layer), new LuaCSFunction(UnityEngine_GameObjectWrap.set_layer));
		L.RegVar("activeSelf", new LuaCSFunction(UnityEngine_GameObjectWrap.get_activeSelf), null);
		L.RegVar("activeInHierarchy", new LuaCSFunction(UnityEngine_GameObjectWrap.get_activeInHierarchy), null);
		L.RegVar("isStatic", new LuaCSFunction(UnityEngine_GameObjectWrap.get_isStatic), new LuaCSFunction(UnityEngine_GameObjectWrap.set_isStatic));
		L.RegVar("tag", new LuaCSFunction(UnityEngine_GameObjectWrap.get_tag), new LuaCSFunction(UnityEngine_GameObjectWrap.set_tag));
		L.RegVar("gameObject", new LuaCSFunction(UnityEngine_GameObjectWrap.get_gameObject), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_GameObject(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				GameObject obj = new GameObject();
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string name = ToLua.CheckString(L, 1);
				GameObject obj2 = new GameObject(name);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (TypeChecker.CheckTypes(L, 1, typeof(string)) && TypeChecker.CheckParamsType(L, typeof(Type), 2, num - 1))
			{
				string name2 = ToLua.CheckString(L, 1);
				Type[] components = ToLua.CheckParamsObject<Type>(L, 2, num - 1);
				GameObject obj3 = new GameObject(name2, components);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.GameObject.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreatePrimitive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PrimitiveType type = (PrimitiveType)((int)ToLua.CheckObject(L, 1, typeof(PrimitiveType)));
			GameObject obj = GameObject.CreatePrimitive(type);
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
	private static int GetComponent(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
			{
				GameObject gameObject = (GameObject)ToLua.ToObject(L, 1);
				string type = ToLua.ToString(L, 2);
				Component component = gameObject.GetComponent(type);
				ToLua.Push(L, component);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Type)))
			{
				GameObject gameObject2 = (GameObject)ToLua.ToObject(L, 1);
				Type type2 = (Type)ToLua.ToObject(L, 2);
				Component component2 = gameObject2.GetComponent(type2);
				ToLua.Push(L, component2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.GetComponent");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetComponentInChildren(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject gameObject = (GameObject)ToLua.CheckObject(L, 1, typeof(GameObject));
			Type type = (Type)ToLua.CheckObject(L, 2, typeof(Type));
			Component componentInChildren = gameObject.GetComponentInChildren(type);
			ToLua.Push(L, componentInChildren);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetComponentInParent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject gameObject = (GameObject)ToLua.CheckObject(L, 1, typeof(GameObject));
			Type type = (Type)ToLua.CheckObject(L, 2, typeof(Type));
			Component componentInParent = gameObject.GetComponentInParent(type);
			ToLua.Push(L, componentInParent);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetComponents(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Type)))
			{
				GameObject gameObject = (GameObject)ToLua.ToObject(L, 1);
				Type type = (Type)ToLua.ToObject(L, 2);
				Component[] components = gameObject.GetComponents(type);
				ToLua.Push(L, components);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Type), typeof(List<Component>)))
			{
				GameObject gameObject2 = (GameObject)ToLua.ToObject(L, 1);
				Type type2 = (Type)ToLua.ToObject(L, 2);
				List<Component> results = (List<Component>)ToLua.ToObject(L, 3);
				gameObject2.GetComponents(type2, results);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.GetComponents");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetComponentsInChildren(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Type)))
			{
				GameObject gameObject = (GameObject)ToLua.ToObject(L, 1);
				Type type = (Type)ToLua.ToObject(L, 2);
				Component[] componentsInChildren = gameObject.GetComponentsInChildren(type);
				ToLua.Push(L, componentsInChildren);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Type), typeof(bool)))
			{
				GameObject gameObject2 = (GameObject)ToLua.ToObject(L, 1);
				Type type2 = (Type)ToLua.ToObject(L, 2);
				bool includeInactive = LuaDLL.lua_toboolean(L, 3);
				Component[] componentsInChildren2 = gameObject2.GetComponentsInChildren(type2, includeInactive);
				ToLua.Push(L, componentsInChildren2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.GetComponentsInChildren");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetComponentsInParent(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Type)))
			{
				GameObject gameObject = (GameObject)ToLua.ToObject(L, 1);
				Type type = (Type)ToLua.ToObject(L, 2);
				Component[] componentsInParent = gameObject.GetComponentsInParent(type);
				ToLua.Push(L, componentsInParent);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Type), typeof(bool)))
			{
				GameObject gameObject2 = (GameObject)ToLua.ToObject(L, 1);
				Type type2 = (Type)ToLua.ToObject(L, 2);
				bool includeInactive = LuaDLL.lua_toboolean(L, 3);
				Component[] componentsInParent2 = gameObject2.GetComponentsInParent(type2, includeInactive);
				ToLua.Push(L, componentsInParent2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.GetComponentsInParent");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject gameObject = (GameObject)ToLua.CheckObject(L, 1, typeof(GameObject));
			bool active = LuaDLL.luaL_checkboolean(L, 2);
			gameObject.SetActive(active);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CompareTag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject gameObject = (GameObject)ToLua.CheckObject(L, 1, typeof(GameObject));
			string tag = ToLua.CheckString(L, 2);
			bool value = gameObject.CompareTag(tag);
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
	private static int FindGameObjectWithTag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string tag = ToLua.CheckString(L, 1);
			GameObject obj = GameObject.FindGameObjectWithTag(tag);
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
	private static int FindWithTag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string tag = ToLua.CheckString(L, 1);
			GameObject obj = GameObject.FindWithTag(tag);
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
	private static int FindGameObjectsWithTag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string tag = ToLua.CheckString(L, 1);
			GameObject[] array = GameObject.FindGameObjectsWithTag(tag);
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendMessageUpwards(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
			{
				GameObject gameObject = (GameObject)ToLua.ToObject(L, 1);
				string methodName = ToLua.ToString(L, 2);
				gameObject.SendMessageUpwards(methodName);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(SendMessageOptions)))
			{
				GameObject gameObject2 = (GameObject)ToLua.ToObject(L, 1);
				string methodName2 = ToLua.ToString(L, 2);
				SendMessageOptions options = (SendMessageOptions)((int)ToLua.ToObject(L, 3));
				gameObject2.SendMessageUpwards(methodName2, options);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(object)))
			{
				GameObject gameObject3 = (GameObject)ToLua.ToObject(L, 1);
				string methodName3 = ToLua.ToString(L, 2);
				object value = ToLua.ToVarObject(L, 3);
				gameObject3.SendMessageUpwards(methodName3, value);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(object), typeof(SendMessageOptions)))
			{
				GameObject gameObject4 = (GameObject)ToLua.ToObject(L, 1);
				string methodName4 = ToLua.ToString(L, 2);
				object value2 = ToLua.ToVarObject(L, 3);
				SendMessageOptions options2 = (SendMessageOptions)((int)ToLua.ToObject(L, 4));
				gameObject4.SendMessageUpwards(methodName4, value2, options2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.SendMessageUpwards");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BroadcastMessage(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
			{
				GameObject gameObject = (GameObject)ToLua.ToObject(L, 1);
				string methodName = ToLua.ToString(L, 2);
				gameObject.BroadcastMessage(methodName);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(SendMessageOptions)))
			{
				GameObject gameObject2 = (GameObject)ToLua.ToObject(L, 1);
				string methodName2 = ToLua.ToString(L, 2);
				SendMessageOptions options = (SendMessageOptions)((int)ToLua.ToObject(L, 3));
				gameObject2.BroadcastMessage(methodName2, options);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(object)))
			{
				GameObject gameObject3 = (GameObject)ToLua.ToObject(L, 1);
				string methodName3 = ToLua.ToString(L, 2);
				object parameter = ToLua.ToVarObject(L, 3);
				gameObject3.BroadcastMessage(methodName3, parameter);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(object), typeof(SendMessageOptions)))
			{
				GameObject gameObject4 = (GameObject)ToLua.ToObject(L, 1);
				string methodName4 = ToLua.ToString(L, 2);
				object parameter2 = ToLua.ToVarObject(L, 3);
				SendMessageOptions options2 = (SendMessageOptions)((int)ToLua.ToObject(L, 4));
				gameObject4.BroadcastMessage(methodName4, parameter2, options2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.BroadcastMessage");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddComponent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject gameObject = (GameObject)ToLua.CheckObject(L, 1, typeof(GameObject));
			Type componentType = (Type)ToLua.CheckObject(L, 2, typeof(Type));
			Component obj = gameObject.AddComponent(componentType);
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
	private static int Find(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string name = ToLua.CheckString(L, 1);
			GameObject obj = GameObject.Find(name);
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
	private static int SendMessage(IntPtr L)
	{
		int result;
		try
		{
			LuaException.SendMsgCount++;
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
			{
				GameObject gameObject = (GameObject)ToLua.ToObject(L, 1);
				string methodName = ToLua.ToString(L, 2);
				gameObject.SendMessage(methodName);
				LuaException.SendMsgCount--;
				if (LuaDLL.lua_toboolean(L, LuaDLL.lua_upvalueindex(1)))
				{
					string msg = LuaDLL.lua_tostring(L, -1);
					LuaDLL.lua_pop(L, 1);
					throw new LuaException(msg, LuaException.GetLastError(), 1);
				}
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(SendMessageOptions)))
			{
				GameObject gameObject2 = (GameObject)ToLua.ToObject(L, 1);
				string methodName2 = ToLua.ToString(L, 2);
				SendMessageOptions options = (SendMessageOptions)((int)ToLua.ToObject(L, 3));
				gameObject2.SendMessage(methodName2, options);
				LuaException.SendMsgCount--;
				if (LuaDLL.lua_toboolean(L, LuaDLL.lua_upvalueindex(1)))
				{
					string msg2 = LuaDLL.lua_tostring(L, -1);
					LuaDLL.lua_pop(L, 1);
					throw new LuaException(msg2, LuaException.GetLastError(), 1);
				}
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(object)))
			{
				GameObject gameObject3 = (GameObject)ToLua.ToObject(L, 1);
				string methodName3 = ToLua.ToString(L, 2);
				object value = ToLua.ToVarObject(L, 3);
				gameObject3.SendMessage(methodName3, value);
				LuaException.SendMsgCount--;
				if (LuaDLL.lua_toboolean(L, LuaDLL.lua_upvalueindex(1)))
				{
					string msg3 = LuaDLL.lua_tostring(L, -1);
					LuaDLL.lua_pop(L, 1);
					throw new LuaException(msg3, LuaException.GetLastError(), 1);
				}
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string), typeof(object), typeof(SendMessageOptions)))
			{
				GameObject gameObject4 = (GameObject)ToLua.ToObject(L, 1);
				string methodName4 = ToLua.ToString(L, 2);
				object value2 = ToLua.ToVarObject(L, 3);
				SendMessageOptions options2 = (SendMessageOptions)((int)ToLua.ToObject(L, 4));
				gameObject4.SendMessage(methodName4, value2, options2);
				LuaException.SendMsgCount--;
				if (LuaDLL.lua_toboolean(L, LuaDLL.lua_upvalueindex(1)))
				{
					string msg4 = LuaDLL.lua_tostring(L, -1);
					LuaDLL.lua_pop(L, 1);
					throw new LuaException(msg4, LuaException.GetLastError(), 1);
				}
				result = 0;
			}
			else
			{
				LuaException.SendMsgCount--;
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.SendMessage");
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
	private static int get_transform(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameObject gameObject = (GameObject)obj;
			Transform transform = gameObject.transform;
			ToLua.Push(L, transform);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index transform on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_layer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameObject gameObject = (GameObject)obj;
			int layer = gameObject.layer;
			LuaDLL.lua_pushinteger(L, layer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeSelf(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameObject gameObject = (GameObject)obj;
			bool activeSelf = gameObject.activeSelf;
			LuaDLL.lua_pushboolean(L, activeSelf);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeSelf on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeInHierarchy(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameObject gameObject = (GameObject)obj;
			bool activeInHierarchy = gameObject.activeInHierarchy;
			LuaDLL.lua_pushboolean(L, activeInHierarchy);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeInHierarchy on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isStatic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameObject gameObject = (GameObject)obj;
			bool isStatic = gameObject.isStatic;
			LuaDLL.lua_pushboolean(L, isStatic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isStatic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameObject gameObject = (GameObject)obj;
			string tag = gameObject.tag;
			LuaDLL.lua_pushstring(L, tag);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gameObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameObject gameObject = (GameObject)obj;
			GameObject gameObject2 = gameObject.gameObject;
			ToLua.Push(L, gameObject2);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gameObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_layer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameObject gameObject = (GameObject)obj;
			int layer = (int)LuaDLL.luaL_checknumber(L, 2);
			gameObject.layer = layer;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isStatic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameObject gameObject = (GameObject)obj;
			bool isStatic = LuaDLL.luaL_checkboolean(L, 2);
			gameObject.isStatic = isStatic;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isStatic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameObject gameObject = (GameObject)obj;
			string tag = ToLua.CheckString(L, 2);
			gameObject.tag = tag;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tag on a nil value");
		}
		return result;
	}
}
