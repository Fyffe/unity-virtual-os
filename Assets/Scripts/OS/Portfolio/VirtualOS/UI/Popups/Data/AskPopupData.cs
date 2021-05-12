using UnityEngine;

namespace OS.Portfolio.VirtualOS.UI.Popups.Data
{
    public class AskPopupData : IPopupData
    {
        public readonly string Message;
        public readonly string Title;
        public readonly PopupButtonData PositiveData;
        public readonly PopupButtonData NegativeData;
        
        public AskPopupData(string message, string title, PopupButtonData positiveData, PopupButtonData negativeData)
        {
            Message = message;
            Title = title;
            PositiveData = positiveData;
            NegativeData = negativeData;
        }
    }
}
