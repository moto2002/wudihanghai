using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace LuaInterface
{
	public class LuaState : LuaStatePtr, IDisposable
	{
		public ObjectTranslator translator = new ObjectTranslator();

		public LuaReflection reflection = new LuaReflection();

		private Dictionary<string, WeakReference> funcMap = new Dictionary<string, WeakReference>();

		private Dictionary<int, WeakReference> funcRefMap = new Dictionary<int, WeakReference>();

		private Dictionary<long, WeakReference> delegateMap = new Dictionary<long, WeakReference>();

		private List<GCRef> gcList = new List<GCRef>();

		private List<LuaBaseRef> subList = new List<LuaBaseRef>();

		private Dictionary<Type, int> metaMap = new Dictionary<Type, int>();

		private Dictionary<Enum, object> enumMap = new Dictionary<Enum, object>();

		private Dictionary<Type, LuaCSFunction> preLoadMap = new Dictionary<Type, LuaCSFunction>();

		private Dictionary<int, Type> typeMap = new Dictionary<int, Type>();

		private HashSet<Type> genericSet = new HashSet<Type>();

		private HashSet<string> moduleSet;

		private static LuaState mainState = null;

		private static Dictionary<IntPtr, LuaState> stateMap = new Dictionary<IntPtr, LuaState>();

		private int beginCount;

		private bool beLogGC;

		private HashSet<Type> missSet = new HashSet<Type>();

		public int ArrayMetatable
		{
			get;
			private set;
		}

		public int DelegateMetatable
		{
			get;
			private set;
		}

		public int TypeMetatable
		{
			get;
			private set;
		}

		public int EnumMetatable
		{
			get;
			private set;
		}

		public int IterMetatable
		{
			get;
			private set;
		}

		public int OutMetatable
		{
			get;
			private set;
		}

		public int EventMetatable
		{
			get;
			private set;
		}

		public int PackBounds
		{
			get;
			private set;
		}

		public int UnpackBounds
		{
			get;
			private set;
		}

		public int PackRay
		{
			get;
			private set;
		}

		public int UnpackRay
		{
			get;
			private set;
		}

		public int PackRaycastHit
		{
			get;
			private set;
		}

		public int PackTouch
		{
			get;
			private set;
		}

		public bool LogGC
		{
			get
			{
				return this.beLogGC;
			}
			set
			{
				this.beLogGC = value;
				this.translator.LogGC = value;
			}
		}

		public object this[string fullPath]
		{
			get
			{
				int newTop = base.LuaGetTop();
				int num = fullPath.LastIndexOf('.');
				object result;
				if (num > 0)
				{
					string fullPath2 = fullPath.Substring(0, num);
					if (!this.PushLuaTable(fullPath2, true))
					{
						base.LuaSetTop(newTop);
						return null;
					}
					string str = fullPath.Substring(num + 1);
					base.LuaPushString(str);
					base.LuaRawGet(-2);
					result = this.ToVariant(-1);
				}
				else
				{
					base.LuaGetGlobal(fullPath);
					result = this.ToVariant(-1);
				}
				base.LuaSetTop(newTop);
				return result;
			}
			set
			{
				int newTop = base.LuaGetTop();
				int num = fullPath.LastIndexOf('.');
				if (num > 0)
				{
					string fname = fullPath.Substring(0, num);
					IntPtr intPtr = base.LuaFindTable(LuaIndexes.LUA_GLOBALSINDEX, fname, 1);
					if (!(intPtr == IntPtr.Zero))
					{
						base.LuaSetTop(newTop);
						int len = LuaDLL.tolua_strlen(intPtr);
						string arg = LuaDLL.lua_ptrtostring(intPtr, len);
						throw new LuaException(string.Format("{0} not a Lua table", arg), null, 1);
					}
					string str = fullPath.Substring(num + 1);
					base.LuaPushString(str);
					this.Push(value);
					base.LuaSetTable(-3);
				}
				else
				{
					this.Push(value);
					base.LuaSetGlobal(fullPath);
				}
				base.LuaSetTop(newTop);
			}
		}

		public LuaState()
		{
			if (LuaState.mainState == null)
			{
				LuaState.mainState = this;
			}
			LuaException.Init();
			this.L = base.LuaNewState();
			LuaState.stateMap.Add(this.L, this);
			base.OpenToLuaLibs();
			ToLua.OpenLibs(this.L);
			this.OpenBaseLibs();
			base.LuaSetTop(0);
			this.InitLuaPath();
		}

		private void OpenBaseLibs()
		{
			this.BeginModule(null);
			this.BeginModule("System");
			System_ObjectWrap.Register(this);
			System_NullObjectWrap.Register(this);
			System_StringWrap.Register(this);
			System_DelegateWrap.Register(this);
			System_EnumWrap.Register(this);
			System_ArrayWrap.Register(this);
			System_TypeWrap.Register(this);
			this.BeginModule("Collections");
			System_Collections_IEnumeratorWrap.Register(this);
			this.BeginModule("ObjectModel");
			System_Collections_ObjectModel_ReadOnlyCollectionWrap.Register(this);
			this.EndModule();
			this.BeginModule("Generic");
			System_Collections_Generic_ListWrap.Register(this);
			System_Collections_Generic_DictionaryWrap.Register(this);
			System_Collections_Generic_KeyValuePairWrap.Register(this);
			this.BeginModule("Dictionary");
			System_Collections_Generic_Dictionary_KeyCollectionWrap.Register(this);
			System_Collections_Generic_Dictionary_ValueCollectionWrap.Register(this);
			this.EndModule();
			this.EndModule();
			this.EndModule();
			this.EndModule();
			this.BeginModule("LuaInterface");
			LuaInterface_LuaOutWrap.Register(this);
			LuaInterface_EventObjectWrap.Register(this);
			this.EndModule();
			this.BeginModule("UnityEngine");
			UnityEngine_ObjectWrap.Register(this);
			UnityEngine_CoroutineWrap.Register(this);
			this.EndModule();
			this.EndModule();
			LuaUnityLibs.OpenLibs(this.L);
			LuaReflection.OpenLibs(this.L);
			this.ArrayMetatable = this.metaMap[typeof(Array)];
			this.TypeMetatable = this.metaMap[typeof(Type)];
			this.DelegateMetatable = this.metaMap[typeof(Delegate)];
			this.EnumMetatable = this.metaMap[typeof(Enum)];
			this.IterMetatable = this.metaMap[typeof(IEnumerator)];
			this.EventMetatable = this.metaMap[typeof(EventObject)];
		}

		private void InitLuaPath()
		{
			this.InitPackagePath();
			if (!LuaFileUtils.Instance.beZip)
			{
			}
		}

		private void OpenBaseLuaLibs()
		{
			this.DoFile("tolua.lua");
			LuaUnityLibs.OpenLuaLibs(this.L);
		}

		public void Start()
		{
			Debugger.Log("LuaState start");
			this.OpenBaseLuaLibs();
			this.PackBounds = this.GetFuncRef("Bounds.New");
			this.UnpackBounds = this.GetFuncRef("Bounds.Get");
			this.PackRay = this.GetFuncRef("Ray.New");
			this.UnpackRay = this.GetFuncRef("Ray.Get");
			this.PackRaycastHit = this.GetFuncRef("RaycastHit.New");
			this.PackTouch = this.GetFuncRef("Touch.New");
		}

		public int OpenLibs(LuaCSFunction open)
		{
			return open(this.L);
		}

		public void BeginPreLoad()
		{
			base.LuaGetGlobal("package");
			base.LuaGetField(-1, "preload");
			this.moduleSet = new HashSet<string>();
		}

		public void EndPreLoad()
		{
			base.LuaPop(2);
			this.moduleSet = null;
		}

		public void AddPreLoad(string name, LuaCSFunction func, Type type)
		{
			if (!this.preLoadMap.ContainsKey(type))
			{
				LuaDLL.tolua_pushcfunction(this.L, func);
				base.LuaSetField(-2, name);
				this.preLoadMap[type] = func;
				string @namespace = type.Namespace;
				if (!string.IsNullOrEmpty(@namespace) && !this.moduleSet.Contains(@namespace))
				{
					LuaDLL.tolua_addpreload(this.L, @namespace);
					this.moduleSet.Add(@namespace);
				}
			}
		}

		public void AddPreLoad(string name, LuaCSFunction func)
		{
			LuaDLL.tolua_pushcfunction(this.L, func);
			base.LuaSetField(-2, name);
		}

		public int BeginPreModule(string name)
		{
			int result = base.LuaGetTop();
			if (string.IsNullOrEmpty(name))
			{
				LuaDLL.lua_pushvalue(this.L, LuaIndexes.LUA_GLOBALSINDEX);
				this.beginCount++;
				return result;
			}
			if (LuaDLL.tolua_beginpremodule(this.L, name, 0))
			{
				this.beginCount++;
				return result;
			}
			throw new LuaException(string.Format("create table {0} fail", name), null, 1);
		}

		public void EndPreModule(int reference)
		{
			this.beginCount--;
			LuaDLL.tolua_endpremodule(this.L, reference);
		}

		public void EndPreModule(IntPtr L, int reference)
		{
			this.beginCount--;
			LuaDLL.tolua_endpremodule(L, reference);
		}

		public void BindPreModule(Type t, LuaCSFunction func)
		{
			this.preLoadMap[t] = func;
		}

		public LuaCSFunction GetPreModule(Type t)
		{
			LuaCSFunction result = null;
			this.preLoadMap.TryGetValue(t, out result);
			return result;
		}

		public bool BeginModule(string name)
		{
			if (LuaDLL.tolua_beginmodule(this.L, name))
			{
				this.beginCount++;
				return true;
			}
			base.LuaSetTop(0);
			throw new LuaException(string.Format("create table {0} fail", name), null, 1);
		}

		public void EndModule()
		{
			this.beginCount--;
			LuaDLL.tolua_endmodule(this.L);
		}

		private void BindTypeRef(int reference, Type t)
		{
			this.metaMap.Add(t, reference);
			this.typeMap.Add(reference, t);
			if (t.IsGenericTypeDefinition)
			{
				this.genericSet.Add(t);
			}
		}

		public Type GetClassType(int reference)
		{
			Type result = null;
			this.typeMap.TryGetValue(reference, out result);
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int Collect(IntPtr L)
		{
			int num = LuaDLL.tolua_rawnetobj(L, 1);
			if (num != -1)
			{
				ObjectTranslator objectTranslator = LuaState.GetTranslator(L);
				objectTranslator.RemoveObject(num);
			}
			return 0;
		}

		private string GetToLuaTypeName(Type t)
		{
			if (t.IsGenericType)
			{
				string text = t.Name;
				int num = text.IndexOf('`');
				if (num > 0)
				{
					text = text.Substring(0, num);
				}
				return text;
			}
			return t.Name;
		}

		public int BeginClass(Type t, Type baseType, string name = null)
		{
			if (this.beginCount == 0)
			{
				throw new LuaException("must call BeginModule first", null, 1);
			}
			int num = 0;
			int num2 = 0;
			if (name == null)
			{
				name = this.GetToLuaTypeName(t);
			}
			if (baseType != null && !this.metaMap.TryGetValue(baseType, out num))
			{
				base.LuaCreateTable(0, 0);
				num = base.LuaRef(LuaIndexes.LUA_REGISTRYINDEX);
				this.BindTypeRef(num, baseType);
			}
			if (this.metaMap.TryGetValue(t, out num2))
			{
				LuaDLL.tolua_beginclass(this.L, name, num, num2);
				this.RegFunction("__gc", new LuaCSFunction(LuaState.Collect));
			}
			else
			{
				num2 = LuaDLL.tolua_beginclass(this.L, name, num, -1);
				this.RegFunction("__gc", new LuaCSFunction(LuaState.Collect));
				this.BindTypeRef(num2, t);
			}
			return num2;
		}

		public void EndClass()
		{
			LuaDLL.tolua_endclass(this.L);
		}

		public int BeginEnum(Type t)
		{
			if (this.beginCount == 0)
			{
				throw new LuaException("must call BeginModule first", null, 1);
			}
			int num = LuaDLL.tolua_beginenum(this.L, t.Name);
			this.RegFunction("__gc", new LuaCSFunction(LuaState.Collect));
			this.BindTypeRef(num, t);
			return num;
		}

		public void EndEnum()
		{
			LuaDLL.tolua_endenum(this.L);
		}

		public void BeginStaticLibs(string name)
		{
			if (this.beginCount == 0)
			{
				throw new LuaException("must call BeginModule first", null, 1);
			}
			LuaDLL.tolua_beginstaticclass(this.L, name);
		}

		public void EndStaticLibs()
		{
			LuaDLL.tolua_endstaticclass(this.L);
		}

		public void RegFunction(string name, LuaCSFunction func)
		{
			IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(func);
			LuaDLL.tolua_function(this.L, name, functionPointerForDelegate);
		}

		public void RegVar(string name, LuaCSFunction get, LuaCSFunction set)
		{
			IntPtr get2 = IntPtr.Zero;
			IntPtr set2 = IntPtr.Zero;
			if (get != null)
			{
				get2 = Marshal.GetFunctionPointerForDelegate(get);
			}
			if (set != null)
			{
				set2 = Marshal.GetFunctionPointerForDelegate(set);
			}
			LuaDLL.tolua_variable(this.L, name, get2, set2);
		}

		public void RegConstant(string name, double d)
		{
			LuaDLL.tolua_constant(this.L, name, d);
		}

		public void RegConstant(string name, bool flag)
		{
			LuaDLL.lua_pushstring(this.L, name);
			LuaDLL.lua_pushboolean(this.L, flag);
			LuaDLL.lua_rawset(this.L, -3);
		}

		private int GetFuncRef(string name)
		{
			if (this.PushLuaFunction(name, false))
			{
				return base.LuaRef(LuaIndexes.LUA_REGISTRYINDEX);
			}
			throw new LuaException("get lua function reference failed: " + name, null, 1);
		}

		public static LuaState Get(IntPtr ptr)
		{
			return LuaState.mainState;
		}

		public static ObjectTranslator GetTranslator(IntPtr ptr)
		{
			return LuaState.mainState.translator;
		}

		public static LuaReflection GetReflection(IntPtr ptr)
		{
			return LuaState.mainState.reflection;
		}

		public object[] DoString(string chunk, string chunkName = "LuaState.cs")
		{
			byte[] bytes = Encoding.UTF8.GetBytes(chunk);
			return this.LuaLoadBuffer(bytes, chunkName);
		}

		public object[] DoFile(string fileName)
		{
			byte[] array = LuaFileUtils.Instance.ReadFile(fileName);
			if (array == null)
			{
				string text = string.Format("cannot open {0}: No such file or directory", fileName);
				text += LuaFileUtils.Instance.FindFileError(fileName);
				throw new LuaException(text, null, 1);
			}
			if (LuaConst.openZbsDebugger)
			{
				fileName = LuaFileUtils.Instance.FindFile(fileName);
			}
			return this.LuaLoadBuffer(array, fileName);
		}

		public void Require(string fileName)
		{
			int newTop = base.LuaGetTop();
			int num = base.LuaRequire(fileName);
			if (num != 0)
			{
				string msg = base.LuaToString(-1);
				base.LuaSetTop(newTop);
				throw new LuaException(msg, LuaException.GetLastError(), 1);
			}
			base.LuaSetTop(newTop);
		}

		public void InitPackagePath()
		{
			base.LuaGetGlobal("package");
			base.LuaGetField(-1, "path");
			string text = base.LuaToString(-1);
			string[] array = text.Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]))
				{
					string path = array[i].Replace('\\', '/');
					LuaFileUtils.Instance.AddSearchPath(path, false);
				}
			}
			base.LuaPushString(string.Empty);
			base.LuaSetField(-3, "path");
			base.LuaPop(2);
		}

		private string ToPackagePath(string path)
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.Append(path);
			stringBuilder.Replace('\\', '/');
			if (stringBuilder.Length > 0 && stringBuilder[stringBuilder.Length - 1] != '/')
			{
				stringBuilder.Append('/');
			}
			stringBuilder.Append("?.lua");
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public void AddSearchPath(string fullPath)
		{
			if (!Path.IsPathRooted(fullPath))
			{
				throw new LuaException(fullPath + " is not a full path", null, 1);
			}
			fullPath = this.ToPackagePath(fullPath);
			LuaFileUtils.Instance.AddSearchPath(fullPath, false);
		}

		public void RemoveSeachPath(string fullPath)
		{
			if (!Path.IsPathRooted(fullPath))
			{
				throw new LuaException(fullPath + " is not a full path", null, 1);
			}
			fullPath = this.ToPackagePath(fullPath);
			LuaFileUtils.Instance.RemoveSearchPath(fullPath);
		}

		public int BeginPCall(int reference)
		{
			return LuaDLL.tolua_beginpcall(this.L, reference);
		}

		public void PCall(int args, int oldTop)
		{
			if (base.LuaPCall(args, LuaDLL.LUA_MULTRET, oldTop) != 0)
			{
				string msg = base.LuaToString(-1);
				throw new LuaException(msg, LuaException.GetLastError(), 1);
			}
		}

		public void EndPCall(int oldTop)
		{
			base.LuaSetTop(oldTop - 1);
		}

		public void PushArgs(object[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				this.Push(args[i]);
			}
		}

		private void CheckNull(LuaBaseRef lbr, string fmt, object arg0)
		{
			if (lbr == null)
			{
				string msg = string.Format(fmt, arg0);
				throw new LuaException(msg, null, 2);
			}
		}

		private bool PushLuaTable(string fullPath, bool checkMap = true)
		{
			if (checkMap)
			{
				WeakReference weakReference = null;
				if (this.funcMap.TryGetValue(fullPath, out weakReference))
				{
					if (weakReference.IsAlive)
					{
						LuaTable lbr = weakReference.Target as LuaTable;
						this.CheckNull(lbr, "{0} not a lua table", fullPath);
						this.Push(lbr);
						return true;
					}
					this.funcMap.Remove(fullPath);
				}
			}
			return LuaDLL.tolua_pushluatable(this.L, fullPath);
		}

		private bool PushLuaFunction(string fullPath, bool checkMap = true)
		{
			if (checkMap)
			{
				WeakReference weakReference = null;
				if (this.funcMap.TryGetValue(fullPath, out weakReference))
				{
					if (weakReference.IsAlive)
					{
						LuaFunction luaFunction = weakReference.Target as LuaFunction;
						this.CheckNull(luaFunction, "{0} not a lua function", fullPath);
						if (luaFunction.IsAlive)
						{
							luaFunction.AddRef();
							return true;
						}
					}
					this.funcMap.Remove(fullPath);
				}
			}
			int num = base.LuaGetTop();
			int num2 = fullPath.LastIndexOf('.');
			if (num2 > 0)
			{
				string fullPath2 = fullPath.Substring(0, num2);
				if (this.PushLuaTable(fullPath2, true))
				{
					string str = fullPath.Substring(num2 + 1);
					base.LuaPushString(str);
					base.LuaRawGet(-2);
					LuaTypes luaTypes = base.LuaType(-1);
					if (luaTypes == LuaTypes.LUA_TFUNCTION)
					{
						base.LuaInsert(num + 1);
						base.LuaSetTop(num + 1);
						return true;
					}
				}
				base.LuaSetTop(num);
				return false;
			}
			base.LuaGetGlobal(fullPath);
			LuaTypes luaTypes2 = base.LuaType(-1);
			if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
			{
				base.LuaSetTop(num);
				return false;
			}
			return true;
		}

		private void RemoveFromGCList(int reference)
		{
			List<GCRef> obj = this.gcList;
			lock (obj)
			{
				for (int i = 0; i < this.gcList.Count; i++)
				{
					if (this.gcList[i].reference == reference)
					{
						this.gcList.RemoveAt(i);
						break;
					}
				}
			}
		}

		public LuaFunction GetFunction(string name, bool beLogMiss = true)
		{
			WeakReference weakReference = null;
			if (this.funcMap.TryGetValue(name, out weakReference))
			{
				if (weakReference.IsAlive)
				{
					LuaFunction luaFunction = weakReference.Target as LuaFunction;
					this.CheckNull(luaFunction, "{0} not a lua function", name);
					if (luaFunction.IsAlive)
					{
						luaFunction.AddRef();
						this.RemoveFromGCList(luaFunction.GetReference());
						return luaFunction;
					}
				}
				this.funcMap.Remove(name);
			}
			if (this.PushLuaFunction(name, false))
			{
				int num = base.ToLuaRef();
				if (this.funcRefMap.TryGetValue(num, out weakReference))
				{
					if (weakReference.IsAlive)
					{
						LuaFunction luaFunction2 = weakReference.Target as LuaFunction;
						this.CheckNull(luaFunction2, "{0} not a lua function", name);
						if (luaFunction2.IsAlive)
						{
							this.funcMap.Add(name, weakReference);
							luaFunction2.AddRef();
							this.RemoveFromGCList(num);
							return luaFunction2;
						}
					}
					this.funcRefMap.Remove(num);
					this.delegateMap.Remove((long)num);
				}
				LuaFunction luaFunction3 = new LuaFunction(num, this);
				luaFunction3.name = name;
				this.funcMap.Add(name, new WeakReference(luaFunction3));
				this.funcRefMap.Add(num, new WeakReference(luaFunction3));
				this.RemoveFromGCList(num);
				if (this.LogGC)
				{
					Debugger.Log("Alloc LuaFunction name {0}, id {1}", name, num);
				}
				return luaFunction3;
			}
			if (beLogMiss)
			{
				Debugger.Log("Lua function {0} not exists", name);
			}
			return null;
		}

		private LuaBaseRef TryGetLuaRef(int reference)
		{
			WeakReference weakReference = null;
			if (this.funcRefMap.TryGetValue(reference, out weakReference))
			{
				if (weakReference.IsAlive)
				{
					LuaBaseRef luaBaseRef = (LuaBaseRef)weakReference.Target;
					if (luaBaseRef.IsAlive)
					{
						luaBaseRef.AddRef();
						return luaBaseRef;
					}
				}
				this.funcRefMap.Remove(reference);
			}
			return null;
		}

		public LuaFunction GetFunction(int reference)
		{
			LuaFunction luaFunction = this.TryGetLuaRef(reference) as LuaFunction;
			if (luaFunction == null)
			{
				luaFunction = new LuaFunction(reference, this);
				this.funcRefMap.Add(reference, new WeakReference(luaFunction));
				if (this.LogGC)
				{
					Debugger.Log("Alloc LuaFunction name , id {0}", reference);
				}
			}
			this.RemoveFromGCList(reference);
			return luaFunction;
		}

		public LuaTable GetTable(string fullPath, bool beLogMiss = true)
		{
			WeakReference weakReference = null;
			if (this.funcMap.TryGetValue(fullPath, out weakReference))
			{
				if (weakReference.IsAlive)
				{
					LuaTable luaTable = weakReference.Target as LuaTable;
					this.CheckNull(luaTable, "{0} not a lua table", fullPath);
					if (luaTable.IsAlive)
					{
						luaTable.AddRef();
						this.RemoveFromGCList(luaTable.GetReference());
						return luaTable;
					}
				}
				this.funcMap.Remove(fullPath);
			}
			if (this.PushLuaTable(fullPath, false))
			{
				int num = base.ToLuaRef();
				LuaTable luaTable2;
				if (this.funcRefMap.TryGetValue(num, out weakReference))
				{
					if (weakReference.IsAlive)
					{
						luaTable2 = (weakReference.Target as LuaTable);
						this.CheckNull(luaTable2, "{0} not a lua table", fullPath);
						if (luaTable2.IsAlive)
						{
							this.funcMap.Add(fullPath, weakReference);
							luaTable2.AddRef();
							this.RemoveFromGCList(num);
							return luaTable2;
						}
					}
					this.funcRefMap.Remove(num);
				}
				luaTable2 = new LuaTable(num, this);
				luaTable2.name = fullPath;
				this.funcMap.Add(fullPath, new WeakReference(luaTable2));
				this.funcRefMap.Add(num, new WeakReference(luaTable2));
				if (this.LogGC)
				{
					Debugger.Log("Alloc LuaTable name {0}, id {1}", fullPath, num);
				}
				this.RemoveFromGCList(num);
				return luaTable2;
			}
			if (beLogMiss)
			{
				Debugger.LogWarning("Lua table {0} not exists", fullPath);
			}
			return null;
		}

		public LuaTable GetTable(int reference)
		{
			LuaTable luaTable = this.TryGetLuaRef(reference) as LuaTable;
			if (luaTable == null)
			{
				luaTable = new LuaTable(reference, this);
				this.funcRefMap.Add(reference, new WeakReference(luaTable));
			}
			this.RemoveFromGCList(reference);
			return luaTable;
		}

		public LuaThread GetLuaThread(int reference)
		{
			LuaThread luaThread = this.TryGetLuaRef(reference) as LuaThread;
			if (luaThread == null)
			{
				luaThread = new LuaThread(reference, this);
				this.funcRefMap.Add(reference, new WeakReference(luaThread));
			}
			this.RemoveFromGCList(reference);
			return luaThread;
		}

		public LuaDelegate GetLuaDelegate(LuaFunction func)
		{
			WeakReference weakReference = null;
			int reference = func.GetReference();
			this.delegateMap.TryGetValue((long)reference, out weakReference);
			if (weakReference != null)
			{
				if (weakReference.IsAlive)
				{
					return weakReference.Target as LuaDelegate;
				}
				this.delegateMap.Remove((long)reference);
			}
			return null;
		}

		public LuaDelegate GetLuaDelegate(LuaFunction func, LuaTable self)
		{
			WeakReference weakReference = null;
			long num = (long)func.GetReference();
			long num2 = (long)((!(self == null)) ? self.GetReference() : 0);
			num2 = ((num2 < 0L) ? 0L : num2);
			long key = num << 32 | num2;
			this.delegateMap.TryGetValue(key, out weakReference);
			if (weakReference != null)
			{
				if (weakReference.IsAlive)
				{
					return weakReference.Target as LuaDelegate;
				}
				this.delegateMap.Remove(key);
			}
			return null;
		}

		public void AddLuaDelegate(LuaDelegate target, LuaFunction func)
		{
			int reference = func.GetReference();
			if (reference > 0)
			{
				this.delegateMap[(long)reference] = new WeakReference(target);
			}
		}

		public void AddLuaDelegate(LuaDelegate target, LuaFunction func, LuaTable self)
		{
			long num = (long)func.GetReference();
			long num2 = (long)((!(self == null)) ? self.GetReference() : 0);
			num2 = ((num2 < 0L) ? 0L : num2);
			long num3 = num << 32 | num2;
			if (num3 > 0L)
			{
				this.delegateMap[num3] = new WeakReference(target);
			}
		}

		public bool CheckTop()
		{
			int num = base.LuaGetTop();
			if (num != 0)
			{
				Debugger.LogWarning("Lua stack top is {0}", num);
				return false;
			}
			return true;
		}

		public void Push(bool b)
		{
			LuaDLL.lua_pushboolean(this.L, b);
		}

		public void Push(double d)
		{
			LuaDLL.lua_pushnumber(this.L, d);
		}

		public void Push(uint un)
		{
			LuaDLL.lua_pushnumber(this.L, un);
		}

		public void Push(int n)
		{
			LuaDLL.lua_pushinteger(this.L, n);
		}

		public void Push(short s)
		{
			LuaDLL.lua_pushnumber(this.L, (double)s);
		}

		public void Push(ushort us)
		{
			LuaDLL.lua_pushnumber(this.L, (double)us);
		}

		public void Push(long l)
		{
			LuaDLL.tolua_pushint64(this.L, l);
		}

		public void Push(ulong ul)
		{
			LuaDLL.tolua_pushuint64(this.L, ul);
		}

		public void Push(string str)
		{
			LuaDLL.lua_pushstring(this.L, str);
		}

		public void Push(IntPtr p)
		{
			LuaDLL.lua_pushlightuserdata(this.L, p);
		}

		public void Push(Vector3 v3)
		{
			LuaDLL.tolua_pushvec3(this.L, v3.x, v3.y, v3.z);
		}

		public void Push(Vector2 v2)
		{
			LuaDLL.tolua_pushvec2(this.L, v2.x, v2.y);
		}

		public void Push(Vector4 v4)
		{
			LuaDLL.tolua_pushvec4(this.L, v4.x, v4.y, v4.z, v4.w);
		}

		public void Push(Color clr)
		{
			LuaDLL.tolua_pushclr(this.L, clr.r, clr.g, clr.b, clr.a);
		}

		public void Push(Quaternion q)
		{
			LuaDLL.tolua_pushquat(this.L, q.x, q.y, q.z, q.w);
		}

		public void Push(Ray ray)
		{
			ToLua.Push(this.L, ray);
		}

		public void Push(Bounds bound)
		{
			ToLua.Push(this.L, bound);
		}

		public void Push(RaycastHit hit)
		{
			ToLua.Push(this.L, hit);
		}

		public void Push(Touch touch)
		{
			ToLua.Push(this.L, touch);
		}

		public void PushLayerMask(LayerMask mask)
		{
			LuaDLL.tolua_pushlayermask(this.L, mask.value);
		}

		public void Push(LuaByteBuffer bb)
		{
			LuaDLL.lua_pushlstring(this.L, bb.buffer, bb.buffer.Length);
		}

		public void PushByteBuffer(byte[] buffer)
		{
			LuaDLL.lua_pushlstring(this.L, buffer, buffer.Length);
		}

		public void Push(LuaBaseRef lbr)
		{
			if (lbr == null)
			{
				base.LuaPushNil();
			}
			else
			{
				base.LuaGetRef(lbr.GetReference());
			}
		}

		private void PushUserData(object o, int reference)
		{
			int index;
			if (this.translator.Getudata(o, out index) && LuaDLL.tolua_pushudata(this.L, index))
			{
				return;
			}
			index = this.translator.AddObject(o);
			LuaDLL.tolua_pushnewudata(this.L, reference, index);
		}

		public void Push(Array array)
		{
			if (array == null)
			{
				base.LuaPushNil();
			}
			else
			{
				this.PushUserData(array, this.ArrayMetatable);
			}
		}

		public void Push(Type t)
		{
			if (t == null)
			{
				base.LuaPushNil();
			}
			else
			{
				this.PushUserData(t, this.TypeMetatable);
			}
		}

		public void Push(Delegate ev)
		{
			if (ev == null)
			{
				base.LuaPushNil();
			}
			else
			{
				this.PushUserData(ev, this.DelegateMetatable);
			}
		}

		public object GetEnumObj(Enum e)
		{
			object obj = null;
			if (!this.enumMap.TryGetValue(e, out obj))
			{
				obj = e;
				this.enumMap.Add(e, obj);
			}
			return obj;
		}

		public void Push(Enum e)
		{
			if (e == null)
			{
				base.LuaPushNil();
			}
			else
			{
				object enumObj = this.GetEnumObj(e);
				this.PushUserData(enumObj, this.EnumMetatable);
			}
		}

		public void Push(IEnumerator iter)
		{
			ToLua.Push(this.L, iter);
		}

		public void Push(UnityEngine.Object obj)
		{
			ToLua.Push(this.L, obj);
		}

		public void Push(TrackedReference tracker)
		{
			ToLua.Push(this.L, tracker);
		}

		public void PushValue(ValueType vt)
		{
			ToLua.PushValue(this.L, vt);
		}

		public void Push(object obj)
		{
			ToLua.Push(this.L, obj);
		}

		public void PushObject(object obj)
		{
			if (obj.GetType().IsEnum)
			{
				ToLua.Push(this.L, (Enum)obj);
			}
			else
			{
				ToLua.PushObject(this.L, obj);
			}
		}

		private Vector3 ToVector3(int stackPos)
		{
			float x;
			float y;
			float z;
			LuaDLL.tolua_getvec3(this.L, stackPos, out x, out y, out z);
			return new Vector3(x, y, z);
		}

		public Vector3 CheckVector3(int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(this.L, stackPos);
			if (luaValueType != LuaValueType.Vector3)
			{
				base.LuaTypeError(stackPos, "Vector3", luaValueType.ToString());
				return Vector3.zero;
			}
			float x;
			float y;
			float z;
			LuaDLL.tolua_getvec3(this.L, stackPos, out x, out y, out z);
			return new Vector3(x, y, z);
		}

		public Quaternion CheckQuaternion(int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(this.L, stackPos);
			if (luaValueType != LuaValueType.Vector4)
			{
				base.LuaTypeError(stackPos, "Quaternion", luaValueType.ToString());
				return Quaternion.identity;
			}
			float x;
			float y;
			float z;
			float w;
			LuaDLL.tolua_getquat(this.L, stackPos, out x, out y, out z, out w);
			return new Quaternion(x, y, z, w);
		}

		public Vector2 CheckVector2(int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(this.L, stackPos);
			if (luaValueType != LuaValueType.Vector2)
			{
				base.LuaTypeError(stackPos, "Vector2", luaValueType.ToString());
				return Vector2.zero;
			}
			float x;
			float y;
			LuaDLL.tolua_getvec2(this.L, stackPos, out x, out y);
			return new Vector2(x, y);
		}

		public Vector4 CheckVector4(int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(this.L, stackPos);
			if (luaValueType != LuaValueType.Vector4)
			{
				base.LuaTypeError(stackPos, "Vector4", luaValueType.ToString());
				return Vector4.zero;
			}
			float x;
			float y;
			float z;
			float w;
			LuaDLL.tolua_getvec4(this.L, stackPos, out x, out y, out z, out w);
			return new Vector4(x, y, z, w);
		}

		public Color CheckColor(int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(this.L, stackPos);
			if (luaValueType != LuaValueType.Color)
			{
				base.LuaTypeError(stackPos, "Color", luaValueType.ToString());
				return Color.black;
			}
			float r;
			float g;
			float b;
			float a;
			LuaDLL.tolua_getclr(this.L, stackPos, out r, out g, out b, out a);
			return new Color(r, g, b, a);
		}

		public Ray CheckRay(int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(this.L, stackPos);
			if (luaValueType != LuaValueType.Ray)
			{
				base.LuaTypeError(stackPos, "Ray", luaValueType.ToString());
				return default(Ray);
			}
			int num = this.BeginPCall(this.UnpackRay);
			base.LuaPushValue(stackPos);
			Ray result;
			try
			{
				this.PCall(1, num);
				Vector3 origin = this.ToVector3(num + 1);
				Vector3 direction = this.ToVector3(num + 2);
				this.EndPCall(num);
				result = new Ray(origin, direction);
			}
			catch (Exception ex)
			{
				this.EndPCall(num);
				throw ex;
			}
			return result;
		}

		public Bounds CheckBounds(int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(this.L, stackPos);
			if (luaValueType != LuaValueType.Bounds)
			{
				base.LuaTypeError(stackPos, "Bounds", luaValueType.ToString());
				return default(Bounds);
			}
			int num = this.BeginPCall(this.UnpackBounds);
			base.LuaPushValue(stackPos);
			Bounds result;
			try
			{
				this.PCall(1, num);
				Vector3 center = this.ToVector3(num + 1);
				Vector3 size = this.ToVector3(num + 2);
				this.EndPCall(num);
				result = new Bounds(center, size);
			}
			catch (Exception ex)
			{
				this.EndPCall(num);
				throw ex;
			}
			return result;
		}

		public LayerMask CheckLayerMask(int stackPos)
		{
			LuaValueType luaValueType = LuaDLL.tolua_getvaluetype(this.L, stackPos);
			if (luaValueType != LuaValueType.LayerMask)
			{
				base.LuaTypeError(stackPos, "LayerMask", luaValueType.ToString());
				return 0;
			}
			return LuaDLL.tolua_getlayermask(this.L, stackPos);
		}

		public long CheckLong(int stackPos)
		{
			return LuaDLL.tolua_checkint64(this.L, stackPos);
		}

		public ulong CheckULong(int stackPos)
		{
			return LuaDLL.tolua_checkuint64(this.L, stackPos);
		}

		public string CheckString(int stackPos)
		{
			return ToLua.CheckString(this.L, stackPos);
		}

		public Delegate CheckDelegate(int stackPos)
		{
			int num = LuaDLL.tolua_rawnetobj(this.L, stackPos);
			if (num != -1)
			{
				object @object = this.translator.GetObject(num);
				if (@object != null)
				{
					Type type = @object.GetType();
					if (type.IsSubclassOf(typeof(MulticastDelegate)))
					{
						return (Delegate)@object;
					}
					base.LuaTypeError(stackPos, "Delegate", type.FullName);
				}
				return null;
			}
			if (base.LuaIsNil(stackPos))
			{
				return null;
			}
			base.LuaTypeError(stackPos, "Delegate", null);
			return null;
		}

		public char[] CheckCharBuffer(int stackPos)
		{
			return ToLua.CheckCharBuffer(this.L, stackPos);
		}

		public byte[] CheckByteBuffer(int stackPos)
		{
			return ToLua.CheckByteBuffer(this.L, stackPos);
		}

		public T[] CheckNumberArray<T>(int stackPos)
		{
			return ToLua.CheckNumberArray<T>(this.L, stackPos);
		}

		public object CheckObject(int stackPos, Type type)
		{
			return ToLua.CheckObject(this.L, stackPos, type);
		}

		public object CheckVarObject(int stackPos, Type type)
		{
			return ToLua.CheckVarObject(this.L, stackPos, type);
		}

		public object[] CheckObjects(int oldTop)
		{
			int num = base.LuaGetTop();
			if (oldTop == num)
			{
				return null;
			}
			List<object> list = new List<object>();
			for (int i = oldTop + 1; i <= num; i++)
			{
				list.Add(this.ToVariant(i));
			}
			return list.ToArray();
		}

		public LuaFunction CheckLuaFunction(int stackPos)
		{
			return ToLua.CheckLuaFunction(this.L, stackPos);
		}

		public LuaTable CheckLuaTable(int stackPos)
		{
			return ToLua.CheckLuaTable(this.L, stackPos);
		}

		public LuaThread CheckLuaThread(int stackPos)
		{
			return ToLua.CheckLuaThread(this.L, stackPos);
		}

		public object ToVariant(int stackPos)
		{
			return ToLua.ToVarObject(this.L, stackPos);
		}

		public void CollectRef(int reference, string name, bool isGCThread = false)
		{
			if (!isGCThread)
			{
				this.Collect(reference, name, false);
			}
			else
			{
				List<GCRef> obj = this.gcList;
				lock (obj)
				{
					this.gcList.Add(new GCRef(reference, name));
				}
			}
		}

		public void DelayDispose(LuaBaseRef br)
		{
			if (br != null)
			{
				this.subList.Add(br);
			}
		}

		public int Collect()
		{
			int count = this.gcList.Count;
			if (count > 0)
			{
				List<GCRef> obj = this.gcList;
				lock (obj)
				{
					for (int i = 0; i < this.gcList.Count; i++)
					{
						int reference = this.gcList[i].reference;
						string name = this.gcList[i].name;
						this.Collect(reference, name, true);
					}
					this.gcList.Clear();
					return count;
				}
			}
			for (int j = 0; j < this.subList.Count; j++)
			{
				this.subList[j].Dispose();
			}
			this.subList.Clear();
			this.translator.Collect();
			return 0;
		}

		public void RefreshDelegateMap()
		{
			List<long> list = new List<long>();
			Dictionary<long, WeakReference>.Enumerator enumerator = this.delegateMap.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<long, WeakReference> current = enumerator.Current;
				if (!current.Value.IsAlive)
				{
					List<long> arg_41_0 = list;
					KeyValuePair<long, WeakReference> current2 = enumerator.Current;
					arg_41_0.Add(current2.Key);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.delegateMap.Remove(list[i]);
			}
		}

		public void ReLoad(string moduleFileName)
		{
			base.LuaGetGlobal("package");
			base.LuaGetField(-1, "loaded");
			base.LuaPushString(moduleFileName);
			base.LuaGetTable(-2);
			if (!base.LuaIsNil(-1))
			{
				base.LuaPushString(moduleFileName);
				base.LuaPushNil();
				base.LuaSetTable(-4);
			}
			base.LuaPop(3);
			string chunk = string.Format("require '{0}'", moduleFileName);
			this.DoString(chunk, "ReLoad");
		}

		public int GetMetaReference(Type t)
		{
			int result = -1;
			this.metaMap.TryGetValue(t, out result);
			return result;
		}

		public int GetMissMetaReference(Type t)
		{
			int num = -1;
			Type type;
			for (type = this.GetBaseType(t); type != null; type = this.GetBaseType(type))
			{
				if (this.metaMap.TryGetValue(type, out num))
				{
					if (!this.missSet.Contains(t))
					{
						Debugger.LogWarning("Type {0} not wrap to lua, push as {1}, the warning is only raised once", LuaMisc.GetTypeName(t), LuaMisc.GetTypeName(type));
					}
					this.missSet.Add(t);
					return num;
				}
			}
			if (num <= 0)
			{
				type = typeof(object);
				num = LuaStatic.GetMetaReference(this.L, type);
			}
			if (!this.missSet.Contains(t))
			{
				Debugger.LogWarning("Type {0} not wrap to lua, push as {1}, the warning is only raised once", LuaMisc.GetTypeName(t), LuaMisc.GetTypeName(type));
			}
			this.missSet.Add(t);
			return num;
		}

		private Type GetBaseType(Type t)
		{
			if (t.IsGenericType)
			{
				return this.GetSpecialGenericType(t);
			}
			return LuaMisc.GetExportBaseType(t);
		}

		private Type GetSpecialGenericType(Type t)
		{
			Type genericTypeDefinition = t.GetGenericTypeDefinition();
			if (this.genericSet.Contains(genericTypeDefinition))
			{
				return (t != genericTypeDefinition) ? genericTypeDefinition : t.BaseType;
			}
			return t.BaseType;
		}

		private void CloseBaseRef()
		{
			base.LuaUnRef(this.PackBounds);
			base.LuaUnRef(this.UnpackBounds);
			base.LuaUnRef(this.PackRay);
			base.LuaUnRef(this.UnpackRay);
			base.LuaUnRef(this.PackRaycastHit);
			base.LuaUnRef(this.PackTouch);
		}

		public void Dispose()
		{
			if (IntPtr.Zero != this.L)
			{
				base.LuaGC(LuaGCOptions.LUA_GCCOLLECT, 0);
				this.Collect();
				foreach (KeyValuePair<Type, int> current in this.metaMap)
				{
					base.LuaUnRef(current.Value);
				}
				List<LuaBaseRef> list = new List<LuaBaseRef>();
				foreach (KeyValuePair<int, WeakReference> current2 in this.funcRefMap)
				{
					if (current2.Value.IsAlive)
					{
						list.Add((LuaBaseRef)current2.Value.Target);
					}
				}
				for (int i = 0; i < list.Count; i++)
				{
					list[i].Dispose(true);
				}
				this.CloseBaseRef();
				this.delegateMap.Clear();
				this.funcRefMap.Clear();
				this.funcMap.Clear();
				this.metaMap.Clear();
				this.typeMap.Clear();
				this.enumMap.Clear();
				this.preLoadMap.Clear();
				this.genericSet.Clear();
				LuaState.stateMap.Remove(this.L);
				base.LuaClose();
				this.translator.Dispose();
				this.translator = null;
				this.missSet.Clear();
				Debugger.Log("LuaState destroy");
			}
			if (LuaState.mainState == this)
			{
				LuaState.mainState = null;
			}
			LuaFileUtils.Instance.Dispose();
			GC.SuppressFinalize(this);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object o)
		{
			if (o == null)
			{
				return this.L == IntPtr.Zero;
			}
			LuaState luaState = o as LuaState;
			return !(luaState == null) && !(luaState.L != this.L) && this.L != IntPtr.Zero;
		}

		public void PrintTable(string name)
		{
			LuaTable table = this.GetTable(name, true);
			LuaDictTable luaDictTable = table.ToDictTable();
			table.Dispose();
			IEnumerator<DictionaryEntry> enumerator = luaDictTable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string arg_44_0 = "map item, k,v is {0}:{1}";
				DictionaryEntry current = enumerator.Current;
				object arg_44_1 = current.Key;
				DictionaryEntry current2 = enumerator.Current;
				Debugger.Log(arg_44_0, arg_44_1, current2.Value);
			}
			enumerator.Dispose();
			luaDictTable.Dispose();
		}

		protected void Collect(int reference, string name, bool beThread)
		{
			if (beThread)
			{
				WeakReference weakReference = null;
				if (name != null)
				{
					this.funcMap.TryGetValue(name, out weakReference);
					if (weakReference != null && !weakReference.IsAlive)
					{
						this.funcMap.Remove(name);
						weakReference = null;
					}
				}
				this.funcRefMap.TryGetValue(reference, out weakReference);
				if (weakReference != null && !weakReference.IsAlive)
				{
					base.ToLuaUnRef(reference);
					this.funcRefMap.Remove(reference);
					this.delegateMap.Remove((long)reference);
					if (this.LogGC)
					{
						string arg = (name != null) ? name : "null";
						Debugger.Log("collect lua reference name {0}, id {1} in thread", arg, reference);
					}
				}
			}
			else
			{
				if (name != null)
				{
					WeakReference weakReference2 = null;
					this.funcMap.TryGetValue(name, out weakReference2);
					if (weakReference2 != null && weakReference2.IsAlive)
					{
						LuaBaseRef luaBaseRef = (LuaBaseRef)weakReference2.Target;
						if (reference == luaBaseRef.GetReference())
						{
							this.funcMap.Remove(name);
						}
					}
				}
				base.ToLuaUnRef(reference);
				this.funcRefMap.Remove(reference);
				this.delegateMap.Remove((long)reference);
				if (this.LogGC)
				{
					string arg2 = (name != null) ? name : "null";
					Debugger.Log("collect lua reference name {0}, id {1} in main", arg2, reference);
				}
			}
		}

		protected object[] LuaLoadBuffer(byte[] buffer, string chunkName)
		{
			base.ToLuaPushTraceback();
			int num = base.LuaGetTop();
			if (base.LuaLoadBuffer(buffer, buffer.Length, chunkName) == 0 && base.LuaPCall(0, LuaDLL.LUA_MULTRET, num) == 0)
			{
				object[] result = this.CheckObjects(num);
				base.LuaSetTop(num - 1);
				return result;
			}
			string msg = base.LuaToString(-1);
			base.LuaSetTop(num - 1);
			throw new LuaException(msg, LuaException.GetLastError(), 1);
		}

		public static bool operator ==(LuaState a, LuaState b)
		{
			if (object.ReferenceEquals(a, b))
			{
				return true;
			}
			if (a == null && b != null)
			{
				return b.L == IntPtr.Zero;
			}
			if (a != null && b == null)
			{
				return a.L == IntPtr.Zero;
			}
			return !(a.L != b.L) && a.L != IntPtr.Zero;
		}

		public static bool operator !=(LuaState a, LuaState b)
		{
			return !(a == b);
		}
	}
}
