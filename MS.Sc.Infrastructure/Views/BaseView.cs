using Glass.Mapper.Sc.Web.Mvc;

namespace MS.Sc.Infrastructure.Views
{
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
