using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFrame.Web.Areas.Manage.Models
{
    public class UIMenu
    {
        /// <summary>
        /// 按钮标识
        /// </summary>
        public string OID { get; set; }
        /// <summary>
        /// 按钮
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Layer { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}