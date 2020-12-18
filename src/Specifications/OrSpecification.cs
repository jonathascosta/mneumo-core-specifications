using System.Linq.Expressions;

namespace Mneumo.Core.Specifications
{
    /// <summary>
    /// Creates a combined specification that represents a conditional OR operation.
    /// </summary>
    /// <typeparam name="T">Object type to be tested.</typeparam>
    public sealed class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(Specification<T> left, Specification<T> right) : base(Expression.Or, left, right) { }
    }
}
