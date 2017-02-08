using Burk.Model.Misc;
using System.Web.Mvc;

namespace Burk.WebUI.Controllers
{
    [Authorize]
    public class SettingSystemController : BaseController
    {
        public SettingSystemController() : base()
        {
            ViewBag.IsShowMenu = true;
        }

        public ActionResult Index(int systemId, int? dossierId)
        {
            ViewData["SystemId"] = systemId;
            return View();
        }
    }
}