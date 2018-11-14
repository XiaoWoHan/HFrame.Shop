using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    /// <summary>
    /// SQL语句帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DBSqlHelper<T>: DBTablePropertie<T> where T : class, new()
    {
        /// <summary>
        /// 执行的Sql语句
        /// </summary>
        protected internal abstract string Sql { get; }
    }
}
