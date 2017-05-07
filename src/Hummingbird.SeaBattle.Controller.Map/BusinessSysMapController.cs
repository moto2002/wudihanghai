using LuaInterface;
using System;
using UnityEngine;

namespace Hummingbird.SeaBattle.Controller.Map
{
	public class BusinessSysMapController : MonoBehaviour
	{
		[NoToLua]
		public LayerMask mask;

		public Camera RenderTextureCamera;

		public int Depth;

		public int RenderTextureWidth;

		public int RenderTextureHeight;

		public void InitRenderTextureCamera()
		{
			if (this.RenderTextureCamera)
			{
				this.RenderTextureCamera.depth = (float)this.Depth;
				this.RenderTextureCamera.cullingMask = this.mask;
				this.RenderTextureCamera.depthTextureMode = DepthTextureMode.None;
				this.RenderTextureCamera.clearFlags = CameraClearFlags.Color;
				this.RenderTextureCamera.renderingPath = RenderingPath.Forward;
				if (this.RenderTextureCamera.targetTexture == null)
				{
					this.RenderTextureCamera.targetTexture = this.CreateTextureFor();
				}
			}
		}

		public Texture GetRenderTexture()
		{
			if (this.RenderTextureCamera)
			{
				return this.RenderTextureCamera.targetTexture;
			}
			return null;
		}

		private RenderTexture CreateTextureFor()
		{
			return new RenderTexture(this.RenderTextureWidth, this.RenderTextureHeight, 24)
			{
				hideFlags = HideFlags.DontSave
			};
		}
	}
}
