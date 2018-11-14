using HFrame.Common.Cache;
using HFrame.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HFrame.CommonBS.Cache
{
    /// <summary>
    /// Cookie帮助类
    /// </summary>
    public class CookieHelper : CacheModel<CookieHelper>
    {
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="SaveMinutes"></param>
        /// <returns></returns>
        public bool Add(string key, object data, int SaveMinutes = 20)
        {
            HttpCookie Hc = new HttpCookie(key);
            if (data == null) return false;
            var DataJson = data.ToJson();
            Hc.Expires = DateTime.Now.AddMinutes(SaveMinutes);
            Hc.Value = DataJson;
            HttpContext.Current.Response.Cookies.Add(Hc);
            return Exists(key);
        }
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public override bool Add(string key, object data)
        {
            return Add(key,data,20);
        }

        public override bool Exists(string key)
        {
            return HttpContext.Current.Request.Cookies[key] != null;
        }

        public override object Get(string key)
        {
            if (String.IsNullOrEmpty(key)) return null;
            if (!Exists(key)) return null;
            return HttpContext.Current.Request.Cookies[key].Value.ParseJson<object>();
        }

        public override bool Remove(string key)
        {
            if (String.IsNullOrEmpty(key)) return false;
            HttpCookie Hc = HttpContext.Current.Request.Cookies[key];
            if (Hc == null) return false;
            var EndTimeSpan = -(Hc.Expires - DateTime.Now);//反剩余结束时间
            Hc.Expires = DateTime.Now.Add(EndTimeSpan);
            HttpContext.Current.Response.AppendCookie(Hc);
            return !Exists(key);
        }
    }
}
