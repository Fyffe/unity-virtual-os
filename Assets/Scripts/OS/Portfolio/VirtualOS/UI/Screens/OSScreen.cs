using OS.Portfolio.VirtualOS.UI.Signals;
using OS.Utilities.Tweening;
using OS.Utilities.UI;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Screens
{
	public abstract class OSScreen : MonoBehaviour, ITogglable
	{
		public bool IsShown { get; protected set; }

		public virtual EScreenType ScreenType => EScreenType.Undefined;
		
		[Header("References")]
		[SerializeField] protected CanvasGroup _canvasGroup;

		public void Toggle()
		{
			if (IsShown)
			{
				Hide();
			}
			else
			{
				Show();
			}
		}

		public abstract void Initialize();
		public abstract void Show();
		public abstract void Hide();
	}
}
