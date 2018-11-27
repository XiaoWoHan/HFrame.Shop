using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    public class InsertSqlHelper<T>: IDBSqlHelper<T>
        where T:class
    {
        #region 插入操作
        private static readonly object _InsertSqlLocker = new object();

        public string GetSql(DBTablePropertie<T> Entity)
        {
            lock (_InsertSqlLocker)
            {
                StringBuilder InsertSql = new StringBuilder();
                InsertSql.Append(SqlModel.INSERT);
                InsertSql.Append(Entity.TableName);
                InsertSql.Append($" (   {String.Join("  , ", Entity.ColumnsList)}  )    ");
                InsertSql.Append(SqlModel.VALUES);
                InsertSql.Append($" (   {String.Join("  ,   ", Entity.Attributes.Values)}    )   ");
                return InsertSql.ToString();
            }
        }
        #endregion
    }
}
