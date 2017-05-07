using System;
using UnityEngine;

namespace Hummingbird.SeaBattle.Common
{
	public class UGUIOverheadSibling : MonoBehaviour
	{
		private RectTransform selfRt;

		private Transform selfRtParent;

		private void Start()
		{
			if (!(base.transform as RectTransform))
			{
				UnityEngine.Object.Destroy(this);
			}
			this.selfRt = (base.transform as RectTransform);
			this.selfRtParent = this.selfRt.parent;
		}

		private void Update()
		{
			int childCount = this.selfRtParent.childCount;
			if (childCount > this.selfRt.GetSiblingIndex() + 1)
			{
				this.selfRt.SetAsLastSibling();
			}
		}
	}
}
