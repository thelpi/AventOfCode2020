using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2020
{
    /// <summary>
    /// Day 1: Report Repair
    /// </summary>
    public sealed class Day01 : DayBase
    {
        private const int SUM_EXPECT = 2020;

        public Day01() : base(2020, 1) { }

        public override long GetFirstPartResult(bool sample)
        {
            return GetInnerResult(sample, 2);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return GetInnerResult(sample, 3);
        }

        private int GetInnerResult(bool sample, int startIndex)
        {
            var values = GetContent(v => Convert.ToInt32(v), sample: sample);

            foreach (var value in RecursiveLoop(values, 0, startIndex))
            {
                if (value.Sum() == SUM_EXPECT)
                {
                    int multiply = 1;
                    value.ForEach(_ => multiply *= _);
                    return multiply;
                }
            }

            throw new NotImplementedException();
        }

        private IEnumerable<List<int>> RecursiveLoop(List<int> values, int startIndex, int offsetFinish)
        {
            for (int i = startIndex; i < values.Count - offsetFinish; i++)
            {
                if (offsetFinish > 1)
                {
                    foreach (var value in RecursiveLoop(values, i + 1, offsetFinish - 1))
                    {
                        value.Add(values[i]);
                        yield return value;
                    }
                }
                else
                {
                    yield return new List<int> { values[i] };
                }
            }
        }
    }
}
