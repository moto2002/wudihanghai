using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hummingbird.SeaBattle.Controller.Map
{
	public class FubenTwoDMapController : MonoBehaviour, IEventSystemHandler, IDragHandler
	{
		[NoToLua]
		public Transform ObjMap;

		[NoToLua]
		public Transform ObjThumbnailPoint;

		public float MovePosSpeed = 20f;

		public Vector2 ClampRatio = Vector2.zero;

		private bool handle = true;

		[NoToLua]
		private Vector3 movePos = Vector3.zero;

		private Vector3 smoothVelocity = Vector3.zero;

		[NoToLua]
		private Vector3 simulateTransPos = Vector3.zero;

		[NoToLua]
		private Vector3 bornPoint = Vector3.zero;

		public void Handle(bool isHandle)
		{
			this.handle = isHandle;
		}

		public void MoveTo(Vector3 point)
		{
			if (!this.ObjMap)
			{
				return;
			}
			this.simulateTransPos = point;
			this.movePos = point;
			if (!this.handle)
			{
				this.ObjMap.localPosition = point;
			}
			else
			{
				this.ObjMap.localPosition = this.Clamp(point);
			}
			this.dragThumbnailPoint();
		}

		public void Init(Vector3 initPoint)
		{
			if (!this.ObjMap)
			{
				return;
			}
			this.ObjMap.localPosition = initPoint;
			this.bornPoint = (this.movePos = (this.simulateTransPos = this.ObjMap.localPosition));
			this.dragThumbnailPoint();
		}

		private void Start()
		{
			if (!this.ObjMap)
			{
				return;
			}
			this.Init(this.ObjMap.localPosition);
		}

		private Vector3 Clamp(Vector3 checkPoint)
		{
			Vector3 result = checkPoint;
			float min = this.bornPoint.x - 0.5f * this.ClampRatio.x;
			float max = this.bornPoint.x + 0.5f * this.ClampRatio.x;
			float min2 = this.bornPoint.y - 0.5f * this.ClampRatio.y;
			float max2 = this.bornPoint.y + 0.5f * this.ClampRatio.y;
			result.x = Mathf.Clamp(result.x, min, max);
			result.y = Mathf.Clamp(result.y, min2, max2);
			return result;
		}

		private Vector3 GET_POS(float x, float y, float z)
		{
			return Vector3.right * x + Vector3.up * y + Vector3.forward * z;
		}

		[NoToLua]
		public void OnDrag(PointerEventData eventData)
		{
			if (!this.handle)
			{
				return;
			}
			this.movePos = this.Clamp(this.ObjMap.localPosition + this.GET_POS(eventData.delta.x * this.MovePosSpeed, eventData.delta.y * this.MovePosSpeed, 0f));
			this.ObjMap.localPosition = this.movePos;
			this.dragThumbnailPoint();
		}

		private void dragThumbnailPoint()
		{
			if (this.ObjThumbnailPoint)
			{
				this.ObjThumbnailPoint.localPosition = -this.ObjMap.localPosition;
			}
		}
	}
}
