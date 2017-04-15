using Burk.Logic.Abstract.Services;
using Burk.Logic.Concrete.Users.Managers;
using Burk.Model.Misc;
using Burk.Model.UDB;
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
        private ISystemService systemService;
        private IDossierService dossierService;
        private IInsetService insetService;
        private IDictionaryService dictionaryService;
        private IValueService valueService;
        #endregion

        #region ctor
        public WorkController(IDictionaryService _dicService, IInsetService _insetService, IDossierService _dossierService, ISystemService _service, IValueService _valueService, ApplicationUserManager userManager) : base(userManager)
        {
            systemService = _service;
            dossierService = _dossierService;
            insetService = _insetService;
            dictionaryService = _dicService;
            valueService = _valueService;
            ViewBag.IsShowSystemName = true;
            ViewBag.IsShowMenu = true;
        }
        #endregion

        public ActionResult Index(int systemId, int? dossierId)
        {
            CleanSessions();
            var system = systemService.GetById("SystemId", systemId.ToString());
            Session["SystemName"] = system.FullName;
            Session["SystemId"] = system.SystemId;
            Session["IsWork"] = true;
            if (dossierId != null && dossierId != 0)
            {
                var dossierObject = dossierService.GetById("DosObjectId", dossierId.ToString());
                Session["DossierName"] = dossierObject.FullName;
                Session["DossierId"] = dossierId;
            }
            else
            {
                Session["DossierName"] = null;
                Session["DossierId"] = null;
            }
            return View();
        }

        public ActionResult AddEditObj(int dossierId, int? mainListId, int? insetId, int? systemId)
        {
            int? valueId = null;
            var dossierObject = dossierService.GetById("DosObjectId", dossierId.ToString());
            Session["DossierName"] = dossierObject.FullName;
            Session["DossierId"] = dossierId;
            Session["MainListId"] = mainListId;
            Session["IsWork"] = true;
            if (systemId != null)
            {
                var system = systemService.GetById("SystemId", systemId.ToString());
                Session["SystemName"] = system.FullName;
                Session["SystemId"] = system.SystemId;
            }

            if (mainListId == null)
            {
                Session["IsCreate"] = true;
                Session["ListId"] = null;
            }
            else
            {
                Session["IsCreate"] = false;
                if (insetId == null)
                    valueId = valueService.GetFirstInsetValueIdByMainListId(mainListId.Value);
                else
                    valueId = valueService.GetValueIdByMainListAndInsetId(mainListId.Value, insetId.Value);
                DossierValue valueModel = valueService.GetById("DosValueId", valueId.ToString());
                Session["ListId"] = valueModel.DosListId;
                Session["InsetId"] = valueService.GetInsetIdByValueId(valueId.Value);
                var insetModel = insetService.GetById("DosInsetId", Session["InsetId"].ToString());
                Session["InsetName"] = insetModel.FullName;
            }
            Session["ValueId"] = valueId;

            return View();
        }
    }
}