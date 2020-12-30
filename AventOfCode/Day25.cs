using System;

namespace AventOfCode
{
    /// <summary>
    /// Day 25: Combo Breaker
    /// </summary>
    public sealed class Day25 : DayBase
    {
        private const long DEFAULT_SUBJECT = 7;
        private const long MODULO = 20201227;

        public Day25() : base(25) { }

        public override long GetFirstPartResult(bool sample)
        {
            var content = GetContent(v => Convert.ToInt64(v), sample: sample);

            return ApplyLoop(FindLoop(content[0]), content[1]);
        }

        public override long GetSecondPartResult(bool sample)
        {
            throw new NotImplementedException("No part. two for day 25.");
        }

        private long ComputeValue(long subject, long value)
        {
            return (subject * value) % MODULO;
        }

        private long FindLoop(long publicKey)
        {
            long value = 1;
            long loopSize = 0;

            while (value != publicKey)
            {
                value = ComputeValue(DEFAULT_SUBJECT, value);
                loopSize++;
            }

            return loopSize;
        }

        private long ApplyLoop(long loopSizeExpected, long subject)
        {
            long value = 1;
            long loopSize = 0;

            while (loopSize < loopSizeExpected)
            {
                value = ComputeValue(subject, value);
                loopSize++;
            }

            return value;
        }
    }
}
