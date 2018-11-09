#region -- 版 本 注 释 --
/****************************************************
* 文 件 名：
* Copyright(c) 王树羽
* CLR 版本: 4.5
* 创 建 人：王树羽
* 电子邮箱：674613047@qq.com
* 官方网站：https://www.cnblogs.com/shuyu
* 创建日期：2018-06-25 
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;

namespace CommonLib
{
    /// <summary>
    /// Http Get Post Put Delete 请求帮助类
    /// </summary>
    public class HttpHelper
    {
        #region Get Post Put Delete 请求

        /// <summary>
        /// 返回指定Url的页面源码,Get提交
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <param name="encoding">编码格式 gb2312 utf-8,默认 utf-8</param>
        /// <returns></returns>
        public static string HttpGet(string url, string encoding = "utf-8")
        {
            return HttpRequest(url, "", "get", encoding);
        }

        /// <summary>
        /// Post提交
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="body">内容</param>
        /// <param name="encoding">编码 默认 utf-8</param>
        /// <returns></returns>
        public static string HttpPost(string url, string body, string encoding = "utf-8")
        {
            return HttpRequest(url, body, "post", encoding);
        }

        /// <summary>
        /// Delete提交
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="body">内容</param>
        /// <param name="encoding">编码 默认 utf-8</param>
        /// <returns></returns>
        public static string HttpDelete(string url, string body, string encoding = "utf-8")
        {
            return HttpRequest(url, body, "delete", encoding);
        }

        /// <summary>
        /// Delete提交
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="body">内容</param>
        /// <param name="encoding">编码 默认 utf-8</param>
        /// <returns></returns>
        public static string HttpPut(string url, string body, string encoding = "utf-8")
        {
            return HttpRequest(url, body, "put", encoding);
        }

        /// <summary>
        /// 模拟Http请求
        /// </summary>
        /// <param name="httpUrl">请求地址 http://www.baidu.com/</param>
        /// <param name="body">参数:id=123@name=admin </param>
        /// <param name="method">请求形式 post get delete put</param>
        /// <param name="encoding">请求的页面编码 uft-8,gb2312,GBK</param>
        /// <returns></returns>
        public static string HttpRequest(string httpUrl, string body, string method, string encoding = "utf-8")
        {
            //创建httpWebRequest对象
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpUrl);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(httpUrl);

            //request.Accept = "text/html, application/xhtml+xml, */*";
            //request.ContentType = "application/json";
            request.Method = method.ToUpper();

            //填充要 post/get 的内容
            if (!string.IsNullOrEmpty(body))
            {
                byte[] data = Encoding.GetEncoding(encoding).GetBytes(body);
                request.ContentLength = data.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
            }

            //发送 post/get 请求到服务器并读取服务器返回信息 
            var result = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var stream = response.GetResponseStream();
                StreamReader str = null;
                if (response.ContentEncoding.ToLower().Contains("gzip"))//有Gzip压缩
                {
                    stream = new GZipStream(stream, CompressionMode.Decompress);
                }
                str = new StreamReader(stream, Encoding.GetEncoding(response.CharacterSet));
                result = str.ReadToEnd();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            } 
            return result;
        }
        #endregion
    }
}
