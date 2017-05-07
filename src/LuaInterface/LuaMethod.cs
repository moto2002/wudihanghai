using System;
using System.Collections.Generic;
using System.Reflection;

namespace LuaInterface
{
	public class LuaMethod
	{
		private MethodInfo method;

		private List<Type> list = new List<Type>();

		private Type kclass;

		[NoToLua]
		public LuaMethod(MethodInfo md, Type t, Type[] types)
		{
			this.method = md;
			this.kclass = t;
			if (types != null)
			{
				this.list.AddRange(types);
			}
		}

		public int Call(IntPtr L)
		{
			object[] array = null;
			object obj = null;
			int num = 1;
			if (!this.method.IsStatic)
			{
				num++;
				obj = ToLua.CheckObject(L, 2, this.kclass);
			}
			ToLua.CheckArgsCount(L, this.list.Count + num);
			if (this.list.Count > 0)
			{
				array = new object[this.list.Count];
				num++;
				for (int i = 0; i < this.list.Count; i++)
				{
					bool isByRef = this.list[i].IsByRef;
					Type type = (!isByRef) ? this.list[i] : this.list[i].GetElementType();
					object temp = ToLua.CheckVarObject(L, i + num, type);
					array[i] = TypeChecker.ChangeType(temp, type);
				}
			}
			object obj2 = this.method.Invoke(obj, array);
			int num2 = 0;
			if (this.method.ReturnType != typeof(void))
			{
				num2++;
				ToLua.Push(L, obj2);
			}
			for (int j = 0; j < this.list.Count; j++)
			{
				if (this.list[j].IsByRef)
				{
					num2++;
					ToLua.Push(L, array[j]);
				}
			}
			return num2;
		}

		public void Destroy()
		{
			this.method = null;
			this.list.Clear();
		}
	}
}
