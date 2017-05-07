using System;
using System.Collections;
using UnityEngine;

public class LTDescr
{
	public bool toggle;

	public bool useEstimatedTime;

	public bool useFrames;

	public bool hasInitiliazed;

	public bool hasPhysics;

	public float passed;

	public float delay;

	public float time;

	public float lastVal;

	private uint _id;

	public int loopCount;

	public uint counter;

	public float direction;

	public bool destroyOnComplete;

	public Transform trans;

	public LTRect ltRect;

	public Vector3 from;

	public Vector3 to;

	public Vector3 diff;

	public Vector3 point;

	public Vector3 axis;

	public Quaternion origRotation;

	public LTBezierPath path;

	public LTSpline spline;

	public TweenAction type;

	public LeanTweenType tweenType;

	public AnimationCurve animationCurve;

	public LeanTweenType loopType;

	public Action<float> onUpdateFloat;

	public Action<float, object> onUpdateFloatObject;

	public Action<Vector3> onUpdateVector3;

	public Action<Vector3, object> onUpdateVector3Object;

	public Action<Color> onUpdateColor;

	public Action onComplete;

	public Action<object> onCompleteObject;

	public object onCompleteParam;

	public object onUpdateParam;

	public bool onCompleteOnRepeat;

	public Hashtable optional;

	private static uint global_counter;

	public int uniqueId
	{
		get
		{
			return (int)(this._id | this.counter << 16);
		}
	}

	public int id
	{
		get
		{
			return this.uniqueId;
		}
	}

	public override string ToString()
	{
		return string.Concat(new object[]
		{
			(!(this.trans != null)) ? "gameObject:null" : ("gameObject:" + this.trans.gameObject),
			" toggle:",
			this.toggle,
			" passed:",
			this.passed,
			" time:",
			this.time,
			" delay:",
			this.delay,
			" from:",
			this.from,
			" to:",
			this.to,
			" type:",
			this.type,
			" ease:",
			this.tweenType,
			" useEstimatedTime:",
			this.useEstimatedTime,
			" id:",
			this.id,
			" hasInitiliazed:",
			this.hasInitiliazed
		});
	}

	public LTDescr cancel()
	{
		LeanTween.removeTween((int)this._id);
		return this;
	}

	public void reset()
	{
		this.toggle = true;
		this.optional = null;
		this.passed = (this.delay = 0f);
		this.useEstimatedTime = (this.useFrames = (this.hasInitiliazed = (this.onCompleteOnRepeat = (this.destroyOnComplete = false))));
		this.animationCurve = null;
		this.tweenType = LeanTweenType.linear;
		this.loopType = LeanTweenType.once;
		this.loopCount = 0;
		this.direction = (this.lastVal = 1f);
		this.onUpdateFloat = null;
		this.onUpdateVector3 = null;
		this.onUpdateFloatObject = null;
		this.onUpdateVector3Object = null;
		this.onComplete = null;
		this.onCompleteObject = null;
		this.onCompleteParam = null;
		this.point = Vector3.zero;
		LTDescr.global_counter += 1u;
	}

	public LTDescr pause()
	{
		if (this.direction != 0f)
		{
			this.lastVal = this.direction;
			this.direction = 0f;
		}
		return this;
	}

	public LTDescr resume()
	{
		this.direction = this.lastVal;
		return this;
	}

	public LTDescr setAxis(Vector3 axis)
	{
		this.axis = axis;
		return this;
	}

	public LTDescr setDelay(float delay)
	{
		if (this.useEstimatedTime)
		{
			this.delay = delay;
		}
		else
		{
			this.delay = delay * Time.timeScale;
		}
		return this;
	}

	public LTDescr setEase(LeanTweenType easeType)
	{
		this.tweenType = easeType;
		return this;
	}

	public LTDescr setEase(AnimationCurve easeCurve)
	{
		this.animationCurve = easeCurve;
		return this;
	}

	public LTDescr setTo(Vector3 to)
	{
		this.to = to;
		return this;
	}

	public LTDescr setFrom(Vector3 from)
	{
		this.from = from;
		this.hasInitiliazed = true;
		this.diff = this.to - this.from;
		return this;
	}

	public LTDescr setHasInitialized(bool has)
	{
		this.hasInitiliazed = has;
		return this;
	}

	public LTDescr setId(uint id)
	{
		this._id = id;
		this.counter = LTDescr.global_counter;
		return this;
	}

	public LTDescr setRepeat(int repeat)
	{
		this.loopCount = repeat;
		if ((repeat > 1 && this.loopType == LeanTweenType.once) || (repeat < 0 && this.loopType == LeanTweenType.once))
		{
			this.loopType = LeanTweenType.clamp;
		}
		return this;
	}

	public LTDescr setLoopType(LeanTweenType loopType)
	{
		this.loopType = loopType;
		return this;
	}

	public LTDescr setUseEstimatedTime(bool useEstimatedTime)
	{
		this.useEstimatedTime = useEstimatedTime;
		return this;
	}

	public LTDescr setUseFrames(bool useFrames)
	{
		this.useFrames = useFrames;
		return this;
	}

	public LTDescr setLoopCount(int loopCount)
	{
		this.loopCount = loopCount;
		return this;
	}

	public LTDescr setLoopOnce()
	{
		this.loopType = LeanTweenType.once;
		return this;
	}

	public LTDescr setLoopClamp()
	{
		this.loopType = LeanTweenType.clamp;
		if (this.loopCount == 0)
		{
			this.loopCount = -1;
		}
		return this;
	}

	public LTDescr setLoopPingPong()
	{
		this.loopType = LeanTweenType.pingPong;
		if (this.loopCount == 0)
		{
			this.loopCount = -1;
		}
		return this;
	}

	public LTDescr setOnComplete(Action onComplete)
	{
		this.onComplete = onComplete;
		return this;
	}

	public LTDescr setOnComplete(Action<object> onComplete)
	{
		this.onCompleteObject = onComplete;
		return this;
	}

	public LTDescr setOnComplete(Action<object> onComplete, object onCompleteParam)
	{
		this.onCompleteObject = onComplete;
		if (onCompleteParam != null)
		{
			this.onCompleteParam = onCompleteParam;
		}
		return this;
	}

	public LTDescr setOnCompleteParam(object onCompleteParam)
	{
		this.onCompleteParam = onCompleteParam;
		return this;
	}

	public LTDescr setOnUpdate(Action<float> onUpdate)
	{
		this.onUpdateFloat = onUpdate;
		return this;
	}

	public LTDescr setOnUpdateObject(Action<float, object> onUpdate)
	{
		this.onUpdateFloatObject = onUpdate;
		return this;
	}

	public LTDescr setOnUpdateVector3(Action<Vector3> onUpdate)
	{
		this.onUpdateVector3 = onUpdate;
		return this;
	}

	public LTDescr setOnUpdateColor(Action<Color> onUpdate)
	{
		this.onUpdateColor = onUpdate;
		return this;
	}

	public LTDescr setOnUpdate(Action<float, object> onUpdate, object onUpdateParam = null)
	{
		this.onUpdateFloatObject = onUpdate;
		if (onUpdateParam != null)
		{
			this.onUpdateParam = onUpdateParam;
		}
		return this;
	}

	public LTDescr setOnUpdate(Action<Vector3, object> onUpdate, object onUpdateParam = null)
	{
		this.onUpdateVector3Object = onUpdate;
		if (onUpdateParam != null)
		{
			this.onUpdateParam = onUpdateParam;
		}
		return this;
	}

	public LTDescr setOnUpdate(Action<Vector3> onUpdate, object onUpdateParam = null)
	{
		this.onUpdateVector3 = onUpdate;
		if (onUpdateParam != null)
		{
			this.onUpdateParam = onUpdateParam;
		}
		return this;
	}

	public LTDescr setOnUpdateParam(object onUpdateParam)
	{
		this.onUpdateParam = onUpdateParam;
		return this;
	}

	public LTDescr setOrientToPath(bool doesOrient)
	{
		if (this.type == TweenAction.MOVE_CURVED || this.type == TweenAction.MOVE_CURVED_LOCAL)
		{
			if (this.path == null)
			{
				this.path = new LTBezierPath();
			}
			this.path.orientToPath = doesOrient;
		}
		else
		{
			this.spline.orientToPath = doesOrient;
		}
		return this;
	}

	public LTDescr setOrientToPath2d(bool doesOrient2d)
	{
		this.setOrientToPath(doesOrient2d);
		if (this.type == TweenAction.MOVE_CURVED || this.type == TweenAction.MOVE_CURVED_LOCAL)
		{
			this.path.orientToPath2d = doesOrient2d;
		}
		else
		{
			this.spline.orientToPath2d = doesOrient2d;
		}
		return this;
	}

	public LTDescr setRect(LTRect rect)
	{
		this.ltRect = rect;
		return this;
	}

	public LTDescr setRect(Rect rect)
	{
		this.ltRect = new LTRect(rect);
		return this;
	}

	public LTDescr setPath(LTBezierPath path)
	{
		this.path = path;
		return this;
	}

	public LTDescr setPoint(Vector3 point)
	{
		this.point = point;
		return this;
	}

	public LTDescr setDestroyOnComplete(bool doesDestroy)
	{
		this.destroyOnComplete = doesDestroy;
		return this;
	}

	public LTDescr setAudio(object audio)
	{
		this.onCompleteParam = audio;
		return this;
	}

	public LTDescr setOnCompleteOnRepeat(bool isOn)
	{
		this.onCompleteOnRepeat = isOn;
		return this;
	}
}
