using AventOfCode;
using Xunit;

namespace AventOfCodeUnitTests
{
    public class DaysTests
    {
        [Theory]
        [InlineData(true, true, 514579)]
        [InlineData(true, false, 1020036)]
        [InlineData(false, true, 241861950)]
        [InlineData(false, false, 286977330)]
        public void Day01Test(bool firstPart, bool sample, long expected)
        {
            var result = Days.Day01(firstPart, sample);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 112)]
        [InlineData(true, false, 284)]
        [InlineData(false, true, 848)]
        [InlineData(false, false, 2240)]
        public void Day17Test(bool firstPart, bool sample, long expected)
        {
            var result = Days.Day17(firstPart, sample);
            Assert.Equal(expected, result);
        }
    }
}
