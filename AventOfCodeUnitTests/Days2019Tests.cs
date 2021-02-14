﻿using AventOfCode._2019;
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

        [Theory]
        [InlineData(true, true, 3500)]
        [InlineData(true, false, 3101878)]
        [InlineData(false, false, 8444)]
        public void Day02Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day02();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, 6)]
        [InlineData(true, false, 2129)]
        [InlineData(false, true, 30)]
        [InlineData(false, false, 134662)]
        public void Day03Test(bool firstPart, bool sample, long expected)
        {
            var day = new Day03();

            var result = firstPart
                ? day.GetFirstPartResult(sample)
                : day.GetSecondPartResult(sample);

            Assert.Equal(expected, result);
        }
    }
}
