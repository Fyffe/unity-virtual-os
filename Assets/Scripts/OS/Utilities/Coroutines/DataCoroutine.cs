using System.Collections;
using UnityEngine;

namespace OS.Utilities.Coroutines
{
    public class DataCoroutine
    {
        public Coroutine Coroutine { get; private set; }
        public object Result;

        private IEnumerator _target;

        public DataCoroutine(IEnumerator target)
        {
            _target = target;
            Coroutine = CoroutineRunner.RunCoroutine(Run());
        }

        private IEnumerator Run()
        {
            while (_target.MoveNext())
            {
                Result = _target.Current;

                yield return Result;
            }
        }
    }
}
