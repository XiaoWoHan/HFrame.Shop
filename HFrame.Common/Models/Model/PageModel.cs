using HFrame.Common.Cache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.Common.Model
{
    public class PageModel<T>: IEnumerable
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
        /// 总条数
        /// </summary>
        public int Total { get; set; }
        #region 计算属性
        /// <summary>
        /// 总页数
        /// </summary>
        public int pageTotal => (int)Math.Ceiling((decimal)Total / pageSize > 0 ? (decimal)pageSize : throw new Exception("pageSize必须大于0"));
        #endregion
        /// <summary>
        /// 结果集
        /// </summary>
        public List<T> Page { get; set; } = new List<T>();
        /// <summary>
        /// 扩展this
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]=>Page[index];
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return Page.GetEnumerator();
        }
    }
}
