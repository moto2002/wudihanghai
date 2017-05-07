using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UILongPressButton : Selectable, IEventSystemHandler, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{
	[SerializeField]
	private Action<object> ClickCallback;

	private Action<object> LongPressCallback;

	private float longPressDelay = 1f;

	private bool isLongpress;

	private float touchBegin;

	private bool isTouchDown;

	private void Update()
	{
		if (this.isTouchDown && base.IsPressed() && base.interactable)
		{
			if (this.isLongpress)
			{
				if (this.LongPressCallback != null)
				{
					this.LongPressCallback(null);
					this.isTouchDown = false;
					this.isLongpress = true;
				}
			}
			else
			{
				this.isLongpress = (Time.time - this.touchBegin > this.longPressDelay);
			}
		}
	}

	public new void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		this.touchBegin = Time.time;
		this.isLongpress = false;
		this.isTouchDown = true;
	}

	public new void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		this.isTouchDown = false;
	}

	public new void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		if (!this.isLongpress && this.ClickCallback != null)
		{
			this.ClickCallback(null);
		}
		this.isLongpress = false;
		this.isTouchDown = false;
	}

	public void SetLongPress(float _longPressDelay, Action<object> _LongPressCallback, Action<object> _ClickCallback)
	{
		this.longPressDelay = _longPressDelay;
		this.LongPressCallback = _LongPressCallback;
		this.ClickCallback = _ClickCallback;
	}
}
