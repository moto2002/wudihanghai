using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace LuaInterface
{
	public static class ToLua
	{
		public static bool useRelativePath = true;

		private static Type monoType = typeof(Type).GetType();

		public static void OpenLibs(IntPtr L)
		{
			ToLua.AddLuaLoader(L);
			LuaDLL.tolua_atpanic(L, new LuaCSFunction(ToLua.Panic));
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(ToLua.Print));
			LuaDLL.lua_setglobal(L, "print");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(ToLua.DoFile));
			LuaDLL.lua_setglobal(L, "dofile");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(ToLua.LoadFile));
			LuaDLL.lua_setglobal(L, "loadfile");
			LuaDLL.lua_getglobal(L, "tolua");
			LuaDLL.lua_pushstring(L, "isnull");
			LuaDLL.lua_pushcfunction(L, new LuaCSFunction(ToLua.IsNull));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pushstring(L, "typeof");
			LuaDLL.lua_pushcfunction(L, new LuaCSFunction(ToLua.GetClassType));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pushstring(L, "tolstring");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(ToLua.BufferToString));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pushstring(L, "toarray");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(ToLua.TableToArray));
			LuaDLL.lua_rawset(L, -3);
			int metaReference = LuaStatic.GetMetaReference(L, typeof(NullObject));
			LuaDLL.lua_pushstring(L, "null");
			LuaDLL.tolua_pushnewudata(L, metaReference, 1);
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pop(L, 1);
			LuaDLL.tolua_pushudata(L, 1);
			LuaDLL.lua_setfield(L, LuaIndexes.LUA_GLOBALSINDEX, "null");
		}

		private static void AddLuaLoader(IntPtr L)
		{
			LuaDLL.lua_getglobal(L, "package");
			LuaDLL.lua_getfield(L, -1, "loaders");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(ToLua.Loader));
			for (int i = LuaDLL.lua_objlen(L, -2) + 1; i > 2; i--)
			{
				LuaDLL.lua_rawgeti(L, -2, i - 1);
				LuaDLL.lua_rawseti(L, -3, i);
			}
			LuaDLL.lua_rawseti(L, -2, 2);
			LuaDLL.lua_pop(L, 2);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int Panic(IntPtr L)
		{
			string msg = string.Format("PANIC: unprotected error in call to Lua API ({0})", LuaDLL.lua_tostring(L, -1));
			throw new LuaException(msg, null, 1);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int Print(IntPtr L)
		{
			int result;
			try
			{
				int num = LuaDLL.lua_gettop(L);
				StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
				for (int i = 1; i <= num; i++)
				{
					if (i > 1)
					{
						stringBuilder.Append("    ");
					}
					if (LuaDLL.lua_isstring(L, i) == 1)
					{
						stringBuilder.Append(LuaDLL.lua_tostring(L, i));
					}
					else if (LuaDLL.lua_isnil(L, i))
					{
						stringBuilder.Append("nil");
					}
					else if (LuaDLL.lua_isboolean(L, i))
					{
						stringBuilder.Append((!LuaDLL.lua_toboolean(L, i)) ? "false" : "true");
					}
					else
					{
						IntPtr value = LuaDLL.lua_topointer(L, i);
						if (value == IntPtr.Zero)
						{
							stringBuilder.Append("nil");
						}
						else
						{
							stringBuilder.AppendFormat("{0}:0x{1}", LuaDLL.luaL_typename(L, i), value.ToString("X"));
						}
					}
				}
				Debugger.Log(StringBuilderCache.GetStringAndRelease(stringBuilder));
				result = 0;
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int Loader(IntPtr L)
		{
			int result;
			try
			{
				string text = LuaDLL.lua_tostring(L, 1);
				text = text.Replace(".", "/");
				byte[] array = LuaFileUtils.Instance.ReadFile(text);
				if (array == null)
				{
					string str = LuaFileUtils.Instance.FindFileError(text);
					LuaDLL.lua_pushstring(L, str);
					result = 1;
				}
				else
				{
					if (LuaConst.openZbsDebugger)
					{
						text = LuaFileUtils.Instance.FindFile(text);
					}
					if (LuaDLL.luaL_loadbuffer(L, array, array.Length, text) != 0)
					{
						string msg = LuaDLL.lua_tostring(L, -1);
						throw new LuaException(msg, LuaException.GetLastError(), 1);
					}
					result = 1;
				}
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int DoFile(IntPtr L)
		{
			int result;
			try
			{
				string text = LuaDLL.lua_tostring(L, 1);
				int num = LuaDLL.lua_gettop(L);
				byte[] array = LuaFileUtils.Instance.ReadFile(text);
				if (array == null)
				{
					string text2 = string.Format("cannot open {0}: No such file or directory", text);
					text2 += LuaFileUtils.Instance.FindFileError(text);
					throw new LuaException(text2, null, 1);
				}
				if (LuaDLL.luaL_loadbuffer(L, array, array.Length, text) == 0 && LuaDLL.lua_pcall(L, 0, LuaDLL.LUA_MULTRET, 0) != 0)
				{
					string msg = LuaDLL.lua_tostring(L, -1);
					throw new LuaException(msg, LuaException.GetLastError(), 1);
				}
				result = LuaDLL.lua_gettop(L) - num;
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int LoadFile(IntPtr L)
		{
			int result;
			try
			{
				string text = LuaDLL.lua_tostring(L, 1);
				byte[] array = LuaFileUtils.Instance.ReadFile(text);
				if (array == null)
				{
					string text2 = string.Format("cannot open {0}: No such file or directory", text);
					text2 += LuaFileUtils.Instance.FindFileError(text);
					throw new LuaException(text2, null, 1);
				}
				if (LuaDLL.luaL_loadbuffer(L, array, array.Length, text) == 0)
				{
					result = 1;
				}
				else
				{
					LuaDLL.lua_pushnil(L);
					LuaDLL.lua_insert(L, -2);
					result = 2;
				}
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int IsNull(IntPtr L)
		{
			if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TNIL)
			{
				LuaDLL.lua_pushboolean(L, true);
			}
			else
			{
				object obj = ToLua.ToObject(L, -1);
				if (obj == null || obj.Equals(null))
				{
					LuaDLL.lua_pushboolean(L, true);
				}
				else
				{
					LuaDLL.lua_pushboolean(L, false);
				}
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int BufferToString(IntPtr L)
		{
			int result;
			try
			{
				object obj = ToLua.CheckObject(L, 1);
				if (obj is byte[])
				{
					byte[] array = (byte[])obj;
					LuaDLL.lua_pushlstring(L, array, array.Length);
				}
				else if (obj is char[])
				{
					byte[] bytes = Encoding.UTF8.GetBytes((char[])obj);
					LuaDLL.lua_pushlstring(L, bytes, bytes.Length);
				}
				else if (obj is string)
				{
					LuaDLL.lua_pushstring(L, (string)obj);
				}
				else
				{
					LuaDLL.luaL_typerror(L, 1, "byte[] or char[]", null);
				}
				result = 1;
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int GetClassType(IntPtr L)
		{
			int num = LuaDLL.tolua_getmetatableref(L, 1);
			if (num > 0)
			{
				Type classType = LuaStatic.GetClassType(L, num);
				ToLua.Push(L, classType);
			}
			else
			{
				switch (LuaDLL.tolua_getvaluetype(L, -1))
				{
				case LuaValueType.Vector3:
					ToLua.Push(L, typeof(Vector3));
					return 1;
				case LuaValueType.Quaternion:
					ToLua.Push(L, typeof(Quaternion));
					return 1;
				case LuaValueType.Vector2:
					ToLua.Push(L, typeof(Vector2));
					return 1;
				case LuaValueType.Color:
					ToLua.Push(L, typeof(Color));
					return 1;
				case LuaValueType.Vector4:
					ToLua.Push(L, typeof(Vector4));
					return 1;
				case LuaValueType.Ray:
					ToLua.Push(L, typeof(Ray));
					return 1;
				case LuaValueType.Bounds:
					ToLua.Push(L, typeof(Bounds));
					return 1;
				case LuaValueType.LayerMask:
					ToLua.Push(L, typeof(LayerMask));
					return 1;
				case LuaValueType.RaycastHit:
					ToLua.Push(L, typeof(RaycastHit));
					return 1;
				}
				Debugger.LogError("type not register to lua");
				LuaDLL.lua_pushnil(L);
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int TableToArray(IntPtr L)
		{
			int result;
			try
			{
				object[] array = ToLua.CheckObjectArray(L, 1);
				Type elementType = (Type)ToLua.CheckObject(L, 2, typeof(Type));
				Array array2 = Array.CreateInstance(elementType, array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					array2.SetValue(array[i], i);
				}
				ToLua.Push(L, array2);
				result = 1;
			}
			catch (LuaException e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int op_ToString(IntPtr L)
		{
			object obj = ToLua.ToObject(L, 1);
			if (obj != null)
			{
				LuaDLL.lua_pushstring(L, obj.ToString());
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
			return 1;
		}

		public static string ToString(IntPtr L, int stackPos)
		{
			if (LuaDLL.lua_isstring(L, stackPos) == 1)
			{
				return LuaDLL.lua_tostring(L, stackPos);
			}
			if (LuaDLL.lua_isuserdata(L, stackPos) == 1)
			{
				return (string)ToLua.ToObject(L, stackPos);
			}
			return null;
		}

		public static object ToObject(IntPtr L, int stackPos)
		{
			int num = LuaDLL.tolua_rawnetobj(L, stackPos);
			if (num != -1)
			{
				ObjectTranslator objectTranslator = ObjectTranslator.Get(L);
				return objectTranslator.GetObject(num);
			}
			return null;
		}

		public static LuaFunction ToLuaFunction(IntPtr L, int stackPos)
		{
			if (LuaDLL.lua_type(L, stackPos) == LuaTypes.LUA_TNIL)
			{
				return null;
			}
			stackPos = LuaDLL.abs_index(L, stackPos);
			LuaDLL.lua_pushvalue(L, stackPos);
			int reference = LuaDLL.toluaL_ref(L);
			return LuaStatic.GetFunction(L, reference);
		}

		public static LuaTable ToLuaTable(IntPtr L, int stackPos)
		{
			if (LuaDLL.lua_type(L, stackPos) == LuaTypes.LUA_TNIL)
			{
				return null;
			}
			stackPos = LuaDLL.abs_index(L, stackPos);
			LuaDLL.lua_pushvalue(L, stackPos);
			int reference = LuaDLL.toluaL_ref(L);
			return LuaStatic.GetTable(L, reference);
		}

		public static LuaThread ToLuaThread(IntPtr L, int stackPos)
		{
			if (LuaDLL.lua_type(L, stackPos) == LuaTypes.LUA_TNIL)
			{
				return null;
			}
			stackPos = LuaDLL.abs_index(L, stackPos);
			LuaDLL.lua_pushvalue(L, stackPos);
			int reference = LuaDLL.toluaL_ref(L);
			return LuaStatic.GetLuaThread(L, reference);
		}

		public static Vector3 ToVector3(IntPtr L, int stackPos)
		{
			float x = 0f;
			float y = 0f;
			float z = 0f;
			LuaDLL.tolua_getvec3(L, stackPos, out x, out y, out z);
			return new Vector3(x, y, z);
		}

		public static Vector4 ToVector4(IntPtr L, int stackPos)
		{
			float x;
			float y;
			float z;
			float w;
			LuaDLL.tolua_getvec4(L, stackPos, out x, out y, out z, out w);
			return new Vector4(x, y, z, w);
		}

		public static Vector2 ToVector2(IntPtr L, int stackPos)
		{
			float x;
			float y;
			LuaDLL.tolua_getvec2(L, stackPos, out x, out y);
			return new Vector2(x, y);
		}

		public static Quaternion ToQuaternion(IntPtr L, int stackPos)
		{
			float x;
			float y;
			float z;
			float w;
			LuaDLL.tolua_getquat(L, stackPos, out x, out y, out z, out w);
			return new Quaternion(x, y, z, w);
		}

		public static Color ToColor(IntPtr L, int stackPos)
		{
			float r;
			float g;
			float b;
			float a;
			LuaDLL.tolua_getclr(L, stackPos, out r, out g, out b, out a);
			return new Color(r, g, b, a);
		}

		public static Ray ToRay(IntPtr L, int stackPos)
		{
			int num = LuaDLL.lua_gettop(L);
			LuaStatic.GetUnpackRayRef(L);
			LuaDLL.lua_pushvalue(L, stackPos);
			if (LuaDLL.lua_pcall(L, 1, 2, 0) == 0)
			{
				Vector3 origin = ToLua.ToVector3(L, num + 1);
				Vector3 direction = ToLua.ToVector3(L, num + 2);
				return new Ray(origin, direction);
			}
			string msg = LuaDLL.lua_tostring(L, -1);
			throw new LuaException(msg, null, 1);
		}

		public static Bounds ToBounds(IntPtr L, int stackPos)
		{
			int num = LuaDLL.lua_gettop(L);
			LuaStatic.GetUnpackBounds(L);
			LuaDLL.lua_pushvalue(L, stackPos);
			if (LuaDLL.lua_pcall(L, 1, 2, 0) == 0)
			{
				Vector3 center = ToLua.ToVector3(L, num + 1);
				Vector3 size = ToLua.ToVector3(L, num + 2);
				return new Bounds(center, size);
			}
			string msg = LuaDLL.lua_tostring(L, -1);
			throw new LuaException(msg, null, 1);
		}

		public static LayerMask ToLayerMask(IntPtr L, int stackPos)
		{
			return LuaDLL.tolua_getlayermask(L, stackPos);
		}

		public static object ToVarObject(IntPtr L, int stackPos)
		{
			switch (LuaDLL.lua_type(L, stackPos))
			{
			case LuaTypes.LUA_TNIL:
				return null;
			case LuaTypes.LUA_TBOOLEAN:
				return LuaDLL.lua_toboolean(L, stackPos);
			case LuaTypes.LUA_TLIGHTUSERDATA:
				return LuaDLL.lua_touserdata(L, stackPos);
			case LuaTypes.LUA_TNUMBER:
				return LuaDLL.lua_tonumber(L, stackPos);
			case LuaTypes.LUA_TSTRING:
				return LuaDLL.lua_tostring(L, stackPos);
			case LuaTypes.LUA_TTABLE:
				return ToLua.ToVarTable(L, stackPos);
			case LuaTypes.LUA_TFUNCTION:
				return ToLua.ToLuaFunction(L, stackPos);
			case LuaTypes.LUA_TUSERDATA:
				if (LuaDLL.tolua_isint64(L, stackPos))
				{
					return LuaDLL.tolua_toint64(L, stackPos);
				}
				return ToLua.ToObject(L, stackPos);
			case LuaTypes.LUA_TTHREAD:
				return ToLua.ToLuaThread(L, stackPos);
			default:
				return null;
			}
		}

		public static object ToVarObject(IntPtr L, int stackPos, Type t)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				object value = LuaDLL.lua_tonumber(L, stackPos);
				return Convert.ChangeType(value, t);
			}
			return ToLua.ToVarObject(L, stackPos);
		}

		public static object ToVarTable(IntPtr L, int stackPos)
		{
			stackPos = LuaDLL.abs_index(L, stackPos);
			switch (LuaDLL.tolua_getvaluetype(L, stackPos))
			{
			case LuaValueType.None:
			{
				LuaDLL.lua_pushvalue(L, stackPos);
				int reference = LuaDLL.toluaL_ref(L);
				return LuaStatic.GetTable(L, reference);
			}
			case LuaValueType.Vector3:
				return ToLua.ToVector3(L, stackPos);
			case LuaValueType.Quaternion:
				return ToLua.ToQuaternion(L, stackPos);
			case LuaValueType.Vector2:
				return ToLua.ToVector2(L, stackPos);
			case LuaValueType.Color:
				return ToLua.ToColor(L, stackPos);
			case LuaValueType.Vector4:
				return ToLua.ToVector4(L, stackPos);
			case LuaValueType.Ray:
				return ToLua.ToRay(L, stackPos);
			case LuaValueType.Bounds:
				return ToLua.ToBounds(L, stackPos);
			case LuaValueType.LayerMask:
				return ToLua.ToLayerMask(L, stackPos);
			}
			return null;
		}

		public static LuaFunction CheckLuaFunction(IntPtr L, int stackPos)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
			if (luaTypes == LuaTypes.LUA_TNIL)
			{
				return null;
			}
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				LuaDLL.luaL_typerror(L, stackPos, "function", null);
				return null;
			}
			return ToLua.ToLuaFunction(L, stackPos);
		}

		public static LuaTable CheckLuaTable(IntPtr L, int stackPos)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
			if (luaTypes == LuaTypes.LUA_TNIL)
			{
				return null;
			}
			if (luaTypes != LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_typerror(L, stackPos, "table", null);
				return null;
			}
			return ToLua.ToLuaTable(L, stackPos);
		}

		public static LuaThread CheckLuaThread(IntPtr L, int stackPos)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
			if (luaTypes == LuaTypes.LUA_TNIL)
			{
				return null;
			}
			if (luaTypes != LuaTypes.LUA_TTHREAD)
			{
				LuaDLL.luaL_typerror(L, stackPos, "thread", null);
				return null;
			}
			return ToLua.ToLuaThread(L, stackPos);
		}

		public static string CheckString(IntPtr L, int stackPos)
		{
			if (LuaDLL.lua_isstring(L, stackPos) == 1)
			{
				return LuaDLL.lua_tostring(L, stackPos);
			}
			if (LuaDLL.lua_isuserdata(L, stackPos) == 1)
			{
				return (string)ToLua.CheckObject(L, stackPos, typeof(string));
			}
			if (LuaDLL.lua_isnil(L, stackPos))
			{
				return null;
			}
			LuaDLL.luaL_typerror(L, stackPos, "string", null);
			return null;
		}

		public static object CheckObject(IntPtr L, int stackPos)
		{
			int num = LuaDLL.tolua_rawnetobj(L, stackPos);
			if (num != -1)
			{
				ObjectTranslator objectTranslator = ObjectTranslator.Get(L);
				return objectTranslator.GetObject(num);
			}
			if (LuaDLL.lua_isnil(L, stackPos))
			{
				return null;
			}
			LuaDLL.luaL_typerror(L, stackPos, "object", null);
			return null;
		}

		public static object CheckObject(IntPtr L, int stackPos, Type type)
		{
			int num = LuaDLL.tolua_rawnetobj(L, stackPos);
			if (num != -1)
			{
				ObjectTranslator objectTranslator = ObjectTranslator.Get(L);
				object @object = objectTranslator.GetObject(num);
				if (@object != null)
				{
					Type type2 = @object.GetType();
					if (type == type2 || type.IsAssignableFrom(type2))
					{
						return @object;
					}
					LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", type.FullName, type2.FullName));
				}
				return null;
			}
			if (LuaDLL.lua_isnil(L, stackPos) && !TypeChecker.IsValueType(type))
			{
				return null;
			}
			LuaDLL.luaL_typerror(L, stackPos, type.FullName, null);
			return null;
		}

		private static Vector3 CheckVector3(IntPtr L, int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(L, stackPos);
			if (luaValueType != LuaValueType.Vector3)
			{
				LuaDLL.luaL_typerror(L, stackPos, "Vector3", luaValueType.ToString());
				return Vector3.zero;
			}
			float x;
			float y;
			float z;
			LuaDLL.tolua_getvec3(L, stackPos, out x, out y, out z);
			return new Vector3(x, y, z);
		}

		private static Quaternion CheckQuaternion(IntPtr L, int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(L, stackPos);
			if (luaValueType != LuaValueType.Vector4)
			{
				LuaDLL.luaL_typerror(L, stackPos, "Quaternion", luaValueType.ToString());
				return Quaternion.identity;
			}
			float x;
			float y;
			float z;
			float w;
			LuaDLL.tolua_getquat(L, stackPos, out x, out y, out z, out w);
			return new Quaternion(x, y, z, w);
		}

		private static Vector2 CheckVector2(IntPtr L, int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(L, stackPos);
			if (luaValueType != LuaValueType.Vector2)
			{
				LuaDLL.luaL_typerror(L, stackPos, "Vector2", luaValueType.ToString());
				return Vector2.zero;
			}
			float x;
			float y;
			LuaDLL.tolua_getvec2(L, stackPos, out x, out y);
			return new Vector2(x, y);
		}

		private static Vector4 CheckVector4(IntPtr L, int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(L, stackPos);
			if (luaValueType != LuaValueType.Vector4)
			{
				LuaDLL.luaL_typerror(L, stackPos, "Vector4", luaValueType.ToString());
				return Vector4.zero;
			}
			float x;
			float y;
			float z;
			float w;
			LuaDLL.tolua_getvec4(L, stackPos, out x, out y, out z, out w);
			return new Vector4(x, y, z, w);
		}

		private static Color CheckColor(IntPtr L, int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(L, stackPos);
			if (luaValueType != LuaValueType.Color)
			{
				LuaDLL.luaL_typerror(L, stackPos, "Color", luaValueType.ToString());
				return Color.black;
			}
			float r;
			float g;
			float b;
			float a;
			LuaDLL.tolua_getclr(L, stackPos, out r, out g, out b, out a);
			return new Color(r, g, b, a);
		}

		private static Ray CheckRay(IntPtr L, int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(L, stackPos);
			if (luaValueType != LuaValueType.Ray)
			{
				LuaDLL.luaL_typerror(L, stackPos, "Ray", luaValueType.ToString());
				return default(Ray);
			}
			return ToLua.ToRay(L, stackPos);
		}

		private static Bounds CheckBounds(IntPtr L, int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(L, stackPos);
			if (luaValueType != LuaValueType.Bounds)
			{
				LuaDLL.luaL_typerror(L, stackPos, "Bounds", luaValueType.ToString());
				return default(Bounds);
			}
			return ToLua.ToBounds(L, stackPos);
		}

		private static LayerMask CheckLayerMask(IntPtr L, int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(L, stackPos);
			if (luaValueType != LuaValueType.LayerMask)
			{
				LuaDLL.luaL_typerror(L, stackPos, "LayerMask", luaValueType.ToString());
				return 0;
			}
			return LuaDLL.tolua_getlayermask(L, stackPos);
		}

		public static object CheckVarObject(IntPtr L, int stackPos, Type t)
		{
			bool flag = TypeChecker.IsValueType(t);
			LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
			if (!flag && luaTypes == LuaTypes.LUA_TNIL)
			{
				return null;
			}
			if (flag)
			{
				if (TypeChecker.IsNullable(t))
				{
					if (luaTypes == LuaTypes.LUA_TNIL)
					{
						return null;
					}
					Type[] genericArguments = t.GetGenericArguments();
					t = genericArguments[0];
				}
				if (t == typeof(bool))
				{
					return LuaDLL.luaL_checkboolean(L, stackPos);
				}
				if (t == typeof(long))
				{
					return LuaDLL.tolua_checkint64(L, stackPos);
				}
				if (t == typeof(ulong))
				{
					return LuaDLL.tolua_checkuint64(L, stackPos);
				}
				if (t.IsPrimitive)
				{
					double num = LuaDLL.luaL_checknumber(L, stackPos);
					return Convert.ChangeType(num, t);
				}
				if (t == typeof(Vector3))
				{
					return ToLua.CheckVector3(L, stackPos);
				}
				if (t == typeof(Quaternion))
				{
					return ToLua.CheckQuaternion(L, stackPos);
				}
				if (t == typeof(Vector2))
				{
					return ToLua.CheckVector2(L, stackPos);
				}
				if (t == typeof(Vector4))
				{
					return ToLua.CheckVector4(L, stackPos);
				}
				if (t == typeof(Color))
				{
					return ToLua.CheckColor(L, stackPos);
				}
				if (t == typeof(Ray))
				{
					return ToLua.CheckRay(L, stackPos);
				}
				if (t == typeof(Bounds))
				{
					return ToLua.CheckBounds(L, stackPos);
				}
				if (t == typeof(LayerMask))
				{
					return ToLua.CheckLayerMask(L, stackPos);
				}
				return ToLua.CheckObject(L, stackPos, t);
			}
			else
			{
				if (t.IsEnum)
				{
					return ToLua.CheckObject(L, stackPos, typeof(Enum));
				}
				if (t == typeof(string))
				{
					return ToLua.CheckString(L, stackPos);
				}
				if (t == typeof(LuaByteBuffer))
				{
					int len = 0;
					IntPtr source = LuaDLL.tolua_tolstring(L, stackPos, out len);
					return new LuaByteBuffer(source, len);
				}
				return ToLua.CheckObject(L, stackPos, t);
			}
		}

		public static UnityEngine.Object CheckUnityObject(IntPtr L, int stackPos, Type type)
		{
			int num = LuaDLL.tolua_rawnetobj(L, stackPos);
			if (num != -1)
			{
				ObjectTranslator objectTranslator = ObjectTranslator.Get(L);
				object @object = objectTranslator.GetObject(num);
				if (@object != null)
				{
					UnityEngine.Object object2 = (UnityEngine.Object)@object;
					if (object2 == null)
					{
						LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.FullName));
						return null;
					}
					Type type2 = object2.GetType();
					if (type == type2 || type2.IsSubclassOf(type))
					{
						return object2;
					}
					LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", type.FullName, type2.FullName));
				}
				return null;
			}
			if (LuaDLL.lua_isnil(L, stackPos))
			{
				return null;
			}
			LuaDLL.luaL_typerror(L, stackPos, type.FullName, null);
			return null;
		}

		public static TrackedReference CheckTrackedReference(IntPtr L, int stackPos, Type type)
		{
			int num = LuaDLL.tolua_rawnetobj(L, stackPos);
			if (num != -1)
			{
				ObjectTranslator objectTranslator = ObjectTranslator.Get(L);
				object @object = objectTranslator.GetObject(num);
				if (@object != null)
				{
					TrackedReference trackedReference = (TrackedReference)@object;
					if (trackedReference == null)
					{
						LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.FullName));
						return null;
					}
					Type type2 = trackedReference.GetType();
					if (type == type2 || type2.IsSubclassOf(type))
					{
						return trackedReference;
					}
					LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", type.FullName, type2.FullName));
				}
				return null;
			}
			if (LuaDLL.lua_isnil(L, stackPos))
			{
				return null;
			}
			LuaDLL.luaL_typerror(L, stackPos, type.FullName, null);
			return null;
		}

		public static object[] CheckObjectArray(IntPtr L, int stackPos)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				int num = 1;
				List<object> list = new List<object>();
				LuaDLL.lua_pushvalue(L, stackPos);
				while (true)
				{
					LuaDLL.lua_rawgeti(L, -1, num);
					if (LuaDLL.lua_type(L, -1) == LuaTypes.LUA_TNIL)
					{
						break;
					}
					object item = ToLua.ToVarObject(L, -1);
					list.Add(item);
					LuaDLL.lua_pop(L, 1);
					num++;
				}
				LuaDLL.lua_pop(L, 1);
				return list.ToArray();
			}
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				return (object[])ToLua.CheckObject(L, stackPos, typeof(object[]));
			}
			if (luaTypes == LuaTypes.LUA_TNIL)
			{
				return null;
			}
			LuaDLL.luaL_typerror(L, stackPos, "object[] or table", null);
			return null;
		}

		public static T[] CheckObjectArray<T>(IntPtr L, int stackPos)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				int num = 1;
				Type typeFromHandle = typeof(T);
				List<T> list = new List<T>();
				LuaDLL.lua_pushvalue(L, stackPos);
				while (true)
				{
					LuaDLL.lua_rawgeti(L, -1, num);
					if (LuaDLL.lua_type(L, -1) == LuaTypes.LUA_TNIL)
					{
						break;
					}
					if (!TypeChecker.CheckType(L, typeFromHandle, -1))
					{
						goto Block_3;
					}
					list.Add((T)((object)ToLua.ToVarObject(L, -1)));
					LuaDLL.lua_pop(L, 1);
					num++;
				}
				LuaDLL.lua_pop(L, 1);
				return list.ToArray();
				Block_3:
				LuaDLL.lua_pop(L, 1);
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TUSERDATA)
				{
					return (T[])ToLua.CheckObject(L, stackPos, typeof(T[]));
				}
				if (luaTypes == LuaTypes.LUA_TNIL)
				{
					return null;
				}
			}
			LuaDLL.luaL_typerror(L, stackPos, typeof(T[]).FullName, null);
			return null;
		}

		public static char[] CheckCharBuffer(IntPtr L, int stackPos)
		{
			if (LuaDLL.lua_isstring(L, stackPos) != 0)
			{
				string text = LuaDLL.lua_tostring(L, stackPos);
				return text.ToCharArray();
			}
			if (LuaDLL.lua_isuserdata(L, stackPos) != 0)
			{
				return (char[])ToLua.CheckObject(L, stackPos, typeof(char[]));
			}
			if (LuaDLL.lua_isnil(L, stackPos))
			{
				return null;
			}
			LuaDLL.luaL_typerror(L, stackPos, "string or char[]", null);
			return null;
		}

		public static byte[] CheckByteBuffer(IntPtr L, int stackPos)
		{
			if (LuaDLL.lua_isstring(L, stackPos) != 0)
			{
				int num;
				IntPtr source = LuaDLL.lua_tolstring(L, stackPos, out num);
				byte[] array = new byte[num];
				Marshal.Copy(source, array, 0, num);
				return array;
			}
			if (LuaDLL.lua_isuserdata(L, stackPos) != 0)
			{
				return (byte[])ToLua.CheckObject(L, stackPos, typeof(byte[]));
			}
			if (LuaDLL.lua_isnil(L, stackPos))
			{
				return null;
			}
			LuaDLL.luaL_typerror(L, stackPos, "string or byte[]", null);
			return null;
		}

		public static T[] CheckNumberArray<T>(IntPtr L, int stackPos)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				int num = 1;
				T t = default(T);
				List<T> list = new List<T>();
				LuaDLL.lua_pushvalue(L, stackPos);
				Type typeFromHandle = typeof(T);
				while (true)
				{
					LuaDLL.lua_rawgeti(L, -1, num);
					luaTypes = LuaDLL.lua_type(L, -1);
					if (luaTypes == LuaTypes.LUA_TNIL)
					{
						break;
					}
					if (luaTypes != LuaTypes.LUA_TNUMBER)
					{
						goto Block_3;
					}
					T item = (T)((object)Convert.ChangeType(LuaDLL.lua_tonumber(L, -1), typeFromHandle));
					list.Add(item);
					LuaDLL.lua_pop(L, 1);
					num++;
				}
				LuaDLL.lua_pop(L, 1);
				return list.ToArray();
				Block_3:;
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TUSERDATA)
				{
					return (T[])ToLua.CheckObject(L, stackPos, typeof(T[]));
				}
				if (luaTypes == LuaTypes.LUA_TNIL)
				{
					return null;
				}
			}
			LuaDLL.luaL_typerror(L, stackPos, LuaMisc.GetTypeName(typeof(T[])), null);
			return null;
		}

		public static bool[] CheckBoolArray(IntPtr L, int stackPos)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				int num = 1;
				Type typeFromHandle = typeof(bool);
				List<bool> list = new List<bool>();
				LuaDLL.lua_pushvalue(L, stackPos);
				while (true)
				{
					LuaDLL.lua_rawgeti(L, -1, num);
					if (LuaDLL.lua_type(L, -1) == LuaTypes.LUA_TNIL)
					{
						break;
					}
					if (!TypeChecker.CheckType(L, typeFromHandle, -1))
					{
						goto Block_3;
					}
					list.Add(LuaDLL.lua_toboolean(L, -1));
					LuaDLL.lua_pop(L, 1);
					num++;
				}
				LuaDLL.lua_pop(L, 1);
				return list.ToArray();
				Block_3:
				LuaDLL.lua_pop(L, 1);
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TUSERDATA)
				{
					return (bool[])ToLua.CheckObject(L, stackPos, typeof(bool[]));
				}
				if (luaTypes == LuaTypes.LUA_TNIL)
				{
					return null;
				}
			}
			LuaDLL.luaL_typerror(L, stackPos, "bool[]", null);
			return null;
		}

		public static string[] CheckStringArray(IntPtr L, int stackPos)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				int num = 1;
				Type typeFromHandle = typeof(string);
				List<string> list = new List<string>();
				LuaDLL.lua_pushvalue(L, stackPos);
				while (true)
				{
					LuaDLL.lua_rawgeti(L, -1, num);
					if (LuaDLL.lua_type(L, -1) == LuaTypes.LUA_TNIL)
					{
						break;
					}
					if (!TypeChecker.CheckType(L, typeFromHandle, -1))
					{
						goto Block_3;
					}
					string item = ToLua.ToString(L, -1);
					list.Add(item);
					LuaDLL.lua_pop(L, 1);
					num++;
				}
				LuaDLL.lua_pop(L, 1);
				return list.ToArray();
				Block_3:
				LuaDLL.lua_pop(L, 1);
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TUSERDATA)
				{
					return (string[])ToLua.CheckObject(L, stackPos, typeof(string[]));
				}
				if (luaTypes == LuaTypes.LUA_TNIL)
				{
					return null;
				}
			}
			LuaDLL.luaL_typerror(L, stackPos, "string[]", null);
			return null;
		}

		public static object CheckGenericObject(IntPtr L, int stackPos, Type type, out Type ArgType)
		{
			object obj = ToLua.ToObject(L, 1);
			Type type2 = obj.GetType();
			ArgType = null;
			if (type2.IsGenericType && type2.GetGenericTypeDefinition() == type)
			{
				Type[] genericArguments = type2.GetGenericArguments();
				ArgType = genericArguments[0];
				return obj;
			}
			LuaDLL.luaL_argerror(L, stackPos, LuaMisc.GetTypeName(type));
			return null;
		}

		public static object CheckGenericObject(IntPtr L, int stackPos, Type type, out Type t1, out Type t2)
		{
			object obj = ToLua.ToObject(L, 1);
			Type type2 = obj.GetType();
			t1 = null;
			t2 = null;
			if (type2.IsGenericType && type2.GetGenericTypeDefinition() == type)
			{
				Type[] genericArguments = type2.GetGenericArguments();
				t1 = genericArguments[0];
				t2 = genericArguments[1];
				return obj;
			}
			LuaDLL.luaL_argerror(L, stackPos, LuaMisc.GetTypeName(type));
			return null;
		}

		public static object CheckGenericObject(IntPtr L, int stackPos, Type type)
		{
			object obj = ToLua.ToObject(L, 1);
			Type type2 = obj.GetType();
			if (type2.IsGenericType && type2.GetGenericTypeDefinition() == type)
			{
				return obj;
			}
			LuaDLL.luaL_argerror(L, stackPos, LuaMisc.GetTypeName(type));
			return null;
		}

		public static object[] ToParamsObject(IntPtr L, int stackPos, int count)
		{
			if (count <= 0)
			{
				return null;
			}
			object[] array = new object[count];
			int i = 0;
			while (i < count)
			{
				array[i++] = ToLua.ToVarObject(L, stackPos++);
			}
			return array;
		}

		public static T[] ToParamsObject<T>(IntPtr L, int stackPos, int count)
		{
			if (count <= 0)
			{
				return null;
			}
			T[] array = new T[count];
			Type typeFromHandle = typeof(T);
			int i = 0;
			while (i < count)
			{
				object temp = ToLua.ToVarObject(L, stackPos++);
				array[i++] = TypeChecker.ChangeType<T>(temp, typeFromHandle);
			}
			return array;
		}

		public static string[] ToParamsString(IntPtr L, int stackPos, int count)
		{
			if (count <= 0)
			{
				return null;
			}
			string[] array = new string[count];
			int i = 0;
			while (i < count)
			{
				array[i++] = ToLua.ToString(L, stackPos++);
			}
			return array;
		}

		public static T[] ToParamsNumber<T>(IntPtr L, int stackPos, int count)
		{
			if (count <= 0)
			{
				return null;
			}
			T[] array = new T[count];
			Type typeFromHandle = typeof(T);
			int i = 0;
			while (i < count)
			{
				double num = LuaDLL.lua_tonumber(L, stackPos++);
				array[i++] = (T)((object)Convert.ChangeType(num, typeFromHandle));
			}
			return array;
		}

		public static char[] ToParamsChar(IntPtr L, int stackPos, int count)
		{
			if (count <= 0)
			{
				return null;
			}
			char[] array = new char[count];
			int i = 0;
			while (i < count)
			{
				array[i++] = (char)LuaDLL.lua_tointeger(L, stackPos++);
			}
			return array;
		}

		public static bool[] CheckParamsBool(IntPtr L, int stackPos, int count)
		{
			if (count <= 0)
			{
				return null;
			}
			bool[] array = new bool[count];
			int i = 0;
			while (i < count)
			{
				array[i++] = LuaDLL.luaL_checkboolean(L, stackPos++);
			}
			return array;
		}

		public static T[] CheckParamsNumber<T>(IntPtr L, int stackPos, int count)
		{
			if (count <= 0)
			{
				return null;
			}
			T[] array = new T[count];
			Type typeFromHandle = typeof(T);
			int i = 0;
			while (i < count)
			{
				double num = LuaDLL.luaL_checknumber(L, stackPos++);
				array[i++] = (T)((object)Convert.ChangeType(num, typeFromHandle));
			}
			return array;
		}

		public static char[] CheckParamsChar(IntPtr L, int stackPos, int count)
		{
			if (count <= 0)
			{
				return null;
			}
			char[] array = new char[count];
			int i = 0;
			while (i < count)
			{
				array[i++] = (char)LuaDLL.luaL_checkinteger(L, stackPos++);
			}
			return array;
		}

		public static string[] CheckParamsString(IntPtr L, int stackPos, int count)
		{
			if (count <= 0)
			{
				return null;
			}
			string[] array = new string[count];
			int i = 0;
			while (i < count)
			{
				array[i++] = ToLua.CheckString(L, stackPos++);
			}
			return array;
		}

		public static T[] CheckParamsObject<T>(IntPtr L, int stackPos, int count)
		{
			if (count <= 0)
			{
				return null;
			}
			T[] array = new T[count];
			Type typeFromHandle = typeof(T);
			int i = 0;
			while (i < count)
			{
				object temp = ToLua.CheckVarObject(L, stackPos++, typeFromHandle);
				array[i++] = TypeChecker.ChangeType<T>(temp, typeFromHandle);
			}
			return array;
		}

		public static void Push(IntPtr L, Vector3 v3)
		{
			LuaDLL.tolua_pushvec3(L, v3.x, v3.y, v3.z);
		}

		public static void Push(IntPtr L, Vector2 v2)
		{
			LuaDLL.tolua_pushvec2(L, v2.x, v2.y);
		}

		public static void Push(IntPtr L, Vector4 v4)
		{
			LuaDLL.tolua_pushvec4(L, v4.x, v4.y, v4.z, v4.w);
		}

		public static void Push(IntPtr L, Quaternion q)
		{
			LuaDLL.tolua_pushquat(L, q.x, q.y, q.z, q.w);
		}

		public static void Push(IntPtr L, Color clr)
		{
			LuaDLL.tolua_pushclr(L, clr.r, clr.g, clr.b, clr.a);
		}

		public static void Push(IntPtr L, Ray ray)
		{
			LuaStatic.GetPackRay(L);
			ToLua.Push(L, ray.direction);
			ToLua.Push(L, ray.origin);
			if (LuaDLL.lua_pcall(L, 2, 1, 0) != 0)
			{
				string msg = LuaDLL.lua_tostring(L, -1);
				throw new LuaException(msg, null, 1);
			}
		}

		public static void Push(IntPtr L, Bounds bound)
		{
			LuaStatic.GetPackBounds(L);
			ToLua.Push(L, bound.center);
			ToLua.Push(L, bound.size);
			if (LuaDLL.lua_pcall(L, 2, 1, 0) != 0)
			{
				string msg = LuaDLL.lua_tostring(L, -1);
				throw new LuaException(msg, null, 1);
			}
		}

		public static void Push(IntPtr L, RaycastHit hit)
		{
			ToLua.Push(L, hit, 31);
		}

		public static void Push(IntPtr L, RaycastHit hit, int flag)
		{
			LuaStatic.GetPackRaycastHit(L);
			if ((flag & 1) != 0)
			{
				ToLua.Push(L, hit.collider);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
			LuaDLL.lua_pushnumber(L, (double)hit.distance);
			if ((flag & 2) != 0)
			{
				ToLua.Push(L, hit.normal);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
			if ((flag & 4) != 0)
			{
				ToLua.Push(L, hit.point);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
			if ((flag & 8) != 0)
			{
				ToLua.Push(L, hit.rigidbody);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
			if ((flag & 16) != 0)
			{
				ToLua.Push(L, hit.transform);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
			if (LuaDLL.lua_pcall(L, 6, 1, 0) != 0)
			{
				string msg = LuaDLL.lua_tostring(L, -1);
				throw new LuaException(msg, null, 1);
			}
		}

		public static void Push(IntPtr L, Touch t)
		{
			ToLua.Push(L, t, 7);
		}

		public static void Push(IntPtr L, Touch t, int flag)
		{
			LuaStatic.GetPackTouch(L);
			LuaDLL.lua_pushinteger(L, t.fingerId);
			if ((flag & 2) != 0)
			{
				ToLua.Push(L, t.position);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
			if ((flag & 4) != 0)
			{
				ToLua.Push(L, t.rawPosition);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
			if ((flag & 1) != 0)
			{
				ToLua.Push(L, t.deltaPosition);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
			LuaDLL.lua_pushnumber(L, (double)t.deltaTime);
			LuaDLL.lua_pushinteger(L, t.tapCount);
			LuaDLL.lua_pushinteger(L, (int)t.phase);
			if (LuaDLL.lua_pcall(L, 7, -1, 0) != 0)
			{
				string msg = LuaDLL.lua_tostring(L, -1);
				throw new LuaException(msg, null, 1);
			}
		}

		public static void PushLayerMask(IntPtr L, LayerMask l)
		{
			LuaDLL.tolua_pushlayermask(L, l.value);
		}

		public static void Push(IntPtr L, LuaByteBuffer bb)
		{
			LuaDLL.lua_pushlstring(L, bb.buffer, bb.buffer.Length);
		}

		public static void PushByteBuffer(IntPtr L, byte[] buffer)
		{
			LuaDLL.tolua_pushlstring(L, buffer, buffer.Length);
		}

		public static void Push(IntPtr L, Array array)
		{
			if (array == null)
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				int arrayMetatable = LuaStatic.GetArrayMetatable(L);
				ToLua.PushUserData(L, array, arrayMetatable);
			}
		}

		public static void Push(IntPtr L, LuaBaseRef lbr)
		{
			if (lbr == null)
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				LuaDLL.lua_getref(L, lbr.GetReference());
			}
		}

		public static void Push(IntPtr L, Type t)
		{
			if (t == null)
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				int typeMetatable = LuaStatic.GetTypeMetatable(L);
				ToLua.PushUserData(L, t, typeMetatable);
			}
		}

		public static void Push(IntPtr L, Delegate ev)
		{
			if (ev == null)
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				int delegateMetatable = LuaStatic.GetDelegateMetatable(L);
				ToLua.PushUserData(L, ev, delegateMetatable);
			}
		}

		public static void Push(IntPtr L, EventObject ev)
		{
			if (ev == null)
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				int eventMetatable = LuaStatic.GetEventMetatable(L);
				ToLua.PushUserData(L, ev, eventMetatable);
			}
		}

		public static void Push(IntPtr L, IEnumerator iter)
		{
			if (iter == null)
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				int metaReference = LuaStatic.GetMetaReference(L, iter.GetType());
				if (metaReference > 0)
				{
					ToLua.PushUserData(L, iter, metaReference);
				}
				else
				{
					int iterMetatable = LuaStatic.GetIterMetatable(L);
					ToLua.PushUserData(L, iter, iterMetatable);
				}
			}
		}

		public static void Push(IntPtr L, Enum e)
		{
			if (e == null)
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				object o = null;
				int enumObject = LuaStatic.GetEnumObject(L, e, out o);
				ToLua.PushUserData(L, o, enumObject);
			}
		}

		public static void PushOut<T>(IntPtr L, LuaOut<T> lo)
		{
			ObjectTranslator objectTranslator = ObjectTranslator.Get(L);
			int index = objectTranslator.AddObject(lo);
			int outMetatable = LuaStatic.GetOutMetatable(L);
			LuaDLL.tolua_pushnewudata(L, outMetatable, index);
		}

		public static void PushValue(IntPtr L, ValueType v)
		{
			if (v == null)
			{
				LuaDLL.lua_pushnil(L);
				return;
			}
			Type type = v.GetType();
			int num = LuaStatic.GetMetaReference(L, type);
			if (num <= 0)
			{
				LuaCSFunction preModule = LuaStatic.GetPreModule(L, type);
				if (preModule != null)
				{
					num = ToLua.LuaPCall(L, preModule);
				}
				else
				{
					num = LuaStatic.GetMissMetaReference(L, type);
				}
			}
			ObjectTranslator objectTranslator = ObjectTranslator.Get(L);
			int index = objectTranslator.AddObject(v);
			LuaDLL.tolua_pushnewudata(L, num, index);
		}

		private static void PushUserData(IntPtr L, object o, int reference)
		{
			ObjectTranslator objectTranslator = ObjectTranslator.Get(L);
			int index;
			if (objectTranslator.Getudata(o, out index) && LuaDLL.tolua_pushudata(L, index))
			{
				return;
			}
			index = objectTranslator.AddObject(o);
			LuaDLL.tolua_pushnewudata(L, reference, index);
		}

		private static int LuaPCall(IntPtr L, LuaCSFunction func)
		{
			int top = LuaDLL.lua_gettop(L);
			LuaDLL.tolua_pushcfunction(L, func);
			if (LuaDLL.lua_pcall(L, 0, -1, 0) != 0)
			{
				string msg = LuaDLL.lua_tostring(L, -1);
				LuaDLL.lua_settop(L, top);
				throw new LuaException(msg, LuaException.GetLastError(), 1);
			}
			int result = LuaDLL.tolua_getclassref(L, -1);
			LuaDLL.lua_settop(L, top);
			return result;
		}

		private static void PushPreLoadType(IntPtr L, object o, Type type)
		{
			LuaCSFunction preModule = LuaStatic.GetPreModule(L, type);
			int num;
			if (preModule != null)
			{
				num = ToLua.LuaPCall(L, preModule);
			}
			else
			{
				num = LuaStatic.GetMissMetaReference(L, type);
			}
			if (num > 0)
			{
				ToLua.PushUserData(L, o, num);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
		}

		private static void PushUserObject(IntPtr L, object o)
		{
			Type type = o.GetType();
			int metaReference = LuaStatic.GetMetaReference(L, type);
			if (metaReference > 0)
			{
				ToLua.PushUserData(L, o, metaReference);
			}
			else
			{
				ToLua.PushPreLoadType(L, o, type);
			}
		}

		public static void Push(IntPtr L, UnityEngine.Object obj)
		{
			if (obj == null)
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				ToLua.PushUserObject(L, obj);
			}
		}

		public static void Push(IntPtr L, TrackedReference obj)
		{
			if (obj == null)
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				ToLua.PushUserObject(L, obj);
			}
		}

		public static void PushObject(IntPtr L, object o)
		{
			if (o == null || o.Equals(null))
			{
				LuaDLL.lua_pushnil(L);
			}
			else
			{
				ToLua.PushUserObject(L, o);
			}
		}

		public static void Push(IntPtr L, object obj)
		{
			if (obj == null || obj.Equals(null))
			{
				LuaDLL.lua_pushnil(L);
				return;
			}
			Type type = obj.GetType();
			if (type.IsValueType)
			{
				if (type == typeof(bool))
				{
					bool value = (bool)obj;
					LuaDLL.lua_pushboolean(L, value);
				}
				else if (type.IsEnum)
				{
					ToLua.Push(L, (Enum)obj);
				}
				else if (type == typeof(long))
				{
					LuaDLL.tolua_pushint64(L, (long)obj);
				}
				else if (type == typeof(ulong))
				{
					LuaDLL.tolua_pushuint64(L, (ulong)obj);
				}
				else if (type.IsPrimitive)
				{
					double number = LuaMisc.ToDouble(obj);
					LuaDLL.lua_pushnumber(L, number);
				}
				else if (type == typeof(Vector3))
				{
					ToLua.Push(L, (Vector3)obj);
				}
				else if (type == typeof(Quaternion))
				{
					ToLua.Push(L, (Quaternion)obj);
				}
				else if (type == typeof(Vector2))
				{
					ToLua.Push(L, (Vector2)obj);
				}
				else if (type == typeof(Vector4))
				{
					ToLua.Push(L, (Vector4)obj);
				}
				else if (type == typeof(Color))
				{
					ToLua.Push(L, (Color)obj);
				}
				else if (type == typeof(RaycastHit))
				{
					ToLua.Push(L, (RaycastHit)obj);
				}
				else if (type == typeof(Touch))
				{
					ToLua.Push(L, (Touch)obj);
				}
				else if (type == typeof(Ray))
				{
					ToLua.Push(L, (Ray)obj);
				}
				else if (type == typeof(Bounds))
				{
					ToLua.Push(L, (Bounds)obj);
				}
				else if (type == typeof(LayerMask))
				{
					ToLua.PushLayerMask(L, (LayerMask)obj);
				}
				else
				{
					ToLua.PushValue(L, (ValueType)obj);
				}
			}
			else if (type.IsArray)
			{
				ToLua.Push(L, (Array)obj);
			}
			else if (type == typeof(string))
			{
				LuaDLL.lua_pushstring(L, (string)obj);
			}
			else if (type.IsSubclassOf(typeof(LuaBaseRef)))
			{
				ToLua.Push(L, (LuaBaseRef)obj);
			}
			else if (type.IsSubclassOf(typeof(UnityEngine.Object)))
			{
				ToLua.Push(L, (UnityEngine.Object)obj);
			}
			else if (type.IsSubclassOf(typeof(TrackedReference)))
			{
				ToLua.Push(L, (TrackedReference)obj);
			}
			else if (type == typeof(LuaByteBuffer))
			{
				LuaByteBuffer luaByteBuffer = (LuaByteBuffer)obj;
				LuaDLL.lua_pushlstring(L, luaByteBuffer.buffer, luaByteBuffer.buffer.Length);
			}
			else if (type.IsSubclassOf(typeof(Delegate)))
			{
				ToLua.Push(L, (Delegate)obj);
			}
			else if (obj is IEnumerator)
			{
				ToLua.Push(L, (IEnumerator)obj);
			}
			else if (type == typeof(EventObject))
			{
				ToLua.Push(L, (EventObject)obj);
			}
			else if (type == ToLua.monoType)
			{
				ToLua.Push(L, (Type)obj);
			}
			else
			{
				ToLua.PushObject(L, obj);
			}
		}

		public static void SetBack(IntPtr L, int stackPos, object o)
		{
			int num = LuaDLL.tolua_rawnetobj(L, stackPos);
			ObjectTranslator objectTranslator = ObjectTranslator.Get(L);
			if (num != -1)
			{
				objectTranslator.SetBack(num, o);
			}
		}

		public static int Destroy(IntPtr L)
		{
			int udata = LuaDLL.tolua_rawnetobj(L, 1);
			ObjectTranslator objectTranslator = ObjectTranslator.Get(L);
			objectTranslator.Destroy(udata);
			return 0;
		}

		public static void CheckArgsCount(IntPtr L, string method, int count)
		{
			int num = LuaDLL.lua_gettop(L);
			if (num != count)
			{
				throw new LuaException(string.Format("no overload for method '{0}' takes '{1}' arguments", method, num), null, 1);
			}
		}

		public static void CheckArgsCount(IntPtr L, int count)
		{
			int num = LuaDLL.lua_gettop(L);
			if (num != count)
			{
				throw new LuaException(string.Format("no overload for method takes '{0}' arguments", num), null, 1);
			}
		}
	}
}
