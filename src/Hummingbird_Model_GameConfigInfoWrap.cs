using Hummingbird.Model;
using LuaInterface;
using System;
using System.Collections.Generic;

public class Hummingbird_Model_GameConfigInfoWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameConfigInfo), typeof(object), null);
		L.RegFunction("GetInstance", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.GetInstance));
		L.RegFunction("New", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap._CreateHummingbird_Model_GameConfigInfo));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("verName", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_verName), null);
		L.RegVar("verCode", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_verCode), null);
		L.RegVar("isFullPackage", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_isFullPackage), null);
		L.RegVar("verMsg", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_verMsg), null);
		L.RegVar("fullPackageUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_fullPackageUrl), null);
		L.RegVar("md5DocUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_md5DocUrl), null);
		L.RegVar("increUpdatePrefix", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_increUpdatePrefix), null);
		L.RegVar("appSize", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_appSize), null);
		L.RegVar("lastUpdateVerCode", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_lastUpdateVerCode), null);
		L.RegVar("userType", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_userType), null);
		L.RegVar("channelCode", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_channelCode), null);
		L.RegVar("appName", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_appName), null);
		L.RegVar("channelName", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_channelName), null);
		L.RegVar("smallChannelSimpleName", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_smallChannelSimpleName), null);
		L.RegVar("isAppStore", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_isAppStore), null);
		L.RegVar("partitionKey", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_partitionKey), null);
		L.RegVar("newHouTaiServiceUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_newHouTaiServiceUrl), null);
		L.RegVar("partitionUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_partitionUrl), null);
		L.RegVar("noticeUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_noticeUrl), null);
		L.RegVar("bridgeUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_bridgeUrl), null);
		L.RegVar("submitQuestion", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_submitQuestion), null);
		L.RegVar("getQuestionList", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_getQuestionList), null);
		L.RegVar("gmScoreUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_gmScoreUrl), null);
		L.RegVar("delQuestion", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_delQuestion), null);
		L.RegVar("gmReadQuestionUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_gmReadQuestionUrl), null);
		L.RegVar("gmUnReadNumUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_gmUnReadNumUrl), null);
		L.RegVar("activeUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_activeUrl), null);
		L.RegVar("payHistory", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_payHistory), null);
		L.RegVar("errorLogUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_errorLogUrl), null);
		L.RegVar("headServicesUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_headServicesUrl), null);
		L.RegVar("voiceServicesUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_voiceServicesUrl), null);
		L.RegVar("checkUserLoginUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_checkUserLoginUrl), null);
		L.RegVar("testHouTaiServicesUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_testHouTaiServicesUrl), null);
		L.RegVar("loginUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_loginUrl), null);
		L.RegVar("registerUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_registerUrl), null);
		L.RegVar("questRegisterUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_questRegisterUrl), null);
		L.RegVar("accountBindUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_accountBindUrl), null);
		L.RegVar("setSafeQuestion", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_setSafeQuestion), null);
		L.RegVar("getSafeQuestion", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_getSafeQuestion), null);
		L.RegVar("resetPassword", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_resetPassword), null);
		L.RegVar("payUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_payUrl), null);
		L.RegVar("vipChannelUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_vipChannelUrl), null);
		L.RegVar("getPayChannel", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_getPayChannel), null);
		L.RegVar("getGold", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_getGold), null);
		L.RegVar("getPayRecord", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_getPayRecord), null);
		L.RegVar("isOpenRecharge", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_isOpenRecharge), null);
		L.RegVar("payReason", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_payReason), null);
		L.RegVar("iapProduceIdsUrl", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_iapProduceIdsUrl), null);
		L.RegVar("extendConfig", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_extendConfig), null);
		L.RegVar("dictExtendConfig", new LuaCSFunction(Hummingbird_Model_GameConfigInfoWrap.get_dictExtendConfig), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateHummingbird_Model_GameConfigInfo(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				GameConfigInfo o = new GameConfigInfo();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Hummingbird.Model.GameConfigInfo.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInstance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			GameConfigInfo instance = GameConfigInfo.GetInstance();
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
	private static int get_verName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string verName = gameConfigInfo.verName;
			LuaDLL.lua_pushstring(L, verName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_verCode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			int verCode = gameConfigInfo.verCode;
			LuaDLL.lua_pushinteger(L, verCode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verCode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isFullPackage(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			bool isFullPackage = gameConfigInfo.isFullPackage;
			LuaDLL.lua_pushboolean(L, isFullPackage);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isFullPackage on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_verMsg(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string verMsg = gameConfigInfo.verMsg;
			LuaDLL.lua_pushstring(L, verMsg);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verMsg on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fullPackageUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string fullPackageUrl = gameConfigInfo.fullPackageUrl;
			LuaDLL.lua_pushstring(L, fullPackageUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fullPackageUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_md5DocUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string md5DocUrl = gameConfigInfo.md5DocUrl;
			LuaDLL.lua_pushstring(L, md5DocUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index md5DocUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_increUpdatePrefix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string increUpdatePrefix = gameConfigInfo.increUpdatePrefix;
			LuaDLL.lua_pushstring(L, increUpdatePrefix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index increUpdatePrefix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_appSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string appSize = gameConfigInfo.appSize;
			LuaDLL.lua_pushstring(L, appSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index appSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lastUpdateVerCode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			int lastUpdateVerCode = gameConfigInfo.lastUpdateVerCode;
			LuaDLL.lua_pushinteger(L, lastUpdateVerCode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lastUpdateVerCode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_userType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			int userType = gameConfigInfo.userType;
			LuaDLL.lua_pushinteger(L, userType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index userType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_channelCode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string channelCode = gameConfigInfo.channelCode;
			LuaDLL.lua_pushstring(L, channelCode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index channelCode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_appName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string appName = gameConfigInfo.appName;
			LuaDLL.lua_pushstring(L, appName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index appName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_channelName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string channelName = gameConfigInfo.channelName;
			LuaDLL.lua_pushstring(L, channelName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index channelName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_smallChannelSimpleName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string smallChannelSimpleName = gameConfigInfo.smallChannelSimpleName;
			LuaDLL.lua_pushstring(L, smallChannelSimpleName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index smallChannelSimpleName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAppStore(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			bool isAppStore = gameConfigInfo.isAppStore;
			LuaDLL.lua_pushboolean(L, isAppStore);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isAppStore on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_partitionKey(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string partitionKey = gameConfigInfo.partitionKey;
			LuaDLL.lua_pushstring(L, partitionKey);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partitionKey on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_newHouTaiServiceUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string newHouTaiServiceUrl = gameConfigInfo.newHouTaiServiceUrl;
			LuaDLL.lua_pushstring(L, newHouTaiServiceUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index newHouTaiServiceUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_partitionUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string partitionUrl = gameConfigInfo.partitionUrl;
			LuaDLL.lua_pushstring(L, partitionUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partitionUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_noticeUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string noticeUrl = gameConfigInfo.noticeUrl;
			LuaDLL.lua_pushstring(L, noticeUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index noticeUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bridgeUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string bridgeUrl = gameConfigInfo.bridgeUrl;
			LuaDLL.lua_pushstring(L, bridgeUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bridgeUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_submitQuestion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string submitQuestion = gameConfigInfo.submitQuestion;
			LuaDLL.lua_pushstring(L, submitQuestion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index submitQuestion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_getQuestionList(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string getQuestionList = gameConfigInfo.getQuestionList;
			LuaDLL.lua_pushstring(L, getQuestionList);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index getQuestionList on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gmScoreUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string gmScoreUrl = gameConfigInfo.gmScoreUrl;
			LuaDLL.lua_pushstring(L, gmScoreUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gmScoreUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_delQuestion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string delQuestion = gameConfigInfo.delQuestion;
			LuaDLL.lua_pushstring(L, delQuestion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index delQuestion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gmReadQuestionUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string gmReadQuestionUrl = gameConfigInfo.gmReadQuestionUrl;
			LuaDLL.lua_pushstring(L, gmReadQuestionUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gmReadQuestionUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gmUnReadNumUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string gmUnReadNumUrl = gameConfigInfo.gmUnReadNumUrl;
			LuaDLL.lua_pushstring(L, gmUnReadNumUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gmUnReadNumUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string activeUrl = gameConfigInfo.activeUrl;
			LuaDLL.lua_pushstring(L, activeUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_payHistory(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string payHistory = gameConfigInfo.payHistory;
			LuaDLL.lua_pushstring(L, payHistory);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index payHistory on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_errorLogUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string errorLogUrl = gameConfigInfo.errorLogUrl;
			LuaDLL.lua_pushstring(L, errorLogUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index errorLogUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_headServicesUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string headServicesUrl = gameConfigInfo.headServicesUrl;
			LuaDLL.lua_pushstring(L, headServicesUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index headServicesUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_voiceServicesUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string voiceServicesUrl = gameConfigInfo.voiceServicesUrl;
			LuaDLL.lua_pushstring(L, voiceServicesUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index voiceServicesUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_checkUserLoginUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string checkUserLoginUrl = gameConfigInfo.checkUserLoginUrl;
			LuaDLL.lua_pushstring(L, checkUserLoginUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index checkUserLoginUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_testHouTaiServicesUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string testHouTaiServicesUrl = gameConfigInfo.testHouTaiServicesUrl;
			LuaDLL.lua_pushstring(L, testHouTaiServicesUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index testHouTaiServicesUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_loginUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string loginUrl = gameConfigInfo.loginUrl;
			LuaDLL.lua_pushstring(L, loginUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index loginUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_registerUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string registerUrl = gameConfigInfo.registerUrl;
			LuaDLL.lua_pushstring(L, registerUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index registerUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_questRegisterUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string questRegisterUrl = gameConfigInfo.questRegisterUrl;
			LuaDLL.lua_pushstring(L, questRegisterUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index questRegisterUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_accountBindUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string accountBindUrl = gameConfigInfo.accountBindUrl;
			LuaDLL.lua_pushstring(L, accountBindUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index accountBindUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_setSafeQuestion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string setSafeQuestion = gameConfigInfo.setSafeQuestion;
			LuaDLL.lua_pushstring(L, setSafeQuestion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index setSafeQuestion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_getSafeQuestion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string getSafeQuestion = gameConfigInfo.getSafeQuestion;
			LuaDLL.lua_pushstring(L, getSafeQuestion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index getSafeQuestion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resetPassword(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string resetPassword = gameConfigInfo.resetPassword;
			LuaDLL.lua_pushstring(L, resetPassword);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resetPassword on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_payUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string payUrl = gameConfigInfo.payUrl;
			LuaDLL.lua_pushstring(L, payUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index payUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_vipChannelUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string vipChannelUrl = gameConfigInfo.vipChannelUrl;
			LuaDLL.lua_pushstring(L, vipChannelUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index vipChannelUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_getPayChannel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string getPayChannel = gameConfigInfo.getPayChannel;
			LuaDLL.lua_pushstring(L, getPayChannel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index getPayChannel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_getGold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string getGold = gameConfigInfo.getGold;
			LuaDLL.lua_pushstring(L, getGold);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index getGold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_getPayRecord(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string getPayRecord = gameConfigInfo.getPayRecord;
			LuaDLL.lua_pushstring(L, getPayRecord);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index getPayRecord on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isOpenRecharge(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			bool isOpenRecharge = gameConfigInfo.isOpenRecharge;
			LuaDLL.lua_pushboolean(L, isOpenRecharge);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isOpenRecharge on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_payReason(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string payReason = gameConfigInfo.payReason;
			LuaDLL.lua_pushstring(L, payReason);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index payReason on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_iapProduceIdsUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string iapProduceIdsUrl = gameConfigInfo.iapProduceIdsUrl;
			LuaDLL.lua_pushstring(L, iapProduceIdsUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index iapProduceIdsUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_extendConfig(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			string extendConfig = gameConfigInfo.extendConfig;
			LuaDLL.lua_pushstring(L, extendConfig);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index extendConfig on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dictExtendConfig(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameConfigInfo gameConfigInfo = (GameConfigInfo)obj;
			Dictionary<string, object> dictExtendConfig = gameConfigInfo.dictExtendConfig;
			ToLua.PushObject(L, dictExtendConfig);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dictExtendConfig on a nil value");
		}
		return result;
	}
}
