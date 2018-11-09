using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HFrame.Common.Helper
{
    /*
     * XML帮助类
     */
    public class XMLHelper
    {
        #region 反序列化
        public static T ParseXML<T>(string XMLStr) where T : class, new()
        {
            T myObject;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(XMLStr);
            myObject = (T)serializer.Deserialize(reader);
            reader.Close();
            return myObject;
        }
        #endregion

        #region 序列化
        public static string ToXML<T>(T Model) where T : class, new()
        {
            if (Model != null)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));

                MemoryStream stream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
                writer.Formatting = Formatting.None;//缩进
                xs.Serialize(writer, Model);

                stream.Position = 0;
                StringBuilder sb = new StringBuilder();
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        sb.Append(line);
                    }
                    reader.Close();
                }
                writer.Close();
                return sb.ToString();
            }
            return string.Empty;
        }

        #endregion
    }
}
