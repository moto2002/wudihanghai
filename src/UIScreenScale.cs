using System;
using UnityEngine;

public class UIScreenScale : MonoBehaviour
{
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		if (num > 0.7f)
		{
			base.transform.localScale = Vector3.one * 1.3f;
		}
		else if (num > 0.65f)
		{
			base.transform.localScale = Vector3.one * 1.15f;
		}
		else if (num > 0.6f)
		{
			base.transform.localScale = Vector3.one * 1.1f;
		}
	}
}
