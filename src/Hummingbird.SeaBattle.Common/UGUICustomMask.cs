using LuaFramework;
using System;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

namespace Hummingbird.SeaBattle.Common
{
	public class UGUICustomMask : Graphic, ICanvasRaycastFilter
	{
		private Canvas mainCV;

		public Sprite sprite;

		public bool AdaptiveBg;

		public Vector2 center = Vector2.zero;

		public Vector2 size = new Vector2(100f, 100f);

		public override Texture mainTexture
		{
			get
			{
				return (!(this.sprite == null)) ? this.sprite.texture : Graphic.s_WhiteTexture;
			}
		}

		private new void Start()
		{
			if (!this.mainCV)
			{
				this.mainCV = Util.FindInParents<Canvas>(base.gameObject, true);
			}
			if (this.AdaptiveBg && base.gameObject.GetComponent<FindCanvasAdaptiveBgOnStart>() == null)
			{
				base.gameObject.AddComponent<FindCanvasAdaptiveBgOnStart>();
			}
		}

		private float getMainCanvasWithScreenPer()
		{
			if (!this.mainCV)
			{
				return 1f;
			}
			float num = ((RectTransform)this.mainCV.transform).sizeDelta.x;
			if (num == 0f)
			{
				num = (float)Screen.width;
			}
			return num / (float)Screen.width;
		}

		public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			Vector2 point = (sp - (Vector2.right * (float)Screen.width * 0.5f + Vector2.up * (float)Screen.height * 0.5f)) * this.getMainCanvasWithScreenPer();
			Rect rect = new Rect(this.center.x - this.size.x * 0.5f, this.center.y - this.size.y * 0.5f, this.size.x, this.size.y);
			return !rect.Contains(point);
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			if (this.center == Vector2.zero && this.size == Vector2.zero)
			{
				vh.Clear();
				base.OnPopulateMesh(vh);
				return;
			}
			Vector4 vector = (!(this.sprite == null)) ? DataUtility.GetOuterUV(this.sprite) : Vector4.zero;
			Vector4 vector2 = new Vector4(-base.rectTransform.pivot.x * base.rectTransform.rect.width, -base.rectTransform.pivot.y * base.rectTransform.rect.height, (1f - base.rectTransform.pivot.x) * base.rectTransform.rect.width, (1f - base.rectTransform.pivot.y) * base.rectTransform.rect.height);
			Vector4 vector3 = new Vector4(this.center.x - this.size.x / 2f, this.center.y - this.size.y / 2f, this.center.x + this.size.x * 0.5f, this.center.y + this.size.y * 0.5f);
			vh.Clear();
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.position = new Vector2(vector2.x, vector2.y);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2(vector.x, vector.y);
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.x, vector2.w);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2(vector.x, vector.w);
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector3.x, vector2.w);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2((-vector2.x + vector3.x) / (vector2.z * 2f), vector.w);
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector3.x, vector2.y);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2((-vector2.x + vector3.x) / (vector2.z * 2f), vector.y);
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector3.z, vector2.y);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2((vector2.z + vector3.z) / (vector2.z * 2f), vector.y);
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector3.z, vector2.w);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2((vector2.z + vector3.z) / (vector2.z * 2f), vector.w);
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.z, vector2.w);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2(vector.z, vector.w);
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector2.z, vector2.y);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2(vector.z, vector.y);
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector3.x, vector3.w);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2((-vector2.x + vector3.x) / (vector2.z * 2f), 1f - (vector2.w - vector3.w) / (vector2.w * 2f));
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector3.z, vector3.w);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2((vector2.z + vector3.z) / (vector2.z * 2f), 1f - (vector2.w - vector3.w) / (vector2.w * 2f));
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector3.x, vector3.y);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2((-vector2.x + vector3.x) / (vector2.z * 2f), (-vector2.y + vector3.y) / (vector2.w * 2f));
			vh.AddVert(simpleVert);
			simpleVert.position = new Vector2(vector3.z, vector3.y);
			simpleVert.color = base.color;
			simpleVert.uv0 = new Vector2((vector2.z + vector3.z) / (vector2.z * 2f), (-vector2.y + vector3.y) / (vector2.w * 2f));
			vh.AddVert(simpleVert);
			vh.AddTriangle(0, 3, 1);
			vh.AddTriangle(3, 2, 1);
			vh.AddTriangle(8, 9, 2);
			vh.AddTriangle(9, 5, 2);
			vh.AddTriangle(4, 7, 5);
			vh.AddTriangle(7, 6, 5);
			vh.AddTriangle(3, 4, 10);
			vh.AddTriangle(4, 11, 10);
		}
	}
}
