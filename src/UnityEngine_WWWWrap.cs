using LuaInterface;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UnityEngine_WWWWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(WWW), typeof(object), null);
		L.RegFunction("Dispose", new LuaCSFunction(UnityEngine_WWWWrap.Dispose));
		L.RegFunction("InitWWW", new LuaCSFunction(UnityEngine_WWWWrap.InitWWW));
		L.RegFunction("EscapeURL", new LuaCSFunction(UnityEngine_WWWWrap.EscapeURL));
		L.RegFunction("UnEscapeURL", new LuaCSFunction(UnityEngine_WWWWrap.UnEscapeURL));
		L.RegFunction("GetAudioClip", new LuaCSFunction(UnityEngine_WWWWrap.GetAudioClip));
		L.RegFunction("GetAudioClipCompressed", new LuaCSFunction(UnityEngine_WWWWrap.GetAudioClipCompressed));
		L.RegFunction("LoadImageIntoTexture", new LuaCSFunction(UnityEngine_WWWWrap.LoadImageIntoTexture));
		L.RegFunction("LoadFromCacheOrDownload", new LuaCSFunction(UnityEngine_WWWWrap.LoadFromCacheOrDownload));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_WWWWrap._CreateUnityEngine_WWW));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("responseHeaders", new LuaCSFunction(UnityEngine_WWWWrap.get_responseHeaders), null);
		L.RegVar("text", new LuaCSFunction(UnityEngine_WWWWrap.get_text), null);
		L.RegVar("bytes", new LuaCSFunction(UnityEngine_WWWWrap.get_bytes), null);
		L.RegVar("size", new LuaCSFunction(UnityEngine_WWWWrap.get_size), null);
		L.RegVar("error", new LuaCSFunction(UnityEngine_WWWWrap.get_error), null);
		L.RegVar("texture", new LuaCSFunction(UnityEngine_WWWWrap.get_texture), null);
		L.RegVar("textureNonReadable", new LuaCSFunction(UnityEngine_WWWWrap.get_textureNonReadable), null);
		L.RegVar("audioClip", new LuaCSFunction(UnityEngine_WWWWrap.get_audioClip), null);
		L.RegVar("isDone", new LuaCSFunction(UnityEngine_WWWWrap.get_isDone), null);
		L.RegVar("progress", new LuaCSFunction(UnityEngine_WWWWrap.get_progress), null);
		L.RegVar("uploadProgress", new LuaCSFunction(UnityEngine_WWWWrap.get_uploadProgress), null);
		L.RegVar("bytesDownloaded", new LuaCSFunction(UnityEngine_WWWWrap.get_bytesDownloaded), null);
		L.RegVar("url", new LuaCSFunction(UnityEngine_WWWWrap.get_url), null);
		L.RegVar("assetBundle", new LuaCSFunction(UnityEngine_WWWWrap.get_assetBundle), null);
		L.RegVar("threadPriority", new LuaCSFunction(UnityEngine_WWWWrap.get_threadPriority), new LuaCSFunction(UnityEngine_WWWWrap.set_threadPriority));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_WWW(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				string url = ToLua.CheckString(L, 1);
				WWW o = new WWW(url);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(byte[])))
			{
				string url2 = ToLua.CheckString(L, 1);
				byte[] postData = ToLua.CheckByteBuffer(L, 2);
				WWW o2 = new WWW(url2, postData);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(WWWForm)))
			{
				string url3 = ToLua.CheckString(L, 1);
				WWWForm form = (WWWForm)ToLua.CheckObject(L, 2, typeof(WWWForm));
				WWW o3 = new WWW(url3, form);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(byte[]), typeof(Dictionary<string, string>)))
			{
				string url4 = ToLua.CheckString(L, 1);
				byte[] postData2 = ToLua.CheckByteBuffer(L, 2);
				Dictionary<string, string> headers = (Dictionary<string, string>)ToLua.CheckObject(L, 3, typeof(Dictionary<string, string>));
				WWW o4 = new WWW(url4, postData2, headers);
				ToLua.PushObject(L, o4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.WWW.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Dispose(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			WWW wWW = (WWW)ToLua.CheckObject(L, 1, typeof(WWW));
			wWW.Dispose();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitWWW(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			WWW wWW = (WWW)ToLua.CheckObject(L, 1, typeof(WWW));
			string url = ToLua.CheckString(L, 2);
			byte[] postData = ToLua.CheckByteBuffer(L, 3);
			string[] iHeaders = ToLua.CheckStringArray(L, 4);
			wWW.InitWWW(url, postData, iHeaders);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EscapeURL(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string s = ToLua.ToString(L, 1);
				string str = WWW.EscapeURL(s);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(Encoding)))
			{
				string s2 = ToLua.ToString(L, 1);
				Encoding e = (Encoding)ToLua.ToObject(L, 2);
				string str2 = WWW.EscapeURL(s2, e);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.WWW.EscapeURL");
			}
		}
		catch (Exception e2)
		{
			result = LuaDLL.toluaL_exception(L, e2, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnEscapeURL(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string s = ToLua.ToString(L, 1);
				string str = WWW.UnEscapeURL(s);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(Encoding)))
			{
				string s2 = ToLua.ToString(L, 1);
				Encoding e = (Encoding)ToLua.ToObject(L, 2);
				string str2 = WWW.UnEscapeURL(s2, e);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.WWW.UnEscapeURL");
			}
		}
		catch (Exception e2)
		{
			result = LuaDLL.toluaL_exception(L, e2, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAudioClip(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(WWW), typeof(bool)))
			{
				WWW wWW = (WWW)ToLua.ToObject(L, 1);
				bool threeD = LuaDLL.lua_toboolean(L, 2);
				AudioClip audioClip = wWW.GetAudioClip(threeD);
				ToLua.Push(L, audioClip);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(WWW), typeof(bool), typeof(bool)))
			{
				WWW wWW2 = (WWW)ToLua.ToObject(L, 1);
				bool threeD2 = LuaDLL.lua_toboolean(L, 2);
				bool stream = LuaDLL.lua_toboolean(L, 3);
				AudioClip audioClip2 = wWW2.GetAudioClip(threeD2, stream);
				ToLua.Push(L, audioClip2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(WWW), typeof(bool), typeof(bool), typeof(AudioType)))
			{
				WWW wWW3 = (WWW)ToLua.ToObject(L, 1);
				bool threeD3 = LuaDLL.lua_toboolean(L, 2);
				bool stream2 = LuaDLL.lua_toboolean(L, 3);
				AudioType audioType = (AudioType)((int)ToLua.ToObject(L, 4));
				AudioClip audioClip3 = wWW3.GetAudioClip(threeD3, stream2, audioType);
				ToLua.Push(L, audioClip3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.WWW.GetAudioClip");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAudioClipCompressed(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(WWW)))
			{
				WWW wWW = (WWW)ToLua.ToObject(L, 1);
				AudioClip audioClipCompressed = wWW.GetAudioClipCompressed();
				ToLua.Push(L, audioClipCompressed);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(WWW), typeof(bool)))
			{
				WWW wWW2 = (WWW)ToLua.ToObject(L, 1);
				bool threeD = LuaDLL.lua_toboolean(L, 2);
				AudioClip audioClipCompressed2 = wWW2.GetAudioClipCompressed(threeD);
				ToLua.Push(L, audioClipCompressed2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(WWW), typeof(bool), typeof(AudioType)))
			{
				WWW wWW3 = (WWW)ToLua.ToObject(L, 1);
				bool threeD2 = LuaDLL.lua_toboolean(L, 2);
				AudioType audioType = (AudioType)((int)ToLua.ToObject(L, 3));
				AudioClip audioClipCompressed3 = wWW3.GetAudioClipCompressed(threeD2, audioType);
				ToLua.Push(L, audioClipCompressed3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.WWW.GetAudioClipCompressed");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadImageIntoTexture(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			WWW wWW = (WWW)ToLua.CheckObject(L, 1, typeof(WWW));
			Texture2D tex = (Texture2D)ToLua.CheckUnityObject(L, 2, typeof(Texture2D));
			wWW.LoadImageIntoTexture(tex);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadFromCacheOrDownload(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(Hash128)))
			{
				string url = ToLua.ToString(L, 1);
				Hash128 hash = (Hash128)ToLua.ToObject(L, 2);
				WWW o = WWW.LoadFromCacheOrDownload(url, hash);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string url2 = ToLua.ToString(L, 1);
				int version = (int)LuaDLL.lua_tonumber(L, 2);
				WWW o2 = WWW.LoadFromCacheOrDownload(url2, version);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(Hash128), typeof(uint)))
			{
				string url3 = ToLua.ToString(L, 1);
				Hash128 hash2 = (Hash128)ToLua.ToObject(L, 2);
				uint crc = (uint)LuaDLL.lua_tonumber(L, 3);
				WWW o3 = WWW.LoadFromCacheOrDownload(url3, hash2, crc);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(uint)))
			{
				string url4 = ToLua.ToString(L, 1);
				int version2 = (int)LuaDLL.lua_tonumber(L, 2);
				uint crc2 = (uint)LuaDLL.lua_tonumber(L, 3);
				WWW o4 = WWW.LoadFromCacheOrDownload(url4, version2, crc2);
				ToLua.PushObject(L, o4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.WWW.LoadFromCacheOrDownload");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_responseHeaders(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			Dictionary<string, string> responseHeaders = wWW.responseHeaders;
			ToLua.PushObject(L, responseHeaders);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index responseHeaders on a nil value");
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
			WWW wWW = (WWW)obj;
			string text = wWW.text;
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
	private static int get_bytes(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			byte[] bytes = wWW.bytes;
			ToLua.Push(L, bytes);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bytes on a nil value");
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
			WWW wWW = (WWW)obj;
			int size = wWW.size;
			LuaDLL.lua_pushinteger(L, size);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index size on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_error(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			string error = wWW.error;
			LuaDLL.lua_pushstring(L, error);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index error on a nil value");
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
			WWW wWW = (WWW)obj;
			Texture2D texture = wWW.texture;
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
	private static int get_textureNonReadable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			Texture2D textureNonReadable = wWW.textureNonReadable;
			ToLua.Push(L, textureNonReadable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index textureNonReadable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_audioClip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			AudioClip audioClip = wWW.audioClip;
			ToLua.Push(L, audioClip);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index audioClip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isDone(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			bool isDone = wWW.isDone;
			LuaDLL.lua_pushboolean(L, isDone);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isDone on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_progress(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			float progress = wWW.progress;
			LuaDLL.lua_pushnumber(L, (double)progress);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index progress on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_uploadProgress(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			float uploadProgress = wWW.uploadProgress;
			LuaDLL.lua_pushnumber(L, (double)uploadProgress);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uploadProgress on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bytesDownloaded(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			int bytesDownloaded = wWW.bytesDownloaded;
			LuaDLL.lua_pushinteger(L, bytesDownloaded);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bytesDownloaded on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_url(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			string url = wWW.url;
			LuaDLL.lua_pushstring(L, url);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index url on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_assetBundle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			AssetBundle assetBundle = wWW.assetBundle;
			ToLua.Push(L, assetBundle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index assetBundle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_threadPriority(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			ThreadPriority threadPriority = wWW.threadPriority;
			ToLua.Push(L, threadPriority);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index threadPriority on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_threadPriority(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WWW wWW = (WWW)obj;
			ThreadPriority threadPriority = (ThreadPriority)((int)ToLua.CheckObject(L, 2, typeof(ThreadPriority)));
			wWW.threadPriority = threadPriority;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index threadPriority on a nil value");
		}
		return result;
	}
}
