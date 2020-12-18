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
        [InlineData(true, true, 165)]
        [InlineData(true, false, 12408060320841)]
        [InlineData(false, true, 208)]
        [InlineData(false, false, 4466434626828)]
        public void Day14Test(bool firstPart, bool sample, long expected)
        {
            var result = Days.Day14(firstPart, sample);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 436)]
        [InlineData(true, false, 763)]
        [InlineData(false, true, 175594)]
        [InlineData(false, false, 1876406)]
        public void Day15Test(bool firstPart, bool sample, long expected)
        {
            var result = Days.Day15(firstPart, sample);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 71)]
        [InlineData(true, false, 24021)]
        [InlineData(false, true, 14)]
        [InlineData(false, false, 1289178686687)]
        public void Day16Test(bool firstPart, bool sample, long expected)
        {
            var result = Days.Day16(firstPart, sample);
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

        [Theory]
        [InlineData(true, true, 51)]
        [InlineData(true, false, 45283905029161)]
        [InlineData(false, true, 23340)]
        [InlineData(false, false, 216975281211165)]
        public void Day18Test(bool firstPart, bool sample, long expected)
        {
            var result = Days.Day18(firstPart, sample);
            Assert.Equal(expected, result);
        }
    }
}
