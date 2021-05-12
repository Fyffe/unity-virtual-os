using System.Collections;
using OS.Utilities.Coroutines;
using UnityEngine;
using UnityEngine.UI;

namespace OS.Utilities.Tweening
{
    public class ImageColorTween : OSTween
    {
        private readonly Image _image;
        
        private readonly Color _targetColor;
        private readonly float _duration;
        
        private Color _startColor;

        public ImageColorTween(Image image, Color startColor, Color targetColor, float duration)
        {
            _image = image;
            _startColor = startColor;
            _targetColor = targetColor;
            _duration = duration;
        }

        public ImageColorTween(Image image, Color targetColor, float duration) : this(image, image.color, targetColor, duration)
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

        public override void StartFromCurrent()
        {
            _startColor = _image.color;
            
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
            
            _image.color = _targetColor;
        }

        private IEnumerator TweenAlpha()
        {
            float elapsed = 0;

            while (elapsed < _duration)
            {
                _image.color = Color.Lerp(_startColor, _targetColor, elapsed / _duration);
                elapsed += Time.deltaTime;
				
                yield return null;
            }

            _image.color = _targetColor;
            
            OnDone?.Invoke();

            IsDone = true;
            
            CleanUp();
        }
    }
}
