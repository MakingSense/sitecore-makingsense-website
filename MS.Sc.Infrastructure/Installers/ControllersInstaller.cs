namespace MS.Sc.Infrastructure.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Factories;
    using Helpers;
    using Logging;

    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web.Mvc;

    /// <summary>
    /// BusinessComponentsInstaller class for registering the classes 
    /// </summary>
    public class ControllersInstaller : IWindsorInstaller
    {
        #region Methods

        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var logger = new WindsorLogging();

            if (container == null)
            {
                logger.Error("ControllersInstaller: parameter container is null ");

                return;
            }

            string[] controllerAssemblies = WindsorHelper.GetWindsorControllerAssemblies();

            foreach (var assembly in controllerAssemblies)
            {
                try
                {
                    var controllerTypes = from t in Assembly.Load(assembly).GetTypes()
                                          where typeof(IController).IsAssignableFrom(t)
                                          select t;

                    foreach (var t in controllerTypes)
                    {
                        // Check if the ControllerType is not allready Registerd
                        if (!IoC.Container.Kernel.HasComponent(t))
                        {
                            logger.Info(string.Format(CultureInfo.InvariantCulture, "Windsor : Registering controller for {0}", t.FullName));

                            container.Register(Component.For(t).LifestyleTransient());
                        }
                    }

                }
                catch (ReflectionTypeLoadException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    logger.Error("ControllersInstaller : ReflectionTypeLoadException ", ex);

                    if (ex.LoaderExceptions == null || !ex.LoaderExceptions.Any())
                    {
                        return;
                    }

                    foreach (var loaderException in ex.LoaderExceptions)
                    {
                        sb.AppendLine(loaderException.Message);

                        if (loaderException.InnerException != null)
                        {
                            sb.AppendLine(loaderException.InnerException.Message);
                        }
                    }

                    logger.Error(sb.ToString());
                }
            }
        }

        #endregion
    }
}
