using LuaInterface;
using System;
using System.Collections;
using UnityEngine;

public class System_ArrayWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Array), typeof(object), null);
		L.RegFunction(".geti", new LuaCSFunction(System_ArrayWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(System_ArrayWrap.set_Item));
		L.RegFunction("ToTable", new LuaCSFunction(System_ArrayWrap.ToTable));
		L.RegFunction("GetLength", new LuaCSFunction(System_ArrayWrap.GetLength));
		L.RegFunction("GetLongLength", new LuaCSFunction(System_ArrayWrap.GetLongLength));
		L.RegFunction("GetLowerBound", new LuaCSFunction(System_ArrayWrap.GetLowerBound));
		L.RegFunction("GetValue", new LuaCSFunction(System_ArrayWrap.GetValue));
		L.RegFunction("SetValue", new LuaCSFunction(System_ArrayWrap.SetValue));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_ArrayWrap.GetEnumerator));
		L.RegFunction("GetUpperBound", new LuaCSFunction(System_ArrayWrap.GetUpperBound));
		L.RegFunction("CreateInstance", new LuaCSFunction(System_ArrayWrap.CreateInstance));
		L.RegFunction("BinarySearch", new LuaCSFunction(System_ArrayWrap.BinarySearch));
		L.RegFunction("Clear", new LuaCSFunction(System_ArrayWrap.Clear));
		L.RegFunction("Clone", new LuaCSFunction(System_ArrayWrap.Clone));
		L.RegFunction("Copy", new LuaCSFunction(System_ArrayWrap.Copy));
		L.RegFunction("IndexOf", new LuaCSFunction(System_ArrayWrap.IndexOf));
		L.RegFunction("Initialize", new LuaCSFunction(System_ArrayWrap.Initialize));
		L.RegFunction("LastIndexOf", new LuaCSFunction(System_ArrayWrap.LastIndexOf));
		L.RegFunction("Reverse", new LuaCSFunction(System_ArrayWrap.Reverse));
		L.RegFunction("Sort", new LuaCSFunction(System_ArrayWrap.Sort));
		L.RegFunction("CopyTo", new LuaCSFunction(System_ArrayWrap.CopyTo));
		L.RegFunction("ConstrainedCopy", new LuaCSFunction(System_ArrayWrap.ConstrainedCopy));
		L.RegFunction("__tostring", new LuaCSFunction(System_ArrayWrap.Lua_ToString));
		L.RegVar("Length", new LuaCSFunction(System_ArrayWrap.get_Length), null);
		L.RegVar("LongLength", new LuaCSFunction(System_ArrayWrap.get_LongLength), null);
		L.RegVar("Rank", new LuaCSFunction(System_ArrayWrap.get_Rank), null);
		L.RegVar("IsSynchronized", new LuaCSFunction(System_ArrayWrap.get_IsSynchronized), null);
		L.RegVar("SyncRoot", new LuaCSFunction(System_ArrayWrap.get_SyncRoot), null);
		L.RegVar("IsFixedSize", new LuaCSFunction(System_ArrayWrap.get_IsFixedSize), null);
		L.RegVar("IsReadOnly", new LuaCSFunction(System_ArrayWrap.get_IsReadOnly), null);
		L.EndClass();
	}

	private static bool GetPrimitiveValue(IntPtr L, object obj, Type t, int index)
	{
		bool result = true;
		if (t == typeof(float))
		{
			float[] array = obj as float[];
			float num = array[index];
			LuaDLL.lua_pushnumber(L, (double)num);
		}
		else if (t == typeof(int))
		{
			int[] array2 = obj as int[];
			int n = array2[index];
			LuaDLL.lua_pushinteger(L, n);
		}
		else if (t == typeof(double))
		{
			double[] array3 = obj as double[];
			double number = array3[index];
			LuaDLL.lua_pushnumber(L, number);
		}
		else if (t == typeof(bool))
		{
			bool[] array4 = obj as bool[];
			bool value = array4[index];
			LuaDLL.lua_pushboolean(L, value);
		}
		else if (t == typeof(long))
		{
			long[] array5 = obj as long[];
			long n2 = array5[index];
			LuaDLL.tolua_pushint64(L, n2);
		}
		else if (t == typeof(sbyte))
		{
			sbyte[] array6 = obj as sbyte[];
			sbyte b = array6[index];
			LuaDLL.lua_pushnumber(L, (double)b);
		}
		else if (t == typeof(byte))
		{
			byte[] array7 = obj as byte[];
			byte b2 = array7[index];
			LuaDLL.lua_pushnumber(L, (double)b2);
		}
		else if (t == typeof(short))
		{
			short[] array8 = obj as short[];
			short num2 = array8[index];
			LuaDLL.lua_pushnumber(L, (double)num2);
		}
		else if (t == typeof(ushort))
		{
			ushort[] array9 = obj as ushort[];
			ushort num3 = array9[index];
			LuaDLL.lua_pushnumber(L, (double)num3);
		}
		else if (t == typeof(char))
		{
			char[] array10 = obj as char[];
			char c = array10[index];
			LuaDLL.lua_pushnumber(L, (double)c);
		}
		else if (t == typeof(uint))
		{
			uint[] array11 = obj as uint[];
			uint num4 = array11[index];
			LuaDLL.lua_pushnumber(L, num4);
		}
		else
		{
			result = false;
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Item(IntPtr L)
	{
		int result;
		try
		{
			Array array = ToLua.ToObject(L, 1) as Array;
			if (array == null)
			{
				throw new LuaException("trying to index an invalid object reference", null, 1);
			}
			int num = LuaDLL.lua_tointeger(L, 2);
			if (num >= array.Length)
			{
				throw new LuaException(string.Concat(new object[]
				{
					"array index out of bounds: ",
					num,
					" ",
					array.Length
				}), null, 1);
			}
			Type elementType = array.GetType().GetElementType();
			if (elementType.IsValueType)
			{
				if (elementType.IsPrimitive)
				{
					if (System_ArrayWrap.GetPrimitiveValue(L, array, elementType, num))
					{
						result = 1;
						return result;
					}
				}
				else
				{
					if (elementType == typeof(Vector3))
					{
						Vector3[] array2 = array as Vector3[];
						Vector3 v = array2[num];
						ToLua.Push(L, v);
						result = 1;
						return result;
					}
					if (elementType == typeof(Quaternion))
					{
						Quaternion[] array3 = array as Quaternion[];
						Quaternion q = array3[num];
						ToLua.Push(L, q);
						result = 1;
						return result;
					}
					if (elementType == typeof(Vector2))
					{
						Vector2[] array4 = array as Vector2[];
						Vector2 v2 = array4[num];
						ToLua.Push(L, v2);
						result = 1;
						return result;
					}
					if (elementType == typeof(Vector4))
					{
						Vector4[] array5 = array as Vector4[];
						Vector4 v3 = array5[num];
						ToLua.Push(L, v3);
						result = 1;
						return result;
					}
					if (elementType == typeof(Color))
					{
						Color[] array6 = array as Color[];
						Color clr = array6[num];
						ToLua.Push(L, clr);
						result = 1;
						return result;
					}
				}
			}
			object value = array.GetValue(num);
			ToLua.Push(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	private static bool SetPrimitiveValue(IntPtr L, object obj, Type t, int index)
	{
		bool result = true;
		if (t == typeof(float))
		{
			float[] array = obj as float[];
			float num = (float)LuaDLL.luaL_checknumber(L, 3);
			array[index] = num;
		}
		else if (t == typeof(int))
		{
			int[] array2 = obj as int[];
			int num2 = LuaDLL.luaL_checkinteger(L, 3);
			array2[index] = num2;
		}
		else if (t == typeof(double))
		{
			double[] array3 = obj as double[];
			double num3 = LuaDLL.luaL_checknumber(L, 3);
			array3[index] = num3;
		}
		else if (t == typeof(bool))
		{
			bool[] array4 = obj as bool[];
			bool flag = LuaDLL.luaL_checkboolean(L, 3);
			array4[index] = flag;
		}
		else if (t == typeof(long))
		{
			long[] array5 = obj as long[];
			long num4 = LuaDLL.tolua_toint64(L, 3);
			array5[index] = num4;
		}
		else if (t == typeof(sbyte))
		{
			sbyte[] array6 = obj as sbyte[];
			sbyte b = (sbyte)LuaDLL.luaL_checknumber(L, 3);
			array6[index] = b;
		}
		else if (t == typeof(byte))
		{
			byte[] array7 = obj as byte[];
			byte b2 = (byte)LuaDLL.luaL_checknumber(L, 3);
			array7[index] = b2;
		}
		else if (t == typeof(short))
		{
			short[] array8 = obj as short[];
			short num5 = (short)LuaDLL.luaL_checknumber(L, 3);
			array8[index] = num5;
		}
		else if (t == typeof(ushort))
		{
			ushort[] array9 = obj as ushort[];
			ushort num6 = (ushort)LuaDLL.luaL_checknumber(L, 3);
			array9[index] = num6;
		}
		else if (t == typeof(char))
		{
			char[] array10 = obj as char[];
			char c = (char)LuaDLL.luaL_checknumber(L, 3);
			array10[index] = c;
		}
		else if (t == typeof(uint))
		{
			uint[] array11 = obj as uint[];
			uint num7 = (uint)LuaDLL.luaL_checknumber(L, 3);
			array11[index] = num7;
		}
		else
		{
			result = false;
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Item(IntPtr L)
	{
		int result;
		try
		{
			Array array = ToLua.ToObject(L, 1) as Array;
			if (array == null)
			{
				throw new LuaException("trying to index an invalid object reference", null, 1);
			}
			int num = LuaDLL.lua_tointeger(L, 2);
			Type elementType = array.GetType().GetElementType();
			if (elementType.IsValueType)
			{
				if (elementType.IsPrimitive)
				{
					if (System_ArrayWrap.SetPrimitiveValue(L, array, elementType, num))
					{
						result = 0;
						return result;
					}
				}
				else
				{
					if (elementType == typeof(Vector3))
					{
						Vector3[] array2 = array as Vector3[];
						Vector3 vector = ToLua.ToVector3(L, 3);
						array2[num] = vector;
						result = 0;
						return result;
					}
					if (elementType == typeof(Quaternion))
					{
						Quaternion[] array3 = array as Quaternion[];
						Quaternion quaternion = ToLua.ToQuaternion(L, 3);
						array3[num] = quaternion;
						result = 0;
						return result;
					}
					if (elementType == typeof(Vector2))
					{
						Vector2[] array4 = array as Vector2[];
						Vector2 vector2 = ToLua.ToVector2(L, 3);
						array4[num] = vector2;
						result = 0;
						return result;
					}
					if (elementType == typeof(Vector4))
					{
						Vector4[] array5 = array as Vector4[];
						Vector4 vector3 = ToLua.ToVector4(L, 3);
						array5[num] = vector3;
						result = 0;
						return result;
					}
					if (elementType == typeof(Color))
					{
						Color[] array6 = array as Color[];
						Color color = ToLua.ToColor(L, 3);
						array6[num] = color;
						result = 0;
						return result;
					}
				}
			}
			if (!TypeChecker.CheckType(L, elementType, 3))
			{
				result = LuaDLL.luaL_typerror(L, 3, LuaMisc.GetTypeName(elementType), null);
			}
			else
			{
				object obj = ToLua.CheckVarObject(L, 3, elementType);
				obj = TypeChecker.ChangeType(obj, elementType);
				array.SetValue(obj, num);
				result = 0;
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Length(IntPtr L)
	{
		int result;
		try
		{
			Array array = ToLua.ToObject(L, 1) as Array;
			if (array == null)
			{
				throw new LuaException("trying to index an invalid object reference", null, 1);
			}
			LuaDLL.lua_pushinteger(L, array.Length);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToTable(IntPtr L)
	{
		int result;
		try
		{
			Array array = ToLua.ToObject(L, 1) as Array;
			if (array == null)
			{
				throw new LuaException("trying to index an invalid object reference", null, 1);
			}
			LuaDLL.lua_createtable(L, array.Length, 0);
			Type elementType = array.GetType().GetElementType();
			if (elementType.IsValueType)
			{
				if (elementType.IsPrimitive)
				{
					if (elementType == typeof(float))
					{
						float[] array2 = array as float[];
						for (int i = 0; i < array2.Length; i++)
						{
							float num = array2[i];
							LuaDLL.lua_pushnumber(L, (double)num);
							LuaDLL.lua_rawseti(L, -2, i + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(int))
					{
						int[] array3 = array as int[];
						for (int j = 0; j < array3.Length; j++)
						{
							int n = array3[j];
							LuaDLL.lua_pushinteger(L, n);
							LuaDLL.lua_rawseti(L, -2, j + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(double))
					{
						double[] array4 = array as double[];
						for (int k = 0; k < array4.Length; k++)
						{
							double number = array4[k];
							LuaDLL.lua_pushnumber(L, number);
							LuaDLL.lua_rawseti(L, -2, k + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(bool))
					{
						bool[] array5 = array as bool[];
						for (int l = 0; l < array5.Length; l++)
						{
							bool value = array5[l];
							LuaDLL.lua_pushboolean(L, value);
							LuaDLL.lua_rawseti(L, -2, l + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(long))
					{
						long[] array6 = array as long[];
						for (int m = 0; m < array6.Length; m++)
						{
							long n2 = array6[m];
							LuaDLL.tolua_pushint64(L, n2);
							LuaDLL.lua_rawseti(L, -2, m + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(byte))
					{
						byte[] array7 = array as byte[];
						for (int num2 = 0; num2 < array7.Length; num2++)
						{
							byte b = array7[num2];
							LuaDLL.lua_pushnumber(L, (double)b);
							LuaDLL.lua_rawseti(L, -2, num2 + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(sbyte))
					{
						sbyte[] array8 = array as sbyte[];
						for (int num3 = 0; num3 < array8.Length; num3++)
						{
							sbyte b2 = array8[num3];
							LuaDLL.lua_pushnumber(L, (double)b2);
							LuaDLL.lua_rawseti(L, -2, num3 + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(char))
					{
						char[] array9 = array as char[];
						for (int num4 = 0; num4 < array9.Length; num4++)
						{
							char c = array9[num4];
							LuaDLL.lua_pushnumber(L, (double)c);
							LuaDLL.lua_rawseti(L, -2, num4 + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(uint))
					{
						uint[] array10 = array as uint[];
						for (int num5 = 0; num5 < array10.Length; num5++)
						{
							uint num6 = array10[num5];
							LuaDLL.lua_pushnumber(L, num6);
							LuaDLL.lua_rawseti(L, -2, num5 + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(short))
					{
						short[] array11 = array as short[];
						for (int num7 = 0; num7 < array11.Length; num7++)
						{
							short num8 = array11[num7];
							LuaDLL.lua_pushnumber(L, (double)num8);
							LuaDLL.lua_rawseti(L, -2, num7 + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(ushort))
					{
						ushort[] array12 = array as ushort[];
						for (int num9 = 0; num9 < array12.Length; num9++)
						{
							ushort num10 = array12[num9];
							LuaDLL.lua_pushnumber(L, (double)num10);
							LuaDLL.lua_rawseti(L, -2, num9 + 1);
						}
						result = 1;
						return result;
					}
				}
				else
				{
					if (elementType == typeof(Vector3))
					{
						Vector3[] array13 = array as Vector3[];
						for (int num11 = 0; num11 < array13.Length; num11++)
						{
							Vector3 v = array13[num11];
							ToLua.Push(L, v);
							LuaDLL.lua_rawseti(L, -2, num11 + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(Quaternion))
					{
						Quaternion[] array14 = array as Quaternion[];
						for (int num12 = 0; num12 < array14.Length; num12++)
						{
							Quaternion q = array14[num12];
							ToLua.Push(L, q);
							LuaDLL.lua_rawseti(L, -2, num12 + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(Vector2))
					{
						Vector2[] array15 = array as Vector2[];
						for (int num13 = 0; num13 < array15.Length; num13++)
						{
							Vector2 v2 = array15[num13];
							ToLua.Push(L, v2);
							LuaDLL.lua_rawseti(L, -2, num13 + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(Vector4))
					{
						Vector4[] array16 = array as Vector4[];
						for (int num14 = 0; num14 < array16.Length; num14++)
						{
							Vector4 v3 = array16[num14];
							ToLua.Push(L, v3);
							LuaDLL.lua_rawseti(L, -2, num14 + 1);
						}
						result = 1;
						return result;
					}
					if (elementType == typeof(Color))
					{
						Color[] array17 = array as Color[];
						for (int num15 = 0; num15 < array17.Length; num15++)
						{
							Color clr = array17[num15];
							ToLua.Push(L, clr);
							LuaDLL.lua_rawseti(L, -2, num15 + 1);
						}
						result = 1;
						return result;
					}
				}
			}
			for (int num16 = 0; num16 < array.Length; num16++)
			{
				object value2 = array.GetValue(num16);
				ToLua.Push(L, value2);
				LuaDLL.lua_rawseti(L, -2, num16 + 1);
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
	private static int GetLength(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Array array = (Array)ToLua.CheckObject(L, 1, typeof(Array));
			int dimension = (int)LuaDLL.luaL_checknumber(L, 2);
			int length = array.GetLength(dimension);
			LuaDLL.lua_pushinteger(L, length);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLongLength(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Array array = (Array)ToLua.CheckObject(L, 1, typeof(Array));
			int dimension = (int)LuaDLL.luaL_checknumber(L, 2);
			long longLength = array.GetLongLength(dimension);
			LuaDLL.lua_pushnumber(L, (double)longLength);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLowerBound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Array array = (Array)ToLua.CheckObject(L, 1, typeof(Array));
			int dimension = (int)LuaDLL.luaL_checknumber(L, 2);
			int lowerBound = array.GetLowerBound(dimension);
			LuaDLL.lua_pushinteger(L, lowerBound);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetValue(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(long)))
			{
				Array array = (Array)ToLua.ToObject(L, 1);
				long index = (long)LuaDLL.lua_tonumber(L, 2);
				object value = array.GetValue(index);
				ToLua.Push(L, value);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(long), typeof(long)))
			{
				Array array2 = (Array)ToLua.ToObject(L, 1);
				long index2 = (long)LuaDLL.lua_tonumber(L, 2);
				long index3 = (long)LuaDLL.lua_tonumber(L, 3);
				object value2 = array2.GetValue(index2, index3);
				ToLua.Push(L, value2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(int), typeof(int)))
			{
				Array array3 = (Array)ToLua.ToObject(L, 1);
				int index4 = (int)LuaDLL.lua_tonumber(L, 2);
				int index5 = (int)LuaDLL.lua_tonumber(L, 3);
				object value3 = array3.GetValue(index4, index5);
				ToLua.Push(L, value3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(long), typeof(long), typeof(long)))
			{
				Array array4 = (Array)ToLua.ToObject(L, 1);
				long index6 = (long)LuaDLL.lua_tonumber(L, 2);
				long index7 = (long)LuaDLL.lua_tonumber(L, 3);
				long index8 = (long)LuaDLL.lua_tonumber(L, 4);
				object value4 = array4.GetValue(index6, index7, index8);
				ToLua.Push(L, value4);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(int), typeof(int), typeof(int)))
			{
				Array array5 = (Array)ToLua.ToObject(L, 1);
				int index9 = (int)LuaDLL.lua_tonumber(L, 2);
				int index10 = (int)LuaDLL.lua_tonumber(L, 3);
				int index11 = (int)LuaDLL.lua_tonumber(L, 4);
				object value5 = array5.GetValue(index9, index10, index11);
				ToLua.Push(L, value5);
				result = 1;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(long), 2, num - 1))
			{
				Array array6 = (Array)ToLua.ToObject(L, 1);
				long[] indices = ToLua.ToParamsNumber<long>(L, 2, num - 1);
				object value6 = array6.GetValue(indices);
				ToLua.Push(L, value6);
				result = 1;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(int), 2, num - 1))
			{
				Array array7 = (Array)ToLua.ToObject(L, 1);
				int[] indices2 = ToLua.ToParamsNumber<int>(L, 2, num - 1);
				object value7 = array7.GetValue(indices2);
				ToLua.Push(L, value7);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Array.GetValue");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetValue(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object), typeof(long)))
			{
				Array array = (Array)ToLua.ToObject(L, 1);
				object value = ToLua.ToVarObject(L, 2, array.GetType().GetElementType());
				long index = (long)LuaDLL.lua_tonumber(L, 3);
				array.SetValue(value, index);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object), typeof(int), typeof(int)))
			{
				Array array2 = (Array)ToLua.ToObject(L, 1);
				object value2 = ToLua.ToVarObject(L, 2, array2.GetType().GetElementType());
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int index3 = (int)LuaDLL.lua_tonumber(L, 4);
				array2.SetValue(value2, index2, index3);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object), typeof(long), typeof(long)))
			{
				Array array3 = (Array)ToLua.ToObject(L, 1);
				object value3 = ToLua.ToVarObject(L, 2, array3.GetType().GetElementType());
				long index4 = (long)LuaDLL.lua_tonumber(L, 3);
				long index5 = (long)LuaDLL.lua_tonumber(L, 4);
				array3.SetValue(value3, index4, index5);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object), typeof(int), typeof(int), typeof(int)))
			{
				Array array4 = (Array)ToLua.ToObject(L, 1);
				object value4 = ToLua.ToVarObject(L, 2, array4.GetType().GetElementType());
				int index6 = (int)LuaDLL.lua_tonumber(L, 3);
				int index7 = (int)LuaDLL.lua_tonumber(L, 4);
				int index8 = (int)LuaDLL.lua_tonumber(L, 5);
				array4.SetValue(value4, index6, index7, index8);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object), typeof(long), typeof(long), typeof(long)))
			{
				Array array5 = (Array)ToLua.ToObject(L, 1);
				object value5 = ToLua.ToVarObject(L, 2, array5.GetType().GetElementType());
				long index9 = (long)LuaDLL.lua_tonumber(L, 3);
				long index10 = (long)LuaDLL.lua_tonumber(L, 4);
				long index11 = (long)LuaDLL.lua_tonumber(L, 5);
				array5.SetValue(value5, index9, index10, index11);
				result = 0;
			}
			else if (TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object)) && TypeChecker.CheckParamsType(L, typeof(long), 3, num - 2))
			{
				Array array6 = (Array)ToLua.ToObject(L, 1);
				object value6 = ToLua.ToVarObject(L, 2, array6.GetType().GetElementType());
				long[] indices = ToLua.ToParamsNumber<long>(L, 3, num - 2);
				array6.SetValue(value6, indices);
				result = 0;
			}
			else if (TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object)) && TypeChecker.CheckParamsType(L, typeof(int), 3, num - 2))
			{
				Array array7 = (Array)ToLua.ToObject(L, 1);
				object value7 = ToLua.ToVarObject(L, 2, array7.GetType().GetElementType());
				int[] indices2 = ToLua.ToParamsNumber<int>(L, 3, num - 2);
				array7.SetValue(value7, indices2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Array.SetValue");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEnumerator(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Array array = (Array)ToLua.CheckObject(L, 1, typeof(Array));
			IEnumerator enumerator = array.GetEnumerator();
			ToLua.Push(L, enumerator);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetUpperBound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Array array = (Array)ToLua.CheckObject(L, 1, typeof(Array));
			int dimension = (int)LuaDLL.luaL_checknumber(L, 2);
			int upperBound = array.GetUpperBound(dimension);
			LuaDLL.lua_pushinteger(L, upperBound);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateInstance(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(int)))
			{
				Type elementType = (Type)ToLua.ToObject(L, 1);
				int length = (int)LuaDLL.lua_tonumber(L, 2);
				Array array = Array.CreateInstance(elementType, length);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(int[]), typeof(int[])))
			{
				Type elementType2 = (Type)ToLua.ToObject(L, 1);
				int[] lengths = ToLua.CheckNumberArray<int>(L, 2);
				int[] lowerBounds = ToLua.CheckNumberArray<int>(L, 3);
				Array array2 = Array.CreateInstance(elementType2, lengths, lowerBounds);
				ToLua.Push(L, array2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(int), typeof(int)))
			{
				Type elementType3 = (Type)ToLua.ToObject(L, 1);
				int length2 = (int)LuaDLL.lua_tonumber(L, 2);
				int length3 = (int)LuaDLL.lua_tonumber(L, 3);
				Array array3 = Array.CreateInstance(elementType3, length2, length3);
				ToLua.Push(L, array3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(int), typeof(int), typeof(int)))
			{
				Type elementType4 = (Type)ToLua.ToObject(L, 1);
				int length4 = (int)LuaDLL.lua_tonumber(L, 2);
				int length5 = (int)LuaDLL.lua_tonumber(L, 3);
				int length6 = (int)LuaDLL.lua_tonumber(L, 4);
				Array array4 = Array.CreateInstance(elementType4, length4, length5, length6);
				ToLua.Push(L, array4);
				result = 1;
			}
			else if (TypeChecker.CheckTypes(L, 1, typeof(Type)) && TypeChecker.CheckParamsType(L, typeof(long), 2, num - 1))
			{
				Type elementType5 = (Type)ToLua.ToObject(L, 1);
				long[] lengths2 = ToLua.ToParamsNumber<long>(L, 2, num - 1);
				Array array5 = Array.CreateInstance(elementType5, lengths2);
				ToLua.Push(L, array5);
				result = 1;
			}
			else if (TypeChecker.CheckTypes(L, 1, typeof(Type)) && TypeChecker.CheckParamsType(L, typeof(int), 2, num - 1))
			{
				Type elementType6 = (Type)ToLua.ToObject(L, 1);
				int[] lengths3 = ToLua.ToParamsNumber<int>(L, 2, num - 1);
				Array array6 = Array.CreateInstance(elementType6, lengths3);
				ToLua.Push(L, array6);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Array.CreateInstance");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BinarySearch(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object)))
			{
				Array array = (Array)ToLua.ToObject(L, 1);
				object value = ToLua.ToVarObject(L, 2, array.GetType().GetElementType());
				int n = Array.BinarySearch(array, value);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object), typeof(IComparer)))
			{
				Array array2 = (Array)ToLua.ToObject(L, 1);
				object value2 = ToLua.ToVarObject(L, 2, array2.GetType().GetElementType());
				IComparer comparer = (IComparer)ToLua.ToObject(L, 3);
				int n2 = Array.BinarySearch(array2, value2, comparer);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(int), typeof(int), typeof(object)))
			{
				Array array3 = (Array)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int length = (int)LuaDLL.lua_tonumber(L, 3);
				object value3 = ToLua.ToVarObject(L, 4, array3.GetType().GetElementType());
				int n3 = Array.BinarySearch(array3, index, length, value3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(int), typeof(int), typeof(object), typeof(IComparer)))
			{
				Array array4 = (Array)ToLua.ToObject(L, 1);
				int index2 = (int)LuaDLL.lua_tonumber(L, 2);
				int length2 = (int)LuaDLL.lua_tonumber(L, 3);
				object value4 = ToLua.ToVarObject(L, 4, array4.GetType().GetElementType());
				IComparer comparer2 = (IComparer)ToLua.ToObject(L, 5);
				int n4 = Array.BinarySearch(array4, index2, length2, value4, comparer2);
				LuaDLL.lua_pushinteger(L, n4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Array.BinarySearch");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Array array = (Array)ToLua.CheckObject(L, 1, typeof(Array));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			int length = (int)LuaDLL.luaL_checknumber(L, 3);
			Array.Clear(array, index, length);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clone(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Array array = (Array)ToLua.CheckObject(L, 1, typeof(Array));
			object obj = array.Clone();
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
	private static int Copy(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(Array), typeof(long)))
			{
				Array sourceArray = (Array)ToLua.ToObject(L, 1);
				Array destinationArray = (Array)ToLua.ToObject(L, 2);
				long length = (long)LuaDLL.lua_tonumber(L, 3);
				Array.Copy(sourceArray, destinationArray, length);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(long), typeof(Array), typeof(long), typeof(long)))
			{
				Array sourceArray2 = (Array)ToLua.ToObject(L, 1);
				long sourceIndex = (long)LuaDLL.lua_tonumber(L, 2);
				Array destinationArray2 = (Array)ToLua.ToObject(L, 3);
				long destinationIndex = (long)LuaDLL.lua_tonumber(L, 4);
				long length2 = (long)LuaDLL.lua_tonumber(L, 5);
				Array.Copy(sourceArray2, sourceIndex, destinationArray2, destinationIndex, length2);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(int), typeof(Array), typeof(int), typeof(int)))
			{
				Array sourceArray3 = (Array)ToLua.ToObject(L, 1);
				int sourceIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				Array destinationArray3 = (Array)ToLua.ToObject(L, 3);
				int destinationIndex2 = (int)LuaDLL.lua_tonumber(L, 4);
				int length3 = (int)LuaDLL.lua_tonumber(L, 5);
				Array.Copy(sourceArray3, sourceIndex2, destinationArray3, destinationIndex2, length3);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Array.Copy");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IndexOf(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object)))
			{
				Array array = (Array)ToLua.ToObject(L, 1);
				object value = ToLua.ToVarObject(L, 2, array.GetType().GetElementType());
				int n = Array.IndexOf(array, value);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object), typeof(int)))
			{
				Array array2 = (Array)ToLua.ToObject(L, 1);
				object value2 = ToLua.ToVarObject(L, 2, array2.GetType().GetElementType());
				int startIndex = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = Array.IndexOf(array2, value2, startIndex);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object), typeof(int), typeof(int)))
			{
				Array array3 = (Array)ToLua.ToObject(L, 1);
				object value3 = ToLua.ToVarObject(L, 2, array3.GetType().GetElementType());
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = Array.IndexOf(array3, value3, startIndex2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Array.IndexOf");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Initialize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Array array = (Array)ToLua.CheckObject(L, 1, typeof(Array));
			array.Initialize();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LastIndexOf(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object)))
			{
				Array array = (Array)ToLua.ToObject(L, 1);
				object value = ToLua.ToVarObject(L, 2, array.GetType().GetElementType());
				int n = Array.LastIndexOf(array, value);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object), typeof(int)))
			{
				Array array2 = (Array)ToLua.ToObject(L, 1);
				object value2 = ToLua.ToVarObject(L, 2, array2.GetType().GetElementType());
				int startIndex = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = Array.LastIndexOf(array2, value2, startIndex);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(object), typeof(int), typeof(int)))
			{
				Array array3 = (Array)ToLua.ToObject(L, 1);
				object value3 = ToLua.ToVarObject(L, 2, array3.GetType().GetElementType());
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = Array.LastIndexOf(array3, value3, startIndex2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Array.LastIndexOf");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reverse(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Array)))
			{
				Array array = (Array)ToLua.ToObject(L, 1);
				Array.Reverse(array);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(int), typeof(int)))
			{
				Array array2 = (Array)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int length = (int)LuaDLL.lua_tonumber(L, 3);
				Array.Reverse(array2, index, length);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Array.Reverse");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Sort(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Array)))
			{
				Array array = (Array)ToLua.ToObject(L, 1);
				Array.Sort(array);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(IComparer)))
			{
				Array array2 = (Array)ToLua.ToObject(L, 1);
				IComparer comparer = (IComparer)ToLua.ToObject(L, 2);
				Array.Sort(array2, comparer);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(Array)))
			{
				Array keys = (Array)ToLua.ToObject(L, 1);
				Array items = (Array)ToLua.ToObject(L, 2);
				Array.Sort(keys, items);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(Array), typeof(IComparer)))
			{
				Array keys2 = (Array)ToLua.ToObject(L, 1);
				Array items2 = (Array)ToLua.ToObject(L, 2);
				IComparer comparer2 = (IComparer)ToLua.ToObject(L, 3);
				Array.Sort(keys2, items2, comparer2);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(int), typeof(int)))
			{
				Array array3 = (Array)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int length = (int)LuaDLL.lua_tonumber(L, 3);
				Array.Sort(array3, index, length);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(int), typeof(int), typeof(IComparer)))
			{
				Array array4 = (Array)ToLua.ToObject(L, 1);
				int index2 = (int)LuaDLL.lua_tonumber(L, 2);
				int length2 = (int)LuaDLL.lua_tonumber(L, 3);
				IComparer comparer3 = (IComparer)ToLua.ToObject(L, 4);
				Array.Sort(array4, index2, length2, comparer3);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(Array), typeof(int), typeof(int)))
			{
				Array keys3 = (Array)ToLua.ToObject(L, 1);
				Array items3 = (Array)ToLua.ToObject(L, 2);
				int index3 = (int)LuaDLL.lua_tonumber(L, 3);
				int length3 = (int)LuaDLL.lua_tonumber(L, 4);
				Array.Sort(keys3, items3, index3, length3);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Array), typeof(Array), typeof(int), typeof(int), typeof(IComparer)))
			{
				Array keys4 = (Array)ToLua.ToObject(L, 1);
				Array items4 = (Array)ToLua.ToObject(L, 2);
				int index4 = (int)LuaDLL.lua_tonumber(L, 3);
				int length4 = (int)LuaDLL.lua_tonumber(L, 4);
				IComparer comparer4 = (IComparer)ToLua.ToObject(L, 5);
				Array.Sort(keys4, items4, index4, length4, comparer4);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Array.Sort");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Array array = (Array)ToLua.CheckObject(L, 1, typeof(Array));
			Array array2 = (Array)ToLua.CheckObject(L, 2, typeof(Array));
			long index = (long)LuaDLL.luaL_checknumber(L, 3);
			array.CopyTo(array2, index);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConstrainedCopy(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			Array sourceArray = (Array)ToLua.CheckObject(L, 1, typeof(Array));
			int sourceIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			Array destinationArray = (Array)ToLua.CheckObject(L, 3, typeof(Array));
			int destinationIndex = (int)LuaDLL.luaL_checknumber(L, 4);
			int length = (int)LuaDLL.luaL_checknumber(L, 5);
			Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_ToString(IntPtr L)
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LongLength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Array array = (Array)obj;
			long longLength = array.LongLength;
			LuaDLL.lua_pushnumber(L, (double)longLength);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LongLength on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Rank(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Array array = (Array)obj;
			int rank = array.Rank;
			LuaDLL.lua_pushinteger(L, rank);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Rank on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsSynchronized(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Array array = (Array)obj;
			bool isSynchronized = array.IsSynchronized;
			LuaDLL.lua_pushboolean(L, isSynchronized);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsSynchronized on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_SyncRoot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Array array = (Array)obj;
			object syncRoot = array.SyncRoot;
			ToLua.Push(L, syncRoot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SyncRoot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsFixedSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Array array = (Array)obj;
			bool isFixedSize = array.IsFixedSize;
			LuaDLL.lua_pushboolean(L, isFixedSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsFixedSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsReadOnly(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Array array = (Array)obj;
			bool isReadOnly = array.IsReadOnly;
			LuaDLL.lua_pushboolean(L, isReadOnly);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsReadOnly on a nil value");
		}
		return result;
	}
}
