#region GlassMapperScCustom generated code
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Glass.Mapper.Configuration;
using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc.IoC;
using MS.Sc.Infrastructure.Helpers;
using System;
using IDependencyResolver = Glass.Mapper.Sc.IoC.IDependencyResolver;

namespace MS.Sc.Web.App_Start
{
    public static  class GlassMapperScCustom
    {
        /// <summary>
        /// Castles the configuration.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void CastleConfig(IWindsorContainer container)
        {
            if (container == null) return;

            Type[] installerTypes = WindsorHelper.GetWindsorInstallerTypes();

            foreach (var type in installerTypes)
            {
                object installer = Activator.CreateInstance(type);
                if (installer != null)
                {
                    container.Install(installer as IWindsorInstaller);
                }
            }
        }

        public static IDependencyResolver CreateResolver(){
			var config = new Glass.Mapper.Sc.Config();

			var dependencyResolver = new DependencyResolver(config);
            // add any changes to the standard resolver here
            
            return dependencyResolver;
		}

		public static IConfigurationLoader[] GlassLoaders(){			
			
			/* USE THIS AREA TO ADD FLUENT CONFIGURATION LOADERS
             * 
             * If you are using Attribute Configuration or automapping/on-demand mapping you don't need to do anything!
             * 
             */

			return new IConfigurationLoader[]{};
		}
		public static void PostLoad(){
			//Remove the comments to activate CodeFist
			/* CODE FIRST START
            var dbs = Sitecore.Configuration.Factory.GetDatabases();
            foreach (var db in dbs)
            {
                var provider = db.GetDataProviders().FirstOrDefault(x => x is GlassDataProvider) as GlassDataProvider;
                if (provider != null)
                {
                    using (new SecurityDisabler())
                    {
                        provider.Initialise(db);
                    }
                }
            }
             * CODE FIRST END
             */
		}
		public static void AddMaps(IConfigFactory<IGlassMap> mapsConfigFactory)
        {
			// Add maps here
            // mapsConfigFactory.Add(() => new SeoMap());
        }
    }
}
#endregion