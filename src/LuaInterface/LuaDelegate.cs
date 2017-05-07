using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LuaInterface
{
	public class LuaDelegate
	{
		public LuaFunction func;

		public LuaTable self;

		public MethodInfo method;

		public LuaDelegate(LuaFunction func)
		{
			this.func = func;
		}

		public LuaDelegate(LuaFunction func, LuaTable self)
		{
			this.func = func;
			this.self = self;
		}

		public virtual void Dispose()
		{
			this.method = null;
			if (this.func != null)
			{
				this.func.Dispose(1);
				this.func = null;
			}
			if (this.self != null)
			{
				this.self.Dispose(1);
				this.self = null;
			}
		}

		public override bool Equals(object o)
		{
			if (o == null)
			{
				return this.func == null && this.self == null;
			}
			LuaDelegate luaDelegate = o as LuaDelegate;
			return !(luaDelegate == null) && !(luaDelegate.func != this.func) && !(luaDelegate.self != this.self) && luaDelegate.func != null;
		}

		private static bool CompareLuaDelegate(LuaDelegate a, LuaDelegate b)
		{
			if (object.ReferenceEquals(a, b))
			{
				return true;
			}
			if (a == null && b != null)
			{
				return b.func == null && b.self == null;
			}
			if (a != null && b == null)
			{
				return a.func == null && b.self == null;
			}
			return !(a.func != b.func) && !(a.self != b.self) && a.func != null;
		}

		public override int GetHashCode()
		{
			return RuntimeHelpers.GetHashCode(this);
		}

		public static bool operator ==(LuaDelegate a, LuaDelegate b)
		{
			return LuaDelegate.CompareLuaDelegate(a, b);
		}

		public static bool operator !=(LuaDelegate a, LuaDelegate b)
		{
			return !LuaDelegate.CompareLuaDelegate(a, b);
		}
	}
}
