using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.Common.Cache
{
    /// <summary>
    /// 基于HashTable读写缓存
    /// </summary>
    public class CacheHelper : CacheModel<CacheHelper>
    {
        #region 属性
        /// <summary>
        /// 存储空间
        /// </summary>
        private static Hashtable _cachemodel = new Hashtable();
        #endregion

        #region 方法
        public override bool Exists(string key)
        {
            return _cachemodel.ContainsKey(key);
        }

        public override object Get(string key)
        {
            return Get<object>(key);
        }

        public override T Get<T>(string key)
        {
            if (_cachemodel != null && Exists(key))
                return _cachemodel[key] as T;
            return default(T);
        }

        public override bool Add(string key, object data)
        {
            if (String.IsNullOrEmpty(key) || Exists(key)) return false;
            _cachemodel.Add(key, data);
            return Exists(key);
        }

        public override bool Remove(string key)
        {
            if (String.IsNullOrEmpty(key)|| !Exists(key)) return false;
            _cachemodel.Remove(key);
            return !Exists(key);
        }
        public override bool AddOrUpdate(string key, object data)
        {
            if (String.IsNullOrEmpty(key)) return false;
            if (!Exists(key))
                _cachemodel.Add(key,data);
            else
                _cachemodel[key] = data;
            return Exists(key);
        }
        #endregion
    }
}
