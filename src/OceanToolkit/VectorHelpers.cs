using System;
using UnityEngine;

namespace OceanToolkit
{
	public static class VectorHelpers
	{
		private static Vector4 vr = new Vector4(1f, 0f, 0f, 0f);

		private static Vector4 vu = new Vector4(0f, 1f, 0f, 0f);

		private static Vector4 vf = new Vector4(0f, 0f, 1f, 0f);

		private static Vector4 vw = new Vector4(0f, 0f, 0f, 1f);

		public static Vector2 GetV2(float x, float y)
		{
			return Vector2.right * x + Vector2.up * y;
		}

		public static Vector3 GetV3(float x, float y, float z)
		{
			return Vector3.right * x + Vector3.up * y + Vector3.forward * z;
		}

		public static Vector4 GetV4(float x, float y, float z, float w)
		{
			return VectorHelpers.vr * x + VectorHelpers.vu * y + VectorHelpers.vf * z + VectorHelpers.vw * w;
		}

		public static Vector2 Mul(Vector2 a, Vector2 b)
		{
			return VectorHelpers.vr * (a.x * b.x) + VectorHelpers.vu * (a.y * b.y);
		}

		public static Vector4 Mul(Vector4 a, Vector4 b)
		{
			return VectorHelpers.vr * (a.x * b.x) + VectorHelpers.vu * (a.y * b.y) + VectorHelpers.vf * (a.z * b.z) + VectorHelpers.vw * (a.w * b.w);
		}

		public static Vector4 Div(Vector4 a, Vector4 b)
		{
			return VectorHelpers.vr * (a.x / b.x) + VectorHelpers.vu * (a.y / b.y) + VectorHelpers.vf * (a.z / b.z) + VectorHelpers.vw * (a.w / b.w);
		}

		public static float Sum(Vector4 val)
		{
			return val.x + val.y + val.z + val.w;
		}
	}
}
