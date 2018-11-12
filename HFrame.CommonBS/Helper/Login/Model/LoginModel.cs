using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HFrame.CommonBS.Model
{
    public class LoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "请输入用户名")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="用户名输入错误")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerisonCode { get; set; }
    }
}