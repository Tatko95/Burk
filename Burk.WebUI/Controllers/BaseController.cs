using Burk.WebUI.Helpers;
using System;
using System.Web.Mvc;

namespace Burk.WebUI.Controllers
{
    public class BaseController : Controller
    {
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
    }
}