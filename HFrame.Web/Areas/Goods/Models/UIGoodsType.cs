using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFrame.Web.Areas.Goods.Models
{
    public class UIGoodsType
    {
        /// <summary>
        /// 商品类型名称
        /// </summary>
        public string GoodsType { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 商品类型名称
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}