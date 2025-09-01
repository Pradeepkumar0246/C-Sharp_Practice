using Calcu;
namespace nunit_test
{
    public class Tests
    {
        [Test]
        public void Multiply_ReturnsProduct()
        {
            var calc = new Calculator();
            var result = calc.Multiply(4, 5);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Divide_ByZero_Throws()
        {
            var calc = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
        }

        [TestCase(2, 10, 5)]
        [TestCase(-3, -9, 3)]
        public void Divide_ReturnsQuotient(int expected, int a, int b)
        {
            var calc = new Calculator();
            var result = calc.Divide(a, b);
            Assert.AreEqual(expected, result);
        }
    }
}