using System;
using System.Collections.Generic;
using OS.Portfolio.VirtualOS.UI.Popups.Data;
using OS.Portfolio.VirtualOS.UI.Popups.Signals;
using OS.Portfolio.VirtualOS.UI.Screens;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Popups
{
    public class PopupsManager
    {
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly AskPopup.Factory _askPopupFactory;
        [Inject(Id = ScreensConfig.OS_CANVAS_ID)] private readonly Canvas _canvas;

        private readonly Dictionary<Type, IFactory<IPopupData, Popup>> _typeToFactory = new Dictionary<Type, IFactory<IPopupData, Popup>>();

        [Inject]
        private void Construct()
        {
            _typeToFactory.Add(typeof(AskPopupData), _askPopupFactory);

            _signalBus.Subscribe<ShowPopupSignal>(OnShowPopup);
        }

        private void OnShowPopup(ShowPopupSignal signal)
        {
            IPopupData data = signal.Data;

            if (!_typeToFactory.TryGetValue(data.GetType(), out IFactory<IPopupData, Popup> factory))
            {
                return;
            }

            Popup popupInstance = factory.Create(data);
            
            popupInstance.transform.SetParent(_canvas.transform, false);
            
            popupInstance.Canvas.overrideSorting = PopupsConfig.OVERRIDE_SORTING != 0;
            popupInstance.Canvas.sortingOrder = PopupsConfig.OVERRIDE_SORTING;
            
            popupInstance.Show();
        }
    }
}
