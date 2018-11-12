using HFrame.Common.Helper;
using HFrame.Common.Model;
using HFrame.CommonBS.Helper;
using HFrame.CommonBS.Model;
using HFrame.CommonDal.Model;

namespace HFrame.CommonBS.Service
{
    public class LoginHelper
    {
        /// <summary>
        /// 登陆状态默认命名空间
        /// </summary>
        private const string CookieName = "CurrentLogin";
        /// <summary>
        /// 获取当前登陆状态
        /// </summary>
        /// <returns></returns>
        public static MemberModel CurrentMember => CookieHelper.GetCookies(CookieName)?.ParseJson<MemberModel>();
        /// <summary>
        /// 添加登陆状态
        /// </summary>
        /// <param name="Member"></param>
        public static void SetLoginStatus(MemberModel Member) => CookieHelper.AddCookies(CookieName, Member.ToJson());

        #region 登陆
        public static bool Login(ResultModel result, LoginModel Model)
        {
            //TODO 验证当前是否允许登陆
            if (CurrentMember != null)
            {
                result.ErrorCode = -1;
                result.ErrorMsg = "您当前已登陆";
                return false;
            }
            //TODO 登陆失败次数限制

            var User = Data_User.Current.GetFirst(m => m.UserName == Model.UserName && !m.IsDeleted);//根据用户名获取当前用户
            if (User == null)
            {
                result.ErrorCode = -1;
                result.ErrorMsg = "用户名或密码错误";
                return false;
            }
            if (User.IsLocked)
            {
                result.ErrorCode = -1;
                result.ErrorMsg = "您当前无法登陆";
                return false;
            }

            var EncryptPass = EncryptionHelper.HMACSMD5Encrypt(Model.Password, User.OID, System.Text.Encoding.ASCII);//加密密码
            if (EncryptPass != User.Password)
            {
                result.ErrorCode = -1;
                result.ErrorMsg = $"登陆失败 密码错误";
                return false;
            }

            #region 添加登陆状态
            var Member = new MemberModel
            {
                MemberOID = User.OID,
                MemberName = User.UserName,
                MemberNickName = User.Name,
                LoginType = Common.Model.Enum.EnumLoginType.Account
            };
            LoginHelper.SetLoginStatus(Member);//添加登陆状态

            result.ErrorCode = 0;
            result.ErrorMsg = $"登陆成功";
            result.CallbackPage = "/Main/Main";
            return true;
            #endregion

        }//UNDONE （未添加当前登陆状态验证，存储登陆状态）
        #endregion
    }
}