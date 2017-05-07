using System;
using UnityEngine;

namespace UnityStandardAssets.Water
{
	[ExecuteInEditMode]
	public class WaterBase : MonoBehaviour
	{
		public GameObject mainCamera;

		public GameObject gonghuiCamera;

		public Material[] sharedMaterialList;

		public Material sharedMaterial;

		public Renderer waterTileRender;

		public PlanarReflection reflectionCtrl;

		public float tileableUvTimeSpeed = 0.06f;

		private void Start()
		{
			if (this.sharedMaterialList != null && this.sharedMaterialList.Length > 0)
			{
				this.sharedMaterial = this.sharedMaterialList[0];
			}
			this.waterTileRender = base.gameObject.GetComponentInChildren<Renderer>();
			this.reflectionCtrl = base.gameObject.GetComponent<PlanarReflection>();
			if (this.waterTileRender)
			{
				this.waterTileRender.sharedMaterial = this.sharedMaterial;
			}
			if (this.reflectionCtrl)
			{
				this.reflectionCtrl.m_SharedMaterial = this.sharedMaterial;
			}
		}

		public void ChangeSharedMaterial(int index)
		{
			if (this.sharedMaterialList != null && this.sharedMaterialList.Length > 0 && index >= 0 && index < this.sharedMaterialList.Length)
			{
				this.sharedMaterial = this.sharedMaterialList[index];
				if (this.waterTileRender)
				{
					this.waterTileRender.sharedMaterial = this.sharedMaterial;
				}
				if (this.reflectionCtrl)
				{
					this.reflectionCtrl.m_SharedMaterial = this.sharedMaterial;
				}
			}
		}

		private void UpdateShader()
		{
			if (!this.sharedMaterial)
			{
				return;
			}
			float num = 0f;
			if (this.sharedMaterial.GetFloat("_tileableUvTime") < 2f)
			{
				num = this.sharedMaterial.GetFloat("_tileableUvTime");
			}
			this.sharedMaterial.SetFloat("_tileableUvTime", num + Time.deltaTime * this.tileableUvTimeSpeed);
		}

		private void activeWater(bool isActive)
		{
			if (isActive)
			{
				this.UpdateShader();
			}
			if (this.waterTileRender && this.waterTileRender.gameObject.activeSelf != isActive)
			{
				this.waterTileRender.gameObject.SetActive(isActive);
			}
		}

		private void LateUpdate()
		{
			if (!this.mainCamera || !this.gonghuiCamera)
			{
				this.activeWater(true);
			}
			else if (this.mainCamera.activeSelf || this.gonghuiCamera.activeSelf)
			{
				this.activeWater(true);
			}
			else
			{
				this.activeWater(false);
			}
		}
	}
}
