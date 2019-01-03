using HFrame.Common.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HFrame.CommonBS.Cache
{
    public class SysCacheHelper : CacheModel<SysCacheHelper>
    {
        private readonly System.Web.Caching.Cache _CACHE = HttpRuntime.Cache;
        public override bool Add(string key, object data)
        {
            return Add(key,data,20);
        }
        public bool Add(string key, object data,int SaveMinutes)
        {
            if(Exists(key)) Remove(key);
            var EndTime=DateTime.Now.AddMinutes(SaveMinutes);
            _CACHE.Insert(key, data, null, EndTime, System.Web.Caching.Cache.NoSlidingExpiration);
            return Exists(key);
        }
        public override bool Exists(string key)
        {
            return _CACHE[key] != null;
        }
        public override T1 Get<T1>(string key)
        {
            return (T1)_CACHE[key];
        }

        public override bool Remove(string key)
        {
            _CACHE.Remove(key);
            return !Exists(key);
        }
    }
}
