using System;
using System.Collections;
using System.Collections.Generic;

namespace LuaInterface
{
	public class LuaDictTable : IDisposable, IEnumerable<DictionaryEntry>, IEnumerable
	{
		private class Enumerator : IEnumerator, IDisposable, IEnumerator<DictionaryEntry>
		{
			private LuaState state;

			private DictionaryEntry current = default(DictionaryEntry);

			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			public DictionaryEntry Current
			{
				get
				{
					return this.current;
				}
			}

			public Enumerator(LuaDictTable list)
			{
				this.state = list.state;
				this.state.Push(list.table);
				this.state.LuaPushNil();
			}

			public bool MoveNext()
			{
				if (this.state.LuaNext(-2))
				{
					this.current = default(DictionaryEntry);
					this.current.Key = this.state.ToVariant(-2);
					this.current.Value = this.state.ToVariant(-1);
					this.state.LuaPop(1);
					return true;
				}
				this.current = default(DictionaryEntry);
				return false;
			}

			public void Reset()
			{
				this.current = default(DictionaryEntry);
			}

			public void Dispose()
			{
				this.state.LuaPop(1);
			}
		}

		private LuaTable table;

		private LuaState state;

		public object this[string key]
		{
			get
			{
				return this.table[key];
			}
			set
			{
				this.table[key] = value;
			}
		}

		public LuaDictTable(LuaTable table)
		{
			table.AddRef();
			this.table = table;
			this.state = table.GetLuaState();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public void Dispose()
		{
			if (this.table != null)
			{
				this.table.Dispose();
				this.table = null;
			}
		}

		public Hashtable ToHashtable()
		{
			Hashtable hashtable = new Hashtable();
			IEnumerator<DictionaryEntry> enumerator = this.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Hashtable arg_2F_0 = hashtable;
				DictionaryEntry current = enumerator.Current;
				object arg_2F_1 = current.Key;
				DictionaryEntry current2 = enumerator.Current;
				arg_2F_0.Add(arg_2F_1, current2.Value);
			}
			enumerator.Dispose();
			return hashtable;
		}

		public IEnumerator<DictionaryEntry> GetEnumerator()
		{
			return new LuaDictTable.Enumerator(this);
		}
	}
}
