using System.Web;
using System.Web.Mvc;

namespace HFrame.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
            filters.Add(new CommonBS.Filter.FormValidationAttribute());

            filters.Add(new CommonBS.Filter.ErrorAttribute());
        }
    }
}
