using System.Linq.Expressions;

namespace Mneumo.Core.Specifications
{
    /// <summary>
    /// Creates a combined specification that represents a conditional AND operation that evaluates the second specification only if the first specification evaluates to true.
    /// </summary>
    /// <typeparam name="T">Object type to be tested.</typeparam>
    public sealed class AndAlsoSpecification<T> : CompositeSpecification<T>
    {
        public AndAlsoSpecification(Specification<T> left, Specification<T> right) : base(Expression.AndAlso, left, right) { }
    }
}
