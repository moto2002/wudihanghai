using System;

namespace UnityEngine.UI
{
	public class LoopVerticalScrollRect : LoopScrollRect
	{
		protected override float GetSize(RectTransform item)
		{
			return LayoutUtility.GetPreferredHeight(item) + base.contentSpacing;
		}

		protected override float GetDimension(Vector2 vector)
		{
			return vector.y;
		}

		protected override Vector2 GetVector(float value)
		{
			return new Vector2(0f, value);
		}

		protected override void Awake()
		{
			base.Awake();
			this.directionSign = -1;
			GridLayoutGroup component = base.content.GetComponent<GridLayoutGroup>();
			if (component != null && component.constraint != GridLayoutGroup.Constraint.FixedColumnCount)
			{
				Debug.LogError("[LoopHorizontalScrollRect] unsupported GridLayoutGroup constraint");
			}
		}

		protected override bool UpdateItems(Bounds viewBounds, Bounds contentBounds)
		{
			bool result = false;
			if (viewBounds.min.y < contentBounds.min.y + 1f)
			{
				float num = base.NewItemAtEnd();
				if (num > 0f)
				{
					if (this.threshold < num)
					{
						this.threshold = num * 1.1f;
					}
					result = true;
				}
			}
			else if (viewBounds.min.y > contentBounds.min.y + this.threshold)
			{
				float num2 = base.DeleteItemAtEnd();
				if (num2 > 0f)
				{
					result = true;
				}
			}
			if (viewBounds.max.y > contentBounds.max.y - 1f)
			{
				float num3 = base.NewItemAtStart();
				if (num3 > 0f)
				{
					if (this.threshold < num3)
					{
						this.threshold = num3 * 1.1f;
					}
					result = true;
				}
			}
			else if (viewBounds.max.y < contentBounds.max.y - this.threshold)
			{
				float num4 = base.DeleteItemAtStart();
				if (num4 > 0f)
				{
					result = true;
				}
			}
			return result;
		}
	}
}
