using System;
using System.Linq.Expressions;

namespace Mneumo.Core.Specifications
{
    public sealed class ParameterReplacerExpressionVisitor<T, R> : ExpressionVisitor
    {
        private readonly ParameterExpression _originalParameter;

        public ParameterReplacerExpressionVisitor(Expression<Func<T, R>> originalExpression)
        {
            _originalParameter = originalExpression.Parameters[0];
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return base.VisitParameter(_originalParameter);
        }
    }
}
