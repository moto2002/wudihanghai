using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LuaFramework_LuaBehaviourWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaBehaviour), typeof(View), null);
		L.RegFunction("AddClick", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddClick));
		L.RegFunction("AddToggleClick", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddToggleClick));
		L.RegFunction("AddLongPressClick", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddLongPressClick));
		L.RegFunction("AddSliderOnValueChanged", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddSliderOnValueChanged));
		L.RegFunction("AddInputFieldEditEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddInputFieldEditEvent));
		L.RegFunction("AddDragEnd", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddDragEnd));
		L.RegFunction("AddDragEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddDragEvent));
		L.RegFunction("AddClickEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddClickEvent));
		L.RegFunction("AddHandleUIInputEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddHandleUIInputEvent));
		L.RegFunction("ClearClick", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.ClearClick));
		L.RegFunction("ImageGray", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.ImageGray));
		L.RegFunction("PlayAnimation", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.PlayAnimation));
		L.RegFunction("FindChildWithName", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.FindChildWithName));
		L.RegFunction("SetViewSortingOrder", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.SetViewSortingOrder));
		L.RegFunction("RemoveCanvasComponent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.RemoveCanvasComponent));
		L.RegFunction("CleanAssetbundleName", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.CleanAssetbundleName));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddClick(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(LuaBehaviour), typeof(Transform), typeof(LuaFunction)))
			{
				LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.ToObject(L, 1);
				Transform transform = (Transform)ToLua.ToObject(L, 2);
				LuaFunction luafunc = ToLua.ToLuaFunction(L, 3);
				luaBehaviour.AddClick(transform, luafunc);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(LuaBehaviour), typeof(GameObject), typeof(LuaFunction)))
			{
				LuaBehaviour luaBehaviour2 = (LuaBehaviour)ToLua.ToObject(L, 1);
				GameObject go = (GameObject)ToLua.ToObject(L, 2);
				LuaFunction luafunc2 = ToLua.ToLuaFunction(L, 3);
				luaBehaviour2.AddClick(go, luafunc2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.LuaBehaviour.AddClick");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddToggleClick(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(LuaBehaviour), typeof(Transform), typeof(LuaFunction)))
			{
				LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.ToObject(L, 1);
				Transform transform = (Transform)ToLua.ToObject(L, 2);
				LuaFunction luafunc = ToLua.ToLuaFunction(L, 3);
				luaBehaviour.AddToggleClick(transform, luafunc);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(LuaBehaviour), typeof(GameObject), typeof(LuaFunction)))
			{
				LuaBehaviour luaBehaviour2 = (LuaBehaviour)ToLua.ToObject(L, 1);
				GameObject go = (GameObject)ToLua.ToObject(L, 2);
				LuaFunction luafunc2 = ToLua.ToLuaFunction(L, 3);
				luaBehaviour2.AddToggleClick(go, luafunc2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.LuaBehaviour.AddToggleClick");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddLongPressClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction longPressLuaFunc = ToLua.CheckLuaFunction(L, 3);
			LuaFunction clickLuaFunc = ToLua.CheckLuaFunction(L, 4);
			float delayTime = (float)LuaDLL.luaL_checknumber(L, 5);
			luaBehaviour.AddLongPressClick(go, longPressLuaFunc, clickLuaFunc, delayTime);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddSliderOnValueChanged(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			Slider slider = (Slider)ToLua.CheckUnityObject(L, 2, typeof(Slider));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddSliderOnValueChanged(slider, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddInputFieldEditEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			InputField input = (InputField)ToLua.CheckUnityObject(L, 2, typeof(InputField));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddInputFieldEditEvent(input, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDragEnd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddDragEnd(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDragEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddDragEvent(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddClickEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddClickEvent(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddHandleUIInputEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddHandleUIInputEvent(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			luaBehaviour.ClearClick();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ImageGray(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			Image image = (Image)ToLua.CheckUnityObject(L, 2, typeof(Image));
			bool grayOrNot = LuaDLL.luaL_checkboolean(L, 3);
			luaBehaviour.ImageGray(image, grayOrNot);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayAnimation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			string strAnimName = ToLua.CheckString(L, 2);
			LuaFunction luaFunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.PlayAnimation(strAnimName, luaFunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindChildWithName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			string childName = ToLua.CheckString(L, 3);
			LuaFunction luaFunc = ToLua.CheckLuaFunction(L, 4);
			luaBehaviour.FindChildWithName(obj, childName, luaFunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetViewSortingOrder(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			bool isUI = LuaDLL.luaL_checkboolean(L, 3);
			int order = (int)LuaDLL.luaL_checknumber(L, 4);
			luaBehaviour.SetViewSortingOrder(gameObject, isUI, order);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveCanvasComponent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			luaBehaviour.RemoveCanvasComponent(gameObject);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CleanAssetbundleName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			luaBehaviour.CleanAssetbundleName();
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
}
