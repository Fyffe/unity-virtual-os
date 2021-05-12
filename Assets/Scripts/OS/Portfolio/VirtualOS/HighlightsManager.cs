using System.Collections.Generic;
using OS.Portfolio.VirtualOS.Signals;
using OS.Portfolio.VirtualOS.UI.Files;
using OS.Utilities;
using OS.Utilities.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace OS.Portfolio.VirtualOS
{
	public class HighlightsManager : ITickable
	{
		[Inject] private readonly SignalBus _signalBus;
		
		private readonly List<File> _highlightedFiles = new List<File>();
		private readonly List<File> _filesToStop = new List<File>();
		
		[Inject]
		private void Construct()
		{
			_signalBus.Subscribe<HighlightFileSignal>(OnHighlightFile);
		}

		public void Tick()
		{
			if (_highlightedFiles.IsNullOrEmpty())
			{
				return;
			}

			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
			{
				bool hasClickedFile = false;
				
				foreach (File file in _highlightedFiles)
				{
					if (EventSystem.current.IsPointerOverSpecificGameObject(file.gameObject))
					{
						continue;
					}

					_filesToStop.Add(file);
					
					hasClickedFile = true;
				}

				if (!hasClickedFile)
				{
					_filesToStop.AddRange(_highlightedFiles);
				}
			}

			if (_filesToStop.IsNullOrEmpty())
			{
				return;
			}

			foreach (File file in _filesToStop)
			{
				file.StopHighlighting();
				
				_highlightedFiles.Remove(file);
			}
			
			_filesToStop.Clear();
		}

		private void OnHighlightFile(HighlightFileSignal signal)
		{
			if (_highlightedFiles.Contains(signal.File))
			{
				return;
			}
			
			_highlightedFiles.Add(signal.File);
			
			signal.File.Highlight();
		}
	}
}
