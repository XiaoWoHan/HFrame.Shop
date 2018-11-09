using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace HFrame.Common.Helper
{
    /// <summary>
    /// Json帮助类
    /// </summary>
    public static class JsonHelper
    {
        #region 序列化
        /// <summary>
        /// 模型转换为Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T Model) where T : class, new()
        {
            if (Model == null)
            {
                return String.Empty;
            }
            return JsonConvert.SerializeObject(Model);
        }
        #endregion

        #region 反序列化
        /// <summary>
        /// 解析Json为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JsonStr"></param>
        /// <returns></returns>
        public static T ParseJson<T>(this string JsonStr) where T : class, new()
        {
            if (String.IsNullOrEmpty(JsonStr))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(JsonStr);
        }
        /// <summary>
        /// 解析Json为对象
        /// </summary>
        /// <param name="JsonStr"></param>
        /// <returns></returns>
        public static object ParsJson(this string JsonStr)
        {
            if (String.IsNullOrEmpty(JsonStr))
            {
                return null;
            }
            return JsonConvert.DeserializeObject(JsonStr);
        }
        #endregion

        #region 文件解析Json
        /// <summary>
        /// 从文件解析Json
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static JObject ReadParseJson(string Path)
        {
            if (String.IsNullOrEmpty(Path))
            {
                return null;
            }
            using (StreamReader reader = File.OpenText(Path))
            {
                return (JObject)JToken.ReadFrom(new JsonTextReader(reader));
            }
        }
        /// <summary>
        /// 从文件解析Json
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static T ReadParseJson<T>(string Path)where T:class,new()
        {
            if (String.IsNullOrEmpty(Path))
            {
                return default(T);
            }
            using (StreamReader reader = File.OpenText(Path))
            {
                return JToken.ReadFrom(new JsonTextReader(reader)).ToObject<T>();
            }
        }
        #endregion

        #region Json转换为XML
        public static XmlDocument JsonToXML(string JsonStr)
        {
            if (String.IsNullOrEmpty(JsonStr))
            {
                return null;
            }
            return JsonConvert.DeserializeXmlNode(JsonStr);
        }
        #endregion
    }
}
