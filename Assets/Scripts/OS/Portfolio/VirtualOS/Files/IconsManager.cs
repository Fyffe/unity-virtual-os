using UnityEngine;
using UnityEngine.U2D;
using Zenject;

namespace OS.Portfolio.VirtualOS.Files
{
    public class IconsManager : IIconsProvider
    {
        [Inject] private IconsManagerSettings _settings;

        private Sprite _defaultIcon;

        [Inject]
        private void Construct()
        {
            _defaultIcon = _settings.SpriteAtlas.GetSprite(_settings.DefaultIconName);
        }

        public Sprite GetIcon(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _defaultIcon;
            }

            Sprite sprite = _settings.SpriteAtlas.GetSprite(name);

            if (!sprite)
            {
                sprite = _defaultIcon;
            }

            return sprite;
        }
    }
}
