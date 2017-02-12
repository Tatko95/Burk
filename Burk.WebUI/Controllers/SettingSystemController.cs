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
        private IDossierService dossierService;
        //private ApplicationUserManager userManager;
        #endregion

        #region ctor
        public SettingSystemController(ISystemService _service)
        {
            service = _service;
        }

        public SettingSystemController(IDossierService _dossierService ,ISystemService _service, ApplicationUserManager userManager) : base(userManager)
        {
            service = _service;
            dossierService = _dossierService;
            ViewBag.IsShowSystemName = true;
            ViewBag.IsShowMenu = true;
        }
        #endregion

        public ActionResult Index(int systemId, int? dossierId)
        {
            var system = service.GetById("SystemId", systemId.ToString());
            Session["SystemName"] = system.FullName;
            Session["SystemId"] = system.SystemId;
            if (dossierId != null && dossierId != 0)
            {
                var dossierObject = dossierService.GetById("DosObjectId", dossierId.ToString());
                ViewData["DossierName"] = dossierObject.FullName;
                Session["DossierId"] = dossierId;
            }
            return View();
        }
    }
}