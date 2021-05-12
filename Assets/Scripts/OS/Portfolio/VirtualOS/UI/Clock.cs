using System;
using OS.Utilities;
using UnityEngine;

namespace OS.Portfolio.VirtualOS.UI
{
	public class Clock : MonoBehaviour
	{
		[SerializeField] private RectTransform _hourHand;
		[SerializeField] private RectTransform _minuteHand;
		[SerializeField] private RectTransform _secondHand;

		private Vector3 _hourEuler;
		private Vector3 _minuteEuler;
		private Vector3 _secondEuler;

		private DateTime _now;

		private void Start()
		{
			_now = DateTime.Now;
			
			_hourEuler = V3.Zero;
			_minuteEuler = V3.Zero;
			_secondEuler = V3.Zero;
			
			UpdateHourHand();
			UpdateMinuteHand();
			UpdateSecondHand();
		}
		
		private void Update()
		{
			_now = DateTime.Now;
			
			UpdateHourHand();
			UpdateMinuteHand();
			UpdateSecondHand();
		}

		private void UpdateHourHand()
		{
			_hourEuler.z = -(_now.Hour / 24f) * 360f;
			_hourHand.localEulerAngles = _hourEuler;
		}

		private void UpdateMinuteHand()
		{
			_minuteEuler.z = -(_now.Minute / 60f) * 360f;
			_minuteHand.localEulerAngles = _minuteEuler;
		}

		private void UpdateSecondHand()
		{
			_secondEuler.z = -(_now.Second / 60f) * 360f;
			_secondHand.localEulerAngles = _secondEuler;
		}
	}
}
