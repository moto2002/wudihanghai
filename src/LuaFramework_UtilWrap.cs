using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_UtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Util), typeof(object), null);
		L.RegFunction("Random", new LuaCSFunction(LuaFramework_UtilWrap.Random));
		L.RegFunction("GetTime", new LuaCSFunction(LuaFramework_UtilWrap.GetTime));
		L.RegFunction("OpenWebView", new LuaCSFunction(LuaFramework_UtilWrap.OpenWebView));
		L.RegFunction("OpenWebViewWithLocalFile", new LuaCSFunction(LuaFramework_UtilWrap.OpenWebViewWithLocalFile));
		L.RegFunction("CloseWebView", new LuaCSFunction(LuaFramework_UtilWrap.CloseWebView));
		L.RegFunction("SetUIDragDropEvent", new LuaCSFunction(LuaFramework_UtilWrap.SetUIDragDropEvent));
		L.RegFunction("SetUIColor", new LuaCSFunction(LuaFramework_UtilWrap.SetUIColor));
		L.RegFunction("Child", new LuaCSFunction(LuaFramework_UtilWrap.Child));
		L.RegFunction("Peer", new LuaCSFunction(LuaFramework_UtilWrap.Peer));
		L.RegFunction("md5", new LuaCSFunction(LuaFramework_UtilWrap.md5));
		L.RegFunction("md5file", new LuaCSFunction(LuaFramework_UtilWrap.md5file));
		L.RegFunction("ClearChild", new LuaCSFunction(LuaFramework_UtilWrap.ClearChild));
		L.RegFunction("ClearMemory", new LuaCSFunction(LuaFramework_UtilWrap.ClearMemory));
		L.RegFunction("GetRelativePath", new LuaCSFunction(LuaFramework_UtilWrap.GetRelativePath));
		L.RegFunction("GetFileText", new LuaCSFunction(LuaFramework_UtilWrap.GetFileText));
		L.RegFunction("AppContentPath", new LuaCSFunction(LuaFramework_UtilWrap.AppContentPath));
		L.RegFunction("Log", new LuaCSFunction(LuaFramework_UtilWrap.Log));
		L.RegFunction("LogWarning", new LuaCSFunction(LuaFramework_UtilWrap.LogWarning));
		L.RegFunction("LogError", new LuaCSFunction(LuaFramework_UtilWrap.LogError));
		L.RegFunction("CallMethod", new LuaCSFunction(LuaFramework_UtilWrap.CallMethod));
		L.RegFunction("GetKey", new LuaCSFunction(LuaFramework_UtilWrap.GetKey));
		L.RegFunction("GetInt", new LuaCSFunction(LuaFramework_UtilWrap.GetInt));
		L.RegFunction("HasKey", new LuaCSFunction(LuaFramework_UtilWrap.HasKey));
		L.RegFunction("SetInt", new LuaCSFunction(LuaFramework_UtilWrap.SetInt));
		L.RegFunction("GetString", new LuaCSFunction(LuaFramework_UtilWrap.GetString));
		L.RegFunction("SetString", new LuaCSFunction(LuaFramework_UtilWrap.SetString));
		L.RegFunction("RemoveData", new LuaCSFunction(LuaFramework_UtilWrap.RemoveData));
		L.RegFunction("ReadGameVersionInfo", new LuaCSFunction(LuaFramework_UtilWrap.ReadGameVersionInfo));
		L.RegFunction("AppendTimestampForUri", new LuaCSFunction(LuaFramework_UtilWrap.AppendTimestampForUri));
		L.RegFunction("GetAssetBundleName", new LuaCSFunction(LuaFramework_UtilWrap.GetAssetBundleName));
		L.RegFunction("GetPrefixInDownloadServer", new LuaCSFunction(LuaFramework_UtilWrap.GetPrefixInDownloadServer));
		L.RegFunction("DecompressProtoData", new LuaCSFunction(LuaFramework_UtilWrap.DecompressProtoData));
		L.RegFunction("SetLayer", new LuaCSFunction(LuaFramework_UtilWrap.SetLayer));
		L.RegFunction("UpdateModelShader", new LuaCSFunction(LuaFramework_UtilWrap.UpdateModelShader));
		L.RegFunction("ShakeScreenEffect", new LuaCSFunction(LuaFramework_UtilWrap.ShakeScreenEffect));
		L.RegFunction("SetAnimationTrigger", new LuaCSFunction(LuaFramework_UtilWrap.SetAnimationTrigger));
		L.RegFunction("SetAnimationClip", new LuaCSFunction(LuaFramework_UtilWrap.SetAnimationClip));
		L.RegFunction("SetAnimationClipSpeed", new LuaCSFunction(LuaFramework_UtilWrap.SetAnimationClipSpeed));
		L.RegFunction("SetCanTouch", new LuaCSFunction(LuaFramework_UtilWrap.SetCanTouch));
		L.RegFunction("GetCanTouch", new LuaCSFunction(LuaFramework_UtilWrap.GetCanTouch));
		L.RegFunction("ScreenPointToRay", new LuaCSFunction(LuaFramework_UtilWrap.ScreenPointToRay));
		L.RegFunction("ChangeMainSceneWater4Material", new LuaCSFunction(LuaFramework_UtilWrap.ChangeMainSceneWater4Material));
		L.RegFunction("SetUIElementCanvasGroupAlpha", new LuaCSFunction(LuaFramework_UtilWrap.SetUIElementCanvasGroupAlpha));
		L.RegFunction("GetXGPushToken", new LuaCSFunction(LuaFramework_UtilWrap.GetXGPushToken));
		L.RegFunction("GetPlatformName", new LuaCSFunction(LuaFramework_UtilWrap.GetPlatformName));
		L.RegFunction("GetCombineMeshGObj", new LuaCSFunction(LuaFramework_UtilWrap.GetCombineMeshGObj));
		L.RegFunction("GameObjectIsNull", new LuaCSFunction(LuaFramework_UtilWrap.GameObjectIsNull));
		L.RegFunction("New", new LuaCSFunction(LuaFramework_UtilWrap._CreateLuaFramework_Util));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("DataPath", new LuaCSFunction(LuaFramework_UtilWrap.get_DataPath), null);
		L.RegVar("NetAvailable", new LuaCSFunction(LuaFramework_UtilWrap.get_NetAvailable), null);
		L.RegVar("IsWifi", new LuaCSFunction(LuaFramework_UtilWrap.get_IsWifi), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLuaFramework_Util(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Util o = new Util();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: LuaFramework.Util.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Random(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float)))
			{
				float min = (float)LuaDLL.lua_tonumber(L, 1);
				float max = (float)LuaDLL.lua_tonumber(L, 2);
				float num2 = Util.Random(min, max);
				LuaDLL.lua_pushnumber(L, (double)num2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int)))
			{
				int min2 = (int)LuaDLL.lua_tonumber(L, 1);
				int max2 = (int)LuaDLL.lua_tonumber(L, 2);
				int n = Util.Random(min2, max2);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.Util.Random");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			long time = Util.GetTime();
			LuaDLL.tolua_pushint64(L, time);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OpenWebView(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string url = ToLua.CheckString(L, 1);
			Rect viewRect = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action<bool> completeCallback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				completeCallback = (Action<bool>)ToLua.CheckObject(L, 3, typeof(Action<bool>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				completeCallback = (DelegateFactory.CreateDelegate(typeof(Action<bool>), func) as Action<bool>);
			}
			Util.OpenWebView(url, viewRect, completeCallback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OpenWebViewWithLocalFile(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string filename = ToLua.CheckString(L, 1);
			Rect viewRect = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action<bool> completeCallback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				completeCallback = (Action<bool>)ToLua.CheckObject(L, 3, typeof(Action<bool>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				completeCallback = (DelegateFactory.CreateDelegate(typeof(Action<bool>), func) as Action<bool>);
			}
			Util.OpenWebViewWithLocalFile(filename, viewRect, completeCallback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CloseWebView(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Util.CloseWebView();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetUIDragDropEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			object param = ToLua.ToVarObject(L, 2);
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			Util.SetUIDragDropEvent(go, param, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetUIColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			int r = (int)LuaDLL.luaL_checknumber(L, 2);
			int g = (int)LuaDLL.luaL_checknumber(L, 3);
			int b = (int)LuaDLL.luaL_checknumber(L, 4);
			int a = (int)LuaDLL.luaL_checknumber(L, 5);
			Util.SetUIColor(go, r, g, b, a);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Child(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(string)))
			{
				Transform go = (Transform)ToLua.ToObject(L, 1);
				string subnode = ToLua.ToString(L, 2);
				GameObject obj = Util.Child(go, subnode);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				string subnode2 = ToLua.ToString(L, 2);
				GameObject obj2 = Util.Child(go2, subnode2);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.Util.Child");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Peer(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(string)))
			{
				Transform go = (Transform)ToLua.ToObject(L, 1);
				string subnode = ToLua.ToString(L, 2);
				GameObject obj = Util.Peer(go, subnode);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				string subnode2 = ToLua.ToString(L, 2);
				GameObject obj2 = Util.Peer(go2, subnode2);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.Util.Peer");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int md5(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string source = ToLua.CheckString(L, 1);
			string str = Util.md5(source);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int md5file(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string file = ToLua.CheckString(L, 1);
			string str = Util.md5file(file);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearChild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform go = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Util.ClearChild(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearMemory(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Util.ClearMemory();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRelativePath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string relativePath = Util.GetRelativePath();
			LuaDLL.lua_pushstring(L, relativePath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFileText(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			string fileText = Util.GetFileText(path);
			LuaDLL.lua_pushstring(L, fileText);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AppContentPath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string str = Util.AppContentPath();
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Log(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			Util.Log(str);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LogWarning(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			Util.LogWarning(str);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LogError(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			Util.LogError(str);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallMethod(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			string module = ToLua.CheckString(L, 1);
			string func = ToLua.CheckString(L, 2);
			object[] args = ToLua.ToParamsObject(L, 3, num - 2);
			object[] array = Util.CallMethod(module, func, args);
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			string key2 = Util.GetKey(key);
			LuaDLL.lua_pushstring(L, key2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			int @int = Util.GetInt(key);
			LuaDLL.lua_pushinteger(L, @int);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			bool value = Util.HasKey(key);
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
	private static int SetInt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string key = ToLua.CheckString(L, 1);
			int value = (int)LuaDLL.luaL_checknumber(L, 2);
			Util.SetInt(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			string @string = Util.GetString(key);
			LuaDLL.lua_pushstring(L, @string);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string key = ToLua.CheckString(L, 1);
			string value = ToLua.CheckString(L, 2);
			Util.SetString(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			Util.RemoveData(key);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadGameVersionInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Util.ReadGameVersionInfo();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AppendTimestampForUri(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string url = ToLua.CheckString(L, 1);
			string str = Util.AppendTimestampForUri(url);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAssetBundleName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string filePath = ToLua.CheckString(L, 1);
			string assetBundleName = Util.GetAssetBundleName(filePath);
			LuaDLL.lua_pushstring(L, assetBundleName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPrefixInDownloadServer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string prefixInDownloadServer = Util.GetPrefixInDownloadServer();
			LuaDLL.lua_pushstring(L, prefixInDownloadServer);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DecompressProtoData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			byte[] buffer = ToLua.CheckByteBuffer(L, 1);
			LuaFunction luaFunc = ToLua.CheckLuaFunction(L, 2);
			Util.DecompressProtoData(buffer, luaFunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string layerName = ToLua.CheckString(L, 2);
			Util.SetLayer(obj, layerName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateModelShader(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string shaderName = ToLua.CheckString(L, 2);
			Util.UpdateModelShader(go, shaderName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ShakeScreenEffect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			bool isShakeCamera = LuaDLL.luaL_checkboolean(L, 2);
			float shakeTime = (float)LuaDLL.luaL_checknumber(L, 3);
			float shakeDelta = (float)LuaDLL.luaL_checknumber(L, 4);
			Util.ShakeScreenEffect(go, isShakeCamera, shakeTime, shakeDelta);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAnimationTrigger(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string name = ToLua.CheckString(L, 2);
			Util.SetAnimationTrigger(go, name);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAnimationClip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string name = ToLua.CheckString(L, 2);
			Util.SetAnimationClip(go, name);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAnimationClipSpeed(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string name = ToLua.CheckString(L, 2);
			float speed = (float)LuaDLL.luaL_checknumber(L, 3);
			Util.SetAnimationClipSpeed(go, name, speed);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetCanTouch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			bool canTouch = LuaDLL.luaL_checkboolean(L, 1);
			Util.SetCanTouch(canTouch);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCanTouch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			bool canTouch = Util.GetCanTouch();
			LuaDLL.lua_pushboolean(L, canTouch);
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
			ToLua.CheckArgsCount(L, 3);
			Camera camera = (Camera)ToLua.CheckUnityObject(L, 1, typeof(Camera));
			Vector2 position = ToLua.ToVector2(L, 2);
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			Util.ScreenPointToRay(camera, position, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeMainSceneWater4Material(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject water4GObj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			Util.ChangeMainSceneWater4Material(water4GObj, index);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetUIElementCanvasGroupAlpha(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			float alpha = (float)LuaDLL.luaL_checknumber(L, 2);
			Util.SetUIElementCanvasGroupAlpha(go, alpha);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetXGPushToken(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string xGPushToken = Util.GetXGPushToken();
			LuaDLL.lua_pushstring(L, xGPushToken);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPlatformName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string platformName = Util.GetPlatformName();
			LuaDLL.lua_pushstring(L, platformName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCombineMeshGObj(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject[] beCombines = ToLua.CheckObjectArray<GameObject>(L, 1);
			GameObject combineMeshGObj = Util.GetCombineMeshGObj(beCombines);
			ToLua.Push(L, combineMeshGObj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GameObjectIsNull(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject gObj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			bool value = Util.GameObjectIsNull(gObj);
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
	private static int get_DataPath(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Util.DataPath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_NetAvailable(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Util.NetAvailable);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsWifi(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Util.IsWifi);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
