using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HFrame.Web.Areas.Goods.Models
{
    public class UIGoodsType
    {
        /// <summary>
        /// 商品类型标识
        /// </summary>
        public string OID { get; set; }
        /// <summary>
        /// 商品类型名称
        /// </summary>
        [Required(ErrorMessage ="商品类型不得为空")]
        [MaxLength(255,ErrorMessage ="商品类型不可超过255个字符")]
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