using System;
using UnityEngine;
using UnityEngine.UI;

namespace UGUITweener
{
	[AddComponentMenu("Tween/Tween Sprite")]
	public class TweenSprite : UITweener
	{
		public Sprite[] sprites;

		private bool mCached;

		private Image mImage;

		private SpriteRenderer mSr;

		private int spriteCount;

		private int value
		{
			set
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				this.spriteCount = ((this.sprites == null) ? 0 : this.sprites.Length);
				base.enabled = (this.spriteCount > 1);
				value = ((!base.enabled) ? 0 : Mathf.Clamp(value, 0, this.spriteCount - 1));
				Sprite sprite = (this.spriteCount <= 0) ? null : this.sprites[value];
				if (this.mImage != null)
				{
					this.mImage.sprite = sprite;
				}
				else if (this.mSr != null)
				{
					this.mSr.sprite = sprite;
				}
			}
		}

		private void Cache()
		{
			this.mCached = true;
			this.mImage = base.GetComponent<Image>();
			this.mSr = base.GetComponent<SpriteRenderer>();
			if (this.mImage == null && this.mSr == null)
			{
				base.enabled = false;
			}
		}

		public void SetSprites(Sprite[] sprites)
		{
			this.sprites = sprites;
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = (int)Mathf.Lerp(0f, (float)this.spriteCount, factor);
		}

		public static TweenSprite Begin(GameObject go, float duration, Sprite[] sprites)
		{
			TweenSprite tweenSprite = UITweener.Begin<TweenSprite>(go, duration);
			tweenSprite.sprites = sprites;
			if (duration <= 0f)
			{
				tweenSprite.Sample(1f, true);
				tweenSprite.enabled = false;
			}
			return tweenSprite;
		}
	}
}
