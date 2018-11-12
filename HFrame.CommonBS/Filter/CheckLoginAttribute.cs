using HFrame.CommonBS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (LoginHelper.CurrentMember() == null)
            {
                filterContext.HttpContext.Response.Redirect("/Default/Login");///跳转回登陆页面
            }
        }
    }//TODO 缺少加解密
}
