namespace MS.Sc.Business.ErrorHandling
{
    using System;

    using Sitecore.Diagnostics;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// ExceptionSafeViewRenderer Class
    /// </summary>
    public class ExceptionSafeViewRenderer : ViewRenderer
    {
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
                //Handle exception and prevent it from bubbling up
                Log.Error(string.Format("Failed to process view '{0}'", this.ViewPath), ex, this);

                Exception innerException = ex.InnerException;

                //If pagemode is normal then render an html comment with some clues to the problem
                if (Sitecore.Context.PageMode.IsNormal)
                {
                    writer.WriteLine("<!-- Exception rendering view '{0}': {1} -->", this.ViewPath, ex.Message);

                    while (innerException != null)
                    {
                        writer.WriteLine("<!-- Inner Exception: {0} -->", innerException.Message);

                        innerException = innerException.InnerException;
                    }
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
    }
}
