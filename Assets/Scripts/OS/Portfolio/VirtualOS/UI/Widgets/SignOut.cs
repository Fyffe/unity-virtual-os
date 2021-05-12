using OS.Portfolio.VirtualOS.Signals;
using OS.Portfolio.VirtualOS.UI.Popups;
using OS.Portfolio.VirtualOS.UI.Popups.Data;
using OS.Portfolio.VirtualOS.UI.Popups.Signals;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Widgets
{
    public class SignOut : SideWidget
    {
        [Inject] private SignalBus _signalBus;

        private bool _isWaitingForResponse = false;
        
        public override void Show()
        {
            if (_isWaitingForResponse)
            {
                return;
            }
            
            _signalBus.Fire(new ShowPopupSignal(new AskPopupData("Are you sure you want to sign out?", "Sign Out", new PopupButtonData("Yes", OnYesPressed), new PopupButtonData("No", OnNoPressed))));
            
            _isWaitingForResponse = true;
        }

        public override void Hide() { }

        private void OnYesPressed()
        {
            _isWaitingForResponse = false;

            _signalBus.Fire(new LockAccountSignal());
        }

        private void OnNoPressed()
        {
            _isWaitingForResponse = false;
        }
    }
}
