using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_SpriteWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Sprite), typeof(UnityEngine.Object), null);
		L.RegFunction("Create", new LuaCSFunction(UnityEngine_SpriteWrap.Create));
		L.RegFunction("OverrideGeometry", new LuaCSFunction(UnityEngine_SpriteWrap.OverrideGeometry));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_SpriteWrap._CreateUnityEngine_Sprite));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_SpriteWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("bounds", new LuaCSFunction(UnityEngine_SpriteWrap.get_bounds), null);
		L.RegVar("rect", new LuaCSFunction(UnityEngine_SpriteWrap.get_rect), null);
		L.RegVar("pixelsPerUnit", new LuaCSFunction(UnityEngine_SpriteWrap.get_pixelsPerUnit), null);
		L.RegVar("texture", new LuaCSFunction(UnityEngine_SpriteWrap.get_texture), null);
		L.RegVar("associatedAlphaSplitTexture", new LuaCSFunction(UnityEngine_SpriteWrap.get_associatedAlphaSplitTexture), null);
		L.RegVar("textureRect", new LuaCSFunction(UnityEngine_SpriteWrap.get_textureRect), null);
		L.RegVar("textureRectOffset", new LuaCSFunction(UnityEngine_SpriteWrap.get_textureRectOffset), null);
		L.RegVar("packed", new LuaCSFunction(UnityEngine_SpriteWrap.get_packed), null);
		L.RegVar("packingMode", new LuaCSFunction(UnityEngine_SpriteWrap.get_packingMode), null);
		L.RegVar("packingRotation", new LuaCSFunction(UnityEngine_SpriteWrap.get_packingRotation), null);
		L.RegVar("pivot", new LuaCSFunction(UnityEngine_SpriteWrap.get_pivot), null);
		L.RegVar("border", new LuaCSFunction(UnityEngine_SpriteWrap.get_border), null);
		L.RegVar("vertices", new LuaCSFunction(UnityEngine_SpriteWrap.get_vertices), null);
		L.RegVar("triangles", new LuaCSFunction(UnityEngine_SpriteWrap.get_triangles), null);
		L.RegVar("uv", new LuaCSFunction(UnityEngine_SpriteWrap.get_uv), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Sprite(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Sprite obj = new Sprite();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Sprite.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Create(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Rect), typeof(Vector2)))
			{
				Texture2D texture = (Texture2D)ToLua.ToObject(L, 1);
				Rect rect = (Rect)ToLua.ToObject(L, 2);
				Vector2 pivot = ToLua.ToVector2(L, 3);
				Sprite obj = Sprite.Create(texture, rect, pivot);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Rect), typeof(Vector2), typeof(float)))
			{
				Texture2D texture2 = (Texture2D)ToLua.ToObject(L, 1);
				Rect rect2 = (Rect)ToLua.ToObject(L, 2);
				Vector2 pivot2 = ToLua.ToVector2(L, 3);
				float pixelsPerUnit = (float)LuaDLL.lua_tonumber(L, 4);
				Sprite obj2 = Sprite.Create(texture2, rect2, pivot2, pixelsPerUnit);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Rect), typeof(Vector2), typeof(float), typeof(uint)))
			{
				Texture2D texture3 = (Texture2D)ToLua.ToObject(L, 1);
				Rect rect3 = (Rect)ToLua.ToObject(L, 2);
				Vector2 pivot3 = ToLua.ToVector2(L, 3);
				float pixelsPerUnit2 = (float)LuaDLL.lua_tonumber(L, 4);
				uint extrude = (uint)LuaDLL.lua_tonumber(L, 5);
				Sprite obj3 = Sprite.Create(texture3, rect3, pivot3, pixelsPerUnit2, extrude);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Rect), typeof(Vector2), typeof(float), typeof(uint), typeof(SpriteMeshType)))
			{
				Texture2D texture4 = (Texture2D)ToLua.ToObject(L, 1);
				Rect rect4 = (Rect)ToLua.ToObject(L, 2);
				Vector2 pivot4 = ToLua.ToVector2(L, 3);
				float pixelsPerUnit3 = (float)LuaDLL.lua_tonumber(L, 4);
				uint extrude2 = (uint)LuaDLL.lua_tonumber(L, 5);
				SpriteMeshType meshType = (SpriteMeshType)((int)ToLua.ToObject(L, 6));
				Sprite obj4 = Sprite.Create(texture4, rect4, pivot4, pixelsPerUnit3, extrude2, meshType);
				ToLua.Push(L, obj4);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Rect), typeof(Vector2), typeof(float), typeof(uint), typeof(SpriteMeshType), typeof(Vector4)))
			{
				Texture2D texture5 = (Texture2D)ToLua.ToObject(L, 1);
				Rect rect5 = (Rect)ToLua.ToObject(L, 2);
				Vector2 pivot5 = ToLua.ToVector2(L, 3);
				float pixelsPerUnit4 = (float)LuaDLL.lua_tonumber(L, 4);
				uint extrude3 = (uint)LuaDLL.lua_tonumber(L, 5);
				SpriteMeshType meshType2 = (SpriteMeshType)((int)ToLua.ToObject(L, 6));
				Vector4 border = ToLua.ToVector4(L, 7);
				Sprite obj5 = Sprite.Create(texture5, rect5, pivot5, pixelsPerUnit4, extrude3, meshType2, border);
				ToLua.Push(L, obj5);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Sprite.Create");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OverrideGeometry(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Sprite sprite = (Sprite)ToLua.CheckObject(L, 1, typeof(Sprite));
			Vector2[] vertices = ToLua.CheckObjectArray<Vector2>(L, 2);
			ushort[] triangles = ToLua.CheckNumberArray<ushort>(L, 3);
			sprite.OverrideGeometry(vertices, triangles);
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
	private static int get_bounds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			Bounds bounds = sprite.bounds;
			ToLua.Push(L, bounds);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bounds on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			Rect rect = sprite.rect;
			ToLua.PushValue(L, rect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelsPerUnit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			float pixelsPerUnit = sprite.pixelsPerUnit;
			LuaDLL.lua_pushnumber(L, (double)pixelsPerUnit);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelsPerUnit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_texture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			Texture2D texture = sprite.texture;
			ToLua.Push(L, texture);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index texture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_associatedAlphaSplitTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			Texture2D associatedAlphaSplitTexture = sprite.associatedAlphaSplitTexture;
			ToLua.Push(L, associatedAlphaSplitTexture);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index associatedAlphaSplitTexture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_textureRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			Rect textureRect = sprite.textureRect;
			ToLua.PushValue(L, textureRect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index textureRect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_textureRectOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			Vector2 textureRectOffset = sprite.textureRectOffset;
			ToLua.Push(L, textureRectOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index textureRectOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_packed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			bool packed = sprite.packed;
			LuaDLL.lua_pushboolean(L, packed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index packed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_packingMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			SpritePackingMode packingMode = sprite.packingMode;
			ToLua.Push(L, packingMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index packingMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_packingRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			SpritePackingRotation packingRotation = sprite.packingRotation;
			ToLua.Push(L, packingRotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index packingRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			Vector2 pivot = sprite.pivot;
			ToLua.Push(L, pivot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_border(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			Vector4 border = sprite.border;
			ToLua.Push(L, border);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index border on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_vertices(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			Vector2[] vertices = sprite.vertices;
			ToLua.Push(L, vertices);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index vertices on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_triangles(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			ushort[] triangles = sprite.triangles;
			ToLua.Push(L, triangles);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index triangles on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_uv(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Sprite sprite = (Sprite)obj;
			Vector2[] uv = sprite.uv;
			ToLua.Push(L, uv);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uv on a nil value");
		}
		return result;
	}
}
