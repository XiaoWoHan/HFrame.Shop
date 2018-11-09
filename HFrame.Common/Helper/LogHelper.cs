using HFrame.Common.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace HFrame.Common.Helper
{
    public class LogHelper
    {
        /// <summary>
        /// 默认日志Key
        /// </summary>
        private const string LOG = "HFrame.Redis.Log";
        /// <summary>
        /// 默认错误Key
        /// </summary>
        private const string ERROR = "HFrame.Redis.Log.Error";
        /// <summary>
        /// 当天默认错误Key
        /// </summary>
        private static string TODYERROR => $"{ERROR}.{DateTime.Now.ToString("yyyy-MM-dd")}";
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="Comment"></param>
        /// <returns></returns>
        public static bool Log(string Comment)
        {
            var Logs = RedisHelper.Current.Get<List<string>>(LOG)??new List<string>();
            Logs.Add(Comment);
            return RedisHelper.Current.AddOrUpdate(LOG, Logs);
        }
        /// <summary>
        /// 写错误
        /// </summary>
        /// <param name="ErrorComment"></param>
        /// <returns></returns>
        public static bool LogError(string ErrorComment)
        {
            var Errors = RedisHelper.Current.Get<List<string>>(TODYERROR) ??new List<string>();
            Errors.Add(ErrorComment);
            return RedisHelper.Current.AddOrUpdate(TODYERROR, Errors);
        }
        /// <summary>
        /// 获取当天错误日志
        /// </summary>
        /// <returns></returns>
        public static List<String> GetTodyErrors()
        {
            return RedisHelper.Current.Get<List<string>>(TODYERROR);
        }
        /// <summary>
        /// 获取所有错误日志
        /// </summary>
        /// <returns></returns>
        public static List<String> GetErrors()
        {
            return RedisHelper.Current.Get<List<string>>(ERROR+".*");
        }//TODO 未完成获取所有错误日志
    }
}
