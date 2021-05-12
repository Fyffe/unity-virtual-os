using OS.Portfolio.VirtualOS.Files;
using OS.Portfolio.VirtualOS.UI.Files;
using OS.Utilities;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Screens
{
	public class MainScreen : FadingScreen
	{
		public override EScreenType ScreenType => EScreenType.MainScreen;

		[Inject] private readonly IFilesManager _filesManager;
		[Inject] private readonly IIconsProvider _iconsProvider;
		[Inject] private readonly File.Factory _fileFactory;

		[SerializeField] private Transform _desktopRoot;
		
		[SerializeField] private FilesProfile _defaultProfile;
		
		public override void Show()
		{
			if (_filesManager.LoadFromProfile(_defaultProfile))
			{
				foreach (FileData fileData in _filesManager.LoadedFiles.Files)
				{
					Sprite icon = _iconsProvider.GetIcon(fileData.IconName);
					FileConstructor constructor = new FileConstructor(fileData, icon);
					File file = _fileFactory.Create(constructor);
					
					file.RectTransform.SetParent(_desktopRoot);
					file.RectTransform.localScale = V3.One;
					file.RectTransform.anchoredPosition = fileData.ScreenPosition;
				}
			}

			base.Show();
		}
	}
}
