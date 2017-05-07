using LuaInterface;
using System;
using UnityEngine;

public class LuaLooper : MonoBehaviour
{
	public LuaState luaState;

	public LuaBeatEvent UpdateEvent
	{
		get;
		private set;
	}

	public LuaBeatEvent LateUpdateEvent
	{
		get;
		private set;
	}

	public LuaBeatEvent FixedUpdateEvent
	{
		get;
		private set;
	}

	private void Start()
	{
		try
		{
			this.UpdateEvent = this.GetEvent("UpdateBeat");
			this.LateUpdateEvent = this.GetEvent("LateUpdateBeat");
			this.FixedUpdateEvent = this.GetEvent("FixedUpdateBeat");
		}
		catch (Exception ex)
		{
			UnityEngine.Object.Destroy(this);
			throw ex;
		}
	}

	private LuaBeatEvent GetEvent(string name)
	{
		LuaTable table = this.luaState.GetTable(name, true);
		if (table == null)
		{
			throw new LuaException(string.Format("Lua table {0} not exists", name), null, 1);
		}
		LuaBeatEvent result = new LuaBeatEvent(table);
		table.Dispose();
		return result;
	}

	private void ThrowException()
	{
		string msg = this.luaState.LuaToString(-1);
		this.luaState.LuaPop(2);
		throw new LuaException(msg, LuaException.GetLastError(), 1);
	}

	private void Update()
	{
		if (this.luaState.LuaUpdate(Time.deltaTime, Time.unscaledDeltaTime) != 0)
		{
			this.ThrowException();
		}
		this.luaState.LuaPop(1);
		this.luaState.Collect();
	}

	private void LateUpdate()
	{
		if (this.luaState.LuaLateUpdate() != 0)
		{
			this.ThrowException();
		}
		this.luaState.LuaPop(1);
	}

	private void FixedUpdate()
	{
		if (this.luaState.LuaFixedUpdate(Time.fixedDeltaTime) != 0)
		{
			this.ThrowException();
		}
		this.luaState.LuaPop(1);
	}

	public void Destroy()
	{
		if (this.luaState != null)
		{
			if (this.UpdateEvent != null)
			{
				this.UpdateEvent.Dispose();
				this.UpdateEvent = null;
			}
			if (this.LateUpdateEvent != null)
			{
				this.LateUpdateEvent.Dispose();
				this.LateUpdateEvent = null;
			}
			if (this.FixedUpdateEvent != null)
			{
				this.FixedUpdateEvent.Dispose();
				this.FixedUpdateEvent = null;
			}
			this.luaState = null;
		}
	}

	private void OnDestroy()
	{
		if (this.luaState != null)
		{
			this.Destroy();
		}
	}
}
