using HFrame.Common.Helper;
using HFrame.Common.Model;
using HFrame.CommonBS.Helper;
using System;
using System.Web.Mvc;
/// <summary>
/// 登陆验证过滤器
/// </summary>
namespace HFrame.CommonBS.Filter
{
    /// <summary>
    /// 登陆验证帮助
    /// </summary>
    public class CheckLoginAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!LoginHelper.IsLogin)
            {
                if (HttpHelper.IsPost)
                {
                    var Result = new ResultModel { ErrorMsg = "请登录后操作", ErrorCode = -2 };//重定向页面
                    filterContext.Result = new JsonResult { Data = Result };
                }
                else
                {
                    filterContext.HttpContext.Response.Redirect("/Login");///跳转回登陆页面
                }
            }
        }
    }//TODO 缺少加解密
}
