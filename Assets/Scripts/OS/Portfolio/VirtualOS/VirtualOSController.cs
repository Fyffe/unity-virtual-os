using OS.Core;
using OS.Portfolio.VirtualOS.Signals;
using OS.Portfolio.VirtualOS.UI.Screens;
using OS.Portfolio.VirtualOS.UI.Signals;
using Zenject;

namespace OS.Portfolio.VirtualOS
{
	public class VirtualOSController : IModule
	{
		public bool IsInitialized { get; private set; }
		public string Name => "Virtual OS";
		public int Priority => ModulePriorities.VIRTUAL_OS;

		[Inject] private readonly SignalBus _signalBus;
		
		public void Initialize()
		{
			_signalBus.Subscribe<LockAccountSignal>(OnLockAccount);
			_signalBus.Subscribe<UnlockScreenSignal>(OnUnlockScreen);
			_signalBus.Subscribe<SignInSignal>(OnSignIn);
			
			IsInitialized = true;
		}

		public void CleanUp()
		{
			IsInitialized = false;
		}

		private void OnLockAccount()
		{
			_signalBus.Fire(new ShowScreenSignal(EScreenType.LockScreen));
		}

		private void OnUnlockScreen()
		{
			_signalBus.Fire(new ShowScreenSignal(EScreenType.LoginScreen));
		}

		private void OnSignIn()
		{
			_signalBus.Fire(new ShowScreenSignal(EScreenType.MainScreen));
		}
	}
}
