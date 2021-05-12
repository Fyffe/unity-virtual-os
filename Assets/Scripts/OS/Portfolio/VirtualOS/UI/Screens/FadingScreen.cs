using OS.Utilities.Tweening;
using UnityEngine;

namespace OS.Portfolio.VirtualOS.UI.Screens
{
	public class FadingScreen : OSScreen
	{
		[Header("Parameters")]
		[SerializeField] private float _showDuration;
		[SerializeField] private float _hideDuration;

		protected CanvasGroupAlphaTween _showTween;
		protected CanvasGroupAlphaTween _hideTween;
		
		public override void Initialize()
		{	
			_showTween = new CanvasGroupAlphaTween(_canvasGroup, 0f, 1f, _showDuration);
			_hideTween = new CanvasGroupAlphaTween(_canvasGroup, 1f, 0f, _hideDuration) { OnDone = OnHidden };
		}
		
		public override void Show()
		{
			if (_showTween.IsRunning)
			{
				return;
			}
			
			_hideTween.Stop();
			_showTween.StartFromCurrent();

			_canvasGroup.blocksRaycasts = true;
			
			IsShown = true;
		}

		public override void Hide()
		{
			if (_hideTween.IsRunning)
			{
				return;
			}
			
			_showTween.Stop();
			_hideTween.OnDone = OnHidden;
			_hideTween.StartFromCurrent();
		}

        
		protected virtual void OnHidden()
		{
			_canvasGroup.blocksRaycasts = false;

			IsShown = false;
		}
	}
}
