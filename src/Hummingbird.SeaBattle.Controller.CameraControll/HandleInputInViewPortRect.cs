using LuaFramework;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hummingbird.SeaBattle.Controller.CameraControll
{
	public class HandleInputInViewPortRect : MonoBehaviour
	{
		public float MatchHeight;

		public float DisplayWidth;

		public Camera Camera;

		public HandleCameraAction CameraActionCtrl;

		[NoToLua]
		public Action<Vector3> OnTouchScreenAction;

		private bool handle = true;

		[NoToLua]
		public bool IsIgnoreGUI;

		private int fingerTouch = 1;

		private Vector2 oneFingerTouchPos = Vector2.zero;

		private Vector2 twoFingerTouchPos = Vector2.zero;

		public void CutViewPortRect(float displayWidth, float rectYRatio, float rectHeightRatio)
		{
			this.cutWithMatchHeight(displayWidth, rectYRatio, rectHeightRatio);
		}

		public void Handle(bool isHandle)
		{
			this.handle = isHandle;
		}

		[NoToLua]
		public void HandleTouchAction()
		{
			if (this.CameraActionCtrl != null)
			{
				this.CameraActionCtrl.TouchScreen(this.getGetTouchPos(Input.GetTouch(0).position));
			}
		}

		private void Awake()
		{
			this.cutWithMatchHeight(this.DisplayWidth, 0f, 1f);
		}

		private void Update()
		{
			if (this.fingerTouch == 1)
			{
				base.StartCoroutine(this.holdHandle());
				return;
			}
			if (!this.IsIgnoreGUI && this.touchUgui())
			{
				return;
			}
			if (!Util.GetCanTouch())
			{
				return;
			}
			this.phoneHandleInput();
		}

		[DebuggerHidden]
		private IEnumerator holdHandle()
		{
			HandleInputInViewPortRect.<holdHandle>c__Iterator4 <holdHandle>c__Iterator = new HandleInputInViewPortRect.<holdHandle>c__Iterator4();
			<holdHandle>c__Iterator.<>f__this = this;
			return <holdHandle>c__Iterator;
		}

		private void phoneHandleInput()
		{
			if (Input.touchCount > 0)
			{
				TouchPhase phase = Input.GetTouch(0).phase;
				if (Input.touchCount > 1 && this.checkScreenPointInViewPortRect(this.getGetTouchPos(Input.GetTouch(0).position)) && this.checkScreenPointInViewPortRect(this.getGetTouchPos(Input.GetTouch(1).position)) && this.handle)
				{
					if (phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
					{
						this.fingerTouch = 4;
						if (this.isEnlarge(this.oneFingerTouchPos, this.twoFingerTouchPos, Input.GetTouch(0).position, Input.GetTouch(1).position))
						{
							if (this.CameraActionCtrl != null)
							{
								this.CameraActionCtrl.Pinch(true);
							}
						}
						else if (this.CameraActionCtrl != null)
						{
							this.CameraActionCtrl.Pinch(false);
						}
						this.oneFingerTouchPos = Input.GetTouch(0).position;
						this.twoFingerTouchPos = Input.GetTouch(1).position;
					}
				}
				else if (this.fingerTouch != 4 && Input.touchCount == 1)
				{
					if (this.fingerTouch != 3 && (phase == TouchPhase.Stationary || phase == TouchPhase.Began) && this.checkScreenPointInViewPortRect(this.getGetTouchPos(Input.GetTouch(0).position)))
					{
						this.fingerTouch = 2;
						this.oneFingerTouchPos = Input.GetTouch(0).position;
					}
					else if (phase == TouchPhase.Moved && this.checkScreenPointInViewPortRect(this.getGetTouchPos(Input.GetTouch(0).position)) && this.handle)
					{
						if (Vector2.Distance(this.oneFingerTouchPos, Input.GetTouch(0).position) > 50f)
						{
							this.fingerTouch = 3;
							if (this.CameraActionCtrl != null)
							{
								this.CameraActionCtrl.Move(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
							}
							this.oneFingerTouchPos = Input.GetTouch(0).position;
						}
					}
					else if (phase == TouchPhase.Ended || phase == TouchPhase.Canceled)
					{
						if (this.fingerTouch == 2)
						{
							if (this.CameraActionCtrl != null)
							{
								this.CameraActionCtrl.TouchScreen(this.getGetTouchPos(Input.GetTouch(0).position));
							}
							if (this.OnTouchScreenAction != null)
							{
								this.OnTouchScreenAction(this.getGetTouchPos(Input.GetTouch(0).position));
							}
						}
						else if (this.fingerTouch == 3)
						{
						}
						this.fingerTouch = 1;
					}
				}
				else if (this.fingerTouch == 4)
				{
					this.fingerTouch = 1;
					this.oneFingerTouchPos = Vector2.zero;
					this.twoFingerTouchPos = Vector2.zero;
				}
			}
		}

		private Vector3 getGetTouchPos(Vector2 tPos)
		{
			return Vector3.right * tPos.x + Vector3.up * tPos.y;
		}

		private bool isEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
		{
			float num = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
			float num2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
			return num < num2;
		}

		private void cutWithMatchHeight(float displayWidth, float rectYRatio, float rectHeightRatio)
		{
			if (this.Camera && this.MatchHeight > 0f && displayWidth > 0f)
			{
				float num = (float)Screen.width * 1f / ((float)Screen.height * 1f);
				float num2 = this.MatchHeight * num;
				float num3 = displayWidth / num2;
				float num4 = (1f - num3) / 2f;
				num4 = ((num4 >= 0f && num4 <= 1f) ? num4 : 0f);
				this.Camera.rect = new Rect(num4, rectYRatio, 1f - num4 * 2f, rectHeightRatio);
			}
		}

		private bool checkScreenPointInViewPortRect(Vector3 screenPoint)
		{
			if (this.Camera)
			{
				float num = this.Camera.rect.x * (float)Screen.width * 1f;
				float num2 = (this.Camera.rect.x + this.Camera.rect.width) * (float)Screen.width * 1f;
				float num3 = this.Camera.rect.y * (float)Screen.height * 1f;
				float num4 = (this.Camera.rect.y + this.Camera.rect.height) * (float)Screen.height * 1f;
				return screenPoint.x >= num && screenPoint.x <= num2 && screenPoint.y >= num3 && screenPoint.y <= num4;
			}
			return false;
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
	}
}
