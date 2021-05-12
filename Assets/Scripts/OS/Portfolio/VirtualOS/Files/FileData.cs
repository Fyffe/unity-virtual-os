using System;
using OS.Utilities;
using UnityEngine;

namespace OS.Portfolio.VirtualOS.Files
{
	[Serializable]
	public class FileData
	{
		public long Id = Helpers.RandomLong();
		public EFileType Type = EFileType.UNDEFINED;
		public long ContainerId = -1;
		public Vector2 ScreenPosition;
		public string Name = "New File";
		public string IconName;
		public string Action;
	}
}
