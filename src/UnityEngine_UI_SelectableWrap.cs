using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnityEngine_UI_SelectableWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Selectable), typeof(UIBehaviour), null);
		L.RegFunction("IsInteractable", new LuaCSFunction(UnityEngine_UI_SelectableWrap.IsInteractable));
		L.RegFunction("FindSelectable", new LuaCSFunction(UnityEngine_UI_SelectableWrap.FindSelectable));
		L.RegFunction("FindSelectableOnLeft", new LuaCSFunction(UnityEngine_UI_SelectableWrap.FindSelectableOnLeft));
		L.RegFunction("FindSelectableOnRight", new LuaCSFunction(UnityEngine_UI_SelectableWrap.FindSelectableOnRight));
		L.RegFunction("FindSelectableOnUp", new LuaCSFunction(UnityEngine_UI_SelectableWrap.FindSelectableOnUp));
		L.RegFunction("FindSelectableOnDown", new LuaCSFunction(UnityEngine_UI_SelectableWrap.FindSelectableOnDown));
		L.RegFunction("OnMove", new LuaCSFunction(UnityEngine_UI_SelectableWrap.OnMove));
		L.RegFunction("OnPointerDown", new LuaCSFunction(UnityEngine_UI_SelectableWrap.OnPointerDown));
		L.RegFunction("OnPointerUp", new LuaCSFunction(UnityEngine_UI_SelectableWrap.OnPointerUp));
		L.RegFunction("OnPointerEnter", new LuaCSFunction(UnityEngine_UI_SelectableWrap.OnPointerEnter));
		L.RegFunction("OnPointerExit", new LuaCSFunction(UnityEngine_UI_SelectableWrap.OnPointerExit));
		L.RegFunction("OnSelect", new LuaCSFunction(UnityEngine_UI_SelectableWrap.OnSelect));
		L.RegFunction("OnDeselect", new LuaCSFunction(UnityEngine_UI_SelectableWrap.OnDeselect));
		L.RegFunction("Select", new LuaCSFunction(UnityEngine_UI_SelectableWrap.Select));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_SelectableWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("allSelectables", new LuaCSFunction(UnityEngine_UI_SelectableWrap.get_allSelectables), null);
		L.RegVar("navigation", new LuaCSFunction(UnityEngine_UI_SelectableWrap.get_navigation), new LuaCSFunction(UnityEngine_UI_SelectableWrap.set_navigation));
		L.RegVar("transition", new LuaCSFunction(UnityEngine_UI_SelectableWrap.get_transition), new LuaCSFunction(UnityEngine_UI_SelectableWrap.set_transition));
		L.RegVar("colors", new LuaCSFunction(UnityEngine_UI_SelectableWrap.get_colors), new LuaCSFunction(UnityEngine_UI_SelectableWrap.set_colors));
		L.RegVar("spriteState", new LuaCSFunction(UnityEngine_UI_SelectableWrap.get_spriteState), new LuaCSFunction(UnityEngine_UI_SelectableWrap.set_spriteState));
		L.RegVar("animationTriggers", new LuaCSFunction(UnityEngine_UI_SelectableWrap.get_animationTriggers), new LuaCSFunction(UnityEngine_UI_SelectableWrap.set_animationTriggers));
		L.RegVar("targetGraphic", new LuaCSFunction(UnityEngine_UI_SelectableWrap.get_targetGraphic), new LuaCSFunction(UnityEngine_UI_SelectableWrap.set_targetGraphic));
		L.RegVar("interactable", new LuaCSFunction(UnityEngine_UI_SelectableWrap.get_interactable), new LuaCSFunction(UnityEngine_UI_SelectableWrap.set_interactable));
		L.RegVar("image", new LuaCSFunction(UnityEngine_UI_SelectableWrap.get_image), new LuaCSFunction(UnityEngine_UI_SelectableWrap.set_image));
		L.RegVar("animator", new LuaCSFunction(UnityEngine_UI_SelectableWrap.get_animator), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsInteractable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			bool value = selectable.IsInteractable();
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindSelectable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			Vector3 dir = ToLua.ToVector3(L, 2);
			Selectable obj = selectable.FindSelectable(dir);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindSelectableOnLeft(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			Selectable obj = selectable.FindSelectableOnLeft();
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindSelectableOnRight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			Selectable obj = selectable.FindSelectableOnRight();
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindSelectableOnUp(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			Selectable obj = selectable.FindSelectableOnUp();
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindSelectableOnDown(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			Selectable obj = selectable.FindSelectableOnDown();
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnMove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			AxisEventData eventData = (AxisEventData)ToLua.CheckObject(L, 2, typeof(AxisEventData));
			selectable.OnMove(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPointerDown(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			selectable.OnPointerDown(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPointerUp(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			selectable.OnPointerUp(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPointerEnter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			selectable.OnPointerEnter(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPointerExit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			selectable.OnPointerExit(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnSelect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			BaseEventData eventData = (BaseEventData)ToLua.CheckObject(L, 2, typeof(BaseEventData));
			selectable.OnSelect(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDeselect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			BaseEventData eventData = (BaseEventData)ToLua.CheckObject(L, 2, typeof(BaseEventData));
			selectable.OnDeselect(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Select(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Selectable selectable = (Selectable)ToLua.CheckObject(L, 1, typeof(Selectable));
			selectable.Select();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int op_Equality(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object x = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object y = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool value = x == y;
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_allSelectables(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, Selectable.allSelectables);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_navigation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			Navigation navigation = selectable.navigation;
			ToLua.PushValue(L, navigation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index navigation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_transition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			Selectable.Transition transition = selectable.transition;
			ToLua.Push(L, transition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index transition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_colors(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			ColorBlock colors = selectable.colors;
			ToLua.PushValue(L, colors);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index colors on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spriteState(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			SpriteState spriteState = selectable.spriteState;
			ToLua.PushValue(L, spriteState);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spriteState on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_animationTriggers(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			AnimationTriggers animationTriggers = selectable.animationTriggers;
			ToLua.PushObject(L, animationTriggers);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animationTriggers on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetGraphic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			Graphic targetGraphic = selectable.targetGraphic;
			ToLua.Push(L, targetGraphic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetGraphic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_interactable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			bool interactable = selectable.interactable;
			LuaDLL.lua_pushboolean(L, interactable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index interactable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_image(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			Image image = selectable.image;
			ToLua.Push(L, image);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index image on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_animator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			Animator animator = selectable.animator;
			ToLua.Push(L, animator);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_navigation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			Navigation navigation = (Navigation)ToLua.CheckObject(L, 2, typeof(Navigation));
			selectable.navigation = navigation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index navigation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_transition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			Selectable.Transition transition = (Selectable.Transition)((int)ToLua.CheckObject(L, 2, typeof(Selectable.Transition)));
			selectable.transition = transition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index transition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_colors(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			ColorBlock colors = (ColorBlock)ToLua.CheckObject(L, 2, typeof(ColorBlock));
			selectable.colors = colors;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index colors on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spriteState(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			SpriteState spriteState = (SpriteState)ToLua.CheckObject(L, 2, typeof(SpriteState));
			selectable.spriteState = spriteState;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spriteState on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_animationTriggers(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			AnimationTriggers animationTriggers = (AnimationTriggers)ToLua.CheckObject(L, 2, typeof(AnimationTriggers));
			selectable.animationTriggers = animationTriggers;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animationTriggers on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetGraphic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			Graphic targetGraphic = (Graphic)ToLua.CheckUnityObject(L, 2, typeof(Graphic));
			selectable.targetGraphic = targetGraphic;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetGraphic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_interactable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			bool interactable = LuaDLL.luaL_checkboolean(L, 2);
			selectable.interactable = interactable;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index interactable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_image(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Selectable selectable = (Selectable)obj;
			Image image = (Image)ToLua.CheckUnityObject(L, 2, typeof(Image));
			selectable.image = image;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index image on a nil value");
		}
		return result;
	}
}
