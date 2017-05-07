using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventListener : EventTrigger, IEventSystemHandler, IEndDragHandler
{
	public delegate void VoidDelegate<T>(T param);

	private object paraRef;

	private EventListener.VoidDelegate<object> onClickWithPara;

	public EventListener.VoidDelegate<GameObject> onDown;

	public EventListener.VoidDelegate<GameObject> onEnter;

	public EventListener.VoidDelegate<GameObject> onExit;

	public EventListener.VoidDelegate<GameObject> onUp;

	public EventListener.VoidDelegate<GameObject> onSelect;

	public EventListener.VoidDelegate<GameObject> onUpdateSelect;

	public EventListener.VoidDelegate<Vector2> onBeginDrag;

	public Action<float, float> onEndDrag;

	public Action<Vector2> onDrag;

	public Action<GameObject, Vector2> onClick;

	private Vector2 beginDragPos;

	private GameObject mGO;

	private Transform mTrans;

	public GameObject cachedGO
	{
		get
		{
			if (this.mGO == null)
			{
				this.mGO = base.gameObject;
			}
			return this.mGO;
		}
	}

	public Transform cachedTrans
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	public static EventListener Get(GameObject go)
	{
		EventListener eventListener = go.GetComponent<EventListener>();
		if (eventListener == null)
		{
			eventListener = go.AddComponent<EventListener>();
		}
		return eventListener;
	}

	public void SetClick(EventListener.VoidDelegate<object> callbackWithParam, object param)
	{
		this.onClick = null;
		this.onClickWithPara = callbackWithParam;
		this.paraRef = param;
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (!eventData.dragging)
		{
			if (this.onClick != null)
			{
				this.onClick(this.mGO, eventData.position);
			}
			else if (this.onClickWithPara != null)
			{
				this.onClickWithPara(this.paraRef);
			}
		}
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		if (this.onDown != null)
		{
			this.onDown(this.mGO);
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (this.onEnter != null)
		{
			this.onEnter(this.mGO);
		}
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		if (this.onExit != null)
		{
			this.onExit(this.mGO);
		}
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		if (this.onUp != null)
		{
			this.onUp(this.mGO);
		}
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
		this.beginDragPos = eventData.position;
		if (this.onBeginDrag != null)
		{
			this.onBeginDrag(eventData.delta);
		}
	}

	public new void OnEndDrag(PointerEventData eventData)
	{
		Vector2 vector = eventData.position - this.beginDragPos;
		if (this.onEndDrag != null)
		{
			this.onEndDrag(vector.x, vector.y);
		}
	}

	public override void OnSelect(BaseEventData eventData)
	{
		if (this.onSelect != null)
		{
			this.onSelect(this.mGO);
		}
	}

	public override void OnUpdateSelected(BaseEventData eventData)
	{
		if (this.onUpdateSelect != null)
		{
			this.onUpdateSelect(this.mGO);
		}
	}

	public override void OnDrag(PointerEventData eventData)
	{
		if (this.onDrag != null)
		{
			this.onDrag(eventData.delta);
		}
	}

	private void Awake()
	{
		this.mGO = base.gameObject;
		this.mTrans = base.transform;
	}
}
