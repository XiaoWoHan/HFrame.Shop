using Dapper;
using HFrame.CommonDal.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal
{
    /// <summary>
    /// 实体类基类--查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class DbBase<T> : DBTablePropertie<T> where T : class, new()
    {
        #region 查询
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public T GetFirst()
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            Select.SetTop(1);
            return connection.Query<T>(Select.GetSql(this)).FirstOrDefault();
        }
        /// <summary>
        /// 查询条件获取第一个
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T GetFirst(Expression<Func<T, bool>> where)
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            Select.SetTop(1);
            Select.SetWhere(where);
            return connection.Query<T>(Select.GetSql(this)).FirstOrDefault();
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public List<T> GetList()
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            return connection.Query<T>(Select.GetSql(this)).ToList();
        }

        /// <summary>
        /// 查询条件获取所有
        /// </summary>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> where)
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            Select.SetWhere(where);
            return connection.Query<T>(Select.GetSql(this)).ToList();
        }

        /// <summary>
        /// 查询条件获取所有
        /// </summary>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> where, Expression<Func<T, object>> OrderBy, bool IsDesc = true)
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            Select.SetWhere(where);
            Select.SetSorting(OrderBy, IsDesc);
            return connection.Query<T>(Select.GetSql(this)).ToList();
        }

        /// <summary>
        /// 查询条件获取所有
        /// </summary>
        /// <returns></returns>
        //public List<T> GetList(object where)
        //{
        //    return connection.Query<T>(SelectStr, where).ToList();
        //}
        //TODO 根据Dapper语法写出查询
        #endregion
    }
}
