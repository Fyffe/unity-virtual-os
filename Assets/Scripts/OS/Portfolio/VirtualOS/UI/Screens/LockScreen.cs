using OS.Portfolio.VirtualOS.Signals;
using OS.Utilities.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Screens
{
    public class LockScreen : FadingScreen
    {
        public override EScreenType ScreenType => EScreenType.LockScreen;

        [Inject] private readonly SignalBus _signalBus;
        
        [SerializeField] private Button _unlockButton;
        
        public override void Initialize()
        {
            base.Initialize();

            _unlockButton.onClick.AddListener(OnUnlockPressed);
        }

        private void OnUnlockPressed()
        {
            _signalBus.Fire(new UnlockScreenSignal());
        }
    }
}
