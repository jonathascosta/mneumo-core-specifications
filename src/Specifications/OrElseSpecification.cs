using System.Linq.Expressions;

namespace Mneumo.Core.Specifications
{
    /// <summary>
    /// Creates a combined specification that represents a conditional OR operation that evaluates the second specification only if the first specification evaluates to false.
    /// </summary>
    /// <typeparam name="T">Object type to be tested.</typeparam>
    public sealed class OrElseSpecification<T> : CompositeSpecification<T>
    {
        public OrElseSpecification(Specification<T> left, Specification<T> right) : base(Expression.OrElse, left, right) { }
    }
}
