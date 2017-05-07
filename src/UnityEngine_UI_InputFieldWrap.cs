using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnityEngine_UI_InputFieldWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(InputField), typeof(Selectable), null);
		L.RegFunction("MoveTextEnd", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.MoveTextEnd));
		L.RegFunction("MoveTextStart", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.MoveTextStart));
		L.RegFunction("ScreenToLocal", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.ScreenToLocal));
		L.RegFunction("OnBeginDrag", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.OnBeginDrag));
		L.RegFunction("OnDrag", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.OnDrag));
		L.RegFunction("OnEndDrag", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.OnEndDrag));
		L.RegFunction("OnPointerDown", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.OnPointerDown));
		L.RegFunction("ProcessEvent", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.ProcessEvent));
		L.RegFunction("OnUpdateSelected", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.OnUpdateSelected));
		L.RegFunction("Rebuild", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.Rebuild));
		L.RegFunction("LayoutComplete", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.LayoutComplete));
		L.RegFunction("GraphicUpdateComplete", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.GraphicUpdateComplete));
		L.RegFunction("ActivateInputField", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.ActivateInputField));
		L.RegFunction("OnSelect", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.OnSelect));
		L.RegFunction("OnPointerClick", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.OnPointerClick));
		L.RegFunction("DeactivateInputField", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.DeactivateInputField));
		L.RegFunction("OnDeselect", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.OnDeselect));
		L.RegFunction("OnSubmit", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.OnSubmit));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("shouldHideMobileInput", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_shouldHideMobileInput), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_shouldHideMobileInput));
		L.RegVar("text", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_text), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_text));
		L.RegVar("isFocused", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_isFocused), null);
		L.RegVar("caretBlinkRate", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_caretBlinkRate), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_caretBlinkRate));
		L.RegVar("textComponent", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_textComponent), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_textComponent));
		L.RegVar("placeholder", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_placeholder), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_placeholder));
		L.RegVar("selectionColor", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_selectionColor), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_selectionColor));
		L.RegVar("onEndEdit", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_onEndEdit), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_onEndEdit));
		L.RegVar("onValueChange", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_onValueChange), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_onValueChange));
		L.RegVar("onValidateInput", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_onValidateInput), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_onValidateInput));
		L.RegVar("characterLimit", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_characterLimit), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_characterLimit));
		L.RegVar("contentType", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_contentType), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_contentType));
		L.RegVar("lineType", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_lineType), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_lineType));
		L.RegVar("inputType", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_inputType), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_inputType));
		L.RegVar("keyboardType", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_keyboardType), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_keyboardType));
		L.RegVar("characterValidation", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_characterValidation), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_characterValidation));
		L.RegVar("multiLine", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_multiLine), null);
		L.RegVar("asteriskChar", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_asteriskChar), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_asteriskChar));
		L.RegVar("wasCanceled", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_wasCanceled), null);
		L.RegVar("caretPosition", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_caretPosition), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_caretPosition));
		L.RegVar("selectionAnchorPosition", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_selectionAnchorPosition), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_selectionAnchorPosition));
		L.RegVar("selectionFocusPosition", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.get_selectionFocusPosition), new LuaCSFunction(UnityEngine_UI_InputFieldWrap.set_selectionFocusPosition));
		L.RegFunction("OnValidateInput", new LuaCSFunction(UnityEngine_UI_InputFieldWrap.UnityEngine_UI_InputField_OnValidateInput));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveTextEnd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			bool shift = LuaDLL.luaL_checkboolean(L, 2);
			inputField.MoveTextEnd(shift);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveTextStart(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			bool shift = LuaDLL.luaL_checkboolean(L, 2);
			inputField.MoveTextStart(shift);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ScreenToLocal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			Vector2 screen = ToLua.ToVector2(L, 2);
			Vector2 v = inputField.ScreenToLocal(screen);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnBeginDrag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			inputField.OnBeginDrag(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDrag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			inputField.OnDrag(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnEndDrag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			inputField.OnEndDrag(eventData);
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
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			inputField.OnPointerDown(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			Event e = (Event)ToLua.CheckObject(L, 2, typeof(Event));
			inputField.ProcessEvent(e);
			result = 0;
		}
		catch (Exception e2)
		{
			result = LuaDLL.toluaL_exception(L, e2, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnUpdateSelected(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			BaseEventData eventData = (BaseEventData)ToLua.CheckObject(L, 2, typeof(BaseEventData));
			inputField.OnUpdateSelected(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Rebuild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			CanvasUpdate update = (CanvasUpdate)((int)ToLua.CheckObject(L, 2, typeof(CanvasUpdate)));
			inputField.Rebuild(update);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LayoutComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			inputField.LayoutComplete();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GraphicUpdateComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			inputField.GraphicUpdateComplete();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ActivateInputField(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			inputField.ActivateInputField();
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
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			BaseEventData eventData = (BaseEventData)ToLua.CheckObject(L, 2, typeof(BaseEventData));
			inputField.OnSelect(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPointerClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			PointerEventData eventData = (PointerEventData)ToLua.CheckObject(L, 2, typeof(PointerEventData));
			inputField.OnPointerClick(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DeactivateInputField(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			inputField.DeactivateInputField();
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
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			BaseEventData eventData = (BaseEventData)ToLua.CheckObject(L, 2, typeof(BaseEventData));
			inputField.OnDeselect(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnSubmit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			InputField inputField = (InputField)ToLua.CheckObject(L, 1, typeof(InputField));
			BaseEventData eventData = (BaseEventData)ToLua.CheckObject(L, 2, typeof(BaseEventData));
			inputField.OnSubmit(eventData);
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
	private static int get_shouldHideMobileInput(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			bool shouldHideMobileInput = inputField.shouldHideMobileInput;
			LuaDLL.lua_pushboolean(L, shouldHideMobileInput);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shouldHideMobileInput on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_text(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			string text = inputField.text;
			LuaDLL.lua_pushstring(L, text);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index text on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isFocused(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			bool isFocused = inputField.isFocused;
			LuaDLL.lua_pushboolean(L, isFocused);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isFocused on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_caretBlinkRate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			float caretBlinkRate = inputField.caretBlinkRate;
			LuaDLL.lua_pushnumber(L, (double)caretBlinkRate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index caretBlinkRate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_textComponent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			Text textComponent = inputField.textComponent;
			ToLua.Push(L, textComponent);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index textComponent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_placeholder(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			Graphic placeholder = inputField.placeholder;
			ToLua.Push(L, placeholder);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index placeholder on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectionColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			Color selectionColor = inputField.selectionColor;
			ToLua.Push(L, selectionColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onEndEdit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.SubmitEvent onEndEdit = inputField.onEndEdit;
			ToLua.PushObject(L, onEndEdit);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onEndEdit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onValueChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.OnChangeEvent onValueChange = inputField.onValueChange;
			ToLua.PushObject(L, onValueChange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onValueChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onValidateInput(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.OnValidateInput onValidateInput = inputField.onValidateInput;
			ToLua.Push(L, onValidateInput);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onValidateInput on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_characterLimit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			int characterLimit = inputField.characterLimit;
			LuaDLL.lua_pushinteger(L, characterLimit);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index characterLimit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_contentType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.ContentType contentType = inputField.contentType;
			ToLua.Push(L, contentType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index contentType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lineType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.LineType lineType = inputField.lineType;
			ToLua.Push(L, lineType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lineType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inputType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.InputType inputType = inputField.inputType;
			ToLua.Push(L, inputType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inputType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keyboardType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			TouchScreenKeyboardType keyboardType = inputField.keyboardType;
			ToLua.Push(L, keyboardType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keyboardType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_characterValidation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.CharacterValidation characterValidation = inputField.characterValidation;
			ToLua.Push(L, characterValidation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index characterValidation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_multiLine(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			bool multiLine = inputField.multiLine;
			LuaDLL.lua_pushboolean(L, multiLine);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index multiLine on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_asteriskChar(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			char asteriskChar = inputField.asteriskChar;
			LuaDLL.lua_pushnumber(L, (double)asteriskChar);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index asteriskChar on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_wasCanceled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			bool wasCanceled = inputField.wasCanceled;
			LuaDLL.lua_pushboolean(L, wasCanceled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wasCanceled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_caretPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			int caretPosition = inputField.caretPosition;
			LuaDLL.lua_pushinteger(L, caretPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index caretPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectionAnchorPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			int selectionAnchorPosition = inputField.selectionAnchorPosition;
			LuaDLL.lua_pushinteger(L, selectionAnchorPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionAnchorPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectionFocusPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			int selectionFocusPosition = inputField.selectionFocusPosition;
			LuaDLL.lua_pushinteger(L, selectionFocusPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionFocusPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shouldHideMobileInput(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			bool shouldHideMobileInput = LuaDLL.luaL_checkboolean(L, 2);
			inputField.shouldHideMobileInput = shouldHideMobileInput;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shouldHideMobileInput on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_text(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			string text = ToLua.CheckString(L, 2);
			inputField.text = text;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index text on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_caretBlinkRate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			float caretBlinkRate = (float)LuaDLL.luaL_checknumber(L, 2);
			inputField.caretBlinkRate = caretBlinkRate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index caretBlinkRate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_textComponent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			Text textComponent = (Text)ToLua.CheckUnityObject(L, 2, typeof(Text));
			inputField.textComponent = textComponent;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index textComponent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_placeholder(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			Graphic placeholder = (Graphic)ToLua.CheckUnityObject(L, 2, typeof(Graphic));
			inputField.placeholder = placeholder;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index placeholder on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectionColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			Color selectionColor = ToLua.ToColor(L, 2);
			inputField.selectionColor = selectionColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onEndEdit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.SubmitEvent onEndEdit = (InputField.SubmitEvent)ToLua.CheckObject(L, 2, typeof(InputField.SubmitEvent));
			inputField.onEndEdit = onEndEdit;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onEndEdit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onValueChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.OnChangeEvent onValueChange = (InputField.OnChangeEvent)ToLua.CheckObject(L, 2, typeof(InputField.OnChangeEvent));
			inputField.onValueChange = onValueChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onValueChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onValidateInput(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			InputField.OnValidateInput onValidateInput;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onValidateInput = (InputField.OnValidateInput)ToLua.CheckObject(L, 2, typeof(InputField.OnValidateInput));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onValidateInput = (DelegateFactory.CreateDelegate(typeof(InputField.OnValidateInput), func) as InputField.OnValidateInput);
			}
			inputField.onValidateInput = onValidateInput;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onValidateInput on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_characterLimit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			int characterLimit = (int)LuaDLL.luaL_checknumber(L, 2);
			inputField.characterLimit = characterLimit;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index characterLimit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_contentType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.ContentType contentType = (InputField.ContentType)((int)ToLua.CheckObject(L, 2, typeof(InputField.ContentType)));
			inputField.contentType = contentType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index contentType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lineType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.LineType lineType = (InputField.LineType)((int)ToLua.CheckObject(L, 2, typeof(InputField.LineType)));
			inputField.lineType = lineType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lineType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_inputType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.InputType inputType = (InputField.InputType)((int)ToLua.CheckObject(L, 2, typeof(InputField.InputType)));
			inputField.inputType = inputType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inputType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keyboardType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			TouchScreenKeyboardType keyboardType = (TouchScreenKeyboardType)((int)ToLua.CheckObject(L, 2, typeof(TouchScreenKeyboardType)));
			inputField.keyboardType = keyboardType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keyboardType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_characterValidation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			InputField.CharacterValidation characterValidation = (InputField.CharacterValidation)((int)ToLua.CheckObject(L, 2, typeof(InputField.CharacterValidation)));
			inputField.characterValidation = characterValidation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index characterValidation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_asteriskChar(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			char asteriskChar = (char)LuaDLL.luaL_checknumber(L, 2);
			inputField.asteriskChar = asteriskChar;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index asteriskChar on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_caretPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			int caretPosition = (int)LuaDLL.luaL_checknumber(L, 2);
			inputField.caretPosition = caretPosition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index caretPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectionAnchorPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			int selectionAnchorPosition = (int)LuaDLL.luaL_checknumber(L, 2);
			inputField.selectionAnchorPosition = selectionAnchorPosition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionAnchorPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectionFocusPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			InputField inputField = (InputField)obj;
			int selectionFocusPosition = (int)LuaDLL.luaL_checknumber(L, 2);
			inputField.selectionFocusPosition = selectionFocusPosition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionFocusPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_UI_InputField_OnValidateInput(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(InputField.OnValidateInput), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(InputField.OnValidateInput), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
