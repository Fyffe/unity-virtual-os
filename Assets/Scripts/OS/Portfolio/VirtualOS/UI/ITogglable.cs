namespace OS.Portfolio.VirtualOS.UI
{
    public interface ITogglable
    {
        bool IsShown { get; }

        void Toggle();
        void Show();
        void Hide();
    }
}
