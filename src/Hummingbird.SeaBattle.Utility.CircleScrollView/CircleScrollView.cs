using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hummingbird.SeaBattle.Utility.CircleScrollView
{
	public class CircleScrollView : UIBehaviour, IEventSystemHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
	{
		private enum MoveDirection
		{
			None,
			Right,
			Left
		}

		private RectTransform rtScrollView;

		private RectTransform rtGrid;

		private Vector2 vector2PointerStart = Vector2.zero;

		private Vector2 vector2GridStart = Vector2.zero;

		private float fCellWidth;

		private float fSpacingX;

		private bool bMovable;

		private bool bDragging;

		public int foucsIndex;

		private new void Start()
		{
			this.rtScrollView = base.transform.GetComponent<RectTransform>();
			Transform transform = base.transform.Find("Grid");
			this.rtGrid = transform.GetComponent<RectTransform>();
			Vector2 cellSize = transform.GetComponent<GridLayoutGroup>().cellSize;
			Vector2 spacing = transform.GetComponent<GridLayoutGroup>().spacing;
			this.fCellWidth = cellSize.x;
			this.fSpacingX = spacing.x;
			this.bMovable = (this.rtGrid.childCount > 1);
			if (this.bMovable)
			{
				if (this.foucsIndex < 0 || this.foucsIndex >= this.rtGrid.childCount)
				{
					this.foucsIndex = 0;
				}
				float num = this.rtGrid.sizeDelta.x / 2f - this.fCellWidth / 2f;
				num -= (float)this.foucsIndex * (this.fCellWidth + this.fSpacingX);
				this.rtGrid.anchoredPosition = new Vector2(num, this.rtGrid.anchoredPosition.y);
			}
		}

		public virtual void OnBeginDrag(PointerEventData eventData)
		{
			if (!this.bMovable)
			{
				return;
			}
			this.vector2PointerStart = Vector2.zero;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.rtScrollView, eventData.position, eventData.pressEventCamera, out this.vector2PointerStart);
			this.bDragging = true;
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			if (!this.bMovable)
			{
				return;
			}
			if (this.bDragging)
			{
				Vector2 a;
				if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(this.rtScrollView, eventData.position, eventData.pressEventCamera, out a))
				{
					return;
				}
				Vector2 vector = a - this.vector2PointerStart;
				if (vector.x != 0f)
				{
					CircleScrollView.MoveDirection moveDirection = (vector.x <= 0f) ? CircleScrollView.MoveDirection.Left : CircleScrollView.MoveDirection.Right;
					this.MoveGrid(moveDirection);
					this.bDragging = false;
				}
			}
		}

		public virtual void OnEndDrag(PointerEventData eventData)
		{
			if (!this.bMovable)
			{
				return;
			}
		}

		public void PreviousCell()
		{
			this.MoveGrid(CircleScrollView.MoveDirection.Left);
		}

		public void NextCell()
		{
			this.MoveGrid(CircleScrollView.MoveDirection.Left);
		}

		private void MoveGrid(CircleScrollView.MoveDirection moveDirection)
		{
			if (!this.bMovable || moveDirection == CircleScrollView.MoveDirection.None)
			{
				return;
			}
			this.RepairCellsOfGrid(moveDirection);
			Vector2 anchoredPosition = this.rtGrid.anchoredPosition;
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			if (moveDirection == CircleScrollView.MoveDirection.Right)
			{
				zero2.x = anchoredPosition.x + this.fCellWidth / 2f;
				zero2.y = this.rtGrid.anchoredPosition.y;
				this.rtGrid.anchoredPosition = zero2;
				zero.x = anchoredPosition.x + this.fCellWidth;
				zero.y = this.rtGrid.anchoredPosition.y;
				this.rtGrid.anchoredPosition = zero;
				this.foucsIndex = (this.foucsIndex - 1 + this.rtGrid.childCount) % this.rtGrid.childCount;
			}
			else if (moveDirection == CircleScrollView.MoveDirection.Left)
			{
				zero2.x = anchoredPosition.x - this.fCellWidth / 2f;
				zero2.y = this.rtGrid.anchoredPosition.y;
				this.rtGrid.anchoredPosition = zero2;
				zero.x = anchoredPosition.x - this.fCellWidth;
				zero.y = this.rtGrid.anchoredPosition.y;
				this.rtGrid.anchoredPosition = zero;
				this.foucsIndex = (this.foucsIndex + 1) % this.rtGrid.childCount;
			}
		}

		private void RepairCellsOfGrid(CircleScrollView.MoveDirection moveDirection)
		{
			if (!this.bMovable || moveDirection == CircleScrollView.MoveDirection.None)
			{
				return;
			}
			Vector2 anchoredPosition = this.rtGrid.anchoredPosition;
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			if (moveDirection == CircleScrollView.MoveDirection.Right)
			{
				if (this.foucsIndex == 0)
				{
					this.rtGrid.GetChild(this.rtGrid.childCount - 1).SetAsFirstSibling();
					zero.x = anchoredPosition.x - this.fCellWidth;
					zero.y = this.rtGrid.anchoredPosition.y;
					this.rtGrid.anchoredPosition = zero;
					this.foucsIndex = (this.foucsIndex + 1) % this.rtGrid.childCount;
				}
			}
			else if (moveDirection == CircleScrollView.MoveDirection.Left && this.foucsIndex == this.rtGrid.childCount - 1)
			{
				this.rtGrid.GetChild(0).SetAsLastSibling();
				zero.x = anchoredPosition.x + this.fCellWidth;
				zero.y = this.rtGrid.anchoredPosition.y;
				this.rtGrid.anchoredPosition = zero;
				this.foucsIndex = (this.foucsIndex - 1 + this.rtGrid.childCount) % this.rtGrid.childCount;
			}
		}
	}
}
