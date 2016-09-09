namespace MS.Sc.Business.Services
{
    using Sitecore.Data.Items;
    using Sitecore.Globalization;
    using Sitecore.Mvc.Presentation;

    using System;

    /// <summary>
    /// Interface for creating a Service that connects to Sitecore functionality 
    /// </summary>
    public interface ISitecoreService
    {
        #region Properties

        /// <summary>
        /// Gets the current item.
        /// </summary>
        /// <value>
        /// The current item.
        /// </value>
        Item CurrentItem
        {
            get;
        }

        /// <summary>
        /// Gets the current website language.
        /// </summary>
        /// <value>The current website language.</value>
        Language CurrentWebsiteLanguage
        {
            get;
        }

        /// <summary>
        /// Gets the rendering context.
        /// </summary>
        /// <value>
        /// The rendering context.
        /// </value>
        RenderingContext RenderingContext
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the dynamic URL.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        string GetDynamicUrl(Item item);

        /// <summary>
        /// Gets the item. 
        /// </summary>
        /// <param name="path"> The path. </param>
        /// <param name="language"> The language. </param>
        /// <param name="version"> The version. </param>
        /// <returns> returns a Sitecore Item </returns>
        Item GetItem(string path, Language language, Sitecore.Data.Version version);

        /// <summary>
        /// Gets URL for the given Sitecore Item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        string GetItemUrl(Item item);

        /// <summary>
        /// Gets the language object/class from the given isoCode .
        /// </summary>
        /// <param name="isoCode">The iso code.</param>
        /// <returns></returns>
        Language GetLanguage(string isoCode);

        /// <summary>
        /// Gets the latest version of the given item and in the given language.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        Item GetLatestVersion(Item item, Language language);

        /// <summary>
        /// Gets the site information property.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        string GetSiteInfoProperty(string key);

        /// <summary>
        /// Isoes the date time to date time.
        /// </summary>
        /// <param name="isoDate">The iso date.</param>
        /// <returns></returns>
        DateTime IsoDateTimeToDateTime(string isoDate);

        string GetVideoUrl(Item item);

        #endregion Methods
    }
}