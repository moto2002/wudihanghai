using System;
using System.Collections.Generic;
using UnityEngine;

public class Facade
{
	protected IController m_controller;

	private static GameObject m_GameManager;

	private static Dictionary<string, object> m_Managers = new Dictionary<string, object>();

	private GameObject AppGameManager
	{
		get
		{
			if (Facade.m_GameManager == null)
			{
				Facade.m_GameManager = GameObject.Find("GameManager");
			}
			return Facade.m_GameManager;
		}
	}

	protected Facade()
	{
		this.InitFramework();
	}

	protected virtual void InitFramework()
	{
		if (this.m_controller != null)
		{
			return;
		}
		this.m_controller = Controller.Instance;
	}

	public virtual void RegisterCommand(string commandName, Type commandType)
	{
		this.m_controller.RegisterCommand(commandName, commandType);
	}

	public virtual void RemoveCommand(string commandName)
	{
		this.m_controller.RemoveCommand(commandName);
	}

	public virtual bool HasCommand(string commandName)
	{
		return this.m_controller.HasCommand(commandName);
	}

	public void RegisterMultiCommand(Type commandType, params string[] commandNames)
	{
		int num = commandNames.Length;
		for (int i = 0; i < num; i++)
		{
			this.RegisterCommand(commandNames[i], commandType);
		}
	}

	public void RemoveMultiCommand(params string[] commandName)
	{
		int num = commandName.Length;
		for (int i = 0; i < num; i++)
		{
			this.RemoveCommand(commandName[i]);
		}
	}

	public void SendMessageCommand(string message, object body = null)
	{
		this.m_controller.ExecuteCommand(new Message(message, body));
	}

	public void AddManager(string typeName, object obj)
	{
		if (!Facade.m_Managers.ContainsKey(typeName))
		{
			Facade.m_Managers.Add(typeName, obj);
		}
	}

	public T AddManager<T>(string typeName) where T : Component
	{
		object obj = null;
		Facade.m_Managers.TryGetValue(typeName, out obj);
		if (obj != null)
		{
			return (T)((object)obj);
		}
		Component value = this.AppGameManager.AddComponent<T>();
		Facade.m_Managers.Add(typeName, value);
		return (T)((object)null);
	}

	public T GetManager<T>(string typeName) where T : class
	{
		if (!Facade.m_Managers.ContainsKey(typeName))
		{
			return (T)((object)null);
		}
		object obj = null;
		Facade.m_Managers.TryGetValue(typeName, out obj);
		return (T)((object)obj);
	}

	public void RemoveManager(string typeName)
	{
		if (!Facade.m_Managers.ContainsKey(typeName))
		{
			return;
		}
		object obj = null;
		Facade.m_Managers.TryGetValue(typeName, out obj);
		Type type = obj.GetType();
		if (type.IsSubclassOf(typeof(MonoBehaviour)))
		{
			UnityEngine.Object.Destroy((Component)obj);
		}
		Facade.m_Managers.Remove(typeName);
	}
}
