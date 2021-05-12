using System.ComponentModel;
using OS.Core;
using OS.Portfolio.VirtualOS.Files;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Files
{
	[CreateAssetMenu(fileName = "Inst_VirtualOS_UI_Files", menuName = "Portfolio/Installers/Virtual OS/Files UI Installer")]
	public class FilesInstaller : ScriptableInstaller
	{
		[SerializeField] private File _filePrefab;
		
		protected override void HandleBindings()
		{
			Container.BindFactory<FileConstructor, File, File.Factory>().FromMonoPoolableMemoryPool(pool => pool.WithInitialSize(5)
			                                                                                                    .FromComponentInNewPrefab(_filePrefab)
			                                                                                                    .UnderTransformGroup("Files_Pool"));
		}

	}
}
