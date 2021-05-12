using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace OS.Utilities.UI
{
    public class ExtendedScrollRect : ScrollRect
    {
        [SerializeField] private bool _allowDragging = true;
        
        public override void OnBeginDrag(PointerEventData eventData)
        {
            if (!_allowDragging)
            {
                return;
            }
            
            base.OnBeginDrag(eventData);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            if (!_allowDragging)
            {
                return;
            }
            
            base.OnDrag(eventData);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            if (!_allowDragging)
            {
                return;
            }
            
            base.OnEndDrag(eventData);
        }
    }
}
