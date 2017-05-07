using System;
using UnityEngine;

namespace Hummingbird.SeaBattle.Controller.CameraControll
{
	public class ShakeCamera : MonoBehaviour
	{
		private float shakeTime = 1f;

		private float shakeDelta = 0.5f;

		private Vector3 originPos;

		private bool isShaking;

		private bool isShakeCamera;

		private Camera cameraObject;

		private Rect originRect;

		private float zOffsetValue;

		private void Start()
		{
			this.originPos = base.transform.localPosition;
			base.enabled = this.isShaking;
			this.cameraObject = base.transform.GetComponent<Camera>();
			if (this.cameraObject != null)
			{
				this.originRect = this.cameraObject.rect;
			}
			this.zOffsetValue = Mathf.Tan(0.0174532924f * base.transform.localEulerAngles.x);
		}

		private void FixedUpdate()
		{
			if (this.isShaking)
			{
				if (this.shakeTime > 0f)
				{
					this.shakeTime -= Time.deltaTime;
					if (this.isShakeCamera)
					{
						Vector3 b = UnityEngine.Random.insideUnitSphere * this.shakeDelta;
						base.transform.localPosition += b;
					}
					else
					{
						this.cameraObject.rect = new Rect(this.shakeDelta * (-1f + 2f * UnityEngine.Random.value), this.shakeDelta * (-1f + 2f * UnityEngine.Random.value), 1f, 1f);
					}
				}
				else
				{
					base.transform.localPosition = this.originPos;
					if (this.cameraObject != null)
					{
						this.cameraObject.rect = this.originRect;
					}
					this.isShaking = false;
					base.enabled = false;
				}
			}
		}

		public void SetShakeParams(bool isShakeCamera, float shakeTime, float shakeDelta)
		{
			this.isShakeCamera = isShakeCamera;
			this.isShaking = true;
			base.enabled = true;
			this.shakeTime = shakeTime;
			this.shakeDelta = shakeDelta;
			this.originPos = base.transform.localPosition;
		}
	}
}
