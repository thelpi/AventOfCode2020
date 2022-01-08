using AventOfCode._2021;
using Xunit;

namespace AventOfCodeUnitTests
{
    public class Days2021Tests
    {
        [Theory]
        [InlineData(true, true, 7)]
        [InlineData(true, false, 1233)]
        [InlineData(false, true, 5)]
        [InlineData(false, false, 1275)]
        public void Day01Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day01();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }
    }
}
