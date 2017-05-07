using Hummingbird.SeaBattle.Controller.CameraControll;
using Hummingbird.SeaBattle.Utility.Platform;
using LuaInterface;
using MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Water;

namespace LuaFramework
{
	public class Util
	{
		private static List<string> luaPaths = new List<string>();

		private static Dictionary<string, object> description = null;

		public static string DataPath
		{
			get
			{
				StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
				string text = "SeaBattle".ToLower();
				if (Application.isMobilePlatform)
				{
					stringBuilder.AppendFormat("{0}/{1}/", Application.persistentDataPath, text);
					return StringBuilderCache.GetStringAndRelease(stringBuilder);
				}
				if (Application.platform == RuntimePlatform.WindowsEditor)
				{
					stringBuilder.AppendFormat("c:/{0}/", text);
				}
				else
				{
					stringBuilder.AppendFormat("{0}/{1}/", Application.persistentDataPath, text);
				}
				return StringBuilderCache.GetStringAndRelease(stringBuilder);
			}
		}

		public static bool NetAvailable
		{
			get
			{
				return Application.internetReachability != NetworkReachability.NotReachable;
			}
		}

		public static bool IsWifi
		{
			get
			{
				return Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
			}
		}

		[NoToLua]
		public static int Int(object o)
		{
			return Convert.ToInt32(o);
		}

		[NoToLua]
		public static float Float(object o)
		{
			return (float)Math.Round((double)Convert.ToSingle(o), 2);
		}

		[NoToLua]
		public static long Long(object o)
		{
			return Convert.ToInt64(o);
		}

		public static int Random(int min, int max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static float Random(float min, float max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static long GetTime()
		{
			long arg_27_0 = DateTime.UtcNow.Ticks;
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
			TimeSpan timeSpan = new TimeSpan(arg_27_0 - dateTime.Ticks);
			return (long)timeSpan.TotalMilliseconds;
		}

		public static void OpenWebView(string url, Rect viewRect, Action<bool> completeCallback)
		{
			Debug.Log("OpenWebView:" + url);
			PlatformUtil.GetInstance().OpenWebView(url, viewRect, completeCallback);
		}

		public static void OpenWebViewWithLocalFile(string filename, Rect viewRect, Action<bool> completeCallback)
		{
			string text = Util.DataPath + filename;
			if (Application.platform == RuntimePlatform.Android)
			{
				text = "file:///" + text;
			}
			PlatformUtil.GetInstance().OpenWebView(text, viewRect, completeCallback);
		}

		public static void CloseWebView()
		{
			PlatformUtil.GetInstance().CloseWebView();
		}

		public static void SetUIDragDropEvent(GameObject go, object param, LuaFunction luafunc)
		{
			UIDrag uIDrag = go.GetComponent<UIDrag>();
			if (uIDrag == null)
			{
				uIDrag = go.AddComponent<UIDrag>();
			}
			if (uIDrag != null)
			{
				uIDrag.param = param;
			}
			UIDrop uIDrop = go.GetComponent<UIDrop>();
			if (uIDrop == null)
			{
				uIDrop = go.AddComponent<UIDrop>();
			}
			if (uIDrop != null)
			{
				uIDrop.param = param;
				uIDrop.callback = delegate(object dragParam, object dropParam)
				{
					luafunc.Call(new object[]
					{
						dragParam,
						dropParam
					});
				};
			}
		}

		public static T Get<T>(GameObject go, string subnode) where T : Component
		{
			if (go != null)
			{
				Transform transform = go.transform.FindChild(subnode);
				if (transform != null)
				{
					return transform.GetComponent<T>();
				}
			}
			return (T)((object)null);
		}

		public static T Get<T>(Transform go, string subnode) where T : Component
		{
			if (go != null)
			{
				Transform transform = go.FindChild(subnode);
				if (transform != null)
				{
					return transform.GetComponent<T>();
				}
			}
			return (T)((object)null);
		}

		public static T Get<T>(Component go, string subnode) where T : Component
		{
			return go.transform.FindChild(subnode).GetComponent<T>();
		}

		public static T Add<T>(GameObject go) where T : Component
		{
			if (go != null)
			{
				T[] components = go.GetComponents<T>();
				for (int i = 0; i < components.Length; i++)
				{
					if (components[i] != null)
					{
						UnityEngine.Object.Destroy(components[i]);
					}
				}
				return go.gameObject.AddComponent<T>();
			}
			return (T)((object)null);
		}

		public static T Add<T>(Transform go) where T : Component
		{
			return Util.Add<T>(go.gameObject);
		}

		public static void SetUIColor(GameObject go, int r, int g, int b, int a)
		{
			Color colorWith255Int = Util.GetColorWith255Int(r, g, b, a);
			Graphic[] componentsInChildren = go.GetComponentsInChildren<Graphic>(true);
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				componentsInChildren[i].color = colorWith255Int;
				i++;
			}
		}

		[NoToLua]
		public static Color GetColorWith255Int(int r, int g, int b, int a)
		{
			return new Color((float)r / 255f, (float)g / 255f, (float)b / 255f, (float)a / 255f);
		}

		public static GameObject Child(GameObject go, string subnode)
		{
			return Util.Child(go.transform, subnode);
		}

		public static GameObject Child(Transform go, string subnode)
		{
			Transform transform = go.FindChild(subnode);
			if (transform == null)
			{
				return null;
			}
			return transform.gameObject;
		}

		public static GameObject Peer(GameObject go, string subnode)
		{
			return Util.Peer(go.transform, subnode);
		}

		public static GameObject Peer(Transform go, string subnode)
		{
			Transform transform = go.parent.FindChild(subnode);
			if (transform == null)
			{
				return null;
			}
			return transform.gameObject;
		}

		public static string md5(string source)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = Encoding.UTF8.GetBytes(source);
			byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes, 0, bytes.Length);
			mD5CryptoServiceProvider.Clear();
			string text = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				text += Convert.ToString(array[i], 16).PadLeft(2, '0');
			}
			return text.PadLeft(32, '0');
		}

		public static string md5file(string file)
		{
			string result;
			try
			{
				FileStream fileStream = new FileStream(file, FileMode.Open);
				MD5 mD = new MD5CryptoServiceProvider();
				byte[] array = mD.ComputeHash(fileStream);
				fileStream.Close();
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(array[i].ToString("x2"));
				}
				result = stringBuilder.ToString();
			}
			catch (Exception ex)
			{
				throw new Exception("md5file() fail, error:" + ex.Message);
			}
			return result;
		}

		public static void ClearChild(Transform go)
		{
			if (go == null)
			{
				return;
			}
			for (int i = go.childCount - 1; i >= 0; i--)
			{
				UnityEngine.Object.Destroy(go.GetChild(i).gameObject);
			}
		}

		public static void ClearMemory()
		{
			GC.Collect();
			Resources.UnloadUnusedAssets();
			LuaManager manager = AppFacade.Instance.GetManager<LuaManager>("LuaManager");
			if (manager != null)
			{
				manager.LuaGC();
			}
		}

		public static string GetRelativePath()
		{
			if (Application.isEditor)
			{
				return "file:///" + Util.DataPath;
			}
			if (Application.isMobilePlatform || Application.isConsolePlatform)
			{
				return "file:///" + Util.DataPath;
			}
			return "file://" + Application.streamingAssetsPath + "/";
		}

		[NoToLua]
		public static string GetStreamingAssetsPath()
		{
			if (Application.isEditor)
			{
				return "file://" + Application.streamingAssetsPath + "/";
			}
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				return "file:///" + Application.dataPath + "/Raw/";
			}
			return Application.streamingAssetsPath + "/";
		}

		public static string GetFileText(string path)
		{
			return File.ReadAllText(path);
		}

		public static string AppContentPath()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			switch (Application.platform)
			{
			case RuntimePlatform.IPhonePlayer:
				stringBuilder.AppendFormat("{0}/Raw/", Application.dataPath);
				goto IL_75;
			case RuntimePlatform.Android:
				stringBuilder.AppendFormat("jar:file://{0}!/assets/", Application.dataPath);
				goto IL_75;
			}
			stringBuilder.AppendFormat("{0}/{1}/", Application.dataPath, "StreamingAssets");
			IL_75:
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public static void Log(string str)
		{
			Debug.Log(str);
		}

		public static void LogWarning(string str)
		{
			Debug.LogWarning(str);
		}

		public static void LogError(string str)
		{
			Debug.LogError(str);
		}

		public static object[] CallMethod(string module, string func, params object[] args)
		{
			LuaManager manager = AppFacade.Instance.GetManager<LuaManager>("LuaManager");
			if (manager == null)
			{
				return null;
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.AppendFormat("{0}.{1}", module, func);
			return manager.CallFunction(StringBuilderCache.GetStringAndRelease(stringBuilder), args);
		}

		public static string GetKey(string key)
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.AppendFormat("{0}{1}_{2}", "SeaBattle_", AppConst.UserId, key);
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public static int GetInt(string key)
		{
			string key2 = Util.GetKey(key);
			return PlayerPrefs.GetInt(key2);
		}

		public static bool HasKey(string key)
		{
			string key2 = Util.GetKey(key);
			return PlayerPrefs.HasKey(key2);
		}

		public static void SetInt(string key, int value)
		{
			string key2 = Util.GetKey(key);
			PlayerPrefs.DeleteKey(key2);
			PlayerPrefs.SetInt(key2, value);
			PlayerPrefs.Save();
		}

		public static string GetString(string key)
		{
			string key2 = Util.GetKey(key);
			return PlayerPrefs.GetString(key2);
		}

		public static void SetString(string key, string value)
		{
			string key2 = Util.GetKey(key);
			PlayerPrefs.DeleteKey(key2);
			PlayerPrefs.SetString(key2, value);
			PlayerPrefs.Save();
		}

		public static void RemoveData(string key)
		{
			string key2 = Util.GetKey(key);
			PlayerPrefs.DeleteKey(key2);
		}

		public static void ReadGameVersionInfo()
		{
			if (Util.HasKey("dhh_version"))
			{
				string @string = Util.GetString("dhh_version");
				string[] array = @string.Split(new char[]
				{
					'|'
				});
				if (array.Length >= 2)
				{
					int num = Convert.ToInt32(array[0]);
					int appVersionCode = PlatformUtil.GetInstance().GetAppVersionCode();
					AppConst.GameVerCode = Mathf.Max(num, appVersionCode);
					if (appVersionCode > num)
					{
						AppConst.GameVerName = PlatformUtil.GetInstance().GetAppVersionName();
					}
					else
					{
						AppConst.GameVerName = array[1];
					}
				}
				else
				{
					AppConst.GameVerCode = PlatformUtil.GetInstance().GetAppVersionCode();
					AppConst.GameVerName = PlatformUtil.GetInstance().GetAppVersionName();
				}
			}
			else
			{
				AppConst.GameVerCode = PlatformUtil.GetInstance().GetAppVersionCode();
				AppConst.GameVerName = PlatformUtil.GetInstance().GetAppVersionName();
			}
		}

		public static string AppendTimestampForUri(string url)
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.Append(url);
			stringBuilder.Append((!url.Contains("?")) ? "?sbtimestamp=" : "&sbtimestamp=");
			stringBuilder.Append(DateTime.Now.ToString("yyyymmddhhmmss"));
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public static string GetAssetBundleName(string filePath)
		{
			int num = filePath.LastIndexOf('.');
			if (num != -1)
			{
				filePath = filePath.Substring(0, num);
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.Append(filePath.Replace('/', '_').ToLower());
			stringBuilder.Append(".unity3d");
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public static string GetPrefixInDownloadServer()
		{
			if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer)
			{
				return "ios";
			}
			if (Application.platform == RuntimePlatform.Android)
			{
				return "android";
			}
			return "windows";
		}

		[NoToLua]
		public static T FindInParents<T>(GameObject go, bool isIncludeSelf = true) where T : Component
		{
			if (go == null)
			{
				return (T)((object)null);
			}
			T t = (T)((object)null);
			if (isIncludeSelf)
			{
				t = go.GetComponent<T>();
				if (t != null)
				{
					return t;
				}
			}
			Transform parent = go.transform.parent;
			while (parent != null && t == null)
			{
				t = parent.gameObject.GetComponent<T>();
				parent = parent.parent;
			}
			return t;
		}

		public static void DecompressProtoData(byte[] buffer, LuaFunction luaFunc)
		{
			if (luaFunc != null)
			{
				byte[] buf = QuickLZ.decompress(buffer);
				luaFunc.Call(new object[]
				{
					new LuaByteBuffer(buf)
				});
				luaFunc.Dispose();
				luaFunc = null;
			}
		}

		public static void SetLayer(GameObject obj, string layerName)
		{
			obj.layer = LayerMask.NameToLayer(layerName);
			for (int i = 0; i < obj.transform.childCount; i++)
			{
				Util.SetLayer(obj.transform.GetChild(i).gameObject, layerName);
			}
		}

		public static void UpdateModelShader(GameObject go, string shaderName)
		{
			if (go == null || string.IsNullOrEmpty(shaderName))
			{
				return;
			}
			Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].material.shader = Shader.Find(shaderName);
			}
		}

		public static void ShakeScreenEffect(GameObject go, bool isShakeCamera, float shakeTime, float shakeDelta)
		{
			ShakeCamera shakeCamera;
			if (!isShakeCamera)
			{
				Transform parent = LuaHelper.GetPrefabLoader().Parent;
				shakeCamera = parent.GetComponent<ShakeCamera>();
				if (shakeCamera == null)
				{
					shakeCamera = parent.gameObject.AddComponent<ShakeCamera>();
				}
			}
			else
			{
				shakeCamera = go.GetComponent<ShakeCamera>();
				if (shakeCamera == null)
				{
					shakeCamera = go.AddComponent<ShakeCamera>();
				}
			}
			shakeCamera.SetShakeParams(isShakeCamera, shakeTime, shakeDelta);
		}

		public static void SetAnimationTrigger(GameObject go, string name)
		{
			if (go == null)
			{
				return;
			}
			Animator componentInChildren = go.GetComponentInChildren<Animator>();
			if (componentInChildren != null)
			{
				if (!componentInChildren.enabled)
				{
					componentInChildren.enabled = true;
				}
				componentInChildren.SetTrigger(name);
			}
		}

		public static void SetAnimationClip(GameObject go, string name)
		{
			if (go == null)
			{
				return;
			}
			Animation componentInChildren = go.GetComponentInChildren<Animation>();
			if (componentInChildren != null)
			{
				if (!componentInChildren.enabled)
				{
					componentInChildren.enabled = true;
				}
				componentInChildren.Play(name);
			}
		}

		public static void SetAnimationClipSpeed(GameObject go, string name, float speed)
		{
			if (go == null)
			{
				return;
			}
			Animation componentInChildren = go.GetComponentInChildren<Animation>();
			if (componentInChildren != null)
			{
				if (!componentInChildren.enabled)
				{
					componentInChildren.enabled = true;
				}
				componentInChildren[name].speed = speed;
			}
		}

		public static void SetCanTouch(bool isEnabled)
		{
			LuaHelper.GetPrefabLoader().GetEventSystem.enabled = isEnabled;
		}

		public static bool GetCanTouch()
		{
			return LuaHelper.GetPrefabLoader().GetEventSystem.enabled;
		}

		public static void ScreenPointToRay(Camera camera, Vector2 position, LuaFunction luafunc)
		{
			Vector3 position2 = Vector3.right * position.x + Vector3.up * position.y;
			Ray ray = camera.ScreenPointToRay(position2);
			LayerMask mask = camera.cullingMask;
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit, float.PositiveInfinity, mask) && raycastHit.transform != null && luafunc != null)
			{
				luafunc.Call(new object[]
				{
					raycastHit.transform.name
				});
				luafunc.Dispose();
				luafunc = null;
			}
		}

		public static void ChangeMainSceneWater4Material(GameObject Water4GObj, int index)
		{
			if (Water4GObj && Water4GObj.GetComponent<WaterBase>() != null)
			{
				Water4GObj.GetComponent<WaterBase>().ChangeSharedMaterial(index);
			}
		}

		public static void SetUIElementCanvasGroupAlpha(GameObject go, float alpha)
		{
			CanvasGroup canvasGroup = go.GetComponent<CanvasGroup>();
			if (canvasGroup == null)
			{
				canvasGroup = go.AddComponent<CanvasGroup>();
			}
			canvasGroup.alpha = alpha;
		}

		public static string GetXGPushToken()
		{
			return PlatformUtil.GetInstance().GetXGPushToken();
		}

		public static string GetPlatformName()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				return "Android";
			}
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				return "IPhonePlayer";
			}
			return "WindowsPlayer";
		}

		public static GameObject GetCombineMeshGObj(GameObject[] beCombines)
		{
			GameObject gameObject = new GameObject("NewCombineMesh", new Type[]
			{
				typeof(MeshFilter),
				typeof(MeshRenderer)
			});
			gameObject.transform.position = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			MeshFilter component = gameObject.GetComponent<MeshFilter>();
			MeshRenderer component2 = gameObject.GetComponent<MeshRenderer>();
			if (beCombines != null && beCombines.Length > 0)
			{
				component.sharedMesh = new Mesh();
				List<CombineInstance> list = new List<CombineInstance>();
				for (int i = 0; i < beCombines.Length; i++)
				{
					MeshFilter component3 = beCombines[i].GetComponent<MeshFilter>();
					MeshRenderer component4 = beCombines[i].GetComponent<MeshRenderer>();
					if (i == 0 && component4 != null)
					{
						component2.lightmapIndex = component4.lightmapIndex;
						component2.sharedMaterial = component4.sharedMaterial;
					}
					if (component3 != null && component3.sharedMesh != null)
					{
						CombineInstance item = default(CombineInstance);
						if (component3.sharedMesh.uv2 != null && component3.sharedMesh.uv2.Length > 0 && component4 != null)
						{
							item.mesh = UnityEngine.Object.Instantiate<Mesh>(component3.sharedMesh);
							Vector2[] uv = item.mesh.uv2;
							Vector2 vector = Vector2.right * component4.lightmapScaleOffset.x + Vector2.up * component4.lightmapScaleOffset.y;
							Vector2 a = Vector2.right * component4.lightmapScaleOffset.z + Vector2.up * component4.lightmapScaleOffset.w;
							for (int j = 0; j < uv.Length; j++)
							{
								uv[j] = a + Vector2.right * (vector.x * uv[j].x) + Vector2.up * (vector.y * uv[j].y);
							}
							item.mesh.uv2 = uv;
						}
						else
						{
							item.mesh = component3.sharedMesh;
						}
						item.transform = component3.transform.localToWorldMatrix;
						list.Add(item);
					}
				}
				if (list.Count > 0)
				{
					component.sharedMesh.CombineMeshes(list.ToArray());
				}
			}
			else
			{
				Debug.LogError("beCombines is null");
			}
			return gameObject;
		}

		public static bool GameObjectIsNull(GameObject gObj)
		{
			return !gObj;
		}

		[NoToLua]
		public static string GetDesConfig(string key)
		{
			if (Util.description == null)
			{
				string path = "Config/Strings";
				TextAsset textAsset = Resources.Load(path, typeof(TextAsset)) as TextAsset;
				Util.description = (Json.Deserialize(textAsset.text) as Dictionary<string, object>);
			}
			string result = string.Empty;
			if (Util.description.ContainsKey(key))
			{
				result = Convert.ToString(Util.description[key]);
			}
			return result;
		}
	}
}
