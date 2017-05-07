using LuaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hummingbird.SeaBattle.Common
{
	public class FindCanvasAdaptiveOnStart : MonoBehaviour
	{
		public float offWidth;

		private void Start()
		{
			RectTransform[] componentsInChildren = base.transform.GetComponentsInChildren<RectTransform>();
			List<RectTransform> list = new List<RectTransform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].parent == base.transform)
				{
					componentsInChildren[i].anchorMax = Vector2.up * 0.5f;
					componentsInChildren[i].anchorMin = Vector2.up * 0.5f;
					componentsInChildren[i].pivot = Vector2.up * 0.5f;
					list.Add(componentsInChildren[i]);
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			Canvas canvas = Util.FindInParents<Canvas>(base.gameObject, true);
			if (canvas)
			{
				float num = ((RectTransform)canvas.transform).sizeDelta.x;
				if (num == 0f)
				{
					num = (float)Screen.width;
				}
				float num2 = num / (float)list.Count;
				for (int j = 0; j < list.Count; j++)
				{
					list[j].anchoredPosition = new Vector2((float)j * num2 + this.offWidth, list[j].anchoredPosition.y);
				}
			}
			list.Clear();
			UnityEngine.Object.Destroy(this);
		}
	}
}
