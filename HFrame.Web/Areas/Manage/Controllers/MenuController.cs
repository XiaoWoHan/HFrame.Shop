using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFrame.Web.Areas.Manage.Controllers
{
    public class MenuController : Controller
    {
        [HttpGet]
        public ActionResult Index() => View();
    }
}