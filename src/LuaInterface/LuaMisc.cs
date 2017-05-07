using System;
using System.Reflection;
using System.Text;

namespace LuaInterface
{
	[NoToLua]
	public static class LuaMisc
	{
		public static string GetArrayRank(Type t)
		{
			int arrayRank = t.GetArrayRank();
			if (arrayRank == 1)
			{
				return "[]";
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.Append('[');
			for (int i = 1; i < arrayRank; i++)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(']');
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public static string GetTypeName(Type t)
		{
			if (t.IsArray)
			{
				string typeName = LuaMisc.GetTypeName(t.GetElementType());
				return typeName + LuaMisc.GetArrayRank(t);
			}
			if (t.IsByRef)
			{
				t = t.GetElementType();
				return LuaMisc.GetTypeName(t);
			}
			if (t.IsGenericType)
			{
				return LuaMisc.GetGenericName(t);
			}
			if (t == typeof(void))
			{
				return "void";
			}
			string primitiveStr = LuaMisc.GetPrimitiveStr(t);
			return primitiveStr.Replace('+', '.');
		}

		public static string[] GetGenericName(Type[] types, int offset, int count)
		{
			string[] array = new string[count];
			for (int i = 0; i < count; i++)
			{
				int num = i + offset;
				if (types[num].IsGenericType)
				{
					array[i] = LuaMisc.GetGenericName(types[num]);
				}
				else
				{
					array[i] = LuaMisc.GetTypeName(types[num]);
				}
			}
			return array;
		}

		private static string CombineTypeStr(string space, string name)
		{
			if (string.IsNullOrEmpty(space))
			{
				return name;
			}
			return space + "." + name;
		}

		private static string GetGenericName(Type t)
		{
			Type[] genericArguments = t.GetGenericArguments();
			string text = t.FullName;
			int num = genericArguments.Length;
			int i = text.IndexOf("[");
			if (i > 0)
			{
				text = text.Substring(0, i);
			}
			string space = null;
			int num2 = 0;
			string text2;
			for (i = text.IndexOf("+"); i > 0; i = text.IndexOf("+"))
			{
				text2 = text.Substring(0, i);
				text = text.Substring(i + 1);
				i = text2.IndexOf('`');
				if (i > 0)
				{
					num = (int)(text2[i + 1] - '0');
					text2 = text2.Substring(0, i);
					text2 = text2 + "<" + string.Join(",", LuaMisc.GetGenericName(genericArguments, num2, num)) + ">";
					num2 += num;
				}
				space = LuaMisc.CombineTypeStr(space, text2);
			}
			text2 = text;
			if (num2 < genericArguments.Length)
			{
				i = text2.IndexOf('`');
				num = (int)(text2[i + 1] - '0');
				text2 = text2.Substring(0, i);
				text2 = text2 + "<" + string.Join(",", LuaMisc.GetGenericName(genericArguments, num2, num)) + ">";
			}
			return LuaMisc.CombineTypeStr(space, text2);
		}

		public static Delegate GetEventHandler(object obj, Type t, string eventName)
		{
			FieldInfo field = t.GetField(eventName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			return (Delegate)field.GetValue(obj);
		}

		public static string GetPrimitiveStr(Type t)
		{
			if (t == typeof(float))
			{
				return "float";
			}
			if (t == typeof(string))
			{
				return "string";
			}
			if (t == typeof(int))
			{
				return "int";
			}
			if (t == typeof(double))
			{
				return "double";
			}
			if (t == typeof(bool))
			{
				return "bool";
			}
			if (t == typeof(uint))
			{
				return "uint";
			}
			if (t == typeof(sbyte))
			{
				return "sbyte";
			}
			if (t == typeof(byte))
			{
				return "byte";
			}
			if (t == typeof(short))
			{
				return "short";
			}
			if (t == typeof(ushort))
			{
				return "ushort";
			}
			if (t == typeof(char))
			{
				return "char";
			}
			if (t == typeof(long))
			{
				return "long";
			}
			if (t == typeof(ulong))
			{
				return "ulong";
			}
			if (t == typeof(decimal))
			{
				return "decimal";
			}
			if (t == typeof(object))
			{
				return "object";
			}
			return t.ToString();
		}

		public static double ToDouble(object obj)
		{
			Type type = obj.GetType();
			if (type == typeof(double) || type == typeof(float))
			{
				return Convert.ToDouble(obj);
			}
			if (type == typeof(int))
			{
				int num = Convert.ToInt32(obj);
				return (double)num;
			}
			if (type == typeof(uint))
			{
				uint num2 = Convert.ToUInt32(obj);
				return num2;
			}
			if (type == typeof(long))
			{
				long num3 = Convert.ToInt64(obj);
				return (double)num3;
			}
			if (type == typeof(ulong))
			{
				ulong num4 = Convert.ToUInt64(obj);
				return num4;
			}
			if (type == typeof(byte))
			{
				byte b = Convert.ToByte(obj);
				return (double)b;
			}
			if (type == typeof(sbyte))
			{
				sbyte b2 = Convert.ToSByte(obj);
				return (double)b2;
			}
			if (type == typeof(char))
			{
				char c = Convert.ToChar(obj);
				return (double)c;
			}
			if (type == typeof(short))
			{
				short num5 = Convert.ToInt16(obj);
				return (double)num5;
			}
			if (type == typeof(ushort))
			{
				ushort num6 = Convert.ToUInt16(obj);
				return (double)num6;
			}
			return 0.0;
		}

		public static Type GetExportBaseType(Type t)
		{
			Type baseType = t.BaseType;
			if (baseType == typeof(ValueType))
			{
				return null;
			}
			if (t.IsAbstract && t.IsSealed)
			{
				return (baseType != typeof(object)) ? baseType : null;
			}
			return baseType;
		}
	}
}
