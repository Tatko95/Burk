using Burk.Logic.Abstract.Services;
using Burk.Logic.Concrete.Users.Managers;
using Burk.Model.Misc;
using System.Collections.Generic;
using System.Web.Mvc;
using Burk.Model.Resources;
using Burk.Model.UDB;

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

        public JsonResult GetMenuItems(int systemId)
        {
            var list = service.GetMenuItemsForSettings(systemId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEditMenuItem(int? dossierId)
        {
            DossierObject model = service.GetById("DosObjectId", dossierId.ToString());
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddEditMenuItem(DossierObject model)
        {
            try
            {
                service.Insert(model);
            }
            catch (System.Exception)
            {
                return Content("Error");
            }
            return Content("Success");
        }
    }
}