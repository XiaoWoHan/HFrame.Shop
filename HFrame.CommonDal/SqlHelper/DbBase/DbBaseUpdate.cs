using Dapper;
using HFrame.Common.Model;
using HFrame.CommonDal.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal
{
    /// <summary>
    /// 实体类基类--更新
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class DbBase<T> : DBTablePropertie<T> where T : class, new()
    {
        #region 更新
        public bool Update(ResultModel result)
        {
            if (IsValid(result))
            {
                UpDateSqlHelper<T> UpDateModel = new UpDateSqlHelper<T>();
                return connection.Execute(UpDateModel.GetSql(this)) > 0;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
