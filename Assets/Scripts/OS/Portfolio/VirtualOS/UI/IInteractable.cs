using UnityEngine.EventSystems;

namespace OS.Portfolio.VirtualOS.UI
{
    public interface IInteractable
    {
        void SingleClick(PointerEventData eventData);
        void DoubleClick(PointerEventData eventData);
        void RightClick(PointerEventData eventData);
        void MiddleClick(PointerEventData eventData);
    }
}
