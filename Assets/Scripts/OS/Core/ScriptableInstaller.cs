using Zenject;

namespace OS.Core 
{
    public class ScriptableInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            HandleSignals();
            HandleBindings();
        }

        protected virtual void HandleSignals()
        {
            
        }
        
        protected virtual void HandleBindings()
        {
            
        }
    }
}
