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

        public ActionResult UserSystems()
        {
            User user = UserManager.FindById(User.Identity.GetUserId());
            var systems = service.GetAllByUser(user.Id);
            return View();
        }

        #region CRUD
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