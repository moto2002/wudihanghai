using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hummingbird.SeaBattle.Utility.FNScrollRect
{
	public class FNScrollViewPool : MonoBehaviour
	{
		private Dictionary<string, Stack<ViewPoolObject>> dictCell;

		private void Start()
		{
			if (this.dictCell == null)
			{
				this.dictCell = new Dictionary<string, Stack<ViewPoolObject>>();
			}
		}

		public void AddPoolObject(ViewPoolObject poolObject, GameObject objPool)
		{
			if (!this.dictCell.ContainsKey(poolObject.Name))
			{
				Stack<ViewPoolObject> value = new Stack<ViewPoolObject>();
				this.dictCell.Add(poolObject.Name, value);
			}
			this.dictCell[poolObject.Name].Push(poolObject);
			poolObject.Obj.SetActive(false);
			poolObject.Obj.transform.SetParent(objPool.transform, false);
		}

		public ViewPoolObject GetPoolObject(string cellName)
		{
			if (this.dictCell == null)
			{
				this.dictCell = new Dictionary<string, Stack<ViewPoolObject>>();
			}
			else if (this.dictCell.ContainsKey(cellName))
			{
				Stack<ViewPoolObject> stack = this.dictCell[cellName];
				if (stack.Count > 0)
				{
					return stack.Pop();
				}
			}
			return null;
		}

		public void ClearPoolWithName(string cellName)
		{
			if (this.dictCell.ContainsKey(cellName))
			{
				Stack<ViewPoolObject> stack = this.dictCell[cellName];
				while (stack.Count > 0)
				{
					UnityEngine.Object.Destroy(stack.Pop().Obj);
				}
				this.dictCell.Remove(cellName);
			}
		}
	}
}
