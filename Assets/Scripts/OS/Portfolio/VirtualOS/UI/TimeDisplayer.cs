using System;
using TMPro;
using UnityEngine;

namespace OS.Portfolio.VirtualOS.UI
{
    public class TimeDisplayer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timeText;
        
        private void Start()
        {
            UpdateDisplay();            
        }

        private void FixedUpdate()
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            _timeText.text = DateTime.Now.ToShortTimeString();
        }
    }
}
