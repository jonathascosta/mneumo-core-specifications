using Mneumo.Core.Specifications;
using Xunit;

namespace Specifications.Tests
{
    public class OrElseSpecificationTests
    {
        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, true)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        [InlineData(11, false)]
        public void IsSatisfiedByTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec = new OrElseSpecification<Foo>(new IsBarLessThanZeroSpecification(), new IsBarLessThanTenSpecification());

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }
    }
}
