using OS.Core;

namespace OS.Portfolio.VirtualOS.UI.Popups.Signals
{
	public class ShowPopupSignal : Signal<IPopupData>
	{
		public IPopupData Data => Value;
	
		public ShowPopupSignal(IPopupData data) : base(data) { }
	}
}