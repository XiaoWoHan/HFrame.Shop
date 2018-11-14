using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    public class UpDateSqlHelper<T>: DBSqlHelper<T> where T : class, new()
    {
        #region 更新操作
        private static object _UpdateSqlLocker = new object();
        protected internal override string Sql
        {
            get
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
        //TODO 缺少不更新字段，WHERE
    }
}
