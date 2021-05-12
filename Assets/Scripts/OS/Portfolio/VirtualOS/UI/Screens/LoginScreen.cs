using OS.Portfolio.VirtualOS.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Screens
{
    public class LoginScreen : FadingScreen
    {
        public override EScreenType ScreenType => EScreenType.LoginScreen;
        
        [Inject] private readonly SignalBus _signalBus;
        
        [SerializeField] private Button _signInButton;
        [SerializeField] private Button _backButton;
        
        public override void Initialize()
        {
            base.Initialize();

            _signInButton.onClick.AddListener(OnSignInPressed);
            _backButton.onClick.AddListener(OnBackPressed);
        }

        private void OnSignInPressed()
        {
            _signalBus.Fire(new SignInSignal());
        }
        
        private void OnBackPressed()
        {
            _signalBus.Fire(new LockAccountSignal());
        }
    }
}
