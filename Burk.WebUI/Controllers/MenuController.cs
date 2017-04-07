using Burk.Logic.Abstract.Services;
using Burk.Logic.Concrete.Users.Managers;
using Burk.Model.Misc;
using System.Collections.Generic;
using System.Web.Mvc;
using Burk.Model.Resources;
using Burk.Model.UDB;
using System;

namespace Burk.WebUI.Controllers
{
    public class MenuController : BaseController
    {
        #region Fields
        private IDossierService service;
        #endregion

        #region ctor
        public MenuController(IDossierService _service)
        {
            service = _service;
        }

        public MenuController(IDossierService _service, ApplicationUserManager userManager) : base(userManager)
        {
            service = _service;
        }
        #endregion

        #region LIST
        public JsonResult GetMenuItemsForSettings(int systemId)
        {
            var list = service.GetMenuItemsForSettings(systemId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region CRUD with MenuItem
        #region AddEdit
        [HttpGet]
        public ActionResult AddEditMenuItem(int? dossierId)
        {
            DossierObject model = service.GetById("DosObjectId", dossierId.ToString());
            if (dossierId == null || dossierId == 0)
                model.SystemId = (int)Session["SystemId"];
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddEditMenuItem(DossierObject model)
        {
            try
            {
                service.Upsert(model);
            }
            catch (Exception)
            {
                return Content("Error");
            }
            return Content("Success");
        }
        #endregion

        #region Delete
        public ActionResult DeleteMenuItem(int dossierId)
        {
            CleanSessions();
            try
            {
                var model = service.GetById("DosObjectId", dossierId.ToString());
                service.Delete(model);
            }
            catch (Exception)
            {
                return Content("Error");
            }
            return Content("Success");
        }
        #endregion
        #endregion

        #region UpDown MenuItem
        public ActionResult UpMenuItem(int dossierId)
        {
            try
            {
                service.UpMenuItem(dossierId);
            }
            catch (Exception)
            {
                return Content("Error");
            }
            return Content("Success");
        }

        public ActionResult DownMenuItem(int dossierId)
        {
            try
            {
                service.DownMenuItem(dossierId);
            }
            catch (Exception)
            {
                return Content("Error");
            }
            return Content("Success");
        }
        #endregion
    }
}