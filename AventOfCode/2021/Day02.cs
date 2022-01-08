using System;
using System.Collections.Generic;

namespace AventOfCode._2021
{
    public sealed class Day02 : DayBase
    {
        public Day02() : base(2021, 2) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetValues(sample);

            long depth = 0;
            long move = 0;
            foreach (var v in values)
            {
                if (v.Item1 == Direction.forward)
                    move += v.Item2;
                else if (v.Item1 == Direction.up)
                    depth -= v.Item2;
                else
                    depth += v.Item2;
            }

            return depth * move;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var values = GetValues(sample);

            long depth = 0;
            long move = 0;
            long aim = 0;
            foreach (var v in values)
            {
                if (v.Item1 == Direction.forward)
                {
                    move += v.Item2;
                    depth += v.Item2 * aim;
                }
                else if (v.Item1 == Direction.up)
                    aim -= v.Item2;
                else
                    aim += v.Item2;
            }

            return depth * move;
        }

        private List<Tuple<Direction, int>> GetValues(bool sample)
        {
            return GetContent(v =>
                new Tuple<Direction, int>(
                    Enum.Parse<Direction>(v.Split(' ')[0]),
                    Convert.ToInt32(v.Split(' ')[1])),
                sample: sample);
        }

        public enum Direction
        {
            forward,
            down,
            up
        }
    }
}
