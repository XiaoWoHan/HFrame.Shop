using System;
using System.Collections.Generic;
using System.Text;
/* *
 * 类型帮助类
 * */
namespace HFrame.Common.Helper
{
    /// <summary>
    /// 类型帮助类
    /// </summary>
    public static class TypeHelper
    {
        #region 转换时间型
        /// <summary>
        /// 将string类型转换成datetime类型
        /// </summary>
        /// <param name="s">目标字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime StringToDateTime(string s, DateTime defaultValue)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                DateTime result;
                if (DateTime.TryParse(s, out result))
                    return result;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将string类型转换成datetime类型
        /// </summary>
        /// <param name="s">目标字符串</param>
        /// <returns></returns>
        public static DateTime StringToDateTime(string s)=> StringToDateTime(s, DateTime.Now);
        #endregion

        #region 泛型帮助
        /// <summary>
        /// 转换类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="TModel"></param>
        /// <returns></returns>
        public static TResult Conversion<T, TResult>(this T TModel)
            where T : class
            where TResult : class, new()
        {
            if (TModel == null) return null;
            var result = new TResult();
            var Propetys = typeof(T).GetProperties();
            foreach (var item in Propetys)
            {
                typeof(T).GetProperty(item.Name).SetValue(result, item.GetValue(TModel));
            }
            return result;
        }

        #endregion
    }
}
