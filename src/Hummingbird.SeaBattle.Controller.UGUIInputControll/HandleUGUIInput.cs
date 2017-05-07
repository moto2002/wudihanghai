using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hummingbird.SeaBattle.Controller.UGUIInputControll
{
	public class HandleUGUIInput : MonoBehaviour
	{
		private int fingerTouch = 1;

		private LuaFunction touchScreenLuafunc;

		public void AddTouchScreen(LuaFunction luafunc)
		{
			if (luafunc == null)
			{
				return;
			}
			this.touchScreenLuafunc = luafunc;
		}

		private void Update()
		{
			this.phoneHandleInput();
		}

		private void phoneHandleInput()
		{
			if (Input.touchCount > 0)
			{
				TouchPhase phase = Input.GetTouch(0).phase;
				if (Input.touchCount == 1)
				{
					if (phase == TouchPhase.Stationary || phase == TouchPhase.Began)
					{
						this.fingerTouch = 2;
					}
					else if (phase == TouchPhase.Ended || phase == TouchPhase.Canceled)
					{
						if (this.fingerTouch == 2)
						{
							this.onTouchScreenAction();
						}
						this.fingerTouch = 1;
					}
				}
			}
		}

		private void onTouchScreenAction()
		{
			if (this.touchUgui())
			{
				if (this.touchScreenLuafunc != null)
				{
					this.touchScreenLuafunc.Call(new object[]
					{
						EventSystem.current.currentSelectedGameObject
					});
				}
			}
			else if (this.touchScreenLuafunc != null)
			{
				this.touchScreenLuafunc.Call(null);
			}
		}

		private bool touchUgui()
		{
			return EventSystem.current && (Input.touchCount == 0 || this.IsPointerOverUIObject());
		}

		private bool IsPointerOverUIObject()
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			return list.Count > 0;
		}

		private void OnDestroy()
		{
			if (this.touchScreenLuafunc != null)
			{
				this.touchScreenLuafunc.Dispose();
				this.touchScreenLuafunc = null;
			}
		}
	}
}
