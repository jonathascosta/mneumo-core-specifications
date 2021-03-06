﻿using Mneumo.Core.Specifications;
using System;
using System.Linq.Expressions;

namespace Specifications.Tests
{
    public class IsBarLessThanZeroSpecification : Specification<Foo>
    {
        public override Expression<Func<Foo, bool>> ToExpression()
        {
            return x => x.Bar < 0;
        }
    }
}
