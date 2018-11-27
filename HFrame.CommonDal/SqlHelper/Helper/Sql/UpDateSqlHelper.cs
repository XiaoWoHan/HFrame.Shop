using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    public class UpDateSqlHelper<T> : IDBSqlHelper<T>
        where T:class
    {
        #region 更新操作
        private static readonly object _UpdateSqlLocker = new object();

        public string GetSql(DBTablePropertie<T> Entity)
        {
            if (String.IsNullOrEmpty(Entity.Key) || !Entity.Attributes.ContainsKey(Entity.Key))
                throw new Exception("未找到主键");
            if (Entity.Attributes[Entity.Key] == null)
                throw new Exception("主键不可为空");
            lock (_UpdateSqlLocker)
            {
                var UpdateSqlBu = new StringBuilder();
                UpdateSqlBu.Append(SqlModel.UPDATE);
                UpdateSqlBu.Append(Entity.TableName);
                UpdateSqlBu.Append(SqlModel.SET);
                UpdateSqlBu.Append(String.Join("    ,   ", Entity.Attributes.Select(m => $"{m.Key.ToString()}  =   {m.Value.ToString()}")));

                UpdateSqlBu.Append(SqlModel.WHERE);
                UpdateSqlBu.Append(Entity.Key);
                UpdateSqlBu.Append("    =   ");
                UpdateSqlBu.Append(Entity.Attributes[Entity.Key]);
                return UpdateSqlBu.ToString();
            }
        }
        #endregion
        //TODO 缺少不更新字段，WHERE
    }
}
