using Mneumo.Core.Specifications;
using System;
using System.Linq.Expressions;

namespace Specifications.Tests
{
    public class IsBarLessThanTenSpecification : Specification<Foo>
    {
        public override Expression<Func<Foo, bool>> ToExpression()
        {
            return x => x.Bar < 10;
        }
    }
}
