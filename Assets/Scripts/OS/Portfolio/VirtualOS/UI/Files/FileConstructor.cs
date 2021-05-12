using OS.Portfolio.VirtualOS.Files;
using UnityEngine;

namespace OS.Portfolio.VirtualOS.UI.Files
{
    public readonly struct FileConstructor
    {
        public readonly FileData FileData;
        public readonly Sprite Icon;
        
        public FileConstructor(FileData fileData, Sprite icon)
        {
            FileData = fileData;
            Icon = icon;
        }
    }
}
