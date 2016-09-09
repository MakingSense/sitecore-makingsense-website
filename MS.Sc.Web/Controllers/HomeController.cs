// <copyright file="HomeController.cshtml" company="Making Sense LLC">
//      Created: 09/09/2016
//      Making Sense. All rights reserved.
// </copyright>
// <author>MMinoldo</author>
// <summery></summery>
namespace MS.Sc.Web.Controllers
{
    using Infrastructure.Controllers;

    using Models;

    using System.Web.Mvc;

    /// <summary>
    /// HomeController Class
    /// </summary>
    /// <seealso cref="MS.Sc.Infrastructure.Controllers.BaseController" />
    public class HomeController : BaseController
    {
        // GET: Home
        /// <summary>
        /// vs this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult VideoSlide()
        {
            var viewModel = this.GetDataSourceItem<IVideo_Slide>();

            return View(Constants.ViewsPaths.VideoSlide, viewModel);
        }
    }
}