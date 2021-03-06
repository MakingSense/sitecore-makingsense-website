﻿namespace MS.Sc.Infrastructure.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

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
                container.Register(Component.For<Business.Services.ISitecoreService>().ImplementedBy<Business.Services.SitecoreService>());
                container.Register(Component.For<Business.Helpers.IContactsService>().ImplementedBy<Business.Helpers.ContactsService>().LifeStyle.Singleton);

                // Logging
                container.Register(Component.For<ILoggingService>().ImplementedBy<WindsorLogging>().Named("WindsorLogging"));
            }
        }

        #endregion
    }
}
