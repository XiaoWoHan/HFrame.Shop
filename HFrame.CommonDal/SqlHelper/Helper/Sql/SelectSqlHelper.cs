using HFrame.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    public class SelectSqlHelper<T> :IDBSqlHelper<T>
        where T:class
    {
        #region 属性
        /// <summary>
        /// Sql锁
        /// </summary>
        private static readonly object _selectLocker = new object();

        #region 私有属性
        private string _SELECTLimit;//查询限制 如 TOP...
        private string _SELECTFunction;//搜索函数
        private string _SELECTColumn;//搜索列名
        private string _SELECTWhere;//搜索条件
        private string _SELECTSorting;//搜索排序
        private EnumSortingType _SELECTSortingType;//搜索排序方式
        #endregion
        #endregion

        #region 构造函数
        public SelectSqlHelper()
        {
        }
        #endregion

        #region 查询字段操作
        /// <summary>
        /// 设置查询字段
        /// </summary>
        /// <param name="Columns">以,分割</param>
        public void SetSelectColumn(string Columns)
        {
            _SELECTColumn = Columns;
        }
        /// <summary>
        /// Lambda设置查询字段
        /// </summary>
        /// <param name="Column"></param>
        public void SetSelectColumn(Expression<Func<T, object>> Columns)
        {
            var Names = LambdaHelper.GetPropertyNames(Columns);
            _SELECTColumn = String.Join("   ,   ", Names);
        }
        /// <summary>
        /// 添加查询字段
        /// </summary>
        /// <param name="Column"></param>
        public void AddSelectColumn(string Column)
        {
            if (String.IsNullOrWhiteSpace(Column)) return;
            if (String.IsNullOrWhiteSpace(_SELECTColumn))
            {
                _SELECTColumn = Column; return;
            }
            _SELECTColumn = $"{_SELECTColumn}    {(Column.Trim().StartsWith(",") ? String.Empty : ",")}   {Column}";
        }
        /// <summary>
        /// Lambda添加查询字段
        /// </summary>
        /// <param name="Column"></param>
        public void AddSelectColumn(Expression<Func<T, object>> Column)
        {
            var Names = LambdaHelper.GetPropertyNames(Column);
            _SELECTColumn = $"{_SELECTColumn} , {String.Join("   ,   ", Names)}";
        }
        #endregion

        #region 查询函数操作
        /// <summary>
        /// 设置查询
        /// </summary>
        /// <param name="functionName"></param>
        public void SetFunction(string functionName)
        {
            _SELECTFunction = functionName;
        }
        #endregion

        #region 查询条件操作
        #region 设置条件
        /// <summary>
        /// 设置Where条件
        /// </summary>
        /// <param name="Where"></param>
        public void SetWhere(string Where)
        {
            _SELECTWhere = Where;
        }
        /// <summary>
        /// lambda设置条件
        /// </summary>
        /// <param name="where"></param>
        public void SetWhere(Expression<Func<T,bool>> where)
        {
            var Where=SqlSugor.GetWhereByLambda(where);
            _SELECTWhere = Where;
        }
        #endregion

        #region 并且条件
        /// <summary>
        /// 添加Where条件
        /// </summary>
        /// <param name="Where"></param>
        public void AndWhere(string Where)
        {
            if (String.IsNullOrWhiteSpace(Where)) return;
            if (String.IsNullOrWhiteSpace(_SELECTWhere))
            {
                _SELECTWhere = Where;
                return;
            }
            _SELECTWhere = $" ({_SELECTWhere})  {SqlModel.AND} ({Where})";
        }
        /// <summary>
        /// lambda添加where条件
        /// </summary>
        /// <param name="where"></param>
        public void AndWhere(Expression<Func<T, bool>> where)
        {
            if (where == null) return;
            var WhereStr = SqlSugor.GetWhereByLambda(where);
            if (String.IsNullOrWhiteSpace(_SELECTWhere))
            {
                _SELECTWhere = WhereStr;
                return;
            }
            _SELECTWhere = $" ({_SELECTWhere})  {SqlModel.AND} ({WhereStr })";
        }
        #endregion

        #region 或者条件
        /// <summary>
        /// 添加或者条件
        /// </summary>
        /// <param name="Where"></param>
        public void OrWhere(string Where)
        {
            if (String.IsNullOrWhiteSpace(Where)) return;
            if (String.IsNullOrWhiteSpace(_SELECTWhere))
            {
                _SELECTWhere = Where;
                return;
            }
            _SELECTWhere = $" ({_SELECTWhere})  {SqlModel.OR} ({Where})";
        }
        /// <summary>
        /// lambda添加或者条件
        /// </summary>
        /// <param name="where"></param>
        public void OrWhere(Expression<Func<T, bool>> where)
        {
            if (where == null) return;
            var WhereStr = SqlSugor.GetWhereByLambda(where);
            if (String.IsNullOrWhiteSpace(_SELECTWhere))
            {
                _SELECTWhere = WhereStr;
                return;
            }
            _SELECTWhere = $" ({_SELECTWhere})  {SqlModel.OR} ({WhereStr})";
        }
        #endregion
        #endregion
        //TODO 缺少去除WHERE

        #region 查询限制操作
        public void SetLimit(string Limit)
        {
            _SELECTLimit = Limit;
        }
        public void SetTop(int TopNum)
        {
            _SELECTLimit = $"   {SqlModel.TOP} {TopNum}    ";
        }
        #endregion

        #region 查询排序操作
        /// <summary>
        /// 设置排序
        /// </summary>
        /// <param name="OrderByStr"></param>
        public void SetSorting(string OrderByStr)
        {
            _SELECTSorting = OrderByStr;
        }
        /// <summary>
        /// 设置排序
        /// </summary>
        /// <param name="OrderByStr"></param>
        public void SetSorting(Expression<Func<T,object>> OrderBy,bool ISDesc=true)
        {
            var OrderByStr = LambdaHelper.GetPropertyNames(OrderBy);
            _SELECTSorting = String.Join("  ,   ",OrderByStr);
            _SELECTSortingType = ISDesc ? EnumSortingType.DESC : EnumSortingType.ASC;
        }
        #endregion

        #region 公共方法
        public string GetSql(DBTablePropertie<T> Entity)
        {
            lock (_selectLocker)
            {
                StringBuilder SELECTSql = new StringBuilder();

                #region 插入SELECT字段
                SELECTSql.Append(SqlModel.SELECT);
                #endregion

                #region 插入{TOP或其他}字段
                SELECTSql.Append(_SELECTLimit);
                #endregion

                #region 插入查询字段
                if (String.IsNullOrWhiteSpace(_SELECTColumn))
                {
                    _SELECTColumn = String.Join("   ,   ", Entity.ColumnsList);
                }
                #region 添加函数
                if (!String.IsNullOrWhiteSpace(_SELECTFunction))
                {
                    SELECTSql.Append(_SELECTFunction);
                    _SELECTColumn = $"({_SELECTColumn})";
                }
                #endregion
                SELECTSql.Append(_SELECTColumn);
                #endregion

                #region 插入FROM
                SELECTSql.Append(SqlModel.FROM);
                SELECTSql.Append(Entity.TableName);
                #endregion

                #region 插入WHERE条件
                if (!String.IsNullOrEmpty(_SELECTWhere))
                {
                    if (!_SELECTWhere.Trim().StartsWith(SqlModel.WHERE))
                    {
                        SELECTSql.Append(SqlModel.WHERE);
                    }
                    SELECTSql.Append(_SELECTWhere);
                }
                #endregion

                #region 插入排序
                if (!String.IsNullOrWhiteSpace(_SELECTSorting))
                {
                    SELECTSql.Append(SqlModel.ORDERBY);
                    SELECTSql.Append(_SELECTSorting);
                    SELECTSql.Append("  ");//TODO   可以再次优化查询排序生成语句
                    SELECTSql.Append(_SELECTSortingType);
                }
                #endregion
                return SELECTSql.ToString();
            }
        }
        #endregion
    }
}
