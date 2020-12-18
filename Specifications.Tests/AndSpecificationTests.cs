using Mneumo.Core.Specifications;
using Xunit;

namespace Specifications.Tests
{
    public class AndSpecificationTests
    {
        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        [InlineData(11, false)]
        public void IsSatisfiedByTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec = new AndSpecification<Foo>(new IsBarGreaterThanZeroSpecification(), new IsBarLessThanTenSpecification());

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }
    }
}
