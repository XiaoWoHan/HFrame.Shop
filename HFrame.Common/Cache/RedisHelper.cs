using HFrame.Common.Helper;
using StackExchange.Redis;
using System;

namespace HFrame.Common.Cache
{
    /// <summary>
    /// 基于Redis读写缓存
    /// </summary>
    public class RedisHelper : CacheModel<RedisHelper>
    {
        #region 属性
        /// <summary>
        /// 连接对象
        /// </summary>
        public IConnectionMultiplexer Connect { get; set; }
        /// <summary>
        /// 链接数据
        /// </summary>
        public IDatabase DataBase { get; set; }
        #endregion

        #region 构造函数
        public RedisHelper()
        {
            Connect = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            DataBase = Connect.GetDatabase();
        }
        public RedisHelper(string Path) : base(Path)
        {
            Connect = ConnectionMultiplexer.Connect(Path);
            DataBase = Connect.GetDatabase();
        }
        #endregion

        #region 方法
        #region 获取
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override object Get(string key)
        {
            return Get<object>(key);
        }
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public override T Get<T>(string key)
        {
            var value = default(T);///默认返回值
            var cacheValue = DataBase.StringGet(key);
            if (!cacheValue.IsNull && cacheValue.HasValue)
            {
                value = JsonHelper.ParseJson<T>(cacheValue.ToString());
            }
            return value;
        }
        #endregion

        #region 添加
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public override bool Add(string key, object data)
        {
            lock (_lockeder)
            {
                var JsonData = JsonHelper.ToJson(data);
                return DataBase.StringSet(key, JsonData);
            }
        }
        public bool Add(string key, object data, int MaxTime)
        {
            lock (_lockeder)
            {
                var timeSpan = TimeSpan.FromSeconds(MaxTime);
                var jsonData = JsonHelper.ToJson(data);
                return DataBase.StringSet(key, jsonData, timeSpan);
            }
        }
        public bool Add(string key, object data, DateTime EndTime)
        {
            lock (_lockeder)
            {
                var timeSpan = EndTime - DateTime.Now;
                var jsonData = JsonHelper.ToJson(data);
                return DataBase.StringSet(key, jsonData, timeSpan);
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="key"></param>
        public override bool Remove(string key)
        {
            lock (_lockeder)
            {
                if (String.IsNullOrEmpty(key) || !Exists(key)) return false;
                return DataBase.KeyDelete(key);
            }
        }
        #endregion

        #region 判断
        /// <summary>
        /// 判断key是否存在
        /// </summary>
        public override bool Exists(string key)
        {
            return DataBase.KeyExists(key);
        }
        #endregion

        #region 添加或更新
        public override bool AddOrUpdate(string key, object data)
        {
            lock (_lockeder)
            {
                if (String.IsNullOrEmpty(key)) return false;
                if (Exists(key))
                {
                    return Add(key, data);
                }
                else
                {
                    Remove(key);
                    Add(key,data);
                    return Exists(key);
                }
                    
            }
        }
        #endregion
        #endregion
    }
}
