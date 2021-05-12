using System;

namespace OS.Portfolio.VirtualOS.UI.Popups
{
	public readonly struct PopupButtonData
	{
		public readonly string Text;
		public readonly Action Action;
		
		public PopupButtonData(string text, Action action)
		{
			Text = text;
			Action = action;
		}
	}
}
