using System;
using UnityEngine;

namespace UnityStandardAssets.Water
{
	[ExecuteInEditMode]
	public class WaterTile : MonoBehaviour
	{
		public PlanarReflection reflection;

		public void Start()
		{
			this.AcquireComponents();
		}

		private void AcquireComponents()
		{
			if (!this.reflection)
			{
				if (base.transform.parent)
				{
					this.reflection = base.transform.parent.GetComponent<PlanarReflection>();
				}
				else
				{
					this.reflection = base.transform.GetComponent<PlanarReflection>();
				}
			}
		}

		public void OnWillRenderObject()
		{
			if (!Camera.current.CompareTag("MainCamera"))
			{
				return;
			}
			if (this.reflection)
			{
				this.reflection.WaterTileBeingRendered(base.transform, Camera.current);
			}
		}
	}
}
