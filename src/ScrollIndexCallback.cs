using Hummingbird.SeaBattle.Utility.FNScrollRect;
using LuaFramework;
using MarchingBytes;
using System;
using UnityEngine;

public class ScrollIndexCallback : MonoBehaviour
{
	public void ScrollCellIndex(int idx)
	{
		base.gameObject.name = base.gameObject.name.Replace("(Clone)", string.Empty);
		string text = base.gameObject.name.Split(new char[]
		{
			'_'
		})[0];
		base.gameObject.name = text + string.Format("_{0}", idx);
		int id = base.transform.GetComponent<PoolObject>().id;
		Util.CallMethod("UIHelper", "ReceiveScrollCellMessage", new object[]
		{
			base.transform,
			idx,
			id,
			text
		});
	}

	public void FNScrollCellIndex(int idx)
	{
		base.gameObject.name = base.gameObject.name.Replace("(Clone)", string.Empty);
		string text = base.gameObject.name.Split(new char[]
		{
			'_'
		})[0];
		base.gameObject.name = text + string.Format("_{0}", idx);
		int id = base.transform.GetComponent<ViewPoolObject>().Id;
		Util.CallMethod("UIHelper", "ReceiveScrollCellMessage", new object[]
		{
			base.transform,
			idx,
			id,
			text
		});
	}
}
