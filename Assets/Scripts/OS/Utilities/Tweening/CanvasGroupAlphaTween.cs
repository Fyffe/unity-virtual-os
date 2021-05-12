using System;
using System.Collections;
using OS.Utilities.Coroutines;
using UnityEngine;

namespace OS.Utilities.Tweening
{
    public class CanvasGroupAlphaTween : OSTween
    {
        private readonly CanvasGroup _canvasGroup;
        
        private readonly float _targetAlpha;
        private readonly float _duration;
        
        private float _startAlpha;

        public CanvasGroupAlphaTween(CanvasGroup canvasGroup, float startAlpha, float targetAlpha, float duration)
        {
            _canvasGroup = canvasGroup;
            _startAlpha = startAlpha;
            _targetAlpha = targetAlpha;
            _duration = duration;
        }

        public CanvasGroupAlphaTween(CanvasGroup canvasGroup, float targetAlpha, float duration) : this(canvasGroup, canvasGroup.alpha, targetAlpha, duration)
        {
            
        }
        
        public CanvasGroupAlphaTween(CanvasGroup canvasGroup, float startAlpha, float targetAlpha, float duration, Action onDone) : this(canvasGroup, startAlpha, targetAlpha, duration)
        {
            OnDone = onDone;
        }
        
        public override void Start()
        {
            if (_coroutine != null)
            {
                CoroutineRunner.StopCoroutine(_coroutine);
            }
            
            _coroutine = CoroutineRunner.RunCoroutine(TweenAlpha());
            
            IsDone = false;
            IsRunning = true;
        }
        
        public override void StartFromCurrent()
        {
            _startAlpha = _canvasGroup.alpha;
            
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

            _canvasGroup.alpha = _targetAlpha;
        }

        private IEnumerator TweenAlpha()
        {
            float elapsed = 0;

            while (elapsed < _duration)
            {
                _canvasGroup.alpha = Mathf.Lerp(_startAlpha, _targetAlpha, elapsed / _duration);
                elapsed += Time.deltaTime;
				
                yield return null;
            }

            _canvasGroup.alpha = _targetAlpha;
            
            OnDone?.Invoke();

            IsDone = true;
            
            CleanUp();
        }
    }
}
