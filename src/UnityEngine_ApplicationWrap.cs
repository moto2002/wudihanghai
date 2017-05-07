using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_ApplicationWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("Application");
		L.RegFunction("Quit", new LuaCSFunction(UnityEngine_ApplicationWrap.Quit));
		L.RegFunction("CancelQuit", new LuaCSFunction(UnityEngine_ApplicationWrap.CancelQuit));
		L.RegFunction("LoadLevel", new LuaCSFunction(UnityEngine_ApplicationWrap.LoadLevel));
		L.RegFunction("LoadLevelAsync", new LuaCSFunction(UnityEngine_ApplicationWrap.LoadLevelAsync));
		L.RegFunction("LoadLevelAdditiveAsync", new LuaCSFunction(UnityEngine_ApplicationWrap.LoadLevelAdditiveAsync));
		L.RegFunction("UnloadLevel", new LuaCSFunction(UnityEngine_ApplicationWrap.UnloadLevel));
		L.RegFunction("LoadLevelAdditive", new LuaCSFunction(UnityEngine_ApplicationWrap.LoadLevelAdditive));
		L.RegFunction("GetStreamProgressForLevel", new LuaCSFunction(UnityEngine_ApplicationWrap.GetStreamProgressForLevel));
		L.RegFunction("CanStreamedLevelBeLoaded", new LuaCSFunction(UnityEngine_ApplicationWrap.CanStreamedLevelBeLoaded));
		L.RegFunction("CaptureScreenshot", new LuaCSFunction(UnityEngine_ApplicationWrap.CaptureScreenshot));
		L.RegFunction("HasProLicense", new LuaCSFunction(UnityEngine_ApplicationWrap.HasProLicense));
		L.RegFunction("ExternalCall", new LuaCSFunction(UnityEngine_ApplicationWrap.ExternalCall));
		L.RegFunction("OpenURL", new LuaCSFunction(UnityEngine_ApplicationWrap.OpenURL));
		L.RegFunction("RequestUserAuthorization", new LuaCSFunction(UnityEngine_ApplicationWrap.RequestUserAuthorization));
		L.RegFunction("HasUserAuthorization", new LuaCSFunction(UnityEngine_ApplicationWrap.HasUserAuthorization));
		L.RegVar("loadedLevel", new LuaCSFunction(UnityEngine_ApplicationWrap.get_loadedLevel), null);
		L.RegVar("loadedLevelName", new LuaCSFunction(UnityEngine_ApplicationWrap.get_loadedLevelName), null);
		L.RegVar("levelCount", new LuaCSFunction(UnityEngine_ApplicationWrap.get_levelCount), null);
		L.RegVar("streamedBytes", new LuaCSFunction(UnityEngine_ApplicationWrap.get_streamedBytes), null);
		L.RegVar("isPlaying", new LuaCSFunction(UnityEngine_ApplicationWrap.get_isPlaying), null);
		L.RegVar("isEditor", new LuaCSFunction(UnityEngine_ApplicationWrap.get_isEditor), null);
		L.RegVar("isWebPlayer", new LuaCSFunction(UnityEngine_ApplicationWrap.get_isWebPlayer), null);
		L.RegVar("platform", new LuaCSFunction(UnityEngine_ApplicationWrap.get_platform), null);
		L.RegVar("isMobilePlatform", new LuaCSFunction(UnityEngine_ApplicationWrap.get_isMobilePlatform), null);
		L.RegVar("isConsolePlatform", new LuaCSFunction(UnityEngine_ApplicationWrap.get_isConsolePlatform), null);
		L.RegVar("runInBackground", new LuaCSFunction(UnityEngine_ApplicationWrap.get_runInBackground), new LuaCSFunction(UnityEngine_ApplicationWrap.set_runInBackground));
		L.RegVar("dataPath", new LuaCSFunction(UnityEngine_ApplicationWrap.get_dataPath), null);
		L.RegVar("streamingAssetsPath", new LuaCSFunction(UnityEngine_ApplicationWrap.get_streamingAssetsPath), null);
		L.RegVar("persistentDataPath", new LuaCSFunction(UnityEngine_ApplicationWrap.get_persistentDataPath), null);
		L.RegVar("temporaryCachePath", new LuaCSFunction(UnityEngine_ApplicationWrap.get_temporaryCachePath), null);
		L.RegVar("srcValue", new LuaCSFunction(UnityEngine_ApplicationWrap.get_srcValue), null);
		L.RegVar("absoluteURL", new LuaCSFunction(UnityEngine_ApplicationWrap.get_absoluteURL), null);
		L.RegVar("unityVersion", new LuaCSFunction(UnityEngine_ApplicationWrap.get_unityVersion), null);
		L.RegVar("version", new LuaCSFunction(UnityEngine_ApplicationWrap.get_version), null);
		L.RegVar("bundleIdentifier", new LuaCSFunction(UnityEngine_ApplicationWrap.get_bundleIdentifier), null);
		L.RegVar("installMode", new LuaCSFunction(UnityEngine_ApplicationWrap.get_installMode), null);
		L.RegVar("sandboxType", new LuaCSFunction(UnityEngine_ApplicationWrap.get_sandboxType), null);
		L.RegVar("productName", new LuaCSFunction(UnityEngine_ApplicationWrap.get_productName), null);
		L.RegVar("companyName", new LuaCSFunction(UnityEngine_ApplicationWrap.get_companyName), null);
		L.RegVar("cloudProjectId", new LuaCSFunction(UnityEngine_ApplicationWrap.get_cloudProjectId), null);
		L.RegVar("webSecurityEnabled", new LuaCSFunction(UnityEngine_ApplicationWrap.get_webSecurityEnabled), null);
		L.RegVar("webSecurityHostUrl", new LuaCSFunction(UnityEngine_ApplicationWrap.get_webSecurityHostUrl), null);
		L.RegVar("targetFrameRate", new LuaCSFunction(UnityEngine_ApplicationWrap.get_targetFrameRate), new LuaCSFunction(UnityEngine_ApplicationWrap.set_targetFrameRate));
		L.RegVar("systemLanguage", new LuaCSFunction(UnityEngine_ApplicationWrap.get_systemLanguage), null);
		L.RegVar("stackTraceLogType", new LuaCSFunction(UnityEngine_ApplicationWrap.get_stackTraceLogType), new LuaCSFunction(UnityEngine_ApplicationWrap.set_stackTraceLogType));
		L.RegVar("backgroundLoadingPriority", new LuaCSFunction(UnityEngine_ApplicationWrap.get_backgroundLoadingPriority), new LuaCSFunction(UnityEngine_ApplicationWrap.set_backgroundLoadingPriority));
		L.RegVar("internetReachability", new LuaCSFunction(UnityEngine_ApplicationWrap.get_internetReachability), null);
		L.RegVar("genuine", new LuaCSFunction(UnityEngine_ApplicationWrap.get_genuine), null);
		L.RegVar("genuineCheckAvailable", new LuaCSFunction(UnityEngine_ApplicationWrap.get_genuineCheckAvailable), null);
		L.RegVar("isShowingSplashScreen", new LuaCSFunction(UnityEngine_ApplicationWrap.get_isShowingSplashScreen), null);
		L.RegVar("logMessageReceived", new LuaCSFunction(UnityEngine_ApplicationWrap.get_logMessageReceived), new LuaCSFunction(UnityEngine_ApplicationWrap.set_logMessageReceived));
		L.RegVar("logMessageReceivedThreaded", new LuaCSFunction(UnityEngine_ApplicationWrap.get_logMessageReceivedThreaded), new LuaCSFunction(UnityEngine_ApplicationWrap.set_logMessageReceivedThreaded));
		L.RegFunction("LogCallback", new LuaCSFunction(UnityEngine_ApplicationWrap.UnityEngine_Application_LogCallback));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Quit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Application.Quit();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CancelQuit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Application.CancelQuit();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadLevel(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string name = ToLua.ToString(L, 1);
				Application.LoadLevel(name);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int index = (int)LuaDLL.lua_tonumber(L, 1);
				Application.LoadLevel(index);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Application.LoadLevel");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadLevelAsync(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string levelName = ToLua.ToString(L, 1);
				AsyncOperation o = Application.LoadLevelAsync(levelName);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int index = (int)LuaDLL.lua_tonumber(L, 1);
				AsyncOperation o2 = Application.LoadLevelAsync(index);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Application.LoadLevelAsync");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadLevelAdditiveAsync(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string levelName = ToLua.ToString(L, 1);
				AsyncOperation o = Application.LoadLevelAdditiveAsync(levelName);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int index = (int)LuaDLL.lua_tonumber(L, 1);
				AsyncOperation o2 = Application.LoadLevelAdditiveAsync(index);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Application.LoadLevelAdditiveAsync");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnloadLevel(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string scenePath = ToLua.ToString(L, 1);
				bool value = Application.UnloadLevel(scenePath);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int index = (int)LuaDLL.lua_tonumber(L, 1);
				bool value2 = Application.UnloadLevel(index);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Application.UnloadLevel");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadLevelAdditive(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string name = ToLua.ToString(L, 1);
				Application.LoadLevelAdditive(name);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int index = (int)LuaDLL.lua_tonumber(L, 1);
				Application.LoadLevelAdditive(index);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Application.LoadLevelAdditive");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStreamProgressForLevel(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string levelName = ToLua.ToString(L, 1);
				float streamProgressForLevel = Application.GetStreamProgressForLevel(levelName);
				LuaDLL.lua_pushnumber(L, (double)streamProgressForLevel);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int levelIndex = (int)LuaDLL.lua_tonumber(L, 1);
				float streamProgressForLevel2 = Application.GetStreamProgressForLevel(levelIndex);
				LuaDLL.lua_pushnumber(L, (double)streamProgressForLevel2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Application.GetStreamProgressForLevel");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CanStreamedLevelBeLoaded(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string levelName = ToLua.ToString(L, 1);
				bool value = Application.CanStreamedLevelBeLoaded(levelName);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int levelIndex = (int)LuaDLL.lua_tonumber(L, 1);
				bool value2 = Application.CanStreamedLevelBeLoaded(levelIndex);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Application.CanStreamedLevelBeLoaded");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CaptureScreenshot(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string filename = ToLua.ToString(L, 1);
				Application.CaptureScreenshot(filename);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string filename2 = ToLua.ToString(L, 1);
				int superSize = (int)LuaDLL.lua_tonumber(L, 2);
				Application.CaptureScreenshot(filename2, superSize);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Application.CaptureScreenshot");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasProLicense(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			bool value = Application.HasProLicense();
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
	private static int ExternalCall(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			string functionName = ToLua.CheckString(L, 1);
			object[] args = ToLua.ToParamsObject(L, 2, num - 1);
			Application.ExternalCall(functionName, args);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OpenURL(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string url = ToLua.CheckString(L, 1);
			Application.OpenURL(url);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RequestUserAuthorization(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UserAuthorization mode = (UserAuthorization)((int)ToLua.CheckObject(L, 1, typeof(UserAuthorization)));
			AsyncOperation o = Application.RequestUserAuthorization(mode);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasUserAuthorization(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UserAuthorization mode = (UserAuthorization)((int)ToLua.CheckObject(L, 1, typeof(UserAuthorization)));
			bool value = Application.HasUserAuthorization(mode);
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
	private static int get_loadedLevel(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Application.loadedLevel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_loadedLevelName(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.loadedLevelName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_levelCount(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Application.levelCount);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_streamedBytes(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Application.streamedBytes);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPlaying(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Application.isPlaying);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isEditor(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Application.isEditor);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isWebPlayer(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Application.isWebPlayer);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_platform(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Application.platform);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isMobilePlatform(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Application.isMobilePlatform);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isConsolePlatform(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Application.isConsolePlatform);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_runInBackground(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Application.runInBackground);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dataPath(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.dataPath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_streamingAssetsPath(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.streamingAssetsPath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_persistentDataPath(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.persistentDataPath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_temporaryCachePath(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.temporaryCachePath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_srcValue(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.srcValue);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_absoluteURL(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.absoluteURL);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_unityVersion(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.unityVersion);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_version(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.version);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bundleIdentifier(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.bundleIdentifier);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_installMode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Application.installMode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sandboxType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Application.sandboxType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_productName(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.productName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_companyName(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.companyName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cloudProjectId(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.cloudProjectId);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_webSecurityEnabled(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Application.webSecurityEnabled);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_webSecurityHostUrl(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Application.webSecurityHostUrl);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetFrameRate(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Application.targetFrameRate);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_systemLanguage(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Application.systemLanguage);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stackTraceLogType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Application.stackTraceLogType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_backgroundLoadingPriority(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Application.backgroundLoadingPriority);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_internetReachability(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Application.internetReachability);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_genuine(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Application.genuine);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_genuineCheckAvailable(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Application.genuineCheckAvailable);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isShowingSplashScreen(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Application.isShowingSplashScreen);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_logMessageReceived(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.logMessageReceived"));
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_logMessageReceivedThreaded(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.logMessageReceivedThreaded"));
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_runInBackground(IntPtr L)
	{
		int result;
		try
		{
			bool runInBackground = LuaDLL.luaL_checkboolean(L, 2);
			Application.runInBackground = runInBackground;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetFrameRate(IntPtr L)
	{
		int result;
		try
		{
			int targetFrameRate = (int)LuaDLL.luaL_checknumber(L, 2);
			Application.targetFrameRate = targetFrameRate;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stackTraceLogType(IntPtr L)
	{
		int result;
		try
		{
			StackTraceLogType stackTraceLogType = (StackTraceLogType)((int)ToLua.CheckObject(L, 2, typeof(StackTraceLogType)));
			Application.stackTraceLogType = stackTraceLogType;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_backgroundLoadingPriority(IntPtr L)
	{
		int result;
		try
		{
			ThreadPriority backgroundLoadingPriority = (ThreadPriority)((int)ToLua.CheckObject(L, 2, typeof(ThreadPriority)));
			Application.backgroundLoadingPriority = backgroundLoadingPriority;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_logMessageReceived(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				EventObject eventObject = (EventObject)ToLua.ToObject(L, 2);
				if (eventObject.op == EventOp.Add)
				{
					Application.LogCallback value = (Application.LogCallback)DelegateFactory.CreateDelegate(typeof(Application.LogCallback), eventObject.func);
					Application.logMessageReceived += value;
				}
				else if (eventObject.op == EventOp.Sub)
				{
					Application.LogCallback logCallback = (Application.LogCallback)LuaMisc.GetEventHandler(null, typeof(Application), "logMessageReceived");
					Delegate[] invocationList = logCallback.GetInvocationList();
					LuaState luaState = LuaState.Get(L);
					for (int i = 0; i < invocationList.Length; i++)
					{
						logCallback = (Application.LogCallback)invocationList[i];
						LuaDelegate luaDelegate = logCallback.Target as LuaDelegate;
						if (luaDelegate != null && luaDelegate.func == eventObject.func)
						{
							Application.logMessageReceived -= logCallback;
							luaState.DelayDispose(luaDelegate.func);
							break;
						}
					}
					eventObject.func.Dispose();
				}
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.logMessageReceived' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_logMessageReceivedThreaded(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				EventObject eventObject = (EventObject)ToLua.ToObject(L, 2);
				if (eventObject.op == EventOp.Add)
				{
					Application.LogCallback value = (Application.LogCallback)DelegateFactory.CreateDelegate(typeof(Application.LogCallback), eventObject.func);
					Application.logMessageReceivedThreaded += value;
				}
				else if (eventObject.op == EventOp.Sub)
				{
					Application.LogCallback logCallback = (Application.LogCallback)LuaMisc.GetEventHandler(null, typeof(Application), "logMessageReceivedThreaded");
					Delegate[] invocationList = logCallback.GetInvocationList();
					LuaState luaState = LuaState.Get(L);
					for (int i = 0; i < invocationList.Length; i++)
					{
						logCallback = (Application.LogCallback)invocationList[i];
						LuaDelegate luaDelegate = logCallback.Target as LuaDelegate;
						if (luaDelegate != null && luaDelegate.func == eventObject.func)
						{
							Application.logMessageReceivedThreaded -= logCallback;
							luaState.DelayDispose(luaDelegate.func);
							break;
						}
					}
					eventObject.func.Dispose();
				}
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.logMessageReceivedThreaded' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_Application_LogCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Application.LogCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Application.LogCallback), func, self);
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
