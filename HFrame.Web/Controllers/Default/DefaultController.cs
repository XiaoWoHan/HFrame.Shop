using HFrame.Common.Model;
using HFrame.CommonBS.Helper;
using HFrame.CommonBS.Model;
using System.Web.Mvc;

namespace HFrame.Web.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public ActionResult Login() => View();
        public ActionResult Login(LoginModel Model)
        {
            var result = new ResultModel();
            var Status = LoginHelper.Login(result, Model);
            return Json(result);
        }
        [HttpGet]
        public ActionResult Register() => View();
        [HttpPost]
        public ActionResult Register(RegisterModel Model)
        {
            var result = new ResultModel();
            var Status = RegisterHelper.Register(result, Model);
            return Json(result);
        }
    }
}