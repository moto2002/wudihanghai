using System;
using UnityEngine;

namespace UnityStandardAssets.Water
{
	public class Water4AdvancedCamera : MonoBehaviour
	{
		public Camera RefractionCamera;

		public Camera MainCamera;

		public LayerMask refractionMask;

		public Material mat;

		public float RenderTexturePerSize = 0.5f;

		private Camera CreateRefractionCameraFor()
		{
			if (!this.RefractionCamera)
			{
				if (!this.MainCamera || !this.MainCamera.gameObject.activeSelf)
				{
					return null;
				}
				GameObject gameObject = new GameObject("RefractionCamera", new Type[]
				{
					typeof(Camera)
				});
				gameObject.transform.SetParent(this.MainCamera.transform);
				this.RefractionCamera = gameObject.GetComponent<Camera>();
				this.RefractionCamera.fieldOfView = this.MainCamera.fieldOfView;
				this.RefractionCamera.depth = -5f;
				this.RefractionCamera.nearClipPlane = this.MainCamera.nearClipPlane;
				this.RefractionCamera.farClipPlane = this.MainCamera.farClipPlane;
				this.RefractionCamera.clearFlags = CameraClearFlags.Color;
			}
			this.SetStandardCameraParameter(this.RefractionCamera, this.refractionMask);
			this.SaneCameraSettings(this.RefractionCamera);
			if (this.RefractionCamera.targetTexture == null)
			{
				this.RefractionCamera.targetTexture = this.CreateTextureFor(this.MainCamera);
			}
			return this.RefractionCamera;
		}

		private void SetStandardCameraParameter(Camera cam, LayerMask mask)
		{
			cam.cullingMask = (mask & ~(1 << LayerMask.NameToLayer("Water")));
			cam.backgroundColor = Color.black;
			cam.enabled = false;
		}

		private RenderTexture CreateTextureFor(Camera cam)
		{
			return new RenderTexture(Mathf.FloorToInt((float)cam.pixelWidth * this.RenderTexturePerSize), Mathf.FloorToInt((float)cam.pixelHeight * this.RenderTexturePerSize), 24)
			{
				hideFlags = HideFlags.DontSave
			};
		}

		private void SaneCameraSettings(Camera helperCam)
		{
			helperCam.depthTextureMode = DepthTextureMode.None;
			helperCam.clearFlags = CameraClearFlags.Color;
			helperCam.renderingPath = RenderingPath.Forward;
		}

		private void LateUpdate()
		{
			if (!this.MainCamera || !this.MainCamera.gameObject.activeSelf)
			{
				return;
			}
			this.RenderRefractionFor(this.MainCamera, this.CreateRefractionCameraFor());
			if (this.RefractionCamera && this.mat)
			{
				this.mat.SetTexture("_RefractionTex", this.RefractionCamera.targetTexture);
			}
		}

		private void RenderRefractionFor(Camera cam, Camera refractionCamera)
		{
			refractionCamera.cullingMask = (this.refractionMask & ~(1 << LayerMask.NameToLayer("Water")));
			refractionCamera.clearFlags = CameraClearFlags.Color;
			GL.invertCulling = true;
			refractionCamera.transform.eulerAngles = cam.transform.eulerAngles;
			refractionCamera.transform.position = cam.transform.position;
			refractionCamera.Render();
			GL.invertCulling = false;
		}
	}
}
