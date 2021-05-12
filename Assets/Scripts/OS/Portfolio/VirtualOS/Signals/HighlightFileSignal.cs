using OS.Core;
using OS.Portfolio.VirtualOS.UI.Files;

namespace OS.Portfolio.VirtualOS.Signals
{
    public class HighlightFileSignal : Signal<File>
    {
        public File File => Value;
        
        public HighlightFileSignal(File file) : base(file) { }
    }
}
