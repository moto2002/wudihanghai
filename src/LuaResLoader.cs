using LuaInterface;
using System;
using System.IO;
using System.Text;
using UnityEngine;

public class LuaResLoader : LuaFileUtils
{
	public LuaResLoader()
	{
		LuaFileUtils.instance = this;
		this.beZip = false;
	}

	public override byte[] ReadFile(string fileName)
	{
		byte[] array = this.ReadDownLoadFile(fileName);
		if (array == null)
		{
			array = this.ReadResourceFile(fileName);
		}
		if (array == null)
		{
			array = base.ReadFile(fileName);
		}
		return array;
	}

	public override string FindFileError(string fileName)
	{
		if (Path.IsPathRooted(fileName))
		{
			return fileName;
		}
		StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
		if (Path.GetExtension(fileName) == ".lua")
		{
			fileName = fileName.Substring(0, fileName.Length - 4);
		}
		for (int i = 0; i < this.searchPaths.Count; i++)
		{
			stringBuilder.AppendFormat("\n\tno file '{0}'", this.searchPaths[i]);
		}
		stringBuilder.AppendFormat("\n\tno file ./Resources/?.lua", new object[0]);
		stringBuilder = stringBuilder.Replace("?", fileName);
		return StringBuilderCache.GetStringAndRelease(stringBuilder);
	}

	private byte[] ReadResourceFile(string fileName)
	{
		if (!fileName.EndsWith(".lua"))
		{
			fileName += ".lua";
		}
		byte[] result = null;
		string path = "Lua/" + fileName;
		TextAsset textAsset = Resources.Load(path, typeof(TextAsset)) as TextAsset;
		if (textAsset != null)
		{
			result = textAsset.bytes;
			Resources.UnloadAsset(textAsset);
		}
		return result;
	}

	private byte[] ReadDownLoadFile(string fileName)
	{
		if (!fileName.EndsWith(".lua"))
		{
			fileName += ".lua";
		}
		string path = fileName;
		if (!Path.IsPathRooted(fileName))
		{
			path = string.Format("{0}/{1}", LuaConst.luaResDir, fileName);
		}
		if (File.Exists(path))
		{
			return File.ReadAllBytes(path);
		}
		return null;
	}
}
