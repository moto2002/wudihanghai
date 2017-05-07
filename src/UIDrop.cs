using System;
using UGUITweener;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrop : MonoBehaviour, IEventSystemHandler, IDropHandler
{
	public delegate void DropDelegate(object dragParam, object dropParam);

	public UIDrop.DropDelegate callback;

	public object param;

	private GameObject mGO;

	private RectTransform mTrans;

	public bool isFinish = true;

	private void Awake()
	{
		this.mGO = base.gameObject;
		this.mTrans = (base.transform as RectTransform);
	}

	public void OnDrop(PointerEventData data)
	{
		UIDrag component = data.pointerDrag.GetComponent<UIDrag>();
		if (!this.isFinish || !component.isFinish)
		{
			return;
		}
		this.isFinish = false;
		UIDrag myUIDrag = base.GetComponent<UIDrag>();
		if (myUIDrag)
		{
			myUIDrag.isFinish = false;
		}
		TweenPosition tweener = TweenPosition.Begin(this.mGO, 0.2f, component.m_originalPosition3D);
		tweener.SetOnFinished(delegate
		{
			UnityEngine.Object.DestroyImmediate(tweener, true);
			this.isFinish = true;
			if (myUIDrag)
			{
				myUIDrag.isFinish = true;
			}
		});
		component.m_originalPosition3D = this.mTrans.anchoredPosition3D;
		component.CUIDrop = this;
		if (this.callback != null)
		{
			this.callback(component.param, this.param);
		}
	}
}
