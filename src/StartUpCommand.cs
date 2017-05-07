using Hummingbird.Model;
using LuaFramework;
using System;

public class StartUpCommand : ControllerCommand
{
	public override void Execute(IMessage message)
	{
		AppFacade.Instance.RegisterCommand("DispatchMessage", typeof(SocketCommand));
		AppFacade.Instance.AddManager<LuaManager>("LuaManager");
		AppFacade.Instance.AddManager<PrefabLoader>("PrefabLoader");
		AppFacade.Instance.AddManager<SoundManager>("SoundManager");
		AppFacade.Instance.AddManager<NetworkManager>("NetworkManager");
		AppFacade.Instance.AddManager<ResourceManager>("ResourceManager");
		AppFacade.Instance.AddManager<GameManager>("GameManager");
		AppFacade.Instance.AddManager<DeviceDrainModel>("DeviceDrainModel");
	}
}
