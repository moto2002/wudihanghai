using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_SkinnedMeshRendererWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SkinnedMeshRenderer), typeof(Renderer), null);
		L.RegFunction("BakeMesh", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.BakeMesh));
		L.RegFunction("GetBlendShapeWeight", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.GetBlendShapeWeight));
		L.RegFunction("SetBlendShapeWeight", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.SetBlendShapeWeight));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap._CreateUnityEngine_SkinnedMeshRenderer));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("bones", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.get_bones), new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.set_bones));
		L.RegVar("rootBone", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.get_rootBone), new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.set_rootBone));
		L.RegVar("quality", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.get_quality), new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.set_quality));
		L.RegVar("sharedMesh", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.get_sharedMesh), new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.set_sharedMesh));
		L.RegVar("updateWhenOffscreen", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.get_updateWhenOffscreen), new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.set_updateWhenOffscreen));
		L.RegVar("localBounds", new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.get_localBounds), new LuaCSFunction(UnityEngine_SkinnedMeshRendererWrap.set_localBounds));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_SkinnedMeshRenderer(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				SkinnedMeshRenderer obj = new SkinnedMeshRenderer();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.SkinnedMeshRenderer.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BakeMesh(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)ToLua.CheckObject(L, 1, typeof(SkinnedMeshRenderer));
			Mesh mesh = (Mesh)ToLua.CheckUnityObject(L, 2, typeof(Mesh));
			skinnedMeshRenderer.BakeMesh(mesh);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBlendShapeWeight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)ToLua.CheckObject(L, 1, typeof(SkinnedMeshRenderer));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			float blendShapeWeight = skinnedMeshRenderer.GetBlendShapeWeight(index);
			LuaDLL.lua_pushnumber(L, (double)blendShapeWeight);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetBlendShapeWeight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)ToLua.CheckObject(L, 1, typeof(SkinnedMeshRenderer));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			float value = (float)LuaDLL.luaL_checknumber(L, 3);
			skinnedMeshRenderer.SetBlendShapeWeight(index, value);
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
	private static int get_bones(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			Transform[] bones = skinnedMeshRenderer.bones;
			ToLua.Push(L, bones);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bones on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rootBone(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			Transform rootBone = skinnedMeshRenderer.rootBone;
			ToLua.Push(L, rootBone);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rootBone on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_quality(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			SkinQuality quality = skinnedMeshRenderer.quality;
			ToLua.Push(L, quality);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index quality on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sharedMesh(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			Mesh sharedMesh = skinnedMeshRenderer.sharedMesh;
			ToLua.Push(L, sharedMesh);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sharedMesh on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_updateWhenOffscreen(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			bool updateWhenOffscreen = skinnedMeshRenderer.updateWhenOffscreen;
			LuaDLL.lua_pushboolean(L, updateWhenOffscreen);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateWhenOffscreen on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localBounds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			Bounds localBounds = skinnedMeshRenderer.localBounds;
			ToLua.Push(L, localBounds);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localBounds on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bones(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			Transform[] bones = ToLua.CheckObjectArray<Transform>(L, 2);
			skinnedMeshRenderer.bones = bones;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bones on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rootBone(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			Transform rootBone = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			skinnedMeshRenderer.rootBone = rootBone;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rootBone on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_quality(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			SkinQuality quality = (SkinQuality)((int)ToLua.CheckObject(L, 2, typeof(SkinQuality)));
			skinnedMeshRenderer.quality = quality;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index quality on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sharedMesh(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			Mesh sharedMesh = (Mesh)ToLua.CheckUnityObject(L, 2, typeof(Mesh));
			skinnedMeshRenderer.sharedMesh = sharedMesh;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sharedMesh on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_updateWhenOffscreen(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			bool updateWhenOffscreen = LuaDLL.luaL_checkboolean(L, 2);
			skinnedMeshRenderer.updateWhenOffscreen = updateWhenOffscreen;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateWhenOffscreen on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localBounds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj;
			Bounds localBounds = ToLua.ToBounds(L, 2);
			skinnedMeshRenderer.localBounds = localBounds;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localBounds on a nil value");
		}
		return result;
	}
}
