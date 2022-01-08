using System;

namespace AventOfCode._2021
{
    public sealed class Day01 : DayBase
    {
        public Day01() : base(2021, 1) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetContent(v => Convert.ToInt32(v), sample: sample);

            long sum = 0;
            for (var i = 1; i < values.Count; i++)
            {
                if (values[i] > values[i - 1])
                    sum++;
            }

            return sum;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var values = GetContent(v => Convert.ToInt32(v), sample: sample);

            long sum = 0;
            for (var i = 3; i < values.Count; i++)
            {
                var oldV = values[i - 1] + values[i - 2] + values[i - 3];
                var newV = values[i] + values[i - 1] + values[i - 2];

                if (newV > oldV)
                    sum++;
            }

            return sum;
        }
    }
}
