using HFrame.CommonBS.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFrame.Web.Controllers.Main
{
    public class MainController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Main() => View();
    }
}