﻿using Dapper;
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
    public class DbBase<T>:DBSqlHelper<T> where T : class, new()
    {
        #region 属性
        private static IDbConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HFrameDB;Integrated Security=True;MultipleActiveResultSets=True");
        public static DbBase<T> Current = new DbBase<T>();
        #endregion

        #region 构造函数
        public DbBase()
        {
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
            return connection.Query<T>(Select.Sql).FirstOrDefault();
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
            return connection.Query<T>(Select.Sql).FirstOrDefault();
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public List<T> GetList()
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            return connection.Query<T>(Select.Sql).ToList();
        }

        /// <summary>
        /// 查询条件获取所有
        /// </summary>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T,bool>> where)
        {
            SelectSqlHelper<T> Select = new SelectSqlHelper<T>();
            Select.SetWhere(where);
            return connection.Query<T>(Select.Sql).ToList();
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
            return connection.Query<T>(Select.Sql).ToList();
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

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public bool Add()
        {
            var InsertStr = GetTableInsertSql();
            return connection.Execute(InsertStr)>0;
        }
        #endregion

        #region 更新
        public bool Update()
        {
            if (IsValid())
            {
                var InsertStr = GetTableUpDateSql();
                return connection.Execute(InsertStr) > 0;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 删除
        public bool Deleted()
        {
            var InsertStr = GetTableDeleteSql();
            return connection.Execute(InsertStr) > 0;
        }
        #endregion
        #endregion

        #region 内部方法
        private bool IsValid()
        {
            ValidationContext context = new ValidationContext(this, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            return Validator.TryValidateObject(this, context, results, true);
        }
        #endregion
    }
}
