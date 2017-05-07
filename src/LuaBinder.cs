using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class LuaBinder
{
	public static void Bind(LuaState L)
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		L.BeginModule(null);
		ViewWrap.Register(L);
		BaseWrap.Register(L);
		ManagerWrap.Register(L);
		L.BeginModule("UnityEngine");
		UnityEngine_ComponentWrap.Register(L);
		UnityEngine_BehaviourWrap.Register(L);
		UnityEngine_MonoBehaviourWrap.Register(L);
		UnityEngine_GameObjectWrap.Register(L);
		UnityEngine_TransformWrap.Register(L);
		UnityEngine_ApplicationWrap.Register(L);
		UnityEngine_ColliderWrap.Register(L);
		UnityEngine_TimeWrap.Register(L);
		UnityEngine_ShaderWrap.Register(L);
		UnityEngine_MaterialWrap.Register(L);
		UnityEngine_RendererWrap.Register(L);
		UnityEngine_WWWWrap.Register(L);
		UnityEngine_ScreenWrap.Register(L);
		UnityEngine_CameraWrap.Register(L);
		UnityEngine_AudioSourceWrap.Register(L);
		UnityEngine_AnimatorWrap.Register(L);
		UnityEngine_InputWrap.Register(L);
		UnityEngine_SkinnedMeshRendererWrap.Register(L);
		UnityEngine_WWWFormWrap.Register(L);
		UnityEngine_SystemInfoWrap.Register(L);
		UnityEngine_MeshRendererWrap.Register(L);
		UnityEngine_BoxColliderWrap.Register(L);
		UnityEngine_RectTransformWrap.Register(L);
		UnityEngine_RectWrap.Register(L);
		UnityEngine_SpriteWrap.Register(L);
		UnityEngine_TextAnchorWrap.Register(L);
		L.BeginModule("UI");
		UnityEngine_UI_TextWrap.Register(L);
		UnityEngine_UI_InputFieldWrap.Register(L);
		UnityEngine_UI_ToggleWrap.Register(L);
		UnityEngine_UI_ImageWrap.Register(L);
		UnityEngine_UI_RawImageWrap.Register(L);
		UnityEngine_UI_SliderWrap.Register(L);
		UnityEngine_UI_HorizontalLayoutGroupWrap.Register(L);
		UnityEngine_UI_ButtonWrap.Register(L);
		UnityEngine_UI_GraphicWrap.Register(L);
		UnityEngine_UI_MaskableGraphicWrap.Register(L);
		UnityEngine_UI_GraphicRaycasterWrap.Register(L);
		UnityEngine_UI_SelectableWrap.Register(L);
		UnityEngine_UI_HorizontalOrVerticalLayoutGroupWrap.Register(L);
		UnityEngine_UI_LayoutGroupWrap.Register(L);
		L.BeginModule("InputField");
		L.RegFunction("OnValidateInput", new LuaCSFunction(LuaBinder.UnityEngine_UI_InputField_OnValidateInput));
		L.EndModule();
		L.EndModule();
		L.BeginModule("EventSystems");
		UnityEngine_EventSystems_UIBehaviourWrap.Register(L);
		UnityEngine_EventSystems_BaseRaycasterWrap.Register(L);
		L.EndModule();
		L.BeginModule("Experimental");
		L.BeginModule("Director");
		UnityEngine_Experimental_Director_DirectorPlayerWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("Events");
		L.RegFunction("UnityAction", new LuaCSFunction(LuaBinder.UnityEngine_Events_UnityAction));
		L.EndModule();
		L.BeginModule("Application");
		L.RegFunction("LogCallback", new LuaCSFunction(LuaBinder.UnityEngine_Application_LogCallback));
		L.EndModule();
		L.BeginModule("Camera");
		L.RegFunction("CameraCallback", new LuaCSFunction(LuaBinder.UnityEngine_Camera_CameraCallback));
		L.EndModule();
		L.BeginModule("RectTransform");
		L.RegFunction("ReapplyDrivenProperties", new LuaCSFunction(LuaBinder.UnityEngine_RectTransform_ReapplyDrivenProperties));
		L.EndModule();
		L.EndModule();
		L.BeginModule("LuaFramework");
		LuaFramework_UtilWrap.Register(L);
		LuaFramework_AppConstWrap.Register(L);
		LuaFramework_LuaHelperWrap.Register(L);
		LuaFramework_ByteBufferWrap.Register(L);
		LuaFramework_LuaBehaviourWrap.Register(L);
		LuaFramework_PrefabLoaderWrap.Register(L);
		LuaFramework_SoundManagerWrap.Register(L);
		LuaFramework_NetworkManagerWrap.Register(L);
		LuaFramework_ResourceManagerWrap.Register(L);
		L.EndModule();
		L.BeginModule("Hummingbird");
		L.BeginModule("Model");
		Hummingbird_Model_GameConfigInfoWrap.Register(L);
		Hummingbird_Model_DeviceDrainModelWrap.Register(L);
		L.EndModule();
		L.BeginModule("SeaBattle");
		L.BeginModule("Controller");
		L.BeginModule("CameraControll");
		Hummingbird_SeaBattle_Controller_CameraControll_HandleInputInViewPortRectWrap.Register(L);
		Hummingbird_SeaBattle_Controller_CameraControll_HandleCameraActionWrap.Register(L);
		L.EndModule();
		L.BeginModule("Map");
		Hummingbird_SeaBattle_Controller_Map_WorldMapControllerWrap.Register(L);
		Hummingbird_SeaBattle_Controller_Map_BusinessSysMapControllerWrap.Register(L);
		Hummingbird_SeaBattle_Controller_Map_FubenTwoDMapControllerWrap.Register(L);
		L.EndModule();
		L.BeginModule("Guide");
		Hummingbird_SeaBattle_Controller_Guide_GuideHighlightMaskWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("Utility");
		Hummingbird_SeaBattle_Utility_TweenUtilWrap.Register(L);
		Hummingbird_SeaBattle_Utility_NumberTextWrap.Register(L);
		L.BeginModule("RichText");
		Hummingbird_SeaBattle_Utility_RichText_RichTextWrap.Register(L);
		L.EndModule();
		L.BeginModule("FNScrollRect");
		Hummingbird_SeaBattle_Utility_FNScrollRect_FNScrollViewWrap.Register(L);
		L.EndModule();
		L.BeginModule("Platform");
		Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("Common");
		Hummingbird_SeaBattle_Common_FrameEventReceiverWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.BeginModule("System");
		L.RegFunction("Action", new LuaCSFunction(LuaBinder.System_Action));
		L.RegFunction("Action_bool", new LuaCSFunction(LuaBinder.System_Action_bool));
		L.RegFunction("Action_UnityEngine_AssetBundle", new LuaCSFunction(LuaBinder.System_Action_UnityEngine_AssetBundle));
		L.RegFunction("Action_UnityEngine_Objects", new LuaCSFunction(LuaBinder.System_Action_UnityEngine_Objects));
		L.RegFunction("Action_UnityEngine_Vector3", new LuaCSFunction(LuaBinder.System_Action_UnityEngine_Vector3));
		L.RegFunction("Action_string", new LuaCSFunction(LuaBinder.System_Action_string));
		L.RegFunction("Action_int", new LuaCSFunction(LuaBinder.System_Action_int));
		L.EndModule();
		L.EndModule();
		Debugger.Log("Register lua type cost time: {0}", Time.realtimeSinceStartup - realtimeSinceStartup);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_UI_InputField_OnValidateInput(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(InputField.OnValidateInput), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(InputField.OnValidateInput), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_Events_UnityAction(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UnityAction), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UnityAction), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_Application_LogCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Application.LogCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Application.LogCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_Camera_CameraCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Camera.CameraCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Camera.CameraCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_RectTransform_ReapplyDrivenProperties(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(RectTransform.ReapplyDrivenProperties), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(RectTransform.ReapplyDrivenProperties), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_bool(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<bool>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<bool>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_UnityEngine_AssetBundle(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<AssetBundle>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<AssetBundle>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_UnityEngine_Objects(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<UnityEngine.Object[]>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<UnityEngine.Object[]>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_UnityEngine_Vector3(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<Vector3>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<Vector3>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_string(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<string>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<string>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_int(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<int>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<int>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
