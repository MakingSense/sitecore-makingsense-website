namespace MS.Sc.Infrastructure.Views
{
    using System.Globalization;
    using System.Web;

    using Glass.Mapper.Sc;
    using Glass.Mapper.Sc.Web;
    using Glass.Mapper.Sc.Web.Mvc;

    using Sitecore.Mvc;
    using Sitecore.Mvc.Helpers;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// BaseView Class
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="Glass.Mapper.Sc.Web.Mvc.GlassView{TModel}" />
    public class BaseView<TModel> : GlassView<TModel> where TModel : class
    {
        /// <summary>
        /// Executes this instance. 
        /// </summary>
        public override void Execute()
        {
        }
    }
}
