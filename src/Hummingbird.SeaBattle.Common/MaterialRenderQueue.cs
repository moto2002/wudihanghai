using System;
using UnityEngine;

namespace Hummingbird.SeaBattle.Common
{
	public class MaterialRenderQueue : MonoBehaviour
	{
		public int RenderQueue = 3000;

		private void Start()
		{
			Renderer component = base.gameObject.GetComponent<Renderer>();
			if (component)
			{
				component.sharedMaterial.renderQueue = this.RenderQueue;
			}
		}
	}
}
