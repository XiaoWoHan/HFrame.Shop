using HFrame.Common.Helper;
using HFrame.Common.Model;
using HFrame.CommonBS.Model;
using HFrame.CommonDal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HFrame.CommonBS.Helper
{
    public class RegisterHelper
    {
        #region 注册
        public static bool Register(ResultModel result, RegisterModel Model)
        {
            ///TODO 是否允许注册验证,注册次数
            
            #region 表单验证
            if (ValidateCodeHelper.CurrentCodeString != Model.VerisonCode.ToLower())
            {
                result.ErrorCode = -1;
                result.ErrorMsg = $"注册失败 验证码错误";
                return false;
            }
            ValidateCodeHelper.DeleteCodeString();//清除验证码
            #endregion
            var SameUser = Data_SysUser.Current.GetFirst(m => m.IsDeleted!=true && m.Name.Equals(Model.UserName));
            if (SameUser != null)
            {
                result.ErrorCode = -1;
                result.ErrorMsg = $"注册失败 用户名已注册";
                return false;
            }
            var SameTelephone = Data_SysUser.Current.GetFirst(m=>m.IsDeleted!=true&&m.Telephone.Equals(Model.Telephone));
            if (SameTelephone != null)
            {
                result.ErrorCode = -1;
                result.ErrorMsg = $"注册失败 手机号已注册";
                return false;
            }

            #region 注册方法
            var UserOID = Guid.NewGuid().ToString();
            var UserModel = new Data_SysUser()
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
            return UserModel.Add(result);
            #endregion
        }
        #endregion
    }
}