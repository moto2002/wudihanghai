using System;
using System.Text;
using UnityEngine;

namespace LuaInterface
{
	public static class Debugger
	{
		public static bool useLog = true;

		public static string threadStack = string.Empty;

		public static ILogger logger = null;

		private static string GetLogFormat(string str)
		{
			StringBuilder arg_10_0 = StringBuilderCache.Acquire(256);
			DateTime now = DateTime.Now;
			arg_10_0.Append(now.Hour);
			arg_10_0.Append(":");
			arg_10_0.Append(now.Minute);
			arg_10_0.Append(":");
			arg_10_0.Append(now.Second);
			arg_10_0.Append(".");
			arg_10_0.Append(now.Millisecond);
			arg_10_0.Append("-");
			arg_10_0.Append(Time.frameCount % 999);
			arg_10_0.Append(": ");
			arg_10_0.Append(str);
			return StringBuilderCache.GetStringAndRelease(arg_10_0);
		}

		public static void Log(string str)
		{
			str = Debugger.GetLogFormat(str);
			if (Debugger.useLog)
			{
				Debug.Log(str);
				return;
			}
			if (Debugger.logger != null)
			{
				Debugger.logger.Log(str, string.Empty, LogType.Log);
			}
		}

		public static void Log(object message)
		{
			Debugger.Log(message.ToString());
		}

		public static void Log(string str, object arg0)
		{
			Debugger.Log(string.Format(str, arg0));
		}

		public static void Log(string str, object arg0, object arg1)
		{
			Debugger.Log(string.Format(str, arg0, arg1));
		}

		public static void Log(string str, object arg0, object arg1, object arg2)
		{
			Debugger.Log(string.Format(str, arg0, arg1, arg2));
		}

		public static void Log(string str, params object[] param)
		{
			Debugger.Log(string.Format(str, param));
		}

		public static void LogWarning(string str)
		{
			str = Debugger.GetLogFormat(str);
			if (Debugger.useLog)
			{
				Debug.LogWarning(str);
				return;
			}
			if (Debugger.logger != null)
			{
				string stack = StackTraceUtility.ExtractStackTrace();
				Debugger.logger.Log(str, stack, LogType.Warning);
			}
		}

		public static void LogWarning(object message)
		{
			Debugger.LogWarning(message.ToString());
		}

		public static void LogWarning(string str, object arg0)
		{
			Debugger.LogWarning(string.Format(str, arg0));
		}

		public static void LogWarning(string str, object arg0, object arg1)
		{
			Debugger.LogWarning(string.Format(str, arg0, arg1));
		}

		public static void LogWarning(string str, object arg0, object arg1, object arg2)
		{
			Debugger.LogWarning(string.Format(str, arg0, arg1, arg2));
		}

		public static void LogWarning(string str, params object[] param)
		{
			Debugger.LogWarning(string.Format(str, param));
		}

		public static void LogError(string str)
		{
			str = Debugger.GetLogFormat(str);
			if (Debugger.useLog)
			{
				Debug.LogError(str);
				return;
			}
			if (Debugger.logger != null)
			{
				string stack = StackTraceUtility.ExtractStackTrace();
				Debugger.logger.Log(str, stack, LogType.Error);
			}
		}

		public static void LogError(object message)
		{
			Debugger.LogError(message.ToString());
		}

		public static void LogError(string str, object arg0)
		{
			Debugger.LogError(string.Format(str, arg0));
		}

		public static void LogError(string str, object arg0, object arg1)
		{
			Debugger.LogError(string.Format(str, arg0, arg1));
		}

		public static void LogError(string str, object arg0, object arg1, object arg2)
		{
			Debugger.LogError(string.Format(str, arg0, arg1, arg2));
		}

		public static void LogError(string str, params object[] param)
		{
			Debugger.LogError(string.Format(str, param));
		}

		public static void LogException(Exception e)
		{
			Debugger.threadStack = e.StackTrace;
			string logFormat = Debugger.GetLogFormat(e.Message);
			if (Debugger.useLog)
			{
				Debug.LogError(logFormat);
				return;
			}
			if (Debugger.logger != null)
			{
				Debugger.logger.Log(logFormat, Debugger.threadStack, LogType.Exception);
			}
		}

		public static void LogException(string str, Exception e)
		{
			Debugger.threadStack = e.StackTrace;
			str = Debugger.GetLogFormat(str + e.Message);
			if (Debugger.useLog)
			{
				Debug.LogError(str);
				return;
			}
			if (Debugger.logger != null)
			{
				Debugger.logger.Log(str, Debugger.threadStack, LogType.Exception);
			}
		}
	}
}
