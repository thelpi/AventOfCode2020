using System;

namespace AventOfCode._2019
{
    /// <summary>
    /// Day 1: The Tyranny of the Rocket Equation
    /// </summary>
    public sealed class Day01 : DayBase
    {
        public Day01() : base(2019, 1) { }

        public override long GetFirstPartResult(bool sample)
        {
            return CommonTrunk(sample, 1);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CommonTrunk(sample, 2);
        }

        private long CommonTrunk(bool sample, int part)
        {
            var values = GetContent(
                v => Convert.ToInt32(v),
                sample: sample,
                part: sample ? part : default(int?));

            long massSum = 0;
            int i = 0;
            while (i < values.Count)
            {
                var value = values[i];
                var addSum = Convert.ToInt32(Math.Floor(value / (decimal)3) - 2);
                if (addSum > 0)
                {
                    massSum += addSum;
                    if (part == 2)
                    {
                        values.Add(addSum);
                    }
                }
                i++;
            }

            return massSum;
        }
    }
}
