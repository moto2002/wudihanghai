using LuaInterface;
using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

public class System_TypeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Type), typeof(object), null);
		L.RegFunction("Equals", new LuaCSFunction(System_TypeWrap.Equals));
		L.RegFunction("GetType", new LuaCSFunction(System_TypeWrap.GetType));
		L.RegFunction("GetTypeArray", new LuaCSFunction(System_TypeWrap.GetTypeArray));
		L.RegFunction("GetTypeCode", new LuaCSFunction(System_TypeWrap.GetTypeCode));
		L.RegFunction("GetTypeFromCLSID", new LuaCSFunction(System_TypeWrap.GetTypeFromCLSID));
		L.RegFunction("GetTypeFromHandle", new LuaCSFunction(System_TypeWrap.GetTypeFromHandle));
		L.RegFunction("GetTypeFromProgID", new LuaCSFunction(System_TypeWrap.GetTypeFromProgID));
		L.RegFunction("GetTypeHandle", new LuaCSFunction(System_TypeWrap.GetTypeHandle));
		L.RegFunction("IsSubclassOf", new LuaCSFunction(System_TypeWrap.IsSubclassOf));
		L.RegFunction("FindInterfaces", new LuaCSFunction(System_TypeWrap.FindInterfaces));
		L.RegFunction("GetInterface", new LuaCSFunction(System_TypeWrap.GetInterface));
		L.RegFunction("GetInterfaceMap", new LuaCSFunction(System_TypeWrap.GetInterfaceMap));
		L.RegFunction("GetInterfaces", new LuaCSFunction(System_TypeWrap.GetInterfaces));
		L.RegFunction("IsAssignableFrom", new LuaCSFunction(System_TypeWrap.IsAssignableFrom));
		L.RegFunction("IsInstanceOfType", new LuaCSFunction(System_TypeWrap.IsInstanceOfType));
		L.RegFunction("GetArrayRank", new LuaCSFunction(System_TypeWrap.GetArrayRank));
		L.RegFunction("GetElementType", new LuaCSFunction(System_TypeWrap.GetElementType));
		L.RegFunction("GetHashCode", new LuaCSFunction(System_TypeWrap.GetHashCode));
		L.RegFunction("GetNestedType", new LuaCSFunction(System_TypeWrap.GetNestedType));
		L.RegFunction("GetNestedTypes", new LuaCSFunction(System_TypeWrap.GetNestedTypes));
		L.RegFunction("GetDefaultMembers", new LuaCSFunction(System_TypeWrap.GetDefaultMembers));
		L.RegFunction("FindMembers", new LuaCSFunction(System_TypeWrap.FindMembers));
		L.RegFunction("InvokeMember", new LuaCSFunction(System_TypeWrap.InvokeMember));
		L.RegFunction("ToString", new LuaCSFunction(System_TypeWrap.ToString));
		L.RegFunction("GetGenericArguments", new LuaCSFunction(System_TypeWrap.GetGenericArguments));
		L.RegFunction("GetGenericTypeDefinition", new LuaCSFunction(System_TypeWrap.GetGenericTypeDefinition));
		L.RegFunction("MakeGenericType", new LuaCSFunction(System_TypeWrap.MakeGenericType));
		L.RegFunction("GetGenericParameterConstraints", new LuaCSFunction(System_TypeWrap.GetGenericParameterConstraints));
		L.RegFunction("MakeArrayType", new LuaCSFunction(System_TypeWrap.MakeArrayType));
		L.RegFunction("MakeByRefType", new LuaCSFunction(System_TypeWrap.MakeByRefType));
		L.RegFunction("MakePointerType", new LuaCSFunction(System_TypeWrap.MakePointerType));
		L.RegFunction("ReflectionOnlyGetType", new LuaCSFunction(System_TypeWrap.ReflectionOnlyGetType));
		L.RegFunction("__tostring", new LuaCSFunction(System_TypeWrap.Lua_ToString));
		L.RegVar("Delimiter", new LuaCSFunction(System_TypeWrap.get_Delimiter), null);
		L.RegVar("EmptyTypes", new LuaCSFunction(System_TypeWrap.get_EmptyTypes), null);
		L.RegVar("FilterAttribute", new LuaCSFunction(System_TypeWrap.get_FilterAttribute), null);
		L.RegVar("FilterName", new LuaCSFunction(System_TypeWrap.get_FilterName), null);
		L.RegVar("FilterNameIgnoreCase", new LuaCSFunction(System_TypeWrap.get_FilterNameIgnoreCase), null);
		L.RegVar("Missing", new LuaCSFunction(System_TypeWrap.get_Missing), null);
		L.RegVar("Assembly", new LuaCSFunction(System_TypeWrap.get_Assembly), null);
		L.RegVar("AssemblyQualifiedName", new LuaCSFunction(System_TypeWrap.get_AssemblyQualifiedName), null);
		L.RegVar("Attributes", new LuaCSFunction(System_TypeWrap.get_Attributes), null);
		L.RegVar("BaseType", new LuaCSFunction(System_TypeWrap.get_BaseType), null);
		L.RegVar("DeclaringType", new LuaCSFunction(System_TypeWrap.get_DeclaringType), null);
		L.RegVar("DefaultBinder", new LuaCSFunction(System_TypeWrap.get_DefaultBinder), null);
		L.RegVar("FullName", new LuaCSFunction(System_TypeWrap.get_FullName), null);
		L.RegVar("GUID", new LuaCSFunction(System_TypeWrap.get_GUID), null);
		L.RegVar("HasElementType", new LuaCSFunction(System_TypeWrap.get_HasElementType), null);
		L.RegVar("IsAbstract", new LuaCSFunction(System_TypeWrap.get_IsAbstract), null);
		L.RegVar("IsAnsiClass", new LuaCSFunction(System_TypeWrap.get_IsAnsiClass), null);
		L.RegVar("IsArray", new LuaCSFunction(System_TypeWrap.get_IsArray), null);
		L.RegVar("IsAutoClass", new LuaCSFunction(System_TypeWrap.get_IsAutoClass), null);
		L.RegVar("IsAutoLayout", new LuaCSFunction(System_TypeWrap.get_IsAutoLayout), null);
		L.RegVar("IsByRef", new LuaCSFunction(System_TypeWrap.get_IsByRef), null);
		L.RegVar("IsClass", new LuaCSFunction(System_TypeWrap.get_IsClass), null);
		L.RegVar("IsCOMObject", new LuaCSFunction(System_TypeWrap.get_IsCOMObject), null);
		L.RegVar("IsContextful", new LuaCSFunction(System_TypeWrap.get_IsContextful), null);
		L.RegVar("IsEnum", new LuaCSFunction(System_TypeWrap.get_IsEnum), null);
		L.RegVar("IsExplicitLayout", new LuaCSFunction(System_TypeWrap.get_IsExplicitLayout), null);
		L.RegVar("IsImport", new LuaCSFunction(System_TypeWrap.get_IsImport), null);
		L.RegVar("IsInterface", new LuaCSFunction(System_TypeWrap.get_IsInterface), null);
		L.RegVar("IsLayoutSequential", new LuaCSFunction(System_TypeWrap.get_IsLayoutSequential), null);
		L.RegVar("IsMarshalByRef", new LuaCSFunction(System_TypeWrap.get_IsMarshalByRef), null);
		L.RegVar("IsNestedAssembly", new LuaCSFunction(System_TypeWrap.get_IsNestedAssembly), null);
		L.RegVar("IsNestedFamANDAssem", new LuaCSFunction(System_TypeWrap.get_IsNestedFamANDAssem), null);
		L.RegVar("IsNestedFamily", new LuaCSFunction(System_TypeWrap.get_IsNestedFamily), null);
		L.RegVar("IsNestedFamORAssem", new LuaCSFunction(System_TypeWrap.get_IsNestedFamORAssem), null);
		L.RegVar("IsNestedPrivate", new LuaCSFunction(System_TypeWrap.get_IsNestedPrivate), null);
		L.RegVar("IsNestedPublic", new LuaCSFunction(System_TypeWrap.get_IsNestedPublic), null);
		L.RegVar("IsNotPublic", new LuaCSFunction(System_TypeWrap.get_IsNotPublic), null);
		L.RegVar("IsPointer", new LuaCSFunction(System_TypeWrap.get_IsPointer), null);
		L.RegVar("IsPrimitive", new LuaCSFunction(System_TypeWrap.get_IsPrimitive), null);
		L.RegVar("IsPublic", new LuaCSFunction(System_TypeWrap.get_IsPublic), null);
		L.RegVar("IsSealed", new LuaCSFunction(System_TypeWrap.get_IsSealed), null);
		L.RegVar("IsSerializable", new LuaCSFunction(System_TypeWrap.get_IsSerializable), null);
		L.RegVar("IsSpecialName", new LuaCSFunction(System_TypeWrap.get_IsSpecialName), null);
		L.RegVar("IsUnicodeClass", new LuaCSFunction(System_TypeWrap.get_IsUnicodeClass), null);
		L.RegVar("IsValueType", new LuaCSFunction(System_TypeWrap.get_IsValueType), null);
		L.RegVar("MemberType", new LuaCSFunction(System_TypeWrap.get_MemberType), null);
		L.RegVar("Module", new LuaCSFunction(System_TypeWrap.get_Module), null);
		L.RegVar("Namespace", new LuaCSFunction(System_TypeWrap.get_Namespace), null);
		L.RegVar("ReflectedType", new LuaCSFunction(System_TypeWrap.get_ReflectedType), null);
		L.RegVar("TypeHandle", new LuaCSFunction(System_TypeWrap.get_TypeHandle), null);
		L.RegVar("TypeInitializer", new LuaCSFunction(System_TypeWrap.get_TypeInitializer), null);
		L.RegVar("UnderlyingSystemType", new LuaCSFunction(System_TypeWrap.get_UnderlyingSystemType), null);
		L.RegVar("ContainsGenericParameters", new LuaCSFunction(System_TypeWrap.get_ContainsGenericParameters), null);
		L.RegVar("IsGenericTypeDefinition", new LuaCSFunction(System_TypeWrap.get_IsGenericTypeDefinition), null);
		L.RegVar("IsGenericType", new LuaCSFunction(System_TypeWrap.get_IsGenericType), null);
		L.RegVar("IsGenericParameter", new LuaCSFunction(System_TypeWrap.get_IsGenericParameter), null);
		L.RegVar("IsNested", new LuaCSFunction(System_TypeWrap.get_IsNested), null);
		L.RegVar("IsVisible", new LuaCSFunction(System_TypeWrap.get_IsVisible), null);
		L.RegVar("GenericParameterPosition", new LuaCSFunction(System_TypeWrap.get_GenericParameterPosition), null);
		L.RegVar("GenericParameterAttributes", new LuaCSFunction(System_TypeWrap.get_GenericParameterAttributes), null);
		L.RegVar("DeclaringMethod", new LuaCSFunction(System_TypeWrap.get_DeclaringMethod), null);
		L.RegVar("StructLayoutAttribute", new LuaCSFunction(System_TypeWrap.get_StructLayoutAttribute), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Equals(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(Type)))
			{
				Type type = (Type)ToLua.ToObject(L, 1);
				Type type2 = (Type)ToLua.ToObject(L, 2);
				bool value = (type == null) ? (type2 == null) : type.Equals(type2);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(object)))
			{
				Type type3 = (Type)ToLua.ToObject(L, 1);
				object obj = ToLua.ToVarObject(L, 2);
				bool value2 = (type3 == null) ? (obj == null) : type3.Equals(obj);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Type.Equals");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetType(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Type)))
			{
				Type type = (Type)ToLua.ToObject(L, 1);
				Type type2 = type.GetType();
				ToLua.Push(L, type2);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string typeName = ToLua.ToString(L, 1);
				Type type3 = Type.GetType(typeName);
				ToLua.Push(L, type3);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(bool)))
			{
				string typeName2 = ToLua.ToString(L, 1);
				bool throwOnError = LuaDLL.lua_toboolean(L, 2);
				Type type4 = Type.GetType(typeName2, throwOnError);
				ToLua.Push(L, type4);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(bool), typeof(bool)))
			{
				string typeName3 = ToLua.ToString(L, 1);
				bool throwOnError2 = LuaDLL.lua_toboolean(L, 2);
				bool ignoreCase = LuaDLL.lua_toboolean(L, 3);
				Type type5 = Type.GetType(typeName3, throwOnError2, ignoreCase);
				ToLua.Push(L, type5);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Type.GetType");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTypeArray(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object[] args = ToLua.CheckObjectArray(L, 1);
			Type[] typeArray = Type.GetTypeArray(args);
			ToLua.Push(L, typeArray);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTypeCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			TypeCode typeCode = Type.GetTypeCode(type);
			ToLua.Push(L, typeCode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTypeFromCLSID(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Guid)))
			{
				Guid clsid = (Guid)ToLua.ToObject(L, 1);
				Type typeFromCLSID = Type.GetTypeFromCLSID(clsid);
				ToLua.Push(L, typeFromCLSID);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Guid), typeof(string)))
			{
				Guid clsid2 = (Guid)ToLua.ToObject(L, 1);
				string server = ToLua.ToString(L, 2);
				Type typeFromCLSID2 = Type.GetTypeFromCLSID(clsid2, server);
				ToLua.Push(L, typeFromCLSID2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Guid), typeof(bool)))
			{
				Guid clsid3 = (Guid)ToLua.ToObject(L, 1);
				bool throwOnError = LuaDLL.lua_toboolean(L, 2);
				Type typeFromCLSID3 = Type.GetTypeFromCLSID(clsid3, throwOnError);
				ToLua.Push(L, typeFromCLSID3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Guid), typeof(string), typeof(bool)))
			{
				Guid clsid4 = (Guid)ToLua.ToObject(L, 1);
				string server2 = ToLua.ToString(L, 2);
				bool throwOnError2 = LuaDLL.lua_toboolean(L, 3);
				Type typeFromCLSID4 = Type.GetTypeFromCLSID(clsid4, server2, throwOnError2);
				ToLua.Push(L, typeFromCLSID4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Type.GetTypeFromCLSID");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTypeFromHandle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RuntimeTypeHandle handle = (RuntimeTypeHandle)ToLua.CheckObject(L, 1, typeof(RuntimeTypeHandle));
			Type typeFromHandle = Type.GetTypeFromHandle(handle);
			ToLua.Push(L, typeFromHandle);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTypeFromProgID(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string progID = ToLua.ToString(L, 1);
				Type typeFromProgID = Type.GetTypeFromProgID(progID);
				ToLua.Push(L, typeFromProgID);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string progID2 = ToLua.ToString(L, 1);
				string server = ToLua.ToString(L, 2);
				Type typeFromProgID2 = Type.GetTypeFromProgID(progID2, server);
				ToLua.Push(L, typeFromProgID2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(bool)))
			{
				string progID3 = ToLua.ToString(L, 1);
				bool throwOnError = LuaDLL.lua_toboolean(L, 2);
				Type typeFromProgID3 = Type.GetTypeFromProgID(progID3, throwOnError);
				ToLua.Push(L, typeFromProgID3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(bool)))
			{
				string progID4 = ToLua.ToString(L, 1);
				string server2 = ToLua.ToString(L, 2);
				bool throwOnError2 = LuaDLL.lua_toboolean(L, 3);
				Type typeFromProgID4 = Type.GetTypeFromProgID(progID4, server2, throwOnError2);
				ToLua.Push(L, typeFromProgID4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Type.GetTypeFromProgID");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTypeHandle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object o = ToLua.ToVarObject(L, 1);
			RuntimeTypeHandle typeHandle = Type.GetTypeHandle(o);
			ToLua.PushValue(L, typeHandle);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsSubclassOf(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type c = (Type)ToLua.CheckObject(L, 2, typeof(Type));
			bool value = type.IsSubclassOf(c);
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindInterfaces(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TypeFilter filter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				filter = (TypeFilter)ToLua.CheckObject(L, 2, typeof(TypeFilter));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				filter = (DelegateFactory.CreateDelegate(typeof(TypeFilter), func) as TypeFilter);
			}
			object filterCriteria = ToLua.ToVarObject(L, 3);
			Type[] array = type.FindInterfaces(filter, filterCriteria);
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInterface(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string)))
			{
				Type type = (Type)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				Type @interface = type.GetInterface(name);
				ToLua.Push(L, @interface);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(bool)))
			{
				Type type2 = (Type)ToLua.ToObject(L, 1);
				string name2 = ToLua.ToString(L, 2);
				bool ignoreCase = LuaDLL.lua_toboolean(L, 3);
				Type interface2 = type2.GetInterface(name2, ignoreCase);
				ToLua.Push(L, interface2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Type.GetInterface");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInterfaceMap(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type interfaceType = (Type)ToLua.CheckObject(L, 2, typeof(Type));
			InterfaceMapping interfaceMap = type.GetInterfaceMap(interfaceType);
			ToLua.PushValue(L, interfaceMap);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInterfaces(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type[] interfaces = type.GetInterfaces();
			ToLua.Push(L, interfaces);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsAssignableFrom(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type c = (Type)ToLua.CheckObject(L, 2, typeof(Type));
			bool value = type.IsAssignableFrom(c);
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsInstanceOfType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			object o = ToLua.ToVarObject(L, 2);
			bool value = type.IsInstanceOfType(o);
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetArrayRank(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			int arrayRank = type.GetArrayRank();
			LuaDLL.lua_pushinteger(L, arrayRank);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetElementType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type elementType = type.GetElementType();
			ToLua.Push(L, elementType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetHashCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			int hashCode = type.GetHashCode();
			LuaDLL.lua_pushinteger(L, hashCode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNestedType(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string)))
			{
				Type type = (Type)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				Type nestedType = type.GetNestedType(name);
				ToLua.Push(L, nestedType);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(uint)))
			{
				Type type2 = (Type)ToLua.ToObject(L, 1);
				string name2 = ToLua.ToString(L, 2);
				BindingFlags bindingAttr = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
				Type nestedType2 = type2.GetNestedType(name2, bindingAttr);
				ToLua.Push(L, nestedType2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Type.GetNestedType");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNestedTypes(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Type)))
			{
				Type type = (Type)ToLua.ToObject(L, 1);
				Type[] nestedTypes = type.GetNestedTypes();
				ToLua.Push(L, nestedTypes);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(uint)))
			{
				Type type2 = (Type)ToLua.ToObject(L, 1);
				BindingFlags bindingAttr = (BindingFlags)LuaDLL.lua_tonumber(L, 2);
				Type[] nestedTypes2 = type2.GetNestedTypes(bindingAttr);
				ToLua.Push(L, nestedTypes2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Type.GetNestedTypes");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDefaultMembers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			MemberInfo[] defaultMembers = type.GetDefaultMembers();
			ToLua.Push(L, defaultMembers);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindMembers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			MemberTypes memberType = (MemberTypes)((int)ToLua.CheckObject(L, 2, typeof(MemberTypes)));
			BindingFlags bindingAttr = (BindingFlags)LuaDLL.luaL_checknumber(L, 3);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 4);
			MemberFilter filter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				filter = (MemberFilter)ToLua.CheckObject(L, 4, typeof(MemberFilter));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 4);
				filter = (DelegateFactory.CreateDelegate(typeof(MemberFilter), func) as MemberFilter);
			}
			object filterCriteria = ToLua.ToVarObject(L, 5);
			MemberInfo[] array = type.FindMembers(memberType, bindingAttr, filter, filterCriteria);
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InvokeMember(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(uint), typeof(Binder), typeof(object), typeof(object[])))
			{
				Type type = (Type)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				BindingFlags invokeAttr = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
				Binder binder = (Binder)ToLua.ToObject(L, 4);
				object target = ToLua.ToVarObject(L, 5);
				object[] args = ToLua.CheckObjectArray(L, 6);
				object obj = type.InvokeMember(name, invokeAttr, binder, target, args);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(uint), typeof(Binder), typeof(object), typeof(object[]), typeof(CultureInfo)))
			{
				Type type2 = (Type)ToLua.ToObject(L, 1);
				string name2 = ToLua.ToString(L, 2);
				BindingFlags invokeAttr2 = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
				Binder binder2 = (Binder)ToLua.ToObject(L, 4);
				object target2 = ToLua.ToVarObject(L, 5);
				object[] args2 = ToLua.CheckObjectArray(L, 6);
				CultureInfo culture = (CultureInfo)ToLua.ToObject(L, 7);
				object obj2 = type2.InvokeMember(name2, invokeAttr2, binder2, target2, args2, culture);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 9 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(string), typeof(uint), typeof(Binder), typeof(object), typeof(object[]), typeof(ParameterModifier[]), typeof(CultureInfo), typeof(string[])))
			{
				Type type3 = (Type)ToLua.ToObject(L, 1);
				string name3 = ToLua.ToString(L, 2);
				BindingFlags invokeAttr3 = (BindingFlags)LuaDLL.lua_tonumber(L, 3);
				Binder binder3 = (Binder)ToLua.ToObject(L, 4);
				object target3 = ToLua.ToVarObject(L, 5);
				object[] args3 = ToLua.CheckObjectArray(L, 6);
				ParameterModifier[] modifiers = ToLua.CheckObjectArray<ParameterModifier>(L, 7);
				CultureInfo culture2 = (CultureInfo)ToLua.ToObject(L, 8);
				string[] namedParameters = ToLua.CheckStringArray(L, 9);
				object obj3 = type3.InvokeMember(name3, invokeAttr3, binder3, target3, args3, modifiers, culture2, namedParameters);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Type.InvokeMember");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			string str = type.ToString();
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetGenericArguments(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type[] genericArguments = type.GetGenericArguments();
			ToLua.Push(L, genericArguments);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetGenericTypeDefinition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			ToLua.Push(L, genericTypeDefinition);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakeGenericType(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type[] typeArguments = ToLua.CheckParamsObject<Type>(L, 2, num - 1);
			Type t = type.MakeGenericType(typeArguments);
			ToLua.Push(L, t);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetGenericParameterConstraints(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type[] genericParameterConstraints = type.GetGenericParameterConstraints();
			ToLua.Push(L, genericParameterConstraints);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakeArrayType(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Type)))
			{
				Type type = (Type)ToLua.ToObject(L, 1);
				Type t = type.MakeArrayType();
				ToLua.Push(L, t);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Type), typeof(int)))
			{
				Type type2 = (Type)ToLua.ToObject(L, 1);
				int rank = (int)LuaDLL.lua_tonumber(L, 2);
				Type t2 = type2.MakeArrayType(rank);
				ToLua.Push(L, t2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Type.MakeArrayType");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakeByRefType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type t = type.MakeByRefType();
			ToLua.Push(L, t);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePointerType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Type type = (Type)ToLua.CheckObject(L, 1, typeof(Type));
			Type t = type.MakePointerType();
			ToLua.Push(L, t);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReflectionOnlyGetType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string typeName = ToLua.CheckString(L, 1);
			bool throwIfNotFound = LuaDLL.luaL_checkboolean(L, 2);
			bool ignoreCase = LuaDLL.luaL_checkboolean(L, 3);
			Type t = Type.ReflectionOnlyGetType(typeName, throwIfNotFound, ignoreCase);
			ToLua.Push(L, t);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_ToString(IntPtr L)
	{
		object obj = ToLua.ToObject(L, 1);
		if (obj != null)
		{
			LuaDLL.lua_pushstring(L, obj.ToString());
		}
		else
		{
			LuaDLL.lua_pushnil(L);
		}
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Delimiter(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)Type.Delimiter);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EmptyTypes(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Type.EmptyTypes);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FilterAttribute(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Type.FilterAttribute);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FilterName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Type.FilterName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FilterNameIgnoreCase(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Type.FilterNameIgnoreCase);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Missing(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Type.Missing);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Assembly(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			Assembly assembly = type.Assembly;
			ToLua.PushObject(L, assembly);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Assembly on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AssemblyQualifiedName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			string assemblyQualifiedName = type.AssemblyQualifiedName;
			LuaDLL.lua_pushstring(L, assemblyQualifiedName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index AssemblyQualifiedName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Attributes(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			TypeAttributes attributes = type.Attributes;
			ToLua.Push(L, attributes);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Attributes on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BaseType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			Type baseType = type.BaseType;
			ToLua.Push(L, baseType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BaseType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DeclaringType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			Type declaringType = type.DeclaringType;
			ToLua.Push(L, declaringType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DeclaringType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DefaultBinder(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, Type.DefaultBinder);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FullName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			string fullName = type.FullName;
			LuaDLL.lua_pushstring(L, fullName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index FullName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GUID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			Guid gUID = type.GUID;
			ToLua.PushValue(L, gUID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index GUID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_HasElementType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool hasElementType = type.HasElementType;
			LuaDLL.lua_pushboolean(L, hasElementType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index HasElementType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsAbstract(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isAbstract = type.IsAbstract;
			LuaDLL.lua_pushboolean(L, isAbstract);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsAbstract on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsAnsiClass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isAnsiClass = type.IsAnsiClass;
			LuaDLL.lua_pushboolean(L, isAnsiClass);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsAnsiClass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsArray(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isArray = type.IsArray;
			LuaDLL.lua_pushboolean(L, isArray);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsArray on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsAutoClass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isAutoClass = type.IsAutoClass;
			LuaDLL.lua_pushboolean(L, isAutoClass);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsAutoClass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsAutoLayout(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isAutoLayout = type.IsAutoLayout;
			LuaDLL.lua_pushboolean(L, isAutoLayout);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsAutoLayout on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsByRef(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isByRef = type.IsByRef;
			LuaDLL.lua_pushboolean(L, isByRef);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsByRef on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsClass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isClass = type.IsClass;
			LuaDLL.lua_pushboolean(L, isClass);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsClass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsCOMObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isCOMObject = type.IsCOMObject;
			LuaDLL.lua_pushboolean(L, isCOMObject);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsCOMObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsContextful(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isContextful = type.IsContextful;
			LuaDLL.lua_pushboolean(L, isContextful);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsContextful on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsEnum(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isEnum = type.IsEnum;
			LuaDLL.lua_pushboolean(L, isEnum);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsEnum on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsExplicitLayout(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isExplicitLayout = type.IsExplicitLayout;
			LuaDLL.lua_pushboolean(L, isExplicitLayout);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsExplicitLayout on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsImport(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isImport = type.IsImport;
			LuaDLL.lua_pushboolean(L, isImport);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsImport on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsInterface(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isInterface = type.IsInterface;
			LuaDLL.lua_pushboolean(L, isInterface);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsInterface on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsLayoutSequential(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isLayoutSequential = type.IsLayoutSequential;
			LuaDLL.lua_pushboolean(L, isLayoutSequential);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsLayoutSequential on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsMarshalByRef(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isMarshalByRef = type.IsMarshalByRef;
			LuaDLL.lua_pushboolean(L, isMarshalByRef);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsMarshalByRef on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsNestedAssembly(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isNestedAssembly = type.IsNestedAssembly;
			LuaDLL.lua_pushboolean(L, isNestedAssembly);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsNestedAssembly on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsNestedFamANDAssem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isNestedFamANDAssem = type.IsNestedFamANDAssem;
			LuaDLL.lua_pushboolean(L, isNestedFamANDAssem);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsNestedFamANDAssem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsNestedFamily(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isNestedFamily = type.IsNestedFamily;
			LuaDLL.lua_pushboolean(L, isNestedFamily);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsNestedFamily on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsNestedFamORAssem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isNestedFamORAssem = type.IsNestedFamORAssem;
			LuaDLL.lua_pushboolean(L, isNestedFamORAssem);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsNestedFamORAssem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsNestedPrivate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isNestedPrivate = type.IsNestedPrivate;
			LuaDLL.lua_pushboolean(L, isNestedPrivate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsNestedPrivate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsNestedPublic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isNestedPublic = type.IsNestedPublic;
			LuaDLL.lua_pushboolean(L, isNestedPublic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsNestedPublic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsNotPublic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isNotPublic = type.IsNotPublic;
			LuaDLL.lua_pushboolean(L, isNotPublic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsNotPublic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsPointer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isPointer = type.IsPointer;
			LuaDLL.lua_pushboolean(L, isPointer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsPointer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsPrimitive(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isPrimitive = type.IsPrimitive;
			LuaDLL.lua_pushboolean(L, isPrimitive);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsPrimitive on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsPublic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isPublic = type.IsPublic;
			LuaDLL.lua_pushboolean(L, isPublic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsPublic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsSealed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isSealed = type.IsSealed;
			LuaDLL.lua_pushboolean(L, isSealed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsSealed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsSerializable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isSerializable = type.IsSerializable;
			LuaDLL.lua_pushboolean(L, isSerializable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsSerializable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsSpecialName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isSpecialName = type.IsSpecialName;
			LuaDLL.lua_pushboolean(L, isSpecialName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsSpecialName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsUnicodeClass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isUnicodeClass = type.IsUnicodeClass;
			LuaDLL.lua_pushboolean(L, isUnicodeClass);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsUnicodeClass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsValueType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isValueType = type.IsValueType;
			LuaDLL.lua_pushboolean(L, isValueType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsValueType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MemberType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			MemberTypes memberType = type.MemberType;
			ToLua.Push(L, memberType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MemberType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Module(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			Module module = type.Module;
			ToLua.PushObject(L, module);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Module on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Namespace(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			string @namespace = type.Namespace;
			LuaDLL.lua_pushstring(L, @namespace);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Namespace on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ReflectedType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			Type reflectedType = type.ReflectedType;
			ToLua.Push(L, reflectedType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ReflectedType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TypeHandle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			RuntimeTypeHandle typeHandle = type.TypeHandle;
			ToLua.PushValue(L, typeHandle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TypeHandle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TypeInitializer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			ConstructorInfo typeInitializer = type.TypeInitializer;
			ToLua.PushObject(L, typeInitializer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TypeInitializer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UnderlyingSystemType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			Type underlyingSystemType = type.UnderlyingSystemType;
			ToLua.Push(L, underlyingSystemType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index UnderlyingSystemType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ContainsGenericParameters(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool containsGenericParameters = type.ContainsGenericParameters;
			LuaDLL.lua_pushboolean(L, containsGenericParameters);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ContainsGenericParameters on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsGenericTypeDefinition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isGenericTypeDefinition = type.IsGenericTypeDefinition;
			LuaDLL.lua_pushboolean(L, isGenericTypeDefinition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsGenericTypeDefinition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsGenericType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isGenericType = type.IsGenericType;
			LuaDLL.lua_pushboolean(L, isGenericType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsGenericType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsGenericParameter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isGenericParameter = type.IsGenericParameter;
			LuaDLL.lua_pushboolean(L, isGenericParameter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsGenericParameter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsNested(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isNested = type.IsNested;
			LuaDLL.lua_pushboolean(L, isNested);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsNested on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsVisible(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			bool isVisible = type.IsVisible;
			LuaDLL.lua_pushboolean(L, isVisible);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsVisible on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GenericParameterPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			int genericParameterPosition = type.GenericParameterPosition;
			LuaDLL.lua_pushinteger(L, genericParameterPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index GenericParameterPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GenericParameterAttributes(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			GenericParameterAttributes genericParameterAttributes = type.GenericParameterAttributes;
			ToLua.Push(L, genericParameterAttributes);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index GenericParameterAttributes on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DeclaringMethod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			MethodBase declaringMethod = type.DeclaringMethod;
			ToLua.PushObject(L, declaringMethod);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DeclaringMethod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_StructLayoutAttribute(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Type type = (Type)obj;
			StructLayoutAttribute structLayoutAttribute = type.StructLayoutAttribute;
			ToLua.PushObject(L, structLayoutAttribute);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index StructLayoutAttribute on a nil value");
		}
		return result;
	}
}
