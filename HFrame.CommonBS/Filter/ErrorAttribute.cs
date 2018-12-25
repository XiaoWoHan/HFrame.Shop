using HFrame.Common.Helper;
using HFrame.Common.Model;
using HFrame.CommonBS.Helper;
using System;
using System.Web.Mvc;

namespace HFrame.CommonBS.Filter
{
    public class ErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            #region 记录错误日志
            string controllerName = (string)filterContext.RouteData.Values["controller"];
            string actionName = (string)filterContext.RouteData.Values["action"];
            string exception = filterContext.Exception.ToString();
            var ErrorMsg = String.Format("{0}/{1}在{2}抛出异常{3}", controllerName, actionName, DateTime.Now, exception);
            LogHelper.LogError(ErrorMsg);
            #endregion
#if !Debug
            if (HttpHelper.IsPost)
            {
                var Result = new ResultModel { ErrorMsg = "系统错误，请联系管理员", ErrorCode = -1 };//重定向页面
                filterContext.Result = new JsonResult { Data = Result };
                filterContext.ExceptionHandled = true;
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("~/Content/Html/Error.html");//TODO 更改为配置项内容
            }
#endif
        }
    }
}
