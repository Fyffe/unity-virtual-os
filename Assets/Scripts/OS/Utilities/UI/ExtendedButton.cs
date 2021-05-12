using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OS.Utilities.UI
{
    public class ExtendedButton : Button
    {
        private Graphic[] _childGraphics = new Graphic[0];

        public void Refresh()
        {
            if (_childGraphics.Length > 0)
            {
                return;
            }
            
            List<Graphic> childGraphics = new List<Graphic>(GetComponentsInChildren<Graphic>());
            childGraphics.Remove(image);

            _childGraphics = childGraphics.ToArray();

        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();

            GetGraphics();
        }
#endif
        
        protected override void DoStateTransition(SelectionState state, bool instant)
        {
            base.DoStateTransition(state, instant);

            if (transition != Transition.ColorTint)
            {
                return;
            }
            
            Color tintColor;

            switch (state)
            {
                case SelectionState.Normal:
                    tintColor = colors.normalColor;
                    break;
                case SelectionState.Highlighted:
                    tintColor = colors.highlightedColor;
                    break;
                case SelectionState.Pressed:
                    tintColor = colors.pressedColor;
                    break;
                case SelectionState.Selected:
                    tintColor = colors.selectedColor;
                    break;
                case SelectionState.Disabled:
                    tintColor = colors.disabledColor;
                    break;
                default:
                    tintColor = Color.black;
                    break;
            }

            foreach (Graphic graphic in _childGraphics)
            {
                graphic.CrossFadeColor(tintColor, instant ? 0f : colors.fadeDuration, true, true);
            }
        }

        private void GetGraphics()
        {
            List<Graphic> childGraphics = new List<Graphic>(GetComponentsInChildren<Graphic>());
            childGraphics.Remove(image);

            _childGraphics = childGraphics.ToArray();

        }
    }
}
