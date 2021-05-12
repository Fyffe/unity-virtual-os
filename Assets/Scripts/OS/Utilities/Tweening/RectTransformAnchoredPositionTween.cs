using System;
using System.Collections;
using OS.Utilities.Coroutines;
using UnityEngine;

namespace OS.Utilities.Tweening
{
	public class RectTransformAnchoredPositionTween : OSTween
	{
		private readonly RectTransform _rectTransform;
        
		private readonly Vector3 _targetPosition;
		
		private readonly float _duration;
		
		private Vector3 _startPosition;
		
		public RectTransformAnchoredPositionTween(RectTransform rectTransform, Vector3 startPosition, Vector3 targetPosition, float duration)
		{
			_rectTransform = rectTransform;
			_startPosition = startPosition;
			_targetPosition = targetPosition;
			_duration = duration;
		}

		public RectTransformAnchoredPositionTween(RectTransform rectTransform, Vector3 targetPosition, float duration) : this(rectTransform, rectTransform.anchoredPosition, targetPosition, duration)
		{
            
		}
        
		public RectTransformAnchoredPositionTween(RectTransform rectTransform, Vector3 startPosition, Vector3 targetPosition, float duration, Action onDone) : this(rectTransform, startPosition, targetPosition, duration)
		{
			OnDone = onDone;
		}
		
		public override void Start()
		{
			if (_coroutine != null)
			{
				CoroutineRunner.StopCoroutine(_coroutine);
			}
            
			_coroutine = CoroutineRunner.RunCoroutine(TweenPosition());
            
			IsDone = false;
			IsRunning = true;
		}
		
		public override void StartFromCurrent()
		{
			_startPosition = _rectTransform.anchoredPosition;
			
			Start();
		}
        
		public override void Stop()
		{
			if (_coroutine != null)
			{
				CoroutineRunner.StopCoroutine(_coroutine);
			}

			IsDone = false;
            
			CleanUp();
		}

		public override void ForceEnd()
		{
			base.ForceEnd();

			_rectTransform.anchoredPosition = _targetPosition;
		}

		private IEnumerator TweenPosition()
		{
			float elapsed = 0;

			while (elapsed < _duration)
			{
				_rectTransform.anchoredPosition = Vector3.Lerp(_startPosition, _targetPosition, elapsed / _duration);
				elapsed += Time.deltaTime;
				
				yield return null;
			}

			_rectTransform.anchoredPosition = _targetPosition;
            
			OnDone?.Invoke();

			IsDone = true;
            
			CleanUp();
		}
	}
}