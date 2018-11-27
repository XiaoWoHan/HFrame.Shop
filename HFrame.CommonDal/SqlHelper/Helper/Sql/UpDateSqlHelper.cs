using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    public class UpDateSqlHelper : IDBSqlHelper
    {
        #region 更新操作
        private static object _UpdateSqlLocker = new object();

        public string GetSql<T>(DBTablePropertie<T> Entity) where T : class
        {
            lock (_UpdateSqlLocker)
            {
                var UpdateSqlBu = new StringBuilder();
                UpdateSqlBu.Append(SqlModel.UPDATE);
                UpdateSqlBu.Append(Entity.TableName);
                UpdateSqlBu.Append(SqlModel.SET);
                UpdateSqlBu.Append(String.Join("    ,   ", Entity.Attributes.Select(m => $"{m.Key.ToString()}  =   {m.Value.ToString()}")));
                return UpdateSqlBu.ToString();
            }
        }
        #endregion
        //TODO 缺少不更新字段，WHERE
    }
}
