using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    public class DeleteSqlHelper<T> :IDBSqlHelper<T>
        where T:class
    {
        #region 删除操作
        private static readonly object _DeleteSqlLocker = new object();

        public string GetSql(DBTablePropertie<T> Entity)
        {
            if (String.IsNullOrEmpty(Entity.Key) || !Entity.Attributes.ContainsKey(Entity.Key))
                throw new Exception("未找到主键");
            if (Entity.Attributes[Entity.Key] == null)
                throw new Exception("主键不可为空");
            lock (_DeleteSqlLocker)
            {
                var DeleteSqlBu = new StringBuilder();
                DeleteSqlBu.Append(SqlModel.DELETE);
                DeleteSqlBu.Append(SqlModel.FROM);
                DeleteSqlBu.Append(Entity.TableName);
                DeleteSqlBu.Append(SqlModel.WHERE);
                DeleteSqlBu.Append(Entity.Key);
                DeleteSqlBu.Append("    =   ");
                DeleteSqlBu.Append(Entity.Attributes[Entity.Key]);
                return DeleteSqlBu.ToString();
            }
        }//TODO 缺少WHERE组装判断
        #endregion
    }
}
