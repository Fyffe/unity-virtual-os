using UnityEngine;

namespace OS.Portfolio.VirtualOS.UI
{
    public abstract class SideWidget : MonoBehaviour, ITogglable
    {
        public bool IsShown { get; protected set; }

        public virtual void Toggle()
        {
            if (IsShown)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        public abstract void Show();
        public abstract void Hide();
    }
}
