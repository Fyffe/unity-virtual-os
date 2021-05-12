using OS.Core;
using OS.Portfolio.VirtualOS.Signals;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS
{
	[CreateAssetMenu(fileName = "Inst_VirtualOS", menuName = "Portfolio/Installers/Virtual OS/Installer")]
	public class VirtualOSInstaller : ScriptableInstaller
	{
		protected override void HandleBindings()
		{
			Container.Bind<VirtualOSController>().AsSingle().NonLazy();
			Container.Bind<IModule>().WithId(CoreConfig.INITIALIZE_ON_LOAD_ID).To<VirtualOSController>().FromResolve();
		}

		protected override void HandleSignals()
		{
			Container.DeclareSignal<LockAccountSignal>();
			Container.DeclareSignal<UnlockScreenSignal>();
			Container.DeclareSignal<SignInSignal>();
		}
	}
}
