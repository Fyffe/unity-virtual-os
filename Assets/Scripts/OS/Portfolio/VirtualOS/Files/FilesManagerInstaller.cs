using OS.Core;
using UnityEngine;

namespace OS.Portfolio.VirtualOS.Files
{
	[CreateAssetMenu(fileName = "Inst_VirtualOS_FilesManager", menuName = "Portfolio/Installers/Virtual OS/Files Manager Installer")]
	public class FilesManagerInstaller : ScriptableInstaller
	{
		protected override void HandleBindings()
		{
			Container.Bind<IFilesManager>().To<FilesManager>().AsSingle();
		}
	}
}
