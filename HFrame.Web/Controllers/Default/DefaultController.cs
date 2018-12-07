using HFrame.Common.Model;
using HFrame.CommonBS.Helper;
using HFrame.CommonBS.Model;
using System.Web.Mvc;

namespace HFrame.Web.Controllers
{
    public class DefaultController : Controller
    {
        #region 登陆
        [HttpGet]
        public ActionResult Login() => View();
        /// <summary>
        /// 提交登陆
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginModel Model)
        {
            var result = new ResultModel();
            var Status = LoginHelper.Login(result, Model);
            return Json(result);
        }
        #endregion

        #region 退出
        [HttpPost]
        public ActionResult Logout()
        {
            var result = new ResultModel();
            var Status = LoginHelper.Logout(result);
            return Json(result);
        }
        #endregion

        #region 注册
        [HttpGet]
        public ActionResult Register() => View();
        /// <summary>
        /// 提交注册
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(RegisterModel Model)
        {
            var result = new ResultModel();
            var Status = RegisterHelper.Register(result, Model);
            if (Status)
            {
                result.CallbackPage = Url.Action("Login");
            }
            return Json(result);
        }
        #endregion
    }
}