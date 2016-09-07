namespace MS.Sc.Infrastructure.Controllers
{
    using System.Web;

    using Glass.Mapper.Sc.Web.Mvc;

    using Sitecore.Mvc.Presentation;

    using Factories;

    /// <summary>
    /// BaseController that will be used by every controller in this project. 
    /// </summary>
    public class BaseController : GlassController
    {
        #region Constructors

        public BaseController() : this(IoC.Container.Resolve<Business.Services.ISitecoreService>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        public BaseController(Business.Services.ISitecoreService sitecoreService)
        {
            this.MsSitecoreService = sitecoreService;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the sitecore service.
        /// </summary>
        /// <value>
        /// The sitecore service.
        /// </value>
        public Business.Services.ISitecoreService SitecoreService
        {
            get
            {
                return MsSitecoreService;
            }
        }

        /// <summary>
        /// Gets the ms sitecore service.
        /// </summary>
        /// <value>
        /// The ms sitecore service.
        /// </value>
        protected Business.Services.ISitecoreService MsSitecoreService
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the logging service.
        /// </summary>
        /// <value>
        /// The logging service.
        /// </value>
        private Logging.ILoggingService LoggingService
        {
            get
            {
                return IoC.Resolve<Logging.ILoggingService>();
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the rendering item parameter.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GetRenderingItemParameter(string key)
        {
            var result = string.Empty;

            var rc = RenderingContext.CurrentOrNull;

            if (rc != null && rc.Rendering != null)
            {
                var parametersAsString = rc.Rendering.RenderingItem.Parameters;
                var parameters = HttpUtility.ParseQueryString(parametersAsString);

                result = parameters[key] ?? string.Empty;
            }
            return result;
        }

        #endregion Methods
    }
}