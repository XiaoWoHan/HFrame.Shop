using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    public class DeleteSqlHelper :IDBSqlHelper
    {
        #region 删除操作
        private static object _DeleteSqlLocker = new object();

        public string GetSql<T>(DBTablePropertie<T> Entity) where T : class
        {
            lock (_DeleteSqlLocker)
            {
                var DeleteSqlBu = new StringBuilder();
                DeleteSqlBu.Append(SqlModel.DELETE);
                DeleteSqlBu.Append(SqlModel.FROM);
                DeleteSqlBu.Append(Entity.TableName);
                return DeleteSqlBu.ToString();
            }
        }
        #endregion
        //TODO 缺少WHERE
    }
}
