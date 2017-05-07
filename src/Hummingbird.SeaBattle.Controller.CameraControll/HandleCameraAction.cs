using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

namespace Hummingbird.SeaBattle.Controller.CameraControll
{
	public class HandleCameraAction : MonoBehaviour
	{
		public Camera Camera;

		public float PinchSmoothTime = 0.05f;

		public float PinchSpeed = 20f;

		public float PinchPower = 10f;

		public float MoveSmoothTime = 0.2f;

		public float MovePosSpeed = 20f;

		public float ClampOffsetAngle;

		public Vector2 ClampRatio = Vector2.zero;

		private LuaFunction touchScreenLuafunc;

		[NoToLua]
		private Vector3 movePos = Vector3.zero;

		private Vector3 smoothVelocity = Vector3.zero;

		[NoToLua]
		private Vector3 simulateTransPos = Vector3.zero;

		[NoToLua]
		private Vector3 bornPoint = Vector3.zero;

		[NoToLua]
		private Vector3 pinchOrgPoint = Vector3.zero;

		[NoToLua]
		private Vector3 forwardRightClamp = Vector3.zero;

		[NoToLua]
		private Vector3 behindLeftClamp = Vector3.zero;

		[NoToLua]
		private Vector3 forwardLeftClamp = Vector3.zero;

		[NoToLua]
		private Vector3 behindRightClamp = Vector3.zero;

		[NoToLua]
		private float originAngle;

		[NoToLua]
		private float xLength;

		[NoToLua]
		private float yLength;

		public void AddTouchScreen(LuaFunction luafunc)
		{
			if (!this.Camera)
			{
				return;
			}
			if (luafunc == null)
			{
				return;
			}
			this.touchScreenLuafunc = luafunc;
		}

		public void MoveTo(Vector3 point)
		{
			if (!this.Camera)
			{
				return;
			}
			this.simulateTransPos = point;
			this.movePos = point;
			this.Camera.transform.position = point;
		}

		public void SmoothTo(Vector3 point)
		{
			if (!this.Camera || this.MoveSmoothTime == 0f)
			{
				return;
			}
			this.movePos = this.Clamp(point);
		}

		public void Init(Vector3 initPoint)
		{
			if (!this.Camera)
			{
				return;
			}
			this.Camera.transform.position = initPoint;
			this.bornPoint = (this.pinchOrgPoint = (this.movePos = (this.simulateTransPos = this.Camera.transform.position)));
			this.initClampPoint(Vector3.zero);
		}

		private void initClampPoint(Vector3 offset)
		{
			this.bornPoint += offset;
			this.forwardRightClamp = this.bornPoint + this.moveForwardDir(this.ClampOffsetAngle) * this.ClampRatio.y + this.moveRightDir(this.ClampOffsetAngle) * this.ClampRatio.x;
			this.behindLeftClamp = this.bornPoint - this.moveForwardDir(this.ClampOffsetAngle) * this.ClampRatio.y - this.moveRightDir(this.ClampOffsetAngle) * this.ClampRatio.x;
			this.forwardLeftClamp = this.bornPoint + this.moveForwardDir(this.ClampOffsetAngle) * this.ClampRatio.y - this.moveRightDir(this.ClampOffsetAngle) * this.ClampRatio.x;
			this.behindRightClamp = this.bornPoint - this.moveForwardDir(this.ClampOffsetAngle) * this.ClampRatio.y + this.moveRightDir(this.ClampOffsetAngle) * this.ClampRatio.x;
			this.originAngle = Mathf.Atan2((this.behindRightClamp - this.behindLeftClamp).z, (this.behindRightClamp - this.behindLeftClamp).x);
			this.xLength = Vector3.Distance(this.behindLeftClamp, this.behindRightClamp);
			this.yLength = Vector3.Distance(this.behindRightClamp, this.forwardRightClamp);
		}

		[NoToLua]
		public void Pinch(bool inOrOut)
		{
			if (!this.Camera)
			{
				return;
			}
			if (inOrOut)
			{
				this.SmoothPinch(this.PinchSpeed);
			}
			else
			{
				this.SmoothPinch(-this.PinchSpeed);
			}
		}

		public void SmoothPinch(float val)
		{
			if (this.Camera.orthographic)
			{
				this.Camera.orthographicSize = Mathf.Clamp(this.Camera.orthographicSize + val, this.PinchSmoothTime, this.PinchPower);
			}
			else
			{
				Vector3 vector = this.Camera.transform.position + this.Camera.transform.forward * val;
				this.pinchOrgPoint = Vector3.right * vector.x + Vector3.forward * vector.z + Vector3.up * this.pinchOrgPoint.y;
				if (Vector3.Distance(vector, this.pinchOrgPoint) > this.PinchPower)
				{
					return;
				}
				this.Camera.transform.position = vector;
				this.movePos = (this.simulateTransPos = this.Camera.transform.position);
				this.initClampPoint(this.Camera.transform.forward * val);
			}
		}

		[NoToLua]
		public void Move(float x, float y)
		{
			if (!this.Camera)
			{
				return;
			}
			if (this.MoveSmoothTime > 0f)
			{
				this.movePos = this.Clamp(this.Camera.transform.position - (this.moveRightDir(0f) * x * this.MovePosSpeed + this.moveForwardDir(0f) * y * this.MovePosSpeed));
			}
			else
			{
				this.Camera.transform.position = this.Clamp(this.Camera.transform.position - (this.moveRightDir(0f) * x * this.MovePosSpeed + this.moveForwardDir(0f) * y * this.MovePosSpeed));
			}
		}

		private void LateUpdate()
		{
			if (!this.Camera || this.MoveSmoothTime == 0f)
			{
				return;
			}
			if (this.simulateTransPos.x.ToString("0.000") == this.movePos.x.ToString("0.000") && this.simulateTransPos.y.ToString("0.000") == this.movePos.y.ToString("0.000") && this.simulateTransPos.z.ToString("0.000") == this.movePos.z.ToString("0.000"))
			{
				return;
			}
			this.simulateTransPos.x = Mathf.SmoothDamp(this.Camera.transform.position.x, this.movePos.x, ref this.smoothVelocity.x, this.MoveSmoothTime);
			this.simulateTransPos.y = Mathf.SmoothDamp(this.Camera.transform.position.y, this.movePos.y, ref this.smoothVelocity.y, this.MoveSmoothTime);
			this.simulateTransPos.z = Mathf.SmoothDamp(this.Camera.transform.position.z, this.movePos.z, ref this.smoothVelocity.z, this.MoveSmoothTime);
			this.Camera.transform.position = this.simulateTransPos;
			this.pinchOrgPoint = Vector3.right * this.Camera.transform.position.x + Vector3.forward * this.Camera.transform.position.z + Vector3.up * this.pinchOrgPoint.y;
		}

		private Vector3 Clamp(Vector3 checkPoint)
		{
			Vector3 vector = checkPoint;
			Vector3 vector2 = checkPoint - this.behindLeftClamp;
			float num = Mathf.Atan2(vector2.z, vector2.x);
			float magnitude = vector2.magnitude;
			float num2 = magnitude * Mathf.Cos(num - this.originAngle);
			float num3 = magnitude * Mathf.Sin(num - this.originAngle);
			if (num2 < 0f)
			{
				vector -= this.moveRightDir(this.ClampOffsetAngle) * num2;
			}
			else if (num2 > this.xLength)
			{
				vector -= this.moveRightDir(this.ClampOffsetAngle) * (num2 - 2f * this.ClampRatio.x);
			}
			if (num3 < 0f)
			{
				vector -= this.moveForwardDir(this.ClampOffsetAngle) * num3;
			}
			else if (num3 > this.yLength)
			{
				vector -= this.moveForwardDir(this.ClampOffsetAngle) * (num3 - 2f * this.ClampRatio.y);
			}
			return vector;
		}

		private void OnDestroy()
		{
			if (this.touchScreenLuafunc != null)
			{
				this.touchScreenLuafunc.Dispose();
				this.touchScreenLuafunc = null;
			}
		}

		[NoToLua]
		public void TouchScreen(Vector3 screenPos)
		{
			RaycastHit raycastHit;
			if (this.Camera && this.checkHitRay(this.Camera, screenPos, out raycastHit) && raycastHit.transform != null)
			{
				if (AppFacade.Instance.GetManager<SoundManager>("SoundManager") != null)
				{
					AppFacade.Instance.GetManager<SoundManager>("SoundManager").PlayActionSound("Audios/sound_click_on.ogg", true);
				}
				if (this.touchScreenLuafunc != null)
				{
					this.touchScreenLuafunc.Call(new object[]
					{
						raycastHit.transform.gameObject
					});
				}
			}
		}

		private Vector3 moveForwardDir(float offsetAngle = 0f)
		{
			if (!this.Camera)
			{
				return Vector3.zero;
			}
			return Quaternion.Euler(0f, this.Camera.transform.eulerAngles.y + offsetAngle, 0f) * Vector3.forward;
		}

		private Vector3 moveRightDir(float offsetAngle = 0f)
		{
			return Quaternion.Euler(0f, 90f, 0f) * this.moveForwardDir(offsetAngle);
		}

		private bool checkHitRay(Camera camera, Vector3 hitPos, out RaycastHit hitRay)
		{
			Ray ray = camera.ScreenPointToRay(hitPos);
			LayerMask mask = camera.cullingMask;
			return Physics.Raycast(ray, out hitRay, float.PositiveInfinity, mask);
		}
	}
}
