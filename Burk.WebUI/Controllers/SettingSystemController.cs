using Burk.Logic.Abstract.Services;
using Burk.Logic.Concrete.Users.Managers;
using Burk.Model.Misc;
using System.Linq;
using System.Web.Mvc;

namespace Burk.WebUI.Controllers
{
    [Authorize]
    public class SettingSystemController : BaseController
    {
        #region Fields
        private ISystemService service;
        private IDossierService dossierService;
        private IInsetService insetService;
        private IDictionaryService dictionaryService;
        #endregion

        #region ctor
        public SettingSystemController(ISystemService _service)
        {
            service = _service;
        }

        public SettingSystemController(IDictionaryService _dicService, IInsetService _insetService, IDossierService _dossierService ,ISystemService _service, ApplicationUserManager userManager) : base(userManager)
        {
            service = _service;
            dossierService = _dossierService;
            insetService = _insetService;
            dictionaryService = _dicService;
            ViewBag.IsShowSystemName = true;
            ViewBag.IsShowMenu = true;
        }
        #endregion

        public ActionResult Index(int systemId, int? dossierId, int? insetId)
        {
            CleanSessions();
            var system = service.GetById("SystemId", systemId.ToString());
            Session["SystemName"] = system.FullName;
            Session["SystemId"] = system.SystemId;
            if (dossierId != null && dossierId != 0)
            {
                var dossierObject = dossierService.GetById("DosObjectId", dossierId.ToString());
                Session["DossierName"] = dossierObject.FullName;
                Session["DossierId"] = dossierId;
            }
            if (insetId != null && insetId != 0)
            {
                var insetObject = insetService.GetById("DosInsetId", insetId.ToString());
                Session["DossierInsetName"] = insetObject.FullName;
                Session["DossierInsetId"] = insetId;
            }
            return View();
        }
    }
}