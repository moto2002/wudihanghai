using LuaInterface;
using System;
using System.Collections;
using UGUITweener;
using UnityEngine;

namespace Hummingbird.SeaBattle.Utility
{
	public class TweenUtil
	{
		public static void Move(GameObject gameObject, Vector3 to, float time, int type, float delay = 0f, LuaFunction finishToDo = null, object para = null)
		{
			if (finishToDo != null)
			{
				LeanTween.move(gameObject, to, time).setDelay(delay).setOnComplete(delegate(object completePara)
				{
					if (finishToDo != null)
					{
						finishToDo.Call(new object[]
						{
							completePara
						});
					}
					finishToDo.Dispose();
					finishToDo = null;
				}).setOnCompleteParam(para).tweenType = (LeanTweenType)type;
			}
			else
			{
				LeanTween.move(gameObject, to, time).setDelay(delay).tweenType = (LeanTweenType)type;
			}
		}

		public static void MoveLocal(GameObject gameObject, Vector3 to, float time, int type, float delay = 0f, LuaFunction finishToDo = null, object para = null)
		{
			if (finishToDo != null)
			{
				LeanTween.moveLocal(gameObject, to, time).setDelay(delay).setOnComplete(delegate(object completePara)
				{
					if (finishToDo != null)
					{
						finishToDo.Call(new object[]
						{
							completePara
						});
					}
					finishToDo.Dispose();
					finishToDo = null;
				}).setOnCompleteParam(para).tweenType = (LeanTweenType)type;
			}
			else
			{
				LeanTween.moveLocal(gameObject, to, time).setDelay(delay).tweenType = (LeanTweenType)type;
			}
		}

		public static void Scale(GameObject gameObject, Vector3 to, float time, int type, float delay = 0f, LuaFunction finishToDo = null, object para = null)
		{
			if (finishToDo != null)
			{
				LeanTween.scale(gameObject, to, time).setDelay(delay).setOnComplete(delegate(object completePara)
				{
					if (finishToDo != null)
					{
						finishToDo.Call(new object[]
						{
							completePara
						});
					}
					finishToDo.Dispose();
					finishToDo = null;
				}).setOnCompleteParam(para).tweenType = (LeanTweenType)type;
			}
			else
			{
				LeanTween.scale(gameObject, to, time).setDelay(delay).tweenType = (LeanTweenType)type;
			}
		}

		public static void ScaleUGUI(GameObject gameObject, Vector2 to, float time, int type, float delay = 0f, LuaFunction finishToDo = null, object para = null)
		{
			Vector3 from = Vector3.zero;
			Vector3 to2 = TweenUtil.GET_POS(to.x, to.y, 0f);
			if (gameObject && (RectTransform)gameObject.transform)
			{
				from = TweenUtil.GET_POS(((RectTransform)gameObject.transform).sizeDelta.x, ((RectTransform)gameObject.transform).sizeDelta.y, 0f);
			}
			if (finishToDo != null)
			{
				LeanTween.value(gameObject, delegate(Vector3 size)
				{
					if (gameObject && (RectTransform)gameObject.transform)
					{
						((RectTransform)gameObject.transform).sizeDelta = TweenUtil.GET_POS(size.x, size.y);
					}
				}, from, to2, time).setDelay(delay).setOnComplete(delegate(object completePara)
				{
					if (finishToDo != null)
					{
						finishToDo.Call(new object[]
						{
							completePara
						});
					}
					finishToDo.Dispose();
					finishToDo = null;
				}).setOnCompleteParam(para).tweenType = (LeanTweenType)type;
			}
			else
			{
				LeanTween.value(gameObject, delegate(Vector3 size)
				{
					if (gameObject && (RectTransform)gameObject.transform)
					{
						((RectTransform)gameObject.transform).sizeDelta = TweenUtil.GET_POS(size.x, size.y);
					}
				}, from, to2, time).setDelay(delay).tweenType = (LeanTweenType)type;
			}
		}

		public static void AlphaUGUI(GameObject gameObject, float to, float time, int type, float delay = 0f, LuaFunction finishToDo = null, object para = null)
		{
			float from = 1f;
			CanvasGroup cvGroup = null;
			if (gameObject)
			{
				cvGroup = gameObject.GetComponent<CanvasGroup>();
				if (!cvGroup)
				{
					cvGroup = gameObject.AddComponent<CanvasGroup>();
				}
				from = cvGroup.alpha;
			}
			if (finishToDo != null)
			{
				LeanTween.value(gameObject, delegate(float v)
				{
					if (gameObject && cvGroup)
					{
						cvGroup.alpha = v;
					}
				}, from, to, time).setDelay(delay).setOnComplete(delegate(object completePara)
				{
					if (finishToDo != null)
					{
						finishToDo.Call(new object[]
						{
							completePara
						});
					}
					finishToDo.Dispose();
					finishToDo = null;
				}).setOnCompleteParam(para).tweenType = (LeanTweenType)type;
			}
			else
			{
				LeanTween.value(gameObject, delegate(float v)
				{
					if (gameObject && cvGroup)
					{
						cvGroup.alpha = v;
					}
				}, from, to, time).setDelay(delay).tweenType = (LeanTweenType)type;
			}
		}

		private static Vector3 GET_POS(float x, float y, float z)
		{
			return Vector3.right * x + Vector3.up * y + Vector3.forward * z;
		}

		private static Vector2 GET_POS(float x, float y)
		{
			return Vector2.right * x + Vector2.up * y;
		}

		public static void PlayGroupTween(GameObject go, int tweenGroup, bool isForward, LuaFunction luafunc)
		{
			if (go == null)
			{
				return;
			}
			UIPlayTween component = go.GetComponent<UIPlayTween>();
			if (component != null)
			{
				component.tweenGroup = tweenGroup;
				if (luafunc != null)
				{
					component.SetOnFinished(delegate
					{
						luafunc.Call();
						luafunc.Dispose();
						luafunc = null;
					});
				}
				component.Play(isForward);
			}
		}

		public static void SetTweenPositionInfo(GameObject go, Vector3 from, Vector3 to, float duration, float delay)
		{
			if (go == null)
			{
				return;
			}
			TweenPosition component = go.GetComponent<TweenPosition>();
			TweenUtil.SetTweenPositionInfoDetail(go, component, from, to, duration, delay);
		}

		private static void SetTweenPositionInfoDetail(GameObject go, TweenPosition tween, Vector3 from, Vector3 to, float duration, float delay)
		{
			if (tween == null)
			{
				tween = go.AddComponent<TweenPosition>();
			}
			tween.from = from;
			tween.to = to;
			tween.duration = duration;
			tween.delay = delay;
		}

		public static void SetTweenPositionInfoByTweenGroup(GameObject go, int tweenGroup, Vector3 from, Vector3 to, float duration, float delay)
		{
			if (go == null)
			{
				return;
			}
			TweenPosition tween = null;
			TweenPosition[] components = go.GetComponents<TweenPosition>();
			if (components != null && components.Length > 1)
			{
				for (int i = 0; i < components.Length; i++)
				{
					if (components[i].tweenGroup == tweenGroup)
					{
						tween = components[i];
						break;
					}
				}
			}
			else if (components != null && components.Length == 1)
			{
				tween = components[0];
			}
			TweenUtil.SetTweenPositionInfoDetail(go, tween, from, to, duration, delay);
		}

		public static void SetTweenUGUITextInfo(GameObject go, double from, double to, float duration)
		{
			if (go == null)
			{
				return;
			}
			TweenUGUIText component = go.GetComponent<TweenUGUIText>();
			if (component != null)
			{
				component.from = from;
				component.to = to;
				component.duration = duration;
			}
		}

		public static void SetTweenSpriteInfo(GameObject go, Sprite[] sprites, float duration, float delay)
		{
			if (go == null)
			{
				return;
			}
			TweenSprite tweenSprite = go.GetComponent<TweenSprite>();
			if (tweenSprite == null)
			{
				tweenSprite = go.AddComponent<TweenSprite>();
			}
			if (tweenSprite != null)
			{
				tweenSprite.sprites = sprites;
				tweenSprite.duration = duration;
				tweenSprite.delay = delay;
			}
		}

		public static void SetTweenRotationInfo(GameObject go, Vector3 from, Vector3 to, float duration)
		{
			if (go == null)
			{
				return;
			}
			TweenRotation tweenRotation = go.GetComponent<TweenRotation>();
			if (tweenRotation == null)
			{
				tweenRotation = go.AddComponent<TweenRotation>();
			}
			if (tweenRotation != null)
			{
				tweenRotation.from = from;
				tweenRotation.to = to;
				tweenRotation.duration = duration;
			}
		}

		public static void SetTweenAlphaInfo(GameObject go, float from, float to, float duration, float delay)
		{
			if (go == null)
			{
				return;
			}
			TweenAlpha component = go.GetComponent<TweenAlpha>();
			TweenUtil.SetTweenAlphaInfoDetail(go, component, from, to, duration, delay);
		}

		private static void SetTweenAlphaInfoDetail(GameObject go, TweenAlpha tween, float from, float to, float duration, float delay)
		{
			if (tween == null)
			{
				tween = go.AddComponent<TweenAlpha>();
			}
			if (tween != null)
			{
				tween.from = from;
				tween.to = to;
				tween.duration = duration;
				tween.delay = delay;
				tween.includeChildren = true;
			}
		}

		public static void SetTweenAlphaInfoByTweenGroup(GameObject go, int tweenGroup, float from, float to, float duration, float delay)
		{
			if (go == null)
			{
				return;
			}
			TweenAlpha tween = null;
			TweenAlpha[] components = go.GetComponents<TweenAlpha>();
			if (components != null && components.Length > 1)
			{
				for (int i = 0; i < components.Length; i++)
				{
					if (components[i].tweenGroup == tweenGroup)
					{
						tween = components[i];
						break;
					}
				}
			}
			else if (components != null && components.Length == 1)
			{
				tween = components[0];
			}
			TweenUtil.SetTweenAlphaInfoDetail(go, tween, from, to, duration, delay);
		}

		public static void SetTweenScaleInfo(GameObject go, Vector3 from, Vector3 to, float duration, float delay, Vector2[] keyframes)
		{
			if (go == null)
			{
				return;
			}
			TweenScale tweenScale = go.GetComponent<TweenScale>();
			if (tweenScale == null)
			{
				tweenScale = go.AddComponent<TweenScale>();
			}
			if (tweenScale != null)
			{
				tweenScale.from = from;
				tweenScale.to = to;
				tweenScale.duration = duration;
				tweenScale.delay = delay;
				if (keyframes != null && keyframes.Length > 0)
				{
					Keyframe[] array = new Keyframe[keyframes.Length];
					for (int i = 0; i < keyframes.Length; i++)
					{
						array[i] = new Keyframe(keyframes[i].x, keyframes[i].y);
					}
					tweenScale.animationCurve = new AnimationCurve(array);
				}
			}
		}

		public static void PlayTween(GameObject go, bool isForward, LuaFunction luafunc, bool isRestart)
		{
			if (go == null)
			{
				return;
			}
			UIPlayTween component = go.GetComponent<UIPlayTween>();
			if (component != null)
			{
				component.SetOnFinished(delegate
				{
					if (luafunc != null)
					{
						luafunc.Call();
						luafunc.Dispose();
						luafunc = null;
					}
				});
				component.Play(isForward);
			}
			else
			{
				UITweener component2 = go.GetComponent<UITweener>();
				if (component2 != null)
				{
					component2.SetOnFinished(delegate
					{
						if (luafunc != null)
						{
							luafunc.Call();
							luafunc.Dispose();
							luafunc = null;
						}
					});
					if (isRestart)
					{
						component2.ResetToBeginning();
					}
					component2.Play(isForward);
				}
				else if (luafunc != null)
				{
					luafunc.Call();
					luafunc.Dispose();
					luafunc = null;
				}
			}
		}

		public static void StopTween(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			UITweener component = go.GetComponent<UITweener>();
			if (component != null)
			{
				component.enabled = false;
			}
		}

		public static void DestroyTween(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			UITweener component = go.GetComponent<UITweener>();
			if (component != null)
			{
				UnityEngine.Object.DestroyImmediate(component);
			}
		}

		public static void StopiTween(GameObject gobj)
		{
			if (gobj == null)
			{
				return;
			}
			iTween.Stop(gobj);
		}

		public static void ITweenMoveTo(GameObject gameObject, object[] path, bool isMovetopath, float speedOrTimeValue, string type, LuaFunction luafunc, float distance, bool isLookAt, bool isUseTime)
		{
			Vector3[] vpath = new Vector3[path.Length];
			for (int i = 0; i < path.Length; i++)
			{
				vpath[i] = (Vector3)path[i];
			}
			Hashtable hashtable = iTween.Hash(new object[]
			{
				"path",
				vpath,
				"orienttopath",
				isLookAt,
				"movetopath",
				isMovetopath,
				"easetype",
				type,
				"delay",
				0f
			});
			if (isUseTime)
			{
				hashtable.Add("time", speedOrTimeValue);
			}
			else
			{
				hashtable.Add("speed", speedOrTimeValue);
			}
			if (luafunc != null)
			{
				bool bCallOnce = true;
				bool bCallCompleteOnce = true;
				Action value = delegate
				{
					float num = Vector3.Distance(gameObject.transform.position, vpath[path.Length - 1]);
					if (bCallOnce && num <= distance)
					{
						bCallOnce = false;
						luafunc.Call(new object[]
						{
							false
						});
					}
					if (bCallCompleteOnce && num <= 0.1f)
					{
						bCallCompleteOnce = false;
						luafunc.Call(new object[]
						{
							true
						});
					}
				};
				Action value2 = delegate
				{
					luafunc.Call(new object[]
					{
						true
					});
					luafunc.Dispose();
					luafunc = null;
				};
				if (distance > 0f)
				{
					hashtable.Add("onupdate", value);
				}
				hashtable.Add("oncomplete", value2);
			}
			iTween.MoveTo(gameObject, hashtable);
		}

		public static void ITweenValueTo(GameObject gameObject, float from, float to, float time, string type, LuaFunction onUpdate, LuaFunction onComplete)
		{
			Hashtable hashtable = iTween.Hash(new object[]
			{
				"easetype",
				type,
				"time",
				time,
				"from",
				from,
				"to",
				to
			});
			if (onUpdate != null)
			{
				Action<object> value3 = delegate(object value)
				{
					onUpdate.Call(new object[]
					{
						(float)value
					});
				};
				hashtable.Add("onupdate", value3);
			}
			if (onComplete != null)
			{
				Action value2 = delegate
				{
					onComplete.Call(new object[]
					{
						true
					});
					onComplete.Dispose();
					onComplete = null;
				};
				hashtable.Add("oncomplete", value2);
			}
			iTween.ValueTo(gameObject, hashtable);
		}
	}
}
