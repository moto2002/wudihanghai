using LuaFramework;
using LuaInterface;
using System;
using System.Collections.Generic;

public class SocketCommand : ControllerCommand
{
	public override void Execute(IMessage message)
	{
		object body = message.Body;
		if (body == null)
		{
			return;
		}
		KeyValuePair<int, LuaByteBuffer> keyValuePair = (KeyValuePair<int, LuaByteBuffer>)body;
		int key = keyValuePair.Key;
		Util.CallMethod("Network", "OnSocket", new object[]
		{
			keyValuePair.Key,
			keyValuePair.Value
		});
	}
}
