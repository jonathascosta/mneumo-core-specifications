using System;
using System.Linq.Expressions;

namespace Mneumo.Core.Specifications
{
    /// <summary>
    /// Combines two specifications into one.
    /// </summary>
    /// <typeparam name="T">Object type to be tested.</typeparam>
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        private readonly Func<Expression, Expression, Expression> _operation;
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public CompositeSpecification(Func<Expression, Expression, BinaryExpression> operation, Specification<T> left, Specification<T> right)
        {
            _operation = operation;
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();

            var parameterReplacer = new ParameterReplacerExpressionVisitor<T, bool>(leftExpression);
            var adjustedRightExpression = (Expression<Func<T, bool>>)parameterReplacer.Visit(rightExpression);

            var combinedBody = _operation(leftExpression.Body, adjustedRightExpression.Body);

            return Expression.Lambda<Func<T, bool>>(combinedBody, leftExpression.Parameters);
        }
    }
}
