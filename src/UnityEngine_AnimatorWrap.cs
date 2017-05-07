using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Experimental.Director;

public class UnityEngine_AnimatorWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Animator), typeof(DirectorPlayer), null);
		L.RegFunction("GetFloat", new LuaCSFunction(UnityEngine_AnimatorWrap.GetFloat));
		L.RegFunction("SetFloat", new LuaCSFunction(UnityEngine_AnimatorWrap.SetFloat));
		L.RegFunction("GetBool", new LuaCSFunction(UnityEngine_AnimatorWrap.GetBool));
		L.RegFunction("SetBool", new LuaCSFunction(UnityEngine_AnimatorWrap.SetBool));
		L.RegFunction("GetInteger", new LuaCSFunction(UnityEngine_AnimatorWrap.GetInteger));
		L.RegFunction("SetInteger", new LuaCSFunction(UnityEngine_AnimatorWrap.SetInteger));
		L.RegFunction("SetTrigger", new LuaCSFunction(UnityEngine_AnimatorWrap.SetTrigger));
		L.RegFunction("ResetTrigger", new LuaCSFunction(UnityEngine_AnimatorWrap.ResetTrigger));
		L.RegFunction("IsParameterControlledByCurve", new LuaCSFunction(UnityEngine_AnimatorWrap.IsParameterControlledByCurve));
		L.RegFunction("GetIKPosition", new LuaCSFunction(UnityEngine_AnimatorWrap.GetIKPosition));
		L.RegFunction("SetIKPosition", new LuaCSFunction(UnityEngine_AnimatorWrap.SetIKPosition));
		L.RegFunction("GetIKRotation", new LuaCSFunction(UnityEngine_AnimatorWrap.GetIKRotation));
		L.RegFunction("SetIKRotation", new LuaCSFunction(UnityEngine_AnimatorWrap.SetIKRotation));
		L.RegFunction("GetIKPositionWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.GetIKPositionWeight));
		L.RegFunction("SetIKPositionWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.SetIKPositionWeight));
		L.RegFunction("GetIKRotationWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.GetIKRotationWeight));
		L.RegFunction("SetIKRotationWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.SetIKRotationWeight));
		L.RegFunction("GetIKHintPosition", new LuaCSFunction(UnityEngine_AnimatorWrap.GetIKHintPosition));
		L.RegFunction("SetIKHintPosition", new LuaCSFunction(UnityEngine_AnimatorWrap.SetIKHintPosition));
		L.RegFunction("GetIKHintPositionWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.GetIKHintPositionWeight));
		L.RegFunction("SetIKHintPositionWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.SetIKHintPositionWeight));
		L.RegFunction("SetLookAtPosition", new LuaCSFunction(UnityEngine_AnimatorWrap.SetLookAtPosition));
		L.RegFunction("SetLookAtWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.SetLookAtWeight));
		L.RegFunction("SetBoneLocalRotation", new LuaCSFunction(UnityEngine_AnimatorWrap.SetBoneLocalRotation));
		L.RegFunction("GetLayerName", new LuaCSFunction(UnityEngine_AnimatorWrap.GetLayerName));
		L.RegFunction("GetLayerIndex", new LuaCSFunction(UnityEngine_AnimatorWrap.GetLayerIndex));
		L.RegFunction("GetLayerWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.GetLayerWeight));
		L.RegFunction("SetLayerWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.SetLayerWeight));
		L.RegFunction("GetCurrentAnimatorStateInfo", new LuaCSFunction(UnityEngine_AnimatorWrap.GetCurrentAnimatorStateInfo));
		L.RegFunction("GetNextAnimatorStateInfo", new LuaCSFunction(UnityEngine_AnimatorWrap.GetNextAnimatorStateInfo));
		L.RegFunction("GetAnimatorTransitionInfo", new LuaCSFunction(UnityEngine_AnimatorWrap.GetAnimatorTransitionInfo));
		L.RegFunction("GetCurrentAnimatorClipInfo", new LuaCSFunction(UnityEngine_AnimatorWrap.GetCurrentAnimatorClipInfo));
		L.RegFunction("GetNextAnimatorClipInfo", new LuaCSFunction(UnityEngine_AnimatorWrap.GetNextAnimatorClipInfo));
		L.RegFunction("IsInTransition", new LuaCSFunction(UnityEngine_AnimatorWrap.IsInTransition));
		L.RegFunction("GetParameter", new LuaCSFunction(UnityEngine_AnimatorWrap.GetParameter));
		L.RegFunction("MatchTarget", new LuaCSFunction(UnityEngine_AnimatorWrap.MatchTarget));
		L.RegFunction("InterruptMatchTarget", new LuaCSFunction(UnityEngine_AnimatorWrap.InterruptMatchTarget));
		L.RegFunction("CrossFadeInFixedTime", new LuaCSFunction(UnityEngine_AnimatorWrap.CrossFadeInFixedTime));
		L.RegFunction("CrossFade", new LuaCSFunction(UnityEngine_AnimatorWrap.CrossFade));
		L.RegFunction("PlayInFixedTime", new LuaCSFunction(UnityEngine_AnimatorWrap.PlayInFixedTime));
		L.RegFunction("Play", new LuaCSFunction(UnityEngine_AnimatorWrap.Play));
		L.RegFunction("SetTarget", new LuaCSFunction(UnityEngine_AnimatorWrap.SetTarget));
		L.RegFunction("GetBoneTransform", new LuaCSFunction(UnityEngine_AnimatorWrap.GetBoneTransform));
		L.RegFunction("StartPlayback", new LuaCSFunction(UnityEngine_AnimatorWrap.StartPlayback));
		L.RegFunction("StopPlayback", new LuaCSFunction(UnityEngine_AnimatorWrap.StopPlayback));
		L.RegFunction("StartRecording", new LuaCSFunction(UnityEngine_AnimatorWrap.StartRecording));
		L.RegFunction("StopRecording", new LuaCSFunction(UnityEngine_AnimatorWrap.StopRecording));
		L.RegFunction("HasState", new LuaCSFunction(UnityEngine_AnimatorWrap.HasState));
		L.RegFunction("StringToHash", new LuaCSFunction(UnityEngine_AnimatorWrap.StringToHash));
		L.RegFunction("Update", new LuaCSFunction(UnityEngine_AnimatorWrap.Update));
		L.RegFunction("Rebind", new LuaCSFunction(UnityEngine_AnimatorWrap.Rebind));
		L.RegFunction("ApplyBuiltinRootMotion", new LuaCSFunction(UnityEngine_AnimatorWrap.ApplyBuiltinRootMotion));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_AnimatorWrap._CreateUnityEngine_Animator));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_AnimatorWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("isOptimizable", new LuaCSFunction(UnityEngine_AnimatorWrap.get_isOptimizable), null);
		L.RegVar("isHuman", new LuaCSFunction(UnityEngine_AnimatorWrap.get_isHuman), null);
		L.RegVar("hasRootMotion", new LuaCSFunction(UnityEngine_AnimatorWrap.get_hasRootMotion), null);
		L.RegVar("humanScale", new LuaCSFunction(UnityEngine_AnimatorWrap.get_humanScale), null);
		L.RegVar("isInitialized", new LuaCSFunction(UnityEngine_AnimatorWrap.get_isInitialized), null);
		L.RegVar("deltaPosition", new LuaCSFunction(UnityEngine_AnimatorWrap.get_deltaPosition), null);
		L.RegVar("deltaRotation", new LuaCSFunction(UnityEngine_AnimatorWrap.get_deltaRotation), null);
		L.RegVar("velocity", new LuaCSFunction(UnityEngine_AnimatorWrap.get_velocity), null);
		L.RegVar("angularVelocity", new LuaCSFunction(UnityEngine_AnimatorWrap.get_angularVelocity), null);
		L.RegVar("rootPosition", new LuaCSFunction(UnityEngine_AnimatorWrap.get_rootPosition), new LuaCSFunction(UnityEngine_AnimatorWrap.set_rootPosition));
		L.RegVar("rootRotation", new LuaCSFunction(UnityEngine_AnimatorWrap.get_rootRotation), new LuaCSFunction(UnityEngine_AnimatorWrap.set_rootRotation));
		L.RegVar("applyRootMotion", new LuaCSFunction(UnityEngine_AnimatorWrap.get_applyRootMotion), new LuaCSFunction(UnityEngine_AnimatorWrap.set_applyRootMotion));
		L.RegVar("linearVelocityBlending", new LuaCSFunction(UnityEngine_AnimatorWrap.get_linearVelocityBlending), new LuaCSFunction(UnityEngine_AnimatorWrap.set_linearVelocityBlending));
		L.RegVar("updateMode", new LuaCSFunction(UnityEngine_AnimatorWrap.get_updateMode), new LuaCSFunction(UnityEngine_AnimatorWrap.set_updateMode));
		L.RegVar("hasTransformHierarchy", new LuaCSFunction(UnityEngine_AnimatorWrap.get_hasTransformHierarchy), null);
		L.RegVar("gravityWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.get_gravityWeight), null);
		L.RegVar("bodyPosition", new LuaCSFunction(UnityEngine_AnimatorWrap.get_bodyPosition), new LuaCSFunction(UnityEngine_AnimatorWrap.set_bodyPosition));
		L.RegVar("bodyRotation", new LuaCSFunction(UnityEngine_AnimatorWrap.get_bodyRotation), new LuaCSFunction(UnityEngine_AnimatorWrap.set_bodyRotation));
		L.RegVar("stabilizeFeet", new LuaCSFunction(UnityEngine_AnimatorWrap.get_stabilizeFeet), new LuaCSFunction(UnityEngine_AnimatorWrap.set_stabilizeFeet));
		L.RegVar("layerCount", new LuaCSFunction(UnityEngine_AnimatorWrap.get_layerCount), null);
		L.RegVar("parameters", new LuaCSFunction(UnityEngine_AnimatorWrap.get_parameters), null);
		L.RegVar("parameterCount", new LuaCSFunction(UnityEngine_AnimatorWrap.get_parameterCount), null);
		L.RegVar("feetPivotActive", new LuaCSFunction(UnityEngine_AnimatorWrap.get_feetPivotActive), new LuaCSFunction(UnityEngine_AnimatorWrap.set_feetPivotActive));
		L.RegVar("pivotWeight", new LuaCSFunction(UnityEngine_AnimatorWrap.get_pivotWeight), null);
		L.RegVar("pivotPosition", new LuaCSFunction(UnityEngine_AnimatorWrap.get_pivotPosition), null);
		L.RegVar("isMatchingTarget", new LuaCSFunction(UnityEngine_AnimatorWrap.get_isMatchingTarget), null);
		L.RegVar("speed", new LuaCSFunction(UnityEngine_AnimatorWrap.get_speed), new LuaCSFunction(UnityEngine_AnimatorWrap.set_speed));
		L.RegVar("targetPosition", new LuaCSFunction(UnityEngine_AnimatorWrap.get_targetPosition), null);
		L.RegVar("targetRotation", new LuaCSFunction(UnityEngine_AnimatorWrap.get_targetRotation), null);
		L.RegVar("cullingMode", new LuaCSFunction(UnityEngine_AnimatorWrap.get_cullingMode), new LuaCSFunction(UnityEngine_AnimatorWrap.set_cullingMode));
		L.RegVar("playbackTime", new LuaCSFunction(UnityEngine_AnimatorWrap.get_playbackTime), new LuaCSFunction(UnityEngine_AnimatorWrap.set_playbackTime));
		L.RegVar("recorderStartTime", new LuaCSFunction(UnityEngine_AnimatorWrap.get_recorderStartTime), new LuaCSFunction(UnityEngine_AnimatorWrap.set_recorderStartTime));
		L.RegVar("recorderStopTime", new LuaCSFunction(UnityEngine_AnimatorWrap.get_recorderStopTime), new LuaCSFunction(UnityEngine_AnimatorWrap.set_recorderStopTime));
		L.RegVar("recorderMode", new LuaCSFunction(UnityEngine_AnimatorWrap.get_recorderMode), null);
		L.RegVar("runtimeAnimatorController", new LuaCSFunction(UnityEngine_AnimatorWrap.get_runtimeAnimatorController), new LuaCSFunction(UnityEngine_AnimatorWrap.set_runtimeAnimatorController));
		L.RegVar("avatar", new LuaCSFunction(UnityEngine_AnimatorWrap.get_avatar), new LuaCSFunction(UnityEngine_AnimatorWrap.set_avatar));
		L.RegVar("layersAffectMassCenter", new LuaCSFunction(UnityEngine_AnimatorWrap.get_layersAffectMassCenter), new LuaCSFunction(UnityEngine_AnimatorWrap.set_layersAffectMassCenter));
		L.RegVar("leftFeetBottomHeight", new LuaCSFunction(UnityEngine_AnimatorWrap.get_leftFeetBottomHeight), null);
		L.RegVar("rightFeetBottomHeight", new LuaCSFunction(UnityEngine_AnimatorWrap.get_rightFeetBottomHeight), null);
		L.RegVar("logWarnings", new LuaCSFunction(UnityEngine_AnimatorWrap.get_logWarnings), new LuaCSFunction(UnityEngine_AnimatorWrap.set_logWarnings));
		L.RegVar("fireEvents", new LuaCSFunction(UnityEngine_AnimatorWrap.get_fireEvents), new LuaCSFunction(UnityEngine_AnimatorWrap.set_fireEvents));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Animator(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Animator obj = new Animator();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Animator.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFloat(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int id = (int)LuaDLL.lua_tonumber(L, 2);
				float @float = animator.GetFloat(id);
				LuaDLL.lua_pushnumber(L, (double)@float);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				float float2 = animator2.GetFloat(name);
				LuaDLL.lua_pushnumber(L, (double)float2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.GetFloat");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetFloat(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(float)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int id = (int)LuaDLL.lua_tonumber(L, 2);
				float value = (float)LuaDLL.lua_tonumber(L, 3);
				animator.SetFloat(id, value);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(float)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				float value2 = (float)LuaDLL.lua_tonumber(L, 3);
				animator2.SetFloat(name, value2);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(float), typeof(float), typeof(float)))
			{
				Animator animator3 = (Animator)ToLua.ToObject(L, 1);
				int id2 = (int)LuaDLL.lua_tonumber(L, 2);
				float value3 = (float)LuaDLL.lua_tonumber(L, 3);
				float dampTime = (float)LuaDLL.lua_tonumber(L, 4);
				float deltaTime = (float)LuaDLL.lua_tonumber(L, 5);
				animator3.SetFloat(id2, value3, dampTime, deltaTime);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(float), typeof(float), typeof(float)))
			{
				Animator animator4 = (Animator)ToLua.ToObject(L, 1);
				string name2 = ToLua.ToString(L, 2);
				float value4 = (float)LuaDLL.lua_tonumber(L, 3);
				float dampTime2 = (float)LuaDLL.lua_tonumber(L, 4);
				float deltaTime2 = (float)LuaDLL.lua_tonumber(L, 5);
				animator4.SetFloat(name2, value4, dampTime2, deltaTime2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.SetFloat");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBool(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int id = (int)LuaDLL.lua_tonumber(L, 2);
				bool @bool = animator.GetBool(id);
				LuaDLL.lua_pushboolean(L, @bool);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				bool bool2 = animator2.GetBool(name);
				LuaDLL.lua_pushboolean(L, bool2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.GetBool");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetBool(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(bool)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int id = (int)LuaDLL.lua_tonumber(L, 2);
				bool value = LuaDLL.lua_toboolean(L, 3);
				animator.SetBool(id, value);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(bool)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				bool value2 = LuaDLL.lua_toboolean(L, 3);
				animator2.SetBool(name, value2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.SetBool");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInteger(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int id = (int)LuaDLL.lua_tonumber(L, 2);
				int integer = animator.GetInteger(id);
				LuaDLL.lua_pushinteger(L, integer);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				int integer2 = animator2.GetInteger(name);
				LuaDLL.lua_pushinteger(L, integer2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.GetInteger");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetInteger(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(int)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int id = (int)LuaDLL.lua_tonumber(L, 2);
				int value = (int)LuaDLL.lua_tonumber(L, 3);
				animator.SetInteger(id, value);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(int)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				int value2 = (int)LuaDLL.lua_tonumber(L, 3);
				animator2.SetInteger(name, value2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.SetInteger");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTrigger(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int trigger = (int)LuaDLL.lua_tonumber(L, 2);
				animator.SetTrigger(trigger);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string trigger2 = ToLua.ToString(L, 2);
				animator2.SetTrigger(trigger2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.SetTrigger");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetTrigger(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int id = (int)LuaDLL.lua_tonumber(L, 2);
				animator.ResetTrigger(id);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				animator2.ResetTrigger(name);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.ResetTrigger");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsParameterControlledByCurve(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int id = (int)LuaDLL.lua_tonumber(L, 2);
				bool value = animator.IsParameterControlledByCurve(id);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				bool value2 = animator2.IsParameterControlledByCurve(name);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.IsParameterControlledByCurve");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIKPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKGoal goal = (AvatarIKGoal)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKGoal)));
			Vector3 iKPosition = animator.GetIKPosition(goal);
			ToLua.Push(L, iKPosition);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetIKPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKGoal goal = (AvatarIKGoal)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKGoal)));
			Vector3 goalPosition = ToLua.ToVector3(L, 3);
			animator.SetIKPosition(goal, goalPosition);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIKRotation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKGoal goal = (AvatarIKGoal)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKGoal)));
			Quaternion iKRotation = animator.GetIKRotation(goal);
			ToLua.Push(L, iKRotation);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetIKRotation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKGoal goal = (AvatarIKGoal)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKGoal)));
			Quaternion goalRotation = ToLua.ToQuaternion(L, 3);
			animator.SetIKRotation(goal, goalRotation);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIKPositionWeight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKGoal goal = (AvatarIKGoal)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKGoal)));
			float iKPositionWeight = animator.GetIKPositionWeight(goal);
			LuaDLL.lua_pushnumber(L, (double)iKPositionWeight);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetIKPositionWeight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKGoal goal = (AvatarIKGoal)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKGoal)));
			float value = (float)LuaDLL.luaL_checknumber(L, 3);
			animator.SetIKPositionWeight(goal, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIKRotationWeight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKGoal goal = (AvatarIKGoal)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKGoal)));
			float iKRotationWeight = animator.GetIKRotationWeight(goal);
			LuaDLL.lua_pushnumber(L, (double)iKRotationWeight);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetIKRotationWeight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKGoal goal = (AvatarIKGoal)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKGoal)));
			float value = (float)LuaDLL.luaL_checknumber(L, 3);
			animator.SetIKRotationWeight(goal, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIKHintPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKHint hint = (AvatarIKHint)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKHint)));
			Vector3 iKHintPosition = animator.GetIKHintPosition(hint);
			ToLua.Push(L, iKHintPosition);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetIKHintPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKHint hint = (AvatarIKHint)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKHint)));
			Vector3 hintPosition = ToLua.ToVector3(L, 3);
			animator.SetIKHintPosition(hint, hintPosition);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIKHintPositionWeight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKHint hint = (AvatarIKHint)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKHint)));
			float iKHintPositionWeight = animator.GetIKHintPositionWeight(hint);
			LuaDLL.lua_pushnumber(L, (double)iKHintPositionWeight);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetIKHintPositionWeight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarIKHint hint = (AvatarIKHint)((int)ToLua.CheckObject(L, 2, typeof(AvatarIKHint)));
			float value = (float)LuaDLL.luaL_checknumber(L, 3);
			animator.SetIKHintPositionWeight(hint, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLookAtPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			Vector3 lookAtPosition = ToLua.ToVector3(L, 2);
			animator.SetLookAtPosition(lookAtPosition);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLookAtWeight(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(float)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				float lookAtWeight = (float)LuaDLL.lua_tonumber(L, 2);
				animator.SetLookAtWeight(lookAtWeight);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(float), typeof(float)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				float weight = (float)LuaDLL.lua_tonumber(L, 2);
				float bodyWeight = (float)LuaDLL.lua_tonumber(L, 3);
				animator2.SetLookAtWeight(weight, bodyWeight);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(float), typeof(float), typeof(float)))
			{
				Animator animator3 = (Animator)ToLua.ToObject(L, 1);
				float weight2 = (float)LuaDLL.lua_tonumber(L, 2);
				float bodyWeight2 = (float)LuaDLL.lua_tonumber(L, 3);
				float headWeight = (float)LuaDLL.lua_tonumber(L, 4);
				animator3.SetLookAtWeight(weight2, bodyWeight2, headWeight);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				Animator animator4 = (Animator)ToLua.ToObject(L, 1);
				float weight3 = (float)LuaDLL.lua_tonumber(L, 2);
				float bodyWeight3 = (float)LuaDLL.lua_tonumber(L, 3);
				float headWeight2 = (float)LuaDLL.lua_tonumber(L, 4);
				float eyesWeight = (float)LuaDLL.lua_tonumber(L, 5);
				animator4.SetLookAtWeight(weight3, bodyWeight3, headWeight2, eyesWeight);
				result = 0;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				Animator animator5 = (Animator)ToLua.ToObject(L, 1);
				float weight4 = (float)LuaDLL.lua_tonumber(L, 2);
				float bodyWeight4 = (float)LuaDLL.lua_tonumber(L, 3);
				float headWeight3 = (float)LuaDLL.lua_tonumber(L, 4);
				float eyesWeight2 = (float)LuaDLL.lua_tonumber(L, 5);
				float clampWeight = (float)LuaDLL.lua_tonumber(L, 6);
				animator5.SetLookAtWeight(weight4, bodyWeight4, headWeight3, eyesWeight2, clampWeight);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.SetLookAtWeight");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetBoneLocalRotation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			HumanBodyBones humanBoneId = (HumanBodyBones)((int)ToLua.CheckObject(L, 2, typeof(HumanBodyBones)));
			Quaternion rotation = ToLua.ToQuaternion(L, 3);
			animator.SetBoneLocalRotation(humanBoneId, rotation);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLayerName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int layerIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			string layerName = animator.GetLayerName(layerIndex);
			LuaDLL.lua_pushstring(L, layerName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLayerIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			string layerName = ToLua.CheckString(L, 2);
			int layerIndex = animator.GetLayerIndex(layerName);
			LuaDLL.lua_pushinteger(L, layerIndex);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLayerWeight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int layerIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			float layerWeight = animator.GetLayerWeight(layerIndex);
			LuaDLL.lua_pushnumber(L, (double)layerWeight);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayerWeight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int layerIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			float weight = (float)LuaDLL.luaL_checknumber(L, 3);
			animator.SetLayerWeight(layerIndex, weight);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCurrentAnimatorStateInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int layerIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
			ToLua.PushValue(L, currentAnimatorStateInfo);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNextAnimatorStateInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int layerIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			AnimatorStateInfo nextAnimatorStateInfo = animator.GetNextAnimatorStateInfo(layerIndex);
			ToLua.PushValue(L, nextAnimatorStateInfo);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAnimatorTransitionInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int layerIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			AnimatorTransitionInfo animatorTransitionInfo = animator.GetAnimatorTransitionInfo(layerIndex);
			ToLua.PushValue(L, animatorTransitionInfo);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCurrentAnimatorClipInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int layerIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			AnimatorClipInfo[] currentAnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
			ToLua.Push(L, currentAnimatorClipInfo);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNextAnimatorClipInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int layerIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			AnimatorClipInfo[] nextAnimatorClipInfo = animator.GetNextAnimatorClipInfo(layerIndex);
			ToLua.Push(L, nextAnimatorClipInfo);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsInTransition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int layerIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			bool value = animator.IsInTransition(layerIndex);
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
	private static int GetParameter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			AnimatorControllerParameter parameter = animator.GetParameter(index);
			ToLua.PushObject(L, parameter);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MatchTarget(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(Vector3), typeof(Quaternion), typeof(AvatarTarget), typeof(MatchTargetWeightMask), typeof(float)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				Vector3 matchPosition = ToLua.ToVector3(L, 2);
				Quaternion matchRotation = ToLua.ToQuaternion(L, 3);
				AvatarTarget targetBodyPart = (AvatarTarget)((int)ToLua.ToObject(L, 4));
				MatchTargetWeightMask weightMask = (MatchTargetWeightMask)ToLua.ToObject(L, 5);
				float startNormalizedTime = (float)LuaDLL.lua_tonumber(L, 6);
				animator.MatchTarget(matchPosition, matchRotation, targetBodyPart, weightMask, startNormalizedTime);
				result = 0;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(Vector3), typeof(Quaternion), typeof(AvatarTarget), typeof(MatchTargetWeightMask), typeof(float), typeof(float)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				Vector3 matchPosition2 = ToLua.ToVector3(L, 2);
				Quaternion matchRotation2 = ToLua.ToQuaternion(L, 3);
				AvatarTarget targetBodyPart2 = (AvatarTarget)((int)ToLua.ToObject(L, 4));
				MatchTargetWeightMask weightMask2 = (MatchTargetWeightMask)ToLua.ToObject(L, 5);
				float startNormalizedTime2 = (float)LuaDLL.lua_tonumber(L, 6);
				float targetNormalizedTime = (float)LuaDLL.lua_tonumber(L, 7);
				animator2.MatchTarget(matchPosition2, matchRotation2, targetBodyPart2, weightMask2, startNormalizedTime2, targetNormalizedTime);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.MatchTarget");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InterruptMatchTarget(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Animator)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				animator.InterruptMatchTarget();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(bool)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				bool completeMatch = LuaDLL.lua_toboolean(L, 2);
				animator2.InterruptMatchTarget(completeMatch);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.InterruptMatchTarget");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CrossFadeInFixedTime(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(float)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash = (int)LuaDLL.lua_tonumber(L, 2);
				float transitionDuration = (float)LuaDLL.lua_tonumber(L, 3);
				animator.CrossFadeInFixedTime(stateNameHash, transitionDuration);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(float)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string stateName = ToLua.ToString(L, 2);
				float transitionDuration2 = (float)LuaDLL.lua_tonumber(L, 3);
				animator2.CrossFadeInFixedTime(stateName, transitionDuration2);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(float), typeof(int)))
			{
				Animator animator3 = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash2 = (int)LuaDLL.lua_tonumber(L, 2);
				float transitionDuration3 = (float)LuaDLL.lua_tonumber(L, 3);
				int layer = (int)LuaDLL.lua_tonumber(L, 4);
				animator3.CrossFadeInFixedTime(stateNameHash2, transitionDuration3, layer);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(float), typeof(int)))
			{
				Animator animator4 = (Animator)ToLua.ToObject(L, 1);
				string stateName2 = ToLua.ToString(L, 2);
				float transitionDuration4 = (float)LuaDLL.lua_tonumber(L, 3);
				int layer2 = (int)LuaDLL.lua_tonumber(L, 4);
				animator4.CrossFadeInFixedTime(stateName2, transitionDuration4, layer2);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(float), typeof(int), typeof(float)))
			{
				Animator animator5 = (Animator)ToLua.ToObject(L, 1);
				string stateName3 = ToLua.ToString(L, 2);
				float transitionDuration5 = (float)LuaDLL.lua_tonumber(L, 3);
				int layer3 = (int)LuaDLL.lua_tonumber(L, 4);
				float fixedTime = (float)LuaDLL.lua_tonumber(L, 5);
				animator5.CrossFadeInFixedTime(stateName3, transitionDuration5, layer3, fixedTime);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(float), typeof(int), typeof(float)))
			{
				Animator animator6 = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash3 = (int)LuaDLL.lua_tonumber(L, 2);
				float transitionDuration6 = (float)LuaDLL.lua_tonumber(L, 3);
				int layer4 = (int)LuaDLL.lua_tonumber(L, 4);
				float fixedTime2 = (float)LuaDLL.lua_tonumber(L, 5);
				animator6.CrossFadeInFixedTime(stateNameHash3, transitionDuration6, layer4, fixedTime2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.CrossFadeInFixedTime");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CrossFade(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(float)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash = (int)LuaDLL.lua_tonumber(L, 2);
				float transitionDuration = (float)LuaDLL.lua_tonumber(L, 3);
				animator.CrossFade(stateNameHash, transitionDuration);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(float)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string stateName = ToLua.ToString(L, 2);
				float transitionDuration2 = (float)LuaDLL.lua_tonumber(L, 3);
				animator2.CrossFade(stateName, transitionDuration2);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(float), typeof(int)))
			{
				Animator animator3 = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash2 = (int)LuaDLL.lua_tonumber(L, 2);
				float transitionDuration3 = (float)LuaDLL.lua_tonumber(L, 3);
				int layer = (int)LuaDLL.lua_tonumber(L, 4);
				animator3.CrossFade(stateNameHash2, transitionDuration3, layer);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(float), typeof(int)))
			{
				Animator animator4 = (Animator)ToLua.ToObject(L, 1);
				string stateName2 = ToLua.ToString(L, 2);
				float transitionDuration4 = (float)LuaDLL.lua_tonumber(L, 3);
				int layer2 = (int)LuaDLL.lua_tonumber(L, 4);
				animator4.CrossFade(stateName2, transitionDuration4, layer2);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(float), typeof(int), typeof(float)))
			{
				Animator animator5 = (Animator)ToLua.ToObject(L, 1);
				string stateName3 = ToLua.ToString(L, 2);
				float transitionDuration5 = (float)LuaDLL.lua_tonumber(L, 3);
				int layer3 = (int)LuaDLL.lua_tonumber(L, 4);
				float normalizedTime = (float)LuaDLL.lua_tonumber(L, 5);
				animator5.CrossFade(stateName3, transitionDuration5, layer3, normalizedTime);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(float), typeof(int), typeof(float)))
			{
				Animator animator6 = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash3 = (int)LuaDLL.lua_tonumber(L, 2);
				float transitionDuration6 = (float)LuaDLL.lua_tonumber(L, 3);
				int layer4 = (int)LuaDLL.lua_tonumber(L, 4);
				float normalizedTime2 = (float)LuaDLL.lua_tonumber(L, 5);
				animator6.CrossFade(stateNameHash3, transitionDuration6, layer4, normalizedTime2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.CrossFade");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayInFixedTime(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash = (int)LuaDLL.lua_tonumber(L, 2);
				animator.PlayInFixedTime(stateNameHash);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				string stateName = ToLua.ToString(L, 2);
				animator2.PlayInFixedTime(stateName);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(int)))
			{
				Animator animator3 = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash2 = (int)LuaDLL.lua_tonumber(L, 2);
				int layer = (int)LuaDLL.lua_tonumber(L, 3);
				animator3.PlayInFixedTime(stateNameHash2, layer);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(int)))
			{
				Animator animator4 = (Animator)ToLua.ToObject(L, 1);
				string stateName2 = ToLua.ToString(L, 2);
				int layer2 = (int)LuaDLL.lua_tonumber(L, 3);
				animator4.PlayInFixedTime(stateName2, layer2);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(int), typeof(float)))
			{
				Animator animator5 = (Animator)ToLua.ToObject(L, 1);
				string stateName3 = ToLua.ToString(L, 2);
				int layer3 = (int)LuaDLL.lua_tonumber(L, 3);
				float fixedTime = (float)LuaDLL.lua_tonumber(L, 4);
				animator5.PlayInFixedTime(stateName3, layer3, fixedTime);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(int), typeof(float)))
			{
				Animator animator6 = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash3 = (int)LuaDLL.lua_tonumber(L, 2);
				int layer4 = (int)LuaDLL.lua_tonumber(L, 3);
				float fixedTime2 = (float)LuaDLL.lua_tonumber(L, 4);
				animator6.PlayInFixedTime(stateNameHash3, layer4, fixedTime2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.PlayInFixedTime");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(Playable)))
			{
				Animator animator = (Animator)ToLua.ToObject(L, 1);
				Playable playable = (Playable)ToLua.ToObject(L, 2);
				animator.Play(playable);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int)))
			{
				Animator animator2 = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash = (int)LuaDLL.lua_tonumber(L, 2);
				animator2.Play(stateNameHash);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string)))
			{
				Animator animator3 = (Animator)ToLua.ToObject(L, 1);
				string stateName = ToLua.ToString(L, 2);
				animator3.Play(stateName);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(int)))
			{
				Animator animator4 = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash2 = (int)LuaDLL.lua_tonumber(L, 2);
				int layer = (int)LuaDLL.lua_tonumber(L, 3);
				animator4.Play(stateNameHash2, layer);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(int)))
			{
				Animator animator5 = (Animator)ToLua.ToObject(L, 1);
				string stateName2 = ToLua.ToString(L, 2);
				int layer2 = (int)LuaDLL.lua_tonumber(L, 3);
				animator5.Play(stateName2, layer2);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(Playable), typeof(object)))
			{
				Animator animator6 = (Animator)ToLua.ToObject(L, 1);
				Playable playable2 = (Playable)ToLua.ToObject(L, 2);
				object customData = ToLua.ToVarObject(L, 3);
				animator6.Play(playable2, customData);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(string), typeof(int), typeof(float)))
			{
				Animator animator7 = (Animator)ToLua.ToObject(L, 1);
				string stateName3 = ToLua.ToString(L, 2);
				int layer3 = (int)LuaDLL.lua_tonumber(L, 3);
				float normalizedTime = (float)LuaDLL.lua_tonumber(L, 4);
				animator7.Play(stateName3, layer3, normalizedTime);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animator), typeof(int), typeof(int), typeof(float)))
			{
				Animator animator8 = (Animator)ToLua.ToObject(L, 1);
				int stateNameHash3 = (int)LuaDLL.lua_tonumber(L, 2);
				int layer4 = (int)LuaDLL.lua_tonumber(L, 3);
				float normalizedTime2 = (float)LuaDLL.lua_tonumber(L, 4);
				animator8.Play(stateNameHash3, layer4, normalizedTime2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animator.Play");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTarget(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			AvatarTarget targetIndex = (AvatarTarget)((int)ToLua.CheckObject(L, 2, typeof(AvatarTarget)));
			float targetNormalizedTime = (float)LuaDLL.luaL_checknumber(L, 3);
			animator.SetTarget(targetIndex, targetNormalizedTime);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBoneTransform(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			HumanBodyBones humanBoneId = (HumanBodyBones)((int)ToLua.CheckObject(L, 2, typeof(HumanBodyBones)));
			Transform boneTransform = animator.GetBoneTransform(humanBoneId);
			ToLua.Push(L, boneTransform);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartPlayback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			animator.StartPlayback();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopPlayback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			animator.StopPlayback();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartRecording(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int frameCount = (int)LuaDLL.luaL_checknumber(L, 2);
			animator.StartRecording(frameCount);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopRecording(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			animator.StopRecording();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasState(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			int layerIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			int stateID = (int)LuaDLL.luaL_checknumber(L, 3);
			bool value = animator.HasState(layerIndex, stateID);
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
	private static int StringToHash(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string name = ToLua.CheckString(L, 1);
			int n = Animator.StringToHash(name);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Update(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			float deltaTime = (float)LuaDLL.luaL_checknumber(L, 2);
			animator.Update(deltaTime);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Rebind(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			animator.Rebind();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ApplyBuiltinRootMotion(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Animator animator = (Animator)ToLua.CheckObject(L, 1, typeof(Animator));
			animator.ApplyBuiltinRootMotion();
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
	private static int get_isOptimizable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool isOptimizable = animator.isOptimizable;
			LuaDLL.lua_pushboolean(L, isOptimizable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isOptimizable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isHuman(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool isHuman = animator.isHuman;
			LuaDLL.lua_pushboolean(L, isHuman);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isHuman on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hasRootMotion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool hasRootMotion = animator.hasRootMotion;
			LuaDLL.lua_pushboolean(L, hasRootMotion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasRootMotion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_humanScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float humanScale = animator.humanScale;
			LuaDLL.lua_pushnumber(L, (double)humanScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index humanScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isInitialized(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool isInitialized = animator.isInitialized;
			LuaDLL.lua_pushboolean(L, isInitialized);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isInitialized on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_deltaPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Vector3 deltaPosition = animator.deltaPosition;
			ToLua.Push(L, deltaPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index deltaPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_deltaRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Quaternion deltaRotation = animator.deltaRotation;
			ToLua.Push(L, deltaRotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index deltaRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_velocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Vector3 velocity = animator.velocity;
			ToLua.Push(L, velocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index velocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_angularVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Vector3 angularVelocity = animator.angularVelocity;
			ToLua.Push(L, angularVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index angularVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rootPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Vector3 rootPosition = animator.rootPosition;
			ToLua.Push(L, rootPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rootPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rootRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Quaternion rootRotation = animator.rootRotation;
			ToLua.Push(L, rootRotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rootRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_applyRootMotion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool applyRootMotion = animator.applyRootMotion;
			LuaDLL.lua_pushboolean(L, applyRootMotion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index applyRootMotion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_linearVelocityBlending(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool linearVelocityBlending = animator.linearVelocityBlending;
			LuaDLL.lua_pushboolean(L, linearVelocityBlending);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index linearVelocityBlending on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_updateMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			AnimatorUpdateMode updateMode = animator.updateMode;
			ToLua.Push(L, updateMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hasTransformHierarchy(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool hasTransformHierarchy = animator.hasTransformHierarchy;
			LuaDLL.lua_pushboolean(L, hasTransformHierarchy);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasTransformHierarchy on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gravityWeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float gravityWeight = animator.gravityWeight;
			LuaDLL.lua_pushnumber(L, (double)gravityWeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gravityWeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bodyPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Vector3 bodyPosition = animator.bodyPosition;
			ToLua.Push(L, bodyPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bodyPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bodyRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Quaternion bodyRotation = animator.bodyRotation;
			ToLua.Push(L, bodyRotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bodyRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stabilizeFeet(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool stabilizeFeet = animator.stabilizeFeet;
			LuaDLL.lua_pushboolean(L, stabilizeFeet);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stabilizeFeet on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_layerCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			int layerCount = animator.layerCount;
			LuaDLL.lua_pushinteger(L, layerCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layerCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_parameters(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			AnimatorControllerParameter[] parameters = animator.parameters;
			ToLua.Push(L, parameters);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parameters on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_parameterCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			int parameterCount = animator.parameterCount;
			LuaDLL.lua_pushinteger(L, parameterCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parameterCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_feetPivotActive(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float feetPivotActive = animator.feetPivotActive;
			LuaDLL.lua_pushnumber(L, (double)feetPivotActive);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index feetPivotActive on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pivotWeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float pivotWeight = animator.pivotWeight;
			LuaDLL.lua_pushnumber(L, (double)pivotWeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivotWeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pivotPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Vector3 pivotPosition = animator.pivotPosition;
			ToLua.Push(L, pivotPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivotPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isMatchingTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool isMatchingTarget = animator.isMatchingTarget;
			LuaDLL.lua_pushboolean(L, isMatchingTarget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isMatchingTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_speed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float speed = animator.speed;
			LuaDLL.lua_pushnumber(L, (double)speed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index speed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Vector3 targetPosition = animator.targetPosition;
			ToLua.Push(L, targetPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Quaternion targetRotation = animator.targetRotation;
			ToLua.Push(L, targetRotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cullingMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			AnimatorCullingMode cullingMode = animator.cullingMode;
			ToLua.Push(L, cullingMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullingMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playbackTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float playbackTime = animator.playbackTime;
			LuaDLL.lua_pushnumber(L, (double)playbackTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playbackTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_recorderStartTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float recorderStartTime = animator.recorderStartTime;
			LuaDLL.lua_pushnumber(L, (double)recorderStartTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index recorderStartTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_recorderStopTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float recorderStopTime = animator.recorderStopTime;
			LuaDLL.lua_pushnumber(L, (double)recorderStopTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index recorderStopTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_recorderMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			AnimatorRecorderMode recorderMode = animator.recorderMode;
			ToLua.Push(L, recorderMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index recorderMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_runtimeAnimatorController(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			RuntimeAnimatorController runtimeAnimatorController = animator.runtimeAnimatorController;
			ToLua.Push(L, runtimeAnimatorController);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index runtimeAnimatorController on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_avatar(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Avatar avatar = animator.avatar;
			ToLua.Push(L, avatar);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index avatar on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_layersAffectMassCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool layersAffectMassCenter = animator.layersAffectMassCenter;
			LuaDLL.lua_pushboolean(L, layersAffectMassCenter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layersAffectMassCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_leftFeetBottomHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float leftFeetBottomHeight = animator.leftFeetBottomHeight;
			LuaDLL.lua_pushnumber(L, (double)leftFeetBottomHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index leftFeetBottomHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rightFeetBottomHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float rightFeetBottomHeight = animator.rightFeetBottomHeight;
			LuaDLL.lua_pushnumber(L, (double)rightFeetBottomHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rightFeetBottomHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_logWarnings(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool logWarnings = animator.logWarnings;
			LuaDLL.lua_pushboolean(L, logWarnings);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index logWarnings on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fireEvents(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool fireEvents = animator.fireEvents;
			LuaDLL.lua_pushboolean(L, fireEvents);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fireEvents on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rootPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Vector3 rootPosition = ToLua.ToVector3(L, 2);
			animator.rootPosition = rootPosition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rootPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rootRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Quaternion rootRotation = ToLua.ToQuaternion(L, 2);
			animator.rootRotation = rootRotation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rootRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_applyRootMotion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool applyRootMotion = LuaDLL.luaL_checkboolean(L, 2);
			animator.applyRootMotion = applyRootMotion;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index applyRootMotion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_linearVelocityBlending(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool linearVelocityBlending = LuaDLL.luaL_checkboolean(L, 2);
			animator.linearVelocityBlending = linearVelocityBlending;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index linearVelocityBlending on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_updateMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			AnimatorUpdateMode updateMode = (AnimatorUpdateMode)((int)ToLua.CheckObject(L, 2, typeof(AnimatorUpdateMode)));
			animator.updateMode = updateMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bodyPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Vector3 bodyPosition = ToLua.ToVector3(L, 2);
			animator.bodyPosition = bodyPosition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bodyPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bodyRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Quaternion bodyRotation = ToLua.ToQuaternion(L, 2);
			animator.bodyRotation = bodyRotation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bodyRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stabilizeFeet(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool stabilizeFeet = LuaDLL.luaL_checkboolean(L, 2);
			animator.stabilizeFeet = stabilizeFeet;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stabilizeFeet on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_feetPivotActive(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float feetPivotActive = (float)LuaDLL.luaL_checknumber(L, 2);
			animator.feetPivotActive = feetPivotActive;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index feetPivotActive on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_speed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float speed = (float)LuaDLL.luaL_checknumber(L, 2);
			animator.speed = speed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index speed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cullingMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			AnimatorCullingMode cullingMode = (AnimatorCullingMode)((int)ToLua.CheckObject(L, 2, typeof(AnimatorCullingMode)));
			animator.cullingMode = cullingMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullingMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playbackTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float playbackTime = (float)LuaDLL.luaL_checknumber(L, 2);
			animator.playbackTime = playbackTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playbackTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_recorderStartTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float recorderStartTime = (float)LuaDLL.luaL_checknumber(L, 2);
			animator.recorderStartTime = recorderStartTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index recorderStartTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_recorderStopTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			float recorderStopTime = (float)LuaDLL.luaL_checknumber(L, 2);
			animator.recorderStopTime = recorderStopTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index recorderStopTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_runtimeAnimatorController(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			RuntimeAnimatorController runtimeAnimatorController = (RuntimeAnimatorController)ToLua.CheckUnityObject(L, 2, typeof(RuntimeAnimatorController));
			animator.runtimeAnimatorController = runtimeAnimatorController;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index runtimeAnimatorController on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_avatar(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			Avatar avatar = (Avatar)ToLua.CheckUnityObject(L, 2, typeof(Avatar));
			animator.avatar = avatar;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index avatar on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_layersAffectMassCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool layersAffectMassCenter = LuaDLL.luaL_checkboolean(L, 2);
			animator.layersAffectMassCenter = layersAffectMassCenter;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layersAffectMassCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_logWarnings(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool logWarnings = LuaDLL.luaL_checkboolean(L, 2);
			animator.logWarnings = logWarnings;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index logWarnings on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fireEvents(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animator animator = (Animator)obj;
			bool fireEvents = LuaDLL.luaL_checkboolean(L, 2);
			animator.fireEvents = fireEvents;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fireEvents on a nil value");
		}
		return result;
	}
}
