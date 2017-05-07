using LuaInterface;
using System;
using UnityEngine;

namespace LuaFramework
{
	public class AppConst
	{
		[NoToLua]
		public const string AppVersionCodeFileName = "appversioncode";

		[NoToLua]
		public const string BackupDeviceIpAddress = "bakip";

		[NoToLua]
		public const string GameVerFileName = "sbv";

		[NoToLua]
		public const string ResourceMd5FileName = "sbf";

		[NoToLua]
		public const string ResourceMd5TempFileName = "sbf_temp";

		[NoToLua]
		public const string UpdateSmallPackageName = "sb_pkg_temp.zip";

		[NoToLua]
		public const string AssetBundleDirName = "bundles";

		[NoToLua]
		public const string AssetPathPrefix = "Assets/SeaBattle/DynamicAssets/";

		[NoToLua]
		public const string AssetStaticPathPrefix = "Assets/SeaBattle/StaticAssets/";

		[NoToLua]
		public const bool LuaByteMode = false;

		[NoToLua]
		public const bool LuaBundleMode = true;

		[NoToLua]
		public const int TimerInterval = 1;

		[NoToLua]
		public const int GameFrameRate = 30;

		[NoToLua]
		public const string MoiveName = "moive.mp4";

		[NoToLua]
		public const string AppName = "SeaBattle";

		[NoToLua]
		public const string LuaTempDir = "LuaTemp/";

		[NoToLua]
		public const string LuaFileBundleName = "sea_battle";

		[NoToLua]
		public const string AudioFileBundleName = "audio";

		[NoToLua]
		public const string AppPrefix = "SeaBattle_";

		[NoToLua]
		public const string ExtName = ".unity3d";

		[NoToLua]
		public const string StreamingAssetsDirName = "StreamingAssets";

		[NoToLua]
		public const string AssetsBundleManifest = "AssetsBundleManifest";

		[NoToLua]
		public const string GameConfigUrl = "http://serverlist.dhh.game1919.com:8080/infocenter/static/upgrade/json/{0}.json";

		[NoToLua]
		public const string GameErrorSubmitUrl = "http://logevent.dhh.game1919.com/log_event/device/addBatch";

		public static int GameVerCode;

		public static string GameVerName;

		[NoToLua]
		public static string GameDeviceDrainUrl = "http://logevent.dhh.game1919.com/log_event/device/add";

		public static string UserId = string.Empty;

		public static int SocketPort = 0;

		public static string SocketAddress = string.Empty;

		public static string FrameworkRoot
		{
			get
			{
				return Application.dataPath;
			}
		}

		public static string PbPath
		{
			get
			{
				return Util.DataPath + "pb/";
			}
		}
	}
}
