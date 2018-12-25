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
    /// 实体类基类--添加
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class DbBase<T> : DBTablePropertie<T> where T : class, new()
    {
        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public bool Add(ResultModel result)
        {
            if (IsValid(result))
            {
                InsertSqlHelper<T> InsertModel = new InsertSqlHelper<T>();
                return connection.Execute(InsertModel.GetSql(this)) > 0;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
