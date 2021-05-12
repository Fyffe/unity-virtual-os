using UnityEngine;
using Zenject;

namespace OS.Core
{
	[CreateAssetMenu(fileName = "Inst_Signals", menuName = CoreConfig.INSTALLERS_PATH + "Signals Installer")]
	public class SignalsInstaller : ScriptableInstaller
	{
		protected override void HandleBindings()
		{
			SignalBusInstaller.Install(Container);
		}
	}
}
