using Xunit;

namespace Specifications.Tests
{
    public class SpecificationTests
    {
        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        [InlineData(11, false)]
        public void AndTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec1 = new IsBarGreaterThanZeroSpecification();
            var spec2 = new IsBarLessThanTenSpecification();

            var spec = spec1.And(spec2);

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        [InlineData(11, false)]
        public void AndOperatorTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec1 = new IsBarGreaterThanZeroSpecification();
            var spec2 = new IsBarLessThanTenSpecification();

            var spec = spec1 & spec2;

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        [InlineData(11, false)]
        public void AndAlsoTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec1 = new IsBarGreaterThanZeroSpecification();
            var spec2 = new IsBarLessThanTenSpecification();

            var spec = spec1.AndAlso(spec2);

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }

        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, true)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        [InlineData(11, false)]
        public void OrTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec1 = new IsBarLessThanZeroSpecification();
            var spec2 = new IsBarLessThanTenSpecification();

            var spec = spec1.Or(spec2);

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }

        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, true)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        [InlineData(11, false)]
        public void OrOperatorTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec1 = new IsBarLessThanZeroSpecification();
            var spec2 = new IsBarLessThanTenSpecification();

            var spec = spec1 | spec2;

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }

        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, true)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        [InlineData(11, false)]
        public void OrElseTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec1 = new IsBarLessThanZeroSpecification();
            var spec2 = new IsBarLessThanTenSpecification();

            var spec = spec1.OrElse(spec2);

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }

        [Theory]
        [InlineData(9, false)]
        [InlineData(10, true)]
        [InlineData(11, true)]
        public void NotTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec = new IsBarLessThanTenSpecification().Not();

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }


        [Theory]
        [InlineData(9, false)]
        [InlineData(10, true)]
        [InlineData(11, true)]
        public void NotOperatorTests(int bar, bool expected)
        {
            var foo = new Foo { Bar = bar };
            var spec = !(new IsBarLessThanTenSpecification());

            Assert.Equal(expected, spec.IsSatisfiedBy(foo));
        }
    }
}
