using System.Linq.Expressions;

namespace Mneumo.Core.Specifications
{
    /// <summary>
    /// Creates a combined specification that represents a conditional AND operation.
    /// </summary>
    /// <typeparam name="T">Object type to be tested.</typeparam>
    public sealed class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(Specification<T> left, Specification<T> right) : base(Expression.And, left, right) { }
    }
}
