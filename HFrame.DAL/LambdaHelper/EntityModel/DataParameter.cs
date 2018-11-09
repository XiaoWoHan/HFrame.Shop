using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LambdaToSql.EntityModel
{
    /// <summary>
    /// 参数化查询 最后转换成 对应的参数化参数
    /// </summary>
    public class DataParameter
    {
        /// <summary>
        /// 获取或设置参数的 System.Data.DbType。
        /// </summary>
        public DbType DbType { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示参数是否接受 null 值。
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 获取或设置 System.Data.Common.DbParameter 的名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置列中数据的最大大小（以字节为单位）。
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 获取或设置该参数的值
        /// </summary>
        public object Value { get; set; }

        public DataParameter(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
