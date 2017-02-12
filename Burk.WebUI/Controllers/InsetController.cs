using Burk.Logic.Abstract.Services;
using Burk.Logic.Concrete.Users.Managers;
using Burk.Model.UDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Burk.WebUI.Controllers
{
    public class InsetController : BaseController
    {
        #region Fields
        private IInsetService service;
        #endregion

        #region ctor
        public InsetController(IInsetService _service)
        {
            service = _service;
        }

        public InsetController(IInsetService _service, ApplicationUserManager userManager) : base(userManager)
        {
            service = _service;
        }
        #endregion

        #region LIST
        public JsonResult GetInsetItemForSettings(int dossierId)
        {
            var list = service.GetInsetItemsForSettings(dossierId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region CRUD with MenuItem
        #region AddEdit
        [HttpGet]
        public ActionResult AddEditInsetItem(int? insetId)
        {
            DossierInset model = service.GetById("DosInsetId", insetId.ToString());
            if (insetId == null || insetId == 0)
                model.DosObjectId = (int)Session["DossierId"];
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddEditInsetItem(DossierInset model)
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
        public ActionResult DeleteInsetItem(int insetId)
        {
            try
            {
                var model = service.GetById("DosInsetId", insetId.ToString());
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

        #region RightLeft InsetItem
        public ActionResult LeftInsetItem(int insetId)
        {
            try
            {
                service.LeftInsetItem(insetId);
            }
            catch (Exception)
            {
                return Content("Error");
            }
            return Content("Success");
        }

        public ActionResult RightInsetItem(int insetId)
        {
            try
            {
                service.RightInsetItem(insetId);
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