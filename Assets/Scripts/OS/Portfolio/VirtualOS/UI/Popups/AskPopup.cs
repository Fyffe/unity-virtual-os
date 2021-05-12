using System;
using OS.Portfolio.VirtualOS.UI.Popups.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Popups
{
    public class AskPopup : Popup
    {
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _positiveText;
        [SerializeField] private TMP_Text _negativeText;

        [SerializeField] private Button _positiveButton;
        [SerializeField] private Button _negativeButton;

        private Action _positiveAction;
        private Action _negativeAction;
        
        [Inject]
        private void Construct(IPopupData popupData)
        {
            AskPopupData data = (AskPopupData) popupData;
            _messageText.text = data.Message;
            _titleText.text = data.Title;
            _positiveText.text = data.PositiveData.Text;
            _negativeText.text = data.NegativeData.Text;
            
            _positiveAction = data.PositiveData.Action;
            _negativeAction = data.NegativeData.Action;
        }

        protected override void Awake()
        {
            base.Awake();
            
            _positiveButton.onClick.AddListener(OnPositivePressed);
            _negativeButton.onClick.AddListener(OnNegativePressed);
        }

        private void OnPositivePressed()
        {
            _positiveAction?.Invoke();
            
            Hide();
        }
        
        private void OnNegativePressed()
        {
            _negativeAction?.Invoke();

            Hide();
        }
        
        public class Factory : PlaceholderFactory<IPopupData, AskPopup> { }
    }
}
