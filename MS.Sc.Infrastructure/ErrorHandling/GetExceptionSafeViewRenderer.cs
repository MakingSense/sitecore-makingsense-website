namespace MS.Sc.Infrastructure.ErrorHandling
{
    using Sitecore.Mvc.Pipelines.Response.GetRenderer;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Mvc.Extensions;
    using Logging;
    using Factories;

    /// <summary>
    /// GetExceptionSafeViewRenderer Class
    /// </summary>
    public class GetExceptionSafeViewRenderer : GetViewRenderer
    {
        /// <summary>
        /// Gets the renderer.
        /// </summary>
        /// <param name="rendering">The rendering.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        protected override Renderer GetRenderer(Rendering rendering, GetRendererArgs args)
        {
            string viewPath = this.GetViewPath(rendering, args);
            
            if (viewPath.IsWhiteSpaceOrNull())
            {
                return null;
            }

            //Return the default view renderer if rendering something from core or the page layout
            if (rendering.RenderingType == Constants.Global.Layout ||
                rendering.RenderingItem == null ||
                rendering.RenderingItem.Database == null ||
                rendering.RenderingItem.Database.Name == Constants.Global.Core)
            {
                return new ViewRenderer
                {
                    ViewPath = viewPath,
                    Rendering = rendering
                };
            }
            else
            {
                //Return our special renderer
                return new ExceptionSafeViewRenderer
                {
                    ViewPath = viewPath,
                    Rendering = rendering
                };
            }
        }
    }
}
