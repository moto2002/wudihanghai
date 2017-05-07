using LuaInterface;
using System;
using System.IO;
using UnityEngine;

namespace LuaFramework
{
	public class LuaLoader : LuaFileUtils
	{
		private ResourceManager m_resMgr;

		private ResourceManager resMgr
		{
			get
			{
				if (this.m_resMgr == null)
				{
					this.m_resMgr = AppFacade.Instance.GetManager<ResourceManager>("ResourceManager");
				}
				return this.m_resMgr;
			}
		}

		public LuaLoader()
		{
			LuaFileUtils.instance = this;
			this.beZip = true;
		}

		public void AddBundle(string bundleName)
		{
			string path = Util.DataPath + bundleName.ToLower();
			if (File.Exists(path))
			{
				AssetBundle assetBundle = AssetBundle.CreateFromFile(path);
				if (assetBundle != null)
				{
					bundleName = bundleName.Replace("lua/", string.Empty).Replace(".unity3d", string.Empty);
					base.AddSearchBundle(bundleName.ToLower(), assetBundle);
				}
			}
		}

		public override byte[] ReadFile(string fileName)
		{
			return base.ReadFile(fileName);
		}
	}
}
