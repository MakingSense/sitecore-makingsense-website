namespace MS.Sc.Business.Services
{
    using System;

    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Data.Managers;
    using Sitecore.Globalization;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// SitecoreService that connects to the sitecore backend 
    /// </summary>
    /// [CustomLifestyle(typeof(RecycledSingletonLifestyleManager))]
    public class SitecoreService : ISitecoreService
    {
        #region Properties

        /// <summary>
        /// Gets the current selected item in the Sitecore context.
        /// </summary>
        /// <value>
        /// The current item.
        /// </value>
        public Item CurrentItem
        {
            get
            {
                return Context.Item;
            }
        }

        /// <summary>
        /// Gets the current selected website language.
        /// </summary>
        /// <value>The current website language.</value>
        public Language CurrentWebsiteLanguage
        {
            get { return Context.Language; }
        }

        /// <summary>
        /// Gets the current rendering context.
        /// </summary>
        /// <value>
        /// The rendering context.
        /// </value>
        public RenderingContext RenderingContext
        {
            get { return RenderingContext.CurrentOrNull; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the dynamic URL.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public string GetDynamicUrl(Item item)
        {
            return Sitecore.Links.LinkManager.GetDynamicUrl(item);
        }
        /// <summary>
        /// Gets the item. 
        /// </summary>
        /// <param name="path"> The path. </param>
        /// <param name="language"> The language. </param>
        /// <param name="version"> The version. </param>
        /// <returns> returns a Sitecore Item </returns>
        public Item GetItem(string path, Language language, Sitecore.Data.Version version)
        {
            return Context.Database.GetItem(path, language, version);
        }

        /// <summary>
        /// Gets URL for the given Sitecore Item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public string GetItemUrl(Item item)
        {
            return Sitecore.Links.LinkManager.GetItemUrl(item);
        }

        /// <summary>
        /// Gets the language object/class from the given isoCode .
        /// </summary>
        /// <param name="isoCode">The iso code.</param>
        /// <returns></returns>
        public Language GetLanguage(string isoCode)
        {
            return LanguageManager.GetLanguage(isoCode);
        }

        /// <summary>
        /// Gets the latest version of the given item and in the given language.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public Item GetLatestVersion(Item item, Language language)
        {
            if (item == null) return null;
            return item.Versions.GetLatestVersion(language);
        }

        /// <summary>
        /// Gets the site information property.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GetSiteInfoProperty(string key)
        {
            return Context.Site.SiteInfo.Properties[key];
        }

        /// <summary>
        /// Isoes the date time to date time.
        /// </summary>
        /// <param name="isoDate">The iso date.</param>
        /// <returns></returns>
        public DateTime IsoDateTimeToDateTime(string isoDate)
        {
            return DateUtil.IsoDateToDateTime(isoDate);
        }

        #endregion Methods
    }
}