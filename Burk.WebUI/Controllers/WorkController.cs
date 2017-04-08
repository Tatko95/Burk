using Burk.Logic.Abstract.Services;
using Burk.Logic.Concrete.Users.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Burk.WebUI.Controllers
{
    [Authorize]
    public class WorkController : BaseController
    {
        #region Fields
        private ISystemService service;
        private IDossierService dossierService;
        private IInsetService insetService;
        private IDictionaryService dictionaryService;
        #endregion

        #region ctor
        //public WorkController(ISystemService _service)
        //{
        //    service = _service;
        //}

        public WorkController(IDictionaryService _dicService, IInsetService _insetService, IDossierService _dossierService, ISystemService _service, ApplicationUserManager userManager) : base(userManager)
        {
            service = _service;
            dossierService = _dossierService;
            insetService = _insetService;
            dictionaryService = _dicService;
            ViewBag.IsShowSystemName = true;
            ViewBag.IsShowMenu = true;
        }
        #endregion

        public ActionResult Index(int systemId, int? dossierId)
        {
            CleanSessions();
            var system = service.GetById("SystemId", systemId.ToString());
            Session["SystemName"] = system.FullName;
            Session["SystemId"] = system.SystemId;
            Session["IsWork"] = true;
            if (dossierId != null && dossierId != 0)
            {
                var dossierObject = dossierService.GetById("DosObjectId", dossierId.ToString());
                Session["DossierName"] = dossierObject.FullName;
                Session["DossierId"] = dossierId;
            }
            return View();
        }

        //public JsonResult GetGrid(int systemId, int dossierId)
        //{
        //    var systems = service.GetAllByUser(CurrentUser.Id);
        //    var systemsList = systems.ToList();

        //    var jsonData = from item in systemsList
        //                   select new
        //                   {
        //                       item.SystemId,
        //                       item.FullName,
        //                       item.ShortName
        //                   };

        //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //}
    }
}