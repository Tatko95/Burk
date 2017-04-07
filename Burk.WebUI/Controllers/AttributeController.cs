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
    [Authorize]
    public class AttributeController : BaseController
    {
        #region Fields
        private IAttributeService service;
        #endregion

        #region ctor
        public AttributeController(IAttributeService _service)
        {
            service = _service;
        }

        public AttributeController(IAttributeService _service, ApplicationUserManager userManager) : base(userManager)
        {
            service = _service;
            ViewBag.IsShowSystemName = true;
            ViewBag.IsShowMenu = true;
        }
        #endregion

        #region CRUD
        #region AddEdit
        [HttpGet]
        public ActionResult AddEditAttribute(int? attributeId, int? insetId)
        {
            DossierAttribute model = service.GetById("DosAttributeId", attributeId.ToString());
            if (attributeId == null || attributeId == 0)
                model.DosInsetId = insetId;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddEditAttribute(DossierAttribute model)
        {
            try
            {
                if (model.DosAttributeId == 0)
                {
                    model = service.InsertAttribute(model);
                    return Content(model.DosAttributeId.ToString());
                }
                else
                {
                    service.Update(model);
                    return Content("Edit" + model.DosAttributeId.ToString());
                }
            }
            catch (Exception)
            {
                return Content("Error");
            }
        }

        public ActionResult UpdatePositionAttribute(int? attrId, int x, int y)
        {
            try
            {
                service.UpdatePositionAttribute(attrId.Value, x, y);
            }
            catch
            {
                return Content("Error");
            }
            return Content(string.Empty);
        }

        public ActionResult UpdateSizeAttribute(int? attrId, int width, int height)
        {
            try
            {
                service.UpdateSizeAttribute(attrId.Value, width, height);
            }
            catch
            {
                return Content("Error");
            }
            return Content(string.Empty);
        }

        public JsonResult GetAttributePanel(int insetId)
        {
            var attributes = service.GetAllAttributes(insetId);
            return Json(attributes, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete
        public ActionResult DeleteAttribute(int? attributeId)
        {
            try
            {
                DossierAttribute model = service.GetById("DosAttributeId", attributeId.ToString());
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
    }
}