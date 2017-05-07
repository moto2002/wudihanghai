using Hummingbird.SeaBattle.Utility.Platform;
using LuaInterface;
using System;

public class Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PlatformUtil), typeof(object), null);
		L.RegFunction("GetInstance", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetInstance));
		L.RegFunction("GetAppVersionCode", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetAppVersionCode));
		L.RegFunction("GetAppVersionName", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetAppVersionName));
		L.RegFunction("GetPlatformName", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetPlatformName));
		L.RegFunction("GetProvidersName", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetProvidersName));
		L.RegFunction("GetIMEI", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetIMEI));
		L.RegFunction("GetAndroidID", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetAndroidID));
		L.RegFunction("GetIDFA", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetIDFA));
		L.RegFunction("GetSimSerialNumber", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetSimSerialNumber));
		L.RegFunction("GetLocalIpAddress", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetLocalIpAddress));
		L.RegFunction("GetDeviceMacAddress", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetDeviceMacAddress));
		L.RegFunction("GetDeviceNetworkType", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetDeviceNetworkType));
		L.RegFunction("GetDeviceManufacturer", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetDeviceManufacturer));
		L.RegFunction("GetDeviceModel", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetDeviceModel));
		L.RegFunction("GetScreenSize", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetScreenSize));
		L.RegFunction("GetDeviceSystemVersion", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetDeviceSystemVersion));
		L.RegFunction("GetDeviceTotalMemorySize", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetDeviceTotalMemorySize));
		L.RegFunction("GetDeviceAvailableMemorySize", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetDeviceAvailableMemorySize));
		L.RegFunction("GetTotalInternalBlockSize", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetTotalInternalBlockSize));
		L.RegFunction("GetAvailableInternalBlockSize", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetAvailableInternalBlockSize));
		L.RegFunction("IsExistSDCard", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.IsExistSDCard));
		L.RegFunction("GetTotalSDCardBlockSize", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetTotalSDCardBlockSize));
		L.RegFunction("GetAvailableSDCardBlockSize", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetAvailableSDCardBlockSize));
		L.RegFunction("GetUUID", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetUUID));
		L.RegFunction("IsNetworkConnected", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.IsNetworkConnected));
		L.RegFunction("OpenPhotoAlbum", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.OpenPhotoAlbum));
		L.RegFunction("OpenCamera", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.OpenCamera));
		L.RegFunction("StartRecording", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.StartRecording));
		L.RegFunction("FinishRecording", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.FinishRecording));
		L.RegFunction("PlayAudio", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.PlayAudio));
		L.RegFunction("StopAudio", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.StopAudio));
		L.RegFunction("TranslateAudio", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.TranslateAudio));
		L.RegFunction("GetAudioDuration", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetAudioDuration));
		L.RegFunction("InitXGPush", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.InitXGPush));
		L.RegFunction("GetXGPushToken", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetXGPushToken));
		L.RegFunction("GetLocalFileInfo", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetLocalFileInfo));
		L.RegFunction("SetLocalFileInfo", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.SetLocalFileInfo));
		L.RegFunction("RegisterBatteryReceiver", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.RegisterBatteryReceiver));
		L.RegFunction("GetSessionId", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.GetSessionId));
		L.RegFunction("Login", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.Login));
		L.RegFunction("Pay", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.Pay));
		L.RegFunction("SubmitRoleData", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.SubmitRoleData));
		L.RegFunction("HasChannelCenter", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.HasChannelCenter));
		L.RegFunction("OpenChannelCenter", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.OpenChannelCenter));
		L.RegFunction("CallSdkEvent", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.CallSdkEvent));
		L.RegFunction("SwitchAccount", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.SwitchAccount));
		L.RegFunction("SetLogoutListener", new LuaCSFunction(Hummingbird_SeaBattle_Utility_Platform_PlatformUtilWrap.SetLogoutListener));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInstance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			PlatformUtil instance = PlatformUtil.GetInstance();
			ToLua.PushObject(L, instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAppVersionCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			int appVersionCode = platformUtil.GetAppVersionCode();
			LuaDLL.lua_pushinteger(L, appVersionCode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAppVersionName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string appVersionName = platformUtil.GetAppVersionName();
			LuaDLL.lua_pushstring(L, appVersionName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPlatformName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string platformName = platformUtil.GetPlatformName();
			LuaDLL.lua_pushstring(L, platformName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetProvidersName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string providersName = platformUtil.GetProvidersName();
			LuaDLL.lua_pushstring(L, providersName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIMEI(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string iMEI = platformUtil.GetIMEI();
			LuaDLL.lua_pushstring(L, iMEI);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAndroidID(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string androidID = platformUtil.GetAndroidID();
			LuaDLL.lua_pushstring(L, androidID);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIDFA(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string iDFA = platformUtil.GetIDFA();
			LuaDLL.lua_pushstring(L, iDFA);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSimSerialNumber(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string simSerialNumber = platformUtil.GetSimSerialNumber();
			LuaDLL.lua_pushstring(L, simSerialNumber);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLocalIpAddress(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string localIpAddress = platformUtil.GetLocalIpAddress();
			LuaDLL.lua_pushstring(L, localIpAddress);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDeviceMacAddress(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string deviceMacAddress = platformUtil.GetDeviceMacAddress();
			LuaDLL.lua_pushstring(L, deviceMacAddress);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDeviceNetworkType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string deviceNetworkType = platformUtil.GetDeviceNetworkType();
			LuaDLL.lua_pushstring(L, deviceNetworkType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDeviceManufacturer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string deviceManufacturer = platformUtil.GetDeviceManufacturer();
			LuaDLL.lua_pushstring(L, deviceManufacturer);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDeviceModel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string deviceModel = platformUtil.GetDeviceModel();
			LuaDLL.lua_pushstring(L, deviceModel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetScreenSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string screenSize = platformUtil.GetScreenSize();
			LuaDLL.lua_pushstring(L, screenSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDeviceSystemVersion(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string deviceSystemVersion = platformUtil.GetDeviceSystemVersion();
			LuaDLL.lua_pushstring(L, deviceSystemVersion);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDeviceTotalMemorySize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string deviceTotalMemorySize = platformUtil.GetDeviceTotalMemorySize();
			LuaDLL.lua_pushstring(L, deviceTotalMemorySize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDeviceAvailableMemorySize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string deviceAvailableMemorySize = platformUtil.GetDeviceAvailableMemorySize();
			LuaDLL.lua_pushstring(L, deviceAvailableMemorySize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTotalInternalBlockSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string totalInternalBlockSize = platformUtil.GetTotalInternalBlockSize();
			LuaDLL.lua_pushstring(L, totalInternalBlockSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAvailableInternalBlockSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string availableInternalBlockSize = platformUtil.GetAvailableInternalBlockSize();
			LuaDLL.lua_pushstring(L, availableInternalBlockSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsExistSDCard(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string str = platformUtil.IsExistSDCard();
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
	private static int GetTotalSDCardBlockSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string totalSDCardBlockSize = platformUtil.GetTotalSDCardBlockSize();
			LuaDLL.lua_pushstring(L, totalSDCardBlockSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAvailableSDCardBlockSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string availableSDCardBlockSize = platformUtil.GetAvailableSDCardBlockSize();
			LuaDLL.lua_pushstring(L, availableSDCardBlockSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetUUID(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string uUID = platformUtil.GetUUID();
			LuaDLL.lua_pushstring(L, uUID);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsNetworkConnected(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			bool isShowTips = LuaDLL.luaL_checkboolean(L, 2);
			bool value = platformUtil.IsNetworkConnected(isShowTips);
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
	private static int OpenPhotoAlbum(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<string> completeCallback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				completeCallback = (Action<string>)ToLua.CheckObject(L, 2, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				completeCallback = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			platformUtil.OpenPhotoAlbum(completeCallback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OpenCamera(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<string> completeCallback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				completeCallback = (Action<string>)ToLua.CheckObject(L, 2, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				completeCallback = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			platformUtil.OpenCamera(completeCallback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartRecording(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<string> completeCallback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				completeCallback = (Action<string>)ToLua.CheckObject(L, 2, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				completeCallback = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			platformUtil.StartRecording(completeCallback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FinishRecording(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			platformUtil.FinishRecording();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayAudio(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string audioFile = ToLua.CheckString(L, 2);
			platformUtil.PlayAudio(audioFile);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopAudio(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			platformUtil.StopAudio();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TranslateAudio(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string audioFile = ToLua.CheckString(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action<string> completeCallback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				completeCallback = (Action<string>)ToLua.CheckObject(L, 3, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				completeCallback = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			platformUtil.TranslateAudio(audioFile, completeCallback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAudioDuration(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string audioFile = ToLua.CheckString(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action<int> completeCallback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				completeCallback = (Action<int>)ToLua.CheckObject(L, 3, typeof(Action<int>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				completeCallback = (DelegateFactory.CreateDelegate(typeof(Action<int>), func) as Action<int>);
			}
			platformUtil.GetAudioDuration(audioFile, completeCallback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitXGPush(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			platformUtil.InitXGPush();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetXGPushToken(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string xGPushToken = platformUtil.GetXGPushToken();
			LuaDLL.lua_pushstring(L, xGPushToken);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLocalFileInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string localFileInfo = platformUtil.GetLocalFileInfo();
			LuaDLL.lua_pushstring(L, localFileInfo);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLocalFileInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string key = ToLua.CheckString(L, 2);
			string value = ToLua.CheckString(L, 3);
			platformUtil.SetLocalFileInfo(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterBatteryReceiver(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			LuaFunction luaFunc = ToLua.CheckLuaFunction(L, 2);
			platformUtil.RegisterBatteryReceiver(luaFunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSessionId(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			bool reGenerate = LuaDLL.luaL_checkboolean(L, 2);
			string sessionId = platformUtil.GetSessionId(reGenerate);
			LuaDLL.lua_pushstring(L, sessionId);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Login(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string customParam = ToLua.CheckString(L, 2);
			LuaFunction luaFunc = ToLua.CheckLuaFunction(L, 3);
			platformUtil.Login(customParam, luaFunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Pay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string jsonPayData = ToLua.CheckString(L, 2);
			platformUtil.Pay(jsonPayData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SubmitRoleData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string jsonRoleData = ToLua.CheckString(L, 2);
			platformUtil.SubmitRoleData(jsonRoleData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasChannelCenter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			bool value = platformUtil.HasChannelCenter();
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
	private static int OpenChannelCenter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			platformUtil.OpenChannelCenter();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallSdkEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			string jsonData = ToLua.CheckString(L, 2);
			platformUtil.CallSdkEvent(jsonData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SwitchAccount(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			LuaFunction luaFunc = ToLua.CheckLuaFunction(L, 2);
			platformUtil.SwitchAccount(luaFunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLogoutListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlatformUtil platformUtil = (PlatformUtil)ToLua.CheckObject(L, 1, typeof(PlatformUtil));
			LuaFunction logoutListener = ToLua.CheckLuaFunction(L, 2);
			platformUtil.SetLogoutListener(logoutListener);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
