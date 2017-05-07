using System;
using UnityEngine;
using UnityEngine.UI;

namespace UGUITweener
{
	[AddComponentMenu("Tween/Tween UGUI Text")]
	public class TweenUGUIText : UITweener
	{
		public double from = 1.0;

		public double to = 1.0;

		private bool mCached;

		private Text text;

		private double curValue;

		public double value
		{
			get
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				return this.curValue;
			}
			set
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				this.curValue = value;
				if (this.text)
				{
					this.text.text = this.curValue.ToString("f0");
				}
			}
		}

		private void Cache()
		{
			this.mCached = true;
			this.text = base.GetComponent<Text>();
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = (double)Mathf.Lerp((float)this.from, (float)this.to, factor);
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
