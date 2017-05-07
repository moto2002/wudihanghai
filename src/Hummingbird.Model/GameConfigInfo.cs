using LuaInterface;
using MiniJSON;
using System;
using System.Collections.Generic;

namespace Hummingbird.Model
{
	public class GameConfigInfo
	{
		private static GameConfigInfo instance;

		public string verName
		{
			get;
			private set;
		}

		public int verCode
		{
			get;
			private set;
		}

		public bool isFullPackage
		{
			get;
			private set;
		}

		public string verMsg
		{
			get;
			private set;
		}

		public string fullPackageUrl
		{
			get;
			private set;
		}

		public string md5DocUrl
		{
			get;
			private set;
		}

		public string increUpdatePrefix
		{
			get;
			private set;
		}

		public string appSize
		{
			get;
			private set;
		}

		public int lastUpdateVerCode
		{
			get;
			private set;
		}

		public int userType
		{
			get;
			private set;
		}

		public string channelCode
		{
			get;
			private set;
		}

		public string appName
		{
			get;
			private set;
		}

		public string channelName
		{
			get;
			private set;
		}

		public string smallChannelSimpleName
		{
			get;
			private set;
		}

		public bool isAppStore
		{
			get;
			private set;
		}

		public string partitionKey
		{
			get;
			private set;
		}

		public string newHouTaiServiceUrl
		{
			get;
			private set;
		}

		public string partitionUrl
		{
			get;
			private set;
		}

		public string noticeUrl
		{
			get;
			private set;
		}

		public string bridgeUrl
		{
			get;
			private set;
		}

		public string submitQuestion
		{
			get;
			private set;
		}

		public string getQuestionList
		{
			get;
			private set;
		}

		public string gmScoreUrl
		{
			get;
			private set;
		}

		public string delQuestion
		{
			get;
			private set;
		}

		public string gmReadQuestionUrl
		{
			get;
			private set;
		}

		public string gmUnReadNumUrl
		{
			get;
			private set;
		}

		public string activeUrl
		{
			get;
			private set;
		}

		public string payHistory
		{
			get;
			private set;
		}

		public string errorLogUrl
		{
			get;
			private set;
		}

		public string headServicesUrl
		{
			get;
			private set;
		}

		public string voiceServicesUrl
		{
			get;
			private set;
		}

		public string checkUserLoginUrl
		{
			get;
			private set;
		}

		public string testHouTaiServicesUrl
		{
			get;
			private set;
		}

		public string loginUrl
		{
			get;
			private set;
		}

		public string registerUrl
		{
			get;
			private set;
		}

		public string questRegisterUrl
		{
			get;
			private set;
		}

		public string accountBindUrl
		{
			get;
			private set;
		}

		public string setSafeQuestion
		{
			get;
			private set;
		}

		public string getSafeQuestion
		{
			get;
			private set;
		}

		public string resetPassword
		{
			get;
			private set;
		}

		public string payUrl
		{
			get;
			private set;
		}

		public string vipChannelUrl
		{
			get;
			private set;
		}

		public string getPayChannel
		{
			get;
			private set;
		}

		public string getGold
		{
			get;
			private set;
		}

		public string getPayRecord
		{
			get;
			private set;
		}

		public bool isOpenRecharge
		{
			get;
			private set;
		}

		public string payReason
		{
			get;
			private set;
		}

		public string iapProduceIdsUrl
		{
			get;
			private set;
		}

		public string extendConfig
		{
			get;
			private set;
		}

		public Dictionary<string, object> dictExtendConfig
		{
			get;
			private set;
		}

		public static GameConfigInfo GetInstance()
		{
			if (GameConfigInfo.instance == null)
			{
				GameConfigInfo.instance = new GameConfigInfo();
			}
			return GameConfigInfo.instance;
		}

		[NoToLua]
		public void SetGameConfigInfo(string text)
		{
			Dictionary<string, object> dictionary = Json.Deserialize(text) as Dictionary<string, object>;
			Dictionary<string, object> dictionary2 = dictionary["updateConfig"] as Dictionary<string, object>;
			Dictionary<string, object> dictionary3 = dictionary["gameConfig"] as Dictionary<string, object>;
			this.verName = Convert.ToString(dictionary2["verName"]);
			this.verCode = Convert.ToInt32(dictionary2["verCode"]);
			this.isFullPackage = Convert.ToBoolean(dictionary2["isFullPackage"]);
			this.verMsg = Convert.ToString(dictionary2["verMsg"]);
			this.fullPackageUrl = Convert.ToString(dictionary2["fullPackageUrl"]);
			this.md5DocUrl = Convert.ToString(dictionary2["md5DocUrl"]);
			this.increUpdatePrefix = Convert.ToString(dictionary2["increUpdatePrefix"]);
			this.appSize = Convert.ToString(dictionary2["appSize"]);
			this.lastUpdateVerCode = Convert.ToInt32(dictionary2["lastUpdateVerCode"]);
			this.userType = Convert.ToInt32(dictionary3["userType"]);
			this.channelCode = Convert.ToString(dictionary3["channelCode"]);
			this.appName = Convert.ToString(dictionary3["appName"]);
			this.channelName = Convert.ToString(dictionary3["channelName"]);
			this.smallChannelSimpleName = Convert.ToString(dictionary3["smallChannelSimpleName"]);
			this.isAppStore = Convert.ToBoolean(dictionary3["isAppStore"]);
			this.partitionKey = Convert.ToString(dictionary3["partitionKey"]);
			this.newHouTaiServiceUrl = Convert.ToString(dictionary3["newHouTaiServiceUrl"]);
			this.partitionUrl = Convert.ToString(dictionary3["partitionUrl"]);
			this.noticeUrl = Convert.ToString(dictionary3["noticeUrl"]);
			this.bridgeUrl = Convert.ToString(dictionary3["bridgeUrl"]);
			this.submitQuestion = Convert.ToString(dictionary3["submitQuestion"]);
			this.getQuestionList = Convert.ToString(dictionary3["getQuestionList"]);
			this.gmScoreUrl = Convert.ToString(dictionary3["gmScoreUrl"]);
			this.delQuestion = Convert.ToString(dictionary3["delQuestion"]);
			this.gmReadQuestionUrl = Convert.ToString(dictionary3["gmReadQuestionUrl"]);
			this.gmUnReadNumUrl = Convert.ToString(dictionary3["gmUnReadNumUrl"]);
			this.activeUrl = Convert.ToString(dictionary3["activeUrl"]);
			this.payHistory = Convert.ToString(dictionary3["payHistory"]);
			this.errorLogUrl = Convert.ToString(dictionary3["errorLogUrl"]);
			this.headServicesUrl = Convert.ToString(dictionary3["headServicesUrl"]);
			this.voiceServicesUrl = Convert.ToString(dictionary3["voiceServicesUrl"]);
			this.checkUserLoginUrl = Convert.ToString(dictionary3["checkUserLoginUrl"]);
			this.testHouTaiServicesUrl = Convert.ToString(dictionary3["testHouTaiServicesUrl"]);
			this.loginUrl = Convert.ToString(dictionary3["loginUrl"]);
			this.registerUrl = Convert.ToString(dictionary3["registerUrl"]);
			this.questRegisterUrl = Convert.ToString(dictionary3["questRegisterUrl"]);
			this.accountBindUrl = Convert.ToString(dictionary3["accountBindUrl"]);
			this.setSafeQuestion = Convert.ToString(dictionary3["setSafeQuestion"]);
			this.getSafeQuestion = Convert.ToString(dictionary3["getSafeQuestion"]);
			this.resetPassword = Convert.ToString(dictionary3["resetPassword"]);
			this.payUrl = Convert.ToString(dictionary3["payUrl"]);
			this.vipChannelUrl = Convert.ToString(dictionary3["vipChannelUrl"]);
			this.getPayChannel = Convert.ToString(dictionary3["getPayChannel"]);
			this.getGold = Convert.ToString(dictionary3["getGold"]);
			this.getPayRecord = Convert.ToString(dictionary3["getPayRecord"]);
			this.isOpenRecharge = Convert.ToBoolean(dictionary3["isOpenRecharge"]);
			this.payReason = Convert.ToString(dictionary3["payReason"]);
			this.iapProduceIdsUrl = Convert.ToString(dictionary3["iapProduceIdsUrl"]);
			if (dictionary3.ContainsKey("extendChannelConfig"))
			{
				this.extendConfig = Json.Serialize(dictionary3["extendChannelConfig"]);
				this.dictExtendConfig = (Json.Deserialize(this.extendConfig) as Dictionary<string, object>);
			}
			else
			{
				this.extendConfig = string.Empty;
			}
		}
	}
}
