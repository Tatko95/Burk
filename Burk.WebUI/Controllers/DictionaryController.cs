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
    public class DictionaryController : BaseController
    {
        #region Fields
        private IDictionaryService dictionaryService;
        #endregion

        #region ctor
        public DictionaryController(IDictionaryService _dicService, ApplicationUserManager userManager) : base(userManager)
        {
            dictionaryService = _dicService;
            ViewBag.IsShowSystemName = true;
            ViewBag.IsShowMenu = true;
        }
        #endregion
        
        public ActionResult Index()
        {
            return View();
        }

        #region GRIDs
        public ActionResult GetListDictionaries(int systemId)
        {
            var dictionaries = dictionaryService.GetDictionaries(systemId);

            var jsonData = from item in dictionaries
                           select new
                           {
                               item.DictionaryId,
                               item.FullName,
                               item.ShortName
                           };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetListValues(int dictionaryId)
        {
            var values = dictionaryService.GetDictionaryValues(dictionaryId);

            var jsonData = from item in values
                           select new
                           {
                               item.DicValueId,
                               item.FullName,
                               item.ShortName
                           };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region CRUD Dictionary
        #region AddEdit
        [HttpGet]
        public ActionResult AddEditDictionary(int dictionaryId)
        {
            var model = dictionaryService.GetById("DictionaryId", dictionaryId.ToString());
            if (string.IsNullOrEmpty(model.FullName))
            {
                model.SystemId = (int)Session["SystemId"];
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddEditDictionary(Dictionary model)
        {
            try
            {
                if (model.DictionaryId == default(int))
                {
                    dictionaryService.Insert(model);
                    return Content("SuccessCreate");
                }
                else
                {
                    dictionaryService.Update(model);
                    return Content("SuccessEdit");
                }
            }
            catch (Exception ex)
            {
                return Content("Error");
                throw new Exception("Error in controller", ex);
            }
        }
        #endregion

        #region Delete
        public ActionResult DeleteDictionary(int dictionaryId)
        {
            try
            {
                var model = dictionaryService.GetById("DictionaryId", dictionaryId.ToString());
                dictionaryService.Delete(model);
            }
            catch (Exception)
            {
                return Content("Error");
            }
            return Content("Success");
        }
        #endregion
        #endregion

        #region CRUD Value
        #region AddEdit
        [HttpGet]
        public ActionResult AddEditValue(int valueId, int dictionaryId)
        {
            var model = dictionaryService.GetValueById(valueId);
            if (string.IsNullOrEmpty(model.FullName))
            {
                model.DictionaryId = dictionaryId;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddEditValue(DictionaryValue model)
        {
            try
            {
                if (model.DicValueId == default(int))
                {
                    dictionaryService.InsertValue(model);
                    return Content("SuccessCreate");
                }
                else
                {
                    dictionaryService.UpdateValue(model);
                    return Content("SuccessEdit");
                }
            }
            catch (Exception ex)
            {
                return Content("Error");
                throw new Exception("Error in controller", ex);
            }
        }
        #endregion

        #region Delete
        public ActionResult DeleteValue(int valueId)
        {
            try
            {
                var model = dictionaryService.GetValueById(valueId);
                dictionaryService.DeleteValue(model);
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