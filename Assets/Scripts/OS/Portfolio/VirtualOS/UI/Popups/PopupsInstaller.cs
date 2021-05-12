using OS.Core;
using OS.Portfolio.VirtualOS.UI.Popups.Signals;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Popups
{
    [CreateAssetMenu(fileName = "Inst_VirtualOS_Popups", menuName = "Portfolio/Installers/Virtual OS/Popups Installer")]
    public class PopupsInstaller : ScriptableInstaller
    {
        [SerializeField] private AskPopup _askPopupPrefab;
        
        protected override void HandleBindings()
        {
            Container.BindFactory<IPopupData, AskPopup, AskPopup.Factory>().FromComponentInNewPrefab(_askPopupPrefab).AsSingle();

            Container.Bind<PopupsManager>().AsSingle().NonLazy();
        }

        protected override void HandleSignals()
        {
            Container.DeclareSignal<ShowPopupSignal>();
        }
    }
}
