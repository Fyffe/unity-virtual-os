namespace OS.Portfolio.VirtualOS.UI
{
	public interface IHighlightable
	{
		bool IsHighlighted { get; }
		
		void Highlight();
		void StopHighlighting();
	}
}
