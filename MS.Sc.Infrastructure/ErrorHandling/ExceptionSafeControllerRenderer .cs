namespace MS.Sc.Infrastructure.ErrorHandling
{
    using System;

    using Sitecore.Mvc.Presentation;

    using Logging;

    using Factories;
    using Sitecore.Configuration;
    using System.Web;
    using System.Globalization;

    /// <summary>
    /// ExceptionSafeViewRenderer Class
    /// </summary>
    public class ExceptionSafeControllerRenderer : ControllerRenderer
    {
        #region properties

        private ILoggingService _logger;

        #endregion

        #region methods

        /// <summary>
        /// Overrides the exsiting renderer and wraps the render method in a try/catch
        /// </summary>
        /// <param name="writer"></param>
        public override void Render(System.IO.TextWriter writer)
        {
            try
            {
                base.Render(writer);
            }
            catch (Exception ex)
            {
                _logger = IoC.Container.Resolve<ILoggingService>();

                //Process any exceptions
                _logger.Error(string.Format("Failed to process controller '{0}.{1}'", this.ControllerName, this.ActionName), "Render", ex.Message, ex);

                Exception innerException = ex.InnerException;

                var format = HttpUtility.HtmlDecode(Settings.GetSetting("MS.Sc.Error.ErrorMessageFormat"));

                //If in normal mode, render an html comment
                if (Sitecore.Context.PageMode.IsNormal)
                {
                    writer.WriteLine("<!-- Exception rendering controler '{0}.{1}': {2} -->", this.ControllerName, this.ActionName, ex.Message);

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
                    //If in experience editor mode, render the exception in a div
                    writer.Write("<div class='controller-render-exception'>");
                    writer.Write("Error rendering controller {2}.{3}: {0}<br/><pre><code>{1}</code></pre>", ex.Message, ex.StackTrace, this.ControllerName, this.ActionName);

                    while (innerException != null)
                    {
                        writer.Write("<hr/>Inner Exception {0}<br/><pre><code>{1}</code></pre>", innerException.Message, innerException.StackTrace);

                        innerException = innerException.InnerException;
                    }

                    writer.Write("</div>");
                }
            }

            #endregion
        }
    }
}
