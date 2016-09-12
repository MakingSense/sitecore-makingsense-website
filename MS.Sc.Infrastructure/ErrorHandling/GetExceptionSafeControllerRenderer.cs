namespace MS.Sc.Infrastructure.ErrorHandling
{
    using System;

    using Sitecore.Mvc.Pipelines.Response.GetRenderer;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// Override the existing pipeline step to return our safe exception renderer if needed
    /// </summary>
    public class GetExceptionSafeControllerRenderer : GetControllerRenderer
    {
        /// <summary>
        /// Gets the renderer.
        /// </summary>
        /// <param name="rendering">The rendering.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        protected override Renderer GetRenderer(Rendering rendering, GetRendererArgs args)
        {
            Tuple<string, string> controllerAndAction = this.GetControllerAndAction(rendering, args);
            
            if (controllerAndAction == null)
            {
                return null;
            }

            string controlerName = controllerAndAction.Item1;
            string actionName = controllerAndAction.Item2;

            if (rendering.RenderingType == Constants.Global.Layout || 
                rendering.RenderingItem == null || 
                rendering.RenderingItem.Database == null || 
                rendering.RenderingItem.Database.Name == Constants.Global.Core)
            {
                return new ControllerRenderer
                {
                    ControllerName = controlerName,
                    ActionName = actionName
                };
            }
            else
            {
                return new ExceptionSafeControllerRenderer
                {
                    ControllerName = controlerName,
                    ActionName = actionName
                };
            }
        }
    }
}
