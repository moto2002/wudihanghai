using System;
using System.Collections.Generic;
using System.Reflection;

namespace LuaInterface
{
	public class LuaConstructor
	{
		private ConstructorInfo method;

		private List<Type> list;

		[NoToLua]
		public LuaConstructor(ConstructorInfo func, Type[] types)
		{
			this.method = func;
			if (types != null)
			{
				this.list = new List<Type>(types);
			}
		}

		public int Call(IntPtr L)
		{
			object[] array = null;
			ToLua.CheckArgsCount(L, this.list.Count + 1);
			if (this.list.Count > 0)
			{
				array = new object[this.list.Count];
				for (int i = 0; i < this.list.Count; i++)
				{
					bool isByRef = this.list[i].IsByRef;
					Type type = (!isByRef) ? this.list[i] : this.list[i].GetElementType();
					object temp = ToLua.CheckVarObject(L, i + 2, type);
					array[i] = TypeChecker.ChangeType(temp, type);
				}
			}
			object obj = this.method.Invoke(array);
			int num = 1;
			ToLua.Push(L, obj);
			for (int j = 0; j < this.list.Count; j++)
			{
				if (this.list[j].IsByRef)
				{
					num++;
					ToLua.Push(L, array[j]);
				}
			}
			return num;
		}

		public void Destroy()
		{
			this.method = null;
			this.list.Clear();
		}
	}
}
