using HFrame.Common.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HFrame.CommonBS.Cache
{
    public class SessionHelper : CacheModel<SessionHelper>
    {
        public override bool Add(string key, object data)
        {
            HttpContext.Current.Session.Add(key, data);
            return Exists(key);
        }

        public override bool Exists(string key)
        {
            return HttpContext.Current.Session[key]!=null;
        }

        public override object Get(string key)
        {
            if (String.IsNullOrEmpty(key)) return null;
            return HttpContext.Current.Session[key];
        }

        public override bool Remove(string key)
        {
            if (String.IsNullOrEmpty(key)) return false;
            if (Exists(key))
                HttpContext.Current.Session.Remove(key);
            return !Exists(key);
        }
        /// <summary>
        /// 移除所有Session
        /// </summary>
        public static void RemoveAllSession()
        {
            HttpContext.Current.Session.RemoveAll();
        }
        /// <summary>
        /// 设置Session超时时间
        /// </summary>
        /// <param name="timeout">超时时间（单位：分）</param>
        public static void SetTimeout(int timeout)
        {
            HttpContext.Current.Session.Timeout = timeout;
        }
        /// <summary>
        /// 获取session超时时间
        /// </summary>
        /// <returns></returns>
        public static int GetTimeout()
        {
            return HttpContext.Current.Session.Timeout;
        }
    }
}
