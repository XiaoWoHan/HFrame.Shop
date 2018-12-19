using HFrame.CommonBS.Controllers;
using HFrame.Web.Areas.Manage.Models;
using HFrame.Web.Areas.Manage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFrame.Web.Areas.Manage.Controllers
{
    public class MenuController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
            => View(MenuService.GetPageMenus());
        [HttpGet]
        public ActionResult Edit(string OID = null)
            => View(MenuService.GetMenu(OID));
        [HttpPost]
        public ActionResult Save(UIMenu Model)
        {
            var result = this.result;
            var Status = MenuService.SaveMenu(result, Model);
            result.CallbackPage = Status ? Url.Action("Index") : String.Empty;
            return Json(result);
        }
    }
}