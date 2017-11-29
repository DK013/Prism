

using Prism.Ioc;
using Prism.Mef.Modularity;
using Prism.Modularity;

namespace Prism.Mef.Wpf.Tests.Support
{
    [ModuleExport("MefModuleOne", typeof(MefModuleOne))]
    public class MefModuleOne : IModule
    {
        public bool WasInitialized = false;

        public void OnInitialized()
        {
            WasInitialized = true;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
