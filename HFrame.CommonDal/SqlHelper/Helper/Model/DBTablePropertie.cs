using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal
{
    /// <summary>
    /// 当前类属性
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBTablePropertie<T> where T : class
    {
        #region 属性
        /// <summary>
        /// 实体类所有公共属性
        /// </summary>
        private PropertyInfo[] PropInfo => typeof(T).GetProperties();
        /// <summary>
        /// 实体类名称（表名称）
        /// </summary>
        protected internal string TableName => typeof(T).Name;
        /// <summary>
        /// 字段名集合
        /// </summary>
        protected internal List<string> ColumnsList => PropInfo.Select(m => m.Name).ToList();
        /// <summary>
        /// 实体类所有属性
        /// </summary>
        protected internal Dictionary<string,object> Attributes
        {
            get
            {
                var _Attributes = new Dictionary<string, object>();
                foreach(var item in ColumnsList)
                {
                    var ItemValue = GetPropertyValue(item);
                    var itemDBValue = FormatValue(ItemValue);
                    _Attributes.Add(item, itemDBValue);
                }
                return _Attributes;
            }
        }
        /// <summary>
        /// 主键
        /// </summary>
        protected internal string Key
        {
            get
            {
                return PropInfo.Where(m => m.GetCustomAttributes(false).Any(x => x is KeyAttribute)).FirstOrDefault()?.Name;
            }
        }
        #endregion

        #region 内部方法
        /// <summary>
        /// 根据属性名称获取属性值
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        private object GetPropertyValue(string propertyName)
        {
            try
            {
                var refVal= default(object);
                var itemType = this.GetType();
                var itemPrpoerty = itemType.GetProperty(propertyName);
                if (itemPrpoerty != null)
                {
                    refVal = itemPrpoerty.GetValue(this);
                }
                return refVal;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取当前字段插入语句格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private object FormatValue(object value)
        {
            if (value == null)
            {
                return "NULL";
            }
            else
            {
                if (value is DateTime)
                {
                    var date = Convert.ToDateTime(value);
                    if (date < Convert.ToDateTime("1900-1-1"))
                    {
                        date = Convert.ToDateTime("1900-1-1");
                    }
                    return "('" + date.ToString("yyyy-MM-dd HH:mm:ss") + "') ";
                }
                else if (value is Enum)
                {
                    return Convert.ToInt64(value);
                }
                else if (value is byte[])
                {
                    string bytesString = "0x" + BitConverter.ToString((byte[])value).Replace("-", "");
                    return bytesString;
                }
                else if (value is Boolean)
                {
                    return Convert.ToBoolean(value) ? "1" : "0";
                }
                else if (value is String || value is object)
                {
                    return "N'" + ToSqlFilter(value.ToString()) + "'";
                }
                else
                {
                    return value;
                }
            }
        }
        /// <summary>
        /// 转义字符，以防报错
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string ToSqlFilter(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                value = value.Replace("'", "''");
            }
            return value;
        }
        #endregion
    }
}
