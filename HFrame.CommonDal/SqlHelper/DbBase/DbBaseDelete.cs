using Dapper;
using HFrame.CommonDal.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal
{
    /// <summary>
    /// 实体类基类--删除
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class DbBase<T> : DBTablePropertie<T> where T : class, new()
    {

        #region 删除
        public bool Delete()
        {
            DeleteSqlHelper<T> DeleteModel = new DeleteSqlHelper<T>();
            return connection.Execute(DeleteModel.GetSql(this)) > 0;
        }
        #endregion
    }
}
