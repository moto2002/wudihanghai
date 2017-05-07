using System;
using System.Collections.Generic;
using UnityEngine;

namespace OceanToolkit
{
	[ExecuteInEditMode, RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class OceanFight : MonoBehaviour
	{
		[SerializeField]
		protected Material mat;

		[SerializeField]
		protected Light sun;

		[SerializeField]
		protected float windAngle;

		[SerializeField]
		protected Vector4 waveAngles = new Vector4(0f, 17f, 0f, 0f);

		[SerializeField]
		protected Vector4 waveSpeeds = new Vector4(1f, 3f, 0f, 0f);

		[SerializeField]
		protected Vector4 waveScales = new Vector4(0.5f, 2f, 0f, 0f);

		[SerializeField]
		protected Vector4 waveLengths = new Vector4(8f, 30f, 10f, 10f);

		[SerializeField]
		protected Vector4 waveExponents = new Vector4(1f, 4f, 1f, 1f);

		protected Vector4 waveOffsets = Vector4.zero;

		protected Vector4 waveDirection01 = Vector4.zero;

		protected Vector4 waveDirection23 = Vector4.zero;

		protected Vector4 waveConstants = Vector4.zero;

		protected Vector4 waveDerivativeConstants = Vector4.zero;

		[SerializeField]
		protected float normalMapAngle0;

		[SerializeField]
		protected float normalMapAngle1 = 36f;

		[SerializeField]
		protected float normalMapSpeed0 = 0.5f;

		[SerializeField]
		protected float normalMapSpeed1 = 0.3f;

		protected Vector2 normalMapOffset0 = Vector2.zero;

		protected Vector2 normalMapOffset1 = Vector2.zero;

		[SerializeField]
		protected int meshResolutionX = 200;

		[SerializeField]
		protected int meshResolutionY = 150;

		[SerializeField]
		protected float meshBoundsSize = 10000f;

		[SerializeField]
		protected bool mainCameraOnly;

		protected MeshRenderer meshRenderer;

		protected MeshFilter meshFilter;

		protected float position;

		protected float scaleSum;

		private Vector3[] ndcPoints;

		private Matrix4x4 range = default(Matrix4x4);

		private bool init_top_bottom_Plane;

		private Plane topPlane;

		private Plane bottomPlane;

		private bool init_waterPlane;

		private Plane waterPlane;

		private Ray topPlaneRay = default(Ray);

		private Ray bottomPlaneRay = default(Ray);

		private Vector3[] corners = new Vector3[8];

		private List<Vector3> points = new List<Vector3>();

		private Vector4[] viewCorners = new Vector4[4];

		private Matrix4x4 viewFrame = default(Matrix4x4);

		private Ray waterPlaneRay = default(Ray);

		public Material OceanMaterial
		{
			get
			{
				return this.mat;
			}
			set
			{
				this.mat = value;
			}
		}

		public Light SunLight
		{
			get
			{
				return this.sun;
			}
			set
			{
				this.sun = value;
			}
		}

		public float WindAngle
		{
			get
			{
				return this.windAngle;
			}
			set
			{
				this.windAngle = Mathf.Clamp(value, 0f, 360f);
			}
		}

		public float WaveAngle0
		{
			get
			{
				return this.waveAngles.x;
			}
			set
			{
				this.waveAngles.x = Mathf.Clamp(value, 0f, 360f);
			}
		}

		public float WaveAngle1
		{
			get
			{
				return this.waveAngles.y;
			}
			set
			{
				this.waveAngles.y = Mathf.Clamp(value, 0f, 360f);
			}
		}

		public float WaveAngle2
		{
			get
			{
				return this.waveAngles.z;
			}
			set
			{
				this.waveAngles.z = Mathf.Clamp(value, 0f, 360f);
			}
		}

		public float WaveAngle3
		{
			get
			{
				return this.waveAngles.w;
			}
			set
			{
				this.waveAngles.w = Mathf.Clamp(value, 0f, 360f);
			}
		}

		public float WaveSpeed0
		{
			get
			{
				return this.waveSpeeds.x;
			}
			set
			{
				this.waveSpeeds.x = Mathf.Max(0f, value);
			}
		}

		public float WaveSpeed1
		{
			get
			{
				return this.waveSpeeds.y;
			}
			set
			{
				this.waveSpeeds.y = Mathf.Max(0f, value);
			}
		}

		public float WaveSpeed2
		{
			get
			{
				return this.waveSpeeds.z;
			}
			set
			{
				this.waveSpeeds.z = Mathf.Max(0f, value);
			}
		}

		public float WaveSpeed3
		{
			get
			{
				return this.waveSpeeds.w;
			}
			set
			{
				this.waveSpeeds.w = Mathf.Max(0f, value);
			}
		}

		public float WaveScale0
		{
			get
			{
				return this.waveScales.x;
			}
			set
			{
				this.waveScales.x = Mathf.Max(0f, value);
			}
		}

		public float WaveScale1
		{
			get
			{
				return this.waveScales.y;
			}
			set
			{
				this.waveScales.y = Mathf.Max(0f, value);
			}
		}

		public float WaveScale2
		{
			get
			{
				return this.waveScales.z;
			}
			set
			{
				this.waveScales.z = Mathf.Max(0f, value);
			}
		}

		public float WaveScale3
		{
			get
			{
				return this.waveScales.w;
			}
			set
			{
				this.waveScales.w = Mathf.Max(0f, value);
			}
		}

		public float WaveLength0
		{
			get
			{
				return this.waveLengths.x;
			}
			set
			{
				this.waveLengths.x = Mathf.Max(Mathf.Epsilon, value);
			}
		}

		public float WaveLength1
		{
			get
			{
				return this.waveLengths.y;
			}
			set
			{
				this.waveLengths.y = Mathf.Max(Mathf.Epsilon, value);
			}
		}

		public float WaveLength2
		{
			get
			{
				return this.waveLengths.z;
			}
			set
			{
				this.waveLengths.z = Mathf.Max(Mathf.Epsilon, value);
			}
		}

		public float WaveLength3
		{
			get
			{
				return this.waveLengths.w;
			}
			set
			{
				this.waveLengths.w = Mathf.Max(Mathf.Epsilon, value);
			}
		}

		public float WaveSharpness0
		{
			get
			{
				return this.waveExponents.x;
			}
			set
			{
				this.waveExponents.x = Mathf.Max(1f, value);
			}
		}

		public float WaveSharpness1
		{
			get
			{
				return this.waveExponents.y;
			}
			set
			{
				this.waveExponents.y = Mathf.Max(1f, value);
			}
		}

		public float WaveSharpness2
		{
			get
			{
				return this.waveExponents.z;
			}
			set
			{
				this.waveExponents.z = Mathf.Max(1f, value);
			}
		}

		public float WaveSharpness3
		{
			get
			{
				return this.waveExponents.w;
			}
			set
			{
				this.waveExponents.w = Mathf.Max(1f, value);
			}
		}

		public float NormalMapAngle0
		{
			get
			{
				return this.normalMapAngle0;
			}
			set
			{
				this.normalMapAngle0 = Mathf.Clamp(value, 0f, 360f);
			}
		}

		public float NormalMapAngle1
		{
			get
			{
				return this.normalMapAngle1;
			}
			set
			{
				this.normalMapAngle1 = Mathf.Clamp(value, 0f, 360f);
			}
		}

		public float NormalMapSpeed0
		{
			get
			{
				return this.normalMapSpeed0;
			}
			set
			{
				this.normalMapSpeed0 = Mathf.Max(0f, value);
			}
		}

		public float NormalMapSpeed1
		{
			get
			{
				return this.normalMapSpeed1;
			}
			set
			{
				this.normalMapSpeed1 = Mathf.Max(0f, value);
			}
		}

		public int ScreenSpaceMeshResolutionX
		{
			get
			{
				return this.meshResolutionX;
			}
			set
			{
				int num = Mathf.Max(1, value);
				if (this.meshResolutionX != num)
				{
					this.meshResolutionX = num;
					this.CreateQuadMesh();
				}
			}
		}

		public int ScreenSpaceMeshResolutionY
		{
			get
			{
				return this.meshResolutionY;
			}
			set
			{
				int num = Mathf.Max(1, value);
				if (this.meshResolutionY != num)
				{
					this.meshResolutionY = num;
					this.CreateQuadMesh();
				}
			}
		}

		public float ScreenSpaceMeshBoundsSize
		{
			get
			{
				return this.meshBoundsSize;
			}
			set
			{
				float num = Mathf.Max(0f, value);
				if (this.meshBoundsSize != num)
				{
					this.meshBoundsSize = num;
					this.CreateQuadMesh();
				}
			}
		}

		public bool MainCameraOnly
		{
			get
			{
				return this.mainCameraOnly;
			}
			set
			{
				this.mainCameraOnly = value;
			}
		}

		protected void CreateQuadMesh()
		{
			int num = this.meshResolutionX;
			int num2 = this.meshResolutionY;
			Vector3[] array = new Vector3[num * num2];
			int[] array2 = new int[(num - 1) * (num2 - 1) * 2 * 3];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					array[i * num2 + j] = VectorHelpers.GetV3((float)i / (float)(num - 1), (float)j / (float)(num2 - 1), 0f);
				}
			}
			int num3 = 0;
			for (int k = 0; k < num - 1; k++)
			{
				for (int l = 0; l < num2 - 1; l++)
				{
					array2[num3++] = k * num2 + l;
					array2[num3++] = k * num2 + (l + 1);
					array2[num3++] = (k + 1) * num2 + (l + 1);
					array2[num3++] = k * num2 + l;
					array2[num3++] = (k + 1) * num2 + (l + 1);
					array2[num3++] = (k + 1) * num2 + l;
				}
			}
			Mesh mesh = new Mesh();
			mesh.name = "Ocean Mesh";
			mesh.vertices = array;
			mesh.triangles = array2;
			mesh.bounds = new Bounds(Vector3.zero, Vector3.one * this.meshBoundsSize);
			this.meshFilter.sharedMesh = mesh;
		}

		protected Vector3[] ProjectPointsToNdc(Matrix4x4 viewProj, List<Vector3> points)
		{
			if (this.ndcPoints == null)
			{
				this.ndcPoints = new Vector3[points.Count];
			}
			for (int i = 0; i < points.Count; i++)
			{
				this.ndcPoints[i] = viewProj.MultiplyPoint(points[i]);
			}
			return this.ndcPoints;
		}

		protected Matrix4x4 MapNdcBoundingBoxToFullscreen(Vector3[] ndcPoints)
		{
			Vector3 vector = ndcPoints[0];
			Vector3 vector2 = ndcPoints[0];
			for (int i = 1; i < ndcPoints.Length; i++)
			{
				vector = Vector3.Min(vector, ndcPoints[i]);
				vector2 = Vector3.Max(vector2, ndcPoints[i]);
			}
			Vector2 vector3 = vector2 - vector;
			this.range.m00 = 1f / vector3.x;
			this.range.m10 = 0f;
			this.range.m20 = 0f;
			this.range.m30 = 0f;
			this.range.m01 = 0f;
			this.range.m11 = 1f / vector3.y;
			this.range.m21 = 0f;
			this.range.m31 = 0f;
			this.range.m02 = 0f;
			this.range.m12 = 0f;
			this.range.m22 = 1f;
			this.range.m32 = 0f;
			this.range.m03 = -(vector.x / vector3.x);
			this.range.m13 = -(vector.y / vector3.y);
			this.range.m23 = 0f;
			this.range.m33 = 1f;
			return this.range;
		}

		protected void UpdateParams()
		{
			this.position = base.transform.position.y;
			this.scaleSum = VectorHelpers.Sum(this.waveScales);
			Vector4 vector = (Vector4.one * this.windAngle + this.waveAngles) * 0.0174532924f;
			this.waveDirection01 = VectorHelpers.GetV4(Mathf.Cos(vector.x), Mathf.Sin(vector.x), Mathf.Cos(vector.y), Mathf.Sin(vector.y));
			this.waveDirection23 = VectorHelpers.GetV4(Mathf.Cos(vector.z), Mathf.Sin(vector.z), Mathf.Cos(vector.w), Mathf.Sin(vector.w));
			this.waveOffsets += this.waveSpeeds * Time.deltaTime;
			this.waveConstants = VectorHelpers.Div(Vector4.one * 6.28318548f, this.waveLengths);
			this.waveDerivativeConstants = 0.5f * VectorHelpers.Mul(VectorHelpers.Mul(this.waveScales, this.waveConstants), this.waveExponents);
			float f = (this.windAngle + this.normalMapAngle0) * 0.0174532924f;
			float f2 = (this.windAngle + this.normalMapAngle1) * 0.0174532924f;
			this.normalMapOffset0 += VectorHelpers.GetV2(Mathf.Cos(f), Mathf.Sin(f)) * this.normalMapSpeed0 * Time.deltaTime;
			this.normalMapOffset1 += VectorHelpers.GetV2(Mathf.Cos(f2), Mathf.Sin(f2)) * this.normalMapSpeed1 * Time.deltaTime;
		}

		protected void SendParamsToShader()
		{
			if (this.mat == null || !this.mat.HasProperty("ot_NormalMap0"))
			{
				return;
			}
			Shader.SetGlobalFloat("ot_OceanPosition", this.position);
			Shader.SetGlobalVector("ot_WaveScales", this.waveScales);
			Shader.SetGlobalVector("ot_WaveLengths", this.waveLengths);
			Shader.SetGlobalVector("ot_WaveExponents", this.waveExponents);
			Shader.SetGlobalVector("ot_WaveOffsets", this.waveOffsets);
			Shader.SetGlobalVector("ot_WaveDirection01", this.waveDirection01);
			Shader.SetGlobalVector("ot_WaveDirection23", this.waveDirection23);
			Shader.SetGlobalVector("ot_WaveConstants", this.waveConstants);
			Shader.SetGlobalVector("ot_WaveDerivativeConstants", this.waveDerivativeConstants);
			Vector2 textureScale = this.mat.GetTextureScale("ot_NormalMap0");
			Vector2 textureScale2 = this.mat.GetTextureScale("ot_NormalMap1");
			this.mat.SetTextureOffset("ot_NormalMap0", VectorHelpers.Mul(this.normalMapOffset0, textureScale));
			this.mat.SetTextureOffset("ot_NormalMap1", VectorHelpers.Mul(this.normalMapOffset1, textureScale2));
			Vector3 v = Vector3.up;
			if (this.sun != null)
			{
				v = -this.sun.transform.forward;
			}
			Shader.SetGlobalVector("ot_LightDir", v);
			Vector4 a = this.mat.GetColor("ot_DeepWaterColorUnlit");
			float @float = this.mat.GetFloat("ot_DeepWaterIntensityZenith");
			float float2 = this.mat.GetFloat("ot_DeepWaterIntensityHorizon");
			float float3 = this.mat.GetFloat("ot_DeepWaterIntensityDark");
			float d;
			if (v.y >= 0f)
			{
				d = Mathf.Lerp(float2, @float, v.y);
			}
			else
			{
				d = Mathf.Lerp(float2, float3, -v.y);
			}
			Shader.SetGlobalVector("ot_DeepWaterColor", a * d);
		}

		protected void IntersectFrustumEdgeWaterPlane(Vector3 start, Vector3 end, List<Vector3> points)
		{
			if (!this.init_top_bottom_Plane)
			{
				this.topPlane = new Plane(Vector3.up, Vector3.up * (this.position + this.scaleSum));
				this.bottomPlane = new Plane(Vector3.up, Vector3.up * this.position);
				this.init_top_bottom_Plane = true;
			}
			else
			{
				this.topPlane.SetNormalAndPosition(Vector3.up, Vector3.up * (this.position + this.scaleSum));
				this.bottomPlane.SetNormalAndPosition(Vector3.up, Vector3.up * this.position);
			}
			Vector3 vector = end - start;
			Vector3 normalized = vector.normalized;
			float magnitude = vector.magnitude;
			this.topPlaneRay.origin = start;
			this.topPlaneRay.direction = normalized;
			float num;
			if (this.topPlane.Raycast(this.topPlaneRay, out num) && num <= magnitude)
			{
				Vector3 vector2 = start + normalized * num;
				points.Add(VectorHelpers.GetV3(vector2.x, this.position, vector2.z));
			}
			this.bottomPlaneRay.origin = start;
			this.bottomPlaneRay.direction = normalized;
			if (this.bottomPlane.Raycast(this.bottomPlaneRay, out num) && num <= magnitude)
			{
				Vector3 vector3 = start + normalized * num;
				points.Add(VectorHelpers.GetV3(vector3.x, this.position, vector3.z));
			}
		}

		protected void IntersectFrustumWaterPlane(Camera cam)
		{
			this.corners[0] = cam.ViewportToWorldPoint(VectorHelpers.GetV3(0f, 0f, cam.nearClipPlane));
			this.corners[1] = cam.ViewportToWorldPoint(VectorHelpers.GetV3(0f, 1f, cam.nearClipPlane));
			this.corners[2] = cam.ViewportToWorldPoint(VectorHelpers.GetV3(1f, 1f, cam.nearClipPlane));
			this.corners[3] = cam.ViewportToWorldPoint(VectorHelpers.GetV3(1f, 0f, cam.nearClipPlane));
			this.corners[4] = cam.ViewportToWorldPoint(VectorHelpers.GetV3(0f, 0f, cam.farClipPlane));
			this.corners[5] = cam.ViewportToWorldPoint(VectorHelpers.GetV3(0f, 1f, cam.farClipPlane));
			this.corners[6] = cam.ViewportToWorldPoint(VectorHelpers.GetV3(1f, 1f, cam.farClipPlane));
			this.corners[7] = cam.ViewportToWorldPoint(VectorHelpers.GetV3(1f, 0f, cam.farClipPlane));
			if (this.points != null)
			{
				this.points.Clear();
			}
			this.IntersectFrustumEdgeWaterPlane(this.corners[0], this.corners[1], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[1], this.corners[2], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[2], this.corners[3], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[3], this.corners[0], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[4], this.corners[5], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[5], this.corners[6], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[6], this.corners[7], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[7], this.corners[4], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[0], this.corners[4], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[1], this.corners[5], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[2], this.corners[6], this.points);
			this.IntersectFrustumEdgeWaterPlane(this.corners[3], this.corners[7], this.points);
		}

		protected void PreRender(Camera cam)
		{
			if (this.mainCameraOnly && cam != Camera.main && cam.name != "Fight Camera" && !cam.CompareTag("MainCamera"))
			{
				return;
			}
			this.IntersectFrustumWaterPlane(cam);
			if (this.points.Count > 0)
			{
				if (!this.init_waterPlane)
				{
					this.waterPlane = new Plane(Vector3.up, Vector3.up * this.position);
					this.init_waterPlane = true;
				}
				else
				{
					this.waterPlane.SetNormalAndPosition(Vector3.up, Vector3.up * this.position);
				}
				Vector3 b = cam.transform.position;
				float a = this.position + this.scaleSum + 10f;
				b.y = Mathf.Max(a, b.y);
				Vector3 a2 = cam.transform.position + cam.transform.forward * 5f;
				Vector3 vector = Vector3.Normalize(a2 - b);
				Vector3 normalized = Vector3.Cross(Vector3.up, vector).normalized;
				Vector3 normalized2 = Vector3.Cross(vector, normalized).normalized;
				this.viewFrame.SetColumn(0, normalized);
				this.viewFrame.SetColumn(1, normalized2);
				this.viewFrame.SetColumn(2, -vector);
				this.viewFrame.SetColumn(3, VectorHelpers.GetV4(b.x, b.y, b.z, 1f));
				Matrix4x4 inverse = this.viewFrame.inverse;
				Matrix4x4 projectionMatrix = cam.projectionMatrix;
				Matrix4x4 matrix4x = projectionMatrix * inverse;
				Shader.SetGlobalMatrix("ot_Proj", projectionMatrix);
				Shader.SetGlobalMatrix("ot_InvView", inverse.inverse);
				Vector3[] array = this.ProjectPointsToNdc(matrix4x, this.points);
				Matrix4x4 lhs = this.MapNdcBoundingBoxToFullscreen(array);
				Matrix4x4 inverse2 = (lhs * matrix4x).inverse;
				Vector2[] array2 = new Vector2[]
				{
					VectorHelpers.GetV2(0f, 0f),
					VectorHelpers.GetV2(1f, 0f),
					VectorHelpers.GetV2(1f, 1f),
					VectorHelpers.GetV2(0f, 1f)
				};
				for (int i = 0; i < array2.Length; i++)
				{
					Vector2 vector2 = array2[i];
					Vector3 v = VectorHelpers.GetV3(vector2.x, vector2.y, -1f);
					Vector3 v2 = VectorHelpers.GetV3(vector2.x, vector2.y, 1f);
					Vector3 vector3 = inverse2.MultiplyPoint(v);
					Vector3 a3 = inverse2.MultiplyPoint(v2);
					Vector3 normalized3 = (a3 - vector3).normalized;
					this.waterPlaneRay.origin = vector3;
					this.waterPlaneRay.direction = normalized3;
					float d;
					this.waterPlane.Raycast(this.waterPlaneRay, out d);
					Vector3 v3 = vector3 + normalized3 * d;
					this.viewCorners[i] = inverse.MultiplyPoint(v3);
				}
				Shader.SetGlobalVector("ot_ViewCorner0", this.viewCorners[0]);
				Shader.SetGlobalVector("ot_ViewCorner1", this.viewCorners[1]);
				Shader.SetGlobalVector("ot_ViewCorner2", this.viewCorners[2]);
				Shader.SetGlobalVector("ot_ViewCorner3", this.viewCorners[3]);
			}
		}

		public void OnEnable()
		{
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(this.PreRender));
		}

		public void OnDisable()
		{
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(this.PreRender));
		}

		public void Start()
		{
			this.OceanMaterial.shader = Shader.Find("Ocean Toolkit/Ocean Shader");
			this.meshRenderer = base.GetComponent<MeshRenderer>();
			this.meshFilter = base.GetComponent<MeshFilter>();
			if (this.meshFilter.sharedMesh == null)
			{
				this.CreateQuadMesh();
			}
		}

		public void LateUpdate()
		{
			if (this.meshRenderer.sharedMaterial != this.mat)
			{
				this.meshRenderer.sharedMaterial = this.mat;
			}
			this.UpdateParams();
			this.SendParamsToShader();
		}
	}
}
