using System;
using UnityEngine;
using UnityEngine.UI;

namespace Hummingbird.SeaBattle.Common
{
	public class ScrollViewOrientation : MonoBehaviour
	{
		public RectTransform viewPointTransform;

		public RectTransform contentTransform;

		public ScrollRect scrollRect;

		public void CenterSelf()
		{
			this.CenterOnItem(base.gameObject.GetComponent<RectTransform>());
		}

		public void CenterOnItem(RectTransform target)
		{
			if (target == null)
			{
				return;
			}
			Vector3 worldPointInWidget = this.GetWorldPointInWidget(this.scrollRect.GetComponent<RectTransform>(), this.GetWidgetWorldPoint(target));
			Vector3 worldPointInWidget2 = this.GetWorldPointInWidget(this.scrollRect.GetComponent<RectTransform>(), this.GetWidgetWorldPoint(this.viewPointTransform));
			Vector3 vector = worldPointInWidget2 - worldPointInWidget;
			vector.z = 0f;
			Vector2 vector2 = new Vector2(vector.x / (this.contentTransform.rect.width - this.viewPointTransform.rect.width), vector.y / (this.contentTransform.rect.height - this.viewPointTransform.rect.height));
			vector2 = this.scrollRect.normalizedPosition - vector2;
			vector2.x = Mathf.Clamp01(vector2.x);
			vector2.y = Mathf.Clamp01(vector2.y);
			this.scrollRect.normalizedPosition = vector2;
		}

		private Vector3 GetWidgetWorldPoint(RectTransform target)
		{
			Vector3 b = new Vector3((0.5f - target.pivot.x) * target.rect.size.x, (0.5f - target.pivot.y) * target.rect.size.y, 0f);
			Vector3 position = target.localPosition + b;
			return target.parent.TransformPoint(position);
		}

		private Vector3 GetWorldPointInWidget(RectTransform target, Vector3 worldPoint)
		{
			return target.InverseTransformPoint(worldPoint);
		}

		public void CenterToSelected(GameObject selected)
		{
			if (selected == null)
			{
				return;
			}
			RectTransform component = selected.GetComponent<RectTransform>();
			Vector3 a = this.viewPointTransform.position + this.viewPointTransform.rect.center;
			Vector3 position = component.position;
			Vector3 b = a - position;
			b.z = 0f;
			Vector3 position2 = this.contentTransform.position + b;
			this.contentTransform.position = position2;
		}
	}
}
