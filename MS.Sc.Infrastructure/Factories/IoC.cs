namespace MS.Sc.Infrastructure.Factories
{
    using System;

    using Castle.Windsor;

    /// <summary>
    /// IoC Class
    /// </summary>
    public static class IoC
    {
        #region Fields

        /// <summary>
        /// Lock Object 
        /// </summary>
        private static readonly object LockObj = new object();

        /// <summary>
        /// Container variable. 
        /// </summary>        
        private static IWindsorContainer _container = null;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the container. 
        /// </summary>
        /// <value> The container. </value>
        public static IWindsorContainer Container
        {
            get
            {
                return _container;
            }

            set
            {
                lock (LockObj)
                {
                    _container = value;
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public static void Dispose()
        {
            if (_container != null)
            {
                _container.Dispose();
            }
        }

        /// <summary>
        /// Resolves this instance. 
        /// </summary>
        /// <typeparam name="T"> The type of the T. </typeparam>
        /// <returns> Return type T </returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Resolves the specified type. 
        /// </summary>
        /// <param name="type"> The type. </param>
        /// <returns> returns object type </returns>
        public static object Resolve(Type type)
        {
            return Container.Resolve(type);
        }

        #endregion Methods
    }
}