using System.Web;
using System.Web.Mvc;

namespace HFrame.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //添加表单验证过滤器
            filters.Add(new CommonBS.Filter.FormValidationAttribute());
            //添加错误记录过滤器
            filters.Add(new CommonBS.Filter.ErrorAttribute());
        }
    }
}
