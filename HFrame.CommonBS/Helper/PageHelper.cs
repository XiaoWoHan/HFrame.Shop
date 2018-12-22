using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonBS.Helper
{
    public class PageModel<T> : List<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 页数量
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int pageTotal { get; set; }
        /// <summary>
        /// 当前元素
        /// </summary>
        public List<T> Page { get; set; }
    }
    public static class PageHelper
    {
        public static PageModel<T> GetPage<T>(this List<T> Model, int pageIndex = 1, int pageSize = 20)
        {
            var result = new PageModel<T>
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                pageTotal = Model.Count,
                Page = Model.Skip(pageIndex * pageSize).Take(pageSize).ToList()
            };
            return result;
        }
    }
}
