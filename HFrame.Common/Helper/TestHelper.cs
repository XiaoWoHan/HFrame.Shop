using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.Common.Helper
{
    public static class TestHelper
    {
        #region 默认值

        #region 默认字符串
        private const string _DEFAULTALERT = "<script>alert(1)</script>";
        private const string _DEFAULTSELECT = "(SELECT * FROM DATA_SYSUSER)";
        private const string _DEFAULTVERSION = "SELECT @@VERSION";
        private const string _DEFAULTDBNAME = "SELECT DB_NAME()";
        private const string _DEFAULTABLENAME = "SELECT TOP 1 NAME FROM SYSOBJECTS WHERE XTYPE='U'";
        #endregion

        #region 默认时间
        //private const DateTime _DEFAULTTIME = DateTime(0000:00:00 00:00:00:0000);
        #endregion
        #endregion
        //public static T SetTestValue<T>()
        //{
            
        //}
    }
}
