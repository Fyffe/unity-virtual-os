using System.Collections.Generic;
using OS.Portfolio.VirtualOS.UI.Signals;
using OS.Utilities;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Screens
{
	public class ScreensManager
	{
		[Inject] private readonly DiContainer _container;
		[Inject] private readonly SignalBus _signalBus;
		[Inject] private readonly List<OSScreen> _screenPrefabs;
		[Inject(Id = ScreensConfig.OS_CANVAS_ID)] private readonly Canvas _canvas;

		private readonly Dictionary<EScreenType, OSScreen> _screens = new Dictionary<EScreenType, OSScreen>();

		private EScreenType _currentScreen = EScreenType.LockScreen;

		[Inject]
		private void Construct()
		{
			foreach (OSScreen screen in _screenPrefabs)
			{
				OSScreen screenInstance = _container.InstantiatePrefabForComponent<OSScreen>(screen, _canvas.transform);
				
				screenInstance.transform.localPosition = V3.Zero;
				screenInstance.transform.localScale = V3.One;
				
				screenInstance.Initialize();

				if (screenInstance.ScreenType != _currentScreen)
				{
					screenInstance.Hide();
				}

				_screens.Add(screenInstance.ScreenType, screenInstance);
			}

			_signalBus.Subscribe<ShowScreenSignal>(OnShowScreen);
		}

		private void OnShowScreen(ShowScreenSignal signal)
		{
			if (_currentScreen == signal.ScreenType || !_screens.TryGetValue(signal.ScreenType, out OSScreen screen))
			{
				return;
			}

			if (_screens.TryGetValue(_currentScreen, out OSScreen currentScreen))
			{
				currentScreen.Hide();
			}

			screen.Show();

			_currentScreen = screen.ScreenType;
		}
	}
}
