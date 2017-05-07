using System;
using UnityEngine;

namespace MarchingBytes
{
	[Serializable]
	public class PoolInfo
	{
		public string poolName;

		public GameObject prefab;

		public int poolSize;

		public bool fixedSize;
	}
}
