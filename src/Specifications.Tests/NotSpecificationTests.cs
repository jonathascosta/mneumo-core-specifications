using Mneumo.Core.Specifications;
using Xunit;

namespace Specifications.Tests
{
    public class NotSpecificationTests
    {
        [Theory]
        [InlineData(9, false)]
        [InlineData(10, true)]
        [InlineData(11, true)]
        public void IsSatisfiedByTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec = new NotSpecification<Foo>(new IsBarLessThanTenSpecification());

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }
    }
}
