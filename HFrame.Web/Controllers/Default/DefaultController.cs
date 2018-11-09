using HFrame.Common.Cache;
using HFrame.Common.Helper;
using HFrame.Common.Model;
using HFrame.Web.Default.Model;
using HFrame.Web.Default.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFrame.Web.Controllers
{
    public class DefaultController : Controller
    {
        #region 公共方法
        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCodeImg()
        {
            var Code = ValidateCodeHelper.GetRandomCode(7);
            ValidateCodeHelper.SetCodeString(Code);
            return File(ValidateCodeHelper.GetVerifyCodeImg(Code), "image/Jpeg");
        }
        #endregion

        [HttpGet]
        public ActionResult Login() => View();
        public ActionResult Login(LoginModel Model)
        {
            var result = new ResultModel();
            var Status = DefaultService.Login(result, Model);
            return Json(result);
        }
        [HttpGet]
        public ActionResult Register() => View();
        [HttpPost]
        public ActionResult Register(RegisterModel Model)
        {
            var result = new ResultModel();
            var Status = DefaultService.Register(result, Model);
            return Json(result);
        }
    }
}