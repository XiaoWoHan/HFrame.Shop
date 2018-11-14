using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    public class InsertSqlHelper<T>: DBSqlHelper<T> where T : class, new()
    {
        #region 插入操作
        private static object _InsertSqlLocker = new object();
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <returns></returns>
        protected internal override string Sql
        {
            get
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
        }
        #endregion
    }
}
