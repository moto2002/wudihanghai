using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace LuaInterface
{
	public class LuaException : Exception
	{
		public static Exception luaStack;

		public static string projectFolder;

		public static int InstantiateCount;

		public static int SendMsgCount;

		protected string _stack = string.Empty;

		public override string StackTrace
		{
			get
			{
				return this._stack;
			}
		}

		public LuaException(string msg, Exception e = null, int skip = 1) : base(msg)
		{
			if (e != null)
			{
				if (e is LuaException)
				{
					this._stack = e.StackTrace;
				}
				else
				{
					StackTrace stackTrace = new StackTrace(e, true);
					StringBuilder stringBuilder = new StringBuilder();
					LuaException.ExtractFormattedStackTrace(stackTrace, stringBuilder, null);
					StackTrace trace = new StackTrace(skip, true);
					LuaException.ExtractFormattedStackTrace(trace, stringBuilder, stackTrace);
					this._stack = stringBuilder.ToString();
				}
			}
			else
			{
				StackTrace trace2 = new StackTrace(skip, true);
				StringBuilder stringBuilder2 = new StringBuilder();
				LuaException.ExtractFormattedStackTrace(trace2, stringBuilder2, null);
				this._stack = stringBuilder2.ToString();
			}
		}

		public static Exception GetLastError()
		{
			Exception result = LuaException.luaStack;
			LuaException.luaStack = null;
			return result;
		}

		public static void ExtractFormattedStackTrace(StackTrace trace, StringBuilder sb, StackTrace skip = null)
		{
			int num = 0;
			if (skip != null && skip.FrameCount > 0)
			{
				MethodBase method = skip.GetFrame(skip.FrameCount - 1).GetMethod();
				for (int i = 0; i < trace.FrameCount; i++)
				{
					StackFrame frame = trace.GetFrame(i);
					MethodBase method2 = frame.GetMethod();
					if (method2 == method)
					{
						num = i + 1;
						break;
					}
				}
				sb.AppendLineEx(string.Empty);
			}
			for (int j = num; j < trace.FrameCount; j++)
			{
				StackFrame frame2 = trace.GetFrame(j);
				MethodBase method3 = frame2.GetMethod();
				if (method3 != null && method3.DeclaringType != null)
				{
					Type declaringType = method3.DeclaringType;
					string @namespace = declaringType.Namespace;
					if ((LuaException.InstantiateCount == 0 && declaringType == typeof(UnityEngine.Object) && method3.Name == "Instantiate") || (LuaException.SendMsgCount == 0 && declaringType == typeof(GameObject) && method3.Name == "SendMessage"))
					{
						break;
					}
					if (@namespace != null && @namespace.Length != 0)
					{
						sb.Append(@namespace);
						sb.Append(".");
					}
					sb.Append(declaringType.Name);
					sb.Append(":");
					sb.Append(method3.Name);
					sb.Append("(");
					int k = 0;
					ParameterInfo[] parameters = method3.GetParameters();
					bool flag = true;
					while (k < parameters.Length)
					{
						if (!flag)
						{
							sb.Append(", ");
						}
						else
						{
							flag = false;
						}
						sb.Append(parameters[k].ParameterType.Name);
						k++;
					}
					sb.Append(")");
					string text = frame2.GetFileName();
					if (text != null)
					{
						text = text.Replace('\\', '/');
						sb.Append(" (at ");
						if (text.StartsWith(LuaException.projectFolder))
						{
							text = text.Substring(LuaException.projectFolder.Length, text.Length - LuaException.projectFolder.Length);
						}
						sb.Append(text);
						sb.Append(":");
						sb.Append(frame2.GetFileLineNumber().ToString());
						sb.Append(")");
					}
					if (j != trace.FrameCount - 1)
					{
						sb.Append("\n");
					}
				}
			}
		}

		public static void Init()
		{
			Type typeFromHandle = typeof(StackTraceUtility);
			FieldInfo field = typeFromHandle.GetField("projectFolder", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			LuaException.projectFolder = (string)field.GetValue(null);
			LuaException.projectFolder = LuaException.projectFolder.Replace('\\', '/');
		}
	}
}
