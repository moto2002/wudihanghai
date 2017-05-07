using System;
using System.Runtime.CompilerServices;

namespace LuaInterface
{
	public abstract class LuaBaseRef : IDisposable
	{
		public string name;

		protected int reference = -1;

		protected LuaState luaState;

		protected ObjectTranslator translator;

		protected volatile bool beDisposed;

		protected int count;

		public volatile bool IsAlive = true;

		public LuaBaseRef()
		{
			this.IsAlive = true;
			this.count = 1;
		}

		~LuaBaseRef()
		{
			this.IsAlive = false;
			this.Dispose(false);
		}

		public virtual void Dispose()
		{
			this.count--;
			if (this.count > 0)
			{
				return;
			}
			this.IsAlive = false;
			this.Dispose(true);
		}

		public void AddRef()
		{
			this.count++;
		}

		public virtual void Dispose(bool disposeManagedResources)
		{
			if (!this.beDisposed)
			{
				this.beDisposed = true;
				if (this.reference > 0 && this.luaState != null)
				{
					this.luaState.CollectRef(this.reference, this.name, !disposeManagedResources);
				}
				this.reference = -1;
				this.luaState = null;
				this.count = 0;
			}
		}

		public void Dispose(int generation)
		{
			if (this.count > generation)
			{
				return;
			}
			this.Dispose(true);
		}

		public LuaState GetLuaState()
		{
			return this.luaState;
		}

		public void Push()
		{
			this.luaState.Push(this);
		}

		public override int GetHashCode()
		{
			return RuntimeHelpers.GetHashCode(this);
		}

		public virtual int GetReference()
		{
			return this.reference;
		}

		public override bool Equals(object o)
		{
			if (o == null)
			{
				return this.reference <= 0;
			}
			LuaBaseRef luaBaseRef = o as LuaBaseRef;
			return !(luaBaseRef == null) && luaBaseRef.reference == this.reference && this.reference > 0;
		}

		private static bool CompareRef(LuaBaseRef a, LuaBaseRef b)
		{
			if (object.ReferenceEquals(a, b))
			{
				return true;
			}
			if (a == null && b != null)
			{
				return b == null || b.reference <= 0;
			}
			if (a != null && b == null)
			{
				return a.reference <= 0;
			}
			return a.reference == b.reference && a.reference > 0;
		}

		public static bool operator ==(LuaBaseRef a, LuaBaseRef b)
		{
			return LuaBaseRef.CompareRef(a, b);
		}

		public static bool operator !=(LuaBaseRef a, LuaBaseRef b)
		{
			return !LuaBaseRef.CompareRef(a, b);
		}
	}
}
