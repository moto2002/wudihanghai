using System;
using UnityEngine;

namespace UGUITweener
{
	[AddComponentMenu("Tween/Tween Volume"), RequireComponent(typeof(AudioSource))]
	public class TweenVolume : UITweener
	{
		[Range(0f, 1f)]
		public float from = 1f;

		[Range(0f, 1f)]
		public float to = 1f;

		private AudioSource mSource;

		public AudioSource audioSource
		{
			get
			{
				if (this.mSource == null)
				{
					this.mSource = base.GetComponent<AudioSource>();
					if (this.mSource == null)
					{
						this.mSource = base.GetComponent<AudioSource>();
						if (this.mSource == null)
						{
							Debug.LogError("TweenVolume needs an AudioSource to work with", this);
							base.enabled = false;
						}
					}
				}
				return this.mSource;
			}
		}

		public float value
		{
			get
			{
				return (!(this.audioSource != null)) ? 0f : this.mSource.volume;
			}
			set
			{
				if (this.audioSource != null)
				{
					this.mSource.volume = value;
				}
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from * (1f - factor) + this.to * factor;
			this.mSource.enabled = (this.mSource.volume > 0.01f);
		}

		public static TweenVolume Begin(GameObject go, float duration, float targetVolume)
		{
			TweenVolume tweenVolume = UITweener.Begin<TweenVolume>(go, duration);
			tweenVolume.from = tweenVolume.value;
			tweenVolume.to = targetVolume;
			return tweenVolume;
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
