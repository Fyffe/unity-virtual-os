using OS.Core;
using UnityEngine;

namespace OS.Portfolio.VirtualOS.Files
{
    [CreateAssetMenu(fileName = "Inst_VirtualOS_IconsManager", menuName = "Portfolio/Installers/Virtual OS/Icons Manager Installer")]
    public class IconsManagerInstaller : ScriptableInstaller
    {
        [SerializeField] private IconsManagerSettings _settings;
        
        protected override void HandleBindings()
        {
            Container.BindInstance(_settings).AsSingle();
            
            Container.Bind<IIconsProvider>().To<IconsManager>().AsSingle();
        }
    }
}
