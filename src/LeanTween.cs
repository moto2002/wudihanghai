using System;
using System.Collections;
using UnityEngine;

public class LeanTween : MonoBehaviour
{
	public static bool throwErrors = true;

	private static LTDescr[] tweens;

	private static int tweenMaxSearch = 0;

	private static int maxTweens = 400;

	private static int frameRendered = -1;

	private static GameObject _tweenEmpty;

	private static float dtEstimated;

	private static float previousRealTime;

	private static float dt;

	private static float dtActual;

	private static LTDescr tween;

	private static int i;

	private static int j;

	private static AnimationCurve punch = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f),
		new Keyframe(0.112586f, 0.9976035f),
		new Keyframe(0.3120486f, -0.1720615f),
		new Keyframe(0.4316337f, 0.07030682f),
		new Keyframe(0.5524869f, -0.03141804f),
		new Keyframe(0.6549395f, 0.003909959f),
		new Keyframe(0.770987f, -0.009817753f),
		new Keyframe(0.8838775f, 0.001939224f),
		new Keyframe(1f, 0f)
	});

	private static AnimationCurve shake = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f),
		new Keyframe(0.25f, 1f),
		new Keyframe(0.75f, -1f),
		new Keyframe(1f, 0f)
	});

	private static Transform trans;

	private static float timeTotal;

	private static TweenAction tweenAction;

	private static float ratioPassed;

	private static float from;

	private static float to;

	private static float val;

	private static Vector3 newVect;

	private static bool isTweenFinished;

	private static GameObject target;

	private static GameObject customTarget;

	public static int startSearch = 0;

	public static LTDescr descr;

	private static Action<LTEvent>[] eventListeners;

	private static GameObject[] goListeners;

	private static int eventsMaxSearch = 0;

	public static int EVENTS_MAX = 10;

	public static int LISTENERS_MAX = 10;

	private static int INIT_LISTENERS_MAX = LeanTween.LISTENERS_MAX;

	public static GameObject tweenEmpty
	{
		get
		{
			LeanTween.init(LeanTween.maxTweens);
			return LeanTween._tweenEmpty;
		}
	}

	public static void init()
	{
		LeanTween.init(LeanTween.maxTweens);
	}

	public static void init(int maxSimultaneousTweens)
	{
		if (LeanTween.tweens == null)
		{
			LeanTween.maxTweens = maxSimultaneousTweens;
			LeanTween.tweens = new LTDescr[LeanTween.maxTweens];
			LeanTween._tweenEmpty = new GameObject();
			LeanTween._tweenEmpty.name = "~LeanTween";
			LeanTween._tweenEmpty.AddComponent(typeof(LeanTween));
			LeanTween._tweenEmpty.isStatic = true;
			LeanTween._tweenEmpty.hideFlags = HideFlags.HideAndDontSave;
			UnityEngine.Object.DontDestroyOnLoad(LeanTween._tweenEmpty);
			for (int i = 0; i < LeanTween.maxTweens; i++)
			{
				LeanTween.tweens[i] = new LTDescr();
			}
		}
	}

	public static void reset()
	{
		LeanTween.tweens = null;
	}

	public void Update()
	{
		LeanTween.update();
	}

	public void OnLevelWasLoaded(int lvl)
	{
		LTGUI.reset();
	}

	public static void update()
	{
		if (LeanTween.frameRendered != Time.frameCount)
		{
			LeanTween.init();
			LeanTween.dtEstimated = Time.realtimeSinceStartup - LeanTween.previousRealTime;
			if (LeanTween.dtEstimated > 0.2f)
			{
				LeanTween.dtEstimated = 0.2f;
			}
			LeanTween.previousRealTime = Time.realtimeSinceStartup;
			LeanTween.dtActual = Time.deltaTime * Time.timeScale;
			int num = 0;
			while (num < LeanTween.tweenMaxSearch && num < LeanTween.maxTweens)
			{
				if (LeanTween.tweens[num].toggle)
				{
					LeanTween.tween = LeanTween.tweens[num];
					LeanTween.trans = LeanTween.tween.trans;
					LeanTween.timeTotal = LeanTween.tween.time;
					LeanTween.tweenAction = LeanTween.tween.type;
					LeanTween.dt = LeanTween.dtActual;
					if (LeanTween.tween.useEstimatedTime)
					{
						LeanTween.dt = LeanTween.dtEstimated;
						LeanTween.timeTotal = LeanTween.tween.time;
					}
					else if (LeanTween.tween.useFrames)
					{
						LeanTween.dt = 1f;
					}
					else if (LeanTween.tween.direction == 0f)
					{
						LeanTween.dt = 0f;
					}
					if (LeanTween.trans == null)
					{
						LeanTween.removeTween(num);
					}
					else
					{
						LeanTween.isTweenFinished = false;
						if (LeanTween.tween.delay <= 0f)
						{
							if (LeanTween.tween.passed + LeanTween.dt > LeanTween.timeTotal && LeanTween.tween.direction > 0f)
							{
								LeanTween.isTweenFinished = true;
								LeanTween.tween.passed = LeanTween.tween.time;
							}
							else if (LeanTween.tween.direction < 0f && LeanTween.tween.passed - LeanTween.dt < 0f)
							{
								LeanTween.isTweenFinished = true;
								LeanTween.tween.passed = Mathf.Epsilon;
							}
						}
						if (!LeanTween.tween.hasInitiliazed && (((double)LeanTween.tween.passed == 0.0 && (double)LeanTween.tween.delay == 0.0) || (double)LeanTween.tween.passed > 0.0))
						{
							LeanTween.tween.hasInitiliazed = true;
							if (!LeanTween.tween.useEstimatedTime)
							{
								LeanTween.tween.time = LeanTween.tween.time * Time.timeScale;
							}
							switch (LeanTween.tweenAction)
							{
							case TweenAction.MOVE_X:
								LeanTween.tween.from.x = LeanTween.trans.position.x;
								break;
							case TweenAction.MOVE_Y:
								LeanTween.tween.from.x = LeanTween.trans.position.y;
								break;
							case TweenAction.MOVE_Z:
								LeanTween.tween.from.x = LeanTween.trans.position.z;
								break;
							case TweenAction.MOVE_LOCAL_X:
								LeanTween.tweens[num].from.x = LeanTween.trans.localPosition.x;
								break;
							case TweenAction.MOVE_LOCAL_Y:
								LeanTween.tweens[num].from.x = LeanTween.trans.localPosition.y;
								break;
							case TweenAction.MOVE_LOCAL_Z:
								LeanTween.tweens[num].from.x = LeanTween.trans.localPosition.z;
								break;
							case TweenAction.MOVE_CURVED:
							case TweenAction.MOVE_CURVED_LOCAL:
							case TweenAction.MOVE_SPLINE:
							case TweenAction.MOVE_SPLINE_LOCAL:
								LeanTween.tween.from.x = 0f;
								break;
							case TweenAction.SCALE_X:
								LeanTween.tween.from.x = LeanTween.trans.localScale.x;
								break;
							case TweenAction.SCALE_Y:
								LeanTween.tween.from.x = LeanTween.trans.localScale.y;
								break;
							case TweenAction.SCALE_Z:
								LeanTween.tween.from.x = LeanTween.trans.localScale.z;
								break;
							case TweenAction.ROTATE_X:
								LeanTween.tween.from.x = LeanTween.trans.eulerAngles.x;
								LeanTween.tween.to.x = LeanTween.closestRot(LeanTween.tween.from.x, LeanTween.tween.to.x);
								break;
							case TweenAction.ROTATE_Y:
								LeanTween.tween.from.x = LeanTween.trans.eulerAngles.y;
								LeanTween.tween.to.x = LeanTween.closestRot(LeanTween.tween.from.x, LeanTween.tween.to.x);
								break;
							case TweenAction.ROTATE_Z:
								LeanTween.tween.from.x = LeanTween.trans.eulerAngles.z;
								LeanTween.tween.to.x = LeanTween.closestRot(LeanTween.tween.from.x, LeanTween.tween.to.x);
								break;
							case TweenAction.ROTATE_AROUND:
								LeanTween.tween.lastVal = 0f;
								LeanTween.tween.from.x = 0f;
								LeanTween.tween.origRotation = LeanTween.trans.rotation;
								break;
							case TweenAction.ROTATE_AROUND_LOCAL:
								LeanTween.tween.lastVal = 0f;
								LeanTween.tween.from.x = 0f;
								LeanTween.tween.origRotation = LeanTween.trans.localRotation;
								break;
							case TweenAction.ALPHA:
							{
								SpriteRenderer component = LeanTween.trans.gameObject.GetComponent<SpriteRenderer>();
								if (component != null)
								{
									LeanTween.tween.from.x = component.color.a;
								}
								else if (LeanTween.trans.gameObject.GetComponent<Renderer>() != null)
								{
									LeanTween.tween.from.x = LeanTween.trans.gameObject.GetComponent<Renderer>().material.color.a;
								}
								break;
							}
							case TweenAction.ALPHA_VERTEX:
								LeanTween.tween.from.x = (float)LeanTween.trans.GetComponent<MeshFilter>().mesh.colors32[0].a;
								break;
							case TweenAction.COLOR:
							{
								SpriteRenderer component2 = LeanTween.trans.gameObject.GetComponent<SpriteRenderer>();
								if (component2 != null)
								{
									LeanTween.tween.from = new Vector3(0f, component2.color.a, 0f);
									LeanTween.tween.diff = new Vector3(1f, 0f, 0f);
									LeanTween.tween.axis = new Vector3(component2.color.r, component2.color.g, component2.color.b);
								}
								else if (LeanTween.trans.gameObject.GetComponent<Renderer>() != null && LeanTween.trans.gameObject.GetComponent<Renderer>())
								{
									Color color = LeanTween.trans.gameObject.GetComponent<Renderer>().material.color;
									LeanTween.tween.from = new Vector3(0f, color.a, 0f);
									LeanTween.tween.diff = new Vector3(1f, 0f, 0f);
									LeanTween.tween.axis = new Vector3(color.r, color.g, color.b);
								}
								break;
							}
							case TweenAction.CALLBACK_COLOR:
								LeanTween.tween.diff = new Vector3(1f, 0f, 0f);
								break;
							case TweenAction.MOVE:
								LeanTween.tween.from = LeanTween.trans.position;
								break;
							case TweenAction.MOVE_LOCAL:
								LeanTween.tween.from = LeanTween.trans.localPosition;
								break;
							case TweenAction.ROTATE:
								LeanTween.tween.from = LeanTween.trans.eulerAngles;
								LeanTween.tween.to = new Vector3(LeanTween.closestRot(LeanTween.tween.from.x, LeanTween.tween.to.x), LeanTween.closestRot(LeanTween.tween.from.y, LeanTween.tween.to.y), LeanTween.closestRot(LeanTween.tween.from.z, LeanTween.tween.to.z));
								break;
							case TweenAction.ROTATE_LOCAL:
								LeanTween.tween.from = LeanTween.trans.localEulerAngles;
								LeanTween.tween.to = new Vector3(LeanTween.closestRot(LeanTween.tween.from.x, LeanTween.tween.to.x), LeanTween.closestRot(LeanTween.tween.from.y, LeanTween.tween.to.y), LeanTween.closestRot(LeanTween.tween.from.z, LeanTween.tween.to.z));
								break;
							case TweenAction.SCALE:
								LeanTween.tween.from = LeanTween.trans.localScale;
								break;
							case TweenAction.GUI_MOVE:
								LeanTween.tween.from = new Vector3(LeanTween.tween.ltRect.rect.x, LeanTween.tween.ltRect.rect.y, 0f);
								break;
							case TweenAction.GUI_MOVE_MARGIN:
								LeanTween.tween.from = new Vector2(LeanTween.tween.ltRect.margin.x, LeanTween.tween.ltRect.margin.y);
								break;
							case TweenAction.GUI_SCALE:
								LeanTween.tween.from = new Vector3(LeanTween.tween.ltRect.rect.width, LeanTween.tween.ltRect.rect.height, 0f);
								break;
							case TweenAction.GUI_ALPHA:
								LeanTween.tween.from.x = LeanTween.tween.ltRect.alpha;
								break;
							case TweenAction.GUI_ROTATE:
								if (!LeanTween.tween.ltRect.rotateEnabled)
								{
									LeanTween.tween.ltRect.rotateEnabled = true;
									LeanTween.tween.ltRect.resetForRotation();
								}
								LeanTween.tween.from.x = LeanTween.tween.ltRect.rotation;
								break;
							}
							if (LeanTween.tweenAction != TweenAction.CALLBACK_COLOR && LeanTween.tweenAction != TweenAction.COLOR)
							{
								LeanTween.tween.diff = LeanTween.tween.to - LeanTween.tween.from;
							}
						}
						if (LeanTween.tween.delay <= 0f)
						{
							if (LeanTween.timeTotal <= 0f)
							{
								LeanTween.ratioPassed = 0f;
							}
							else
							{
								LeanTween.ratioPassed = LeanTween.tween.passed / LeanTween.timeTotal;
							}
							if (LeanTween.ratioPassed > 1f)
							{
								LeanTween.ratioPassed = 1f;
							}
							else if (LeanTween.ratioPassed < 0f)
							{
								LeanTween.ratioPassed = 0f;
							}
							if (LeanTween.tweenAction >= TweenAction.MOVE_X && LeanTween.tweenAction <= TweenAction.CALLBACK)
							{
								if (LeanTween.tween.animationCurve != null)
								{
									LeanTween.val = LeanTween.tweenOnCurve(LeanTween.tween, LeanTween.ratioPassed);
								}
								else
								{
									switch (LeanTween.tween.tweenType)
									{
									case LeanTweenType.linear:
										LeanTween.val = LeanTween.tween.from.x + LeanTween.tween.diff.x * LeanTween.ratioPassed;
										break;
									case LeanTweenType.easeOutQuad:
										LeanTween.val = LeanTween.easeOutQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInQuad:
										LeanTween.val = LeanTween.easeInQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutQuad:
										LeanTween.val = LeanTween.easeInOutQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInCubic:
										LeanTween.val = LeanTween.easeInCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutCubic:
										LeanTween.val = LeanTween.easeOutCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutCubic:
										LeanTween.val = LeanTween.easeInOutCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInQuart:
										LeanTween.val = LeanTween.easeInQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutQuart:
										LeanTween.val = LeanTween.easeOutQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutQuart:
										LeanTween.val = LeanTween.easeInOutQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInQuint:
										LeanTween.val = LeanTween.easeInQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutQuint:
										LeanTween.val = LeanTween.easeOutQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutQuint:
										LeanTween.val = LeanTween.easeInOutQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInSine:
										LeanTween.val = LeanTween.easeInSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutSine:
										LeanTween.val = LeanTween.easeOutSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutSine:
										LeanTween.val = LeanTween.easeInOutSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInExpo:
										LeanTween.val = LeanTween.easeInExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutExpo:
										LeanTween.val = LeanTween.easeOutExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutExpo:
										LeanTween.val = LeanTween.easeInOutExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInCirc:
										LeanTween.val = LeanTween.easeInCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutCirc:
										LeanTween.val = LeanTween.easeOutCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutCirc:
										LeanTween.val = LeanTween.easeInOutCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInBounce:
										LeanTween.val = LeanTween.easeInBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutBounce:
										LeanTween.val = LeanTween.easeOutBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutBounce:
										LeanTween.val = LeanTween.easeInOutBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInBack:
										LeanTween.val = LeanTween.easeInBack(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutBack:
										LeanTween.val = LeanTween.easeOutBack(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutBack:
										LeanTween.val = LeanTween.easeInOutElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInElastic:
										LeanTween.val = LeanTween.easeInElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeOutElastic:
										LeanTween.val = LeanTween.easeOutElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeInOutElastic:
										LeanTween.val = LeanTween.easeInOutElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeSpring:
										LeanTween.val = LeanTween.spring(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed);
										break;
									case LeanTweenType.easeShake:
									case LeanTweenType.punch:
										if (LeanTween.tween.tweenType == LeanTweenType.punch)
										{
											LeanTween.tween.animationCurve = LeanTween.punch;
										}
										else if (LeanTween.tween.tweenType == LeanTweenType.easeShake)
										{
											LeanTween.tween.animationCurve = LeanTween.shake;
										}
										LeanTween.tween.to.x = LeanTween.tween.from.x + LeanTween.tween.to.x;
										LeanTween.tween.diff.x = LeanTween.tween.to.x - LeanTween.tween.from.x;
										LeanTween.val = LeanTween.tweenOnCurve(LeanTween.tween, LeanTween.ratioPassed);
										break;
									default:
										LeanTween.val = LeanTween.tween.from.x + LeanTween.tween.diff.x * LeanTween.ratioPassed;
										break;
									}
								}
								if (LeanTween.tweenAction == TweenAction.MOVE_X)
								{
									LeanTween.trans.position = new Vector3(LeanTween.val, LeanTween.trans.position.y, LeanTween.trans.position.z);
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_Y)
								{
									LeanTween.trans.position = new Vector3(LeanTween.trans.position.x, LeanTween.val, LeanTween.trans.position.z);
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_Z)
								{
									LeanTween.trans.position = new Vector3(LeanTween.trans.position.x, LeanTween.trans.position.y, LeanTween.val);
								}
								if (LeanTween.tweenAction == TweenAction.MOVE_LOCAL_X)
								{
									LeanTween.trans.localPosition = new Vector3(LeanTween.val, LeanTween.trans.localPosition.y, LeanTween.trans.localPosition.z);
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_LOCAL_Y)
								{
									LeanTween.trans.localPosition = new Vector3(LeanTween.trans.localPosition.x, LeanTween.val, LeanTween.trans.localPosition.z);
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_LOCAL_Z)
								{
									LeanTween.trans.localPosition = new Vector3(LeanTween.trans.localPosition.x, LeanTween.trans.localPosition.y, LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_CURVED)
								{
									if (LeanTween.tween.path.orientToPath)
									{
										if (LeanTween.tween.path.orientToPath2d)
										{
											LeanTween.tween.path.place2d(LeanTween.trans, LeanTween.val);
										}
										else
										{
											LeanTween.tween.path.place(LeanTween.trans, LeanTween.val);
										}
									}
									else
									{
										LeanTween.trans.position = LeanTween.tween.path.point(LeanTween.val);
									}
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_CURVED_LOCAL)
								{
									if (LeanTween.tween.path.orientToPath)
									{
										if (LeanTween.tween.path.orientToPath2d)
										{
											LeanTween.tween.path.placeLocal2d(LeanTween.trans, LeanTween.val);
										}
										else
										{
											LeanTween.tween.path.placeLocal(LeanTween.trans, LeanTween.val);
										}
									}
									else
									{
										LeanTween.trans.localPosition = LeanTween.tween.path.point(LeanTween.val);
									}
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_SPLINE)
								{
									if (LeanTween.tween.spline.orientToPath)
									{
										if (LeanTween.tween.spline.orientToPath2d)
										{
											LeanTween.tween.spline.place2d(LeanTween.trans, LeanTween.val);
										}
										else
										{
											LeanTween.tween.spline.place(LeanTween.trans, LeanTween.val);
										}
									}
									else
									{
										LeanTween.trans.position = LeanTween.tween.spline.point(LeanTween.val);
									}
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_SPLINE_LOCAL)
								{
									if (LeanTween.tween.spline.orientToPath)
									{
										if (LeanTween.tween.spline.orientToPath2d)
										{
											LeanTween.tween.spline.placeLocal2d(LeanTween.trans, LeanTween.val);
										}
										else
										{
											LeanTween.tween.spline.placeLocal(LeanTween.trans, LeanTween.val);
										}
									}
									else
									{
										LeanTween.trans.localPosition = LeanTween.tween.spline.point(LeanTween.val);
									}
								}
								else if (LeanTween.tweenAction == TweenAction.SCALE_X)
								{
									LeanTween.trans.localScale = new Vector3(LeanTween.val, LeanTween.trans.localScale.y, LeanTween.trans.localScale.z);
								}
								else if (LeanTween.tweenAction == TweenAction.SCALE_Y)
								{
									LeanTween.trans.localScale = new Vector3(LeanTween.trans.localScale.x, LeanTween.val, LeanTween.trans.localScale.z);
								}
								else if (LeanTween.tweenAction == TweenAction.SCALE_Z)
								{
									LeanTween.trans.localScale = new Vector3(LeanTween.trans.localScale.x, LeanTween.trans.localScale.y, LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_X)
								{
									LeanTween.trans.eulerAngles = new Vector3(LeanTween.val, LeanTween.trans.eulerAngles.y, LeanTween.trans.eulerAngles.z);
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_Y)
								{
									LeanTween.trans.eulerAngles = new Vector3(LeanTween.trans.eulerAngles.x, LeanTween.val, LeanTween.trans.eulerAngles.z);
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_Z)
								{
									LeanTween.trans.eulerAngles = new Vector3(LeanTween.trans.eulerAngles.x, LeanTween.trans.eulerAngles.y, LeanTween.val);
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_AROUND)
								{
									float num2 = LeanTween.val - LeanTween.tween.lastVal;
									Debug.Log(string.Concat(new object[]
									{
										"move:",
										num2,
										" val:",
										LeanTween.val,
										" timeTotal:",
										LeanTween.timeTotal,
										" from:",
										LeanTween.tween.from,
										" diff:",
										LeanTween.tween.diff,
										" type:",
										LeanTween.tween.tweenType
									}));
									if (LeanTween.isTweenFinished)
									{
										if (LeanTween.tween.direction > 0f)
										{
											Vector3 localPosition = LeanTween.trans.localPosition;
											LeanTween.trans.RotateAround(LeanTween.trans.TransformPoint(LeanTween.tween.point), LeanTween.tween.axis, -LeanTween.tween.to.x);
											Vector3 b = localPosition - LeanTween.trans.localPosition;
											LeanTween.trans.localPosition = localPosition - b;
											LeanTween.trans.rotation = LeanTween.tween.origRotation;
											LeanTween.trans.RotateAround(LeanTween.trans.TransformPoint(LeanTween.tween.point), LeanTween.tween.axis, LeanTween.tween.to.x);
										}
										else
										{
											LeanTween.trans.rotation = LeanTween.tween.origRotation;
										}
									}
									else
									{
										LeanTween.trans.RotateAround(LeanTween.trans.TransformPoint(LeanTween.tween.point), LeanTween.tween.axis, num2);
										LeanTween.tween.lastVal = LeanTween.val;
									}
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_AROUND_LOCAL)
								{
									float angle = LeanTween.val - LeanTween.tween.lastVal;
									if (LeanTween.isTweenFinished)
									{
										if (LeanTween.tween.direction > 0f)
										{
											Vector3 localPosition2 = LeanTween.trans.localPosition;
											LeanTween.trans.RotateAround(LeanTween.trans.TransformPoint(LeanTween.tween.point), LeanTween.trans.TransformDirection(LeanTween.tween.axis), -LeanTween.tween.to.x);
											Vector3 b2 = localPosition2 - LeanTween.trans.localPosition;
											LeanTween.trans.localPosition = localPosition2 - b2;
											LeanTween.trans.localRotation = LeanTween.tween.origRotation;
											LeanTween.trans.RotateAround(LeanTween.trans.TransformPoint(LeanTween.tween.point), LeanTween.trans.TransformDirection(LeanTween.tween.axis), LeanTween.tween.to.x);
										}
										else
										{
											LeanTween.trans.localRotation = LeanTween.tween.origRotation;
										}
									}
									else
									{
										LeanTween.trans.RotateAround(LeanTween.trans.TransformPoint(LeanTween.tween.point), LeanTween.trans.TransformDirection(LeanTween.tween.axis), angle);
										LeanTween.tween.lastVal = LeanTween.val;
									}
								}
								else if (LeanTween.tweenAction == TweenAction.ALPHA)
								{
									SpriteRenderer component3 = LeanTween.trans.gameObject.GetComponent<SpriteRenderer>();
									if (component3 != null)
									{
										component3.color = new Color(component3.color.r, component3.color.g, component3.color.b, LeanTween.val);
									}
									else
									{
										if (LeanTween.trans.gameObject.GetComponent<Renderer>() != null)
										{
											Material[] materials = LeanTween.trans.gameObject.GetComponent<Renderer>().materials;
											for (int i = 0; i < materials.Length; i++)
											{
												materials[i].color = new Color(materials[i].color.r, materials[i].color.g, materials[i].color.b, LeanTween.val);
											}
										}
										if (LeanTween.trans.childCount > 0)
										{
											for (int j = 0; j < LeanTween.trans.childCount; j++)
											{
												Transform child = LeanTween.trans.GetChild(j);
												if (child.gameObject.GetComponent<Renderer>() != null)
												{
													Material[] materials2 = LeanTween.trans.gameObject.GetComponent<Renderer>().materials;
													for (int k = 0; k < materials2.Length; k++)
													{
														materials2[k].color = new Color(materials2[k].color.r, materials2[k].color.g, materials2[k].color.b, LeanTween.val);
													}
												}
											}
										}
									}
								}
								else if (LeanTween.tweenAction == TweenAction.ALPHA_VERTEX)
								{
									Mesh mesh = LeanTween.trans.GetComponent<MeshFilter>().mesh;
									Vector3[] vertices = mesh.vertices;
									Color32[] array = new Color32[vertices.Length];
									Color32 color2 = mesh.colors32[0];
									color2 = new Color((float)color2.r, (float)color2.g, (float)color2.b, LeanTween.val);
									for (int l = 0; l < vertices.Length; l++)
									{
										array[l] = color2;
									}
									mesh.colors32 = array;
								}
								else if (LeanTween.tweenAction == TweenAction.COLOR || LeanTween.tweenAction == TweenAction.CALLBACK_COLOR)
								{
									Color color3 = LeanTween.tweenColor(LeanTween.tween, LeanTween.val);
									if (LeanTween.tweenAction == TweenAction.COLOR)
									{
										if (LeanTween.trans.gameObject.GetComponent<Renderer>() != null)
										{
											Material[] materials3 = LeanTween.trans.gameObject.GetComponent<Renderer>().materials;
											for (int m = 0; m < materials3.Length; m++)
											{
												materials3[m].color = color3;
											}
										}
									}
									else if (LeanTween.tweenAction == TweenAction.CALLBACK_COLOR)
									{
										LeanTween.tween.onUpdateColor(color3);
									}
								}
							}
							else if (LeanTween.tweenAction >= TweenAction.MOVE)
							{
								if (LeanTween.tween.animationCurve != null)
								{
									LeanTween.newVect = LeanTween.tweenOnCurveVector(LeanTween.tween, LeanTween.ratioPassed);
								}
								else if (LeanTween.tween.tweenType == LeanTweenType.linear)
								{
									LeanTween.newVect = new Vector3(LeanTween.tween.from.x + LeanTween.tween.diff.x * LeanTween.ratioPassed, LeanTween.tween.from.y + LeanTween.tween.diff.y * LeanTween.ratioPassed, LeanTween.tween.from.z + LeanTween.tween.diff.z * LeanTween.ratioPassed);
								}
								else if (LeanTween.tween.tweenType >= LeanTweenType.linear)
								{
									switch (LeanTween.tween.tweenType)
									{
									case LeanTweenType.easeOutQuad:
										LeanTween.newVect = new Vector3(LeanTween.easeOutQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed), LeanTween.easeOutQuadOpt(LeanTween.tween.from.y, LeanTween.tween.diff.y, LeanTween.ratioPassed), LeanTween.easeOutQuadOpt(LeanTween.tween.from.z, LeanTween.tween.diff.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInQuad:
										LeanTween.newVect = new Vector3(LeanTween.easeInQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed), LeanTween.easeInQuadOpt(LeanTween.tween.from.y, LeanTween.tween.diff.y, LeanTween.ratioPassed), LeanTween.easeInQuadOpt(LeanTween.tween.from.z, LeanTween.tween.diff.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInOutQuad:
										LeanTween.newVect = new Vector3(LeanTween.easeInOutQuadOpt(LeanTween.tween.from.x, LeanTween.tween.diff.x, LeanTween.ratioPassed), LeanTween.easeInOutQuadOpt(LeanTween.tween.from.y, LeanTween.tween.diff.y, LeanTween.ratioPassed), LeanTween.easeInOutQuadOpt(LeanTween.tween.from.z, LeanTween.tween.diff.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInCubic:
										LeanTween.newVect = new Vector3(LeanTween.easeInCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInCubic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInCubic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeOutCubic:
										LeanTween.newVect = new Vector3(LeanTween.easeOutCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeOutCubic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeOutCubic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInOutCubic:
										LeanTween.newVect = new Vector3(LeanTween.easeInOutCubic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInOutCubic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInOutCubic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInQuart:
										LeanTween.newVect = new Vector3(LeanTween.easeInQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInQuart(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInQuart(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeOutQuart:
										LeanTween.newVect = new Vector3(LeanTween.easeOutQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeOutQuart(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeOutQuart(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInOutQuart:
										LeanTween.newVect = new Vector3(LeanTween.easeInOutQuart(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInOutQuart(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInOutQuart(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInQuint:
										LeanTween.newVect = new Vector3(LeanTween.easeInQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInQuint(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInQuint(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeOutQuint:
										LeanTween.newVect = new Vector3(LeanTween.easeOutQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeOutQuint(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeOutQuint(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInOutQuint:
										LeanTween.newVect = new Vector3(LeanTween.easeInOutQuint(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInOutQuint(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInOutQuint(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInSine:
										LeanTween.newVect = new Vector3(LeanTween.easeInSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInSine(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInSine(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeOutSine:
										LeanTween.newVect = new Vector3(LeanTween.easeOutSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeOutSine(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeOutSine(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInOutSine:
										LeanTween.newVect = new Vector3(LeanTween.easeInOutSine(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInOutSine(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInOutSine(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInExpo:
										LeanTween.newVect = new Vector3(LeanTween.easeInExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInExpo(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInExpo(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeOutExpo:
										LeanTween.newVect = new Vector3(LeanTween.easeOutExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeOutExpo(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeOutExpo(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInOutExpo:
										LeanTween.newVect = new Vector3(LeanTween.easeInOutExpo(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInOutExpo(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInOutExpo(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInCirc:
										LeanTween.newVect = new Vector3(LeanTween.easeInCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInCirc(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInCirc(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeOutCirc:
										LeanTween.newVect = new Vector3(LeanTween.easeOutCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeOutCirc(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeOutCirc(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInOutCirc:
										LeanTween.newVect = new Vector3(LeanTween.easeInOutCirc(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInOutCirc(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInOutCirc(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInBounce:
										LeanTween.newVect = new Vector3(LeanTween.easeInBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInBounce(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInBounce(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeOutBounce:
										LeanTween.newVect = new Vector3(LeanTween.easeOutBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeOutBounce(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeOutBounce(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInOutBounce:
										LeanTween.newVect = new Vector3(LeanTween.easeInOutBounce(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInOutBounce(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInOutBounce(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInBack:
										LeanTween.newVect = new Vector3(LeanTween.easeInBack(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInBack(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInBack(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeOutBack:
										LeanTween.newVect = new Vector3(LeanTween.easeOutBack(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeOutBack(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeOutBack(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInOutBack:
										LeanTween.newVect = new Vector3(LeanTween.easeInOutBack(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInOutBack(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInOutBack(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInElastic:
										LeanTween.newVect = new Vector3(LeanTween.easeInElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInElastic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInElastic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeOutElastic:
										LeanTween.newVect = new Vector3(LeanTween.easeOutElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeOutElastic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeOutElastic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeInOutElastic:
										LeanTween.newVect = new Vector3(LeanTween.easeInOutElastic(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.easeInOutElastic(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.easeInOutElastic(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeSpring:
										LeanTween.newVect = new Vector3(LeanTween.spring(LeanTween.tween.from.x, LeanTween.tween.to.x, LeanTween.ratioPassed), LeanTween.spring(LeanTween.tween.from.y, LeanTween.tween.to.y, LeanTween.ratioPassed), LeanTween.spring(LeanTween.tween.from.z, LeanTween.tween.to.z, LeanTween.ratioPassed));
										break;
									case LeanTweenType.easeShake:
									case LeanTweenType.punch:
										if (LeanTween.tween.tweenType == LeanTweenType.punch)
										{
											LeanTween.tween.animationCurve = LeanTween.punch;
										}
										else if (LeanTween.tween.tweenType == LeanTweenType.easeShake)
										{
											LeanTween.tween.animationCurve = LeanTween.shake;
										}
										LeanTween.tween.to = LeanTween.tween.from + LeanTween.tween.to;
										LeanTween.tween.diff = LeanTween.tween.to - LeanTween.tween.from;
										if (LeanTween.tweenAction == TweenAction.ROTATE || LeanTween.tweenAction == TweenAction.ROTATE_LOCAL)
										{
											LeanTween.tween.to = new Vector3(LeanTween.closestRot(LeanTween.tween.from.x, LeanTween.tween.to.x), LeanTween.closestRot(LeanTween.tween.from.y, LeanTween.tween.to.y), LeanTween.closestRot(LeanTween.tween.from.z, LeanTween.tween.to.z));
										}
										LeanTween.newVect = LeanTween.tweenOnCurveVector(LeanTween.tween, LeanTween.ratioPassed);
										break;
									}
								}
								else
								{
									LeanTween.newVect = new Vector3(LeanTween.tween.from.x + LeanTween.tween.diff.x * LeanTween.ratioPassed, LeanTween.tween.from.y + LeanTween.tween.diff.y * LeanTween.ratioPassed, LeanTween.tween.from.z + LeanTween.tween.diff.z * LeanTween.ratioPassed);
								}
								if (LeanTween.tweenAction == TweenAction.MOVE)
								{
									LeanTween.trans.position = LeanTween.newVect;
								}
								else if (LeanTween.tweenAction == TweenAction.MOVE_LOCAL)
								{
									LeanTween.trans.localPosition = LeanTween.newVect;
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE)
								{
									LeanTween.trans.eulerAngles = LeanTween.newVect;
								}
								else if (LeanTween.tweenAction == TweenAction.ROTATE_LOCAL)
								{
									LeanTween.trans.localEulerAngles = LeanTween.newVect;
								}
								else if (LeanTween.tweenAction == TweenAction.SCALE)
								{
									LeanTween.trans.localScale = LeanTween.newVect;
								}
								else if (LeanTween.tweenAction == TweenAction.GUI_MOVE)
								{
									LeanTween.tween.ltRect.rect = new Rect(LeanTween.newVect.x, LeanTween.newVect.y, LeanTween.tween.ltRect.rect.width, LeanTween.tween.ltRect.rect.height);
								}
								else if (LeanTween.tweenAction == TweenAction.GUI_MOVE_MARGIN)
								{
									LeanTween.tween.ltRect.margin = new Vector2(LeanTween.newVect.x, LeanTween.newVect.y);
								}
								else if (LeanTween.tweenAction == TweenAction.GUI_SCALE)
								{
									LeanTween.tween.ltRect.rect = new Rect(LeanTween.tween.ltRect.rect.x, LeanTween.tween.ltRect.rect.y, LeanTween.newVect.x, LeanTween.newVect.y);
								}
								else if (LeanTween.tweenAction == TweenAction.GUI_ALPHA)
								{
									LeanTween.tween.ltRect.alpha = LeanTween.newVect.x;
								}
								else if (LeanTween.tweenAction == TweenAction.GUI_ROTATE)
								{
									LeanTween.tween.ltRect.rotation = LeanTween.newVect.x;
								}
							}
							if (LeanTween.tween.onUpdateFloat != null)
							{
								LeanTween.tween.onUpdateFloat(LeanTween.val);
							}
							else if (LeanTween.tween.onUpdateFloatObject != null)
							{
								LeanTween.tween.onUpdateFloatObject(LeanTween.val, LeanTween.tween.onUpdateParam);
							}
							else if (LeanTween.tween.onUpdateVector3Object != null)
							{
								LeanTween.tween.onUpdateVector3Object(LeanTween.newVect, LeanTween.tween.onUpdateParam);
							}
							else if (LeanTween.tween.onUpdateVector3 != null)
							{
								LeanTween.tween.onUpdateVector3(LeanTween.newVect);
							}
							else if (LeanTween.tween.optional != null)
							{
								object obj = LeanTween.tween.optional["onUpdate"];
								if (obj != null)
								{
									Hashtable arg = (Hashtable)LeanTween.tween.optional["onUpdateParam"];
									if (LeanTween.tweenAction == TweenAction.VALUE3)
									{
										if (obj.GetType() == typeof(string))
										{
											string methodName = obj as string;
											LeanTween.customTarget = ((LeanTween.tween.optional["onUpdateTarget"] == null) ? LeanTween.trans.gameObject : (LeanTween.tween.optional["onUpdateTarget"] as GameObject));
											LeanTween.customTarget.BroadcastMessage(methodName, LeanTween.newVect, SendMessageOptions.DontRequireReceiver);
										}
										else if (obj.GetType() == typeof(Action<Vector3, Hashtable>))
										{
											Action<Vector3, Hashtable> action = (Action<Vector3, Hashtable>)obj;
											action(LeanTween.newVect, arg);
										}
										else
										{
											Action<Vector3> action2 = (Action<Vector3>)obj;
											action2(LeanTween.newVect);
										}
									}
									else if (obj.GetType() == typeof(string))
									{
										string methodName2 = obj as string;
										if (LeanTween.tween.optional["onUpdateTarget"] != null)
										{
											LeanTween.customTarget = (LeanTween.tween.optional["onUpdateTarget"] as GameObject);
											LeanTween.customTarget.BroadcastMessage(methodName2, LeanTween.val, SendMessageOptions.DontRequireReceiver);
										}
										else
										{
											LeanTween.trans.gameObject.BroadcastMessage(methodName2, LeanTween.val, SendMessageOptions.DontRequireReceiver);
										}
									}
									else if (obj.GetType() == typeof(Action<float, Hashtable>))
									{
										Action<float, Hashtable> action3 = (Action<float, Hashtable>)obj;
										action3(LeanTween.val, arg);
									}
									else if (obj.GetType() == typeof(Action<Vector3>))
									{
										Action<Vector3> action4 = (Action<Vector3>)obj;
										action4(LeanTween.newVect);
									}
									else
									{
										Action<float> action5 = (Action<float>)obj;
										action5(LeanTween.val);
									}
								}
							}
						}
						if (LeanTween.isTweenFinished)
						{
							if (LeanTween.tweenAction == TweenAction.GUI_ROTATE)
							{
								LeanTween.tween.ltRect.rotateFinished = true;
							}
							if (LeanTween.tween.loopType == LeanTweenType.once || LeanTween.tween.loopCount == 1)
							{
								if (LeanTween.tweenAction == TweenAction.DELAYED_SOUND)
								{
									AudioSource.PlayClipAtPoint((AudioClip)LeanTween.tween.onCompleteParam, LeanTween.tween.to, LeanTween.tween.from.x);
								}
								if (LeanTween.tween.onComplete != null)
								{
									LeanTween.removeTween(num);
									LeanTween.tween.onComplete();
								}
								else if (LeanTween.tween.onCompleteObject != null)
								{
									LeanTween.removeTween(num);
									LeanTween.tween.onCompleteObject(LeanTween.tween.onCompleteParam);
								}
								else if (LeanTween.tween.optional != null)
								{
									Action action6 = null;
									Action<object> action7 = null;
									string text = string.Empty;
									object obj2 = null;
									if (LeanTween.tween.optional != null && LeanTween.tween.trans && LeanTween.tween.optional["onComplete"] != null)
									{
										obj2 = LeanTween.tween.optional["onCompleteParam"];
										if (LeanTween.tween.optional["onComplete"].GetType() == typeof(string))
										{
											text = (LeanTween.tween.optional["onComplete"] as string);
										}
										else if (obj2 != null)
										{
											action7 = (Action<object>)LeanTween.tween.optional["onComplete"];
										}
										else
										{
											action6 = (Action)LeanTween.tween.optional["onComplete"];
											if (action6 == null)
											{
												Debug.LogWarning("callback was not converted");
											}
										}
									}
									LeanTween.removeTween(num);
									if (action7 != null)
									{
										action7(obj2);
									}
									else if (action6 != null)
									{
										action6();
									}
									else if (text != string.Empty)
									{
										if (LeanTween.tween.optional["onCompleteTarget"] != null)
										{
											LeanTween.customTarget = (LeanTween.tween.optional["onCompleteTarget"] as GameObject);
											if (obj2 != null)
											{
												LeanTween.customTarget.BroadcastMessage(text, obj2, SendMessageOptions.DontRequireReceiver);
											}
											else
											{
												LeanTween.customTarget.BroadcastMessage(text, SendMessageOptions.DontRequireReceiver);
											}
										}
										else if (obj2 != null)
										{
											LeanTween.trans.gameObject.BroadcastMessage(text, obj2, SendMessageOptions.DontRequireReceiver);
										}
										else
										{
											LeanTween.trans.gameObject.BroadcastMessage(text, SendMessageOptions.DontRequireReceiver);
										}
									}
								}
								else
								{
									LeanTween.removeTween(num);
								}
							}
							else
							{
								if ((LeanTween.tween.loopCount < 0 && LeanTween.tween.type == TweenAction.CALLBACK) || LeanTween.tween.onCompleteOnRepeat)
								{
									if (LeanTween.tweenAction == TweenAction.DELAYED_SOUND)
									{
										AudioSource.PlayClipAtPoint((AudioClip)LeanTween.tween.onCompleteParam, LeanTween.tween.to, LeanTween.tween.from.x);
									}
									if (LeanTween.tween.onComplete != null)
									{
										LeanTween.tween.onComplete();
									}
									else if (LeanTween.tween.onCompleteObject != null)
									{
										LeanTween.tween.onCompleteObject(LeanTween.tween.onCompleteParam);
									}
								}
								if (LeanTween.tween.loopCount >= 1)
								{
									LeanTween.tween.loopCount--;
								}
								if (LeanTween.tween.loopType == LeanTweenType.clamp)
								{
									LeanTween.tween.passed = Mathf.Epsilon;
								}
								else if (LeanTween.tween.loopType == LeanTweenType.pingPong)
								{
									LeanTween.tween.direction = 0f - LeanTween.tween.direction;
								}
							}
						}
						else if (LeanTween.tween.delay <= 0f)
						{
							LeanTween.tween.passed += LeanTween.dt * LeanTween.tween.direction;
						}
						else
						{
							LeanTween.tween.delay -= LeanTween.dt;
							if (LeanTween.tween.delay < 0f)
							{
								LeanTween.tween.passed = 0f;
								LeanTween.tween.delay = 0f;
							}
						}
					}
				}
				num++;
			}
			LeanTween.frameRendered = Time.frameCount;
		}
	}

	private static Color tweenColor(LTDescr tween, float val)
	{
		Vector3 vector = tween.point - tween.axis;
		float num = tween.to.y - tween.from.y;
		return new Color(tween.axis.x + vector.x * val, tween.axis.y + vector.y * val, tween.axis.z + vector.z * val, tween.from.y + num * val);
	}

	public static void removeTween(int i)
	{
		if (LeanTween.tweens[i].toggle)
		{
			LeanTween.tweens[i].toggle = false;
			if (LeanTween.tweens[i].destroyOnComplete && LeanTween.tweens[i].ltRect != null)
			{
				LTGUI.destroy(LeanTween.tweens[i].ltRect.id);
			}
			LeanTween.startSearch = i;
			if (i + 1 >= LeanTween.tweenMaxSearch)
			{
				LeanTween.startSearch = 0;
				LeanTween.tweenMaxSearch--;
			}
		}
	}

	public static Vector3[] add(Vector3[] a, Vector3 b)
	{
		Vector3[] array = new Vector3[a.Length];
		LeanTween.i = 0;
		while (LeanTween.i < a.Length)
		{
			array[LeanTween.i] = a[LeanTween.i] + b;
			LeanTween.i++;
		}
		return array;
	}

	public static float closestRot(float from, float to)
	{
		float num = 0f - (360f - to);
		float num2 = 360f + to;
		float num3 = Mathf.Abs(to - from);
		float num4 = Mathf.Abs(num - from);
		float num5 = Mathf.Abs(num2 - from);
		if (num3 < num4 && num3 < num5)
		{
			return to;
		}
		if (num4 < num5)
		{
			return num;
		}
		return num2;
	}

	public static void cancel(GameObject gameObject)
	{
		LeanTween.init();
		Transform transform = gameObject.transform;
		for (int i = 0; i < LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].trans == transform)
			{
				LeanTween.removeTween(i);
			}
		}
	}

	public static void cancel(GameObject gameObject, int uniqueId)
	{
		if (uniqueId >= 0)
		{
			LeanTween.init();
			int num = uniqueId & 65535;
			int num2 = uniqueId >> 16;
			if (LeanTween.tweens[num].trans == null || (LeanTween.tweens[num].trans.gameObject == gameObject && (ulong)LeanTween.tweens[num].counter == (ulong)((long)num2)))
			{
				LeanTween.removeTween(num);
			}
		}
	}

	public static void cancel(LTRect ltRect, int uniqueId)
	{
		if (uniqueId >= 0)
		{
			LeanTween.init();
			int num = uniqueId & 65535;
			int num2 = uniqueId >> 16;
			if (LeanTween.tweens[num].ltRect == ltRect && (ulong)LeanTween.tweens[num].counter == (ulong)((long)num2))
			{
				LeanTween.removeTween(num);
			}
		}
	}

	private static void cancel(int uniqueId)
	{
		if (uniqueId >= 0)
		{
			LeanTween.init();
			int num = uniqueId & 65535;
			int num2 = uniqueId >> 16;
			if (LeanTween.tweens[num].hasInitiliazed && (ulong)LeanTween.tweens[num].counter == (ulong)((long)num2))
			{
				LeanTween.removeTween(num);
			}
		}
	}

	public static LTDescr description(int uniqueId)
	{
		int num = uniqueId & 65535;
		int num2 = uniqueId >> 16;
		if (LeanTween.tweens[num] != null && LeanTween.tweens[num].uniqueId == uniqueId && (ulong)LeanTween.tweens[num].counter == (ulong)((long)num2))
		{
			return LeanTween.tweens[num];
		}
		for (int i = 0; i < LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].uniqueId == uniqueId && (ulong)LeanTween.tweens[i].counter == (ulong)((long)num2))
			{
				return LeanTween.tweens[i];
			}
		}
		return null;
	}

	[Obsolete("Use 'pause( id )' instead")]
	public static void pause(GameObject gameObject, int uniqueId)
	{
		LeanTween.pause(uniqueId);
	}

	public static void pause(int uniqueId)
	{
		int num = uniqueId & 65535;
		int num2 = uniqueId >> 16;
		if ((ulong)LeanTween.tweens[num].counter == (ulong)((long)num2))
		{
			LeanTween.tweens[num].pause();
		}
	}

	public static void pause(GameObject gameObject)
	{
		Transform transform = gameObject.transform;
		for (int i = 0; i < LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].trans == transform)
			{
				LeanTween.tweens[i].pause();
			}
		}
	}

	[Obsolete("Use 'resume( id )' instead")]
	public static void resume(GameObject gameObject, int uniqueId)
	{
		LeanTween.resume(uniqueId);
	}

	public static void resume(int uniqueId)
	{
		int num = uniqueId & 65535;
		int num2 = uniqueId >> 16;
		if ((ulong)LeanTween.tweens[num].counter == (ulong)((long)num2))
		{
			LeanTween.tweens[num].resume();
		}
	}

	public static void resume(GameObject gameObject)
	{
		Transform transform = gameObject.transform;
		for (int i = 0; i < LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].trans == transform)
			{
				LeanTween.tweens[i].resume();
			}
		}
	}

	public static bool isTweening(GameObject gameObject)
	{
		Transform transform = gameObject.transform;
		for (int i = 0; i < LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].toggle && LeanTween.tweens[i].trans == transform)
			{
				return true;
			}
		}
		return false;
	}

	public static bool isTweening(int uniqueId)
	{
		int num = uniqueId & 65535;
		int num2 = uniqueId >> 16;
		return num >= 0 && num < LeanTween.maxTweens && ((ulong)LeanTween.tweens[num].counter == (ulong)((long)num2) && LeanTween.tweens[num].toggle);
	}

	public static bool isTweening(LTRect ltRect)
	{
		for (int i = 0; i < LeanTween.tweenMaxSearch; i++)
		{
			if (LeanTween.tweens[i].toggle && LeanTween.tweens[i].ltRect == ltRect)
			{
				return true;
			}
		}
		return false;
	}

	public static void drawBezierPath(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
	{
		Vector3 vector = a;
		Vector3 a2 = -a + 3f * (b - c) + d;
		Vector3 b2 = 3f * (a + c) - 6f * b;
		Vector3 b3 = 3f * (b - a);
		for (float num = 1f; num <= 30f; num += 1f)
		{
			float d2 = num / 30f;
			Vector3 vector2 = ((a2 * d2 + b2) * d2 + b3) * d2 + a;
			Gizmos.DrawLine(vector, vector2);
			vector = vector2;
		}
	}

	public static object logError(string error)
	{
		if (LeanTween.throwErrors)
		{
			Debug.LogError(error);
		}
		else
		{
			Debug.Log(error);
		}
		return null;
	}

	public static LTDescr options(LTDescr seed)
	{
		Debug.LogError("error this function is no longer used");
		return null;
	}

	public static LTDescr options()
	{
		LeanTween.init();
		LeanTween.j = 0;
		LeanTween.i = LeanTween.startSearch;
		while (LeanTween.j < LeanTween.maxTweens)
		{
			if (LeanTween.i >= LeanTween.maxTweens - 1)
			{
				LeanTween.i = 0;
			}
			if (!LeanTween.tweens[LeanTween.i].toggle)
			{
				if (LeanTween.i + 1 > LeanTween.tweenMaxSearch)
				{
					LeanTween.tweenMaxSearch = LeanTween.i + 1;
				}
				LeanTween.startSearch = LeanTween.i + 1;
				break;
			}
			LeanTween.j++;
			if (LeanTween.j >= LeanTween.maxTweens)
			{
				return LeanTween.logError("LeanTween - You have run out of available spaces for tweening. To avoid this error increase the number of spaces to available for tweening when you initialize the LeanTween class ex: LeanTween.init( " + LeanTween.maxTweens * 2 + " );") as LTDescr;
			}
			LeanTween.i++;
		}
		LeanTween.tween = LeanTween.tweens[LeanTween.i];
		LeanTween.tween.reset();
		LeanTween.tween.setId((uint)LeanTween.i);
		return LeanTween.tween;
	}

	private static LTDescr pushNewTween(GameObject gameObject, Vector3 to, float time, TweenAction tweenAction, LTDescr tween)
	{
		LeanTween.init(LeanTween.maxTweens);
		if (gameObject == null)
		{
			return null;
		}
		tween.trans = gameObject.transform;
		tween.to = to;
		tween.time = time;
		tween.type = tweenAction;
		return tween;
	}

	public static LTDescr alpha(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ALPHA, LeanTween.options());
	}

	public static LTDescr alpha(LTRect ltRect, float to, float time)
	{
		ltRect.alphaEnabled = true;
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, new Vector3(to, 0f, 0f), time, TweenAction.GUI_ALPHA, LeanTween.options().setRect(ltRect));
	}

	public static LTDescr alphaVertex(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ALPHA_VERTEX, LeanTween.options());
	}

	public static LTDescr color(GameObject gameObject, Color to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, to.a, 0f), time, TweenAction.COLOR, LeanTween.options().setPoint(new Vector3(to.r, to.g, to.b)));
	}

	public static LTDescr delayedCall(float delayTime, Action callback)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, Vector3.zero, delayTime, TweenAction.CALLBACK, LeanTween.options().setOnComplete(callback));
	}

	public static LTDescr delayedCall(float delayTime, Action<object> callback)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, Vector3.zero, delayTime, TweenAction.CALLBACK, LeanTween.options().setOnComplete(callback));
	}

	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action callback)
	{
		return LeanTween.pushNewTween(gameObject, Vector3.zero, delayTime, TweenAction.CALLBACK, LeanTween.options().setOnComplete(callback));
	}

	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action<object> callback)
	{
		return LeanTween.pushNewTween(gameObject, Vector3.zero, delayTime, TweenAction.CALLBACK, LeanTween.options().setOnComplete(callback));
	}

	public static LTDescr destroyAfter(LTRect rect, float delayTime)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, Vector3.zero, delayTime, TweenAction.CALLBACK, LeanTween.options().setRect(rect).setDestroyOnComplete(true));
	}

	public static LTDescr move(GameObject gameObject, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.MOVE, LeanTween.options());
	}

	public static LTDescr move(GameObject gameObject, Vector2 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to.x, to.y, gameObject.transform.position.z), time, TweenAction.MOVE, LeanTween.options());
	}

	public static LTDescr move(GameObject gameObject, Vector3[] to, float time)
	{
		LeanTween.descr = LeanTween.options();
		if (LeanTween.descr.path == null)
		{
			LeanTween.descr.path = new LTBezierPath(to);
		}
		else
		{
			LeanTween.descr.path.setPoints(to);
		}
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, 0f, 0f), time, TweenAction.MOVE_CURVED, LeanTween.descr);
	}

	public static LTDescr moveSpline(GameObject gameObject, Vector3[] to, float time)
	{
		LeanTween.descr = LeanTween.options();
		LeanTween.descr.spline = new LTSpline(to);
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, 0f, 0f), time, TweenAction.MOVE_SPLINE, LeanTween.descr);
	}

	public static LTDescr moveSplineLocal(GameObject gameObject, Vector3[] to, float time)
	{
		LeanTween.descr = LeanTween.options();
		LeanTween.descr.spline = new LTSpline(to);
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, 0f, 0f), time, TweenAction.MOVE_SPLINE_LOCAL, LeanTween.descr);
	}

	public static LTDescr move(LTRect ltRect, Vector2 to, float time)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, to, time, TweenAction.GUI_MOVE, LeanTween.options().setRect(ltRect));
	}

	public static LTDescr moveMargin(LTRect ltRect, Vector2 to, float time)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, to, time, TweenAction.GUI_MOVE_MARGIN, LeanTween.options().setRect(ltRect));
	}

	public static LTDescr moveX(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_X, LeanTween.options());
	}

	public static LTDescr moveY(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_Y, LeanTween.options());
	}

	public static LTDescr moveZ(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_Z, LeanTween.options());
	}

	public static LTDescr moveLocal(GameObject gameObject, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.MOVE_LOCAL, LeanTween.options());
	}

	public static LTDescr moveLocal(GameObject gameObject, Vector3[] to, float time)
	{
		LeanTween.descr = LeanTween.options();
		if (LeanTween.descr.path == null)
		{
			LeanTween.descr.path = new LTBezierPath(to);
		}
		else
		{
			LeanTween.descr.path.setPoints(to);
		}
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, 0f, 0f), time, TweenAction.MOVE_CURVED_LOCAL, LeanTween.descr);
	}

	public static LTDescr moveLocalX(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_LOCAL_X, LeanTween.options());
	}

	public static LTDescr moveLocalY(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_LOCAL_Y, LeanTween.options());
	}

	public static LTDescr moveLocalZ(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_LOCAL_Z, LeanTween.options());
	}

	public static LTDescr rotate(GameObject gameObject, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.ROTATE, LeanTween.options());
	}

	public static LTDescr rotate(LTRect ltRect, float to, float time)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, new Vector3(to, 0f, 0f), time, TweenAction.GUI_ROTATE, LeanTween.options().setRect(ltRect));
	}

	public static LTDescr rotateLocal(GameObject gameObject, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.ROTATE_LOCAL, LeanTween.options());
	}

	public static LTDescr rotateX(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ROTATE_X, LeanTween.options());
	}

	public static LTDescr rotateY(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ROTATE_Y, LeanTween.options());
	}

	public static LTDescr rotateZ(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ROTATE_Z, LeanTween.options());
	}

	public static LTDescr rotateAround(GameObject gameObject, Vector3 axis, float add, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(add, 0f, 0f), time, TweenAction.ROTATE_AROUND, LeanTween.options().setAxis(axis));
	}

	public static LTDescr rotateAroundLocal(GameObject gameObject, Vector3 axis, float add, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(add, 0f, 0f), time, TweenAction.ROTATE_AROUND_LOCAL, LeanTween.options().setAxis(axis));
	}

	public static LTDescr scale(GameObject gameObject, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.SCALE, LeanTween.options());
	}

	public static LTDescr scale(LTRect ltRect, Vector2 to, float time)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, to, time, TweenAction.GUI_SCALE, LeanTween.options().setRect(ltRect));
	}

	public static LTDescr scaleX(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.SCALE_X, LeanTween.options());
	}

	public static LTDescr scaleY(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.SCALE_Y, LeanTween.options());
	}

	public static LTDescr scaleZ(GameObject gameObject, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.SCALE_Z, LeanTween.options());
	}

	public static LTDescr value(GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CALLBACK, LeanTween.options().setTo(new Vector3(to, 0f, 0f)).setFrom(new Vector3(from, 0f, 0f)).setOnUpdate(callOnUpdate));
	}

	public static LTDescr value(GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, to.a, 0f), time, TweenAction.CALLBACK_COLOR, LeanTween.options().setPoint(new Vector3(to.r, to.g, to.b)).setAxis(new Vector3(from.r, from.g, from.b)).setFrom(new Vector3(0f, from.a, 0f)).setHasInitialized(false).setOnUpdateColor(callOnUpdate));
	}

	public static LTDescr value(GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.VALUE3, LeanTween.options().setTo(to).setFrom(from).setOnUpdateVector3(callOnUpdate));
	}

	public static LTDescr value(GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CALLBACK, LeanTween.options().setTo(new Vector3(to, 0f, 0f)).setFrom(new Vector3(from, 0f, 0f)).setOnUpdateObject(callOnUpdate));
	}

	public static LTDescr delayedSound(AudioClip audio, Vector3 pos, float volume)
	{
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, pos, 0f, TweenAction.DELAYED_SOUND, LeanTween.options().setTo(pos).setFrom(new Vector3(volume, 0f, 0f)).setAudio(audio));
	}

	public static Hashtable h(object[] arr)
	{
		if (arr.Length % 2 == 1)
		{
			LeanTween.logError("LeanTween - You have attempted to create a Hashtable with an odd number of values.");
			return null;
		}
		Hashtable hashtable = new Hashtable();
		LeanTween.i = 0;
		while (LeanTween.i < arr.Length)
		{
			hashtable.Add(arr[LeanTween.i] as string, arr[LeanTween.i + 1]);
			LeanTween.i += 2;
		}
		return hashtable;
	}

	private static int idFromUnique(int uniqueId)
	{
		return uniqueId & 65535;
	}

	private static int pushNewTween(GameObject gameObject, Vector3 to, float time, TweenAction tweenAction, Hashtable optional)
	{
		LeanTween.init(LeanTween.maxTweens);
		if (gameObject == null)
		{
			return -1;
		}
		LeanTween.j = 0;
		LeanTween.i = LeanTween.startSearch;
		while (LeanTween.j < LeanTween.maxTweens)
		{
			if (LeanTween.i >= LeanTween.maxTweens - 1)
			{
				LeanTween.i = 0;
			}
			if (!LeanTween.tweens[LeanTween.i].toggle)
			{
				if (LeanTween.i + 1 > LeanTween.tweenMaxSearch)
				{
					LeanTween.tweenMaxSearch = LeanTween.i + 1;
				}
				LeanTween.startSearch = LeanTween.i + 1;
				break;
			}
			LeanTween.j++;
			if (LeanTween.j >= LeanTween.maxTweens)
			{
				LeanTween.logError("LeanTween - You have run out of available spaces for tweening. To avoid this error increase the number of spaces to available for tweening when you initialize the LeanTween class ex: LeanTween.init( " + LeanTween.maxTweens * 2 + " );");
				return -1;
			}
			LeanTween.i++;
		}
		LeanTween.tween = LeanTween.tweens[LeanTween.i];
		LeanTween.tween.toggle = true;
		LeanTween.tween.reset();
		LeanTween.tween.trans = gameObject.transform;
		LeanTween.tween.to = to;
		LeanTween.tween.time = time;
		LeanTween.tween.type = tweenAction;
		LeanTween.tween.optional = optional;
		LeanTween.tween.setId((uint)LeanTween.i);
		if (optional != null)
		{
			object obj = optional["ease"];
			int num = 0;
			if (obj != null)
			{
				LeanTween.tween.tweenType = LeanTweenType.linear;
				if (obj.GetType() == typeof(LeanTweenType))
				{
					LeanTween.tween.tweenType = (LeanTweenType)((int)obj);
				}
				else if (obj.GetType() == typeof(AnimationCurve))
				{
					LeanTween.tween.animationCurve = (optional["ease"] as AnimationCurve);
				}
				else
				{
					string text = optional["ease"].ToString();
					if (text.Equals("easeOutQuad"))
					{
						LeanTween.tween.tweenType = LeanTweenType.easeOutQuad;
					}
					else if (text.Equals("easeInQuad"))
					{
						LeanTween.tween.tweenType = LeanTweenType.easeInQuad;
					}
					else if (text.Equals("easeInOutQuad"))
					{
						LeanTween.tween.tweenType = LeanTweenType.easeInOutQuad;
					}
				}
				num++;
			}
			if (optional["rect"] != null)
			{
				LeanTween.tween.ltRect = (LTRect)optional["rect"];
				num++;
			}
			if (optional["path"] != null)
			{
				LeanTween.tween.path = (LTBezierPath)optional["path"];
				num++;
			}
			if (optional["delay"] != null)
			{
				LeanTween.tween.delay = (float)optional["delay"];
				num++;
			}
			if (optional["useEstimatedTime"] != null)
			{
				LeanTween.tween.useEstimatedTime = (bool)optional["useEstimatedTime"];
				num++;
			}
			if (optional["useFrames"] != null)
			{
				LeanTween.tween.useFrames = (bool)optional["useFrames"];
				num++;
			}
			if (optional["loopType"] != null)
			{
				LeanTween.tween.loopType = (LeanTweenType)((int)optional["loopType"]);
				num++;
			}
			if (optional["repeat"] != null)
			{
				LeanTween.tween.loopCount = (int)optional["repeat"];
				if (LeanTween.tween.loopType == LeanTweenType.once)
				{
					LeanTween.tween.loopType = LeanTweenType.clamp;
				}
				num++;
			}
			if (optional["point"] != null)
			{
				LeanTween.tween.point = (Vector3)optional["point"];
				num++;
			}
			if (optional["axis"] != null)
			{
				LeanTween.tween.axis = (Vector3)optional["axis"];
				num++;
			}
			if (optional.Count <= num)
			{
				LeanTween.tween.optional = null;
			}
		}
		else
		{
			LeanTween.tween.optional = null;
		}
		return LeanTween.tweens[LeanTween.i].uniqueId;
	}

	public static int value(string callOnUpdate, float from, float to, float time, Hashtable optional)
	{
		return LeanTween.value(LeanTween.tweenEmpty, callOnUpdate, from, to, time, optional);
	}

	public static int value(GameObject gameObject, string callOnUpdate, float from, float to, float time)
	{
		return LeanTween.value(gameObject, callOnUpdate, from, to, time, new Hashtable());
	}

	public static int value(GameObject gameObject, string callOnUpdate, float from, float to, float time, object[] optional)
	{
		return LeanTween.value(gameObject, callOnUpdate, from, to, time, LeanTween.h(optional));
	}

	public static int value(GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time, object[] optional)
	{
		return LeanTween.value(gameObject, callOnUpdate, from, to, time, LeanTween.h(optional));
	}

	public static int value(GameObject gameObject, Action<float, Hashtable> callOnUpdate, float from, float to, float time, object[] optional)
	{
		return LeanTween.value(gameObject, callOnUpdate, from, to, time, LeanTween.h(optional));
	}

	public static int value(GameObject gameObject, string callOnUpdate, float from, float to, float time, Hashtable optional)
	{
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["onUpdate"] = callOnUpdate;
		int num = LeanTween.idFromUnique(LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CALLBACK, optional));
		LeanTween.tweens[num].from = new Vector3(from, 0f, 0f);
		return num;
	}

	public static int value(GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time, Hashtable optional)
	{
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["onUpdate"] = callOnUpdate;
		int num = LeanTween.idFromUnique(LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CALLBACK, optional));
		LeanTween.tweens[num].from = new Vector3(from, 0f, 0f);
		return num;
	}

	public static int value(GameObject gameObject, Action<float, Hashtable> callOnUpdate, float from, float to, float time, Hashtable optional)
	{
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["onUpdate"] = callOnUpdate;
		int num = LeanTween.idFromUnique(LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.CALLBACK, optional));
		LeanTween.tweens[num].from = new Vector3(from, 0f, 0f);
		return num;
	}

	public static int value(GameObject gameObject, string callOnUpdate, Vector3 from, Vector3 to, float time, Hashtable optional)
	{
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["onUpdate"] = callOnUpdate;
		int num = LeanTween.idFromUnique(LeanTween.pushNewTween(gameObject, to, time, TweenAction.VALUE3, optional));
		LeanTween.tweens[num].from = from;
		return num;
	}

	public static int value(GameObject gameObject, string callOnUpdate, Vector3 from, Vector3 to, float time, object[] optional)
	{
		return LeanTween.value(gameObject, callOnUpdate, from, to, time, LeanTween.h(optional));
	}

	public static int value(GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time, Hashtable optional)
	{
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["onUpdate"] = callOnUpdate;
		int num = LeanTween.idFromUnique(LeanTween.pushNewTween(gameObject, to, time, TweenAction.VALUE3, optional));
		LeanTween.tweens[num].from = from;
		return num;
	}

	public static int value(GameObject gameObject, Action<Vector3, Hashtable> callOnUpdate, Vector3 from, Vector3 to, float time, Hashtable optional)
	{
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["onUpdate"] = callOnUpdate;
		int num = LeanTween.idFromUnique(LeanTween.pushNewTween(gameObject, to, time, TweenAction.VALUE3, optional));
		LeanTween.tweens[num].from = from;
		return num;
	}

	public static int value(GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time, object[] optional)
	{
		return LeanTween.value(gameObject, callOnUpdate, from, to, time, LeanTween.h(optional));
	}

	public static int value(GameObject gameObject, Action<Vector3, Hashtable> callOnUpdate, Vector3 from, Vector3 to, float time, object[] optional)
	{
		return LeanTween.value(gameObject, callOnUpdate, from, to, time, LeanTween.h(optional));
	}

	public static int rotate(GameObject gameObject, Vector3 to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.ROTATE, optional);
	}

	public static int rotate(GameObject gameObject, Vector3 to, float time, object[] optional)
	{
		return LeanTween.rotate(gameObject, to, time, LeanTween.h(optional));
	}

	public static int rotate(LTRect ltRect, float to, float time, Hashtable optional)
	{
		LeanTween.init();
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["rect"] = ltRect;
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, new Vector3(to, 0f, 0f), time, TweenAction.GUI_ROTATE, optional);
	}

	public static int rotate(LTRect ltRect, float to, float time, object[] optional)
	{
		return LeanTween.rotate(ltRect, to, time, LeanTween.h(optional));
	}

	public static int rotateX(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ROTATE_X, optional);
	}

	public static int rotateX(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.rotateX(gameObject, to, time, LeanTween.h(optional));
	}

	public static int rotateY(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ROTATE_Y, optional);
	}

	public static int rotateY(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.rotateY(gameObject, to, time, LeanTween.h(optional));
	}

	public static int rotateZ(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ROTATE_Z, optional);
	}

	public static int rotateZ(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.rotateZ(gameObject, to, time, LeanTween.h(optional));
	}

	public static int rotateLocal(GameObject gameObject, Vector3 to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.ROTATE_LOCAL, optional);
	}

	public static int rotateLocal(GameObject gameObject, Vector3 to, float time, object[] optional)
	{
		return LeanTween.rotateLocal(gameObject, to, time, LeanTween.h(optional));
	}

	public static int rotateAround(GameObject gameObject, Vector3 axis, float add, float time, Hashtable optional)
	{
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["axis"] = axis;
		if (optional["point"] == null)
		{
			optional["point"] = Vector3.zero;
		}
		return LeanTween.pushNewTween(gameObject, new Vector3(add, 0f, 0f), time, TweenAction.ROTATE_AROUND, optional);
	}

	public static int rotateAround(GameObject gameObject, Vector3 axis, float add, float time, object[] optional)
	{
		return LeanTween.rotateAround(gameObject, axis, add, time, LeanTween.h(optional));
	}

	public static int moveX(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_X, optional);
	}

	public static int moveX(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.moveX(gameObject, to, time, LeanTween.h(optional));
	}

	public static int moveY(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_Y, optional);
	}

	public static int moveY(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.moveY(gameObject, to, time, LeanTween.h(optional));
	}

	public static int moveZ(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_Z, optional);
	}

	public static int moveZ(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.moveZ(gameObject, to, time, LeanTween.h(optional));
	}

	public static int move(GameObject gameObject, Vector3 to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.MOVE, optional);
	}

	public static int move(GameObject gameObject, Vector3 to, float time, object[] optional)
	{
		return LeanTween.move(gameObject, to, time, LeanTween.h(optional));
	}

	public static int move(GameObject gameObject, Vector3[] to, float time, Hashtable optional)
	{
		if (to.Length < 4)
		{
			string message = "LeanTween - When passing values for a vector path, you must pass four or more values!";
			if (LeanTween.throwErrors)
			{
				Debug.LogError(message);
			}
			else
			{
				Debug.Log(message);
			}
			return -1;
		}
		if (to.Length % 4 != 0)
		{
			string message2 = "LeanTween - When passing values for a vector path, they must be in sets of four: controlPoint1, controlPoint2, endPoint2, controlPoint2, controlPoint2...";
			if (LeanTween.throwErrors)
			{
				Debug.LogError(message2);
			}
			else
			{
				Debug.Log(message2);
			}
			return -1;
		}
		LeanTween.init();
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		LTBezierPath lTBezierPath = new LTBezierPath(to);
		if (optional["orientToPath"] != null)
		{
			lTBezierPath.orientToPath = true;
		}
		optional["path"] = lTBezierPath;
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, 0f, 0f), time, TweenAction.MOVE_CURVED, optional);
	}

	public static int move(GameObject gameObject, Vector3[] to, float time, object[] optional)
	{
		return LeanTween.move(gameObject, to, time, LeanTween.h(optional));
	}

	public static int move(LTRect ltRect, Vector2 to, float time, Hashtable optional)
	{
		LeanTween.init();
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["rect"] = ltRect;
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, to, time, TweenAction.GUI_MOVE, optional);
	}

	public static int move(LTRect ltRect, Vector3 to, float time, object[] optional)
	{
		return LeanTween.move(ltRect, to, time, LeanTween.h(optional));
	}

	public static int moveLocal(GameObject gameObject, Vector3 to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.MOVE_LOCAL, optional);
	}

	public static int moveLocal(GameObject gameObject, Vector3 to, float time, object[] optional)
	{
		return LeanTween.moveLocal(gameObject, to, time, LeanTween.h(optional));
	}

	public static int moveLocal(GameObject gameObject, Vector3[] to, float time, Hashtable optional)
	{
		if (to.Length < 4)
		{
			string message = "LeanTween - When passing values for a vector path, you must pass four or more values!";
			if (LeanTween.throwErrors)
			{
				Debug.LogError(message);
			}
			else
			{
				Debug.Log(message);
			}
			return -1;
		}
		if (to.Length % 4 != 0)
		{
			string message2 = "LeanTween - When passing values for a vector path, they must be in sets of four: controlPoint1, controlPoint2, endPoint2, controlPoint2, controlPoint2...";
			if (LeanTween.throwErrors)
			{
				Debug.LogError(message2);
			}
			else
			{
				Debug.Log(message2);
			}
			return -1;
		}
		LeanTween.init();
		if (optional == null)
		{
			optional = new Hashtable();
		}
		LTBezierPath lTBezierPath = new LTBezierPath(to);
		if (optional["orientToPath"] != null)
		{
			lTBezierPath.orientToPath = true;
		}
		optional["path"] = lTBezierPath;
		return LeanTween.pushNewTween(gameObject, new Vector3(1f, 0f, 0f), time, TweenAction.MOVE_CURVED_LOCAL, optional);
	}

	public static int moveLocal(GameObject gameObject, Vector3[] to, float time, object[] optional)
	{
		return LeanTween.moveLocal(gameObject, to, time, LeanTween.h(optional));
	}

	public static int moveLocalX(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_LOCAL_X, optional);
	}

	public static int moveLocalX(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.moveLocalX(gameObject, to, time, LeanTween.h(optional));
	}

	public static int moveLocalY(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_LOCAL_Y, optional);
	}

	public static int moveLocalY(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.moveLocalY(gameObject, to, time, LeanTween.h(optional));
	}

	public static int moveLocalZ(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.MOVE_LOCAL_Z, optional);
	}

	public static int moveLocalZ(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.moveLocalZ(gameObject, to, time, LeanTween.h(optional));
	}

	public static int scale(GameObject gameObject, Vector3 to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, to, time, TweenAction.SCALE, optional);
	}

	public static int scale(GameObject gameObject, Vector3 to, float time, object[] optional)
	{
		return LeanTween.scale(gameObject, to, time, LeanTween.h(optional));
	}

	public static int scale(LTRect ltRect, Vector2 to, float time, Hashtable optional)
	{
		LeanTween.init();
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["rect"] = ltRect;
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, to, time, TweenAction.GUI_SCALE, optional);
	}

	public static int scale(LTRect ltRect, Vector2 to, float time, object[] optional)
	{
		return LeanTween.scale(ltRect, to, time, LeanTween.h(optional));
	}

	public static int alpha(LTRect ltRect, float to, float time, Hashtable optional)
	{
		LeanTween.init();
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		ltRect.alphaEnabled = true;
		optional["rect"] = ltRect;
		return LeanTween.pushNewTween(LeanTween.tweenEmpty, new Vector3(to, 0f, 0f), time, TweenAction.GUI_ALPHA, optional);
	}

	public static int alpha(LTRect ltRect, float to, float time, object[] optional)
	{
		return LeanTween.alpha(ltRect, to, time, LeanTween.h(optional));
	}

	public static int scaleX(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.SCALE_X, optional);
	}

	public static int scaleX(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.scaleX(gameObject, to, time, LeanTween.h(optional));
	}

	public static int scaleY(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.SCALE_Y, optional);
	}

	public static int scaleY(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.scaleY(gameObject, to, time, LeanTween.h(optional));
	}

	public static int scaleZ(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.SCALE_Z, optional);
	}

	public static int scaleZ(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.scaleZ(gameObject, to, time, LeanTween.h(optional));
	}

	public static int delayedCall(float delayTime, string callback, Hashtable optional)
	{
		LeanTween.init();
		return LeanTween.delayedCall(LeanTween.tweenEmpty, delayTime, callback, optional);
	}

	public static int delayedCall(float delayTime, Action callback, object[] optional)
	{
		LeanTween.init();
		return LeanTween.delayedCall(LeanTween.tweenEmpty, delayTime, callback, LeanTween.h(optional));
	}

	public static int delayedCall(GameObject gameObject, float delayTime, string callback, object[] optional)
	{
		return LeanTween.delayedCall(gameObject, delayTime, callback, LeanTween.h(optional));
	}

	public static int delayedCall(GameObject gameObject, float delayTime, Action callback, object[] optional)
	{
		return LeanTween.delayedCall(gameObject, delayTime, callback, LeanTween.h(optional));
	}

	public static int delayedCall(GameObject gameObject, float delayTime, string callback, Hashtable optional)
	{
		if (optional == null || optional.Count == 0)
		{
			optional = new Hashtable();
		}
		optional["onComplete"] = callback;
		return LeanTween.pushNewTween(gameObject, Vector3.zero, delayTime, TweenAction.CALLBACK, optional);
	}

	public static int delayedCall(GameObject gameObject, float delayTime, Action callback, Hashtable optional)
	{
		if (optional == null)
		{
			optional = new Hashtable();
		}
		optional["onComplete"] = callback;
		return LeanTween.pushNewTween(gameObject, Vector3.zero, delayTime, TweenAction.CALLBACK, optional);
	}

	public static int delayedCall(GameObject gameObject, float delayTime, Action<object> callback, Hashtable optional)
	{
		if (optional == null)
		{
			optional = new Hashtable();
		}
		optional["onComplete"] = callback;
		return LeanTween.pushNewTween(gameObject, Vector3.zero, delayTime, TweenAction.CALLBACK, optional);
	}

	public static int alpha(GameObject gameObject, float to, float time, Hashtable optional)
	{
		return LeanTween.pushNewTween(gameObject, new Vector3(to, 0f, 0f), time, TweenAction.ALPHA, optional);
	}

	public static int alpha(GameObject gameObject, float to, float time, object[] optional)
	{
		return LeanTween.alpha(gameObject, to, time, LeanTween.h(optional));
	}

	private static float tweenOnCurve(LTDescr tweenDescr, float ratioPassed)
	{
		return tweenDescr.from.x + tweenDescr.diff.x * tweenDescr.animationCurve.Evaluate(ratioPassed);
	}

	private static Vector3 tweenOnCurveVector(LTDescr tweenDescr, float ratioPassed)
	{
		return new Vector3(tweenDescr.from.x + tweenDescr.diff.x * tweenDescr.animationCurve.Evaluate(ratioPassed), tweenDescr.from.y + tweenDescr.diff.y * tweenDescr.animationCurve.Evaluate(ratioPassed), tweenDescr.from.z + tweenDescr.diff.z * tweenDescr.animationCurve.Evaluate(ratioPassed));
	}

	private static float easeOutQuadOpt(float start, float diff, float ratioPassed)
	{
		return -diff * ratioPassed * (ratioPassed - 2f) + start;
	}

	private static float easeInQuadOpt(float start, float diff, float ratioPassed)
	{
		return diff * ratioPassed * ratioPassed + start;
	}

	private static float easeInOutQuadOpt(float start, float diff, float ratioPassed)
	{
		ratioPassed /= 0.5f;
		if (ratioPassed < 1f)
		{
			return diff / 2f * ratioPassed * ratioPassed + start;
		}
		ratioPassed -= 1f;
		return -diff / 2f * (ratioPassed * (ratioPassed - 2f) - 1f) + start;
	}

	private static float linear(float start, float end, float val)
	{
		return Mathf.Lerp(start, end, val);
	}

	private static float clerp(float start, float end, float val)
	{
		float num = 0f;
		float num2 = 360f;
		float num3 = Mathf.Abs((num2 - num) / 2f);
		float result;
		if (end - start < -num3)
		{
			float num4 = (num2 - start + end) * val;
			result = start + num4;
		}
		else if (end - start > num3)
		{
			float num4 = -(num2 - end + start) * val;
			result = start + num4;
		}
		else
		{
			result = start + (end - start) * val;
		}
		return result;
	}

	private static float spring(float start, float end, float val)
	{
		val = Mathf.Clamp01(val);
		val = (Mathf.Sin(val * 3.14159274f * (0.2f + 2.5f * val * val * val)) * Mathf.Pow(1f - val, 2.2f) + val) * (1f + 1.2f * (1f - val));
		return start + (end - start) * val;
	}

	private static float easeInQuad(float start, float end, float val)
	{
		end -= start;
		return end * val * val + start;
	}

	private static float easeOutQuad(float start, float end, float val)
	{
		end -= start;
		return -end * val * (val - 2f) + start;
	}

	private static float easeInOutQuad(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return end / 2f * val * val + start;
		}
		val -= 1f;
		return -end / 2f * (val * (val - 2f) - 1f) + start;
	}

	private static float easeInCubic(float start, float end, float val)
	{
		end -= start;
		return end * val * val * val + start;
	}

	private static float easeOutCubic(float start, float end, float val)
	{
		val -= 1f;
		end -= start;
		return end * (val * val * val + 1f) + start;
	}

	private static float easeInOutCubic(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return end / 2f * val * val * val + start;
		}
		val -= 2f;
		return end / 2f * (val * val * val + 2f) + start;
	}

	private static float easeInQuart(float start, float end, float val)
	{
		end -= start;
		return end * val * val * val * val + start;
	}

	private static float easeOutQuart(float start, float end, float val)
	{
		val -= 1f;
		end -= start;
		return -end * (val * val * val * val - 1f) + start;
	}

	private static float easeInOutQuart(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return end / 2f * val * val * val * val + start;
		}
		val -= 2f;
		return -end / 2f * (val * val * val * val - 2f) + start;
	}

	private static float easeInQuint(float start, float end, float val)
	{
		end -= start;
		return end * val * val * val * val * val + start;
	}

	private static float easeOutQuint(float start, float end, float val)
	{
		val -= 1f;
		end -= start;
		return end * (val * val * val * val * val + 1f) + start;
	}

	private static float easeInOutQuint(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return end / 2f * val * val * val * val * val + start;
		}
		val -= 2f;
		return end / 2f * (val * val * val * val * val + 2f) + start;
	}

	private static float easeInSine(float start, float end, float val)
	{
		end -= start;
		return -end * Mathf.Cos(val / 1f * 1.57079637f) + end + start;
	}

	private static float easeOutSine(float start, float end, float val)
	{
		end -= start;
		return end * Mathf.Sin(val / 1f * 1.57079637f) + start;
	}

	private static float easeInOutSine(float start, float end, float val)
	{
		end -= start;
		return -end / 2f * (Mathf.Cos(3.14159274f * val / 1f) - 1f) + start;
	}

	private static float easeInExpo(float start, float end, float val)
	{
		end -= start;
		return end * Mathf.Pow(2f, 10f * (val / 1f - 1f)) + start;
	}

	private static float easeOutExpo(float start, float end, float val)
	{
		end -= start;
		return end * (-Mathf.Pow(2f, -10f * val / 1f) + 1f) + start;
	}

	private static float easeInOutExpo(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return end / 2f * Mathf.Pow(2f, 10f * (val - 1f)) + start;
		}
		val -= 1f;
		return end / 2f * (-Mathf.Pow(2f, -10f * val) + 2f) + start;
	}

	private static float easeInCirc(float start, float end, float val)
	{
		end -= start;
		return -end * (Mathf.Sqrt(1f - val * val) - 1f) + start;
	}

	private static float easeOutCirc(float start, float end, float val)
	{
		val -= 1f;
		end -= start;
		return end * Mathf.Sqrt(1f - val * val) + start;
	}

	private static float easeInOutCirc(float start, float end, float val)
	{
		val /= 0.5f;
		end -= start;
		if (val < 1f)
		{
			return -end / 2f * (Mathf.Sqrt(1f - val * val) - 1f) + start;
		}
		val -= 2f;
		return end / 2f * (Mathf.Sqrt(1f - val * val) + 1f) + start;
	}

	private static float easeInBounce(float start, float end, float val)
	{
		end -= start;
		float num = 1f;
		return end - LeanTween.easeOutBounce(0f, end, num - val) + start;
	}

	private static float easeOutBounce(float start, float end, float val)
	{
		val /= 1f;
		end -= start;
		if (val < 0.363636374f)
		{
			return end * (7.5625f * val * val) + start;
		}
		if (val < 0.727272749f)
		{
			val -= 0.545454562f;
			return end * (7.5625f * val * val + 0.75f) + start;
		}
		if ((double)val < 0.90909090909090906)
		{
			val -= 0.8181818f;
			return end * (7.5625f * val * val + 0.9375f) + start;
		}
		val -= 0.954545438f;
		return end * (7.5625f * val * val + 0.984375f) + start;
	}

	private static float easeInOutBounce(float start, float end, float val)
	{
		end -= start;
		float num = 1f;
		if (val < num / 2f)
		{
			return LeanTween.easeInBounce(0f, end, val * 2f) * 0.5f + start;
		}
		return LeanTween.easeOutBounce(0f, end, val * 2f - num) * 0.5f + end * 0.5f + start;
	}

	private static float easeInBack(float start, float end, float val)
	{
		end -= start;
		val /= 1f;
		float num = 1.70158f;
		return end * val * val * ((num + 1f) * val - num) + start;
	}

	private static float easeOutBack(float start, float end, float val)
	{
		float num = 1.70158f;
		end -= start;
		val = val / 1f - 1f;
		return end * (val * val * ((num + 1f) * val + num) + 1f) + start;
	}

	private static float easeInOutBack(float start, float end, float val)
	{
		float num = 1.70158f;
		end -= start;
		val /= 0.5f;
		if (val < 1f)
		{
			num *= 1.525f;
			return end / 2f * (val * val * ((num + 1f) * val - num)) + start;
		}
		val -= 2f;
		num *= 1.525f;
		return end / 2f * (val * val * ((num + 1f) * val + num) + 2f) + start;
	}

	private static float easeInElastic(float start, float end, float val)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (val == 0f)
		{
			return start;
		}
		val /= num;
		if (val == 1f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < Mathf.Abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
		}
		val -= 1f;
		return -(num3 * Mathf.Pow(2f, 10f * val) * Mathf.Sin((val * num - num4) * 6.28318548f / num2)) + start;
	}

	private static float easeOutElastic(float start, float end, float val)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (val == 0f)
		{
			return start;
		}
		val /= num;
		if (val == 1f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < Mathf.Abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
		}
		return num3 * Mathf.Pow(2f, -10f * val) * Mathf.Sin((val * num - num4) * 6.28318548f / num2) + end + start;
	}

	private static float easeInOutElastic(float start, float end, float val)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (val == 0f)
		{
			return start;
		}
		val /= num / 2f;
		if (val == 2f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < Mathf.Abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
		}
		if (val < 1f)
		{
			val -= 1f;
			return -0.5f * (num3 * Mathf.Pow(2f, 10f * val) * Mathf.Sin((val * num - num4) * 6.28318548f / num2)) + start;
		}
		val -= 1f;
		return num3 * Mathf.Pow(2f, -10f * val) * Mathf.Sin((val * num - num4) * 6.28318548f / num2) * 0.5f + end + start;
	}

	public static void addListener(int eventId, Action<LTEvent> callback)
	{
		LeanTween.addListener(LeanTween.tweenEmpty, eventId, callback);
	}

	public static void addListener(GameObject caller, int eventId, Action<LTEvent> callback)
	{
		if (LeanTween.eventListeners == null)
		{
			LeanTween.INIT_LISTENERS_MAX = LeanTween.LISTENERS_MAX;
			LeanTween.eventListeners = new Action<LTEvent>[LeanTween.EVENTS_MAX * LeanTween.LISTENERS_MAX];
			LeanTween.goListeners = new GameObject[LeanTween.EVENTS_MAX * LeanTween.LISTENERS_MAX];
		}
		LeanTween.i = 0;
		while (LeanTween.i < LeanTween.INIT_LISTENERS_MAX)
		{
			int num = eventId * LeanTween.INIT_LISTENERS_MAX + LeanTween.i;
			if (LeanTween.goListeners[num] == null || LeanTween.eventListeners[num] == null)
			{
				LeanTween.eventListeners[num] = callback;
				LeanTween.goListeners[num] = caller;
				if (LeanTween.i >= LeanTween.eventsMaxSearch)
				{
					LeanTween.eventsMaxSearch = LeanTween.i + 1;
				}
				return;
			}
			if (LeanTween.goListeners[num] == caller && object.ReferenceEquals(LeanTween.eventListeners[num], callback))
			{
				return;
			}
			LeanTween.i++;
		}
		Debug.LogError("You ran out of areas to add listeners, consider increasing INIT_LISTENERS_MAX, ex: LeanTween.INIT_LISTENERS_MAX = " + LeanTween.INIT_LISTENERS_MAX * 2);
	}

	public static bool removeListener(int eventId, Action<LTEvent> callback)
	{
		return LeanTween.removeListener(LeanTween.tweenEmpty, eventId, callback);
	}

	public static bool removeListener(GameObject caller, int eventId, Action<LTEvent> callback)
	{
		LeanTween.i = 0;
		while (LeanTween.i < LeanTween.eventsMaxSearch)
		{
			int num = eventId * LeanTween.INIT_LISTENERS_MAX + LeanTween.i;
			if (LeanTween.goListeners[num] == caller && object.ReferenceEquals(LeanTween.eventListeners[num], callback))
			{
				LeanTween.eventListeners[num] = null;
				LeanTween.goListeners[num] = null;
				return true;
			}
			LeanTween.i++;
		}
		return false;
	}

	public static void dispatchEvent(int eventId)
	{
		LeanTween.dispatchEvent(eventId, null);
	}

	public static void dispatchEvent(int eventId, object data)
	{
		for (int i = 0; i < LeanTween.eventsMaxSearch; i++)
		{
			int num = eventId * LeanTween.INIT_LISTENERS_MAX + i;
			if (LeanTween.eventListeners[num] != null)
			{
				if (LeanTween.goListeners[num])
				{
					LeanTween.eventListeners[num](new LTEvent(eventId, data));
				}
				else
				{
					LeanTween.eventListeners[num] = null;
				}
			}
		}
	}
}
