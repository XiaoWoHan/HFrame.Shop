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
        public PageSqlHelper(int pageIndex, int pageSize)
        {
            _PAGESIZE = pageSize;
            _PAGEINDEX = pageIndex;
        }
        #region 属性
        #region 私有属性
        private static readonly object _PageSqlLocker = new object();
        #endregion
        private int _PAGESIZE;//条数
        private int _PAGEINDEX;//页数
        private const string _TableName= " DateTable   ";
        #endregion
        public new string GetSql(DBTablePropertie<T> Entity)
        {
            lock (_PageSqlLocker)
            {
                base.SetSelectColumn("ROW_NUMBER() OVER (ORDER BY CreateTime) AS ROW, COUNT(*) OVER() AS TOTAL,*");
                var DBSelectSql = base.GetSql(Entity);//查询语句

                StringBuilder PageSql = new StringBuilder();
                PageSql.Append(SqlModel.SELECT);
                PageSql.Append(SqlModel.TOP);
                PageSql.Append($"   ({_PAGESIZE})   ");
                PageSql.Append("    *   ");
                PageSql.Append(SqlModel.FROM);
                PageSql.Append($"   ({DBSelectSql}) ");
                PageSql.Append(SqlModel.AS);
                PageSql.Append(_TableName);
                PageSql.Append(SqlModel.WHERE);
                PageSql.Append($"   {_TableName}.ROW    >   ({_PAGESIZE * (_PAGEINDEX - 1)})");
                PageSql.Append(SqlModel.ORDERBY);
                PageSql.Append($"   {_TableName}.ROW    ");
                return PageSql.ToString();
            }
        }
    }
}
