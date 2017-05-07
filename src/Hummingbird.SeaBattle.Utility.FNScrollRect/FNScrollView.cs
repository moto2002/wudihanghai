using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using UGUITweener;
using UnityEngine;
using UnityEngine.UI;

namespace Hummingbird.SeaBattle.Utility.FNScrollRect
{
	public class FNScrollView : MonoBehaviour
	{
		private const string VIEW_POOL_NAME = "ScrollViewPool";

		public Transform transViewCell;

		public float cellHeight;

		public float moveTime;

		public int maxCount;

		private RectTransform transContent;

		private ScrollRect scrollRect;

		private int nTotalCount;

		private float viewHeight;

		private int cellId;

		private LuaFunction luaCallback;

		private bool isCallOnce;

		private string cellName;

		private FNScrollViewPool viewPool;

		private Dictionary<int, ViewPoolObject> dictViewPool;

		private bool isInit;

		private void Init()
		{
			if (this.isInit)
			{
				return;
			}
			if (this.transViewCell == null)
			{
				Debug.LogError("请先给scrollview设置cell对象！！");
			}
			this.transViewCell.gameObject.SetActive(false);
			GameObject gameObject = GameObject.Find("ScrollViewPool");
			if (gameObject == null)
			{
				gameObject = new GameObject("ScrollViewPool");
				gameObject.AddComponent<FNScrollViewPool>();
				gameObject.AddComponent<ResidentObject>();
			}
			this.viewPool = gameObject.GetComponent<FNScrollViewPool>();
			this.dictViewPool = new Dictionary<int, ViewPoolObject>();
			this.scrollRect = base.GetComponent<ScrollRect>();
			this.transContent = this.scrollRect.content;
			this.viewHeight = ((RectTransform)base.transform).rect.size.y;
			if (this.cellHeight == 0f)
			{
				this.cellHeight = 100f;
			}
			if (this.moveTime == 0f)
			{
				this.moveTime = 0.5f;
			}
			this.isInit = true;
		}

		private void LateUpdate()
		{
			if (this.scrollRect != null && this.scrollRect.IsActive() && this.scrollRect.velocity.y != 0f)
			{
				this.UpdateCell();
			}
		}

		public void InitScrollView(int totalCount, int nStartCell, string cellName)
		{
			this.Init();
			this.cellName = cellName;
			this.RecoverAllCell();
			this.nTotalCount = totalCount;
			this.transContent.sizeDelta = new Vector2(this.transContent.sizeDelta.x, (float)totalCount * this.cellHeight);
			float num = Mathf.Max((float)this.nTotalCount * this.cellHeight - this.viewHeight, 0f);
			if (nStartCell == -1)
			{
				this.transContent.anchoredPosition = new Vector2(this.transContent.anchoredPosition.x, num);
			}
			else if (nStartCell >= 0)
			{
				float y = Mathf.Min((float)nStartCell * this.cellHeight, num);
				this.transContent.anchoredPosition = new Vector2(this.transContent.anchoredPosition.x, y);
			}
			this.UpdateCell();
		}

		public void AddCell(int addCount, bool needMoveDown, bool isShowAnimation)
		{
			if (this.maxCount <= 0 || this.nTotalCount < this.maxCount)
			{
				this.nTotalCount += addCount;
				this.transContent.sizeDelta = new Vector2(this.transContent.sizeDelta.x, (float)this.nTotalCount * this.cellHeight);
				this.ResetCellPosition(addCount);
			}
			else
			{
				if (this.IsAtBottom())
				{
					this.ResetCellPosition(addCount * 2);
					this.RemoveFirstData();
				}
				if (needMoveDown)
				{
					float y = Mathf.Max((float)(this.nTotalCount - 1) * this.cellHeight - this.viewHeight, 0f);
					this.transContent.anchoredPosition = new Vector2(this.transContent.anchoredPosition.x, y);
				}
			}
			float y2 = Mathf.Max((float)this.nTotalCount * this.cellHeight - this.viewHeight, 0f);
			if (needMoveDown)
			{
				if (isShowAnimation)
				{
					if (!this.transContent.GetComponent<TweenPosition>())
					{
						this.transContent.gameObject.AddComponent<TweenPosition>();
					}
					Vector3 to = new Vector3(this.transContent.localPosition.x, y2, this.transContent.localPosition.z);
					TweenUtil.SetTweenPositionInfo(this.transContent.gameObject, this.transContent.localPosition, to, this.moveTime, 0f);
					TweenUtil.PlayTween(this.transContent.gameObject, true, null, true);
				}
				else
				{
					this.transContent.anchoredPosition = new Vector2(this.transContent.anchoredPosition.x, y2);
				}
			}
			this.UpdateCell();
		}

		public bool IsAtBottom()
		{
			float num = Mathf.Max((float)this.nTotalCount * this.cellHeight - this.viewHeight, 0f);
			return Mathf.Abs(this.transContent.anchoredPosition.y - num) < this.cellHeight + 50f;
		}

		public void SetAtBottomCallback(LuaFunction luac)
		{
			this.luaCallback = luac;
		}

		private void CreateCell(int idx)
		{
			ViewPoolObject viewPoolObject = this.viewPool.GetPoolObject(this.cellName);
			GameObject gameObject;
			if (viewPoolObject == null)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.transViewCell.gameObject);
				gameObject.name = this.cellName;
				viewPoolObject = gameObject.AddComponent<ViewPoolObject>();
				viewPoolObject.Name = this.cellName;
				viewPoolObject.Id = ++this.cellId;
				viewPoolObject.Obj = gameObject;
			}
			else
			{
				gameObject = viewPoolObject.Obj;
			}
			float y = (this.transContent.sizeDelta.y - this.cellHeight) * 0.5f - this.cellHeight * (float)idx;
			gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, y, gameObject.transform.localPosition.z);
			gameObject.SetActive(true);
			gameObject.transform.SetParent(this.transContent, false);
			this.dictViewPool.Add(idx, viewPoolObject);
			gameObject.GetComponent<ScrollIndexCallback>().FNScrollCellIndex(idx);
		}

		private void ResetCellPosition(int addCount)
		{
			foreach (KeyValuePair<int, ViewPoolObject> current in this.dictViewPool)
			{
				GameObject obj = current.Value.Obj;
				obj.transform.localPosition += new Vector3(0f, (float)addCount * this.cellHeight * 0.5f, 0f);
			}
		}

		private void RemoveFirstData()
		{
			Dictionary<int, ViewPoolObject> dictionary = new Dictionary<int, ViewPoolObject>(this.dictViewPool);
			ArrayList arrayList = new ArrayList(dictionary.Keys);
			arrayList.Sort();
			int num = 0;
			for (int i = 0; i < arrayList.Count; i++)
			{
				num = Convert.ToInt32(arrayList[i]);
				int num2 = num - 1;
				if (num2 < 0)
				{
					this.RecoverCellWithKey(0);
				}
				else
				{
					if (this.dictViewPool.ContainsKey(num2))
					{
						this.dictViewPool.Remove(num2);
					}
					this.dictViewPool.Add(num2, dictionary[num]);
				}
			}
			this.dictViewPool.Remove(num);
		}

		private void RecoverCellWithKey(int key)
		{
			if (this.dictViewPool.ContainsKey(key))
			{
				this.viewPool.AddPoolObject(this.dictViewPool[key], this.viewPool.gameObject);
				this.dictViewPool.Remove(key);
			}
		}

		private void RecoverAllCell()
		{
			foreach (KeyValuePair<int, ViewPoolObject> current in this.dictViewPool)
			{
				this.viewPool.AddPoolObject(current.Value, this.viewPool.gameObject);
			}
			this.dictViewPool.Clear();
		}

		private void UpdateCell()
		{
			int num = Mathf.FloorToInt(this.transContent.anchoredPosition.y / this.cellHeight);
			int num2 = Mathf.CeilToInt((this.transContent.anchoredPosition.y + this.viewHeight) / this.cellHeight);
			if (this.luaCallback != null)
			{
				if (num2 >= this.nTotalCount)
				{
					if (!this.isCallOnce)
					{
						this.luaCallback.Call();
						this.isCallOnce = true;
					}
				}
				else
				{
					this.isCallOnce = false;
				}
			}
			for (int i = 0; i < this.nTotalCount; i++)
			{
				if (i < num || i > num2)
				{
					this.RecoverCellWithKey(i);
				}
				if (i >= num && i <= num2 && !this.dictViewPool.ContainsKey(i))
				{
					this.CreateCell(i);
				}
			}
		}

		private void OnDestroy()
		{
			if (this.viewPool != null)
			{
				this.viewPool.ClearPoolWithName(this.cellName);
			}
			if (this.luaCallback != null)
			{
				this.luaCallback.Dispose();
				this.luaCallback = null;
			}
		}
	}
}
