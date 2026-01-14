using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void GetFibonacciSeries_Count5_ReturnsCorrectSeries()
        {
            // Arrange
            var expected = new List<int> { 0, 1, 1, 2, 3 };

            // Act
            var result = Program.GetFibonacciSeries(5);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetFibonacciSeries_Count0_ReturnsEmptyList()
        {
            // Act
            var result = Program.GetFibonacciSeries(0);

            // Assert
            Assert.Empty(result);
        }
    }
}