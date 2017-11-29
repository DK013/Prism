using System;
using Prism.Ioc;
using Prism.Logging;

namespace Prism.Modularity
{
    public partial class ModuleInitializer : IModuleInitializer
    {
        private IContainerExtension _container { get; }
        private ILoggerFacade _loggerFacade { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ModuleInitializer"/>.
        /// </summary>
        /// <param name="container">The container that will be used to resolve the modules by specifying its type.</param>
        /// <param name="loggerFacade">The logger to use.</param>
        public ModuleInitializer(IContainerExtension container, ILoggerFacade loggerFacade)
        {
            _container = container;
            _loggerFacade = loggerFacade;
        }

        /// <summary>
        /// Uses the container to resolve a new <see cref="IModule"/> by specifying its <see cref="Type"/>.
        /// </summary>
        /// <param name="moduleType">The type name to resolve. This type must implement <see cref="IModule"/>.</param>
        /// <returns>A new instance of <paramref name="moduleType"/>.</returns>
        protected virtual IModule CreateModule(Type moduleType)
        {
            return (IModule)_container.Resolve(moduleType);
        }
    }
}
