using System;
using System.Collections.Generic;

public class Controller : IController
{
	protected IDictionary<string, Type> m_commandMap;

	protected IDictionary<IView, List<string>> m_viewCmdMap;

	protected static volatile IController m_instance;

	protected readonly object m_syncRoot = new object();

	protected static readonly object m_staticSyncRoot;

	public static IController Instance
	{
		get
		{
			if (Controller.m_instance == null)
			{
				object staticSyncRoot = Controller.m_staticSyncRoot;
				lock (staticSyncRoot)
				{
					if (Controller.m_instance == null)
					{
						Controller.m_instance = new Controller();
					}
				}
			}
			return Controller.m_instance;
		}
	}

	protected Controller()
	{
		this.InitializeController();
	}

	static Controller()
	{
		Controller.m_staticSyncRoot = new object();
	}

	protected virtual void InitializeController()
	{
		this.m_commandMap = new Dictionary<string, Type>();
		this.m_viewCmdMap = new Dictionary<IView, List<string>>();
	}

	public virtual void ExecuteCommand(IMessage note)
	{
		Type type = null;
		List<IView> list = null;
		object syncRoot = this.m_syncRoot;
		lock (syncRoot)
		{
			if (this.m_commandMap.ContainsKey(note.Name))
			{
				type = this.m_commandMap[note.Name];
			}
			else
			{
				list = new List<IView>();
				foreach (KeyValuePair<IView, List<string>> current in this.m_viewCmdMap)
				{
					if (current.Value.Contains(note.Name))
					{
						list.Add(current.Key);
					}
				}
			}
		}
		if (type != null)
		{
			object obj = Activator.CreateInstance(type);
			if (obj is ICommand)
			{
				((ICommand)obj).Execute(note);
			}
		}
		if (list != null && list.Count > 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i].OnMessage(note);
			}
			list = null;
		}
	}

	public virtual void RegisterCommand(string commandName, Type commandType)
	{
		object syncRoot = this.m_syncRoot;
		lock (syncRoot)
		{
			this.m_commandMap[commandName] = commandType;
		}
	}

	public virtual void RegisterViewCommand(IView view, string[] commandNames)
	{
		object syncRoot = this.m_syncRoot;
		lock (syncRoot)
		{
			if (this.m_viewCmdMap.ContainsKey(view))
			{
				List<string> list = null;
				if (this.m_viewCmdMap.TryGetValue(view, out list))
				{
					for (int i = 0; i < commandNames.Length; i++)
					{
						if (!list.Contains(commandNames[i]))
						{
							list.Add(commandNames[i]);
						}
					}
				}
			}
			else
			{
				this.m_viewCmdMap.Add(view, new List<string>(commandNames));
			}
		}
	}

	public virtual bool HasCommand(string commandName)
	{
		object syncRoot = this.m_syncRoot;
		bool result;
		lock (syncRoot)
		{
			result = this.m_commandMap.ContainsKey(commandName);
		}
		return result;
	}

	public virtual void RemoveCommand(string commandName)
	{
		object syncRoot = this.m_syncRoot;
		lock (syncRoot)
		{
			if (this.m_commandMap.ContainsKey(commandName))
			{
				this.m_commandMap.Remove(commandName);
			}
		}
	}

	public virtual void RemoveViewCommand(IView view, string[] commandNames)
	{
		object syncRoot = this.m_syncRoot;
		lock (syncRoot)
		{
			if (this.m_viewCmdMap.ContainsKey(view))
			{
				List<string> list = null;
				if (this.m_viewCmdMap.TryGetValue(view, out list))
				{
					for (int i = 0; i < commandNames.Length; i++)
					{
						if (list.Contains(commandNames[i]))
						{
							list.Remove(commandNames[i]);
						}
					}
				}
			}
		}
	}
}
