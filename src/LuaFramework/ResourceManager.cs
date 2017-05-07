using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using UnityEngine;

namespace LuaFramework
{
	public class ResourceManager : Manager
	{
		private class AssetBundleInfo
		{
			public AssetBundle m_AssetBundle;

			public int m_ReferencedCount;

			public UnityEngine.Object asset;

			public Dictionary<string, UnityEngine.Object> assets;

			public AssetBundleInfo(AssetBundle assetBundle)
			{
				this.m_AssetBundle = assetBundle;
				this.m_ReferencedCount = 1;
			}
		}

		private class LoadAssetRequest
		{
			public Type assetType;

			public string[] assetNames;

			public LuaFunction luaFunc;

			public Action<UnityEngine.Object[]> sharpFunc;
		}

		private string m_InDownloadingURL = string.Empty;

		private string m_OutDownloadingURL = string.Empty;

		private AssetBundleManifest m_AssetBundleManifest;

		private AsyncOperation m_AsyncOperation;

		private Dictionary<string, string[]> m_Dependencies = new Dictionary<string, string[]>();

		private Dictionary<string, int> m_DownloadingBundleCount = new Dictionary<string, int>();

		private Dictionary<string, ResourceManager.AssetBundleInfo> m_LoadedAssetBundles = new Dictionary<string, ResourceManager.AssetBundleInfo>();

		private Dictionary<string, List<ResourceManager.LoadAssetRequest>> m_LoadRequests = new Dictionary<string, List<ResourceManager.LoadAssetRequest>>();

		private Dictionary<string, Dictionary<string, Sprite>> spriteInAltasDict = new Dictionary<string, Dictionary<string, Sprite>>();

		private Dictionary<string, Material> spriteAltasWithMaterialDict = new Dictionary<string, Material>();

		private Dictionary<string, bool> dictExistBundlesName = new Dictionary<string, bool>();

		private LuaFunction loadSceneProgressCallback;

		private string strPreScene_abName = string.Empty;

		[NoToLua]
		public void Initialize(string manifestName, Action initOK)
		{
			this.m_OutDownloadingURL = Util.GetRelativePath();
			this.m_InDownloadingURL = Util.GetStreamingAssetsPath();
			this.ReadBundlesInDataPath();
			this.LoadAsset<AssetBundleManifest>(manifestName, new string[]
			{
				"AssetBundleManifest"
			}, delegate(UnityEngine.Object[] objs)
			{
				if (objs.Length > 0)
				{
					this.m_AssetBundleManifest = (objs[0] as AssetBundleManifest);
				}
				if (initOK != null)
				{
					initOK();
				}
				this.UnloadAssetBundle(manifestName, false, true);
			}, null);
		}

		private void ReadBundlesInDataPath()
		{
			string path = Util.DataPath + "bundles";
			if (Directory.Exists(path))
			{
				string[] files = Directory.GetFiles(path);
				for (int i = 0; i < files.Length; i++)
				{
					this.dictExistBundlesName.Add(Path.GetFileName(files[i]), true);
				}
			}
		}

		public void LoadScene(string name, LuaFunction progressCallback, LuaFunction completeCallback)
		{
			this.loadSceneProgressCallback = progressCallback;
			string abName = Util.GetAssetBundleName("Scenes/" + name);
			this.LoadAsset<UnityEngine.Object>(abName, new string[]
			{
				name
			}, delegate(UnityEngine.Object[] objs)
			{
				if (objs.Length == 0)
				{
					return;
				}
				this.StartCoroutine(this.LoadSceneAsync(name, abName, this.loadSceneProgressCallback, completeCallback));
			}, null);
		}

		[DebuggerHidden]
		private IEnumerator LoadSceneAsync(string scene, string abName, LuaFunction progressCallback, LuaFunction completeCallback)
		{
			ResourceManager.<LoadSceneAsync>c__IteratorE <LoadSceneAsync>c__IteratorE = new ResourceManager.<LoadSceneAsync>c__IteratorE();
			<LoadSceneAsync>c__IteratorE.scene = scene;
			<LoadSceneAsync>c__IteratorE.progressCallback = progressCallback;
			<LoadSceneAsync>c__IteratorE.completeCallback = completeCallback;
			<LoadSceneAsync>c__IteratorE.abName = abName;
			<LoadSceneAsync>c__IteratorE.<$>scene = scene;
			<LoadSceneAsync>c__IteratorE.<$>progressCallback = progressCallback;
			<LoadSceneAsync>c__IteratorE.<$>completeCallback = completeCallback;
			<LoadSceneAsync>c__IteratorE.<$>abName = abName;
			<LoadSceneAsync>c__IteratorE.<>f__this = this;
			return <LoadSceneAsync>c__IteratorE;
		}

		[NoToLua]
		public void LoadLuaBundle(Action<AssetBundle> callback)
		{
			base.StartCoroutine(this.OnLoadLuaBundle(callback));
		}

		[DebuggerHidden]
		private IEnumerator OnLoadLuaBundle(Action<AssetBundle> callback)
		{
			ResourceManager.<OnLoadLuaBundle>c__IteratorF <OnLoadLuaBundle>c__IteratorF = new ResourceManager.<OnLoadLuaBundle>c__IteratorF();
			<OnLoadLuaBundle>c__IteratorF.callback = callback;
			<OnLoadLuaBundle>c__IteratorF.<$>callback = callback;
			<OnLoadLuaBundle>c__IteratorF.<>f__this = this;
			return <OnLoadLuaBundle>c__IteratorF;
		}

		[NoToLua]
		public void LoadPrefab(string path, Action<UnityEngine.Object[]> callback)
		{
			string assetBundleName = Util.GetAssetBundleName(path);
			string text = path.Substring(path.LastIndexOf('/') + 1);
			if (path.StartsWith("Effects/"))
			{
				assetBundleName = Util.GetAssetBundleName("Effects/allEffects");
			}
			this.LoadAsset<GameObject>(assetBundleName, new string[]
			{
				text
			}, callback, null);
		}

		public void LoadSprites(string path, Action<UnityEngine.Object[]> action, LuaFunction func)
		{
			string text = path.Substring(0, path.LastIndexOf('.'));
			string text2 = text.Substring(text.LastIndexOf('/') + 1);
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			path = path.Substring(0, path.LastIndexOf('/'));
			string text3 = path.Substring(path.LastIndexOf('/') + 1).ToLower();
			stringBuilder.AppendFormat("{0}/{1}", path, text3);
			string assetBundleName = Util.GetAssetBundleName(StringBuilderCache.GetStringAndRelease(stringBuilder));
			if (this.spriteInAltasDict.ContainsKey(assetBundleName) && this.spriteAltasWithMaterialDict.ContainsKey(assetBundleName))
			{
				if (action != null)
				{
					action(new UnityEngine.Object[]
					{
						this.spriteInAltasDict[assetBundleName][text2],
						this.spriteAltasWithMaterialDict[assetBundleName]
					});
				}
				if (func != null)
				{
					func.Call(new object[]
					{
						new UnityEngine.Object[]
						{
							this.spriteInAltasDict[assetBundleName][text2],
							this.spriteAltasWithMaterialDict[assetBundleName]
						}
					});
					func.Dispose();
					func = null;
				}
			}
			else
			{
				this.LoadAsset<Sprite>(assetBundleName, new string[]
				{
					text3,
					text2
				}, action, func);
			}
		}

		[NoToLua]
		public void LoadAudio(string path, Action<UnityEngine.Object[]> action)
		{
			if (string.IsNullOrEmpty(path))
			{
				return;
			}
			path = path.Substring(0, path.LastIndexOf('.'));
			string assetBundleName = Util.GetAssetBundleName(path);
			string text = path.Substring(path.LastIndexOf('/') + 1);
			this.LoadAsset<AudioClip>(assetBundleName, new string[]
			{
				text
			}, action, null);
		}

		private string GetRealAssetPath(string abName)
		{
			if (abName.Equals("bundles"))
			{
				return abName;
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.Append(abName.ToLower());
			if (!abName.EndsWith(".unity3d"))
			{
				stringBuilder.Append(".unity3d");
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		private void LoadAsset<T>(string abName, string[] assetNames, Action<UnityEngine.Object[]> action = null, LuaFunction func = null) where T : UnityEngine.Object
		{
			abName = this.GetRealAssetPath(abName);
			if (abName == null)
			{
				func.Dispose();
				func = null;
				return;
			}
			ResourceManager.AssetBundleInfo loadedAssetBundle = this.GetLoadedAssetBundle(abName);
			if (loadedAssetBundle != null && (loadedAssetBundle.asset != null || loadedAssetBundle.assets != null))
			{
				if (action != null || func != null)
				{
					loadedAssetBundle.m_ReferencedCount++;
				}
				UnityEngine.Object @object = loadedAssetBundle.asset;
				if (abName.Equals("effects_alleffects.unity3d") && assetNames.Length > 0 && loadedAssetBundle.assets.ContainsKey(assetNames[0]))
				{
					@object = loadedAssetBundle.assets[assetNames[0]];
				}
				if (action != null)
				{
					action(new UnityEngine.Object[]
					{
						@object
					});
					action = null;
				}
				if (func != null)
				{
					func.Call(new object[]
					{
						@object
					});
					func.Dispose();
					func = null;
				}
			}
			else
			{
				ResourceManager.LoadAssetRequest loadAssetRequest = new ResourceManager.LoadAssetRequest();
				loadAssetRequest.assetType = typeof(T);
				loadAssetRequest.assetNames = assetNames;
				loadAssetRequest.luaFunc = func;
				loadAssetRequest.sharpFunc = action;
				List<ResourceManager.LoadAssetRequest> list = null;
				if (!this.m_LoadRequests.TryGetValue(abName, out list))
				{
					list = new List<ResourceManager.LoadAssetRequest>();
					list.Add(loadAssetRequest);
					this.m_LoadRequests.Add(abName, list);
					base.StartCoroutine(this.OnLoadAsset<T>(abName));
				}
				else
				{
					list.Add(loadAssetRequest);
				}
			}
		}

		[DebuggerHidden]
		private IEnumerator OnLoadAsset<T>(string abName) where T : UnityEngine.Object
		{
			ResourceManager.<OnLoadAsset>c__Iterator10<T> <OnLoadAsset>c__Iterator = new ResourceManager.<OnLoadAsset>c__Iterator10<T>();
			<OnLoadAsset>c__Iterator.abName = abName;
			<OnLoadAsset>c__Iterator.<$>abName = abName;
			<OnLoadAsset>c__Iterator.<>f__this = this;
			return <OnLoadAsset>c__Iterator;
		}

		private string GetABUrl(string abName)
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.AppendFormat("{0}{1}/{2}", (!this.dictExistBundlesName.ContainsKey(abName)) ? this.m_InDownloadingURL : this.m_OutDownloadingURL, "bundles", abName);
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		[DebuggerHidden]
		private IEnumerator OnLoadAssetBundle(string abName)
		{
			ResourceManager.<OnLoadAssetBundle>c__Iterator11 <OnLoadAssetBundle>c__Iterator = new ResourceManager.<OnLoadAssetBundle>c__Iterator11();
			<OnLoadAssetBundle>c__Iterator.abName = abName;
			<OnLoadAssetBundle>c__Iterator.<$>abName = abName;
			<OnLoadAssetBundle>c__Iterator.<>f__this = this;
			return <OnLoadAssetBundle>c__Iterator;
		}

		[DebuggerHidden]
		private IEnumerator OnLoadAssetBundle(string abName, Type type)
		{
			ResourceManager.<OnLoadAssetBundle>c__Iterator12 <OnLoadAssetBundle>c__Iterator = new ResourceManager.<OnLoadAssetBundle>c__Iterator12();
			<OnLoadAssetBundle>c__Iterator.abName = abName;
			<OnLoadAssetBundle>c__Iterator.type = type;
			<OnLoadAssetBundle>c__Iterator.<$>abName = abName;
			<OnLoadAssetBundle>c__Iterator.<$>type = type;
			<OnLoadAssetBundle>c__Iterator.<>f__this = this;
			return <OnLoadAssetBundle>c__Iterator;
		}

		private ResourceManager.AssetBundleInfo GetLoadedAssetBundle(string abName)
		{
			ResourceManager.AssetBundleInfo assetBundleInfo = null;
			this.m_LoadedAssetBundles.TryGetValue(abName, out assetBundleInfo);
			if (assetBundleInfo == null)
			{
				return null;
			}
			string[] array = null;
			if (!this.m_Dependencies.TryGetValue(abName, out array))
			{
				return assetBundleInfo;
			}
			for (int i = 0; i < array.Length; i++)
			{
				ResourceManager.AssetBundleInfo assetBundleInfo2;
				this.m_LoadedAssetBundles.TryGetValue(array[i], out assetBundleInfo2);
				if (assetBundleInfo2 == null)
				{
					return null;
				}
			}
			return assetBundleInfo;
		}

		[NoToLua]
		public void UnloadAssetBundleWithoutDependencies(string abName)
		{
			abName = this.GetRealAssetPath(abName);
			if (abName == null)
			{
				return;
			}
			ResourceManager.AssetBundleInfo loadedAssetBundle = this.GetLoadedAssetBundle(abName);
			if (loadedAssetBundle == null)
			{
				return;
			}
			if (loadedAssetBundle.m_AssetBundle != null)
			{
				loadedAssetBundle.m_AssetBundle.Unload(false);
				loadedAssetBundle.m_AssetBundle = null;
			}
		}

		public void UnloadAssetBundle(string abName, bool abUnload, bool ignoreReferencedCount = false)
		{
			abName = this.GetRealAssetPath(abName);
			if (abName == null)
			{
				return;
			}
			if (this.UnloadAssetBundleInternal(abName, abUnload, ignoreReferencedCount))
			{
				this.UnloadDependencies(abName, abUnload, ignoreReferencedCount);
			}
		}

		private void UnloadDependencies(string abName, bool abUnload, bool ignoreReferencedCount)
		{
			string[] array = null;
			if (!this.m_Dependencies.TryGetValue(abName, out array))
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = this.UnloadAssetBundleInternal(array[i], abUnload, ignoreReferencedCount);
				if (flag && this.m_Dependencies.ContainsKey(array[i]))
				{
					this.UnloadDependencies(array[i], abUnload, ignoreReferencedCount);
				}
			}
			this.m_Dependencies.Remove(abName);
		}

		private bool UnloadAssetBundleInternal(string abName, bool abUnload, bool ignoreReferencedCount)
		{
			ResourceManager.AssetBundleInfo loadedAssetBundle = this.GetLoadedAssetBundle(abName);
			if (loadedAssetBundle == null)
			{
				return true;
			}
			if (--loadedAssetBundle.m_ReferencedCount > 0 && !ignoreReferencedCount)
			{
				return false;
			}
			if (!ignoreReferencedCount && this.m_LoadRequests.ContainsKey(abName))
			{
				return false;
			}
			if (abUnload && loadedAssetBundle.asset != null)
			{
				UnityEngine.Object.DestroyImmediate(loadedAssetBundle.asset, true);
			}
			if (loadedAssetBundle.m_AssetBundle != null)
			{
				loadedAssetBundle.m_AssetBundle.Unload(abUnload);
			}
			if (loadedAssetBundle.assets != null)
			{
				loadedAssetBundle.assets.Clear();
				loadedAssetBundle.assets = null;
			}
			this.m_LoadedAssetBundles.Remove(abName);
			return true;
		}
	}
}
