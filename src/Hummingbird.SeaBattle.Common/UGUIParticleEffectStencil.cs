using LuaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace Hummingbird.SeaBattle.Common
{
	public class UGUIParticleEffectStencil : MonoBehaviour
	{
		public Shader[] EffectStencilShader;

		public Shader MaskStencilShader;

		public List<Shader> EffectOrgShader = new List<Shader>();

		private bool isStartChangeShader;

		private void Awake()
		{
			this.isStartChangeShader = true;
		}

		[DebuggerHidden]
		protected IEnumerator Start()
		{
			UGUIParticleEffectStencil.<Start>c__Iterator2 <Start>c__Iterator = new UGUIParticleEffectStencil.<Start>c__Iterator2();
			<Start>c__Iterator.<>f__this = this;
			return <Start>c__Iterator;
		}

		private void OnEnable()
		{
			if (this.isStartChangeShader)
			{
				return;
			}
			base.StartCoroutine(this.checkParentMaskYieldOne());
		}

		[DebuggerHidden]
		private IEnumerator checkParentMaskYieldOne()
		{
			UGUIParticleEffectStencil.<checkParentMaskYieldOne>c__Iterator3 <checkParentMaskYieldOne>c__Iterator = new UGUIParticleEffectStencil.<checkParentMaskYieldOne>c__Iterator3();
			<checkParentMaskYieldOne>c__Iterator.<>f__this = this;
			return <checkParentMaskYieldOne>c__Iterator;
		}

		private void checkParentMask()
		{
			GameObject gameObject = null;
			RectMask2D rectMask2D = Util.FindInParents<RectMask2D>(base.gameObject, true);
			Mask mask = Util.FindInParents<Mask>(base.gameObject, true);
			if (rectMask2D)
			{
				gameObject = rectMask2D.gameObject;
			}
			if (mask)
			{
				gameObject = mask.gameObject;
			}
			if (gameObject)
			{
				Image image = gameObject.GetComponent<Image>();
				if (!image)
				{
					image = gameObject.AddComponent<Image>();
				}
				if (image.material == null || image.material.shader != this.MaskStencilShader)
				{
					Material material = new Material(this.MaskStencilShader);
					if (image.sprite != null)
					{
						material.EnableKeyword("MOBILE_USE_ETC_ALPHA");
						material.DisableKeyword("UNITY_EDITOR_NO_ALPHA");
						material.SetTexture("_MainTex", image.material.GetTexture("_MainTex"));
						material.SetTexture("_AlphaTex", image.material.GetTexture("_AlphaTex"));
						image.material = material;
					}
					else
					{
						material.DisableKeyword("MOBILE_USE_ETC_ALPHA");
						material.EnableKeyword("UNITY_EDITOR_NO_ALPHA");
						image.material = material;
					}
				}
				Renderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<Renderer>(true);
				int num = 0;
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (this.EffectStencilShader != null && this.EffectStencilShader.Length != 0)
					{
						if (num >= this.EffectStencilShader.Length)
						{
							num = this.EffectStencilShader.Length - 1;
						}
						componentsInChildren[i].sharedMaterial.shader = this.EffectStencilShader[num];
						MaterialRenderQueue component = componentsInChildren[i].GetComponent<MaterialRenderQueue>();
						if (component != null)
						{
							componentsInChildren[i].sharedMaterial.renderQueue = component.RenderQueue;
						}
						num++;
					}
				}
			}
			else
			{
				Renderer[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<Renderer>(true);
				int num2 = 0;
				for (int j = 0; j < componentsInChildren2.Length; j++)
				{
					if (this.EffectOrgShader.Count > num2)
					{
						componentsInChildren2[j].sharedMaterial.shader = this.EffectOrgShader[num2];
					}
					MaterialRenderQueue component2 = componentsInChildren2[j].GetComponent<MaterialRenderQueue>();
					if (component2 != null)
					{
						componentsInChildren2[j].sharedMaterial.renderQueue = component2.RenderQueue;
					}
					num2++;
				}
			}
		}
	}
}
