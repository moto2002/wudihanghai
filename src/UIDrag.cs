using LuaFramework;
using System;
using UGUITweener;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IEventSystemHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	public object param;

	public Vector3 m_originalPosition3D;

	private RectTransform m_DraggingPlane;

	private GameObject mGO;

	private RectTransform mTrans;

	public bool isFinish = true;

	public UIDrop CUIDrop;

	private void Awake()
	{
		this.mGO = base.gameObject;
		this.mTrans = (base.transform as RectTransform);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!this.isFinish)
		{
			return;
		}
		Canvas canvas = Util.FindInParents<Canvas>(base.gameObject, true);
		if (canvas == null)
		{
			return;
		}
		this.m_originalPosition3D = this.mTrans.anchoredPosition3D;
		this.mTrans.SetAsLastSibling();
		CanvasGroup canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = false;
		this.m_DraggingPlane = (canvas.transform as RectTransform);
		this.SetDraggedPosition(eventData);
	}

	public void OnDrag(PointerEventData data)
	{
		if (!this.isFinish)
		{
			return;
		}
		this.SetDraggedPosition(data);
	}

	private void SetDraggedPosition(PointerEventData data)
	{
		Vector3 position;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(this.m_DraggingPlane, data.position, data.pressEventCamera, out position))
		{
			this.mTrans.position = position;
			this.mTrans.rotation = this.m_DraggingPlane.rotation;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!this.isFinish)
		{
			return;
		}
		if (this.CUIDrop && !this.CUIDrop.isFinish && !this.isFinish)
		{
			return;
		}
		CanvasGroup component = base.gameObject.GetComponent<CanvasGroup>();
		if (component)
		{
			UnityEngine.Object.DestroyImmediate(component, true);
		}
		this.mTrans.SetAsLastSibling();
		this.isFinish = false;
		UIDrop myUIDrop = base.GetComponent<UIDrop>();
		if (myUIDrop)
		{
			myUIDrop.isFinish = false;
		}
		TweenPosition tweener = TweenPosition.Begin(this.mGO, 0.2f, this.m_originalPosition3D);
		tweener.SetOnFinished(delegate
		{
			UnityEngine.Object.DestroyImmediate(tweener, true);
			this.isFinish = true;
			if (myUIDrop)
			{
				myUIDrop.isFinish = true;
			}
			this.CUIDrop = null;
		});
	}
}
