namespace MS.Sc.Infrastructure.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Glass.Mapper.Sc;

    using Logging;

    /// <summary>
    /// BusinessComponentsInstaller class for registering the classes 
    /// </summary>
    public class BusinessComponentsInstaller : IWindsorInstaller
    {
        #region Methods

        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container != null)
            {
                // Services
                container.Register(Component.For<ISitecoreService>().ImplementedBy<SitecoreService>());

                // Logging
                container.Register(Component.For<ILoggingService>().ImplementedBy<WindsorLogging>().Named("WindsorLogging"));
            }
        }

        #endregion
    }
}
