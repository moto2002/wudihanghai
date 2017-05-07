using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_ShaderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Shader), typeof(UnityEngine.Object), null);
		L.RegFunction("Find", new LuaCSFunction(UnityEngine_ShaderWrap.Find));
		L.RegFunction("EnableKeyword", new LuaCSFunction(UnityEngine_ShaderWrap.EnableKeyword));
		L.RegFunction("DisableKeyword", new LuaCSFunction(UnityEngine_ShaderWrap.DisableKeyword));
		L.RegFunction("IsKeywordEnabled", new LuaCSFunction(UnityEngine_ShaderWrap.IsKeywordEnabled));
		L.RegFunction("SetGlobalColor", new LuaCSFunction(UnityEngine_ShaderWrap.SetGlobalColor));
		L.RegFunction("SetGlobalVector", new LuaCSFunction(UnityEngine_ShaderWrap.SetGlobalVector));
		L.RegFunction("SetGlobalFloat", new LuaCSFunction(UnityEngine_ShaderWrap.SetGlobalFloat));
		L.RegFunction("SetGlobalInt", new LuaCSFunction(UnityEngine_ShaderWrap.SetGlobalInt));
		L.RegFunction("SetGlobalTexture", new LuaCSFunction(UnityEngine_ShaderWrap.SetGlobalTexture));
		L.RegFunction("SetGlobalMatrix", new LuaCSFunction(UnityEngine_ShaderWrap.SetGlobalMatrix));
		L.RegFunction("SetGlobalBuffer", new LuaCSFunction(UnityEngine_ShaderWrap.SetGlobalBuffer));
		L.RegFunction("PropertyToID", new LuaCSFunction(UnityEngine_ShaderWrap.PropertyToID));
		L.RegFunction("WarmupAllShaders", new LuaCSFunction(UnityEngine_ShaderWrap.WarmupAllShaders));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_ShaderWrap._CreateUnityEngine_Shader));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_ShaderWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("isSupported", new LuaCSFunction(UnityEngine_ShaderWrap.get_isSupported), null);
		L.RegVar("maximumLOD", new LuaCSFunction(UnityEngine_ShaderWrap.get_maximumLOD), new LuaCSFunction(UnityEngine_ShaderWrap.set_maximumLOD));
		L.RegVar("globalMaximumLOD", new LuaCSFunction(UnityEngine_ShaderWrap.get_globalMaximumLOD), new LuaCSFunction(UnityEngine_ShaderWrap.set_globalMaximumLOD));
		L.RegVar("renderQueue", new LuaCSFunction(UnityEngine_ShaderWrap.get_renderQueue), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Shader(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Shader obj = new Shader();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Shader.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Find(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string name = ToLua.CheckString(L, 1);
			Shader obj = Shader.Find(name);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EnableKeyword(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string keyword = ToLua.CheckString(L, 1);
			Shader.EnableKeyword(keyword);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DisableKeyword(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string keyword = ToLua.CheckString(L, 1);
			Shader.DisableKeyword(keyword);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsKeywordEnabled(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string keyword = ToLua.CheckString(L, 1);
			bool value = Shader.IsKeywordEnabled(keyword);
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
	private static int SetGlobalColor(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(Color)))
			{
				int nameID = (int)LuaDLL.lua_tonumber(L, 1);
				Color color = ToLua.ToColor(L, 2);
				Shader.SetGlobalColor(nameID, color);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(Color)))
			{
				string propertyName = ToLua.ToString(L, 1);
				Color color2 = ToLua.ToColor(L, 2);
				Shader.SetGlobalColor(propertyName, color2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Shader.SetGlobalColor");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGlobalVector(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(Vector4)))
			{
				int nameID = (int)LuaDLL.lua_tonumber(L, 1);
				Vector4 vec = ToLua.ToVector4(L, 2);
				Shader.SetGlobalVector(nameID, vec);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(Vector4)))
			{
				string propertyName = ToLua.ToString(L, 1);
				Vector4 vec2 = ToLua.ToVector4(L, 2);
				Shader.SetGlobalVector(propertyName, vec2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Shader.SetGlobalVector");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGlobalFloat(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(float)))
			{
				int nameID = (int)LuaDLL.lua_tonumber(L, 1);
				float value = (float)LuaDLL.lua_tonumber(L, 2);
				Shader.SetGlobalFloat(nameID, value);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(float)))
			{
				string propertyName = ToLua.ToString(L, 1);
				float value2 = (float)LuaDLL.lua_tonumber(L, 2);
				Shader.SetGlobalFloat(propertyName, value2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Shader.SetGlobalFloat");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGlobalInt(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int)))
			{
				int nameID = (int)LuaDLL.lua_tonumber(L, 1);
				int value = (int)LuaDLL.lua_tonumber(L, 2);
				Shader.SetGlobalInt(nameID, value);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string propertyName = ToLua.ToString(L, 1);
				int value2 = (int)LuaDLL.lua_tonumber(L, 2);
				Shader.SetGlobalInt(propertyName, value2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Shader.SetGlobalInt");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGlobalTexture(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(Texture)))
			{
				int nameID = (int)LuaDLL.lua_tonumber(L, 1);
				Texture tex = (Texture)ToLua.ToObject(L, 2);
				Shader.SetGlobalTexture(nameID, tex);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(Texture)))
			{
				string propertyName = ToLua.ToString(L, 1);
				Texture tex2 = (Texture)ToLua.ToObject(L, 2);
				Shader.SetGlobalTexture(propertyName, tex2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Shader.SetGlobalTexture");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGlobalMatrix(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(Matrix4x4)))
			{
				int nameID = (int)LuaDLL.lua_tonumber(L, 1);
				Matrix4x4 mat = (Matrix4x4)ToLua.ToObject(L, 2);
				Shader.SetGlobalMatrix(nameID, mat);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(Matrix4x4)))
			{
				string propertyName = ToLua.ToString(L, 1);
				Matrix4x4 mat2 = (Matrix4x4)ToLua.ToObject(L, 2);
				Shader.SetGlobalMatrix(propertyName, mat2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Shader.SetGlobalMatrix");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGlobalBuffer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string propertyName = ToLua.CheckString(L, 1);
			ComputeBuffer buffer = (ComputeBuffer)ToLua.CheckObject(L, 2, typeof(ComputeBuffer));
			Shader.SetGlobalBuffer(propertyName, buffer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PropertyToID(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string name = ToLua.CheckString(L, 1);
			int n = Shader.PropertyToID(name);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WarmupAllShaders(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Shader.WarmupAllShaders();
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
	private static int get_isSupported(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Shader shader = (Shader)obj;
			bool isSupported = shader.isSupported;
			LuaDLL.lua_pushboolean(L, isSupported);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isSupported on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maximumLOD(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Shader shader = (Shader)obj;
			int maximumLOD = shader.maximumLOD;
			LuaDLL.lua_pushinteger(L, maximumLOD);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maximumLOD on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_globalMaximumLOD(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Shader.globalMaximumLOD);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_renderQueue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Shader shader = (Shader)obj;
			int renderQueue = shader.renderQueue;
			LuaDLL.lua_pushinteger(L, renderQueue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderQueue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maximumLOD(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Shader shader = (Shader)obj;
			int maximumLOD = (int)LuaDLL.luaL_checknumber(L, 2);
			shader.maximumLOD = maximumLOD;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maximumLOD on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_globalMaximumLOD(IntPtr L)
	{
		int result;
		try
		{
			int globalMaximumLOD = (int)LuaDLL.luaL_checknumber(L, 2);
			Shader.globalMaximumLOD = globalMaximumLOD;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
