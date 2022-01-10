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

        [Theory]
        [InlineData(true, true, 150)]
        [InlineData(true, false, 2120749)]
        [InlineData(false, true, 900)]
        [InlineData(false, false, 2138382217)]
        public void Day02Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day02();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 198)]
        [InlineData(true, false, 2250414)]
        [InlineData(false, true, 230)]
        [InlineData(false, false, 6085575)]
        public void Day03Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day03();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 4512)]
        [InlineData(true, false, 33348)]
        [InlineData(false, true, 1924)]
        [InlineData(false, false, 8112)]
        public void Day04Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day04();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 5)]
        [InlineData(true, false, 5373)]
        [InlineData(false, true, 12)]
        [InlineData(false, false, 21514)]
        public void Day05Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day05();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 5934)]
        [InlineData(true, false, 345387)]
        [InlineData(false, true, 26984457539)]
        [InlineData(false, false, 1574445493136)]
        public void Day06Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day06();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 37)]
        [InlineData(true, false, 336131)]
        [InlineData(false, true, 168)]
        [InlineData(false, false, 92676646)]
        public void Day07Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day07();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }
    }
}
