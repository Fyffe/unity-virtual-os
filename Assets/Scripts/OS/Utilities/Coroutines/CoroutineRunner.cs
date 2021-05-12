using System.Collections;
using UnityEngine;

namespace OS.Utilities.Coroutines 
{
	public static class CoroutineRunner
	{
		private static MonoBehaviour _monoBehaviour; 
		
		public static Coroutine RunCoroutine(IEnumerator coroutine)
		{
			if (!_monoBehaviour)
			{
				_monoBehaviour = new GameObject("Coroutine_Runner").AddComponent<CoroutineRunnerMono>();
			}

			return _monoBehaviour.StartCoroutine(coroutine);
		}

		public static void StopCoroutine(Coroutine coroutine)
		{
			_monoBehaviour.StopCoroutine(coroutine);
		}
	}
}
