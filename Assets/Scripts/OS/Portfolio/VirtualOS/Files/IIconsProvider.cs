using UnityEngine;

namespace OS.Portfolio.VirtualOS.Files
{
	public interface IIconsProvider
	{
		public Sprite GetIcon(string name);
	}
}
