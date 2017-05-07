using System;
using UnityEngine;

namespace SimpleFramework
{
	public class GlobalGenerator : MonoBehaviour
	{
		private void Awake()
		{
			this.InitGameMangager();
		}

		public void InitGameMangager()
		{
			string name = "GameManager";
			GameObject gameObject = GameObject.Find(name);
			if (gameObject == null)
			{
				gameObject = new GameObject(name);
				gameObject.name = name;
				AppFacade.Instance.StartUp();
			}
		}
	}
}
