using System;
using System.Collections.Generic;
using System.Reflection;

namespace LuaInterface
{
	public static class LuaMethodCache
	{
		public static Dictionary<Type, Dictionary<string, List<MethodInfo>>> dict = new Dictionary<Type, Dictionary<string, List<MethodInfo>>>();

		private static MethodInfo GetMethod(Type t, string name, Type[] ts)
		{
			Dictionary<string, List<MethodInfo>> dictionary = null;
			List<MethodInfo> list = null;
			if (!LuaMethodCache.dict.TryGetValue(t, out dictionary))
			{
				dictionary = new Dictionary<string, List<MethodInfo>>();
				LuaMethodCache.dict.Add(t, dictionary);
			}
			if (!dictionary.TryGetValue(name, out list))
			{
				list = new List<MethodInfo>();
				MethodInfo[] methods = t.GetMethods();
				for (int i = 0; i < methods.Length; i++)
				{
					if (methods[i].Name == name)
					{
						list.Add(methods[i]);
					}
				}
				dictionary.Add(name, list);
			}
			if (list.Count == 1)
			{
				return list[0];
			}
			for (int j = 0; j < list.Count; j++)
			{
				ParameterInfo[] parameters = list[j].GetParameters();
				bool flag = true;
				if (parameters.Length == 0 && (ts == null || ts.Length == 0))
				{
					return list[j];
				}
				if (parameters.Length == ts.Length)
				{
					for (int k = 0; k < ts.Length; k++)
					{
						if (parameters[k].ParameterType != ts[k])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		public static object CallSingleMethod(string name, object obj, params object[] args)
		{
			MethodInfo method = LuaMethodCache.GetMethod(obj.GetType(), name, null);
			return method.Invoke(obj, args);
		}

		public static object CallMethod(string name, object obj, params object[] args)
		{
			Type[] array = new Type[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				array[i] = args[i].GetType();
			}
			MethodInfo method = LuaMethodCache.GetMethod(obj.GetType(), name, array);
			return method.Invoke(obj, args);
		}
	}
}
