using UnityEngine;
using UnityEngine.UI;

namespace OS.Utilities.Tweening
{
	public static class Extensions
	{
		public static CanvasGroupAlphaTween TweenAlpha(this CanvasGroup canvasGroup, float startAlpha, float targetAlpha, float duration)
		{
			return new CanvasGroupAlphaTween(canvasGroup, startAlpha, targetAlpha, duration);
		}
		
		public static CanvasGroupAlphaTween TweenAlpha(this CanvasGroup canvasGroup, float targetAlpha, float duration)
		{
			return new CanvasGroupAlphaTween(canvasGroup, canvasGroup.alpha, targetAlpha, duration);
		}

		public static ImageAlphaTween TweenAlpha(this Image image, float startAlpha, float targetAlpha, float duration)
		{
			return new ImageAlphaTween(image, startAlpha, targetAlpha, duration);
		}
		
		public static ImageColorTween TweenColor(this Image image, Color startColor, Color targetColor, float duration)
		{
			return new ImageColorTween(image, startColor, targetColor, duration);
		}
		
		public static ImageColorTween TweenColor(this Image image, Color targetColor, float duration)
		{
			return new ImageColorTween(image, image.color, targetColor, duration);
		}
	}
}
