using Calcu;

namespace xunit_test
{
    public class xunit
    {
        [Fact]
        public void Add_ReturnsSum()
        {
            var calc = new Calculator();
            var result = calc.Add(2, 3);
            Assert.Equal(5, result);
        }
        [Theory]
        [InlineData(-5, -2, 3)]
        [InlineData(0, 2, 2)]
        public void Subtract_ReturnsExpected(int expected, int a, int b)
        {
            var calc = new Calculator();
            var result = calc.Subtract(a, b);
            Assert.Equal(expected, result);
        }
    }
}