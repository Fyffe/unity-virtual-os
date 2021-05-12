using OS.Core;
using OS.Portfolio.VirtualOS.Files;

namespace OS.Portfolio.VirtualOS.Signals
{
    public class TriggerFileActionSignal
    {
        public readonly EFileType FileType;
        public readonly string Arguments;
        
        public TriggerFileActionSignal(EFileType fileType, string arguments)
        {
            FileType = fileType;
            Arguments = arguments;
        }
    }
}
