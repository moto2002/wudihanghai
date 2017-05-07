using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_RectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Rect), null, null);
		L.RegFunction("MinMaxRect", new LuaCSFunction(UnityEngine_RectWrap.MinMaxRect));
		L.RegFunction("Set", new LuaCSFunction(UnityEngine_RectWrap.Set));
		L.RegFunction("ToString", new LuaCSFunction(UnityEngine_RectWrap.ToString));
		L.RegFunction("Contains", new LuaCSFunction(UnityEngine_RectWrap.Contains));
		L.RegFunction("Overlaps", new LuaCSFunction(UnityEngine_RectWrap.Overlaps));
		L.RegFunction("NormalizedToPoint", new LuaCSFunction(UnityEngine_RectWrap.NormalizedToPoint));
		L.RegFunction("PointToNormalized", new LuaCSFunction(UnityEngine_RectWrap.PointToNormalized));
		L.RegFunction("GetHashCode", new LuaCSFunction(UnityEngine_RectWrap.GetHashCode));
		L.RegFunction("Equals", new LuaCSFunction(UnityEngine_RectWrap.Equals));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_RectWrap._CreateUnityEngine_Rect));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_RectWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("x", new LuaCSFunction(UnityEngine_RectWrap.get_x), new LuaCSFunction(UnityEngine_RectWrap.set_x));
		L.RegVar("y", new LuaCSFunction(UnityEngine_RectWrap.get_y), new LuaCSFunction(UnityEngine_RectWrap.set_y));
		L.RegVar("position", new LuaCSFunction(UnityEngine_RectWrap.get_position), new LuaCSFunction(UnityEngine_RectWrap.set_position));
		L.RegVar("center", new LuaCSFunction(UnityEngine_RectWrap.get_center), new LuaCSFunction(UnityEngine_RectWrap.set_center));
		L.RegVar("min", new LuaCSFunction(UnityEngine_RectWrap.get_min), new LuaCSFunction(UnityEngine_RectWrap.set_min));
		L.RegVar("max", new LuaCSFunction(UnityEngine_RectWrap.get_max), new LuaCSFunction(UnityEngine_RectWrap.set_max));
		L.RegVar("width", new LuaCSFunction(UnityEngine_RectWrap.get_width), new LuaCSFunction(UnityEngine_RectWrap.set_width));
		L.RegVar("height", new LuaCSFunction(UnityEngine_RectWrap.get_height), new LuaCSFunction(UnityEngine_RectWrap.set_height));
		L.RegVar("size", new LuaCSFunction(UnityEngine_RectWrap.get_size), new LuaCSFunction(UnityEngine_RectWrap.set_size));
		L.RegVar("xMin", new LuaCSFunction(UnityEngine_RectWrap.get_xMin), new LuaCSFunction(UnityEngine_RectWrap.set_xMin));
		L.RegVar("yMin", new LuaCSFunction(UnityEngine_RectWrap.get_yMin), new LuaCSFunction(UnityEngine_RectWrap.set_yMin));
		L.RegVar("xMax", new LuaCSFunction(UnityEngine_RectWrap.get_xMax), new LuaCSFunction(UnityEngine_RectWrap.set_xMax));
		L.RegVar("yMax", new LuaCSFunction(UnityEngine_RectWrap.get_yMax), new LuaCSFunction(UnityEngine_RectWrap.set_yMax));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Rect(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				Rect source = (Rect)ToLua.CheckObject(L, 1, typeof(Rect));
				Rect rect = new Rect(source);
				ToLua.PushValue(L, rect);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Vector2), typeof(Vector2)))
			{
				Vector2 position = ToLua.ToVector2(L, 1);
				Vector2 size = ToLua.ToVector2(L, 2);
				Rect rect2 = new Rect(position, size);
				ToLua.PushValue(L, rect2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				float x = (float)LuaDLL.luaL_checknumber(L, 1);
				float y = (float)LuaDLL.luaL_checknumber(L, 2);
				float width = (float)LuaDLL.luaL_checknumber(L, 3);
				float height = (float)LuaDLL.luaL_checknumber(L, 4);
				Rect rect3 = new Rect(x, y, width, height);
				ToLua.PushValue(L, rect3);
				result = 1;
			}
			else if (num == 0)
			{
				ToLua.PushValue(L, default(Rect));
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Rect.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MinMaxRect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			float xmin = (float)LuaDLL.luaL_checknumber(L, 1);
			float ymin = (float)LuaDLL.luaL_checknumber(L, 2);
			float xmax = (float)LuaDLL.luaL_checknumber(L, 3);
			float ymax = (float)LuaDLL.luaL_checknumber(L, 4);
			Rect rect = Rect.MinMaxRect(xmin, ymin, xmax, ymax);
			ToLua.PushValue(L, rect);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Set(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			Rect rect = (Rect)ToLua.CheckObject(L, 1, typeof(Rect));
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			float width = (float)LuaDLL.luaL_checknumber(L, 4);
			float height = (float)LuaDLL.luaL_checknumber(L, 5);
			rect.Set(x, y, width, height);
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToString(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Rect)))
			{
				string str = ((Rect)ToLua.ToObject(L, 1)).ToString();
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Rect), typeof(string)))
			{
				Rect rect = (Rect)ToLua.ToObject(L, 1);
				string format = ToLua.ToString(L, 2);
				string str2 = rect.ToString(format);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rect.ToString");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Contains(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Rect), typeof(Vector3)))
			{
				Rect rect = (Rect)ToLua.ToObject(L, 1);
				Vector3 point = ToLua.ToVector3(L, 2);
				bool value = rect.Contains(point);
				LuaDLL.lua_pushboolean(L, value);
				ToLua.SetBack(L, 1, rect);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Rect), typeof(Vector2)))
			{
				Rect rect2 = (Rect)ToLua.ToObject(L, 1);
				Vector2 point2 = ToLua.ToVector2(L, 2);
				bool value2 = rect2.Contains(point2);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.SetBack(L, 1, rect2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Rect), typeof(Vector3), typeof(bool)))
			{
				Rect rect3 = (Rect)ToLua.ToObject(L, 1);
				Vector3 point3 = ToLua.ToVector3(L, 2);
				bool allowInverse = LuaDLL.lua_toboolean(L, 3);
				bool value3 = rect3.Contains(point3, allowInverse);
				LuaDLL.lua_pushboolean(L, value3);
				ToLua.SetBack(L, 1, rect3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rect.Contains");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Overlaps(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Rect), typeof(Rect)))
			{
				Rect rect = (Rect)ToLua.ToObject(L, 1);
				Rect other = (Rect)ToLua.ToObject(L, 2);
				bool value = rect.Overlaps(other);
				LuaDLL.lua_pushboolean(L, value);
				ToLua.SetBack(L, 1, rect);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Rect), typeof(Rect), typeof(bool)))
			{
				Rect rect2 = (Rect)ToLua.ToObject(L, 1);
				Rect other2 = (Rect)ToLua.ToObject(L, 2);
				bool allowInverse = LuaDLL.lua_toboolean(L, 3);
				bool value2 = rect2.Overlaps(other2, allowInverse);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.SetBack(L, 1, rect2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rect.Overlaps");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NormalizedToPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Rect rectangle = (Rect)ToLua.CheckObject(L, 1, typeof(Rect));
			Vector2 normalizedRectCoordinates = ToLua.ToVector2(L, 2);
			Vector2 v = Rect.NormalizedToPoint(rectangle, normalizedRectCoordinates);
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
	private static int PointToNormalized(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Rect rectangle = (Rect)ToLua.CheckObject(L, 1, typeof(Rect));
			Vector2 point = ToLua.ToVector2(L, 2);
			Vector2 v = Rect.PointToNormalized(rectangle, point);
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
	private static int GetHashCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Rect rect = (Rect)ToLua.CheckObject(L, 1, typeof(Rect));
			int hashCode = rect.GetHashCode();
			LuaDLL.lua_pushinteger(L, hashCode);
			ToLua.SetBack(L, 1, rect);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Equals(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Rect rect = (Rect)ToLua.ToObject(L, 1);
			object other = ToLua.ToVarObject(L, 2);
			bool value = rect.Equals(other);
			LuaDLL.lua_pushboolean(L, value);
			ToLua.SetBack(L, 1, rect);
			result = 1;
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
			Rect lhs = (Rect)ToLua.ToObject(L, 1);
			Rect rhs = (Rect)ToLua.ToObject(L, 2);
			bool value = lhs == rhs;
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
	private static int get_x(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			float x = ((Rect)obj).x;
			LuaDLL.lua_pushnumber(L, (double)x);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index x on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_y(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			float y = ((Rect)obj).y;
			LuaDLL.lua_pushnumber(L, (double)y);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index y on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_position(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Vector2 position = ((Rect)obj).position;
			ToLua.Push(L, position);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index position on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_center(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Vector2 center = ((Rect)obj).center;
			ToLua.Push(L, center);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index center on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_min(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Vector2 min = ((Rect)obj).min;
			ToLua.Push(L, min);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index min on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_max(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Vector2 max = ((Rect)obj).max;
			ToLua.Push(L, max);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index max on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_width(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			float width = ((Rect)obj).width;
			LuaDLL.lua_pushnumber(L, (double)width);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index width on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_height(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			float height = ((Rect)obj).height;
			LuaDLL.lua_pushnumber(L, (double)height);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_size(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Vector2 size = ((Rect)obj).size;
			ToLua.Push(L, size);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index size on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_xMin(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			float xMin = ((Rect)obj).xMin;
			LuaDLL.lua_pushnumber(L, (double)xMin);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index xMin on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_yMin(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			float yMin = ((Rect)obj).yMin;
			LuaDLL.lua_pushnumber(L, (double)yMin);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index yMin on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_xMax(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			float xMax = ((Rect)obj).xMax;
			LuaDLL.lua_pushnumber(L, (double)xMax);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index xMax on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_yMax(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			float yMax = ((Rect)obj).yMax;
			LuaDLL.lua_pushnumber(L, (double)yMax);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index yMax on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_x(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			rect.x = x;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index x on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_y(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			float y = (float)LuaDLL.luaL_checknumber(L, 2);
			rect.y = y;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index y on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_position(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			Vector2 position = ToLua.ToVector2(L, 2);
			rect.position = position;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index position on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_center(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			Vector2 center = ToLua.ToVector2(L, 2);
			rect.center = center;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index center on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_min(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			Vector2 min = ToLua.ToVector2(L, 2);
			rect.min = min;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index min on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_max(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			Vector2 max = ToLua.ToVector2(L, 2);
			rect.max = max;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index max on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_width(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			float width = (float)LuaDLL.luaL_checknumber(L, 2);
			rect.width = width;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index width on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_height(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			float height = (float)LuaDLL.luaL_checknumber(L, 2);
			rect.height = height;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_size(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			Vector2 size = ToLua.ToVector2(L, 2);
			rect.size = size;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index size on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_xMin(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			float xMin = (float)LuaDLL.luaL_checknumber(L, 2);
			rect.xMin = xMin;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index xMin on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_yMin(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			float yMin = (float)LuaDLL.luaL_checknumber(L, 2);
			rect.yMin = yMin;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index yMin on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_xMax(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			float xMax = (float)LuaDLL.luaL_checknumber(L, 2);
			rect.xMax = xMax;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index xMax on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_yMax(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rect rect = (Rect)obj;
			float yMax = (float)LuaDLL.luaL_checknumber(L, 2);
			rect.yMax = yMax;
			ToLua.SetBack(L, 1, rect);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index yMax on a nil value");
		}
		return result;
	}
}
