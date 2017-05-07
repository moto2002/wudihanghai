using LuaInterface;
using MarchingBytes;
using System;
using UGUITweener;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LuaFramework
{
	public class PrefabLoader : Manager
	{
		private Transform parent;

		private bool isPlayAnimation;

		private EasyObjectPool easyObjectPool;

		private EventSystem eventSystem;

		public Transform Parent
		{
			get
			{
				if (this.parent == null)
				{
					GameObject gameObject = GameObject.FindWithTag("GuiCamera");
					if (gameObject != null)
					{
						this.parent = gameObject.transform;
					}
				}
				return this.parent;
			}
		}

		private EasyObjectPool EasyObjectPool
		{
			get
			{
				if (this.easyObjectPool == null)
				{
					this.easyObjectPool = GameObject.Find("EasyObjectPool").GetComponent<EasyObjectPool>();
				}
				return this.easyObjectPool;
			}
		}

		[NoToLua]
		public EventSystem GetEventSystem
		{
			get
			{
				if (this.eventSystem == null)
				{
					this.eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
				}
				return this.eventSystem;
			}
		}

		public void LoadMainCanvas(LuaFunction func)
		{
			base.ResManager.LoadPrefab("UIPrefabs/Login/MainCanvas", delegate(UnityEngine.Object[] objs)
			{
				if (objs.Length == 0)
				{
					return;
				}
				GameObject gameObject = objs[0] as GameObject;
				gameObject = UnityEngine.Object.Instantiate<GameObject>(gameObject);
				gameObject.name = gameObject.name.Replace("(Clone)", string.Empty);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = Vector3.one * 1000f;
				gameObject.AddComponent<LuaBehaviour>().assetbundleName = Util.GetAssetBundleName("UIPrefabs/Login/MainCanvas");
				if (func != null)
				{
					func.Call(new object[]
					{
						gameObject
					});
					func.Dispose();
					func = null;
				}
				string assetBundleName = Util.GetAssetBundleName("UIPrefabs/Login/MainCanvas");
				this.ResManager.UnloadAssetBundleWithoutDependencies(assetBundleName);
			});
		}

		private string checkNameInPeers(Transform parent, string strName)
		{
			if (parent == null)
			{
				return strName;
			}
			if (parent.FindChild(strName) == null)
			{
				return strName;
			}
			int num = 1;
			while (!(parent.FindChild(string.Format("{0}_{1}", strName, num)) == null))
			{
				num++;
			}
			return string.Format("{0}_{1}", strName, num);
		}

		public bool IsPlayAnimation()
		{
			return this.isPlayAnimation;
		}

		public void SetIsPlayAnimation(bool isPlay)
		{
			this.isPlayAnimation = isPlay;
		}

		public void CreateUIPrefab(string name, string parentName, string nameInScene, string layerName, LuaFunction func)
		{
			base.ResManager.LoadPrefab(name, delegate(UnityEngine.Object[] objs)
			{
				if (objs.Length == 0)
				{
					return;
				}
				GameObject gameObject = objs[0] as GameObject;
				gameObject = UnityEngine.Object.Instantiate<GameObject>(gameObject);
				if (!string.IsNullOrEmpty(parentName))
				{
					string text = "MainCanvas/GuiCamera";
					if (parentName.Equals(text))
					{
						gameObject.transform.SetParent(this.Parent);
					}
					else if (parentName.StartsWith(text))
					{
						gameObject.transform.SetParent(this.Parent.FindChild(parentName.Substring(text.Length + 1)));
					}
				}
				if (!string.IsNullOrEmpty(layerName))
				{
					Util.SetLayer(gameObject, layerName);
				}
				string text2 = gameObject.name;
				if (string.IsNullOrEmpty(nameInScene))
				{
					text2 = text2.Replace("(Clone)", string.Empty);
				}
				else
				{
					text2 = nameInScene;
				}
				gameObject.name = this.checkNameInPeers(gameObject.transform.parent, text2);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = Vector3.zero;
				if (gameObject.transform as RectTransform)
				{
					((RectTransform)gameObject.transform).offsetMin = Vector2.zero;
					((RectTransform)gameObject.transform).offsetMax = Vector2.zero;
				}
				if (name.StartsWith("Effects/"))
				{
					gameObject.AddComponent<LuaBehaviour>().assetbundleName = Util.GetAssetBundleName("Effects/allEffects");
				}
				else
				{
					gameObject.AddComponent<LuaBehaviour>().assetbundleName = Util.GetAssetBundleName(name);
				}
				UITweener component = gameObject.GetComponent<TweenScale>();
				if (component != null && component.enabled)
				{
					this.isPlayAnimation = true;
					component.SetOnFinished(delegate
					{
						this.isPlayAnimation = false;
					});
				}
				if (func != null)
				{
					func.Call(new object[]
					{
						gameObject
					});
					func.Dispose();
					func = null;
				}
				string assetBundleName = Util.GetAssetBundleName(name);
				if (name.StartsWith("Effects/"))
				{
					assetBundleName = Util.GetAssetBundleName("Effects/allEffects");
				}
				this.ResManager.UnloadAssetBundleWithoutDependencies(assetBundleName);
			});
		}

		public void CreateHeroPrefab(string name, string parentName, string nameInScene, string layerName, bool removeBoxCollider, LuaFunction func)
		{
			base.ResManager.LoadPrefab(name, delegate(UnityEngine.Object[] objs)
			{
				if (objs.Length == 0)
				{
					return;
				}
				GameObject gameObject = objs[0] as GameObject;
				gameObject = UnityEngine.Object.Instantiate<GameObject>(gameObject);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.position = Vector3.one * 10000f;
				if (!string.IsNullOrEmpty(parentName))
				{
					gameObject.transform.SetParent(GameObject.Find(parentName).transform);
				}
				if (!string.IsNullOrEmpty(layerName))
				{
					Util.SetLayer(gameObject, layerName);
				}
				if (string.IsNullOrEmpty(nameInScene))
				{
					gameObject.name = gameObject.name.Replace("(Clone)", string.Empty);
				}
				else
				{
					gameObject.name = nameInScene;
				}
				gameObject.AddComponent<LuaBehaviour>().assetbundleName = Util.GetAssetBundleName(name);
				if (removeBoxCollider)
				{
					UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
					Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
					componentInChildren.SetTrigger("xingzou");
				}
				if (func != null)
				{
					func.Call(new object[]
					{
						gameObject
					});
					func.Dispose();
					func = null;
				}
				string assetBundleName = Util.GetAssetBundleName(name);
				this.ResManager.UnloadAssetBundleWithoutDependencies(assetBundleName);
			});
		}

		public void CloseUIPrefab(string name)
		{
			GameObject gameObject = GameObject.Find("ImgBgCanvas/ImgBgCamera");
			if (gameObject != null && gameObject.GetComponent<AppView>() != null)
			{
				UnityEngine.Object.Destroy(gameObject.GetComponent<AppView>());
			}
		}

		public void InitScrollView(GameObject go, int count, string cellName, int focusIndex = -1)
		{
			LoopScrollRect component = go.GetComponent<LoopScrollRect>();
			if (component != null)
			{
				component.prefabPool = this.EasyObjectPool;
				component.SetPrefabToPool(cellName);
				component.ClearCells();
				component.totalCount = count;
				component.focusIndex = focusIndex;
			}
		}

		public void ChangeScrollViewCount(GameObject go, int num)
		{
			LoopScrollRect component = go.GetComponent<LoopScrollRect>();
			if (component != null)
			{
				component.totalCount = Math.Max(0, component.totalCount + num);
			}
		}

		public void ScrollViewFocusOn(GameObject go, int index, LuaFunction func)
		{
			LoopScrollRect component = go.GetComponent<LoopScrollRect>();
			if (component != null)
			{
				component.FocusOnByIndex(index, delegate(RectTransform target)
				{
					if (func != null)
					{
						func.Call(new object[]
						{
							target
						});
						func.Dispose();
						func = null;
					}
				});
			}
		}
	}
}
