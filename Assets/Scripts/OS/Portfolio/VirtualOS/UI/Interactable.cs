using UnityEngine;
using UnityEngine.EventSystems;

namespace OS.Portfolio.VirtualOS.UI
{
    public abstract class Interactable : MonoBehaviour, IInteractable, IPointerDownHandler
    {
        [SerializeField] protected float _doubleClickDelay = 0.1f;
        
        protected float _lastPressTime = 0f;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Middle:
                    HandleMiddleMouseButton(eventData);
                    break;
                case PointerEventData.InputButton.Right:
                    HandleRightMouseButton(eventData);
                    break;
                case PointerEventData.InputButton.Left:
                    HandleLeftMouseButton(eventData);
                    break;
            }
        }

        public abstract void SingleClick(PointerEventData eventData);
        public abstract void DoubleClick(PointerEventData eventData);
        public abstract void RightClick(PointerEventData eventData);
        public abstract void MiddleClick(PointerEventData eventData);
        
        private void HandleLeftMouseButton(PointerEventData eventData)
        {
            if (Time.unscaledTime - _lastPressTime < _doubleClickDelay)
            {
                _lastPressTime = Time.unscaledTime;
                
                DoubleClick(eventData);
                
                return;
            }
            
            _lastPressTime = Time.unscaledTime;
            
            SingleClick(eventData);
        }

        private void HandleRightMouseButton(PointerEventData eventData)
        {
            RightClick(eventData);
        }
        
        private void HandleMiddleMouseButton(PointerEventData eventData)
        {
            MiddleClick(eventData);
        }
    }
}
