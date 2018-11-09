using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HFrame.Common.Helper
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 获得字符串的长度,一个汉字的长度为2
        /// </summary>
        public static int StringByteLength(this string s) => String.IsNullOrEmpty(s) ? 0 : Encoding.Default.GetBytes(s).Length;
        /// <summary>
        /// Guid随机字符串
        /// </summary>
        public static string GuidStr => Guid.NewGuid().ToString();
        /// <summary>
        /// 当前时间字符
        /// </summary>
        public static string TimeStr => DateTime.Now.ToString("yyyyMMddHHmmssffff");

        #region 方法

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="splitStr">分隔字符串</param>
        /// <returns></returns>
        public static string[] SplitString(this string sourceStr, string splitStr)
        {
            if (string.IsNullOrEmpty(sourceStr) || string.IsNullOrEmpty(splitStr))
                return new string[0] { };

            if (sourceStr.IndexOf(splitStr) == -1)
                return new string[] { sourceStr };

            if (splitStr.Length == 1)
                return sourceStr.Split(splitStr[0]);
            else
                return Regex.Split(sourceStr, Regex.Escape(splitStr), RegexOptions.IgnoreCase);

        }

        /// <summary>
        /// 包含在内
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="inValues"></param>
        /// <returns></returns>
        public static bool IsContainsIn(this string thisValue, params string[] inValues)
        {
            return inValues.Any(it => thisValue.Contains(it));
        }
        #endregion
    }
}
