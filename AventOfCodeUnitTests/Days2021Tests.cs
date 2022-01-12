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

        [Theory]
        [InlineData(true, true, 26)]
        [InlineData(true, false, 479)]
        [InlineData(false, true, 61229)]
        [InlineData(false, false, 1041746)]
        public void Day08Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day08();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 15)]
        [InlineData(true, false, 550)]
        [InlineData(false, true, 1134)]
        [InlineData(false, false, 1100682)]
        public void Day09Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day09();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 26397)]
        [InlineData(true, false, 168417)]
        [InlineData(false, true, 288957)]
        [InlineData(false, false, 2802519786)]
        public void Day10Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day10();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 1656)]
        [InlineData(true, false, 1673)]
        [InlineData(false, true, 195)]
        [InlineData(false, false, 279)]
        public void Day11Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day11();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 19)]
        [InlineData(true, false, 4885)]
        [InlineData(false, true, 103)]
        [InlineData(false, false, 117095)]
        public void Day12Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day12();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 17, null)]
        [InlineData(true, false, 790, null)]
        [InlineData(false, true, 0, "1\t1\t1\t1\t1\t\r\n1\t0\t0\t0\t1\t\r\n1\t0\t0\t0\t1\t\r\n1\t0\t0\t0\t1\t\r\n1\t1\t1\t1\t1\t\r\n")]
        [InlineData(false, false, 0, "1\t1\t1\t1\t1\t1\t\r\n1\t0\t0\t1\t0\t0\t\r\n1\t0\t0\t1\t0\t0\t\r\n0\t1\t1\t0\t0\t0\t\r\n0\t0\t0\t0\t0\t0\t\r\n0\t1\t1\t1\t1\t0\t\r\n1\t0\t0\t0\t0\t1\t\r\n1\t0\t0\t1\t0\t1\t\r\n0\t1\t0\t1\t1\t1\t\r\n0\t0\t0\t0\t0\t0\t\r\n1\t1\t1\t1\t1\t1\t\r\n0\t0\t1\t0\t0\t0\t\r\n0\t0\t1\t0\t0\t0\t\r\n1\t1\t1\t1\t1\t1\t\r\n0\t0\t0\t0\t0\t0\t\r\n1\t0\t0\t0\t1\t1\t\r\n1\t0\t0\t1\t0\t1\t\r\n1\t0\t1\t0\t0\t1\t\r\n1\t1\t0\t0\t0\t1\t\r\n0\t0\t0\t0\t0\t0\t\r\n1\t1\t1\t1\t1\t1\t\r\n1\t0\t1\t0\t0\t1\t\r\n1\t0\t1\t0\t0\t1\t\r\n0\t1\t0\t1\t1\t0\t\r\n0\t0\t0\t0\t0\t0\t\r\n1\t1\t1\t1\t1\t1\t\r\n1\t0\t1\t0\t0\t0\t\r\n1\t0\t1\t0\t0\t0\t\r\n1\t0\t0\t0\t0\t0\t\r\n0\t0\t0\t0\t0\t0\t\r\n0\t0\t0\t0\t1\t0\t\r\n0\t0\t0\t0\t0\t1\t\r\n1\t0\t0\t0\t0\t1\t\r\n1\t1\t1\t1\t1\t0\t\r\n0\t0\t0\t0\t0\t0\t\r\n0\t1\t1\t1\t1\t0\t\r\n1\t0\t0\t0\t0\t1\t\r\n1\t0\t0\t0\t0\t1\t\r\n0\t1\t0\t0\t1\t0\t\r\n")]
        public void Day13Test(bool firstPart, bool sample, long expected, string expectedFinalForm)
        {
            var day = new Day13();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expectedFinalForm, day.FinalForm);
            Assert.Equal(expected, result);
        }
    }
}
