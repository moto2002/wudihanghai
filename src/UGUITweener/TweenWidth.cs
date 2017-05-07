using System;
using UnityEngine;

namespace UGUITweener
{
	[AddComponentMenu("Tween/Tween Width"), RequireComponent(typeof(RectTransform))]
	public class TweenWidth : UITweener
	{
		public float from = 100f;

		public float to = 100f;

		private RectTransform mRect;

		public RectTransform cachedRect
		{
			get
			{
				if (this.mRect == null)
				{
					this.mRect = base.GetComponent<RectTransform>();
				}
				return this.mRect;
			}
		}

		public float value
		{
			get
			{
				return this.cachedRect.rect.width;
			}
			set
			{
				this.cachedRect.sizeDelta = new Vector2(value, this.cachedRect.rect.height);
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = (float)Mathf.RoundToInt(this.from * (1f - factor) + this.to * factor);
		}

		public static TweenWidth Begin(RectTransform widget, float duration, int width)
		{
			TweenWidth tweenWidth = UITweener.Begin<TweenWidth>(widget.gameObject, duration);
			tweenWidth.from = widget.rect.width;
			tweenWidth.to = (float)width;
			if (duration <= 0f)
			{
				tweenWidth.Sample(1f, true);
				tweenWidth.enabled = false;
			}
			return tweenWidth;
		}

		[ContextMenu("Set 'From' to current value")]
		public override void SetStartToCurrentValue()
		{
			this.from = this.value;
		}

		[ContextMenu("Set 'To' to current value")]
		public override void SetEndToCurrentValue()
		{
			this.to = this.value;
		}

		[ContextMenu("Assume value of 'From'")]
		private void SetCurrentValueToStart()
		{
			this.value = this.from;
		}

		[ContextMenu("Assume value of 'To'")]
		private void SetCurrentValueToEnd()
		{
			this.value = this.to;
		}
	}
}
