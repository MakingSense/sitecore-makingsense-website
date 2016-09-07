using MS.Sc.Infrastructure.Factories;

namespace MS.Sc.Infrastructure.Pipelines
{
    /// <summary>
    /// InitializeControllerFactory Class
    /// </summary>
    public class InitializeControllerFactory : Sitecore.Mvc.Pipelines.Loader.InitializeControllerFactory
    {
        #region Methods

        /// <summary>
        /// Sets the controller factory.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected override void SetControllerFactory(Sitecore.Pipelines.PipelineArgs args)
        {
            // Set global controller factory
            System.Web.Mvc.ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());
        }

        #endregion Methods
    }
}
