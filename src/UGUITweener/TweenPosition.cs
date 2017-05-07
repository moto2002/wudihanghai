using System;
using UnityEngine;

namespace UGUITweener
{
	[AddComponentMenu("Tween/Tween Position")]
	public class TweenPosition : UITweener
	{
		public Vector3 from;

		public Vector3 to;

		public MoveDirection moveDirection = MoveDirection.all;

		public bool isAnchored;

		private Transform mTrans;

		private RectTransform mRect;

		public Transform cachedTransform
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

		public Vector3 value
		{
			get
			{
				return (!this.isAnchored || !(this.mRect != null)) ? this.cachedTransform.localPosition : this.mRect.anchoredPosition3D;
			}
			set
			{
				if (this.isAnchored && this.mRect != null)
				{
					Vector3 anchoredPosition3D = this.mRect.anchoredPosition3D;
					switch (this.moveDirection)
					{
					case MoveDirection.x:
						anchoredPosition3D.x = value.x;
						break;
					case MoveDirection.y:
						anchoredPosition3D.y = value.y;
						break;
					case MoveDirection.z:
						anchoredPosition3D.z = value.z;
						break;
					default:
						anchoredPosition3D = value;
						break;
					}
					this.mRect.anchoredPosition3D = anchoredPosition3D;
				}
				else
				{
					Vector3 localPosition = this.cachedTransform.localPosition;
					switch (this.moveDirection)
					{
					case MoveDirection.x:
						localPosition.x = value.x;
						break;
					case MoveDirection.y:
						localPosition.y = value.y;
						break;
					case MoveDirection.z:
						localPosition.z = value.z;
						break;
					default:
						localPosition = value;
						break;
					}
					this.cachedTransform.localPosition = localPosition;
				}
			}
		}

		private void Awake()
		{
			this.mRect = (this.cachedTransform as RectTransform);
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from * (1f - factor) + this.to * factor;
		}

		public static TweenPosition Begin(GameObject go, float duration, Vector3 pos)
		{
			TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration);
			tweenPosition.isAnchored = true;
			tweenPosition.from = tweenPosition.value;
			tweenPosition.to = pos;
			if (duration <= 0f)
			{
				tweenPosition.Sample(1f, true);
				tweenPosition.enabled = false;
			}
			return tweenPosition;
		}

		public static TweenPosition Begin(GameObject go, float duration, Vector3 pos, bool worldSpace)
		{
			TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration);
			tweenPosition.isAnchored = worldSpace;
			tweenPosition.from = tweenPosition.value;
			tweenPosition.to = pos;
			if (duration <= 0f)
			{
				tweenPosition.Sample(1f, true);
				tweenPosition.enabled = false;
			}
			return tweenPosition;
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
