using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HFrame.Common.Helper
{
    /// <summary>
    /// Cookie帮助类
    /// </summary>
    public class CookieHelper
    {
        #region Cookies 操作
        /// <summary>
        /// 添加Cookies
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="value">Cookie值</param>
        /// <param name="Domain">Cookie作用域</param>
        public static void AddCookies(string name, string value, string Domain = "")
        {
            HttpCookie Hc = new HttpCookie(name);
            if (!string.IsNullOrEmpty(Domain))
            {
                Hc.Domain = Domain;
            }
            Hc.Expires = DateTime.Now.AddMinutes(20);
            Hc.Value = value;
            HttpContext.Current.Response.Cookies.Add(Hc);
        }

        /// <summary>
        /// 读取 Cookie
        /// </summary>
        /// <param name="name">Cookie值</param>
        public static string GetCookies(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                return HttpContext.Current.Request.Cookies[name].Value;
            }
            return "";
        }

        /// <summary>
        /// 移除 Cookie
        /// </summary>
        /// <param name="name">Cookie值</param>
        public static void RemoveCookies(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpCookie Hc = HttpContext.Current.Request.Cookies[name];
                Hc.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.AppendCookie(Hc); //这句一定要加上，否则无法删除
            }
        }
        #endregion
    }
}
