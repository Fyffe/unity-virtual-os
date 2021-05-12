using OS.Core;
using OS.Portfolio.VirtualOS.UI.Screens;

namespace OS.Portfolio.VirtualOS.UI.Signals
{
    public class ShowScreenSignal : Signal<EScreenType>
    {
        public EScreenType ScreenType => Value;
        
        public ShowScreenSignal(EScreenType screenType) : base(screenType) { }
    }
}
