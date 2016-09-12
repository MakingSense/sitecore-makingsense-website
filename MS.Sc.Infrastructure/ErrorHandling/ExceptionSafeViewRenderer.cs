namespace MS.Sc.Infrastructure.ErrorHandling
{
    using System;

    using Sitecore.Mvc.Presentation;

    using Logging;

    using Factories;
    using System.Web;
    using Sitecore.Configuration;
    using System.Globalization;

    /// <summary>
    /// ExceptionSafeViewRenderer Class
    /// </summary>
    public class ExceptionSafeViewRenderer : ViewRenderer
    {
        #region properties

        private ILoggingService _logger;

        #endregion

        #region methods

        /// <summary>
        /// Renders the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public override void Render(System.IO.TextWriter writer)
        {
            try
            {
                base.Render(writer);
            }
            catch (Exception ex)
            {
                _logger = IoC.Container.Resolve<ILoggingService>();

                //Handle exception and prevent it from bubbling up
                _logger.Error(string.Format("Failed to process view '{0}'", this.ViewPath), "Render", ex.Message, ex);

                Exception innerException = ex.InnerException;

                var format = HttpUtility.HtmlDecode(Settings.GetSetting("MS.Sc.Error.ErrorMessageFormat"));

                //If pagemode is normal then render an html comment with some clues to the problem
                if (Sitecore.Context.PageMode.IsNormal)
                {
                    writer.WriteLine("<!-- Exception rendering view '{0}': {1} -->", this.ViewPath, ex.Message);

                    while (innerException != null)
                    {
                        writer.WriteLine("<!-- Inner Exception: {0} -->", innerException.Message);

                        innerException = innerException.InnerException;
                    }

                    var messageTitle = HttpUtility.HtmlDecode(Settings.GetSetting("MS.Sc.Error.ErrorMessageTitle"));
                    var message = HttpUtility.HtmlDecode(Settings.GetSetting("MS.Sc.Error.ErrorMessageText"));

                    var html = string.Format(CultureInfo.InvariantCulture, format, messageTitle, message);

                    writer.Write(html);
                }
                else
                {
                    //In Experience Editor mode, render the exception in a div
                    writer.Write("<div class='view-render-exception'>");
                    writer.Write("Error rendering view {2}: {0}<br/><pre><code>{1}</code></pre>", ex.Message, ex.StackTrace, this.ViewPath);

                    while (innerException != null)
                    {
                        writer.Write("<hr/>Inner Exception {0}<br/><pre><code>{1}</code></pre>", innerException.Message, innerException.StackTrace);

                        innerException = innerException.InnerException;
                    }

                    writer.Write("</div>");
                }
            }
        }

        #endregion
    }
}
