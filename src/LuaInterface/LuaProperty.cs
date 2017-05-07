using System;
using System.Globalization;
using System.Reflection;

namespace LuaInterface
{
	public class LuaProperty
	{
		private PropertyInfo property;

		private Type kclass;

		[NoToLua]
		public LuaProperty(PropertyInfo prop, Type t)
		{
			this.property = prop;
			this.kclass = t;
		}

		public int Get(IntPtr L)
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 2, this.kclass, typeof(object[])))
			{
				object obj = ToLua.ToVarObject(L, 2);
				object[] index = ToLua.CheckObjectArray(L, 3);
				object value = this.property.GetValue(obj, index);
				ToLua.Push(L, value);
				return 1;
			}
			if (num == 6 && TypeChecker.CheckTypes(L, 2, this.kclass, typeof(uint), typeof(Binder), typeof(object[]), typeof(CultureInfo)))
			{
				object obj2 = ToLua.ToVarObject(L, 2);
				BindingFlags invokeAttr = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
				Binder binder = (Binder)ToLua.ToObject(L, 4);
				object[] index2 = ToLua.CheckObjectArray(L, 5);
				CultureInfo culture = (CultureInfo)ToLua.ToObject(L, 6);
				object value2 = this.property.GetValue(obj2, invokeAttr, binder, index2, culture);
				ToLua.Push(L, value2);
				return 1;
			}
			return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaInterface.LuaProperty.Get");
		}

		public int Set(IntPtr L)
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 4 && TypeChecker.CheckTypes(L, 2, this.kclass, typeof(object), typeof(object[])))
			{
				object obj = ToLua.ToVarObject(L, 2);
				object obj2 = ToLua.ToVarObject(L, 3);
				object[] index = ToLua.CheckObjectArray(L, 4);
				obj2 = TypeChecker.ChangeType(obj2, this.property.PropertyType);
				this.property.SetValue(obj, obj2, index);
				return 0;
			}
			if (num == 7 && TypeChecker.CheckTypes(L, 2, this.kclass, typeof(object), typeof(uint), typeof(Binder), typeof(object[]), typeof(CultureInfo)))
			{
				object obj3 = ToLua.ToVarObject(L, 2);
				object obj4 = ToLua.ToVarObject(L, 3);
				BindingFlags invokeAttr = (BindingFlags)LuaDLL.lua_tonumber(L, 4);
				Binder binder = (Binder)ToLua.ToObject(L, 5);
				object[] index2 = ToLua.CheckObjectArray(L, 6);
				CultureInfo culture = (CultureInfo)ToLua.ToObject(L, 7);
				obj4 = TypeChecker.ChangeType(obj4, this.property.PropertyType);
				this.property.SetValue(obj3, obj4, invokeAttr, binder, index2, culture);
				return 0;
			}
			return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaInterface.LuaProperty.Set");
		}
	}
}
