using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            // Arrange
            int n = 5;
            int expected = 120;

            // Act
            int result = Algorithms.GetFactorial(n);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanFormatSeparators()
        {
            // Arrange
            string[] input = { "a", "b", "c" };
            string expected = "a, b and c";

            // Act
            string result = Algorithms.FormatSeparators(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}