using HFrame.Common.Cache;
using HFrame.Common.Helper;
using HFrame.Common.Model;
using HFrame.DAL;
using HFrame.Web.Default.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace HFrame.Web.Default.Service
{
    public class DefaultService
    {
        #region 注册
        public static bool Register(ResultModel result, RegisterModel Model)
        {
            #region 表单验证
            ValidationContext context = new ValidationContext(Model, null, null);///创建验证实体
            List<ValidationResult> results = new List<ValidationResult>();///返回的ErrorMsgList
            var valid = Validator.TryValidateObject(Model, context, results, true);///执行验证
            if (!valid)
            {
                result.ErrorCode = -1;
                result.ErrorMsg = $"注册失败 {results.FirstOrDefault()?.ErrorMessage}";
                return false;
            }
            if (ValidateCodeHelper.CurrentCodeString != Model.VerisonCode.ToLower())
            {
                result.ErrorCode = -1;
                result.ErrorMsg = $"注册失败 验证码错误";
                return false;
            }
            #endregion

            ValidateCodeHelper.DeleteCodeString();//清除验证码

            #region 注册方法
            var UserOID = Guid.NewGuid().ToString();
            var UserModel = new Data_User()
            {
                OID = UserOID,
                Name = Model.UserName,
                UserName = Model.UserName,
                Password = EncryptionHelper.HMACSMD5Encrypt(Model.Password, UserOID, Encoding.ASCII),
                Telephone = Model.Telephone,
                IsDeleted = false,
                IsLocked = false,
                CreateTime = DateTime.Now
            };
            return UserModel.Add();
            #endregion
        }
        #endregion

        #region 登陆
        public static bool Login(ResultModel result, LoginModel Model)
        {
            #region 模型表单验证
            ValidationContext context = new ValidationContext(Model, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(Model, context, results, true);
            #endregion
            if (valid)
            {
                var User = Data_User.Current.GetFirst(m => m.UserName == Model.UserName);
                var EncryptPass = EncryptionHelper.HMACSMD5Encrypt(Model.Password, User.OID, Encoding.ASCII);
                if (EncryptPass == User.Password)
                {
                    result.ErrorCode = 0;
                    result.ErrorMsg = $"登陆成功";
                    return true;
                }
                else
                {
                    result.ErrorCode = -1;
                    result.ErrorMsg = $"登陆失败 密码错误";
                    return false;
                }
            }
            else
            {
                result.ErrorCode = -1;
                result.ErrorMsg = $"登陆失败 {results.FirstOrDefault()?.ErrorMessage}";
                return false;
            }
        }
        //UNDONE （未添加当前登陆状态验证，存储登陆状态）
        #endregion
    }
}