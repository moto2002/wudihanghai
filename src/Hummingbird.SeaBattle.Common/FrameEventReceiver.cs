using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

namespace Hummingbird.SeaBattle.Common
{
	public class FrameEventReceiver : MonoBehaviour
	{
		private LuaBehaviour luaBehaviour;

		private LuaFunction lunFunc;

		private void Start()
		{
			this.luaBehaviour = base.gameObject.GetComponentInParent<LuaBehaviour>();
		}

		private void HandleAnimationMessage(string flag)
		{
			if (this.luaBehaviour != null)
			{
				this.luaBehaviour.ReveiveAnimationFrameEvent(flag);
			}
		}

		private void HandleCameraAnimationMessage()
		{
			Animator component = base.transform.GetComponent<Animator>();
			if (component != null)
			{
				component.enabled = false;
			}
			if (this.lunFunc != null)
			{
				this.lunFunc.Call();
				this.lunFunc.Dispose();
				this.lunFunc = null;
			}
		}

		public void AddLuaCallbackEvent(LuaFunction luafunc)
		{
			this.lunFunc = luafunc;
		}
	}
}
