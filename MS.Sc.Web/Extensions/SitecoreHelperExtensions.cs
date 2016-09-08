namespace MS.Sc.Business.SitecoreExtensions
{
    using Glass.Mapper.Sc;

    using Infrastructure.Factories;

    using Sitecore.Data.Items;
    using Sitecore.Mvc.Helpers;
    using Sitecore.Sites;

    using System;
    using System.Web;

    /// <summary>
    /// SitecoreHelperExtensions Class
    /// </summary>
    public static class SitecoreHelperExtensions
    {
        #region Methods

        /// <summary>
        /// Googles the analytics account code.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <returns></returns>
        public static HtmlString GoogleAnalyticsAccountCode(this SitecoreHelper helper)
        {
            //var sitecoreContext = IoC.Resolve<ISitecoreContext>();
            //var sitecoreService = IoC.Resolve<Services.ISitecoreService>();

            //Item item = sitecoreService.GetHomeItem<Item>();

            //if (!Sitecore.Context.PageMode.IsNormal || item == null)
            //{
            //    return new HtmlString(string.Empty);
            //}

            //var website = sitecoreService.Cast<Models.Site>(item);

            //if (website != null)
            //{
            //    return new HtmlString(website.AnalyticsAccountCode);
            //}

            return new HtmlString(string.Empty);
        }

        /// <summary>
        ///     Returns the the meta tag description from the current page and if emtpy the description
        ///     from the websitefolder
        /// </summary>
        /// <param name="helper"> The helper. </param>
        /// <returns></returns>
        public static HtmlString SeoMetaTagDescription(this SitecoreHelper helper)
        {
            return new HtmlString(string.Empty);
        }

        /// <summary>
        ///     Returns the the meta tag Keywords from the current page and if emtpy returns the
        ///     keywords from the websitefolder
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="keywords">The keywords.</param>
        /// <returns></returns>
        public static HtmlString SeoMetaTagKeywords(this SitecoreHelper helper, string keywords)
        {
            return new HtmlString(string.Empty);
        }

        /// <summary>
        ///     Seoes the meta tag robots.
        /// </summary>
        /// <param name="helper"> The helper. </param>
        /// <returns></returns>
        public static HtmlString SeoMetaTagRobots(this SitecoreHelper helper)
        {
            return new HtmlString(string.Empty);
        }

        /// <summary>
        ///     Seoes the meta title.
        /// </summary>
        /// <param name="helper"> The helper. </param>
        /// <returns></returns>
        public static HtmlString SeoMetaTitle(this SitecoreHelper helper)
        {
            return new HtmlString(string.Empty);
        }
        
        #endregion Methods
    }
}