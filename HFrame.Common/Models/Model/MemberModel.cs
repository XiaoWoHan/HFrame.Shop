using HFrame.Common.Model.Enum;

namespace HFrame.Common.Model
{
    public class MemberModel
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        internal string MemberOID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        internal string MemberName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        internal string MemberNickName { get; set; }
        /// <summary>
        /// 登陆标识
        /// </summary>
        internal string Token { get; set; }
        /// <summary>
        /// 登陆方式
        /// </summary>
        internal EnumLoginType LoginType { get; set; }
    }
}
