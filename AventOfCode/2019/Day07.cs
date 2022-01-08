using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2019
{
    /// <summary>
    /// Day 7: Amplification Circuit
    /// </summary>
    public sealed class Day07 : DayBase
    {
        public Day07() : base(2019, 7) { }

        public override long GetFirstPartResult(bool sample)
        {
            var originalValues = GetContent(
                v => Convert.ToInt32(v),
                separator: ",",
                sample: sample);

            var phases = new int[] { 4, 3, 2, 1, 0 };

            var amps = Enumerable
                .Range(0, 5)
                .Select(_ => new List<int>(originalValues))
                .ToList();

            var io = 0;
            for (int i = 0; i < 5; i++)
            {
                Day05.LoopAndGetOutput(amps[i], phases[i]);
                io = Day05.LoopAndGetOutput(amps[i], io);
            }

            return io;
        }

        public override long GetSecondPartResult(bool sample)
        {
            throw new Exception();
        }
    }
}
