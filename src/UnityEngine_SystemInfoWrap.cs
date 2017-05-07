using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_SystemInfoWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SystemInfo), typeof(object), null);
		L.RegFunction("SupportsRenderTextureFormat", new LuaCSFunction(UnityEngine_SystemInfoWrap.SupportsRenderTextureFormat));
		L.RegFunction("SupportsTextureFormat", new LuaCSFunction(UnityEngine_SystemInfoWrap.SupportsTextureFormat));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_SystemInfoWrap._CreateUnityEngine_SystemInfo));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("operatingSystem", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_operatingSystem), null);
		L.RegVar("processorType", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_processorType), null);
		L.RegVar("processorCount", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_processorCount), null);
		L.RegVar("systemMemorySize", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_systemMemorySize), null);
		L.RegVar("graphicsMemorySize", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_graphicsMemorySize), null);
		L.RegVar("graphicsDeviceName", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_graphicsDeviceName), null);
		L.RegVar("graphicsDeviceVendor", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_graphicsDeviceVendor), null);
		L.RegVar("graphicsDeviceID", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_graphicsDeviceID), null);
		L.RegVar("graphicsDeviceVendorID", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_graphicsDeviceVendorID), null);
		L.RegVar("graphicsDeviceType", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_graphicsDeviceType), null);
		L.RegVar("graphicsDeviceVersion", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_graphicsDeviceVersion), null);
		L.RegVar("graphicsShaderLevel", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_graphicsShaderLevel), null);
		L.RegVar("graphicsMultiThreaded", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_graphicsMultiThreaded), null);
		L.RegVar("supportsShadows", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsShadows), null);
		L.RegVar("supportsRenderTextures", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsRenderTextures), null);
		L.RegVar("supportsRenderToCubemap", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsRenderToCubemap), null);
		L.RegVar("supportsImageEffects", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsImageEffects), null);
		L.RegVar("supports3DTextures", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supports3DTextures), null);
		L.RegVar("supportsComputeShaders", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsComputeShaders), null);
		L.RegVar("supportsInstancing", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsInstancing), null);
		L.RegVar("supportsSparseTextures", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsSparseTextures), null);
		L.RegVar("supportedRenderTargetCount", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportedRenderTargetCount), null);
		L.RegVar("supportsStencil", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsStencil), null);
		L.RegVar("npotSupport", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_npotSupport), null);
		L.RegVar("deviceUniqueIdentifier", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_deviceUniqueIdentifier), null);
		L.RegVar("deviceName", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_deviceName), null);
		L.RegVar("deviceModel", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_deviceModel), null);
		L.RegVar("supportsAccelerometer", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsAccelerometer), null);
		L.RegVar("supportsGyroscope", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsGyroscope), null);
		L.RegVar("supportsLocationService", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsLocationService), null);
		L.RegVar("supportsVibration", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_supportsVibration), null);
		L.RegVar("deviceType", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_deviceType), null);
		L.RegVar("maxTextureSize", new LuaCSFunction(UnityEngine_SystemInfoWrap.get_maxTextureSize), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_SystemInfo(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				SystemInfo o = new SystemInfo();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.SystemInfo.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SupportsRenderTextureFormat(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RenderTextureFormat format = (RenderTextureFormat)((int)ToLua.CheckObject(L, 1, typeof(RenderTextureFormat)));
			bool value = SystemInfo.SupportsRenderTextureFormat(format);
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
	private static int SupportsTextureFormat(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TextureFormat format = (TextureFormat)((int)ToLua.CheckObject(L, 1, typeof(TextureFormat)));
			bool value = SystemInfo.SupportsTextureFormat(format);
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
	private static int get_operatingSystem(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, SystemInfo.operatingSystem);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_processorType(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, SystemInfo.processorType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_processorCount(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SystemInfo.processorCount);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_systemMemorySize(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SystemInfo.systemMemorySize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphicsMemorySize(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SystemInfo.graphicsMemorySize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphicsDeviceName(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, SystemInfo.graphicsDeviceName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphicsDeviceVendor(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, SystemInfo.graphicsDeviceVendor);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphicsDeviceID(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SystemInfo.graphicsDeviceID);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphicsDeviceVendorID(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SystemInfo.graphicsDeviceVendorID);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphicsDeviceType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, SystemInfo.graphicsDeviceType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphicsDeviceVersion(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, SystemInfo.graphicsDeviceVersion);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphicsShaderLevel(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SystemInfo.graphicsShaderLevel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphicsMultiThreaded(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.graphicsMultiThreaded);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsShadows(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsShadows);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsRenderTextures(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsRenderTextures);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsRenderToCubemap(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsRenderToCubemap);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsImageEffects(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsImageEffects);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supports3DTextures(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supports3DTextures);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsComputeShaders(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsComputeShaders);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsInstancing(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsInstancing);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsSparseTextures(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsSparseTextures);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportedRenderTargetCount(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SystemInfo.supportedRenderTargetCount);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsStencil(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SystemInfo.supportsStencil);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_npotSupport(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, SystemInfo.npotSupport);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_deviceUniqueIdentifier(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, SystemInfo.deviceUniqueIdentifier);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_deviceName(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, SystemInfo.deviceName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_deviceModel(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, SystemInfo.deviceModel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsAccelerometer(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsAccelerometer);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsGyroscope(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsGyroscope);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsLocationService(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsLocationService);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportsVibration(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, SystemInfo.supportsVibration);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_deviceType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, SystemInfo.deviceType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxTextureSize(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SystemInfo.maxTextureSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
