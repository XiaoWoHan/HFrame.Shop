using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.DAL
{
    /// <summary>
    /// SQL语句帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBSqlHelper<T>: DBTablePropertie<T> where T : class, new()
    {
        #region 属性

        #region SQL字段封装
        private const string SELECT = " SELECT  ";
        private const string FROM = "   FROM    ";
        private const string WHERE = "  WHERE   ";

        private const string INSERT = "   INSERT    INTO    ";
        private const string VALUES = "   VALUES    ";

        private const string DELETE = "   DELETE    ";

        private const string UPDATE = "   UPDATE    ";
        private const string SET = "   SET    ";
        #endregion

        #endregion

        #region 构造函数
        protected internal DBSqlHelper()
        {

        }
        #endregion

        #region 查询操作
        private static object _selectLocker = new object();
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        protected internal string GetTableSelectSql()
        {
            lock (_selectLocker)
            {
                StringBuilder SelectSql = new StringBuilder();
                SelectSql.Append(SELECT);
                SelectSql.Append(base.Columns);
                SelectSql.Append(FROM);
                SelectSql.Append(base.TableName);
                return SelectSql.ToString();
            }
        }

        private static object _whereSelectLocker = new object();
        protected internal string GetTableWhereSelectSql(Expression<Func<T, bool>> expression)
        {
            lock (_whereSelectLocker)
            {
                StringBuilder SelectSql = new StringBuilder();
                SelectSql.Append(SELECT);
                SelectSql.Append(base.Columns);
                SelectSql.Append(FROM);
                SelectSql.Append(base.TableName);
                SelectSql.Append(WHERE);
                SelectSql.Append(GetTableWhereSql(expression));
                return SelectSql.ToString();
            }
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
                InsertSql.Append(INSERT);
                InsertSql.Append(base.TableName);
                InsertSql.Append($" (   {base.Columns}  )    ");
                InsertSql.Append(VALUES);
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
                DeleteSqlBu.Append(DELETE);
                DeleteSqlBu.Append(FROM);
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
                UpdateSqlBu.Append(UPDATE);
                UpdateSqlBu.Append(TableName);
                UpdateSqlBu.Append(SET);
                UpdateSqlBu.Append(ColumsAndValue);
                return UpdateSqlBu.ToString();
            }
        }
        #endregion

        #region 查询条件
        private static object _WhereSqlLocker = new object();
        protected internal string GetTableWhereSql(Expression<Func<T, bool>> expression)
        {
            lock (_WhereSqlLocker)
            {
                var itemLambda = new LambdaToSql.LambdaRouter();
                var Str= itemLambda.ExpressionRouter(expression);
                return Str;
            }
        }
        #endregion
    }
}
