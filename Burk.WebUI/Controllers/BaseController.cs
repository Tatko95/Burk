using Burk.Logic.Concrete.Users.Managers;
using Burk.WebUI.Helpers;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Web.Mvc;

namespace Burk.WebUI.Controllers
{
    public class BaseController : Controller
    {
        #region Ctor
        public BaseController()
        {

        }

        public BaseController(ApplicationUserManager _userManager)
        {
            userManager = _userManager;
        }
        #endregion

        #region Localization
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            int culture = 0;
            if (Session == null || Session["CurrentCulture"] == null)
            {
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["Culture"], out culture);
                Session["CurrentCulture"] = culture;
            }
            else
            {
                culture = (int)Session["CurrentCulture"];
            }
            CultureHelper.CurrentCulture = culture;

            base.OnActionExecuting(filterContext);
        }
        #endregion

        #region Users
        private ApplicationUserManager userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }
        #endregion
    }
}