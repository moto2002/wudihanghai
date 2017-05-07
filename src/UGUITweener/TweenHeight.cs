using System;
using UnityEngine;

namespace UGUITweener
{
	[AddComponentMenu("Tween/Tween Height"), RequireComponent(typeof(RectTransform))]
	public class TweenHeight : UITweener
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
				return this.cachedRect.rect.height;
			}
			set
			{
				this.cachedRect.sizeDelta = new Vector2(this.cachedRect.rect.width, value);
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = (float)Mathf.RoundToInt(this.from * (1f - factor) + this.to * factor);
		}

		public static TweenHeight Begin(RectTransform widget, float duration, int height)
		{
			TweenHeight tweenHeight = UITweener.Begin<TweenHeight>(widget.gameObject, duration);
			tweenHeight.from = widget.rect.height;
			tweenHeight.to = (float)height;
			if (duration <= 0f)
			{
				tweenHeight.Sample(1f, true);
				tweenHeight.enabled = false;
			}
			return tweenHeight;
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
