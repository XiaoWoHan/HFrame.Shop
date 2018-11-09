using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
/*
 * 登陆状态
 */
namespace HFrame.Common.Model.Enum
{
    public enum EnumLoginType
    {
        [Description("临时登陆")]
        Temporary=0,
        [Description("扫码登陆")]
        ScanQRCode = 0,
        [Description("账号登陆")]
        Account = 1,
        [Description("手机登陆")]
        MobilePhone = 2,
        [Description("邮箱登陆")]
        Email = 3,
    }
}
