using HFrame.Web.Areas.Goods.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFrame.Web.Areas.Goods.Controllers
{
    public class GoodsTypeController : Controller
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
            return View();
        }
    }
}