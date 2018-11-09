using HFrame.Common.Cache;
using HFrame.Common.Helper;
using HFrame.Common.Model;
using HFrame.CommonBS;
using HFrame.CommonBS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFrame.CommonBS.Controllers
{
    [CheckLogin]
    public class BaseController : Controller
    {
        public static MemberModel result => LoginHelper.CurrentMember();
    }//TODO 缺少验证
}