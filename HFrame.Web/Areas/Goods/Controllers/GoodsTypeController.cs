using HFrame.CommonBS.Controllers;
using HFrame.Web.Areas.Goods.Models;
using HFrame.Web.Areas.Goods.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFrame.Web.Areas.Goods.Controllers
{
    public class GoodsTypeController : BaseController
    {
        [HttpGet]
        public ActionResult List()
        {
            var Types = GoodsTypeService.GetPageGoodsType();
            return View(Types);
        }
        [HttpGet]
        public ActionResult Edit(string OID=null)
        {
            var Model = GoodsTypeService.GetPageGoodsType(OID);
            return View(Model);
        }
        [HttpPost]
        public ActionResult Save(UIGoodsType Model)
        {
            var result = this.result;
            var Status = GoodsTypeService.SaveGoodsType(result,Model);
            result.CallbackPage=Status?Url.Action("List"):String.Empty;
            return Json(result);
        }
        [HttpPost]
        public ActionResult Delete(string OID)
        {
            var result = this.result;
            var Status = GoodsTypeService.DeleteGoodsType(result,OID);
            return Json(result);
        }
    }
}