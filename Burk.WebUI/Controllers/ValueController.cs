using Burk.Logic.Abstract.Services;
using Burk.Logic.Concrete.Users.Managers;
using Burk.Model.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Burk.WebUI.Controllers
{
    public class ValueController : BaseController
    {
        #region Fields
        private IValueService service;
        #endregion

        #region ctor
        public ValueController(IValueService _service, ApplicationUserManager userManager) : base(userManager)
        {
            service = _service;
            ViewBag.IsShowSystemName = true;
            ViewBag.IsShowMenu = true;
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetGridValues(int dossierId)
        {
            IEnumerable<GridItem> gridValues = service.GetGridValuesByDossierId(dossierId);

            return Json(gridValues, JsonRequestBehavior.AllowGet);
        }

        #region CRUD
        public ActionResult SaveValues(string obj, int dossierId)
        {
            IList<AttributeValue> modelObj = new JavaScriptSerializer().Deserialize<IList<AttributeValue>>(obj);
            int mainListId = service.InsertValuesWithList(modelObj, dossierId);
            return Content(mainListId.ToString());
        }
        
        public ActionResult EditValue(int valueId, string obj)
        {
            IList<AttributeValue> modelObj = new JavaScriptSerializer().Deserialize<IList<AttributeValue>>(obj);
            service.UpdateValues(modelObj, valueId);

            return Content(string.Empty);
        }

        public ActionResult DeleteValue(int mainListId)
        {
            service.DeleteValueByMainListId(mainListId);
            return Content(string.Empty);
        }
        #endregion

        public JsonResult GetValueAttrByValueId(int valueId, string typeName, string typeIndex)
        {
            var returnValue = service.GetValueAttrByValueId(valueId, typeName, typeIndex);
            return Json(returnValue, JsonRequestBehavior.AllowGet);
        }
    }
}