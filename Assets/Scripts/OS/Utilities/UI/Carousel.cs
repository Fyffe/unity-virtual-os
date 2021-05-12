using System;
using System.Collections.Generic;
using OS.Utilities.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace OS.Utilities.UI
{
	/// <summary>
	/// Base class for any and all UI carousels.
	/// </summary>
	public class Carousel : MonoBehaviour, ITickable, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] protected RectTransform _contentRoot;
		[SerializeField] protected List<CanvasGroup> _slides = new List<CanvasGroup>();
		
		[SerializeField] private float _fadeDuration = 1.5f;
		[SerializeField] private float _slideInterval = 4f;

		[SerializeField] private bool _autoSlide = true;
		
		[SerializeField] private Button _previousButton, _nextButton;

		protected CanvasGroup _currentSlide;

		protected int _currentSlideIndex = 0;

		protected bool _isPaused = false;
		protected bool _isBusy = false;

		private CanvasGroupAlphaTween _currentSlideTween;
		private CanvasGroupAlphaTween _nextSlideTween;

		private float _timerValue;

		public void Start()
		{
			Initialize();
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			_isPaused = true;
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			_isPaused = false;
		}

		public virtual void Tick()
		{
			HandleAutoSlide();
		}

		protected virtual void Initialize()
		{
			_previousButton.onClick.AddListener(PreviousSlide);
			_nextButton.onClick.AddListener(NextSlide);

			if (_slides != null && _slides.Count > 0)
			{
				_currentSlide = _slides[_currentSlideIndex];
				_currentSlide.alpha = 1f;
				_currentSlide.blocksRaycasts = true;
			}
		}

		protected void HandleAutoSlide()
		{
			if (!_autoSlide || _isPaused || _isBusy)
			{
				return;
			}

			_timerValue += Time.deltaTime;

			if (_timerValue >= _slideInterval)
			{
				_timerValue = 0f;
				
				NextSlide();
			}
		}

		protected void NextSlide()
		{
			AddToSlideValue(1);
		}

		protected void PreviousSlide()
		{
			AddToSlideValue(-1);
		}

		/// <summary>
		/// Slides carousel by passed value. 
		/// </summary>
		/// <param name="delta">Value to add to <see cref="_currentSlideIndex"/>. Pass negative values to decrease.</param>
		protected void AddToSlideValue(int delta)
		{
			if (_isBusy || _slides == null || _slides.Count == 0)
			{
				return;
			}
			
			_currentSlideIndex += delta;

			if (_currentSlideIndex >= _slides.Count)
			{
				_currentSlideIndex = 0;
			}
			else if (_currentSlideIndex < 0)
			{
				_currentSlideIndex = _slides.Count - 1;
			}

			OnSlide();
		}

		protected virtual void OnSlide()
		{
			if (_isBusy)
			{
				return;
			}
			
			_currentSlideTween = new CanvasGroupAlphaTween(_currentSlide, 1f, 0f, _fadeDuration, CheckAvailability);
			_nextSlideTween = new CanvasGroupAlphaTween(_slides[_currentSlideIndex], 0f, 1f, _fadeDuration, CheckAvailability);
			
			_currentSlideTween.Start();
			_nextSlideTween.Start();

			_currentSlide.blocksRaycasts = false;
			_currentSlide = _slides[_currentSlideIndex];

			_timerValue = 0f;

			_isBusy = true;
		}

		private void CheckAvailability()
		{
			_isBusy = (_currentSlideTween == null || _currentSlideTween.IsDone) && (_nextSlideTween == null || _nextSlideTween.IsDone);

			if (!_isBusy)
			{
				_currentSlide.blocksRaycasts = true;
			}
		}

		private void OnDestroy()
		{
			_previousButton.onClick.RemoveListener(PreviousSlide);
			_nextButton.onClick.RemoveListener(NextSlide);

			_currentSlideTween = null;
			_nextSlideTween = null;
		}
	}
}
