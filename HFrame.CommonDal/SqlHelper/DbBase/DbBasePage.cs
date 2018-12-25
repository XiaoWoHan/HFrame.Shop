using Dapper;
using HFrame.Common.Helper;
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
    /// 实体类基类--分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class DbBase<T> : DBTablePropertie<T> where T : class, new()
    {
        #region 分页查询
        public PageModel<T> GetPage(int pageIndex, int PageSize)
        {
            PageSqlHelper<T> Page = new PageSqlHelper<T>(pageIndex, PageSize);
            var ListModel = connection.Query(Page.GetSql(this)).ToList();
            var Total = ListModel.FirstOrDefault()?.TotalNum ?? 0;//总条数

            var PagedList = JsonHelper.ParseJson<List<T>>(ListModel.ToJson());//TODO 分页转换类型可优化
            return new PageModel<T>()
            {
                pageIndex = pageIndex,
                pageSize = PageSize,
                Total = Total,
                Page = PagedList
            };
        }
        #endregion
    }
}
