using System;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingBytes
{
	internal class Pool
	{
		private Stack<PoolObject> availableObjStack = new Stack<PoolObject>();

		private bool fixedSize;

		private GameObject poolObjectPrefab;

		private int poolSize;

		private string poolName;

		private int transId;

		private Transform poolRoot;

		public Pool(string poolName, GameObject poolObjectPrefab, int initialCount, bool fixedSize, Transform pool)
		{
			this.poolName = poolName;
			this.poolObjectPrefab = poolObjectPrefab;
			this.poolSize = initialCount;
			this.fixedSize = fixedSize;
			this.poolRoot = pool;
			this.transId = 0;
			for (int i = 0; i < initialCount; i++)
			{
				this.AddObjectToPool(this.NewObjectInstance());
			}
		}

		private void AddObjectToPool(PoolObject po)
		{
			po.gameObject.SetActive(false);
			this.availableObjStack.Push(po);
			po.isPooled = true;
			po.transform.SetParent(this.poolRoot, false);
		}

		private PoolObject NewObjectInstance()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.poolObjectPrefab);
			PoolObject poolObject = gameObject.GetComponent<PoolObject>();
			if (poolObject == null)
			{
				poolObject = gameObject.AddComponent<PoolObject>();
			}
			poolObject.poolName = this.poolName;
			poolObject.id = ++this.transId;
			return poolObject;
		}

		public GameObject NextAvailableObject(Vector3 position, Quaternion rotation)
		{
			PoolObject poolObject = null;
			if (this.availableObjStack.Count > 0)
			{
				poolObject = this.availableObjStack.Pop();
			}
			else if (!this.fixedSize)
			{
				this.poolSize++;
				poolObject = this.NewObjectInstance();
			}
			else
			{
				Debug.LogWarning("No object available & cannot grow pool: " + this.poolName);
			}
			GameObject gameObject = null;
			if (poolObject != null)
			{
				poolObject.isPooled = false;
				gameObject = poolObject.gameObject;
				gameObject.SetActive(true);
				gameObject.transform.position = position;
				gameObject.transform.rotation = rotation;
			}
			return gameObject;
		}

		public GameObject NextAvailableObject()
		{
			PoolObject poolObject = null;
			if (this.availableObjStack.Count > 0)
			{
				poolObject = this.availableObjStack.Pop();
			}
			else if (!this.fixedSize)
			{
				this.poolSize++;
				poolObject = this.NewObjectInstance();
			}
			else
			{
				Debug.LogWarning("No object available & cannot grow pool: " + this.poolName);
			}
			GameObject gameObject = null;
			if (poolObject != null)
			{
				poolObject.isPooled = false;
				gameObject = poolObject.gameObject;
				gameObject.SetActive(true);
			}
			return gameObject;
		}

		public void ReturnObjectToPool(PoolObject po)
		{
			if (this.poolName.Equals(po.poolName))
			{
				if (po.isPooled)
				{
					Debug.LogWarning(po.gameObject.name + " is already in pool. Why are you trying to return it again? Check usage.");
				}
				else
				{
					this.AddObjectToPool(po);
				}
			}
			else
			{
				Debug.LogError(string.Format("Trying to add object to incorrect pool {0} {1}", po.poolName, this.poolName));
			}
		}

		public void SetPoolObjectPrefab(GameObject prefab)
		{
			this.poolObjectPrefab = prefab;
		}

		public void RemovePoolPrefab()
		{
			while (this.availableObjStack.Count > 0)
			{
				UnityEngine.Object.Destroy(this.availableObjStack.Pop().gameObject);
			}
			this.availableObjStack.Clear();
			this.transId = 0;
		}
	}
}
