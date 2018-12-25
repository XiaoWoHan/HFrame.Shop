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
    }
}
