using HFrame.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.Common.Helper
{
    public static class ListHelper
    {
        /// <summary>
        /// 分页集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageModel<T> GetPage<T>(this List<T> Model, int pageIndex = 1, int pageSize = 20)
        {
            var result = new PageModel<T>
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                Total = Model.Count,
                Page = Model.Skip(pageIndex * pageSize).Take(pageSize).ToList()
            }; 
            return result;
        }
    }
}
