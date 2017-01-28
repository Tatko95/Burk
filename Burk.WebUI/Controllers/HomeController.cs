using Burk.Model.Resources;
using Burk.WebUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

        public ActionResult GenerateJS_Of_Resource()
        {
            string dataBegin = "var localization = ";

            Dictionary<string, string> msg = new Dictionary<string, string>();
            foreach (var tt in typeof(Resource).GetProperties())
                if (tt.PropertyType.Name == "String")
                    msg.Add(tt.Name, tt.GetValue(typeof(Resource)).ToString());
            JavaScriptSerializer js = new JavaScriptSerializer();

            string data = dataBegin + MvcHtmlString.Create(js.Serialize(msg));

            return JavaScript(data);
        }
    }
}