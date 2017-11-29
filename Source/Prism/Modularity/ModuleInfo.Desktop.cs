#if NET45

using System;
using System.Collections.ObjectModel;

namespace Prism.Modularity
{
    [Serializable]
    public partial class ModuleInfo
    {
        /// <summary>
        /// Initializes a new empty instance of <see cref="ModuleInfo"/>.
        /// </summary>
        public ModuleInfo()
            : this(null, null, new string[0])
        {
        }

        /// <summary>
        /// Reference to the location of the module assembly.
        /// <example>The following are examples of valid <see cref="ModuleInfo.Ref"/> values:
        /// file://c:/MyProject/Modules/MyModule.dll for a loose DLL in WPF.
        /// </example>
        /// </summary>
        public string Ref { get; set; }
    }
}
#endif
