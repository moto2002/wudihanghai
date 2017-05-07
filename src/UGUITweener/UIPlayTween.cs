using System;
using System.Collections.Generic;
using UGUITweener.AnimationOrTween;
using UnityEngine;

namespace UGUITweener
{
	[ExecuteInEditMode]
	public class UIPlayTween : MonoBehaviour
	{
		public GameObject tweenTarget;

		public int tweenGroup;

		public Direction playDirection = Direction.Forward;

		public bool resetOnPlay;

		public bool resetIfDisabled;

		public EnableCondition ifDisabledOnPlay;

		public DisableCondition disableWhenFinished;

		public bool includeChildren;

		public bool bPlayInEnable;

		public bool bResetInDisable;

		public List<EventDelegate> onFinished = new List<EventDelegate>();

		private UITweener[] mTweens;

		private int mActive;

		private void Start()
		{
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.gameObject;
			}
			GameObject gameObject = this.tweenTarget ?? base.gameObject;
			this.mTweens = ((!this.includeChildren) ? gameObject.GetComponents<UITweener>() : gameObject.GetComponentsInChildren<UITweener>());
		}

		private void OnEnable()
		{
			if (this.bPlayInEnable)
			{
				if (this.mTweens == null)
				{
					return;
				}
				for (int i = 0; i < this.mTweens.Length; i++)
				{
					this.mTweens[i].PlayForward();
				}
			}
		}

		private void OnDisable()
		{
			if (this.bResetInDisable)
			{
				if (this.mTweens == null)
				{
					return;
				}
				for (int i = 0; i < this.mTweens.Length; i++)
				{
					this.mTweens[i].ResetToBeginning();
				}
			}
		}

		[ContextMenu("Play Forward")]
		public void PlayForward()
		{
			this.Play(true);
		}

		[ContextMenu("Play Reverse")]
		public void PlayReverse()
		{
			this.Play(false);
		}

		public void Play(bool forward)
		{
			this.mActive = 0;
			GameObject gameObject = (!(this.tweenTarget == null)) ? this.tweenTarget : base.gameObject;
			this.mTweens = ((!this.includeChildren) ? gameObject.GetComponents<UITweener>() : gameObject.GetComponentsInChildren<UITweener>());
			if (!this.GetActive(gameObject))
			{
				if (this.ifDisabledOnPlay != EnableCondition.EnableThenPlay)
				{
					return;
				}
				this.SetActive(gameObject, true);
			}
			if (this.mTweens.Length == 0)
			{
				if (this.disableWhenFinished != DisableCondition.DoNotDisable)
				{
					this.SetActive(this.tweenTarget, false);
				}
			}
			else
			{
				bool flag = false;
				if (this.playDirection == Direction.Reverse)
				{
					forward = !forward;
				}
				int i = 0;
				int num = this.mTweens.Length;
				while (i < num)
				{
					UITweener uITweener = this.mTweens[i];
					if (uITweener.tweenGroup == this.tweenGroup)
					{
						if (!flag && !this.GetActive(gameObject))
						{
							flag = true;
							this.SetActive(gameObject, true);
						}
						this.mActive++;
						if (this.playDirection == Direction.Toggle)
						{
							EventDelegate.Add(uITweener.onFinished, new EventDelegate.Callback(this.OnFinished), true);
							uITweener.Toggle();
						}
						else
						{
							if (this.resetOnPlay || (this.resetIfDisabled && !uITweener.enabled))
							{
								uITweener.ResetToBeginning();
							}
							EventDelegate.Add(uITweener.onFinished, new EventDelegate.Callback(this.OnFinished), true);
							uITweener.Play(forward);
						}
					}
					i++;
				}
			}
		}

		private void OnFinished()
		{
			if (--this.mActive == 0)
			{
				if (this.disableWhenFinished != DisableCondition.DoNotDisable)
				{
					this.SetActive(this.tweenTarget, false);
				}
				EventDelegate.Execute(this.onFinished);
			}
		}

		public void SetOnFinished(EventDelegate.Callback del)
		{
			EventDelegate.Set(this.onFinished, del);
		}

		public void SetOnFinished(EventDelegate del)
		{
			EventDelegate.Set(this.onFinished, del);
		}

		public void AddOnFinished(EventDelegate.Callback del)
		{
			EventDelegate.Add(this.onFinished, del);
		}

		public void AddOnFinished(EventDelegate del)
		{
			EventDelegate.Add(this.onFinished, del);
		}

		public void RemoveOnFinished(EventDelegate del)
		{
			if (this.onFinished != null)
			{
				this.onFinished.Remove(del);
			}
		}

		public bool GetActive(GameObject go)
		{
			return go && go.activeSelf;
		}

		public void SetActive(GameObject go, bool active)
		{
			if (go && go.activeSelf != active)
			{
				go.SetActive(active);
			}
		}
	}
}
