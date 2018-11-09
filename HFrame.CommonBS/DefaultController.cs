using HFrame.Common.Cache;
using HFrame.Common.Helper;
using HFrame.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFrame.Web.Controllers
{
    public class BaseController : Controller
    {
        public static MemberModel result=> CookieHelper.GetCookies("CurrentMumber").ParseJson<MemberModel>();
        public BaseController()
        {
            if (result == null)
            {
                //TODO 拦截进入页面
            }
        }
    }
}