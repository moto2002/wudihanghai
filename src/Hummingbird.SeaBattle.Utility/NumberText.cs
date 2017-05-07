using LuaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hummingbird.SeaBattle.Utility
{
	public class NumberText : MonoBehaviour
	{
		public Color Color = Color.white;

		private float numberWidth;

		private List<Image> imageList = new List<Image>();

		public void SetText(string text, string imagePath)
		{
			for (int i = 0; i < this.imageList.Count; i++)
			{
				this.imageList[i].gameObject.SetActive(false);
			}
			text = text.Replace(".", "_").Replace(":", "^");
			char[] array = text.ToCharArray();
			for (int j = 0; j < array.Length; j++)
			{
				string path = string.Format("{0}{1}.png", imagePath, array[j]);
				Image numberImage = null;
				if (this.imageList.Count > j)
				{
					numberImage = this.imageList[j];
					numberImage.gameObject.name = array[j].ToString();
				}
				else
				{
					GameObject gameObject = new GameObject(array[j].ToString());
					gameObject.transform.SetParent(base.transform, false);
					numberImage = gameObject.AddComponent<Image>();
					numberImage.gameObject.SetActive(false);
					this.imageList.Add(numberImage);
				}
				if (numberImage)
				{
					numberImage.raycastTarget = false;
					numberImage.color = this.Color;
				}
				AppFacade.Instance.GetManager<ResourceManager>("ResourceManager").LoadSprites(path, delegate(UnityEngine.Object[] spriteAndMat)
				{
					if (spriteAndMat != null && spriteAndMat.Length > 0)
					{
						numberImage.sprite = (spriteAndMat[0] as Sprite);
						if (spriteAndMat.Length == 2)
						{
							numberImage.material = (spriteAndMat[1] as Material);
						}
						numberImage.SetNativeSize();
						numberImage.gameObject.SetActive(true);
					}
				}, null);
			}
			this.numberWidth = ((this.numberWidth != 0f) ? this.numberWidth : 10f);
			int num = array.Length;
			float num2;
			if (num % 2 == 0)
			{
				num2 = ((float)(num / 2) - 0.5f) * -this.numberWidth;
			}
			else
			{
				num2 = (float)(num / 2) * -this.numberWidth;
			}
			for (int k = 0; k < this.imageList.Count; k++)
			{
				this.imageList[k].transform.localPosition = new Vector3(num2 + (float)k * this.numberWidth, 0f, 0f);
			}
		}

		public float GetNumberWidth()
		{
			return this.numberWidth * (float)this.imageList.Count;
		}
	}
}
