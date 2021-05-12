using System;
using TMPro;
using UnityEngine;

namespace OS.Portfolio.VirtualOS.UI
{
	public class DateDisplayer : MonoBehaviour
	{
		[SerializeField] private TMP_Text _dateText;
		
		private float _timeUntilMidnight;
		
		private void Start()
		{
			UpdateDate();
			UpdateDisplay();
		}

		private void FixedUpdate()
		{
			if (_timeUntilMidnight > 0)
			{
				_timeUntilMidnight -= Time.fixedUnscaledDeltaTime;
				
				return;
			}
			
			UpdateDate();
			UpdateDisplay();
		}

		private float GetTimeUntilMidnight()
		{
			return (float) (DateTime.Today.AddDays(1) - DateTime.Now).TotalSeconds;
		}

		private void UpdateDate()
		{
			_timeUntilMidnight = GetTimeUntilMidnight();
		}

		private void UpdateDisplay()
		{
			_dateText.text = DateTime.Today.ToShortDateString();
		}
	}
}
