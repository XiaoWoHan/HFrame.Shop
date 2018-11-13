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
    public class DBSqlHelper<T>: DBTablePropertie<T> where T : class, new()
    {
        #region 构造函数
        protected internal DBSqlHelper()
        {

        }
        #endregion

        #region 插入操作
        private static object _InsertSqlLocker = new object();
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <returns></returns>
        protected internal string GetTableInsertSql()
        {
            lock (_InsertSqlLocker)
            {
                StringBuilder InsertSql = new StringBuilder();
                InsertSql.Append(SqlModel.INSERT);
                InsertSql.Append(base.TableName);
                InsertSql.Append($" (   {base.TableColumnStr}  )    ");
                InsertSql.Append(SqlModel.VALUES);
                InsertSql.Append($" (   {base.Values}    )   ");
                return InsertSql.ToString();
            }
        }
        #endregion

        #region 删除操作
        private static object _DeleteSqlLocker = new object();
        protected internal string GetTableDeleteSql()
        {
            lock (_DeleteSqlLocker)
            {
                var DeleteSqlBu = new StringBuilder();
                DeleteSqlBu.Append(SqlModel.DELETE);
                DeleteSqlBu.Append(SqlModel.FROM);
                DeleteSqlBu.Append(TableName);
                return DeleteSqlBu.ToString();
            }
        }
        #endregion

        #region 更新操作
        private static object _UpdateSqlLocker = new object();
        protected internal string GetTableUpDateSql()
        {
            lock (_UpdateSqlLocker)
            {
                var UpdateSqlBu = new StringBuilder();
                UpdateSqlBu.Append(SqlModel.UPDATE);
                UpdateSqlBu.Append(TableName);
                UpdateSqlBu.Append(SqlModel.SET);
                UpdateSqlBu.Append(ColumsAndValue);
                return UpdateSqlBu.ToString();
            }
        }
        #endregion
    }
}
