using System;
using System.Globalization;
using CommonServiceLocator;
using Prism.Logging;

namespace Prism.Modularity
{
    public partial class ModuleInitializer
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly ILoggerFacade _loggerFacade;

        /// <summary>
        /// Initializes a new instance of <see cref="ModuleInitializer"/>.
        /// </summary>
        /// <param name="serviceLocator">The container that will be used to resolve the modules by specifying its type.</param>
        /// <param name="loggerFacade">The logger to use.</param>
        public ModuleInitializer(IServiceLocator serviceLocator, ILoggerFacade loggerFacade)
        {
            this._serviceLocator = serviceLocator ?? throw new ArgumentNullException(nameof(serviceLocator));
            this._loggerFacade = loggerFacade ?? throw new ArgumentNullException(nameof(loggerFacade));
        }

        /// <summary>
        /// Uses the container to resolve a new <see cref="IModule"/> by specifying its <see cref="Type"/>.
        /// </summary>
        /// <param name="moduleType">The type name to resolve. This type must implement <see cref="IModule"/>.</param>
        /// <returns>A new instance of <paramref name="moduleType"/>.</returns>
        protected virtual IModule CreateModule(Type moduleType)
        {
            //Type moduleType = Type.GetType(typeName);
            if (moduleType == null)
            {
                throw new ModuleInitializeException(string.Format(CultureInfo.CurrentCulture, Properties.Resources.FailedToGetType, moduleType.AssemblyQualifiedName));
            }

            return (IModule)this._serviceLocator.GetInstance(moduleType);
        }
    }
}
