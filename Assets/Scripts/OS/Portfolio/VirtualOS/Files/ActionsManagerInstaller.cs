using OS.Core;
using OS.Portfolio.VirtualOS.Signals;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS.Files
{
	[CreateAssetMenu(fileName = "Inst_VirtualOS_ActionsManager", menuName = "Portfolio/Installers/Virtual OS/Actions Manager Installer")]
	public class ActionsManagerInstaller : ScriptableInstaller
	{
		protected override void HandleBindings()
		{
			Container.Bind<ActionsManager>().AsSingle().NonLazy();
		}

		protected override void HandleSignals()
		{
			Container.DeclareSignal<TriggerFileActionSignal>();
		}
	}
}
