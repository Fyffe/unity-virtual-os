using System;
using OS.Portfolio.VirtualOS.Signals;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS.Files
{
	public class ActionsManager
	{
		[Inject] private readonly SignalBus _signalBus;

		[Inject]
		private void Construct()
		{
			_signalBus.Subscribe<TriggerFileActionSignal>(OnTriggerFileAction);
		}

		private void OnTriggerFileAction(TriggerFileActionSignal signal)
		{
			switch(signal.FileType)
			{
				case EFileType.FOLDER:
					
					break;
				case EFileType.WINDOW:
					
					break;
				case EFileType.LINK:
					Application.OpenURL(signal.Arguments);
					break;
			}
		}
	}
}
