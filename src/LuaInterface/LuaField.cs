using System;
using System.Globalization;
using System.Reflection;

namespace LuaInterface
{
	public class LuaField
	{
		private FieldInfo field;

		private Type kclass;

		[NoToLua]
		public LuaField(FieldInfo info, Type t)
		{
			this.field = info;
			this.kclass = t;
		}

		public int Get(IntPtr L)
		{
			int result;
			try
			{
				ToLua.CheckArgsCount(L, 2);
				object obj = ToLua.CheckObject(L, 2, this.kclass);
				object obj2 = this.field.GetValue(obj);
				if (obj2 == null)
				{
					if (typeof(MulticastDelegate).IsAssignableFrom(this.field.FieldType))
					{
						obj2 = DelegateFactory.CreateDelegate(this.field.FieldType, null);
						ToLua.Push(L, (Delegate)obj2);
					}
					else
					{
						LuaDLL.lua_pushnil(L);
					}
				}
				else
				{
					ToLua.Push(L, obj2);
				}
				result = 1;
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		public int Set(IntPtr L)
		{
			int result;
			try
			{
				int num = LuaDLL.lua_gettop(L);
				if (num == 3 && TypeChecker.CheckTypes(L, 2, this.kclass, typeof(object)))
				{
					object obj = ToLua.ToVarObject(L, 2);
					object obj2 = ToLua.ToVarObject(L, 3);
					obj2 = TypeChecker.ChangeType(obj2, this.field.FieldType);
					this.field.SetValue(obj, obj2);
					result = 0;
				}
				else if (num == 6 && TypeChecker.CheckTypes(L, 2, this.kclass, typeof(object), typeof(uint), typeof(Binder), typeof(CultureInfo)))
				{
					object obj3 = ToLua.ToVarObject(L, 2);
					object obj4 = ToLua.ToVarObject(L, 3);
					BindingFlags invokeAttr = (BindingFlags)LuaDLL.lua_tonumber(L, 4);
					Binder binder = (Binder)ToLua.ToObject(L, 5);
					CultureInfo culture = (CultureInfo)ToLua.ToObject(L, 6);
					obj4 = TypeChecker.ChangeType(obj4, this.field.FieldType);
					this.field.SetValue(obj3, obj4, invokeAttr, binder, culture);
					result = 0;
				}
				else
				{
					result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaField.Set");
				}
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}
	}
}
