using System;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingBytes
{
	public class EasyObjectPool : MonoBehaviour
	{
		public static EasyObjectPool instance;

		private Dictionary<string, Pool> poolDictionary = new Dictionary<string, Pool>();

		private void Awake()
		{
			EasyObjectPool.instance = this;
		}

		public GameObject GetObjectFromPool(string poolName, Vector3 position, Quaternion rotation)
		{
			GameObject gameObject = null;
			if (this.poolDictionary.ContainsKey(poolName))
			{
				Pool pool = this.poolDictionary[poolName];
				gameObject = pool.NextAvailableObject(position, rotation);
				if (gameObject == null)
				{
					Debug.LogWarning("No object available in pool. Consider setting fixedSize to false.: " + poolName);
				}
			}
			else
			{
				Debug.LogError("Invalid pool name specified: " + poolName);
			}
			return gameObject;
		}

		public GameObject GetObjectFromPool(string poolName)
		{
			GameObject gameObject = null;
			if (this.poolDictionary.ContainsKey(poolName))
			{
				Pool pool = this.poolDictionary[poolName];
				gameObject = pool.NextAvailableObject();
				if (gameObject == null)
				{
					Debug.LogWarning("No object available in pool. Consider setting fixedSize to false.: " + poolName);
				}
			}
			else
			{
				Debug.LogError("Invalid pool name specified: " + poolName);
			}
			return gameObject;
		}

		public void ReturnObjectToPool(GameObject go)
		{
			PoolObject component = go.GetComponent<PoolObject>();
			if (component == null)
			{
				Debug.LogWarning("Specified object is not a pooled instance: " + go.name);
			}
			else if (this.poolDictionary.ContainsKey(component.poolName))
			{
				Pool pool = this.poolDictionary[component.poolName];
				pool.ReturnObjectToPool(component);
			}
			else
			{
				Debug.LogWarning("No pool available with name: " + component.poolName);
			}
		}

		public void SetPrefabWithName(string prefabName, GameObject prefab)
		{
			if (!this.poolDictionary.ContainsKey(prefabName))
			{
				Pool value = new Pool(prefabName, prefab, 0, false, base.transform);
				this.poolDictionary.Add(prefabName, value);
			}
			this.poolDictionary[prefabName].SetPoolObjectPrefab(prefab);
		}

		public void RemovePoolPrefab(string prefabName)
		{
			if (this.poolDictionary.ContainsKey(prefabName))
			{
				this.poolDictionary[prefabName].RemovePoolPrefab();
			}
		}
	}
}
