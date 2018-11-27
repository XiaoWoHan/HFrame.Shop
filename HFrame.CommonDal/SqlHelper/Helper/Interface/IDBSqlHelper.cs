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
    public interface IDBSqlHelper<T>
        where T:class
    {
        /// <summary>
        /// 执行的Sql语句
        /// </summary>
        string GetSql(DBTablePropertie<T> Entity);
    }
}
