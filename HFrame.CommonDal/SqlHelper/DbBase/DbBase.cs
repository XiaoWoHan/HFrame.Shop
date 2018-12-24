using Dapper;
using HFrame.Common.Helper;
using HFrame.Common.Model;
using HFrame.CommonDal.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace HFrame.CommonDal
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class DbBase<T> :DBTablePropertie<T> where T : class,new()
    {
        #region 属性
        private static IDbConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=HFrameDB;Integrated Security=True;MultipleActiveResultSets=True");
        public static T Current => new T();
        #endregion

        #region 内部方法
        /// <summary>
        /// 验证模型是否正确
        /// </summary>
        /// <returns></returns>
        private bool IsValid(ResultModel Msg)
        {
            ValidationContext context = new ValidationContext(this, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var FeedBack=Validator.TryValidateObject(this, context, results, true);
            if (!FeedBack)
            {
                Msg.ErrorCode = -1;
                Msg.ErrorMsg = results.FirstOrDefault()?.ErrorMessage;
            }
            return FeedBack;
        }
        #endregion

        #region 方法
         #region 查询
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public T GetFirst()
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            Select.SetTop(1);
            return connection.Query<T>(Select.GetSql(this)).FirstOrDefault();
        }
        /// <summary>
        /// 查询条件获取第一个
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T GetFirst(Expression<Func<T,bool>> where)
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            Select.SetTop(1);
            Select.SetWhere(where);
            return connection.Query<T>(Select.GetSql(this)).FirstOrDefault();
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public List<T> GetList()
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            return connection.Query<T>(Select.GetSql(this)).ToList();
        }

        /// <summary>
        /// 查询条件获取所有
        /// </summary>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T,bool>> where)
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            Select.SetWhere(where);
            return connection.Query<T>(Select.GetSql(this)).ToList();
        }

        /// <summary>
        /// 查询条件获取所有
        /// </summary>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> where,Expression<Func<T,object>> OrderBy,bool IsDesc=true)
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            Select.SetWhere(where);
            Select.SetSorting(OrderBy, IsDesc);
            return connection.Query<T>(Select.GetSql(this)).ToList();
        }

        /// <summary>
        /// 查询条件获取所有
        /// </summary>
        /// <returns></returns>
        //public List<T> GetList(object where)
        //{
        //    return connection.Query<T>(SelectStr, where).ToList();
        //}
        //TODO 根据Dapper语法写出查询
        #endregion

        #region 分页查询
        public PageModel<T> GetPage(int pageIndex,int PageSize)
        {
            PageSqlHelper<T> Page = new PageSqlHelper<T>(pageIndex,PageSize);
            var ListModel=connection.Query(Page.GetSql(this)).ToList();
            var Total = ListModel.FirstOrDefault()?.TotalNum ?? 0;//总条数

            var PagedList=JsonHelper.ParseJson<List<T>>(ListModel.ToJson());
            return new PageModel<T>()
            {
                pageIndex = pageIndex,
                pageSize = PageSize,
                Total = Total,
                Page = PagedList
            };
        }
        #endregion

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

        #region 删除
        public bool Delete()
        {
            DeleteSqlHelper<T> DeleteModel = new DeleteSqlHelper<T>();
            return connection.Execute(DeleteModel.GetSql(this)) > 0;
        }
        #endregion
        #endregion
    }
    public partial class DbBase<T>
    {
        #region 转换类型
        public T1 Conversion<T1>()
            where T1:class,new()
        {
            var result = new T1();
            var PropInfo = typeof(T).GetProperties();
            foreach (var item in PropInfo)
            {
                typeof(T1).GetProperty(item.Name).SetValue(result,item.GetValue(this));
            }
            return result;
        }
        #endregion
    }
}
