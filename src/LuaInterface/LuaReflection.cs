using System;
using System.Collections.Generic;
using System.Reflection;

namespace LuaInterface
{
	public class LuaReflection : IDisposable
	{
		public List<Assembly> list = new List<Assembly>();

		private static LuaReflection _reflection;

		public LuaReflection()
		{
			LuaReflection._reflection = this;
			this.LoadAssembly("mscorlib");
			this.LoadAssembly("UnityEngine");
		}

		public static void OpenLibs(IntPtr L)
		{
			LuaDLL.lua_getglobal(L, "tolua");
			LuaDLL.lua_pushstring(L, "findtype");
			LuaDLL.lua_pushcfunction(L, new LuaCSFunction(LuaReflection.FindType));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pushstring(L, "loadassembly");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(LuaReflection.LoadAssembly));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pushstring(L, "getmethod");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(LuaReflection.GetMethod));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pushstring(L, "getconstructor");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(LuaReflection.GetConstructor));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pushstring(L, "gettypemethod");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(LuaReflection.GetTypeMethod));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pushstring(L, "getfield");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(LuaReflection.GetField));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pushstring(L, "getproperty");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(LuaReflection.GetProperty));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pushstring(L, "createinstance");
			LuaDLL.tolua_pushcfunction(L, new LuaCSFunction(LuaReflection.CreateInstance));
			LuaDLL.lua_rawset(L, -3);
			LuaDLL.lua_pop(L, 1);
			LuaState luaState = LuaState.Get(L);
			luaState.BeginPreLoad();
			luaState.AddPreLoad("tolua.reflection", new LuaCSFunction(LuaReflection.OpenReflectionLibs));
			luaState.EndPreLoad();
		}

		public static LuaReflection Get(IntPtr L)
		{
			return LuaReflection._reflection;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int OpenReflectionLibs(IntPtr L)
		{
			int result;
			try
			{
				LuaState luaState = LuaState.Get(L);
				luaState.BeginModule(null);
				luaState.BeginModule("LuaInterface");
				LuaInterface_LuaMethodWrap.Register(luaState);
				LuaInterface_LuaPropertyWrap.Register(luaState);
				LuaInterface_LuaFieldWrap.Register(luaState);
				LuaInterface_LuaConstructorWrap.Register(luaState);
				luaState.EndModule();
				luaState.EndModule();
				result = 0;
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int FindType(IntPtr L)
		{
			string name = ToLua.CheckString(L, 1);
			LuaReflection luaReflection = LuaReflection.Get(L);
			List<Assembly> list = luaReflection.list;
			Type type = null;
			for (int i = 0; i < list.Count; i++)
			{
				type = list[i].GetType(name);
				if (type != null)
				{
					break;
				}
			}
			ToLua.Push(L, type);
			return 1;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int LoadAssembly(IntPtr L)
		{
			try
			{
				LuaReflection luaReflection = LuaReflection.Get(L);
				string name = ToLua.CheckString(L, 1);
				LuaDLL.lua_pushboolean(L, luaReflection.LoadAssembly(name));
			}
			catch (Exception e)
			{
				return LuaDLL.toluaL_exception(L, e, null);
			}
			return 1;
		}

		private static void PushLuaMethod(IntPtr L, MethodInfo md, Type t, Type[] types)
		{
			if (md != null)
			{
				LuaMethod o = new LuaMethod(md, t, types);
				ToLua.PushObject(L, o);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int GetMethod(IntPtr L)
		{
			try
			{
				int num = LuaDLL.lua_gettop(L);
				Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
				string name = ToLua.CheckString(L, 2);
				Type[] array = null;
				if (num > 2)
				{
					array = new Type[num - 2];
					for (int i = 3; i <= num; i++)
					{
						Type type2 = (Type)ToLua.CheckObject(L, i, typeof(Type));
						if (type2 == null)
						{
							LuaDLL.luaL_typerror(L, i, "Type", null);
						}
						array[i - 3] = type2;
					}
				}
				MethodInfo method;
				if (array == null)
				{
					method = type.GetMethod(name);
				}
				else
				{
					method = type.GetMethod(name, array);
				}
				LuaReflection.PushLuaMethod(L, method, type, array);
			}
			catch (Exception e)
			{
				return LuaDLL.toluaL_exception(L, e, null);
			}
			return 1;
		}

		private static void PushLuaConstructor(IntPtr L, ConstructorInfo func, Type[] types)
		{
			if (func != null)
			{
				LuaConstructor o = new LuaConstructor(func, types);
				ToLua.PushObject(L, o);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int GetConstructor(IntPtr L)
		{
			try
			{
				int num = LuaDLL.lua_gettop(L);
				Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
				Type[] array = null;
				if (num > 1)
				{
					array = new Type[num - 1];
					for (int i = 2; i <= num; i++)
					{
						Type type2 = (Type)ToLua.CheckObject(L, i, typeof(Type));
						if (type2 == null)
						{
							LuaDLL.luaL_typerror(L, i, "Type", null);
						}
						array[i - 2] = type2;
					}
				}
				ConstructorInfo constructor = type.GetConstructor(array);
				LuaReflection.PushLuaConstructor(L, constructor, array);
			}
			catch (Exception e)
			{
				return LuaDLL.toluaL_exception(L, e, null);
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int GetTypeMethod(IntPtr L)
		{
			int result;
			try
			{
				int num = LuaDLL.lua_gettop(L);
				if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string)))
				{
					Type type = (Type)ToLua.ToObject(L, 1);
					string name = ToLua.ToString(L, 2);
					MethodInfo method = type.GetMethod(name);
					LuaReflection.PushLuaMethod(L, method, type, null);
					result = 1;
				}
				else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(Type[])))
				{
					Type type2 = (Type)ToLua.ToObject(L, 1);
					string name2 = ToLua.ToString(L, 2);
					Type[] types = ToLua.CheckObjectArray<Type>(L, 3);
					MethodInfo method2 = type2.GetMethod(name2, types);
					LuaReflection.PushLuaMethod(L, method2, type2, types);
					result = 1;
				}
				else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(uint)))
				{
					Type type3 = (Type)ToLua.ToObject(L, 1);
					string name3 = ToLua.ToString(L, 2);
					BindingFlags bindingAttr = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
					MethodInfo method3 = type3.GetMethod(name3, bindingAttr);
					LuaReflection.PushLuaMethod(L, method3, type3, null);
					result = 1;
				}
				else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(Type[]), typeof(ParameterModifier[])))
				{
					Type type4 = (Type)ToLua.ToObject(L, 1);
					string name4 = ToLua.ToString(L, 2);
					Type[] types2 = ToLua.CheckObjectArray<Type>(L, 3);
					ParameterModifier[] modifiers = ToLua.CheckObjectArray<ParameterModifier>(L, 4);
					MethodInfo method4 = type4.GetMethod(name4, types2, modifiers);
					LuaReflection.PushLuaMethod(L, method4, type4, types2);
					result = 1;
				}
				else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(uint), typeof(Binder), typeof(Type[]), typeof(ParameterModifier[])))
				{
					Type type5 = (Type)ToLua.ToObject(L, 1);
					string name5 = ToLua.ToString(L, 2);
					BindingFlags bindingAttr2 = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
					Binder binder = (Binder)ToLua.ToObject(L, 4);
					Type[] types3 = ToLua.CheckObjectArray<Type>(L, 5);
					ParameterModifier[] modifiers2 = ToLua.CheckObjectArray<ParameterModifier>(L, 6);
					MethodInfo method5 = type5.GetMethod(name5, bindingAttr2, binder, types3, modifiers2);
					LuaReflection.PushLuaMethod(L, method5, type5, types3);
					result = 1;
				}
				else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(uint), typeof(Binder), typeof(CallingConventions), typeof(Type[]), typeof(ParameterModifier[])))
				{
					Type type6 = (Type)ToLua.ToObject(L, 1);
					string name6 = ToLua.ToString(L, 2);
					BindingFlags bindingAttr3 = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
					Binder binder2 = (Binder)ToLua.ToObject(L, 4);
					CallingConventions callConvention = (CallingConventions)((int)ToLua.ToObject(L, 5));
					Type[] types4 = ToLua.CheckObjectArray<Type>(L, 6);
					ParameterModifier[] modifiers3 = ToLua.CheckObjectArray<ParameterModifier>(L, 7);
					MethodInfo method6 = type6.GetMethod(name6, bindingAttr3, binder2, callConvention, types4, modifiers3);
					LuaReflection.PushLuaMethod(L, method6, type6, types4);
					result = 1;
				}
				else
				{
					result = LuaDLL.luaL_throw(L, "invalid arguments to method: tolua.gettypemethod");
				}
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		private static void PushLuaProperty(IntPtr L, PropertyInfo p, Type t)
		{
			if (p != null)
			{
				LuaProperty o = new LuaProperty(p, t);
				ToLua.PushObject(L, o);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int GetProperty(IntPtr L)
		{
			int result;
			try
			{
				int num = LuaDLL.lua_gettop(L);
				if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string)))
				{
					Type type = (Type)ToLua.ToObject(L, 1);
					string name = ToLua.ToString(L, 2);
					PropertyInfo property = type.GetProperty(name);
					LuaReflection.PushLuaProperty(L, property, type);
					result = 1;
				}
				else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(Type[])))
				{
					Type type2 = (Type)ToLua.ToObject(L, 1);
					string name2 = ToLua.ToString(L, 2);
					Type[] types = ToLua.CheckObjectArray<Type>(L, 3);
					PropertyInfo property2 = type2.GetProperty(name2, types);
					LuaReflection.PushLuaProperty(L, property2, type2);
					result = 1;
				}
				else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(Type)))
				{
					Type type3 = (Type)ToLua.ToObject(L, 1);
					string name3 = ToLua.ToString(L, 2);
					Type returnType = (Type)ToLua.ToObject(L, 3);
					PropertyInfo property3 = type3.GetProperty(name3, returnType);
					LuaReflection.PushLuaProperty(L, property3, type3);
					result = 1;
				}
				else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(uint)))
				{
					Type type4 = (Type)ToLua.ToObject(L, 1);
					string name4 = ToLua.ToString(L, 2);
					BindingFlags bindingAttr = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
					PropertyInfo property4 = type4.GetProperty(name4, bindingAttr);
					LuaReflection.PushLuaProperty(L, property4, type4);
					result = 1;
				}
				else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(Type), typeof(Type[])))
				{
					Type type5 = (Type)ToLua.ToObject(L, 1);
					string name5 = ToLua.ToString(L, 2);
					Type returnType2 = (Type)ToLua.ToObject(L, 3);
					Type[] types2 = ToLua.CheckObjectArray<Type>(L, 4);
					PropertyInfo property5 = type5.GetProperty(name5, returnType2, types2);
					LuaReflection.PushLuaProperty(L, property5, type5);
					result = 1;
				}
				else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(Type), typeof(Type[]), typeof(ParameterModifier[])))
				{
					Type type6 = (Type)ToLua.ToObject(L, 1);
					string name6 = ToLua.ToString(L, 2);
					Type returnType3 = (Type)ToLua.ToObject(L, 3);
					Type[] types3 = ToLua.CheckObjectArray<Type>(L, 4);
					ParameterModifier[] modifiers = ToLua.CheckObjectArray<ParameterModifier>(L, 5);
					PropertyInfo property6 = type6.GetProperty(name6, returnType3, types3, modifiers);
					LuaReflection.PushLuaProperty(L, property6, type6);
					result = 1;
				}
				else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(uint), typeof(Binder), typeof(Type), typeof(Type[]), typeof(ParameterModifier[])))
				{
					Type type7 = (Type)ToLua.ToObject(L, 1);
					string name7 = ToLua.ToString(L, 2);
					BindingFlags bindingAttr2 = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
					Binder binder = (Binder)ToLua.ToObject(L, 4);
					Type returnType4 = (Type)ToLua.ToObject(L, 5);
					Type[] types4 = ToLua.CheckObjectArray<Type>(L, 6);
					ParameterModifier[] modifiers2 = ToLua.CheckObjectArray<ParameterModifier>(L, 7);
					PropertyInfo property7 = type7.GetProperty(name7, bindingAttr2, binder, returnType4, types4, modifiers2);
					LuaReflection.PushLuaProperty(L, property7, type7);
					result = 1;
				}
				else
				{
					result = LuaDLL.luaL_throw(L, "invalid arguments to method: tolua.getproperty");
				}
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		private static void PushLuaField(IntPtr L, FieldInfo f, Type t)
		{
			if (f != null)
			{
				LuaField o = new LuaField(f, t);
				ToLua.PushObject(L, o);
			}
			else
			{
				LuaDLL.lua_pushnil(L);
			}
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int GetField(IntPtr L)
		{
			int result;
			try
			{
				int num = LuaDLL.lua_gettop(L);
				if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string)))
				{
					Type type = (Type)ToLua.ToObject(L, 1);
					string name = ToLua.ToString(L, 2);
					FieldInfo field = type.GetField(name);
					LuaReflection.PushLuaField(L, field, type);
					result = 1;
				}
				else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(uint)))
				{
					Type type2 = (Type)ToLua.ToObject(L, 1);
					string name2 = ToLua.ToString(L, 2);
					BindingFlags bindingAttr = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
					FieldInfo field2 = type2.GetField(name2, bindingAttr);
					LuaReflection.PushLuaField(L, field2, type2);
					result = 1;
				}
				else
				{
					result = LuaDLL.luaL_throw(L, "invalid arguments to method: tolua.getfield");
				}
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
			try
			{
				Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
				if (type == null)
				{
					LuaDLL.luaL_typerror(L, 1, "Type", null);
				}
				int num = LuaDLL.lua_gettop(L);
				object obj;
				if (num == 1)
				{
					obj = Activator.CreateInstance(type);
				}
				else
				{
					object[] array = new object[num - 1];
					for (int i = 2; i <= num; i++)
					{
						array[i - 2] = ToLua.ToVarObject(L, i);
					}
					obj = Activator.CreateInstance(type, array);
				}
				ToLua.Push(L, obj);
			}
			catch (Exception e)
			{
				return LuaDLL.toluaL_exception(L, e, null);
			}
			return 1;
		}

		private bool LoadAssembly(string name)
		{
			for (int i = 0; i < this.list.Count; i++)
			{
				if (this.list[i].GetName().Name == name)
				{
					return true;
				}
			}
			Assembly assembly = Assembly.Load(name);
			if (assembly == null)
			{
				assembly = Assembly.Load(AssemblyName.GetAssemblyName(name));
			}
			if (assembly != null && !this.list.Contains(assembly))
			{
				this.list.Add(assembly);
			}
			return assembly != null;
		}

		public void Dispose()
		{
			this.list.Clear();
		}
	}
}
