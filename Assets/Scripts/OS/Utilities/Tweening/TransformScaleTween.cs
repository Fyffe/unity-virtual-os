using System;
using System.Collections;
using OS.Utilities.Coroutines;
using UnityEngine;

namespace OS.Utilities.Tweening
{
	public class TransformScaleTween : OSTween
	{
		private readonly Transform _transform;
        
		private readonly Vector3 _targetScale;
		
		private readonly float _duration;
		
		private Vector3 _startScale;
		
		public TransformScaleTween(Transform transform, Vector3 startScale, Vector3 targetScale, float duration)
		{
			_transform = transform;
			_startScale = startScale;
			_targetScale = targetScale;
			_duration = duration;
		}
	
		public TransformScaleTween(Transform transform, Vector3 targetPosition, float duration) : this(transform, transform.localScale, targetPosition, duration)
		{
            
		}
        
		public TransformScaleTween(Transform transform, Vector3 startScale, Vector3 targetScale, float duration, Action onDone) : this(transform, startScale, targetScale, duration)
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
			_startScale = _transform.localScale;
    	
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

			_transform.localScale = _targetScale;
		}

		private IEnumerator TweenPosition()
		{
			float elapsed = 0;

			while (elapsed < _duration)
			{
				_transform.localScale = Vector3.Lerp(_startScale, _targetScale, elapsed / _duration);
				elapsed += Time.deltaTime;
    		
				yield return null;
			}

			_transform.localScale = _targetScale;
        
			OnDone?.Invoke();

			IsDone = true;
        
			CleanUp();
		}
	}
}
