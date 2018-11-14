using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    public class DeleteSqlHelper<T> : DBSqlHelper<T> where T : class, new()
    {
        #region 删除操作
        private static object _DeleteSqlLocker = new object();
        protected internal override string Sql
        {
            get
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
        }
        #endregion
        //TODO 缺少WHERE
    }
}
