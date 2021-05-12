using UnityEngine;
using UnityEngine.U2D;

namespace OS.Portfolio.VirtualOS.Files
{
	[CreateAssetMenu(fileName = "Set_IconsManager", menuName = "Portfolio/Virtual OS/Icons Manager Settings")]
	public class IconsManagerSettings : ScriptableObject
	{
		public SpriteAtlas SpriteAtlas;
		public string DefaultIconName;
	}
}
