using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LambdaToSql.LambdaParser
{
    /// <summary>
    ///
    /// </summary>
    internal class PartialEvaluator : ExpressionVisitor
    {
        private Func<Expression, bool> fnCanBeEvaluated;
        private HashSet<Expression> candidates;

        /// <summary>
        /// 
        /// </summary>
        public PartialEvaluator() : this(CanBeEvaluatedLocally)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fnCanBeEvaluated"></param>
        public PartialEvaluator(Func<Expression, bool> fnCanBeEvaluated)
        {
            this.fnCanBeEvaluated = fnCanBeEvaluated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public Expression Eval(Expression exp)
        {
            this.candidates = new Nominator(this.fnCanBeEvaluated).Nominate(exp);
            return this.Visit(exp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public override Expression Visit(Expression exp)
        {
            if (exp == null)
            {
                return null;
            }
            if (this.candidates.Contains(exp))
            {
                return this.Evaluate(exp);
            }
            return base.Visit(exp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private Expression Evaluate(Expression exp)
        {
            if (exp.NodeType == ExpressionType.Constant)
            {
                return exp;
            }
            LambdaExpression lambda = Expression.Lambda(exp);
            Delegate fn = lambda.Compile();
            var value = Expression.Constant(fn.DynamicInvoke(null), exp.Type);
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private static bool CanBeEvaluatedLocally(Expression exp)
        {
            return exp.NodeType != ExpressionType.Parameter;
        }
    }
}
