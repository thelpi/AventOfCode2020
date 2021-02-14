using System;
using System.Collections.Generic;

namespace AventOfCode._2019
{
    /// <summary>
    /// Day 2: 1202 Program Alarm
    /// </summary>
    public sealed class Day02 : DayBase
    {
        private const int STOP_AT = 99;
        private const int EXPECTED_OUTPUT = 19690720;

        public Day02() : base(2019, 2) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetContent(v => Convert.ToInt32(v), separator: ",", sample: sample);

            if (!sample)
            {
                values[1] = 12;
                values[2] = 2;
            }

            return LoopAndGetOutput(values);
        }

        public override long GetSecondPartResult(bool sample)
        {
            var values = GetContent(v => Convert.ToInt32(v), separator: ",", sample: sample);

            var noun = -1;
            var verb = -1;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var copyValues = new List<int>(values)
                    {
                        [1] = i,
                        [2] = j
                    };
                    var output = LoopAndGetOutput(copyValues);
                    if (output == EXPECTED_OUTPUT)
                    {
                        noun = i;
                        verb = j;
                        goto endloop;
                    }
                }
            }
            endloop:
            return 100 * noun + verb;
        }

        private static long LoopAndGetOutput(List<int> values)
        {
            var i = 0;
            var stop = false;
            do
            {
                var start = values[i];
                var n1 = values[i + 1];
                var n2 = values[i + 2];
                var end = values[i + 3];

                if (start == 1)
                {
                    values[end] = values[n1] + values[n2];
                }
                else if (start == 2)
                {
                    values[end] = values[n1] * values[n2];
                }
                else if (start == STOP_AT)
                {
                    stop = true;
                }
                i += 4;
            }
            while (!stop);

            return values[0];
        }
    }
}
