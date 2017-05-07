using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class DelegateFactory
{
	private class System_Action_Event : LuaDelegate
	{
		public System_Action_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_Events_UnityAction_Event : LuaDelegate
	{
		public UnityEngine_Events_UnityAction_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Events_UnityAction_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_Application_LogCallback_Event : LuaDelegate
	{
		public UnityEngine_Application_LogCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Application_LogCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0, string param1, LogType param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0, string param1, LogType param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_Camera_CameraCallback_Event : LuaDelegate
	{
		public UnityEngine_Camera_CameraCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Camera_CameraCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Camera param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Camera param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_RectTransform_ReapplyDrivenProperties_Event : LuaDelegate
	{
		public UnityEngine_RectTransform_ReapplyDrivenProperties_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_RectTransform_ReapplyDrivenProperties_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(RectTransform param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(RectTransform param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_UI_InputField_OnValidateInput_Event : LuaDelegate
	{
		public UnityEngine_UI_InputField_OnValidateInput_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_UI_InputField_OnValidateInput_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public char Call(string param0, int param1, char param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push((int)param2);
			this.func.PCall();
			char result = (char)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public char CallWithSelf(string param0, int param1, char param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push((int)param2);
			this.func.PCall();
			char result = (char)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Action_bool_Event : LuaDelegate
	{
		public System_Action_bool_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_bool_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(bool param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(bool param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_UnityEngine_AssetBundle_Event : LuaDelegate
	{
		public System_Action_UnityEngine_AssetBundle_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UnityEngine_AssetBundle_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(AssetBundle param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(AssetBundle param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_UnityEngine_Objects_Event : LuaDelegate
	{
		public System_Action_UnityEngine_Objects_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UnityEngine_Objects_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(UnityEngine.Object[] param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(UnityEngine.Object[] param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_UnityEngine_Vector3_Event : LuaDelegate
	{
		public System_Action_UnityEngine_Vector3_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UnityEngine_Vector3_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Vector3 param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Vector3 param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_string_Event : LuaDelegate
	{
		public System_Action_string_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_int_Event : LuaDelegate
	{
		public System_Action_int_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_int_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	public delegate Delegate DelegateValue(LuaFunction func, LuaTable self, bool flag);

	public static Dictionary<Type, DelegateFactory.DelegateValue> dict;

	static DelegateFactory()
	{
		DelegateFactory.dict = new Dictionary<Type, DelegateFactory.DelegateValue>();
		DelegateFactory.Register();
	}

	[NoToLua]
	public static void Register()
	{
		DelegateFactory.dict.Clear();
		DelegateFactory.dict.Add(typeof(Action), new DelegateFactory.DelegateValue(DelegateFactory.System_Action));
		DelegateFactory.dict.Add(typeof(UnityAction), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Events_UnityAction));
		DelegateFactory.dict.Add(typeof(Application.LogCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Application_LogCallback));
		DelegateFactory.dict.Add(typeof(Camera.CameraCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Camera_CameraCallback));
		DelegateFactory.dict.Add(typeof(RectTransform.ReapplyDrivenProperties), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_RectTransform_ReapplyDrivenProperties));
		DelegateFactory.dict.Add(typeof(InputField.OnValidateInput), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_UI_InputField_OnValidateInput));
		DelegateFactory.dict.Add(typeof(Action<bool>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_bool));
		DelegateFactory.dict.Add(typeof(Action<AssetBundle>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UnityEngine_AssetBundle));
		DelegateFactory.dict.Add(typeof(Action<UnityEngine.Object[]>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UnityEngine_Objects));
		DelegateFactory.dict.Add(typeof(Action<Vector3>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UnityEngine_Vector3));
		DelegateFactory.dict.Add(typeof(Action<string>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_string));
		DelegateFactory.dict.Add(typeof(Action<int>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_int));
	}

	[NoToLua]
	public static Delegate CreateDelegate(Type t, LuaFunction func = null)
	{
		DelegateFactory.DelegateValue delegateValue = null;
		if (!DelegateFactory.dict.TryGetValue(t, out delegateValue))
		{
			throw new LuaException(string.Format("Delegate {0} not register", LuaMisc.GetTypeName(t)), null, 1);
		}
		if (!(func != null))
		{
			return delegateValue(func, null, false);
		}
		LuaState luaState = func.GetLuaState();
		LuaDelegate luaDelegate = luaState.GetLuaDelegate(func);
		if (luaDelegate != null)
		{
			return Delegate.CreateDelegate(t, luaDelegate, luaDelegate.method);
		}
		Delegate @delegate = delegateValue(func, null, false);
		luaDelegate = (@delegate.Target as LuaDelegate);
		luaState.AddLuaDelegate(luaDelegate, func);
		return @delegate;
	}

	[NoToLua]
	public static Delegate CreateDelegate(Type t, LuaFunction func, LuaTable self)
	{
		DelegateFactory.DelegateValue delegateValue = null;
		if (!DelegateFactory.dict.TryGetValue(t, out delegateValue))
		{
			throw new LuaException(string.Format("Delegate {0} not register", LuaMisc.GetTypeName(t)), null, 1);
		}
		if (!(func != null))
		{
			return delegateValue(func, self, true);
		}
		LuaState luaState = func.GetLuaState();
		LuaDelegate luaDelegate = luaState.GetLuaDelegate(func, self);
		if (luaDelegate != null)
		{
			return Delegate.CreateDelegate(t, luaDelegate, luaDelegate.method);
		}
		Delegate @delegate = delegateValue(func, self, true);
		luaDelegate = (@delegate.Target as LuaDelegate);
		luaState.AddLuaDelegate(luaDelegate, func, self);
		return @delegate;
	}

	[NoToLua]
	public static Delegate RemoveDelegate(Delegate obj, LuaFunction func)
	{
		LuaState luaState = func.GetLuaState();
		Delegate[] invocationList = obj.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			LuaDelegate luaDelegate = invocationList[i].Target as LuaDelegate;
			if (luaDelegate != null && luaDelegate.func == func)
			{
				obj = Delegate.Remove(obj, invocationList[i]);
				luaState.DelayDispose(luaDelegate.func);
				break;
			}
		}
		return obj;
	}

	[NoToLua]
	public static Delegate RemoveDelegate(Delegate obj, Delegate dg)
	{
		LuaDelegate luaDelegate = dg.Target as LuaDelegate;
		if (luaDelegate == null)
		{
			obj = Delegate.Remove(obj, dg);
			return obj;
		}
		LuaState luaState = luaDelegate.func.GetLuaState();
		Delegate[] invocationList = obj.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			LuaDelegate luaDelegate2 = invocationList[i].Target as LuaDelegate;
			if (luaDelegate2 != null && luaDelegate2 == luaDelegate)
			{
				obj = Delegate.Remove(obj, invocationList[i]);
				luaState.DelayDispose(luaDelegate2.func);
				luaState.DelayDispose(luaDelegate2.self);
				break;
			}
		}
		return obj;
	}

	public static Delegate System_Action(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_Event system_Action_Event = new DelegateFactory.System_Action_Event(func);
			Action action = new Action(system_Action_Event.Call);
			system_Action_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_Event system_Action_Event2 = new DelegateFactory.System_Action_Event(func, self);
		Action action2 = new Action(system_Action_Event2.CallWithSelf);
		system_Action_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate UnityEngine_Events_UnityAction(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UnityAction(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Events_UnityAction_Event unityEngine_Events_UnityAction_Event = new DelegateFactory.UnityEngine_Events_UnityAction_Event(func);
			UnityAction unityAction = new UnityAction(unityEngine_Events_UnityAction_Event.Call);
			unityEngine_Events_UnityAction_Event.method = unityAction.Method;
			return unityAction;
		}
		DelegateFactory.UnityEngine_Events_UnityAction_Event unityEngine_Events_UnityAction_Event2 = new DelegateFactory.UnityEngine_Events_UnityAction_Event(func, self);
		UnityAction unityAction2 = new UnityAction(unityEngine_Events_UnityAction_Event2.CallWithSelf);
		unityEngine_Events_UnityAction_Event2.method = unityAction2.Method;
		return unityAction2;
	}

	public static Delegate UnityEngine_Application_LogCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Application.LogCallback(delegate(string param0, string param1, LogType param2)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Application_LogCallback_Event unityEngine_Application_LogCallback_Event = new DelegateFactory.UnityEngine_Application_LogCallback_Event(func);
			Application.LogCallback logCallback = new Application.LogCallback(unityEngine_Application_LogCallback_Event.Call);
			unityEngine_Application_LogCallback_Event.method = logCallback.Method;
			return logCallback;
		}
		DelegateFactory.UnityEngine_Application_LogCallback_Event unityEngine_Application_LogCallback_Event2 = new DelegateFactory.UnityEngine_Application_LogCallback_Event(func, self);
		Application.LogCallback logCallback2 = new Application.LogCallback(unityEngine_Application_LogCallback_Event2.CallWithSelf);
		unityEngine_Application_LogCallback_Event2.method = logCallback2.Method;
		return logCallback2;
	}

	public static Delegate UnityEngine_Camera_CameraCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Camera.CameraCallback(delegate(Camera param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Camera_CameraCallback_Event unityEngine_Camera_CameraCallback_Event = new DelegateFactory.UnityEngine_Camera_CameraCallback_Event(func);
			Camera.CameraCallback cameraCallback = new Camera.CameraCallback(unityEngine_Camera_CameraCallback_Event.Call);
			unityEngine_Camera_CameraCallback_Event.method = cameraCallback.Method;
			return cameraCallback;
		}
		DelegateFactory.UnityEngine_Camera_CameraCallback_Event unityEngine_Camera_CameraCallback_Event2 = new DelegateFactory.UnityEngine_Camera_CameraCallback_Event(func, self);
		Camera.CameraCallback cameraCallback2 = new Camera.CameraCallback(unityEngine_Camera_CameraCallback_Event2.CallWithSelf);
		unityEngine_Camera_CameraCallback_Event2.method = cameraCallback2.Method;
		return cameraCallback2;
	}

	public static Delegate UnityEngine_RectTransform_ReapplyDrivenProperties(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new RectTransform.ReapplyDrivenProperties(delegate(RectTransform param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_RectTransform_ReapplyDrivenProperties_Event unityEngine_RectTransform_ReapplyDrivenProperties_Event = new DelegateFactory.UnityEngine_RectTransform_ReapplyDrivenProperties_Event(func);
			RectTransform.ReapplyDrivenProperties reapplyDrivenProperties = new RectTransform.ReapplyDrivenProperties(unityEngine_RectTransform_ReapplyDrivenProperties_Event.Call);
			unityEngine_RectTransform_ReapplyDrivenProperties_Event.method = reapplyDrivenProperties.Method;
			return reapplyDrivenProperties;
		}
		DelegateFactory.UnityEngine_RectTransform_ReapplyDrivenProperties_Event unityEngine_RectTransform_ReapplyDrivenProperties_Event2 = new DelegateFactory.UnityEngine_RectTransform_ReapplyDrivenProperties_Event(func, self);
		RectTransform.ReapplyDrivenProperties reapplyDrivenProperties2 = new RectTransform.ReapplyDrivenProperties(unityEngine_RectTransform_ReapplyDrivenProperties_Event2.CallWithSelf);
		unityEngine_RectTransform_ReapplyDrivenProperties_Event2.method = reapplyDrivenProperties2.Method;
		return reapplyDrivenProperties2;
	}

	public static Delegate UnityEngine_UI_InputField_OnValidateInput(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new InputField.OnValidateInput((string param0, int param1, char param2) => '\0');
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_UI_InputField_OnValidateInput_Event unityEngine_UI_InputField_OnValidateInput_Event = new DelegateFactory.UnityEngine_UI_InputField_OnValidateInput_Event(func);
			InputField.OnValidateInput onValidateInput = new InputField.OnValidateInput(unityEngine_UI_InputField_OnValidateInput_Event.Call);
			unityEngine_UI_InputField_OnValidateInput_Event.method = onValidateInput.Method;
			return onValidateInput;
		}
		DelegateFactory.UnityEngine_UI_InputField_OnValidateInput_Event unityEngine_UI_InputField_OnValidateInput_Event2 = new DelegateFactory.UnityEngine_UI_InputField_OnValidateInput_Event(func, self);
		InputField.OnValidateInput onValidateInput2 = new InputField.OnValidateInput(unityEngine_UI_InputField_OnValidateInput_Event2.CallWithSelf);
		unityEngine_UI_InputField_OnValidateInput_Event2.method = onValidateInput2.Method;
		return onValidateInput2;
	}

	public static Delegate System_Action_bool(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<bool>(delegate(bool param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_bool_Event system_Action_bool_Event = new DelegateFactory.System_Action_bool_Event(func);
			Action<bool> action = new Action<bool>(system_Action_bool_Event.Call);
			system_Action_bool_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_bool_Event system_Action_bool_Event2 = new DelegateFactory.System_Action_bool_Event(func, self);
		Action<bool> action2 = new Action<bool>(system_Action_bool_Event2.CallWithSelf);
		system_Action_bool_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_UnityEngine_AssetBundle(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<AssetBundle>(delegate(AssetBundle param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UnityEngine_AssetBundle_Event system_Action_UnityEngine_AssetBundle_Event = new DelegateFactory.System_Action_UnityEngine_AssetBundle_Event(func);
			Action<AssetBundle> action = new Action<AssetBundle>(system_Action_UnityEngine_AssetBundle_Event.Call);
			system_Action_UnityEngine_AssetBundle_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UnityEngine_AssetBundle_Event system_Action_UnityEngine_AssetBundle_Event2 = new DelegateFactory.System_Action_UnityEngine_AssetBundle_Event(func, self);
		Action<AssetBundle> action2 = new Action<AssetBundle>(system_Action_UnityEngine_AssetBundle_Event2.CallWithSelf);
		system_Action_UnityEngine_AssetBundle_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_UnityEngine_Objects(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<UnityEngine.Object[]>(delegate(UnityEngine.Object[] param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UnityEngine_Objects_Event system_Action_UnityEngine_Objects_Event = new DelegateFactory.System_Action_UnityEngine_Objects_Event(func);
			Action<UnityEngine.Object[]> action = new Action<UnityEngine.Object[]>(system_Action_UnityEngine_Objects_Event.Call);
			system_Action_UnityEngine_Objects_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UnityEngine_Objects_Event system_Action_UnityEngine_Objects_Event2 = new DelegateFactory.System_Action_UnityEngine_Objects_Event(func, self);
		Action<UnityEngine.Object[]> action2 = new Action<UnityEngine.Object[]>(system_Action_UnityEngine_Objects_Event2.CallWithSelf);
		system_Action_UnityEngine_Objects_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_UnityEngine_Vector3(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<Vector3>(delegate(Vector3 param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UnityEngine_Vector3_Event system_Action_UnityEngine_Vector3_Event = new DelegateFactory.System_Action_UnityEngine_Vector3_Event(func);
			Action<Vector3> action = new Action<Vector3>(system_Action_UnityEngine_Vector3_Event.Call);
			system_Action_UnityEngine_Vector3_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UnityEngine_Vector3_Event system_Action_UnityEngine_Vector3_Event2 = new DelegateFactory.System_Action_UnityEngine_Vector3_Event(func, self);
		Action<Vector3> action2 = new Action<Vector3>(system_Action_UnityEngine_Vector3_Event2.CallWithSelf);
		system_Action_UnityEngine_Vector3_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<string>(delegate(string param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_string_Event system_Action_string_Event = new DelegateFactory.System_Action_string_Event(func);
			Action<string> action = new Action<string>(system_Action_string_Event.Call);
			system_Action_string_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_string_Event system_Action_string_Event2 = new DelegateFactory.System_Action_string_Event(func, self);
		Action<string> action2 = new Action<string>(system_Action_string_Event2.CallWithSelf);
		system_Action_string_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<int>(delegate(int param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_int_Event system_Action_int_Event = new DelegateFactory.System_Action_int_Event(func);
			Action<int> action = new Action<int>(system_Action_int_Event.Call);
			system_Action_int_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_int_Event system_Action_int_Event2 = new DelegateFactory.System_Action_int_Event(func, self);
		Action<int> action2 = new Action<int>(system_Action_int_Event2.CallWithSelf);
		system_Action_int_Event2.method = action2.Method;
		return action2;
	}
}
