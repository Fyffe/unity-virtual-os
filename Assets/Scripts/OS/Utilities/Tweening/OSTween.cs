using System;
using OS.Utilities.Coroutines;
using UnityEngine;

namespace OS.Utilities.Tweening
{
	/// <summary>
	/// Base class for all tweens.
	/// </summary>
	public abstract class OSTween
	{
		public bool IsDone { get; protected set; } = false;
		public bool IsRunning { get; protected set; } = false;

		public Action OnDone;
		
		protected Coroutine _coroutine;

		public abstract void Start();
		public abstract void StartFromCurrent();
		public abstract void Stop();

		public virtual void ForceEnd()
		{
			if (_coroutine != null)
			{
				CoroutineRunner.StopCoroutine(_coroutine);
			}
			
			OnDone?.Invoke();

			IsDone = true;
			IsRunning = false;

			CleanUp();
		}

		protected virtual void CleanUp()
		{
			IsRunning = false;
			_coroutine = null;
			OnDone = null;
		}
	}
}
