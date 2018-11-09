using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LambdaToSql.LambdaParser
{
    /// <summary>
    /// 根据Expression表达式生成SQL 
    /// </summary>
    public class MsSqlHandle
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// sql参数集合
        /// </summary>
        public List<SqlParameter> Arguments { get; set; }

        /// <summary>
        /// 参数开始索引
        /// </summary>
        public int ArgumentsStartIndex { get; set; }

        /// <summary>
        /// 生成SQL
        /// </summary>
        /// <param name="exp">表达式</param>
        /// <returns></returns>
        public void Init(Expression exp)
        {
            var obj = new ParserBuilder()
            {
                ArgumentsStartIndex = this.ArgumentsStartIndex
            };
            obj.InitBuild(exp);

            this.Result = obj.Result;
            this.Arguments = new List<SqlParameter>();
            foreach (DictionaryEntry item in obj.Arguments)
            {
                this.Arguments.Add(new SqlParameter(item.Key.ToString(), item.Value));
            }
        }
    }
}
