using System;
using System.Collections.Generic;

namespace AventOfCode._2019
{
    /// <summary>
    /// Day 5: Sunny with a Chance of Asteroids
    /// </summary>
    public sealed class Day05 : DayBase
    {
        private const int STOP_AT = 99;

        public Day05() : base(2019, 5) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetContent(v => Convert.ToInt32(v), separator: ",", sample: sample);

            return LoopAndGetOutput(values, 1);
        }

        public override long GetSecondPartResult(bool sample)
        {
            throw new Exception();
        }

        private static long LoopAndGetOutput(List<int> values, int input)
        {
            var i = 0;
            var stop = false;
            do
            {
                var actualValue = values[i];

                if (actualValue == STOP_AT)
                {
                    stop = true;
                }
                else
                {
                    var start = actualValue.ToString().PadLeft(5, '0');
                    var opcode = Convert.ToInt32(start.Substring(3, 2));
                    var immediate1 = Convert.ToInt32(start.Substring(2, 1)) == 1;
                    var immediate2 = Convert.ToInt32(start.Substring(1, 1)) == 1;
                    var immediate3 = Convert.ToInt32(start.Substring(0, 1)) == 1;

                    var v1 = immediate1 ? i + 1 : values[i + 1];
                    var v2 = immediate2 ? i + 2 : values[i + 2];
                    var v3 = immediate3 ? i + 3 : values[i + 3];

                    switch (opcode)
                    {
                        case 1:
                            values[v3] = values[v1] + values[v2];
                            i += 4;
                            break;
                        case 2:
                            values[v3] = values[v1] * values[v2];
                            i += 4;
                            break;
                        case 3:
                            values[v1] = input;
                            i += 2;
                            break;
                        case 4:
                            input = values[v1];
                            i += 2;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            }
            while (!stop);

            return input;
        }
    }
}
