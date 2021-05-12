using UnityEngine;
using LogType = OS.Core.Logging.LogType;

namespace OS.Core.Logging
{
	/// <summary>
	/// Logging wrapper for <see cref="UnityEngine.Debug"/>.
	/// </summary>
	public static class Logger
	{
		public static void Log(string message, string tag = "", LogType type = LogType.Info)
		{
			if (!string.IsNullOrEmpty(tag))
			{
				message = $"<<OS.Logger>> | [{tag}] | {message}";
			}
			switch (type)
			{
				case LogType.Warning:
					Debug.LogWarning(message);
					break;
				case LogType.Error:
					Debug.LogError(message);
					break;
				case LogType.Info:
				default:
				{
					Debug.Log(message);
					break;
				}
			}
		}
	}
}
