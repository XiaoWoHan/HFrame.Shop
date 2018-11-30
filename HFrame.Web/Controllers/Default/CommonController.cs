using HFrame.Common.Helper;
using HFrame.CommonBS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFrame.Web.Controllers
{
    public class CommonController : Controller
    {
        #region 公共方法
        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ValidateCodeImg()
        {
            var Code = ValidateCodeHelper.GetRandomCode(7);
            ValidateCodeHelper.SetCodeString(Code);
            return File(ValidateCodeHelper.GetVerifyCodeImg(Code), "image/Jpeg");
        }
        #endregion
    }
}