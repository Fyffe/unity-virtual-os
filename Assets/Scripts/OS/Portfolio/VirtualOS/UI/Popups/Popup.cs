using OS.Utilities;
using OS.Utilities.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OS.Portfolio.VirtualOS.UI.Popups
{
    public class Popup : Draggable, ITogglable
    {
        public Canvas Canvas => _canvas;
        
        public bool IsShown { get; protected set; }

        [Header("References")]
        [SerializeField] protected Canvas _canvas;
        [SerializeField] protected CanvasGroup _canvasGroup;

        [Header("Parameters")] 
        [SerializeField] private float _showDuration;
        [SerializeField] private float _hideDuration;

        private readonly Vector3 _showScale = V3.One;
        private readonly Vector3 _hideScale = V3.Zero;

        private Transform _transform;

        private TransformScaleTween _showScaleTween;
        private TransformScaleTween _hideScaleTween;

        private CanvasGroupAlphaTween _showAlphaTween;
        private CanvasGroupAlphaTween _hideAlphaTween;
    
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

        public void Show()
        {
            _hideAlphaTween.Stop();
            _hideScaleTween.Stop();

            _showAlphaTween.OnDone = OnShowAlphaDone;
            
            _showAlphaTween.StartFromCurrent();
            _showScaleTween.StartFromCurrent();
        }

        public void Hide()
        {
            _canvasGroup.blocksRaycasts = false;

            _showAlphaTween.Stop();
            _showScaleTween.Stop();
            
            _hideAlphaTween.StartFromCurrent();
            _hideScaleTween.StartFromCurrent();

            IsShown = false;
        }

        protected virtual void Awake()
        {
            _transform = transform;
            
            _showAlphaTween = new CanvasGroupAlphaTween(_canvasGroup, 0f, 1f, _showDuration);
            _hideAlphaTween = new CanvasGroupAlphaTween(_canvasGroup, 1f, 0f, _hideDuration);

            _showScaleTween = new TransformScaleTween(_transform, _hideScale, _showScale, _showDuration);
            _hideScaleTween = new TransformScaleTween(_transform, _showScale, _hideScale, _hideDuration);
        }

        private void OnShowAlphaDone()
        {
            _canvasGroup.blocksRaycasts = true;
            
            IsShown = true;
        }

        public override void RightClick(PointerEventData eventData) { }

        public override void MiddleClick(PointerEventData eventData) { }
    }
}
