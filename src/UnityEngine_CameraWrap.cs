using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Rendering;

public class UnityEngine_CameraWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Camera), typeof(Behaviour), null);
		L.RegFunction("SetTargetBuffers", new LuaCSFunction(UnityEngine_CameraWrap.SetTargetBuffers));
		L.RegFunction("ResetWorldToCameraMatrix", new LuaCSFunction(UnityEngine_CameraWrap.ResetWorldToCameraMatrix));
		L.RegFunction("ResetProjectionMatrix", new LuaCSFunction(UnityEngine_CameraWrap.ResetProjectionMatrix));
		L.RegFunction("ResetAspect", new LuaCSFunction(UnityEngine_CameraWrap.ResetAspect));
		L.RegFunction("WorldToScreenPoint", new LuaCSFunction(UnityEngine_CameraWrap.WorldToScreenPoint));
		L.RegFunction("WorldToViewportPoint", new LuaCSFunction(UnityEngine_CameraWrap.WorldToViewportPoint));
		L.RegFunction("ViewportToWorldPoint", new LuaCSFunction(UnityEngine_CameraWrap.ViewportToWorldPoint));
		L.RegFunction("ScreenToWorldPoint", new LuaCSFunction(UnityEngine_CameraWrap.ScreenToWorldPoint));
		L.RegFunction("ScreenToViewportPoint", new LuaCSFunction(UnityEngine_CameraWrap.ScreenToViewportPoint));
		L.RegFunction("ViewportToScreenPoint", new LuaCSFunction(UnityEngine_CameraWrap.ViewportToScreenPoint));
		L.RegFunction("ViewportPointToRay", new LuaCSFunction(UnityEngine_CameraWrap.ViewportPointToRay));
		L.RegFunction("ScreenPointToRay", new LuaCSFunction(UnityEngine_CameraWrap.ScreenPointToRay));
		L.RegFunction("GetAllCameras", new LuaCSFunction(UnityEngine_CameraWrap.GetAllCameras));
		L.RegFunction("Render", new LuaCSFunction(UnityEngine_CameraWrap.Render));
		L.RegFunction("RenderWithShader", new LuaCSFunction(UnityEngine_CameraWrap.RenderWithShader));
		L.RegFunction("SetReplacementShader", new LuaCSFunction(UnityEngine_CameraWrap.SetReplacementShader));
		L.RegFunction("ResetReplacementShader", new LuaCSFunction(UnityEngine_CameraWrap.ResetReplacementShader));
		L.RegFunction("RenderDontRestore", new LuaCSFunction(UnityEngine_CameraWrap.RenderDontRestore));
		L.RegFunction("SetupCurrent", new LuaCSFunction(UnityEngine_CameraWrap.SetupCurrent));
		L.RegFunction("RenderToCubemap", new LuaCSFunction(UnityEngine_CameraWrap.RenderToCubemap));
		L.RegFunction("CopyFrom", new LuaCSFunction(UnityEngine_CameraWrap.CopyFrom));
		L.RegFunction("AddCommandBuffer", new LuaCSFunction(UnityEngine_CameraWrap.AddCommandBuffer));
		L.RegFunction("RemoveCommandBuffer", new LuaCSFunction(UnityEngine_CameraWrap.RemoveCommandBuffer));
		L.RegFunction("RemoveCommandBuffers", new LuaCSFunction(UnityEngine_CameraWrap.RemoveCommandBuffers));
		L.RegFunction("RemoveAllCommandBuffers", new LuaCSFunction(UnityEngine_CameraWrap.RemoveAllCommandBuffers));
		L.RegFunction("GetCommandBuffers", new LuaCSFunction(UnityEngine_CameraWrap.GetCommandBuffers));
		L.RegFunction("CalculateObliqueMatrix", new LuaCSFunction(UnityEngine_CameraWrap.CalculateObliqueMatrix));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_CameraWrap._CreateUnityEngine_Camera));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_CameraWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("onPreCull", new LuaCSFunction(UnityEngine_CameraWrap.get_onPreCull), new LuaCSFunction(UnityEngine_CameraWrap.set_onPreCull));
		L.RegVar("onPreRender", new LuaCSFunction(UnityEngine_CameraWrap.get_onPreRender), new LuaCSFunction(UnityEngine_CameraWrap.set_onPreRender));
		L.RegVar("onPostRender", new LuaCSFunction(UnityEngine_CameraWrap.get_onPostRender), new LuaCSFunction(UnityEngine_CameraWrap.set_onPostRender));
		L.RegVar("fieldOfView", new LuaCSFunction(UnityEngine_CameraWrap.get_fieldOfView), new LuaCSFunction(UnityEngine_CameraWrap.set_fieldOfView));
		L.RegVar("nearClipPlane", new LuaCSFunction(UnityEngine_CameraWrap.get_nearClipPlane), new LuaCSFunction(UnityEngine_CameraWrap.set_nearClipPlane));
		L.RegVar("farClipPlane", new LuaCSFunction(UnityEngine_CameraWrap.get_farClipPlane), new LuaCSFunction(UnityEngine_CameraWrap.set_farClipPlane));
		L.RegVar("renderingPath", new LuaCSFunction(UnityEngine_CameraWrap.get_renderingPath), new LuaCSFunction(UnityEngine_CameraWrap.set_renderingPath));
		L.RegVar("actualRenderingPath", new LuaCSFunction(UnityEngine_CameraWrap.get_actualRenderingPath), null);
		L.RegVar("hdr", new LuaCSFunction(UnityEngine_CameraWrap.get_hdr), new LuaCSFunction(UnityEngine_CameraWrap.set_hdr));
		L.RegVar("orthographicSize", new LuaCSFunction(UnityEngine_CameraWrap.get_orthographicSize), new LuaCSFunction(UnityEngine_CameraWrap.set_orthographicSize));
		L.RegVar("orthographic", new LuaCSFunction(UnityEngine_CameraWrap.get_orthographic), new LuaCSFunction(UnityEngine_CameraWrap.set_orthographic));
		L.RegVar("opaqueSortMode", new LuaCSFunction(UnityEngine_CameraWrap.get_opaqueSortMode), new LuaCSFunction(UnityEngine_CameraWrap.set_opaqueSortMode));
		L.RegVar("transparencySortMode", new LuaCSFunction(UnityEngine_CameraWrap.get_transparencySortMode), new LuaCSFunction(UnityEngine_CameraWrap.set_transparencySortMode));
		L.RegVar("depth", new LuaCSFunction(UnityEngine_CameraWrap.get_depth), new LuaCSFunction(UnityEngine_CameraWrap.set_depth));
		L.RegVar("aspect", new LuaCSFunction(UnityEngine_CameraWrap.get_aspect), new LuaCSFunction(UnityEngine_CameraWrap.set_aspect));
		L.RegVar("cullingMask", new LuaCSFunction(UnityEngine_CameraWrap.get_cullingMask), new LuaCSFunction(UnityEngine_CameraWrap.set_cullingMask));
		L.RegVar("eventMask", new LuaCSFunction(UnityEngine_CameraWrap.get_eventMask), new LuaCSFunction(UnityEngine_CameraWrap.set_eventMask));
		L.RegVar("backgroundColor", new LuaCSFunction(UnityEngine_CameraWrap.get_backgroundColor), new LuaCSFunction(UnityEngine_CameraWrap.set_backgroundColor));
		L.RegVar("rect", new LuaCSFunction(UnityEngine_CameraWrap.get_rect), new LuaCSFunction(UnityEngine_CameraWrap.set_rect));
		L.RegVar("pixelRect", new LuaCSFunction(UnityEngine_CameraWrap.get_pixelRect), new LuaCSFunction(UnityEngine_CameraWrap.set_pixelRect));
		L.RegVar("targetTexture", new LuaCSFunction(UnityEngine_CameraWrap.get_targetTexture), new LuaCSFunction(UnityEngine_CameraWrap.set_targetTexture));
		L.RegVar("pixelWidth", new LuaCSFunction(UnityEngine_CameraWrap.get_pixelWidth), null);
		L.RegVar("pixelHeight", new LuaCSFunction(UnityEngine_CameraWrap.get_pixelHeight), null);
		L.RegVar("cameraToWorldMatrix", new LuaCSFunction(UnityEngine_CameraWrap.get_cameraToWorldMatrix), null);
		L.RegVar("worldToCameraMatrix", new LuaCSFunction(UnityEngine_CameraWrap.get_worldToCameraMatrix), new LuaCSFunction(UnityEngine_CameraWrap.set_worldToCameraMatrix));
		L.RegVar("projectionMatrix", new LuaCSFunction(UnityEngine_CameraWrap.get_projectionMatrix), new LuaCSFunction(UnityEngine_CameraWrap.set_projectionMatrix));
		L.RegVar("velocity", new LuaCSFunction(UnityEngine_CameraWrap.get_velocity), null);
		L.RegVar("clearFlags", new LuaCSFunction(UnityEngine_CameraWrap.get_clearFlags), new LuaCSFunction(UnityEngine_CameraWrap.set_clearFlags));
		L.RegVar("stereoEnabled", new LuaCSFunction(UnityEngine_CameraWrap.get_stereoEnabled), null);
		L.RegVar("stereoSeparation", new LuaCSFunction(UnityEngine_CameraWrap.get_stereoSeparation), new LuaCSFunction(UnityEngine_CameraWrap.set_stereoSeparation));
		L.RegVar("stereoConvergence", new LuaCSFunction(UnityEngine_CameraWrap.get_stereoConvergence), new LuaCSFunction(UnityEngine_CameraWrap.set_stereoConvergence));
		L.RegVar("cameraType", new LuaCSFunction(UnityEngine_CameraWrap.get_cameraType), new LuaCSFunction(UnityEngine_CameraWrap.set_cameraType));
		L.RegVar("stereoMirrorMode", new LuaCSFunction(UnityEngine_CameraWrap.get_stereoMirrorMode), new LuaCSFunction(UnityEngine_CameraWrap.set_stereoMirrorMode));
		L.RegVar("targetDisplay", new LuaCSFunction(UnityEngine_CameraWrap.get_targetDisplay), new LuaCSFunction(UnityEngine_CameraWrap.set_targetDisplay));
		L.RegVar("main", new LuaCSFunction(UnityEngine_CameraWrap.get_main), null);
		L.RegVar("current", new LuaCSFunction(UnityEngine_CameraWrap.get_current), null);
		L.RegVar("allCameras", new LuaCSFunction(UnityEngine_CameraWrap.get_allCameras), null);
		L.RegVar("allCamerasCount", new LuaCSFunction(UnityEngine_CameraWrap.get_allCamerasCount), null);
		L.RegVar("useOcclusionCulling", new LuaCSFunction(UnityEngine_CameraWrap.get_useOcclusionCulling), new LuaCSFunction(UnityEngine_CameraWrap.set_useOcclusionCulling));
		L.RegVar("layerCullDistances", new LuaCSFunction(UnityEngine_CameraWrap.get_layerCullDistances), new LuaCSFunction(UnityEngine_CameraWrap.set_layerCullDistances));
		L.RegVar("layerCullSpherical", new LuaCSFunction(UnityEngine_CameraWrap.get_layerCullSpherical), new LuaCSFunction(UnityEngine_CameraWrap.set_layerCullSpherical));
		L.RegVar("depthTextureMode", new LuaCSFunction(UnityEngine_CameraWrap.get_depthTextureMode), new LuaCSFunction(UnityEngine_CameraWrap.set_depthTextureMode));
		L.RegVar("clearStencilAfterLightingPass", new LuaCSFunction(UnityEngine_CameraWrap.get_clearStencilAfterLightingPass), new LuaCSFunction(UnityEngine_CameraWrap.set_clearStencilAfterLightingPass));
		L.RegVar("commandBufferCount", new LuaCSFunction(UnityEngine_CameraWrap.get_commandBufferCount), null);
		L.RegFunction("CameraCallback", new LuaCSFunction(UnityEngine_CameraWrap.UnityEngine_Camera_CameraCallback));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Camera(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Camera obj = new Camera();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Camera.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTargetBuffers(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(RenderBuffer[]), typeof(RenderBuffer)))
			{
				Camera camera = (Camera)ToLua.ToObject(L, 1);
				RenderBuffer[] colorBuffer = ToLua.CheckObjectArray<RenderBuffer>(L, 2);
				RenderBuffer depthBuffer = (RenderBuffer)ToLua.ToObject(L, 3);
				camera.SetTargetBuffers(colorBuffer, depthBuffer);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(RenderBuffer), typeof(RenderBuffer)))
			{
				Camera camera2 = (Camera)ToLua.ToObject(L, 1);
				RenderBuffer colorBuffer2 = (RenderBuffer)ToLua.ToObject(L, 2);
				RenderBuffer depthBuffer2 = (RenderBuffer)ToLua.ToObject(L, 3);
				camera2.SetTargetBuffers(colorBuffer2, depthBuffer2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Camera.SetTargetBuffers");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetWorldToCameraMatrix(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			camera.ResetWorldToCameraMatrix();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetProjectionMatrix(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			camera.ResetProjectionMatrix();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetAspect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			camera.ResetAspect();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WorldToScreenPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Vector3 position = ToLua.ToVector3(L, 2);
			Vector3 v = camera.WorldToScreenPoint(position);
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
	private static int WorldToViewportPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Vector3 position = ToLua.ToVector3(L, 2);
			Vector3 v = camera.WorldToViewportPoint(position);
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
	private static int ViewportToWorldPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Vector3 position = ToLua.ToVector3(L, 2);
			Vector3 v = camera.ViewportToWorldPoint(position);
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
	private static int ScreenToWorldPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Vector3 position = ToLua.ToVector3(L, 2);
			Vector3 v = camera.ScreenToWorldPoint(position);
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
	private static int ScreenToViewportPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Vector3 position = ToLua.ToVector3(L, 2);
			Vector3 v = camera.ScreenToViewportPoint(position);
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
	private static int ViewportToScreenPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Vector3 position = ToLua.ToVector3(L, 2);
			Vector3 v = camera.ViewportToScreenPoint(position);
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
	private static int ViewportPointToRay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Vector3 position = ToLua.ToVector3(L, 2);
			Ray ray = camera.ViewportPointToRay(position);
			ToLua.Push(L, ray);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ScreenPointToRay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Vector3 position = ToLua.ToVector3(L, 2);
			Ray ray = camera.ScreenPointToRay(position);
			ToLua.Push(L, ray);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAllCameras(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Camera[] cameras = ToLua.CheckObjectArray<Camera>(L, 1);
			int allCameras = Camera.GetAllCameras(cameras);
			LuaDLL.lua_pushinteger(L, allCameras);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Render(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			camera.Render();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RenderWithShader(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Shader shader = (Shader)ToLua.CheckUnityObject(L, 2, typeof(Shader));
			string replacementTag = ToLua.CheckString(L, 3);
			camera.RenderWithShader(shader, replacementTag);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetReplacementShader(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Shader shader = (Shader)ToLua.CheckUnityObject(L, 2, typeof(Shader));
			string replacementTag = ToLua.CheckString(L, 3);
			camera.SetReplacementShader(shader, replacementTag);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetReplacementShader(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			camera.ResetReplacementShader();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RenderDontRestore(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			camera.RenderDontRestore();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetupCurrent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Camera cur = (Camera)ToLua.CheckUnityObject(L, 1, typeof(Camera));
			Camera.SetupCurrent(cur);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RenderToCubemap(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(RenderTexture)))
			{
				Camera camera = (Camera)ToLua.ToObject(L, 1);
				RenderTexture cubemap = (RenderTexture)ToLua.ToObject(L, 2);
				bool value = camera.RenderToCubemap(cubemap);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(Cubemap)))
			{
				Camera camera2 = (Camera)ToLua.ToObject(L, 1);
				Cubemap cubemap2 = (Cubemap)ToLua.ToObject(L, 2);
				bool value2 = camera2.RenderToCubemap(cubemap2);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(RenderTexture), typeof(int)))
			{
				Camera camera3 = (Camera)ToLua.ToObject(L, 1);
				RenderTexture cubemap3 = (RenderTexture)ToLua.ToObject(L, 2);
				int faceMask = (int)LuaDLL.lua_tonumber(L, 3);
				bool value3 = camera3.RenderToCubemap(cubemap3, faceMask);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(Cubemap), typeof(int)))
			{
				Camera camera4 = (Camera)ToLua.ToObject(L, 1);
				Cubemap cubemap4 = (Cubemap)ToLua.ToObject(L, 2);
				int faceMask2 = (int)LuaDLL.lua_tonumber(L, 3);
				bool value4 = camera4.RenderToCubemap(cubemap4, faceMask2);
				LuaDLL.lua_pushboolean(L, value4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Camera.RenderToCubemap");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyFrom(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Camera other = (Camera)ToLua.CheckUnityObject(L, 2, typeof(Camera));
			camera.CopyFrom(other);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddCommandBuffer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			CameraEvent evt = (CameraEvent)((int)ToLua.CheckObject(L, 2, typeof(CameraEvent)));
			CommandBuffer buffer = (CommandBuffer)ToLua.CheckObject(L, 3, typeof(CommandBuffer));
			camera.AddCommandBuffer(evt, buffer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveCommandBuffer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			CameraEvent evt = (CameraEvent)((int)ToLua.CheckObject(L, 2, typeof(CameraEvent)));
			CommandBuffer buffer = (CommandBuffer)ToLua.CheckObject(L, 3, typeof(CommandBuffer));
			camera.RemoveCommandBuffer(evt, buffer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveCommandBuffers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			CameraEvent evt = (CameraEvent)((int)ToLua.CheckObject(L, 2, typeof(CameraEvent)));
			camera.RemoveCommandBuffers(evt);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveAllCommandBuffers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			camera.RemoveAllCommandBuffers();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCommandBuffers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			CameraEvent evt = (CameraEvent)((int)ToLua.CheckObject(L, 2, typeof(CameraEvent)));
			CommandBuffer[] commandBuffers = camera.GetCommandBuffers(evt);
			ToLua.Push(L, commandBuffers);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateObliqueMatrix(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckObject(L, 1, typeof(Camera));
			Vector4 clipPlane = ToLua.ToVector4(L, 2);
			Matrix4x4 matrix4x = camera.CalculateObliqueMatrix(clipPlane);
			ToLua.PushValue(L, matrix4x);
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
	private static int get_onPreCull(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Camera.onPreCull);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onPreRender(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Camera.onPreRender);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onPostRender(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Camera.onPostRender);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fieldOfView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float fieldOfView = camera.fieldOfView;
			LuaDLL.lua_pushnumber(L, (double)fieldOfView);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fieldOfView on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_nearClipPlane(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float nearClipPlane = camera.nearClipPlane;
			LuaDLL.lua_pushnumber(L, (double)nearClipPlane);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index nearClipPlane on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_farClipPlane(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float farClipPlane = camera.farClipPlane;
			LuaDLL.lua_pushnumber(L, (double)farClipPlane);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index farClipPlane on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_renderingPath(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			RenderingPath renderingPath = camera.renderingPath;
			ToLua.Push(L, renderingPath);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderingPath on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_actualRenderingPath(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			RenderingPath actualRenderingPath = camera.actualRenderingPath;
			ToLua.Push(L, actualRenderingPath);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index actualRenderingPath on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hdr(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool hdr = camera.hdr;
			LuaDLL.lua_pushboolean(L, hdr);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hdr on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_orthographicSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float orthographicSize = camera.orthographicSize;
			LuaDLL.lua_pushnumber(L, (double)orthographicSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index orthographicSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_orthographic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool orthographic = camera.orthographic;
			LuaDLL.lua_pushboolean(L, orthographic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index orthographic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_opaqueSortMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			OpaqueSortMode opaqueSortMode = camera.opaqueSortMode;
			ToLua.Push(L, opaqueSortMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index opaqueSortMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_transparencySortMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			TransparencySortMode transparencySortMode = camera.transparencySortMode;
			ToLua.Push(L, transparencySortMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index transparencySortMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float depth = camera.depth;
			LuaDLL.lua_pushnumber(L, (double)depth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_aspect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float aspect = camera.aspect;
			LuaDLL.lua_pushnumber(L, (double)aspect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index aspect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cullingMask(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			int cullingMask = camera.cullingMask;
			LuaDLL.lua_pushinteger(L, cullingMask);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullingMask on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventMask(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			int eventMask = camera.eventMask;
			LuaDLL.lua_pushinteger(L, eventMask);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventMask on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_backgroundColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Color backgroundColor = camera.backgroundColor;
			ToLua.Push(L, backgroundColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index backgroundColor on a nil value");
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
			Camera camera = (Camera)obj;
			Rect rect = camera.rect;
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
	private static int get_pixelRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Rect pixelRect = camera.pixelRect;
			ToLua.PushValue(L, pixelRect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelRect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			RenderTexture targetTexture = camera.targetTexture;
			ToLua.Push(L, targetTexture);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetTexture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			int pixelWidth = camera.pixelWidth;
			LuaDLL.lua_pushinteger(L, pixelWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			int pixelHeight = camera.pixelHeight;
			LuaDLL.lua_pushinteger(L, pixelHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cameraToWorldMatrix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Matrix4x4 cameraToWorldMatrix = camera.cameraToWorldMatrix;
			ToLua.PushValue(L, cameraToWorldMatrix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cameraToWorldMatrix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldToCameraMatrix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Matrix4x4 worldToCameraMatrix = camera.worldToCameraMatrix;
			ToLua.PushValue(L, worldToCameraMatrix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldToCameraMatrix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_projectionMatrix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Matrix4x4 projectionMatrix = camera.projectionMatrix;
			ToLua.PushValue(L, projectionMatrix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index projectionMatrix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_velocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Vector3 velocity = camera.velocity;
			ToLua.Push(L, velocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index velocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clearFlags(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			CameraClearFlags clearFlags = camera.clearFlags;
			ToLua.Push(L, clearFlags);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clearFlags on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stereoEnabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool stereoEnabled = camera.stereoEnabled;
			LuaDLL.lua_pushboolean(L, stereoEnabled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stereoEnabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stereoSeparation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float stereoSeparation = camera.stereoSeparation;
			LuaDLL.lua_pushnumber(L, (double)stereoSeparation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stereoSeparation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stereoConvergence(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float stereoConvergence = camera.stereoConvergence;
			LuaDLL.lua_pushnumber(L, (double)stereoConvergence);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stereoConvergence on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cameraType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			CameraType cameraType = camera.cameraType;
			ToLua.Push(L, cameraType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cameraType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stereoMirrorMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool stereoMirrorMode = camera.stereoMirrorMode;
			LuaDLL.lua_pushboolean(L, stereoMirrorMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stereoMirrorMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetDisplay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			int targetDisplay = camera.targetDisplay;
			LuaDLL.lua_pushinteger(L, targetDisplay);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetDisplay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_main(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Camera.main);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_current(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Camera.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_allCameras(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Camera.allCameras);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_allCamerasCount(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Camera.allCamerasCount);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useOcclusionCulling(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool useOcclusionCulling = camera.useOcclusionCulling;
			LuaDLL.lua_pushboolean(L, useOcclusionCulling);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useOcclusionCulling on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_layerCullDistances(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float[] layerCullDistances = camera.layerCullDistances;
			ToLua.Push(L, layerCullDistances);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layerCullDistances on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_layerCullSpherical(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool layerCullSpherical = camera.layerCullSpherical;
			LuaDLL.lua_pushboolean(L, layerCullSpherical);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layerCullSpherical on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depthTextureMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			DepthTextureMode depthTextureMode = camera.depthTextureMode;
			ToLua.Push(L, depthTextureMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depthTextureMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clearStencilAfterLightingPass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool clearStencilAfterLightingPass = camera.clearStencilAfterLightingPass;
			LuaDLL.lua_pushboolean(L, clearStencilAfterLightingPass);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clearStencilAfterLightingPass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_commandBufferCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			int commandBufferCount = camera.commandBufferCount;
			LuaDLL.lua_pushinteger(L, commandBufferCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index commandBufferCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onPreCull(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Camera.CameraCallback onPreCull;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPreCull = (Camera.CameraCallback)ToLua.CheckObject(L, 2, typeof(Camera.CameraCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPreCull = (DelegateFactory.CreateDelegate(typeof(Camera.CameraCallback), func) as Camera.CameraCallback);
			}
			Camera.onPreCull = onPreCull;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onPreRender(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Camera.CameraCallback onPreRender;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPreRender = (Camera.CameraCallback)ToLua.CheckObject(L, 2, typeof(Camera.CameraCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPreRender = (DelegateFactory.CreateDelegate(typeof(Camera.CameraCallback), func) as Camera.CameraCallback);
			}
			Camera.onPreRender = onPreRender;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onPostRender(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Camera.CameraCallback onPostRender;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPostRender = (Camera.CameraCallback)ToLua.CheckObject(L, 2, typeof(Camera.CameraCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPostRender = (DelegateFactory.CreateDelegate(typeof(Camera.CameraCallback), func) as Camera.CameraCallback);
			}
			Camera.onPostRender = onPostRender;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fieldOfView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float fieldOfView = (float)LuaDLL.luaL_checknumber(L, 2);
			camera.fieldOfView = fieldOfView;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fieldOfView on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_nearClipPlane(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float nearClipPlane = (float)LuaDLL.luaL_checknumber(L, 2);
			camera.nearClipPlane = nearClipPlane;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index nearClipPlane on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_farClipPlane(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float farClipPlane = (float)LuaDLL.luaL_checknumber(L, 2);
			camera.farClipPlane = farClipPlane;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index farClipPlane on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_renderingPath(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			RenderingPath renderingPath = (RenderingPath)((int)ToLua.CheckObject(L, 2, typeof(RenderingPath)));
			camera.renderingPath = renderingPath;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderingPath on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hdr(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool hdr = LuaDLL.luaL_checkboolean(L, 2);
			camera.hdr = hdr;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hdr on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_orthographicSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float orthographicSize = (float)LuaDLL.luaL_checknumber(L, 2);
			camera.orthographicSize = orthographicSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index orthographicSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_orthographic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool orthographic = LuaDLL.luaL_checkboolean(L, 2);
			camera.orthographic = orthographic;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index orthographic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_opaqueSortMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			OpaqueSortMode opaqueSortMode = (OpaqueSortMode)((int)ToLua.CheckObject(L, 2, typeof(OpaqueSortMode)));
			camera.opaqueSortMode = opaqueSortMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index opaqueSortMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_transparencySortMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			TransparencySortMode transparencySortMode = (TransparencySortMode)((int)ToLua.CheckObject(L, 2, typeof(TransparencySortMode)));
			camera.transparencySortMode = transparencySortMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index transparencySortMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float depth = (float)LuaDLL.luaL_checknumber(L, 2);
			camera.depth = depth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_aspect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float aspect = (float)LuaDLL.luaL_checknumber(L, 2);
			camera.aspect = aspect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index aspect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cullingMask(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			int cullingMask = (int)LuaDLL.luaL_checknumber(L, 2);
			camera.cullingMask = cullingMask;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullingMask on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventMask(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			int eventMask = (int)LuaDLL.luaL_checknumber(L, 2);
			camera.eventMask = eventMask;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventMask on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_backgroundColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Color backgroundColor = ToLua.ToColor(L, 2);
			camera.backgroundColor = backgroundColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index backgroundColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Rect rect = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			camera.rect = rect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pixelRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Rect pixelRect = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			camera.pixelRect = pixelRect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelRect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			RenderTexture targetTexture = (RenderTexture)ToLua.CheckUnityObject(L, 2, typeof(RenderTexture));
			camera.targetTexture = targetTexture;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetTexture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_worldToCameraMatrix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Matrix4x4 worldToCameraMatrix = (Matrix4x4)ToLua.CheckObject(L, 2, typeof(Matrix4x4));
			camera.worldToCameraMatrix = worldToCameraMatrix;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldToCameraMatrix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_projectionMatrix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			Matrix4x4 projectionMatrix = (Matrix4x4)ToLua.CheckObject(L, 2, typeof(Matrix4x4));
			camera.projectionMatrix = projectionMatrix;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index projectionMatrix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clearFlags(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			CameraClearFlags clearFlags = (CameraClearFlags)((int)ToLua.CheckObject(L, 2, typeof(CameraClearFlags)));
			camera.clearFlags = clearFlags;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clearFlags on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stereoSeparation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float stereoSeparation = (float)LuaDLL.luaL_checknumber(L, 2);
			camera.stereoSeparation = stereoSeparation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stereoSeparation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stereoConvergence(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float stereoConvergence = (float)LuaDLL.luaL_checknumber(L, 2);
			camera.stereoConvergence = stereoConvergence;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stereoConvergence on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cameraType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			CameraType cameraType = (CameraType)((int)ToLua.CheckObject(L, 2, typeof(CameraType)));
			camera.cameraType = cameraType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cameraType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stereoMirrorMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool stereoMirrorMode = LuaDLL.luaL_checkboolean(L, 2);
			camera.stereoMirrorMode = stereoMirrorMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stereoMirrorMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetDisplay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			int targetDisplay = (int)LuaDLL.luaL_checknumber(L, 2);
			camera.targetDisplay = targetDisplay;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetDisplay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useOcclusionCulling(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool useOcclusionCulling = LuaDLL.luaL_checkboolean(L, 2);
			camera.useOcclusionCulling = useOcclusionCulling;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useOcclusionCulling on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_layerCullDistances(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			float[] layerCullDistances = ToLua.CheckNumberArray<float>(L, 2);
			camera.layerCullDistances = layerCullDistances;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layerCullDistances on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_layerCullSpherical(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool layerCullSpherical = LuaDLL.luaL_checkboolean(L, 2);
			camera.layerCullSpherical = layerCullSpherical;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layerCullSpherical on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_depthTextureMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			DepthTextureMode depthTextureMode = (DepthTextureMode)((int)ToLua.CheckObject(L, 2, typeof(DepthTextureMode)));
			camera.depthTextureMode = depthTextureMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depthTextureMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clearStencilAfterLightingPass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Camera camera = (Camera)obj;
			bool clearStencilAfterLightingPass = LuaDLL.luaL_checkboolean(L, 2);
			camera.clearStencilAfterLightingPass = clearStencilAfterLightingPass;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clearStencilAfterLightingPass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_Camera_CameraCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Camera.CameraCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Camera.CameraCallback), func, self);
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
