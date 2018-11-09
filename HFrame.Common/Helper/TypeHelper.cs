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
    class TypeHelper
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
        public static DateTime StringToDateTime(string s)
        {

            return StringToDateTime(s, DateTime.Now);
        }
        #endregion
    }
}
