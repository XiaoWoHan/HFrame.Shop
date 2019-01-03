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
        private const string CookieKey = "_HFrame_Cookie_Key_2018_12_18_";
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="SaveMinutes"></param>
        /// <returns></returns>
        public bool Add(string key, object data, int SaveMinutes = 20)
        {
            var Encryptionkey = EncryptionHelper.MD5Encrypt(key,Encoding.ASCII);
            HttpCookie Hc = new HttpCookie(Encryptionkey);
            if (data == null) return false;
            Hc.Expires = DateTime.Now.AddMinutes(SaveMinutes);
            var DataJson = data.ToJson();
            var EncryptionData = EncryptionHelper.DESEncrypt(DataJson, CookieKey);
            Hc.Value = EncryptionData;
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
        public override T1 Get<T1>(string key)
        {
            var Encryptionkey = EncryptionHelper.MD5Encrypt(key, Encoding.ASCII);
            if (String.IsNullOrEmpty(Encryptionkey)) return null;
            if (!Exists(Encryptionkey)) return null;
            var EncryptionData = HttpContext.Current.Request.Cookies[Encryptionkey].Value;
            var Data = EncryptionHelper.DESDecrypt(EncryptionData, CookieKey);
            return Data.ParseJson<T1>();
        }
        public override bool Remove(string key)
        {
            var Encryptionkey = EncryptionHelper.MD5Encrypt(key, Encoding.ASCII);
            if (String.IsNullOrEmpty(Encryptionkey)) return false;
            HttpCookie Hc = HttpContext.Current.Request.Cookies[Encryptionkey];
            if (Hc == null) return false;
            Hc.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.AppendCookie(Hc);
            return !Exists(Encryptionkey);
        }
    }
}
