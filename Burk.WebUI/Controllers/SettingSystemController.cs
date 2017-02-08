using Burk.Logic.Abstract.Services;
using Burk.Logic.Concrete.Users.Managers;
using Burk.Model.Misc;
using System.Web.Mvc;

namespace Burk.WebUI.Controllers
{
    [Authorize]
    public class SettingSystemController : BaseController
    {
        #region Fields
        private ISystemService service;
        //private ApplicationUserManager userManager;
        #endregion

        #region ctor
        public SettingSystemController(ISystemService _service)
        {
            service = _service;
        }

        public SettingSystemController(ISystemService _service, ApplicationUserManager userManager) : base(userManager)
        {
            service = _service;
            ViewBag.IsShowSystemName = true;
            ViewBag.IsShowMenu = true;
        }
        #endregion

        public ActionResult Index(int systemId, int? dossierId)
        {
            var model = service.GetById("SystemId", systemId.ToString());
            Session["SystemName"] = model.FullName;
            Session["SystemId"] = model.SystemId;
            ViewData["SystemId"] = systemId;
            return View();
        }
    }
}