using System.Collections.Generic;
using OS.Core;
using OS.Portfolio.VirtualOS.UI.Screens;
using OS.Portfolio.VirtualOS.UI.Signals;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI
{
    [CreateAssetMenu(fileName = "Inst_VirtualOS_UI", menuName = "Portfolio/Installers/Virtual OS/UI Installer")]
    public class VirtualOSUIInstaller : ScriptableInstaller
    {
        public Canvas OSCanvas;
        public List<OSScreen> Screens = new List<OSScreen>();
        
        protected override void HandleBindings()
        {
            Container.Bind<Canvas>().WithId(ScreensConfig.OS_CANVAS_ID).FromComponentInNewPrefab(OSCanvas).AsSingle();
            Container.BindInstance(Screens).AsTransient();

            Container.Bind<ScreensManager>().AsSingle().NonLazy();
        }

        protected override void HandleSignals()
        {
            Container.DeclareSignal<ShowScreenSignal>();
        }
    }
}
