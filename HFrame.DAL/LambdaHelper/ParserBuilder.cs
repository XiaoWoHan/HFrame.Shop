using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace LambdaToSql.LambdaParser
{
    /// <summary>
    /// 脚本生成实体
    /// </summary>
    internal sealed class ParserBuilder : ExpressionVisitor
    {
        #region 属性

        /// <summary>
        /// 参数
        /// </summary>
        public OrderedDictionary Arguments { get; private set; }

        /// <summary>
        /// 参数开始索引
        /// </summary>
        public int ArgumentsStartIndex { get; set; }

        /// <summary>
        ///  返回值
        /// </summary>
        public string Result
        {
            get
            {
                var str = string.Join(",", this.ConditionParts);
                return str;
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        private Stack<string> ConditionParts = new Stack<string>();
        #endregion

        #region 默认构造函数

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ParserBuilder()
        {
            this.Arguments = new OrderedDictionary();
        }
        #endregion

        #region 执行生成

        /// <summary>
        /// 执行生成
        /// </summary>
        /// <param name="expression"></param>
        public void InitBuild(Expression expression)
        {
            //前期处理
            PartialEvaluator evaluator = new PartialEvaluator();
            Expression evaluatedExpression = evaluator.Eval(expression);

            this.Visit(evaluatedExpression);
        }
        #endregion


        #region 重写 二元操作符

        /// <summary>
        /// 重写 二元操作符
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected sealed override Expression VisitBinary(BinaryExpression node)
        {
            if (node != null)
            {
                this.Visit(node.Left);
                this.Visit(node.Right);

                string right = this.ConditionParts.Pop();
                string left = this.ConditionParts.Pop();

                string opr = ExpressionTypeCast.Convert(node.NodeType);//操作符 
                string condition = string.Format("({0}{1}{2})", left, opr, right);
                this.ConditionParts.Push(condition);
            }
            return node;
        }
        #endregion

        #region 重写常量

        /// <summary>
        /// 重写常量
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected sealed override Expression VisitConstant(ConstantExpression node)
        {
            if (node != null)
            {
                var parName = string.Format("@parm{0}", this.Arguments.Count + this.ArgumentsStartIndex);
                this.Arguments.Add(parName, node.Value);
                //this.ConditionParts.Push(string.Format("{{{0}}}", this.Arguments.Count - 1));
                this.ConditionParts.Push(parName);
            }
            return node;
        }
        #endregion

        #region 重写 字段 属性
        public bool IsFound { get; private set; }
        public Type MemberType { get; private set; }
        /// <summary>
        /// 重写 字段 属性
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>00.
        protected sealed override Expression VisitMember(MemberExpression node)
        {
            if (node != null && node.Member.Name != "Value")
            {
                var obj = node.Update(Visit(node.Expression));
                PropertyInfo propertyInfo = node.Member as PropertyInfo;
                if (propertyInfo == null)
                {
                    return node;
                }
                this.ConditionParts.Push(string.Format("{0}", propertyInfo.Name));
            }
            else
            {
                return base.VisitMember(node);
            }
            return node;


            //if (!IsFound && node.Member.MemberType == MemberTypes.Property)
            //{
            //    IsFound = true; 
            //    MemberType = node.Type;
            //    if (node.Member.Name == "Value")
            //    {
            //        IsFound = false;
            //    }
            //    else
            //    {
            //        this.ConditionParts.Push(string.Format("{0}", node.Member.Name));
            //    }
            //}
            //return base.VisitMember(node);
        }
        #endregion

        #region 重写方法处理

        /// <summary>
        /// ConditionBuilder 并不支持生成Like操作，如 字符串的 StartsWith，Contains，EndsWith 并不能生成这样的SQL： Like ‘xxx%’, Like ‘%xxx%’ , Like ‘%xxx’ . 只要override VisitMethodCall 这个方法即可实现上述功能。
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected sealed override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node != null)
            {
                Expression field;
                Expression par = null;
                if (node.ToString().StartsWith("value"))
                {
                    if (node.Object != null)
                    {
                        par = node.Object;
                        field = node.Arguments[0];
                    }
                    else
                    {
                        par = node.Arguments[0];
                        field = node.Arguments[1];
                    }
                }
                else
                {
                    if (node.Object != null)
                    {
                        field = node.Object;
                        if (node.Arguments.Count > 0)
                        {
                            par = node.Arguments[0];
                        }
                    }
                    else
                    {
                        field = node.Arguments[0];
                        par = node.Arguments[1];
                    }
                }

                this.Visit(field);
                this.Visit(par);
                var right = this.ConditionParts.Pop();
                var left = this.ConditionParts.Pop();

                MethodCall(node.Method.Name, left, right);
            }
            return node;
        }

        /// <summary>
        /// 自定义方法和公用方法处理
        /// </summary>
        /// <param name="methodName">方法名称</param>
        /// <param name="left">左测 一定是字段名称</param>
        /// <param name="right">右侧 一定是 this.Arguments的key</param>
        private void MethodCall(string methodName, string left, string right)
        {
            var value = this.Arguments[right];
            var format = "";

            #region 设置sql查询模板

            if (methodName == "Contains" && value is System.Collections.IList)
            {
                methodName = "ExIn";
            }
            if (methodName == "NotContains" && value is System.Collections.IList)
            {
                methodName = "ExNotIn";
            }

            switch (methodName)//系统级
            {
                case "StartsWith":
                    {
                        format = "({0} like {1}+'%')";
                        break;
                    }
                case "EndsWith":
                    {
                        format = "({0} like '%'+{1})";
                        break;
                    }
                case "Contains":
                    {
                        format = "({0} like '%'+{1}+'%')";
                        break;
                    }
                case "NotContains":
                    {
                        format = "({0} not like '%'+{1}+'%')";
                        break;
                    }
                case "Equals":
                    {
                        format = "({0} = {1} ";
                        break;
                    }
                case "ExIn":
                    {
                        format = "({0} in ({1}))";
                        break;
                    }
                case "ExNotIn":
                    {
                        format = "({0} not in ({1}))";
                        break;
                    }
                case "ExNotLike":
                    {
                        format = "({0} not like '%'+{1}+'%')";
                        break;
                    }
                case "ExNotStartsLike":
                    {
                        format = "({0} not like {1}+'%')";
                        break;
                    }
                case "ExNotEndsLike":
                    {
                        format = "({0} not like '%'+{1})";
                        break;
                    }
            }
            #endregion

            #region 组装sql语句

            switch (methodName)
            {
                case "ExIn":
                case "ExNotIn":
                    {
                        this.Arguments.Remove(right);
                        var sb = new StringBuilder();
                        var ls = "";
                        foreach (var item in (value as System.Collections.IList))
                        {
                            var parName = "@parm" + (this.Arguments.Count + this.ArgumentsStartIndex);
                            sb.Append(ls + parName);
                            ls = ",";
                            this.Arguments.Add(parName, item);
                        }
                        if (!string.IsNullOrEmpty(sb.ToString()))
                        {
                            this.ConditionParts.Push(string.Format(format, left, sb));
                        }
                        else
                        {
                            if (methodName == "ExIn")
                            {
                                this.ConditionParts.Push(string.Format("1 = 0"));
                            }
                            else if (methodName == "ExNotIn")
                            {
                                this.ConditionParts.Push(string.Format("1 = 1"));
                            }
                        }
                        break;
                    }
                case "ToLower":
                    {
                        var arrs = left.Split('=');
                        var sql = string.Format("ToLower({0})={1}", arrs[0], arrs[1]);
                        this.ConditionParts.Push(sql);
                        break;
                    }
                default:
                    {
                        this.ConditionParts.Push(string.Format(format, left, right));
                        break;
                    }
            }
            #endregion
        }

        #endregion 
    }
}
