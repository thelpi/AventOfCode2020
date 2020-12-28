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
            var day = new Day01();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 2)]
        [InlineData(true, false, 625)]
        [InlineData(false, true, 1)]
        [InlineData(false, false, 391)]
        public void Day02Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day02();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 7)]
        [InlineData(true, false, 244)]
        [InlineData(false, true, 336)]
        [InlineData(false, false, 9406609920)]
        public void Day03Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day03();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 2)]
        [InlineData(true, false, 260)]
        [InlineData(false, true, 2)]
        [InlineData(false, false, 153)]
        public void Day04Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day04();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        // Part. 2 can't be tested with sample datas
        [Theory]
        [InlineData(true, true, 820)]
        [InlineData(true, false, 908)]
        [InlineData(false, false, 619)]
        public void Day05Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day05();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 11)]
        [InlineData(true, false, 6714)]
        [InlineData(false, true, 6)]
        [InlineData(false, false, 3435)]
        public void Day06Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day06();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 4)]
        [InlineData(true, false, 142)]
        [InlineData(false, true, 32)]
        [InlineData(false, false, 10219)]
        public void Day07Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day07();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 5)]
        [InlineData(true, false, 1553)]
        [InlineData(false, true, 8)]
        [InlineData(false, false, 1877)]
        public void Day08Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day08();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 127)]
        [InlineData(true, false, 23278925)]
        [InlineData(false, true, 62)]
        [InlineData(false, false, 4011064)]
        public void Day09Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day09();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 35)]
        [InlineData(true, false, 2244)]
        [InlineData(false, true, 8)]
        [InlineData(false, false, 3947645370368)]
        public void Day10Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day10();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 37)]
        [InlineData(true, false, 2166)]
        [InlineData(false, true, 26)]
        [InlineData(false, false, 1955)]
        public void Day11Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day11();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 25)]
        [InlineData(true, false, 1319)]
        [InlineData(false, true, 286)]
        [InlineData(false, false, 62434)]
        public void Day12Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day12();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 295)]
        [InlineData(true, false, 410)]
        [InlineData(false, true, 1068781)]
        [InlineData(false, false, 600691418730595)]
        public void Day13Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day13();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 165)]
        [InlineData(true, false, 12408060320841)]
        [InlineData(false, true, 208)]
        [InlineData(false, false, 4466434626828)]
        public void Day14Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day14();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 436)]
        [InlineData(true, false, 763)]
        [InlineData(false, true, 175594)]
        [InlineData(false, false, 1876406)]
        public void Day15Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day15();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 71)]
        [InlineData(true, false, 24021)]
        [InlineData(false, true, 14)]
        [InlineData(false, false, 1289178686687)]
        public void Day16Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day16();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 112)]
        [InlineData(true, false, 284)]
        [InlineData(false, true, 848)]
        [InlineData(false, false, 2240)]
        public void Day17Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day17();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 51)]
        [InlineData(true, false, 45283905029161)]
        [InlineData(false, true, 23340)]
        [InlineData(false, false, 216975281211165)]
        public void Day18Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day18();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 2)]
        [InlineData(true, false, 210)]
        [InlineData(false, true, 12)]
        [InlineData(false, false, 422)]
        public void Day19Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day19();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 20899048083289)]
        [InlineData(true, false, 28057939502729)]
        [InlineData(false, true, 273)]
        [InlineData(false, false, 2489)]
        public void Day20Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day20();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        // Both part. in the same test
        [Theory]
        [InlineData(true, 5, "mxmxvkd,sqjhc,fvjkl")]
        [InlineData(false, 2584, "fqhpsl,zxncg,clzpsl,zbbnj,jkgbvlxh,dzqc,ppj,glzb")]
        public void Day21Test(bool sample, long expectedCount, string expectedCanonical)
        {
            var day = new Day21();

            var result = day.GetSecondPartResult(sample);

            Assert.Equal(expectedCount, result);
            Assert.Equal(expectedCanonical, day.Part2CanonicalResult);
        }

        [Theory]
        [InlineData(true, true, 306)]
        [InlineData(true, false, 33925)]
        [InlineData(false, true, 291)]
        [InlineData(false, false, 33441)]
        public void Day22Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day22();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        // Part. 2 takes 4 hour to complete
        [Theory]
        [InlineData(true, true, 67384529)]
        [InlineData(true, false, 27865934)]
        //[InlineData(false, true, 149245887792)]
        //[InlineData(false, false, 170836011000)]
        public void Day23Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day23();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 10)]
        [InlineData(true, false, 282)]
        [InlineData(false, true, 2208)]
        [InlineData(false, false, 3445)]
        public void Day24Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day24();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        // No "real" part. 2
        [Theory]
        [InlineData(true, 14897079)]
        [InlineData(false, 18862163)]
        public void Day25Test(bool sample, long expected)
        {
            var result = new Day25().GetFirstPartResult(sample);
            Assert.Equal(expected, result);
        }
    }
}
