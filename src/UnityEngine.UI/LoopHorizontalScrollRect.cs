using System;

namespace UnityEngine.UI
{
	public class LoopHorizontalScrollRect : LoopScrollRect
	{
		protected override float GetSize(RectTransform item)
		{
			return LayoutUtility.GetPreferredWidth(item) + base.contentSpacing;
		}

		protected override float GetDimension(Vector2 vector)
		{
			return vector.x;
		}

		protected override Vector2 GetVector(float value)
		{
			return new Vector2(-value, 0f);
		}

		protected override void Awake()
		{
			base.Awake();
			this.directionSign = 1;
			GridLayoutGroup component = base.content.GetComponent<GridLayoutGroup>();
			if (component != null && component.constraint != GridLayoutGroup.Constraint.FixedRowCount)
			{
				Debug.LogError("[LoopHorizontalScrollRect] unsupported GridLayoutGroup constraint");
			}
		}

		protected override bool UpdateItems(Bounds viewBounds, Bounds contentBounds)
		{
			bool result = false;
			if (viewBounds.max.x > contentBounds.max.x)
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
			else if (viewBounds.max.x < contentBounds.max.x - this.threshold)
			{
				float num2 = base.DeleteItemAtEnd();
				if (num2 > 0f)
				{
					result = true;
				}
			}
			if (viewBounds.min.x < contentBounds.min.x)
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
			else if (viewBounds.min.x > contentBounds.min.x + this.threshold)
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
