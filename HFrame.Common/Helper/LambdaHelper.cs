using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.Common.Helper
{
    public static class LambdaHelper
    {
        /// <summary>
        /// 根据Lambda表达式获取字段名称字符串
        /// </summary>
        /// <typeparam name="T">要获取的类型</typeparam>
        /// <param name="expression">Lambda表达式树对象</param>
        /// <returns>字段名称数组</returns>
        public static string[] GetPropertyNames<T>(Expression<Func<T, object>> expression)
        {
            if (expression == null) throw new ArgumentNullException();
            //只有一个值 NodeType 类型为 ExpressionType.Convert
            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                return new[] { GetPropertyVlaue("Body.Operand.Member.Name", expression) as string };
            }
            //返回的是一个数组 NodeType 类型为 ExpressionType.NewArrayInit
            if (expression.Body.NodeType == ExpressionType.NewArrayInit)
            {
                var list = (IEnumerable<Expression>)GetPropertyVlaue("Body.Expressions", expression);
                return list.Select(l =>
                {
                    //他的第一项类型为 Convert 后面的均为 MemberAccess
                    if (l.NodeType == ExpressionType.Convert)
                        return GetPropertyVlaue("Operand.Member.Name", l) as string;
                    return GetPropertyVlaue("Member.Name", l) as string;
                }).ToArray();
            }
            if (expression.Body.NodeType == ExpressionType.New)
            {
                var list = ((NewExpression)expression.Body).Members;
                return list.Select(m=>m.Name).ToArray();

            }
            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                var Name=((MemberExpression)expression.Body).Member.Name;
                return new string[] { Name };
            }
            throw new Exception("表达式过于复杂无法解析！");
        }

        /// <summary>
        /// 根据路径获取字段值
        /// </summary>
        /// <param name="fullPath">路径</param>
        /// <param name="obj">对象</param>
        /// <returns>获取到的值</returns>
        private static object GetPropertyVlaue(string fullPath, object obj)
        {
            var o = obj;
            fullPath.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(point =>
            {
                o = o.GetType().GetProperty(point,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).GetValue(o, null);
            });
            return o;
        }

    }
}
