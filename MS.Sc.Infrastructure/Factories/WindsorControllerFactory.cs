namespace MS.Sc.Infrastructure.Factories
{
    using System;

    using System.Web.Mvc;
    using System.Web.Routing;

    using Logging;

    /// <summary>
    /// WindsorControllerFactory Class
    /// </summary>
    /// <seealso cref="System.Web.Mvc.DefaultControllerFactory" />
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        #region Fields

        private ILoggingService _logger;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorControllerFactory" /> class.
        /// </summary>
        public WindsorControllerFactory()
        {
            //_logger = IoC.Container.Resolve<ILoggingService>("WindsorLogging");
            _logger = new WindsorLogging();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Releases the specified controller.
        /// </summary>
        /// <param name="controller">The controller to release.</param>
        public override void ReleaseController(IController controller)
        {
            if (controller == null)
            {
                return;
            }

            _logger.DebugFormat("WindsorControllerFactory : ReleaseController {0}", controller.GetType().Name);

            IoC.Container.Release(controller);
        }

        /// <summary>
        /// Retrieves the controller instance for the specified request context and controller type. 
        /// </summary>
        /// <param name="requestContext">
        /// The context of the HTTP request, which includes the HTTP context and route data.
        /// </param>
        /// <param name="controllerType"> The type of the controller. </param>
        /// <exception cref="T:System.Web.HttpException">
        /// <paramref name="controllerType" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="controllerType" /> cannot be assigned.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// An instance of <paramref name="controllerType" /> cannot be created.
        /// </exception>
        /// <returns> The controller instance. </returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = null;

            if (controllerType == null || requestContext == null)
            {
                if (controllerType == null) _logger.Error("WindsorControllerFactory : GetControllerInstance controllertype = null");
                if (requestContext != null) _logger.Error("WindsorControllerFactory : GetControllerInstance requestContext = null");

                return null;
            }

            if (!IoC.Container.Kernel.HasComponent(controllerType))
            {
                // Controller type not found in IoC so must be one from sitecore core
                // we must call in the base function

                controller = base.GetControllerInstance(requestContext, controllerType);

                if (controller == null)
                {
                    _logger.ErrorFormat("WindsorControllerFactory : (base) Can't resolve the controller off type  ({0}) ", controllerType.Name);

                    return null;
                }

                _logger.DebugFormat("WindsorControllerFactory : (base) GetControllerInstance controller ({0}) Resolved", controllerType.Name);

                return controller;

            }

            controller = (IController)IoC.Container.Resolve(controllerType);

            if (controller != null)
            {
                _logger.DebugFormat("WindsorControllerFactory : GetControllerInstance controller ({0}) Resolved", controllerType.Name);

                return controller;
            }

            return null;
        }

        #endregion Methods
    }
}