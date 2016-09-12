// <copyright file="HomeController.cshtml" company="Making Sense LLC">
//      Created: 09/09/2016
//      Making Sense. All rights reserved.
// </copyright>
// <author>MMinoldo</author>
// <summery></summery>
namespace MS.Sc.Web.Controllers
{
    using Business.Helpers;
    using Infrastructure.Controllers;
    using Infrastructure.Factories;
    using Models;

    using System.Web.Mvc;

    /// <summary>
    /// HomeController Class
    /// </summary>
    /// <seealso cref="MS.Sc.Infrastructure.Controllers.BaseController" />
    public class HomeController : BaseController
    {
        #region properties

        private IContactsService ContactsService { get; set; }

        #endregion

        #region methods

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

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        [HttpPost]
        public bool CreateContact(string email)
        {
            //TODO: Create contact logic
            ContactsService = IoC.Resolve<IContactsService>();
            
            return ContactsService.CreateUpdateContact(email);
        }

        #endregion
    }
}