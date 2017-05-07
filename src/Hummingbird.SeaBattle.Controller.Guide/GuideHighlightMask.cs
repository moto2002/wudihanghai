using Hummingbird.SeaBattle.Common;
using Hummingbird.SeaBattle.Controller.CameraControll;
using LuaFramework;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hummingbird.SeaBattle.Controller.Guide
{
	[RequireComponent(typeof(HandleInputInViewPortRect))]
	public class GuideHighlightMask : Graphic, IPointerClickHandler, IEventSystemHandler
	{
		private struct SScrollRectState
		{
			public MonoBehaviour Ctrl;

			public bool vertical;

			public bool horizontal;
		}

		[NoToLua]
		public Transform arrow;

		[NoToLua]
		public Vector2 center = Vector2.zero;

		[NoToLua]
		public Vector2 size = new Vector2(100f, 100f);

		[NoToLua]
		public Camera uiCamera;

		[NoToLua]
		public Canvas mainCV;

		[NoToLua]
		public Vector2 centerOffset = Vector2.zero;

		[NoToLua]
		public Vector2 sizeOffset = Vector2.zero;

		[NoToLua]
		public Transform SelfTr;

		[NoToLua]
		public Transform SelfParent;

		private List<GuideHighlightMask.SScrollRectState> PrevScrollRectCtrls = new List<GuideHighlightMask.SScrollRectState>();

		[NoToLua]
		public HandleInputInViewPortRect MainCamera3DInputCtrl;

		private LuaFunction onPointerDownInOrOutSide;

		private bool isSelfUIOnTouch;

		private new void Start()
		{
			this.SelfTr = base.transform;
			this.SelfParent = this.SelfTr.parent;
			if (!this.uiCamera)
			{
				this.uiCamera = Util.FindInParents<Camera>(base.gameObject, true);
			}
			HandleInputInViewPortRect component = base.GetComponent<HandleInputInViewPortRect>();
			if (component && this.uiCamera)
			{
				component.Camera = this.uiCamera;
				component.IsIgnoreGUI = true;
				component.OnTouchScreenAction = new Action<Vector3>(this.TouchScreen);
			}
			if (!this.mainCV)
			{
				this.mainCV = Util.FindInParents<Canvas>(base.gameObject, false);
			}
			this.findPrevScrollRect();
		}

		private void Update()
		{
			this.overheadSiblingAndFindPrevScrollRect();
		}

		protected new void OnDestroy()
		{
			this.openArrowBoxCollider();
			this.openEnablePrevScrollRect();
			this.openEnablePrevCamera3InputCtrl();
			if (this.onPointerDownInOrOutSide != null)
			{
				this.onPointerDownInOrOutSide.Dispose();
				this.onPointerDownInOrOutSide = null;
			}
		}

		public void SetArrow(Transform element, Vector2 centerOffset, Vector2 sizeOffset)
		{
			if (element)
			{
				this.arrow = element;
			}
			this.centerOffset = centerOffset;
			this.sizeOffset = sizeOffset;
			if (!this.uiCamera || !this.mainCV)
			{
				base.StartCoroutine(this.doUpdate());
			}
			else
			{
				this.doUpdateAction();
			}
		}

		public void InitPointerLuaFunction(LuaFunction luaOnPointer)
		{
			this.onPointerDownInOrOutSide = luaOnPointer;
		}

		private void openEnablePrevScrollRect()
		{
			for (int i = 0; i < this.PrevScrollRectCtrls.Count; i++)
			{
				if (this.PrevScrollRectCtrls[i].Ctrl != null && this.PrevScrollRectCtrls[i].Ctrl as LoopScrollRect)
				{
					(this.PrevScrollRectCtrls[i].Ctrl as LoopScrollRect).vertical = this.PrevScrollRectCtrls[i].vertical;
					(this.PrevScrollRectCtrls[i].Ctrl as LoopScrollRect).horizontal = this.PrevScrollRectCtrls[i].horizontal;
				}
				if (this.PrevScrollRectCtrls[i].Ctrl as ScrollRect)
				{
					(this.PrevScrollRectCtrls[i].Ctrl as ScrollRect).vertical = this.PrevScrollRectCtrls[i].vertical;
					(this.PrevScrollRectCtrls[i].Ctrl as ScrollRect).horizontal = this.PrevScrollRectCtrls[i].horizontal;
				}
			}
		}

		private void openEnablePrevCamera3InputCtrl()
		{
			if (this.MainCamera3DInputCtrl != null)
			{
				this.MainCamera3DInputCtrl.Handle(true);
			}
		}

		private void openArrowBoxCollider()
		{
			if (this.arrow && this.arrow)
			{
				BoxCollider component = this.arrow.GetComponent<BoxCollider>();
				if (component != null)
				{
					component.size -= Vector3.one * 5f;
				}
			}
		}

		private void overheadSiblingAndFindPrevScrollRect()
		{
			if (!this.SelfParent || !this.SelfTr)
			{
				return;
			}
			int childCount = this.SelfParent.childCount;
			if (childCount > this.SelfTr.GetSiblingIndex() + 1)
			{
				this.findPrevScrollRect();
			}
		}

		private void findPrevScrollRect()
		{
			if (!this.SelfParent || !this.SelfTr)
			{
				return;
			}
			this.SelfTr.SetAsLastSibling();
			this.openEnablePrevScrollRect();
			this.PrevScrollRectCtrls.Clear();
			if (this.SelfParent.childCount > 1)
			{
				Transform child = this.SelfParent.GetChild(this.SelfTr.GetSiblingIndex() - 1);
				Transform[] componentsInChildren = child.GetComponentsInChildren<Transform>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (componentsInChildren[i].GetComponent<LoopScrollRect>() != null)
					{
						GuideHighlightMask.SScrollRectState item = default(GuideHighlightMask.SScrollRectState);
						item.Ctrl = componentsInChildren[i].GetComponent<LoopScrollRect>();
						item.vertical = componentsInChildren[i].GetComponent<LoopScrollRect>().vertical;
						item.horizontal = componentsInChildren[i].GetComponent<LoopScrollRect>().horizontal;
						componentsInChildren[i].GetComponent<LoopScrollRect>().vertical = false;
						componentsInChildren[i].GetComponent<LoopScrollRect>().horizontal = false;
						this.PrevScrollRectCtrls.Add(item);
					}
					else if (componentsInChildren[i].GetComponent<ScrollRect>() != null)
					{
						GuideHighlightMask.SScrollRectState item = default(GuideHighlightMask.SScrollRectState);
						item.Ctrl = componentsInChildren[i].GetComponent<ScrollRect>();
						item.vertical = componentsInChildren[i].GetComponent<ScrollRect>().vertical;
						item.horizontal = componentsInChildren[i].GetComponent<ScrollRect>().horizontal;
						componentsInChildren[i].GetComponent<ScrollRect>().vertical = false;
						componentsInChildren[i].GetComponent<ScrollRect>().horizontal = false;
						this.PrevScrollRectCtrls.Add(item);
					}
				}
			}
		}

		private Vector2 getScreenSize()
		{
			if (!this.mainCV)
			{
				return Vector2.zero;
			}
			float num = ((RectTransform)this.mainCV.transform).sizeDelta.x;
			float num2 = ((RectTransform)this.mainCV.transform).sizeDelta.y;
			if (num == 0f)
			{
				num = (float)Screen.width;
			}
			if (num2 == 0f)
			{
				num2 = (float)Screen.height;
			}
			return Vector2.right * num + Vector2.up * num2;
		}

		private float getMainCanvasWithScreenPer()
		{
			if (!this.mainCV)
			{
				return 1f;
			}
			float num = ((RectTransform)this.mainCV.transform).sizeDelta.x;
			if (num == 0f)
			{
				num = (float)Screen.width;
			}
			return num / (float)Screen.width;
		}

		public Vector2 GetScreenPosition()
		{
			if (!this.arrow)
			{
				return Vector2.zero;
			}
			if (this.arrow.GetComponent<ScrollViewOrientation>() != null)
			{
				this.arrow.GetComponent<ScrollViewOrientation>().CenterSelf();
			}
			Camera camera = null;
			if (this.arrow as RectTransform)
			{
				camera = this.uiCamera;
			}
			else
			{
				GameObject[] array = GameObject.FindGameObjectsWithTag("MainCamera");
				if (array == null || array.Length == 0)
				{
					return Vector2.zero;
				}
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].layer == this.arrow.gameObject.layer)
					{
						camera = array[i].GetComponent<Camera>();
						this.MainCamera3DInputCtrl = camera.GetComponent<HandleInputInViewPortRect>();
						if (this.MainCamera3DInputCtrl != null)
						{
							this.MainCamera3DInputCtrl.Handle(false);
						}
						break;
					}
				}
			}
			if (!camera)
			{
				UnityEngine.Debug.LogError("Can Not Find Camera");
				return Vector2.zero;
			}
			Vector3 vector = camera.WorldToViewportPoint(this.arrow.position);
			float num = this.getScreenSize().x * vector.x;
			float num2 = this.getScreenSize().y * vector.y;
			return Vector2.right * (num - this.getScreenSize().x * 0.5f) + Vector2.up * (num2 - this.getScreenSize().y * 0.5f) + this.centerOffset;
		}

		private Vector2 getArrowSize()
		{
			Vector2 vector = Vector2.zero;
			if (!this.arrow)
			{
				return vector;
			}
			if (this.arrow as RectTransform)
			{
				vector = (this.arrow as RectTransform).rect.size;
			}
			else
			{
				vector = Vector2.one * 100f;
			}
			if (this.sizeOffset == Vector2.one * -9999f)
			{
				return Vector3.zero;
			}
			return vector + this.sizeOffset;
		}

		[DebuggerHidden]
		private IEnumerator doUpdate()
		{
			GuideHighlightMask.<doUpdate>c__Iterator5 <doUpdate>c__Iterator = new GuideHighlightMask.<doUpdate>c__Iterator5();
			<doUpdate>c__Iterator.<>f__this = this;
			return <doUpdate>c__Iterator;
		}

		private void doUpdateAction()
		{
			if (!this.arrow)
			{
				this.closeArrow();
			}
			else
			{
				Vector2 screenPosition = this.GetScreenPosition();
				if (!(this.arrow as RectTransform))
				{
					BoxCollider component = this.arrow.GetComponent<BoxCollider>();
					if (component != null)
					{
						component.size += Vector3.one * 5f;
					}
				}
				if (this.center != screenPosition || this.size != this.getArrowSize())
				{
					this.center = screenPosition;
					this.size = this.getArrowSize();
					this.SetAllDirty();
				}
			}
		}

		private void closeArrow()
		{
			this.arrow = null;
			this.center = (this.size = Vector2.zero);
			this.SetAllDirty();
		}

		[NoToLua]
		public void OnPointerClick(PointerEventData eventData)
		{
			this.isSelfUIOnTouch = true;
		}

		[NoToLua]
		public void TouchScreen(Vector3 screenPos)
		{
			if (!this.isSelfUIOnTouch)
			{
				return;
			}
			this.isSelfUIOnTouch = false;
			Rect rect = new Rect(this.center.x - this.size.x * 0.5f, this.center.y - this.size.y * 0.5f, this.size.x, this.size.y);
			Vector2 vector = Vector2.right * screenPos.x + Vector2.up * screenPos.y;
			vector = (vector - (Vector2.right * (float)Screen.width * 0.5f + Vector2.up * (float)Screen.height * 0.5f)) * this.getMainCanvasWithScreenPer();
			if (rect.Contains(vector))
			{
				if (this.onPointerDownInOrOutSide != null)
				{
					this.onPointerDownInOrOutSide.Call(new object[]
					{
						true
					});
				}
				if (!this.arrow)
				{
					return;
				}
				if (this.arrow as RectTransform)
				{
					base.gameObject.GetComponent<GraphicRaycaster>().enabled = false;
					PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
					pointerEventData.position = Vector2.right * screenPos.x + Vector2.up * screenPos.y;
					ExecuteEvents.Execute<IPointerClickHandler>(this.arrow.gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);
					base.gameObject.GetComponent<GraphicRaycaster>().enabled = true;
				}
				else
				{
					if (this.MainCamera3DInputCtrl != null)
					{
						this.MainCamera3DInputCtrl.HandleTouchAction();
					}
					this.openArrowBoxCollider();
				}
				this.closeArrow();
			}
			else if (this.onPointerDownInOrOutSide != null)
			{
				this.onPointerDownInOrOutSide.Call(new object[]
				{
					false
				});
			}
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			if (this.center == Vector2.zero && this.size == Vector2.zero)
			{
				vh.Clear();
				base.OnPopulateMesh(vh);
				return;
			}
			Vector4 vector = new Vector4(-base.rectTransform.pivot.x * base.rectTransform.rect.width, -base.rectTransform.pivot.y * base.rectTransform.rect.height, (1f - base.rectTransform.pivot.x) * base.rectTransform.rect.width, (1f - base.rectTransform.pivot.y) * base.rectTransform.rect.height);
			Vector4 vector2 = new Vector4(this.center.x - this.size.x / 2f, this.center.y - this.size.y / 2f, this.center.x + this.size.x * 0.5f, this.center.y + this.size.y * 0.5f);
			vh.Clear();
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.position = new Vector2(vector.x, vector.y);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector.x, vector.w);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.x, vector.w);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.x, vector.y);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.z, vector.y);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.z, vector.w);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector.z, vector.w);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector.z, vector.y);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.x, vector2.w);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.z, vector2.w);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.x, vector2.y);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.z, vector2.y);
			simpleVert.color = base.color;
			vh.AddVert(simpleVert);
			vh.AddTriangle(0, 3, 1);
			vh.AddTriangle(3, 2, 1);
			vh.AddTriangle(8, 9, 2);
			vh.AddTriangle(9, 5, 2);
			vh.AddTriangle(4, 7, 5);
			vh.AddTriangle(7, 6, 5);
			vh.AddTriangle(3, 4, 10);
			vh.AddTriangle(4, 11, 10);
		}
	}
}
