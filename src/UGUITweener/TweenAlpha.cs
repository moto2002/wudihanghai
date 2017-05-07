using System;
using UnityEngine;
using UnityEngine.UI;

namespace UGUITweener
{
	[AddComponentMenu("Tween/Tween Alpha")]
	public class TweenAlpha : UITweener
	{
		[Range(0f, 1f)]
		public float from = 1f;

		[Range(0f, 1f)]
		public float to = 1f;

		public bool includeChildren;

		private bool mCached;

		private Graphic mGraphic;

		private Material mMat;

		private SpriteRenderer mSr;

		private CanvasGroup canvasGroup;

		public float value
		{
			get
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.includeChildren)
				{
					if (this.canvasGroup == null)
					{
						this.canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
					}
					return this.canvasGroup.alpha;
				}
				if (this.mGraphic != null)
				{
					return this.mGraphic.color.a;
				}
				if (this.mSr != null)
				{
					return this.mSr.color.a;
				}
				return (!(this.mMat != null)) ? 1f : this.mMat.color.a;
			}
			set
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.includeChildren)
				{
					if (this.canvasGroup == null)
					{
						this.canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
					}
					this.canvasGroup.alpha = value;
				}
				else if (this.mGraphic != null)
				{
					Color color = this.mGraphic.color;
					color.a = value;
					this.mGraphic.color = color;
				}
				else if (this.mSr != null)
				{
					Color color2 = this.mSr.color;
					color2.a = value;
					this.mSr.color = color2;
				}
				else if (this.mMat != null)
				{
					Color color3 = this.mMat.color;
					color3.a = value;
					this.mMat.color = color3;
				}
			}
		}

		private void Cache()
		{
			this.mCached = true;
			this.mGraphic = base.GetComponent<Graphic>();
			this.mSr = base.GetComponent<SpriteRenderer>();
			this.canvasGroup = base.GetComponent<CanvasGroup>();
			if (this.mGraphic == null && this.mSr == null && !this.includeChildren)
			{
				Renderer component = base.GetComponent<Renderer>();
				if (component != null)
				{
					this.mMat = component.material;
				}
				if (this.mMat == null)
				{
					this.mGraphic = base.GetComponentInChildren<Graphic>();
				}
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = Mathf.Lerp(this.from, this.to, factor);
		}

		public static TweenAlpha Begin(GameObject go, float duration, float alpha)
		{
			TweenAlpha tweenAlpha = UITweener.Begin<TweenAlpha>(go, duration);
			tweenAlpha.from = tweenAlpha.value;
			tweenAlpha.to = alpha;
			if (duration <= 0f)
			{
				tweenAlpha.Sample(1f, true);
				tweenAlpha.enabled = false;
			}
			return tweenAlpha;
		}

		public override void SetStartToCurrentValue()
		{
			this.from = this.value;
		}

		public override void SetEndToCurrentValue()
		{
			this.to = this.value;
		}
	}
}
