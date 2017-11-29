using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Prism.Modularity
{
    /// <summary>
    /// <see cref="IModuleCatalog"/>  extensions.
    /// </summary>
    public static class IModuleCatalogExtensions
    {
        /// <summary>
        /// Adds the module.
        /// </summary>
        /// <returns>The module.</returns>
        /// <param name="catalog">Catalog</param>
        /// <param name="mode"><see cref="InitializationMode"/></param>
        /// <typeparam name="T">The <see cref="IModule"/> type parameter.</typeparam>
        public static IModuleCatalog AddModule<T>(this IModuleCatalog catalog, InitializationMode mode = InitializationMode.WhenAvailable)
            where T : IModule =>
            catalog.AddModule<T>(typeof(T).AssemblyQualifiedName, mode);

        /// <summary>
        /// Adds the module.
        /// </summary>
        /// <returns>The module.</returns>
        /// <param name="catalog">Catalog.</param>
        /// <param name="name">Name.</param>
        /// <param name="mode"><see cref="IModule"/>.</param>
        /// <typeparam name="T">The <see cref="IModule"/> type parameter.</typeparam>
        public static IModuleCatalog AddModule<T>(this IModuleCatalog catalog, string name, InitializationMode mode = InitializationMode.WhenAvailable)
            where T : IModule =>
            catalog.AddModule(name, typeof(T), mode);

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <param name="catalog">The <see cref="IModuleCatalog"/></param>
        /// <param name="moduleType"><see cref="Type"/> of the module to be added.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="IModuleCatalog"/> instance with the added module.</returns>
        public static IModuleCatalog AddModule(this IModuleCatalog catalog, Type moduleType, params string[] dependsOn) => 
            catalog.AddModule(moduleType, InitializationMode.WhenAvailable, dependsOn);

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog
        /// </summary>
        /// <typeparam name="T">Type of <see cref="IModule"/></typeparam>
        /// <param name="catalog">The <see cref="IModuleCatalog"/></param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="IModuleCatalog"/> instance with the added module.</returns>
        public static IModuleCatalog AddModule<T>(this IModuleCatalog catalog, params string[] dependsOn)
            where T : IModule =>
            catalog.AddModule(typeof(T), dependsOn);

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <param name="catalog">The <see cref="IModuleCatalog"/></param>
        /// <param name="moduleType"><see cref="Type"/> of the module to be added.</param>
        /// <param name="initializationMode">Stage on which the module to be added will be initialized.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="IModuleCatalog"/> instance with the added module.</returns>
        public static IModuleCatalog AddModule(this IModuleCatalog catalog, Type moduleType, InitializationMode initializationMode, params string[] dependsOn)
        {
            if (moduleType == null) throw new ArgumentNullException(nameof(moduleType));
            return catalog.AddModule(moduleType.AssemblyQualifiedName, moduleType, initializationMode, dependsOn);
        }

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="IModule"/></typeparam>
        /// <param name="catalog">The <see cref="IModuleCatalog"/></param>
        /// <param name="initializationMode">Stage on which the module to be added will be initialized.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="IModuleCatalog"/> instance with the added module.</returns>
        public static IModuleCatalog AddModule<T>(this IModuleCatalog catalog, InitializationMode initializationMode, params string[] dependsOn)
            where T : IModule =>
            catalog.AddModule(typeof(T), initializationMode, dependsOn);

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <param name="catalog">The <see cref="IModuleCatalog"/></param>
        /// <param name="moduleName">Name of the module to be added.</param>
        /// <param name="moduleType"><see cref="Type"/> of the module to be added.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="IModuleCatalog"/> instance with the added module.</returns>
        public static IModuleCatalog AddModule(this IModuleCatalog catalog, string moduleName, Type moduleType, params string[] dependsOn)
        {
            return catalog.AddModule(moduleName, moduleType, InitializationMode.WhenAvailable, dependsOn);
        }

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="IModule"/></typeparam>
        /// <param name="catalog">The <see cref="IModuleCatalog"/></param>
        /// <param name="moduleName">Name of the module to be added.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="IModuleCatalog"/> instance with the added module.</returns>
        public static IModuleCatalog AddModule<T>(this IModuleCatalog catalog, string moduleName, params string[] dependsOn)
            where T : IModule =>
            catalog.AddModule(moduleName, typeof(T), dependsOn);

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <param name="catalog">The <see cref="IModuleCatalog"/></param>
        /// <param name="moduleName">Name of the module to be added.</param>
        /// <param name="moduleType"><see cref="Type"/> of the module to be added.</param>
        /// <param name="initializationMode">Stage on which the module to be added will be initialized.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="IModuleCatalog"/> instance with the added module.</returns>
        public static IModuleCatalog AddModule(this IModuleCatalog catalog, string moduleName, Type moduleType, InitializationMode initializationMode, params string[] dependsOn)
        {
            return InternalAddModule(catalog, moduleName, moduleType, null, initializationMode, dependsOn);
        }

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="IModule"/></typeparam>
        /// <param name="catalog">The <see cref="IModuleCatalog"/></param>
        /// <param name="moduleName">Name of the module to be added.</param>
        /// <param name="initializationMode">Stage on which the module to be added will be initialized.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="IModuleCatalog"/> instance with the added module.</returns>
        public static IModuleCatalog AddModule<T>(this IModuleCatalog catalog, string moduleName, InitializationMode initializationMode, params string[] dependsOn)
            where T : IModule =>
            catalog.AddModule(moduleName, typeof(T), initializationMode, dependsOn);

#if NET45
        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <param name="catalog">The <see cref="IModuleCatalog"/></param>
        /// <param name="moduleName">Name of the module to be added.</param>
        /// <param name="moduleType"><see cref="Type"/> of the module to be added.</param>
        /// <param name="refValue">Reference to the location of the module to be added assembly.</param>
        /// <param name="initializationMode">Stage on which the module to be added will be initialized.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="IModuleCatalog"/> instance with the added module.</returns>
        public static IModuleCatalog AddModule(this IModuleCatalog catalog, string moduleName, Type moduleType, string refValue, InitializationMode initializationMode, params string[] dependsOn) =>
            InternalAddModule(catalog, moduleName, moduleType, refValue, initializationMode, dependsOn);

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="IModule"/></typeparam>
        /// <param name="catalog">The <see cref="IModuleCatalog"/></param>
        /// <param name="moduleName">Name of the module to be added.</param>
        /// <param name="refValue">Reference to the location of the module to be added assembly.</param>
        /// <param name="initializationMode">Stage on which the module to be added will be initialized.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="IModuleCatalog"/> instance with the added module.</returns>
        public static IModuleCatalog AddModule<T>(this IModuleCatalog catalog, string moduleName, string refValue, InitializationMode initializationMode, params string[] dependsOn)
            where T : IModule =>
            catalog.AddModule(moduleName, typeof(T), refValue, initializationMode, dependsOn);
#endif

        private static IModuleCatalog InternalAddModule(IModuleCatalog catalog, string moduleName, Type moduleType, string refValue, InitializationMode initializationMode, params string[] dependsOn)
        {
            if (moduleName == null)
                throw new ArgumentNullException(nameof(moduleName));

            if (moduleType == null)
                throw new ArgumentNullException(nameof(moduleType));

            ModuleInfo moduleInfo = new ModuleInfo(moduleType, moduleName)
            {
                InitializationMode = initializationMode,
#if NET45
                Ref = refValue
#endif
            };
            moduleInfo.DependsOn.AddRange(dependsOn);
            catalog.Items.Add(moduleInfo);
            return catalog;
        }

        /// <summary>
        /// Checks to see if the <see cref="IModule"/> exists in the <see cref="IModuleCatalog.Modules"/>  
        /// </summary>
        /// <returns><c>true</c> if the Module exists.</returns>
        /// <param name="catalog">Catalog.</param>
        /// <typeparam name="T">The <see cref="IModule"/> to check for.</typeparam>
        public static bool Exists<T>(this IModuleCatalog catalog)
            where T : IModule =>
            catalog.Modules.Any(mi => mi.ModuleType == typeof(T));

        /// <summary>
        /// Exists the specified catalog and name.
        /// </summary>
        /// <returns><c>true</c> if the Module exists.</returns>
        /// <param name="catalog">Catalog.</param>
        /// <param name="name">Name.</param>
        public static bool Exists(this IModuleCatalog catalog, string name) =>
            catalog.Modules.Any(module => module.ModuleName == name);

        /// <summary>
        /// Checks to see if the <see cref="IModule"/> is already initialized. 
        /// </summary>
        /// <returns><c>true</c>, if initialized, <c>false</c> otherwise.</returns>
        /// <param name="catalog">Catalog.</param>
        /// <typeparam name="T">The <see cref="IModule"/> to check.</typeparam>
        public static bool IsInitialized<T>(this IModuleCatalog catalog)
            where T : IModule =>
            catalog.Modules.FirstOrDefault(mi => mi.ModuleType == typeof(T))?.State == ModuleState.Initialized;

        /// <summary>
        /// Checks to see if the <see cref="IModule"/> is already initialized. 
        /// </summary>
        /// <returns><c>true</c>, if initialized, <c>false</c> otherwise.</returns>
        /// <param name="catalog">Catalog.</param>
        /// <param name="name">Name.</param>
        public static bool IsInitialized(this IModuleCatalog catalog, string name) =>
            catalog.Modules.FirstOrDefault(module => module.ModuleName == name)?.State == ModuleState.Initialized;
    }
}
