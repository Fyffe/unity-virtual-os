using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OS.Core
{
	/// <summary>
	/// Initializes the game and its <see cref="IModule"/>s marked with <see cref="CoreConfig.INITIALIZE_ON_LOAD_ID"/>.  
	/// </summary>
	public abstract class Bootstrap : MonoBehaviour
	{
		protected List<IModule> _modules;
		
		[Inject]
		private void Construct([Inject(Id=CoreConfig.INITIALIZE_ON_LOAD_ID)] List<IModule> modules)
		{
			_modules = modules;
		}

		/// <summary>
		/// Initializes <see cref="IModule"/>s based on their priority.
		/// </summary>
		/// <returns></returns>
		protected IEnumerator InitializeModules()
		{
			_modules.Sort((x, y) => x.Priority.CompareTo(y.Priority));
			
			foreach (IModule module in _modules)
			{
				if (module.IsInitialized)
				{
					continue;
				}
				
				module.Initialize();
				
				OnModuleInitialize(module);
				
				yield return new WaitUntil(() => module.IsInitialized);

				OnModuleInitialized(module);

				yield return null;
			}
			
			OnModulesInitialized();
		}

		/// <summary>
		/// Called whenever an <see cref="IModule"/> is about to be initialized.
		/// </summary>
		/// <param name="module"><see cref="IModule"/> that is being initialized.</param>
		protected abstract void OnModuleInitialize(IModule module);
		/// <summary>
		/// Called whenever an <see cref="IModule"/> has been initialized. 
		/// </summary>
		/// <param name="module"><see cref="IModule"/> that has been initialized.</param>
		protected abstract void OnModuleInitialized(IModule module);
		/// <summary>
		/// Called once all <see cref="IModule"/>s have been initialized.
		/// </summary>
		protected abstract void OnModulesInitialized();
	}
}
