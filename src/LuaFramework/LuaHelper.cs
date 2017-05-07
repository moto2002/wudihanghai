using Hummingbird.Model;
using LuaInterface;
using System;
using System.Reflection;
using UnityEngine;

namespace LuaFramework
{
	public static class LuaHelper
	{
		public static Type GetType(string classname)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Type type = executingAssembly.GetType(classname);
			if (type == null)
			{
				type = executingAssembly.GetType(classname);
			}
			return type;
		}

		public static PrefabLoader GetPrefabLoader()
		{
			return AppFacade.Instance.GetManager<PrefabLoader>("PrefabLoader");
		}

		public static ResourceManager GetResManager()
		{
			return AppFacade.Instance.GetManager<ResourceManager>("ResourceManager");
		}

		public static NetworkManager GetNetManager()
		{
			return AppFacade.Instance.GetManager<NetworkManager>("NetworkManager");
		}

		public static SoundManager GetSoundManager()
		{
			return AppFacade.Instance.GetManager<SoundManager>("SoundManager");
		}

		public static DeviceDrainModel GetDeviceDrainModel()
		{
			return AppFacade.Instance.GetManager<DeviceDrainModel>("DeviceDrainModel");
		}

		public static void OnCallLuaFunc(LuaByteBuffer data, LuaFunction func)
		{
			if (func != null)
			{
				func.Call(new object[]
				{
					data
				});
			}
			Debug.LogWarning("OnCallLuaFunc length:>>" + data.buffer.Length);
		}

		public static void OnJsonCallFunc(string data, LuaFunction func)
		{
			Debug.LogWarning(string.Concat(new object[]
			{
				"OnJsonCallback data:>>",
				data,
				" lenght:>>",
				data.Length
			}));
			if (func != null)
			{
				func.Call(new object[]
				{
					data
				});
			}
		}
	}
}
