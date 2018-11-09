﻿using HFrame.Common.Helper;
using HFrame.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonBS.Helper
{
    public class LoginHelper
    {
        public const string CookieName = "CurrentLogin";
        public static void SetLoginStatus(MemberModel Member) => CookieHelper.AddCookies(CookieName,Member.ToJson());
        public static MemberModel CurrentMember() => CookieHelper.GetCookies(CookieName)?.ParseJson<MemberModel>();
    }///TODO 缺少加密解密操作 缺少登陆方法实现封装
}
