using System;
using UnityEngine;

namespace LuaFramework
{
	public class Main : MonoBehaviour
	{
		private void Start()
		{
			AppFacade.Instance.StartUp();
		}
	}
}
