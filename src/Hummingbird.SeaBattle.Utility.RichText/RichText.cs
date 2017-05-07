using LuaFramework;
using LuaInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hummingbird.SeaBattle.Utility.RichText
{
	public class RichText : Text, IPointerClickHandler, IEventSystemHandler
	{
		private class HrefInfo
		{
			public int startIndex;

			public int endIndex;

			public string name;

			public List<Rect> boxes = new List<Rect>();
		}

		private List<Image> m_ImagesPool = new List<Image>();

		private List<int> m_ImagesVertexIndex = new List<int>();

		private List<int> m_ImagesFrontVertexIndex = new List<int>();

		private Regex s_Regex = new Regex("<quad name=(.+?) size=(\\d*\\.?\\d+%?) width=(\\d*\\.?\\d+%?) />", RegexOptions.Singleline);

		private string orignText;

		private string m_OutputText;

		private List<RichText.HrefInfo> m_HrefInfos = new List<RichText.HrefInfo>();

		private StringBuilder s_TextBuilder = new StringBuilder();

		private Regex s_HrefRegex = new Regex("<a href=([^>\\n\\s]+)>(.*?)(</a>)", RegexOptions.Singleline);

		private LuaFunction m_OnHrefClick;

		private Regex s_HrefColorReggex = new Regex("<color=#([A-Za-z0-9]+)>(.*?)(</color>)", RegexOptions.Singleline);

		private List<Text> m_TextUnderLinePool = new List<Text>();

		[NoToLua]
		public override void SetVerticesDirty()
		{
			if (string.IsNullOrEmpty(this.text) || this.text.Equals(string.Empty))
			{
				return;
			}
			base.SetVerticesDirty();
			this.UpdateQuadImage();
		}

		protected void UpdateQuadImage()
		{
			this.m_OutputText = this.GetOutputText();
			this.m_ImagesVertexIndex.Clear();
			this.m_ImagesFrontVertexIndex.Clear();
			foreach (Match match in this.s_Regex.Matches(this.m_OutputText))
			{
				int index = match.Index;
				this.m_ImagesFrontVertexIndex.Add(index * 4 - 1);
				int item = index * 4 + 3 + (match.Value.Length - 1) * 4;
				this.m_ImagesVertexIndex.Add(item);
				this.m_ImagesPool.RemoveAll((Image image) => image == null);
				if (this.m_ImagesPool.Count == 0)
				{
					base.GetComponentsInChildren<Image>(this.m_ImagesPool);
				}
				float num = float.Parse(match.Groups[2].Value);
				if (this.m_ImagesVertexIndex.Count > this.m_ImagesPool.Count)
				{
					GameObject gameObject = DefaultControls.CreateImage(default(DefaultControls.Resources));
					gameObject.layer = base.gameObject.layer;
					RectTransform rectTransform = gameObject.transform as RectTransform;
					if (rectTransform)
					{
						rectTransform.SetParent(base.rectTransform);
						rectTransform.localPosition = Vector3.zero;
						rectTransform.localRotation = Quaternion.identity;
						rectTransform.localScale = Vector3.one;
						rectTransform.sizeDelta = Vector2.right * num + Vector2.up * num;
					}
					gameObject.gameObject.SetActive(false);
					this.m_ImagesPool.Add(gameObject.GetComponent<Image>());
				}
				string value = match.Groups[1].Value;
				Image image2 = this.m_ImagesPool[this.m_ImagesVertexIndex.Count - 1];
				string text = value.Substring(0, value.LastIndexOf('.'));
				string text2 = text.Substring(text.LastIndexOf('/') + 1);
				if (image2.sprite == null || !text2.Equals(image2.sprite.name))
				{
					this.setSprite(image2, num, value);
				}
				else
				{
					this.showImg(image2, num);
				}
			}
			for (int i = this.m_ImagesVertexIndex.Count; i < this.m_ImagesPool.Count; i++)
			{
				if (this.m_ImagesPool[i])
				{
					this.m_ImagesPool[i].gameObject.SetActive(false);
				}
			}
		}

		private void showImg(Image img, float size)
		{
			if (img)
			{
				img.rectTransform.sizeDelta = Vector2.right * size + Vector2.up * size;
				img.gameObject.SetActive(true);
			}
		}

		private void setSprite(Image image, float size, string path)
		{
			string text = path.Substring(0, path.LastIndexOf('.'));
			string text2 = text.Substring(text.LastIndexOf('/') + 1);
			if (AppFacade.Instance.GetManager<ResourceManager>("ResourceManager") == null)
			{
				return;
			}
			AppFacade.Instance.GetManager<ResourceManager>("ResourceManager").LoadSprites(path, delegate(UnityEngine.Object[] spriteAndMat)
			{
				if (spriteAndMat != null && spriteAndMat.Length > 0)
				{
					image.sprite = (spriteAndMat[0] as Sprite);
					if (spriteAndMat.Length == 2)
					{
						image.material = (spriteAndMat[1] as Material);
					}
					this.showImg(image, size);
				}
			}, null);
		}

		protected new void OnDestroy()
		{
			if (this.m_OnHrefClick != null)
			{
				this.m_OnHrefClick.Dispose();
				this.m_OnHrefClick = null;
			}
			this.m_ImagesPool.Clear();
			this.m_HrefInfos.Clear();
			if (this.s_TextBuilder != null)
			{
				this.s_TextBuilder.Clear();
				this.s_TextBuilder = null;
			}
		}

		protected override void OnPopulateMesh(VertexHelper toFill)
		{
			if (string.IsNullOrEmpty(this.text) || this.text.Equals(string.Empty))
			{
				return;
			}
			string text = this.orignText;
			this.orignText = this.m_Text;
			this.m_Text = this.m_OutputText;
			base.OnPopulateMesh(toFill);
			this.m_Text = this.orignText;
			UIVertex vertex = default(UIVertex);
			UIVertex uIVertex = default(UIVertex);
			for (int i = 0; i < this.m_ImagesVertexIndex.Count; i++)
			{
				int num = this.m_ImagesVertexIndex[i];
				RectTransform rectTransform = this.m_ImagesPool[i].rectTransform;
				Vector2 sizeDelta = rectTransform.sizeDelta;
				if (num < toFill.currentVertCount)
				{
					toFill.PopulateUIVertex(ref vertex, num);
					float y = vertex.position.y;
					toFill.PopulateUIVertex(ref uIVertex, num - 1);
					toFill.PopulateUIVertex(ref vertex, this.m_ImagesFrontVertexIndex[i]);
					float d = (uIVertex.position.x + vertex.position.x) / 2f;
					rectTransform.anchoredPosition = Vector2.right * d + Vector2.up * (y + sizeDelta.y / 4f);
					toFill.PopulateUIVertex(ref vertex, num - 3);
					Vector3 position = vertex.position;
					int j = num;
					int num2 = num - 3;
					while (j > num2)
					{
						toFill.PopulateUIVertex(ref vertex, j);
						vertex.position = position;
						toFill.SetUIVertex(vertex, j);
						j--;
					}
					toFill.PopulateUIVertex(ref vertex, this.m_ImagesFrontVertexIndex[i] - 3);
					position = vertex.position;
					int k = this.m_ImagesFrontVertexIndex[i];
					int num3 = this.m_ImagesFrontVertexIndex[i] - 3;
					while (k > num3)
					{
						toFill.PopulateUIVertex(ref vertex, k);
						vertex.position = position;
						toFill.SetUIVertex(vertex, k);
						k--;
					}
				}
			}
			int num4 = 0;
			for (int l = 0; l < this.m_HrefInfos.Count; l++)
			{
				RichText.HrefInfo hrefInfo = this.m_HrefInfos[l];
				hrefInfo.boxes.Clear();
				if (hrefInfo.startIndex < toFill.currentVertCount)
				{
					toFill.PopulateUIVertex(ref vertex, hrefInfo.startIndex);
					Vector3 position2 = vertex.position;
					Bounds bounds = new Bounds(position2, Vector3.zero);
					int m = hrefInfo.startIndex;
					int endIndex = hrefInfo.endIndex;
					while (m < endIndex)
					{
						if (m >= toFill.currentVertCount)
						{
							break;
						}
						toFill.PopulateUIVertex(ref vertex, m);
						position2 = vertex.position;
						if (position2.x < bounds.min.x)
						{
							hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
							bounds = new Bounds(position2, Vector3.zero);
						}
						else
						{
							bounds.Encapsulate(position2);
						}
						m++;
					}
					hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
					if (this.m_TextUnderLinePool[num4] != null)
					{
						RectTransform component = this.m_TextUnderLinePool[num4].GetComponent<RectTransform>();
						toFill.PopulateUIVertex(ref vertex, hrefInfo.startIndex);
						component.anchoredPosition = new Vector2(vertex.position.x + component.sizeDelta.x / 2f, vertex.position.y - component.sizeDelta.y / 2f);
					}
					num4++;
				}
			}
		}

		public void SetOnHrefClick(LuaFunction clickToDo)
		{
			this.m_OnHrefClick = clickToDo;
		}

		protected string GetOutputText()
		{
			if (this.s_TextBuilder == null)
			{
				this.s_TextBuilder = new StringBuilder();
			}
			this.s_TextBuilder.Length = 0;
			this.m_HrefInfos.Clear();
			int num = 0;
			int num2 = 0;
			foreach (Match match in this.s_HrefRegex.Matches(this.text))
			{
				this.s_TextBuilder.Append(this.text.Substring(num, match.Index - num));
				RichText.HrefInfo hrefInfo = new RichText.HrefInfo();
				hrefInfo.startIndex = this.s_TextBuilder.Length * 4;
				hrefInfo.endIndex = (this.s_TextBuilder.Length + match.Groups[2].Length - 1) * 4 + 3;
				hrefInfo.name = match.Groups[1].Value;
				MatchCollection matchCollection = this.s_HrefColorReggex.Matches(match.Groups[2].Value);
				this.m_HrefInfos.Add(hrefInfo);
				this.s_TextBuilder.Append(match.Groups[2].Value);
				num = match.Index + match.Length;
				num2++;
				this.CreateUnderLine(num2, match.Groups[2].Value, matchCollection);
			}
			for (int i = num2 + 1; i <= this.m_TextUnderLinePool.Count; i++)
			{
				this.m_TextUnderLinePool[i - 1].gameObject.SetActive(false);
			}
			this.s_TextBuilder.Append(this.text.Substring(num, this.text.Length - num));
			return this.s_TextBuilder.ToString();
		}

		private void InitStandardUnderLine(Text txtLine, string strHref, MatchCollection matchCollection)
		{
			if (txtLine != null)
			{
				txtLine.font = base.font;
				txtLine.color = base.color;
				txtLine.fontSize = base.fontSize;
				txtLine.horizontalOverflow = HorizontalWrapMode.Overflow;
				txtLine.verticalOverflow = VerticalWrapMode.Overflow;
				txtLine.alignment = TextAnchor.UpperCenter;
				txtLine.raycastTarget = false;
				RectTransform component = txtLine.GetComponent<RectTransform>();
				string str = strHref;
				string arg = string.Empty;
				if (matchCollection.Count > 0)
				{
					foreach (Match match in matchCollection)
					{
						arg = match.Groups[1].Value;
						str = match.Groups[2].Value;
					}
				}
				int stringRealNumber = this.GetStringRealNumber(str);
				float x = (float)(stringRealNumber * base.fontSize) * 0.5f;
				if (component)
				{
					component.sizeDelta = new Vector2(x, (float)base.fontSize);
				}
				txtLine.text = string.Empty;
				for (int i = 0; i < stringRealNumber; i++)
				{
					txtLine.text += "_";
				}
				if (matchCollection.Count > 0)
				{
					txtLine.text = string.Format("<color=#{0}>{1}</color>", arg, txtLine.text);
				}
				txtLine.gameObject.SetActive(true);
			}
		}

		private void CreateUnderLine(int index, string strHref, MatchCollection matchCollection)
		{
			if (index > this.m_TextUnderLinePool.Count || this.m_TextUnderLinePool[index - 1] == null)
			{
				GameObject gameObject = DefaultControls.CreateText(default(DefaultControls.Resources));
				if (gameObject)
				{
					gameObject.layer = base.gameObject.layer;
					gameObject.transform.SetParent(base.transform);
					gameObject.transform.localPosition = Vector3.zero;
					gameObject.transform.localScale = Vector3.one;
					Text component = gameObject.GetComponent<Text>();
					if (component)
					{
						this.InitStandardUnderLine(component, strHref, matchCollection);
						if (index > this.m_TextUnderLinePool.Count)
						{
							this.m_TextUnderLinePool.Add(component);
						}
						else
						{
							this.m_TextUnderLinePool[index - 1] = component;
						}
					}
				}
			}
			else
			{
				this.InitStandardUnderLine(this.m_TextUnderLinePool[index - 1], strHref, matchCollection);
			}
		}

		[NoToLua]
		public void OnPointerClick(PointerEventData eventData)
		{
			Vector2 point;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, eventData.position, eventData.pressEventCamera, out point);
			for (int i = 0; i < this.m_HrefInfos.Count; i++)
			{
				RichText.HrefInfo hrefInfo = this.m_HrefInfos[i];
				List<Rect> boxes = hrefInfo.boxes;
				for (int j = 0; j < boxes.Count; j++)
				{
					if (boxes[j].Contains(point))
					{
						if (this.m_OnHrefClick != null)
						{
							this.m_OnHrefClick.Call(new object[]
							{
								hrefInfo.name
							});
						}
						return;
					}
				}
			}
		}

		private int GetStringRealNumber(string str)
		{
			string empty = string.Empty;
			int num = 0;
			byte[] bytes = Encoding.Unicode.GetBytes(str);
			for (int i = 1; i < bytes.GetLength(0); i += 2)
			{
				if (bytes[i] > 0)
				{
					num += 2;
				}
				else
				{
					num++;
				}
			}
			return num;
		}

		public RichText GetStandardString(string str)
		{
			if (this.s_TextBuilder == null)
			{
				this.s_TextBuilder = new StringBuilder();
			}
			this.s_TextBuilder.Length = 0;
			int num = 0;
			foreach (Match match in this.s_HrefRegex.Matches(str))
			{
				this.s_TextBuilder.Append(str.Substring(num, match.Index - num));
				this.s_TextBuilder.Append(match.Groups[2].Value);
				num = match.Index + match.Length;
			}
			this.s_TextBuilder.Append(str.Substring(num, str.Length - num));
			this.text = this.s_TextBuilder.ToString();
			return this;
		}
	}
}
