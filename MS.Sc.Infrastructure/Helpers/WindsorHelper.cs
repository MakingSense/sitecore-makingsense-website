namespace MS.Sc.Infrastructure.Helpers
{
    using Sitecore.Configuration;

    using System;
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// Windsor Helper Class
    /// </summary>
    public static class WindsorHelper
    {
        #region Methods

        /// <summary>
        /// Gets the windsor controller assemblies.
        /// </summary>
        /// <returns></returns>
        public static string[] GetWindsorControllerAssemblies()
        {
            var f = Factory.GetConfigNode("Windsor.ContainerConfiguration/controllers");
            var list = new List<string>();

            if (f == null)
            {
                return list.ToArray();
            }

            foreach (XmlNode assembly in f.ChildNodes)
            {
                if (assembly.Attributes != null && assembly.Attributes["name"] != null)
                {
                    list.Add(assembly.Attributes["name"].InnerText);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Gets the windsor installer types.
        /// </summary>
        /// <returns></returns>
        public static Type[] GetWindsorInstallerTypes()
        {
            var f = Factory.GetConfigNode("Windsor.ContainerConfiguration/installers");
            var list = new List<Type>();

            if (f == null) return list.ToArray();

            foreach (XmlNode assembly in f.ChildNodes)
            {
                if (assembly.Attributes != null && assembly.Attributes["name"] != null)
                {
                    list.Add(Type.GetType(assembly.Attributes["name"].InnerText, true));
                }
            }
            return list.ToArray();
        }

        #endregion Methods
    }
}
