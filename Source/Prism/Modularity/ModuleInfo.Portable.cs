#if !NET45
using System;
using System.Collections.ObjectModel;

namespace Prism.Modularity
{
    public partial class ModuleInfo
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ModuleInfo"/>.
        /// </summary>
        /// <param name="moduleType">The module's type.</param>
        public ModuleInfo(Type moduleType)
            : this(moduleType, moduleType.Name) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ModuleInfo"/>.
        /// </summary>
        /// <param name="moduleType">The module's type.</param>
        /// <param name="moduleName">The module's name.</param>
        public ModuleInfo(Type moduleType, string moduleName)
            : this(moduleType, moduleName, InitializationMode.WhenAvailable) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ModuleInfo"/>.
        /// </summary>
        /// <param name="moduleType">The module's type.</param>
        /// <param name="moduleName">The module's name.</param>
        /// <param name="initializationMode">The module's <see cref="InitializationMode"/>.</param>
        public ModuleInfo(Type moduleType, string moduleName, InitializationMode initializationMode)
        {
            ModuleType = moduleType;
            ModuleName = moduleName;
            InitializationMode = initializationMode;
        }
    }
}
#endif