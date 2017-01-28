using Burk.Logic.Abstract.Services;
using Burk.Logic.Concrete.Users.Managers;
using Burk.Model.Users;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Burk.WebUI.Controllers
{
    [Authorize]
    public class SystemController : BaseController
    {
        #region Fields
        private ISystemService service;
        //private ApplicationUserManager userManager;
        #endregion

        #region ctor
        public SystemController(ISystemService _service)
        {
            service = _service;
        }

        public SystemController(ISystemService _service, ApplicationUserManager userManager) : base(userManager)
        {
            service = _service;
        }
        #endregion

        #region GRIDS
        public JsonResult GetListSystems()
        {
            User user = UserManager.FindById(User.Identity.GetUserId());
            var systems = service.GetAllByUser(user.Id);
            var systemsList = systems.ToList();

            var jsonData = from item in systemsList
                           select new
                           {
                               item.SystemId,
                               item.FullName,
                               item.ShortName
                           };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region CRUD
        #region GetAll
        public ActionResult UserSystems()
        {
            return View();
        }
        #endregion

        #region AddEdit
        [HttpGet]
        public ActionResult AddEdit(int systemId = 0)
        {
            Model.UDB.System system = service.GetById("SystemId", systemId.ToString());
            return PartialView("AddEditSystem", system);
        }

        [HttpPost]
        public ActionResult AddEdit(Model.UDB.System model)
        {
            return Content(string.Empty);
        }
        #endregion
        #endregion
    }
}