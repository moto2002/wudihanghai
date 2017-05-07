using Hummingbird.SeaBattle.Controller.UGUIInputControll;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LuaFramework
{
	public class LuaBehaviour : View
	{
		private List<LuaFunction> luaFuncList = new List<LuaFunction>();

		private LuaFunction luaFuncAnimFrameEvent;

		[NoToLua]
		public string assetbundleName;

		private bool bGongjiState;

		private string strGongjiName = "gongji";

		private static bool isOnClick;

		private Material grayMat;

		private Dictionary<Image, Material> genETCMat;

		private Dictionary<Image, bool> imageGrayOrNot;

		private Shader grayShader;

		protected void OnClick()
		{
			Util.CallMethod(base.name, "OnClick", new object[0]);
		}

		protected void OnClickEvent(GameObject go)
		{
			Util.CallMethod(base.name, "OnClick", new object[]
			{
				go
			});
		}

		public void AddClick(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.luaFuncList.Add(luafunc);
			Button component = go.GetComponent<Button>();
			component.onClick.RemoveAllListeners();
			component.onClick.AddListener(delegate
			{
				bool flag = Input.touchCount == 1;
				if (flag)
				{
					if (LuaBehaviour.isOnClick)
					{
						return;
					}
					LuaBehaviour.isOnClick = true;
					AppFacade.Instance.GetManager<GameManager>("GameManager").StartCoroutine(this.endFrameClick());
					this.SoundManager.PlayActionSound("Audios/sound_click_on.ogg", true);
					luafunc.Call(new object[]
					{
						go
					});
				}
			});
		}

		[DebuggerHidden]
		private IEnumerator endFrameClick()
		{
			return new LuaBehaviour.<endFrameClick>c__Iterator1();
		}

		public void AddClick(Transform transform, LuaFunction luafunc)
		{
			this.AddClick(transform.gameObject, luafunc);
		}

		public void AddToggleClick(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.luaFuncList.Add(luafunc);
			Toggle component = go.GetComponent<Toggle>();
			component.onValueChanged.RemoveAllListeners();
			component.onValueChanged.AddListener(delegate(bool isOn)
			{
				bool flag = Input.touchCount == 1 || Input.touchCount == 0;
				if (flag)
				{
					luafunc.Call(new object[]
					{
						go,
						isOn
					});
					if (isOn)
					{
						this.SoundManager.PlayActionSound("Audios/sound_click_on.ogg", true);
					}
				}
			});
		}

		public void AddToggleClick(Transform transform, LuaFunction luafunc)
		{
			this.AddToggleClick(transform.gameObject, luafunc);
		}

		public void AddLongPressClick(GameObject go, LuaFunction longPressLuaFunc, LuaFunction clickLuaFunc = null, float delayTime = 1f)
		{
			if (go == null)
			{
				return;
			}
			if (longPressLuaFunc != null)
			{
				this.luaFuncList.Add(longPressLuaFunc);
			}
			if (clickLuaFunc != null)
			{
				this.luaFuncList.Add(clickLuaFunc);
			}
			UILongPressButton uILongPressButton = go.GetComponent<UILongPressButton>();
			if (uILongPressButton == null)
			{
				uILongPressButton = go.AddComponent<UILongPressButton>();
			}
			if (uILongPressButton != null)
			{
				uILongPressButton.SetLongPress(delayTime, delegate(object o)
				{
					if (longPressLuaFunc != null)
					{
						longPressLuaFunc.Call();
					}
				}, delegate(object o)
				{
					if (clickLuaFunc != null)
					{
						clickLuaFunc.Call();
					}
				});
			}
		}

		public void AddSliderOnValueChanged(Slider slider, LuaFunction luafunc)
		{
			if (slider == null || luafunc == null)
			{
				return;
			}
			this.luaFuncList.Add(luafunc);
			slider.onValueChanged.AddListener(delegate(float _value)
			{
				luafunc.Call(new object[]
				{
					_value
				});
			});
		}

		public void AddInputFieldEditEvent(InputField input, LuaFunction luafunc)
		{
			this.luaFuncList.Add(luafunc);
			input.onEndEdit.AddListener(delegate(string inputText)
			{
				luafunc.Call(new object[]
				{
					inputText
				});
			});
		}

		public void AddDragEnd(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.luaFuncList.Add(luafunc);
			EventListener.Get(go).onEndDrag = delegate(float deltaX, float deltaY)
			{
				luafunc.Call(new object[]
				{
					deltaX,
					deltaY
				});
			};
		}

		public void AddDragEvent(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.luaFuncList.Add(luafunc);
			EventListener.Get(go).onDrag = delegate(Vector2 delta)
			{
				luafunc.Call(new object[]
				{
					delta.x,
					delta.y
				});
			};
		}

		public void AddClickEvent(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.luaFuncList.Add(luafunc);
			EventListener.Get(go).onClick = delegate(GameObject obj, Vector2 pos)
			{
				bool flag = Input.touchCount == 1;
				if (flag)
				{
					luafunc.Call(new object[]
					{
						obj,
						pos
					});
				}
			};
		}

		public void AddHandleUIInputEvent(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			HandleUGUIInput component = go.GetComponent<HandleUGUIInput>();
			if (component)
			{
				this.luaFuncList.Add(luafunc);
				component.AddTouchScreen(luafunc);
			}
		}

		public void ClearClick()
		{
			for (int i = 0; i < this.luaFuncList.Count; i++)
			{
				if (this.luaFuncList[i] != null)
				{
					this.luaFuncList[i].Dispose();
					this.luaFuncList[i] = null;
				}
			}
			this.luaFuncList.Clear();
		}

		public void ImageGray(Image image, bool grayOrNot)
		{
			if (image)
			{
				if (grayOrNot)
				{
					if (this.grayShader == null)
					{
						this.grayShader = Shader.Find("OnlyloveShader/Gray");
					}
					if (this.grayMat == null)
					{
						this.grayMat = new Material(this.grayShader);
					}
					if (this.genETCMat == null)
					{
						this.genETCMat = new Dictionary<Image, Material>();
					}
					if (this.imageGrayOrNot == null)
					{
						this.imageGrayOrNot = new Dictionary<Image, bool>();
					}
					this.imageGrayOrNot[image] = true;
					UnityAction unityAction = delegate
					{
						if (image != null)
						{
							if (image.material != null && image.material.shader.name.Contains("ETCAlpha"))
							{
								this.genETCMat[image] = image.material;
							}
							if (this.imageGrayOrNot != null && this.imageGrayOrNot.ContainsKey(image) && !this.imageGrayOrNot[image])
							{
								return;
							}
							if (this.genETCMat.ContainsKey(image) && this.genETCMat[image] != null)
							{
								if (this.grayMat.GetTexture("_MainTex") != null && this.grayMat.GetTexture("_MainTex").name != this.genETCMat[image].GetTexture("_MainTex").name)
								{
									this.grayMat = new Material(this.grayShader);
									this.grayMat.EnableKeyword("MOBILE_USE_ETC_ALPHA");
									this.grayMat.DisableKeyword("UNITY_EDITOR_NO_ALPHA");
								}
								this.grayMat.EnableKeyword("MOBILE_USE_ETC_ALPHA");
								this.grayMat.DisableKeyword("UNITY_EDITOR_NO_ALPHA");
								this.grayMat.SetTexture("_MainTex", this.genETCMat[image].GetTexture("_MainTex"));
								this.grayMat.SetTexture("_AlphaTex", this.genETCMat[image].GetTexture("_AlphaTex"));
								image.material = this.grayMat;
							}
						}
					};
					image.RegisterDirtyMaterialCallback(unityAction);
					unityAction();
				}
				else
				{
					if (this.imageGrayOrNot != null && this.imageGrayOrNot.ContainsKey(image))
					{
						this.imageGrayOrNot[image] = false;
					}
					if (this.genETCMat != null && this.genETCMat.ContainsKey(image) && this.genETCMat[image] != null && image.material != null && image.material.shader == this.grayShader)
					{
						image.material = this.genETCMat[image];
					}
				}
			}
		}

		public void PlayAnimation(string strAnimName, LuaFunction luaFunc)
		{
			Animator componentInChildren = base.transform.GetComponentInChildren<Animator>();
			if (this.bGongjiState)
			{
				return;
			}
			if (componentInChildren != null)
			{
				componentInChildren.SetTrigger(strAnimName);
				if (strAnimName == this.strGongjiName)
				{
					this.bGongjiState = true;
				}
				if (luaFunc != null)
				{
					this.luaFuncAnimFrameEvent = luaFunc;
				}
			}
		}

		[NoToLua]
		public void ReveiveAnimationFrameEvent(string flag)
		{
			if (flag == this.strGongjiName)
			{
				this.bGongjiState = false;
			}
			if (this.luaFuncAnimFrameEvent != null)
			{
				this.luaFuncAnimFrameEvent.Call();
				this.luaFuncAnimFrameEvent.Dispose();
				this.luaFuncAnimFrameEvent = null;
			}
		}

		public void FindChildWithName(GameObject obj, string childName, LuaFunction luaFunc)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < obj.transform.childCount; i++)
			{
				Transform child = obj.transform.GetChild(i);
				if (child.name.Equals(childName))
				{
					list.Add(child);
				}
			}
			if (luaFunc != null)
			{
				luaFunc.Call(new object[]
				{
					list.ToArray()
				});
				luaFunc.Dispose();
				luaFunc = null;
			}
		}

		public void SetViewSortingOrder(GameObject gameObject, bool isUI, int order)
		{
			if (isUI)
			{
				Canvas canvas = gameObject.GetComponent<Canvas>();
				if (canvas == null)
				{
					canvas = gameObject.AddComponent<Canvas>();
					gameObject.AddComponent<GraphicRaycaster>();
				}
				if (order < 0)
				{
					canvas.overrideSorting = false;
				}
				else
				{
					canvas.overrideSorting = true;
					canvas.sortingOrder = order;
				}
			}
			else
			{
				Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>(true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].sortingOrder = order;
				}
			}
		}

		public void RemoveCanvasComponent(GameObject gameObject)
		{
			if (gameObject != null)
			{
				UnityEngine.Object.Destroy(gameObject.GetComponent<GraphicRaycaster>());
				UnityEngine.Object.Destroy(gameObject.GetComponent<Canvas>());
			}
		}

		public void CleanAssetbundleName()
		{
			this.assetbundleName = null;
		}

		protected void OnDestroy()
		{
			this.ClearClick();
			this.grayMat = null;
			if (this.genETCMat != null)
			{
				this.genETCMat.Clear();
			}
			this.genETCMat = null;
			if (this.imageGrayOrNot != null)
			{
				this.imageGrayOrNot.Clear();
			}
			this.imageGrayOrNot = null;
			this.grayShader = null;
			if (!string.IsNullOrEmpty(this.assetbundleName))
			{
				base.ResManager.UnloadAssetBundle(this.assetbundleName, true, false);
			}
		}
	}
}
