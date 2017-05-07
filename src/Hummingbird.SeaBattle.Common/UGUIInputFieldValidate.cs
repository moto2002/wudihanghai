using System;
using UnityEngine;
using UnityEngine.UI;

namespace Hummingbird.SeaBattle.Common
{
	[ExecuteInEditMode]
	public class UGUIInputFieldValidate : MonoBehaviour
	{
		public InputField InputField;

		private void Start()
		{
			if (!this.InputField)
			{
				this.InputField = base.gameObject.GetComponent<InputField>();
			}
			if (this.InputField)
			{
				this.InputField.onValidateInput = delegate(string text, int charIndex, char addedChar)
				{
					if (char.IsSurrogate(addedChar))
					{
						return '*';
					}
					return addedChar;
				};
			}
		}
	}
}
