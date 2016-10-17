using Burk.WebUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Burk.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeCurrentCulture(int id)
        {
            var t = Thread.CurrentThread.CurrentUICulture;
            CultureHelper.CurrentCulture = id;
            Session["CurrentCulture"] = id;
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}