using System.Collections;
using OS.Utilities.Coroutines;
using UnityEngine;
using UnityEngine.UI;

namespace OS.Utilities.Tweening
{
    public class ImageAlphaTween : OSTween
    {
        private readonly Image _image;
        
        private readonly float _targetAlpha;
        private readonly float _duration;
        
        private float _startAlpha;

        public ImageAlphaTween(Image image, float startAlpha, float targetAlpha, float duration)
        {
            _image = image;
            _startAlpha = startAlpha;
            _targetAlpha = targetAlpha;
            _duration = duration;
        }

        public ImageAlphaTween(Image image, float targetAlpha, float duration) : this(image, image.color.a, targetAlpha, duration)
        {
            
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

        public override void Stop()
        {
            if (_coroutine != null)
            {
                CoroutineRunner.StopCoroutine(_coroutine);
            }

            IsDone = false;
            
            CleanUp();
        }

        public override void StartFromCurrent()
        {
            _startAlpha = _image.color.a;

            Start();
        }

        public override void ForceEnd()
        {
            base.ForceEnd();
            
            Color tempColor = _image.color;
            tempColor.a = _targetAlpha;
            _image.color = tempColor;
        }

        private IEnumerator TweenAlpha()
        {
            Color tempColor = _image.color;
            tempColor.a = _startAlpha;
			
            float elapsed = 0;

            while (elapsed < _duration)
            {
                tempColor.a = Mathf.Lerp(_startAlpha, _targetAlpha, elapsed / _duration);
                _image.color = tempColor;
                elapsed += Time.deltaTime;
				
                yield return null;
            }

            tempColor.a = _targetAlpha;
            _image.color = tempColor;
            
            OnDone?.Invoke();

            IsDone = true;
            
            CleanUp();
        }
    }
}
