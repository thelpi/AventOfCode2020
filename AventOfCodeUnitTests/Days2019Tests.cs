using AventOfCode._2019;
using Xunit;

namespace AventOfCodeUnitTests
{
    public class Days2019Tests
    {
        [Theory]
        [InlineData(true, true, 34241)]
        [InlineData(true, false, 3474920)]
        [InlineData(false, true, 50346)]
        [InlineData(false, false, 5209504)]
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
