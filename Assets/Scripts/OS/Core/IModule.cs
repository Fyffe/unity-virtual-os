namespace OS.Core 
{
    /// <summary>
    /// Interface to help organize game's structure.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Determines if this module has already been initialized.
        /// </summary>
        bool IsInitialized { get; }
        
        /// <summary>
        /// Name of this module, used for debugging purposes.
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Modules are initialized based on this property - the lower the value is - the sooner this module will be initialized.
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Initializes this module.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Clear all references of this module.
        /// </summary>
        void CleanUp();
    }
}
