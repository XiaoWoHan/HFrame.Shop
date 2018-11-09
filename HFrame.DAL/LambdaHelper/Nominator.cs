using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LambdaToSql.LambdaParser
{
    /// <summary>
    /// Performs bottom-up analysis to determine which nodes can possibly
    /// be part of an evaluated sub-tree.
    /// </summary>
    internal class Nominator : ExpressionVisitor
    {
        private Func<Expression, bool> m_fnCanBeEvaluated;
        private HashSet<Expression> m_candidates;
        private bool m_cannotBeEvaluated;

        internal Nominator(Func<Expression, bool> fnCanBeEvaluated)
        {
            this.m_fnCanBeEvaluated = fnCanBeEvaluated;
        }

        internal HashSet<Expression> Nominate(Expression expression)
        {
            this.m_candidates = new HashSet<Expression>();
            this.Visit(expression);
            return this.m_candidates;
        }

        public override Expression Visit(Expression expression)
        {
            if (expression != null)
            {
                bool saveCannotBeEvaluated = this.m_cannotBeEvaluated;
                this.m_cannotBeEvaluated = false;

                base.Visit(expression);

                if (!this.m_cannotBeEvaluated)
                {
                    if (this.m_fnCanBeEvaluated(expression))
                    {
                        this.m_candidates.Add(expression);
                    }
                    else
                    {
                        this.m_cannotBeEvaluated = true;
                    }
                }

                this.m_cannotBeEvaluated |= saveCannotBeEvaluated;
            }

            return expression;
        }
    }
}
