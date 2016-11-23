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
            systemsList.Add(new Model.UDB.System() { FullName = "1", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 1 });
            systemsList.Add(new Model.UDB.System() { FullName = "2", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 2 });
            systemsList.Add(new Model.UDB.System() { FullName = "3", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 4 });
            systemsList.Add(new Model.UDB.System() { FullName = "4", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 5 });
            systemsList.Add(new Model.UDB.System() { FullName = "5", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 16 });
            systemsList.Add(new Model.UDB.System() { FullName = "6", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 17 });
            systemsList.Add(new Model.UDB.System() { FullName = "7", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 18 });
            systemsList.Add(new Model.UDB.System() { FullName = "8", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 19 });
            systemsList.Add(new Model.UDB.System() { FullName = "9", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 10 });
            systemsList.Add(new Model.UDB.System() { FullName = "0", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 122 });
            systemsList.Add(new Model.UDB.System() { FullName = "й", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 133 });
            systemsList.Add(new Model.UDB.System() { FullName = "d", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 144 });
            systemsList.Add(new Model.UDB.System() { FullName = "у", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 155 });
            systemsList.Add(new Model.UDB.System() { FullName = "к", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 166 });
            systemsList.Add(new Model.UDB.System() { FullName = "е", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 188 });
            systemsList.Add(new Model.UDB.System() { FullName = "н", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 177 });
            systemsList.Add(new Model.UDB.System() { FullName = "г", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 199 });
            systemsList.Add(new Model.UDB.System() { FullName = "ш", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 112 });
            systemsList.Add(new Model.UDB.System() { FullName = "щ", LanguageId = 1, ShortName = "s", UID = 1, SystemId = 135 });


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
        public ActionResult AddEdit()
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult AddEdit(Model.UDB.System model)
        {
            return Content(string.Empty);
        }
        #endregion
        #endregion
        
        // GET: System
        public ActionResult Index()
        {
            return View();
        }
    }
}