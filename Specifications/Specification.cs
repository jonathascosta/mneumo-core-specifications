using System;
using System.Linq.Expressions;

namespace Mneumo.Core.Specifications
{
    /// <summary>
    /// Base class for Specifications.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Specification<T>
    {
        /// <summary>
        /// When implemented, determines if specification is satisfied by object state.
        /// </summary>
        /// <param name="obj">Object to test.</param>
        /// <returns>If specification is met returns true, otherwise returns false.</returns>
        public virtual bool IsSatisfiedBy(T obj)
        {
            return ToExpression().Compile()(obj);
        }

        public Specification<T> And(Specification<T> spec)
        {
            return new AndSpecification<T>(this, spec);
        }

        public Specification<T> AndAlso(Specification<T> spec)
        {
            return new AndAlsoSpecification<T>(this, spec);
        }

        public Specification<T> Or(Specification<T> spec)
        {
            return new OrSpecification<T>(this, spec);
        }

        public Specification<T> OrElse(Specification<T> spec)
        {
            return new OrElseSpecification<T>(this, spec);
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        public abstract Expression<Func<T, bool>> ToExpression();

        public static Specification<T> operator &(Specification<T> left, Specification<T> right)
        {
            return left.And(right);
        }

        public static Specification<T> operator |(Specification<T> left, Specification<T> right)
        {
            return left.Or(right);
        }

        public static Specification<T> operator !(Specification<T> spec)
        {
            return spec.Not();
        }
    }
}
