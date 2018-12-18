using HFrame.Common.Model.Enum;

namespace HFrame.Common.Model
{
    public class MemberModel
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public string MemberOID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string MemberNickName { get; set; }
        /// <summary>
        /// 登陆标识
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 登陆方式
        /// </summary>
        public EnumLoginType LoginType { get; set; }
    }
}
