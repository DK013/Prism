using Prism.Ioc;
using Prism.Modularity;
using System;

namespace Prism.Wpf.Tests.Mocks.Modules
{
    public class MockModuleA : IModule
    {
        public void OnInitialized()
        {
            throw new System.NotImplementedException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }

    public class DummyClass
    {
    }
}
