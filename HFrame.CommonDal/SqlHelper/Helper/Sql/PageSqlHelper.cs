using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    /// <summary>
    /// 分页查询语句
    /// </summary>
    /// <code>
    /// --TIME_SEGMENT为数据表字段
    ///    declare @pagesize int--每页大小
    ///    declare @currentpage int--当前页
    ///    
    ///    set @pagesize=2
    ///    set @currentpage = 2
    ///    
    ///    SELECT TOP(@pagesize) *
    ///    FROM(
    ///     SELECT ROW_NUMBER() OVER (ORDER BY CreateTime) AS row, COUNT(*) OVER() AS TOTAL,*
    ///     FROM Data_Menu
    ///    ) as t
    ///    WHERE t.row > (@pagesize*(@currentpage-1)) 
    ///    order by t.row;
    /// </code>
    public class PageSqlHelper<T>: SelectSqlHelper<T> , IDBSqlHelper<T>
        where T : class
    {
        public new string GetSql(DBTablePropertie<T> Entity)
        {
            base.SetSelectColumn("ROW_NUMBER() OVER (ORDER BY CreateTime) AS row, COUNT(*) OVER() AS TOTAL,")
            var SelectSql=base.GetSql(Entity);

            return String.Empty;
        }
    }
}
