using OS.Core;
using OS.Portfolio.VirtualOS.Signals;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS
{
	[CreateAssetMenu(fileName = "Inst_VirtualOS_Highlights", menuName = "Portfolio/Installers/Virtual OS/Highlights Installer")]
	public class HighlightsInstaller : ScriptableInstaller
	{
		protected override void HandleBindings()
		{
			Container.Bind<HighlightsManager>().AsSingle().NonLazy();
			Container.Bind<ITickable>().To<HighlightsManager>().FromResolve();
		}

		protected override void HandleSignals()
		{
			Container.DeclareSignal<HighlightFileSignal>();
		}
	}
}
