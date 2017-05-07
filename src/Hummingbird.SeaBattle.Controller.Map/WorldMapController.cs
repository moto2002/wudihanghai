using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hummingbird.SeaBattle.Controller.Map
{
	public class WorldMapController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
	{
		public float Distance;

		public Vector3 Offset;

		public int TiledCount;

		public float TiledWidth;

		public float DragVelocity;

		private Camera mapCamera;

		private float cameraSinRadian;

		private float cameraCosRadian;

		private Vector2 currentCoordinate = Vector2.zero;

		private Vector2 offsetCoordinate;

		private Vector2 startCoordinate;

		private LuaFunction moveCoordinateLuaFunc;

		private LuaFunction touchCoordinateLuaFunc;

		private LuaFunction updateLuaFunc;

		public void FocusTo(int x, int y)
		{
			this.currentCoordinate = new Vector2((float)x, (float)y);
			float num = (float)y * this.TiledWidth;
			float num2 = (float)x * -this.TiledWidth;
			this.mapCamera.transform.localPosition = this.Offset + new Vector3(this.Distance + num, this.mapCamera.transform.localPosition.y, this.Distance + num2);
			if (this.mapCamera != null && this.mapCamera.transform.parent != null)
			{
				Vector3 position = -this.mapCamera.transform.localPosition;
				position.y = this.mapCamera.transform.parent.transform.position.y;
				this.mapCamera.transform.parent.transform.position = position;
			}
		}

		private void Awake()
		{
			if (this.TiledWidth == 0f)
			{
				this.TiledWidth = 10f;
			}
			this.offsetCoordinate = this.Distance * Vector2.one + new Vector2(this.Offset.x - this.TiledWidth * 0.5f, this.Offset.z + this.TiledWidth * 0.5f);
		}

		public void SetCamera(GameObject objCamera, bool bNeedSetPos)
		{
			if (bNeedSetPos)
			{
				objCamera.transform.localPosition = this.Offset + new Vector3(this.Distance, objCamera.transform.localPosition.y, this.Distance);
			}
			this.mapCamera = objCamera.GetComponent<Camera>();
			float f = objCamera.transform.eulerAngles.x * 0.0174532924f;
			this.cameraSinRadian = Mathf.Sin(f);
			this.cameraCosRadian = Mathf.Cos(f);
		}

		[NoToLua]
		public void OnPointerClick(PointerEventData eventData)
		{
			if (!eventData.dragging)
			{
				Vector3 position = Vector3.right * eventData.position.x + Vector3.up * eventData.position.y;
				Ray ray = this.mapCamera.ScreenPointToRay(position);
				LayerMask mask = this.mapCamera.cullingMask;
				RaycastHit raycastHit;
				if (Physics.Raycast(ray, out raycastHit, float.PositiveInfinity, mask) && this.touchCoordinateLuaFunc != null)
				{
					string name = raycastHit.transform.name;
					this.touchCoordinateLuaFunc.Call(new object[]
					{
						name
					});
				}
			}
		}

		[NoToLua]
		public void OnBeginDrag(PointerEventData eventData)
		{
			this.startCoordinate = this.currentCoordinate;
		}

		[NoToLua]
		public void OnDrag(PointerEventData eventData)
		{
			float num = eventData.delta.x * this.cameraCosRadian - eventData.delta.y * this.cameraSinRadian;
			float num2 = eventData.delta.x * this.cameraSinRadian + eventData.delta.y * this.cameraCosRadian;
			num = num * this.cameraCosRadian * this.DragVelocity;
			num2 = num2 * this.cameraSinRadian * this.DragVelocity;
			Vector3 localPosition = this.mapCamera.transform.localPosition + new Vector3(num, 0f, num2);
			Vector2 vector = new Vector2(localPosition.x, localPosition.z) - this.offsetCoordinate;
			vector = new Vector2((float)Mathf.FloorToInt(vector.y / -this.TiledWidth), (float)Mathf.FloorToInt(vector.x / this.TiledWidth));
			if (vector.x != this.currentCoordinate.x || vector.y != this.currentCoordinate.y)
			{
				this.currentCoordinate = vector;
				if (this.moveCoordinateLuaFunc != null)
				{
					this.moveCoordinateLuaFunc.Call(new object[]
					{
						this.currentCoordinate.x,
						this.currentCoordinate.y
					});
				}
			}
			if (vector.x >= 0f && vector.x <= (float)this.TiledCount && vector.y >= 0f && vector.y <= (float)this.TiledCount)
			{
				this.mapCamera.transform.localPosition = localPosition;
			}
		}

		[NoToLua]
		public void OnEndDrag(PointerEventData eventData)
		{
			if (this.mapCamera != null && this.mapCamera.transform.parent != null)
			{
				Vector3 position = -this.mapCamera.transform.localPosition;
				position.y = this.mapCamera.transform.parent.transform.position.y;
				this.mapCamera.transform.parent.transform.position = position;
			}
			if (this.updateLuaFunc != null && !this.startCoordinate.Equals(this.currentCoordinate) && this.currentCoordinate.x >= 0f && this.currentCoordinate.y >= 0f && this.currentCoordinate.x <= (float)this.TiledCount && this.currentCoordinate.y <= (float)this.TiledCount)
			{
				this.updateLuaFunc.Call();
			}
		}

		public void SetCallback(LuaFunction moveCoordinateLuaFunc, LuaFunction touchCoordinateLuaFunc, LuaFunction updateLuaFunc)
		{
			this.moveCoordinateLuaFunc = moveCoordinateLuaFunc;
			this.touchCoordinateLuaFunc = touchCoordinateLuaFunc;
			this.updateLuaFunc = updateLuaFunc;
		}

		private void OnDestroy()
		{
			if (this.updateLuaFunc != null)
			{
				this.updateLuaFunc.Dispose();
				this.updateLuaFunc = null;
			}
			if (this.moveCoordinateLuaFunc != null)
			{
				this.moveCoordinateLuaFunc.Dispose();
				this.updateLuaFunc = null;
			}
			if (this.touchCoordinateLuaFunc != null)
			{
				this.touchCoordinateLuaFunc.Dispose();
				this.touchCoordinateLuaFunc = null;
			}
		}
	}
}
