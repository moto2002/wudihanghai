using System;
using UnityEngine;

public static class LuaConst
{
	public static string luaDir = Application.dataPath + "/Lua";

	public static string toluaDir = Application.dataPath + "/ToLua/Lua";

	public static string osDir = "Android";

	public static string luaResDir = string.Format("{0}/{1}/Lua", Application.persistentDataPath, LuaConst.osDir);

	public static string zbsDir = LuaConst.luaResDir + "/mobdebug/";

	public static bool openLuaSocket = true;

	public static bool openZbsDebugger = false;
}
