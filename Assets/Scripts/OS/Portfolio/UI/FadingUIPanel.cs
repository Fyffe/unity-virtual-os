using OS.Utilities.Tweening;
using OS.Utilities.UI;
using UnityEngine;

namespace OS.Portfolio.UI
{
    public class FadingUIPanel : UIPanel
    {
        [Header("References")]
        [SerializeField] private CanvasGroup _canvasGroup;
        
        [Header("Parameters")]
        [SerializeField] private float _showTweenDuration = 0.25f;
        [SerializeField] private float _hideTweenDuration = 0.2f;

        private CanvasGroupAlphaTween _showTween;
        private CanvasGroupAlphaTween _hideTween;

        public override void Toggle(bool isEnabled)
        {
            if (isEnabled)
            {
                _canvas.enabled = true;
                
                _showTween = new CanvasGroupAlphaTween(_canvasGroup, 1f, _showTweenDuration);
                
                _hideTween?.Stop();
                _showTween.Start();
            }
            else
            {
                _hideTween = new CanvasGroupAlphaTween(_canvasGroup, 0f, _hideTweenDuration);
                _hideTween.OnDone += OnHideDone;

                _showTween?.Stop();
                _hideTween.Start();
            }
        }

        private void OnHideDone()
        {
            _canvas.enabled = false;
        }
    }
}
