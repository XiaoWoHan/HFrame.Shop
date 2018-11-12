﻿using HFrame.Common.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HFrame.CommonBS.Model
{
    /// <summary>
    /// 注册表单
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage ="请输入用户名")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "账户名必须大于3且不大于50个字符")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "密码必须大于3且不大于32个字符")]
        public string Password { get; set; }
        /// <summary>
        /// 重复密码
        /// </summary>
        [Required(ErrorMessage = "请输入重复密码")]
        [Compare("Password",ErrorMessage ="两次密码输入不一致")]
        public string RePassword { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Phone(ErrorMessage = "联系电话不正确")]
        [Required(ErrorMessage = "请输入联系电话")]
        public string Telephone { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "请输入验证码")]
        public string VerisonCode { get; set; }
    }
}