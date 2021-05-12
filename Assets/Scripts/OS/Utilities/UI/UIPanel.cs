using UnityEngine;

namespace OS.Utilities.UI
{
    [RequireComponent(typeof(Canvas))]
    public class UIPanel : MonoBehaviour
    {
        [SerializeField] protected Canvas _canvas;

        public void Toggle()
        {
            Toggle(!_canvas.enabled);
        }

        public virtual void Toggle(bool isEnabled)
        {
            _canvas.enabled = isEnabled;
        }

        private void OnValidate()
        {
            _canvas = GetComponent<Canvas>();
        }

        private void Reset()
        {
            _canvas = GetComponent<Canvas>();
        }
    }
}
