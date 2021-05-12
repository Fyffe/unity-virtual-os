using OS.Core;
using OS.Portfolio.UI;
using OS.Utilities.Coroutines;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace OS.Portfolio
{
    public class Bootstrap : Core.Bootstrap
    {
        [Header("References")]
        [SerializeField] private FadingUIPanel _pressPanel;
        [SerializeField] private Button _startButton;
        [SerializeField] private PlayableDirector _closeInDirector;
    
        protected override void OnModuleInitialize(IModule module)
        {
            
        }

        protected override void OnModuleInitialized(IModule module)
        {
            
        }

        protected override void OnModulesInitialized()
        {
            _pressPanel.Toggle(true);
            
            _startButton.onClick.AddListener(StartPortfolio);
            _startButton.interactable = true;
        }

        private void Start()
        {
            CoroutineRunner.RunCoroutine(InitializeModules());
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveListener(StartPortfolio);
        }

        private void StartPortfolio()
        {
            _startButton.gameObject.SetActive(false);
            _pressPanel.Toggle(false);
            
            _closeInDirector.stopped += OnCloseInStopped;
            _closeInDirector.Play();
        }

        private void OnCloseInStopped(PlayableDirector director)
        {
            Debug.Log("Enable OS here!");
        }
    }
}
