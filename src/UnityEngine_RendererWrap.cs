using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UnityEngine_RendererWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Renderer), typeof(Component), null);
		L.RegFunction("SetPropertyBlock", new LuaCSFunction(UnityEngine_RendererWrap.SetPropertyBlock));
		L.RegFunction("GetPropertyBlock", new LuaCSFunction(UnityEngine_RendererWrap.GetPropertyBlock));
		L.RegFunction("GetClosestReflectionProbes", new LuaCSFunction(UnityEngine_RendererWrap.GetClosestReflectionProbes));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_RendererWrap._CreateUnityEngine_Renderer));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_RendererWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("isPartOfStaticBatch", new LuaCSFunction(UnityEngine_RendererWrap.get_isPartOfStaticBatch), null);
		L.RegVar("worldToLocalMatrix", new LuaCSFunction(UnityEngine_RendererWrap.get_worldToLocalMatrix), null);
		L.RegVar("localToWorldMatrix", new LuaCSFunction(UnityEngine_RendererWrap.get_localToWorldMatrix), null);
		L.RegVar("enabled", new LuaCSFunction(UnityEngine_RendererWrap.get_enabled), new LuaCSFunction(UnityEngine_RendererWrap.set_enabled));
		L.RegVar("shadowCastingMode", new LuaCSFunction(UnityEngine_RendererWrap.get_shadowCastingMode), new LuaCSFunction(UnityEngine_RendererWrap.set_shadowCastingMode));
		L.RegVar("receiveShadows", new LuaCSFunction(UnityEngine_RendererWrap.get_receiveShadows), new LuaCSFunction(UnityEngine_RendererWrap.set_receiveShadows));
		L.RegVar("material", new LuaCSFunction(UnityEngine_RendererWrap.get_material), new LuaCSFunction(UnityEngine_RendererWrap.set_material));
		L.RegVar("sharedMaterial", new LuaCSFunction(UnityEngine_RendererWrap.get_sharedMaterial), new LuaCSFunction(UnityEngine_RendererWrap.set_sharedMaterial));
		L.RegVar("materials", new LuaCSFunction(UnityEngine_RendererWrap.get_materials), new LuaCSFunction(UnityEngine_RendererWrap.set_materials));
		L.RegVar("sharedMaterials", new LuaCSFunction(UnityEngine_RendererWrap.get_sharedMaterials), new LuaCSFunction(UnityEngine_RendererWrap.set_sharedMaterials));
		L.RegVar("bounds", new LuaCSFunction(UnityEngine_RendererWrap.get_bounds), null);
		L.RegVar("lightmapIndex", new LuaCSFunction(UnityEngine_RendererWrap.get_lightmapIndex), new LuaCSFunction(UnityEngine_RendererWrap.set_lightmapIndex));
		L.RegVar("realtimeLightmapIndex", new LuaCSFunction(UnityEngine_RendererWrap.get_realtimeLightmapIndex), new LuaCSFunction(UnityEngine_RendererWrap.set_realtimeLightmapIndex));
		L.RegVar("lightmapScaleOffset", new LuaCSFunction(UnityEngine_RendererWrap.get_lightmapScaleOffset), new LuaCSFunction(UnityEngine_RendererWrap.set_lightmapScaleOffset));
		L.RegVar("realtimeLightmapScaleOffset", new LuaCSFunction(UnityEngine_RendererWrap.get_realtimeLightmapScaleOffset), new LuaCSFunction(UnityEngine_RendererWrap.set_realtimeLightmapScaleOffset));
		L.RegVar("isVisible", new LuaCSFunction(UnityEngine_RendererWrap.get_isVisible), null);
		L.RegVar("useLightProbes", new LuaCSFunction(UnityEngine_RendererWrap.get_useLightProbes), new LuaCSFunction(UnityEngine_RendererWrap.set_useLightProbes));
		L.RegVar("probeAnchor", new LuaCSFunction(UnityEngine_RendererWrap.get_probeAnchor), new LuaCSFunction(UnityEngine_RendererWrap.set_probeAnchor));
		L.RegVar("reflectionProbeUsage", new LuaCSFunction(UnityEngine_RendererWrap.get_reflectionProbeUsage), new LuaCSFunction(UnityEngine_RendererWrap.set_reflectionProbeUsage));
		L.RegVar("sortingLayerName", new LuaCSFunction(UnityEngine_RendererWrap.get_sortingLayerName), new LuaCSFunction(UnityEngine_RendererWrap.set_sortingLayerName));
		L.RegVar("sortingLayerID", new LuaCSFunction(UnityEngine_RendererWrap.get_sortingLayerID), new LuaCSFunction(UnityEngine_RendererWrap.set_sortingLayerID));
		L.RegVar("sortingOrder", new LuaCSFunction(UnityEngine_RendererWrap.get_sortingOrder), new LuaCSFunction(UnityEngine_RendererWrap.set_sortingOrder));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Renderer(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Renderer obj = new Renderer();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Renderer.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPropertyBlock(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Renderer renderer = (Renderer)ToLua.CheckObject(L, 1, typeof(Renderer));
			MaterialPropertyBlock propertyBlock = (MaterialPropertyBlock)ToLua.CheckObject(L, 2, typeof(MaterialPropertyBlock));
			renderer.SetPropertyBlock(propertyBlock);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPropertyBlock(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Renderer renderer = (Renderer)ToLua.CheckObject(L, 1, typeof(Renderer));
			MaterialPropertyBlock dest = (MaterialPropertyBlock)ToLua.CheckObject(L, 2, typeof(MaterialPropertyBlock));
			renderer.GetPropertyBlock(dest);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClosestReflectionProbes(IntPtr L)
	{
		int result2;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Renderer renderer = (Renderer)ToLua.CheckObject(L, 1, typeof(Renderer));
			List<ReflectionProbeBlendInfo> result = (List<ReflectionProbeBlendInfo>)ToLua.CheckObject(L, 2, typeof(List<ReflectionProbeBlendInfo>));
			renderer.GetClosestReflectionProbes(result);
			result2 = 0;
		}
		catch (Exception e)
		{
			result2 = LuaDLL.toluaL_exception(L, e, null);
		}
		return result2;
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
	private static int get_isPartOfStaticBatch(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			bool isPartOfStaticBatch = renderer.isPartOfStaticBatch;
			LuaDLL.lua_pushboolean(L, isPartOfStaticBatch);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isPartOfStaticBatch on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldToLocalMatrix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Matrix4x4 worldToLocalMatrix = renderer.worldToLocalMatrix;
			ToLua.PushValue(L, worldToLocalMatrix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldToLocalMatrix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localToWorldMatrix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Matrix4x4 localToWorldMatrix = renderer.localToWorldMatrix;
			ToLua.PushValue(L, localToWorldMatrix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localToWorldMatrix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_enabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			bool enabled = renderer.enabled;
			LuaDLL.lua_pushboolean(L, enabled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shadowCastingMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			ShadowCastingMode shadowCastingMode = renderer.shadowCastingMode;
			ToLua.Push(L, shadowCastingMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowCastingMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_receiveShadows(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			bool receiveShadows = renderer.receiveShadows;
			LuaDLL.lua_pushboolean(L, receiveShadows);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index receiveShadows on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Material material = renderer.material;
			ToLua.Push(L, material);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sharedMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Material sharedMaterial = renderer.sharedMaterial;
			ToLua.Push(L, sharedMaterial);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sharedMaterial on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_materials(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Material[] materials = renderer.materials;
			ToLua.Push(L, materials);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index materials on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sharedMaterials(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Material[] sharedMaterials = renderer.sharedMaterials;
			ToLua.Push(L, sharedMaterials);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sharedMaterials on a nil value");
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
			Renderer renderer = (Renderer)obj;
			Bounds bounds = renderer.bounds;
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
	private static int get_lightmapIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			int lightmapIndex = renderer.lightmapIndex;
			LuaDLL.lua_pushinteger(L, lightmapIndex);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lightmapIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_realtimeLightmapIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			int realtimeLightmapIndex = renderer.realtimeLightmapIndex;
			LuaDLL.lua_pushinteger(L, realtimeLightmapIndex);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index realtimeLightmapIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lightmapScaleOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Vector4 lightmapScaleOffset = renderer.lightmapScaleOffset;
			ToLua.Push(L, lightmapScaleOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lightmapScaleOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_realtimeLightmapScaleOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Vector4 realtimeLightmapScaleOffset = renderer.realtimeLightmapScaleOffset;
			ToLua.Push(L, realtimeLightmapScaleOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index realtimeLightmapScaleOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isVisible(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			bool isVisible = renderer.isVisible;
			LuaDLL.lua_pushboolean(L, isVisible);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isVisible on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useLightProbes(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			bool useLightProbes = renderer.useLightProbes;
			LuaDLL.lua_pushboolean(L, useLightProbes);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useLightProbes on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_probeAnchor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Transform probeAnchor = renderer.probeAnchor;
			ToLua.Push(L, probeAnchor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index probeAnchor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_reflectionProbeUsage(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			ReflectionProbeUsage reflectionProbeUsage = renderer.reflectionProbeUsage;
			ToLua.Push(L, reflectionProbeUsage);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index reflectionProbeUsage on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortingLayerName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			string sortingLayerName = renderer.sortingLayerName;
			LuaDLL.lua_pushstring(L, sortingLayerName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingLayerName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortingLayerID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			int sortingLayerID = renderer.sortingLayerID;
			LuaDLL.lua_pushinteger(L, sortingLayerID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingLayerID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortingOrder(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			int sortingOrder = renderer.sortingOrder;
			LuaDLL.lua_pushinteger(L, sortingOrder);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingOrder on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_enabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			bool enabled = LuaDLL.luaL_checkboolean(L, 2);
			renderer.enabled = enabled;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shadowCastingMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			ShadowCastingMode shadowCastingMode = (ShadowCastingMode)((int)ToLua.CheckObject(L, 2, typeof(ShadowCastingMode)));
			renderer.shadowCastingMode = shadowCastingMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowCastingMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_receiveShadows(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			bool receiveShadows = LuaDLL.luaL_checkboolean(L, 2);
			renderer.receiveShadows = receiveShadows;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index receiveShadows on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Material material = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			renderer.material = material;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sharedMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Material sharedMaterial = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			renderer.sharedMaterial = sharedMaterial;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sharedMaterial on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_materials(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Material[] materials = ToLua.CheckObjectArray<Material>(L, 2);
			renderer.materials = materials;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index materials on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sharedMaterials(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Material[] sharedMaterials = ToLua.CheckObjectArray<Material>(L, 2);
			renderer.sharedMaterials = sharedMaterials;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sharedMaterials on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lightmapIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			int lightmapIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			renderer.lightmapIndex = lightmapIndex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lightmapIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_realtimeLightmapIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			int realtimeLightmapIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			renderer.realtimeLightmapIndex = realtimeLightmapIndex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index realtimeLightmapIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lightmapScaleOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Vector4 lightmapScaleOffset = ToLua.ToVector4(L, 2);
			renderer.lightmapScaleOffset = lightmapScaleOffset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lightmapScaleOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_realtimeLightmapScaleOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Vector4 realtimeLightmapScaleOffset = ToLua.ToVector4(L, 2);
			renderer.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index realtimeLightmapScaleOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useLightProbes(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			bool useLightProbes = LuaDLL.luaL_checkboolean(L, 2);
			renderer.useLightProbes = useLightProbes;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useLightProbes on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_probeAnchor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			Transform probeAnchor = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			renderer.probeAnchor = probeAnchor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index probeAnchor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_reflectionProbeUsage(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			ReflectionProbeUsage reflectionProbeUsage = (ReflectionProbeUsage)((int)ToLua.CheckObject(L, 2, typeof(ReflectionProbeUsage)));
			renderer.reflectionProbeUsage = reflectionProbeUsage;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index reflectionProbeUsage on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sortingLayerName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			string sortingLayerName = ToLua.CheckString(L, 2);
			renderer.sortingLayerName = sortingLayerName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingLayerName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sortingLayerID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			int sortingLayerID = (int)LuaDLL.luaL_checknumber(L, 2);
			renderer.sortingLayerID = sortingLayerID;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingLayerID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sortingOrder(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Renderer renderer = (Renderer)obj;
			int sortingOrder = (int)LuaDLL.luaL_checknumber(L, 2);
			renderer.sortingOrder = sortingOrder;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingOrder on a nil value");
		}
		return result;
	}
}
