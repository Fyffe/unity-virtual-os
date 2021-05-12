using System.Collections.Generic;
using UnityEngine;

namespace OS.Portfolio.VirtualOS.Files
{
    [CreateAssetMenu(fileName = "Profile_Files", menuName = "Portfolio/Virtual OS/Files Profile")]
    public class FilesProfile : ScriptableObject
    {
        public FilesData FilesData;
    }
}
