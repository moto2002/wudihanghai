using System;
using UnityEngine;
using UnityEngine.UI;

namespace UGUITweener
{
	[AddComponentMenu("Tween/Tween Color")]
	public class TweenColor : UITweener
	{
		public Color from = Color.white;

		public Color to = Color.white;

		private bool mCached;

		private Graphic mGraphic;

		private Material mMat;

		private Light mLight;

		private SpriteRenderer mSr;

		public Color value
		{
			get
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.mGraphic != null)
				{
					return this.mGraphic.color;
				}
				if (this.mMat != null)
				{
					return this.mMat.color;
				}
				if (this.mSr != null)
				{
					return this.mSr.color;
				}
				if (this.mLight != null)
				{
					return this.mLight.color;
				}
				return Color.black;
			}
			set
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.mGraphic != null)
				{
					this.mGraphic.color = value;
				}
				else if (this.mMat != null)
				{
					this.mMat.color = value;
				}
				else if (this.mSr != null)
				{
					this.mSr.color = value;
				}
				else if (this.mLight != null)
				{
					this.mLight.color = value;
					this.mLight.enabled = (value.r + value.g + value.b > 0.01f);
				}
			}
		}

		private void Cache()
		{
			this.mCached = true;
			this.mGraphic = base.GetComponent<Graphic>();
			if (this.mGraphic != null)
			{
				return;
			}
			this.mSr = base.GetComponent<SpriteRenderer>();
			if (this.mSr != null)
			{
				return;
			}
			Renderer component = base.GetComponent<Renderer>();
			if (component != null)
			{
				this.mMat = component.material;
				return;
			}
			this.mLight = base.GetComponent<Light>();
			if (this.mLight == null)
			{
				this.mGraphic = base.GetComponentInChildren<Graphic>();
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = Color.Lerp(this.from, this.to, factor);
		}

		public static TweenColor Begin(GameObject go, float duration, Color color)
		{
			TweenColor tweenColor = UITweener.Begin<TweenColor>(go, duration);
			tweenColor.from = tweenColor.value;
			tweenColor.to = color;
			if (duration <= 0f)
			{
				tweenColor.Sample(1f, true);
				tweenColor.enabled = false;
			}
			return tweenColor;
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
