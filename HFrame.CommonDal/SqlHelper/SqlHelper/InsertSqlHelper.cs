using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    public class InsertSqlHelper: IDBSqlHelper
    {
        #region 插入操作
        private static object _InsertSqlLocker = new object();

        public string GetSql<T>(DBTablePropertie<T> Entity) where T : class
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
