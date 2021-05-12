using OS.Utilities.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace OS.Portfolio.VirtualOS.UI.Widgets
{
    public class SoundControl : SideWidget
    {
        [Header("References")] 
        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private Button _toggleButton;
        
        [SerializeField] private RectTransform _backgroundRectTransform;
        [SerializeField] private RectTransform _sliderRectTransform;
        
        [Header("Parameters")]
        [SerializeField] private float _showDuration;
        [SerializeField] private float _hideDuration;

        [SerializeField] private float _canvasGroupHiddenAlpha;
        [SerializeField] private float _canvasGroupShownAlpha;

        [SerializeField] private Vector3 _backgroundHiddenPosition;
        [SerializeField] private Vector3 _backgroundShownPosition;
        
        [SerializeField] private Vector3 _sliderHiddenPosition;
        [SerializeField] private Vector3 _sliderShownPosition;
        
        private CanvasGroupAlphaTween _canvasGroupShowTween;
        private CanvasGroupAlphaTween _canvasGroupHideTween;

        private RectTransformAnchoredPositionTween _backgroundPositionShowTween;
        private RectTransformAnchoredPositionTween _backgroundPositionHideTween;
        
        private RectTransformAnchoredPositionTween _sliderPositionShowTween;
        private RectTransformAnchoredPositionTween _sliderPositionHideTween;
        
        public override void Show()
        {
            _canvasGroupHideTween.Stop();
            _backgroundPositionHideTween.Stop();
            _sliderPositionHideTween.Stop();
                
            _canvasGroupShowTween.StartFromCurrent();
            _backgroundPositionShowTween.StartFromCurrent();
            _sliderPositionShowTween.StartFromCurrent();

            IsShown = true;
        }

        public override void Hide()
        {
            _canvasGroupShowTween.Stop();
            _backgroundPositionShowTween.Stop();
            _sliderPositionShowTween.Stop();
                    
            _canvasGroupHideTween.StartFromCurrent();
            _backgroundPositionHideTween.StartFromCurrent();
            _sliderPositionHideTween.StartFromCurrent();

            IsShown = false;
        }

        private void Start()
        {
            _toggleButton.onClick.AddListener(Toggle);
            
            _canvasGroupShowTween = new CanvasGroupAlphaTween(_canvasGroup, _canvasGroupHiddenAlpha, _canvasGroupShownAlpha, _showDuration);
            _canvasGroupHideTween = new CanvasGroupAlphaTween(_canvasGroup, _canvasGroupShownAlpha, _canvasGroupHiddenAlpha, _hideDuration);

            _backgroundPositionShowTween = new RectTransformAnchoredPositionTween(_backgroundRectTransform, _backgroundHiddenPosition, _backgroundShownPosition, _showDuration);
            _backgroundPositionHideTween = new RectTransformAnchoredPositionTween(_backgroundRectTransform, _backgroundShownPosition, _backgroundHiddenPosition, _hideDuration);
            
            _sliderPositionShowTween = new RectTransformAnchoredPositionTween(_sliderRectTransform, _sliderHiddenPosition, _sliderShownPosition, _showDuration);
            _sliderPositionHideTween = new RectTransformAnchoredPositionTween(_sliderRectTransform, _sliderShownPosition, _sliderHiddenPosition, _hideDuration);
        }
    }
}
