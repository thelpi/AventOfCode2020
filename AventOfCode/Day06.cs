using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 6: Custom Customs
    /// </summary>
    public sealed class Day06 : DayBase
    {
        public Day06() : base(6) { }

        public override long GetFirstPartResult(bool sample)
        {
            return InternalCount(sample, (count, group) => count > 0);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return InternalCount(sample, (count, group) => count == group.Count);
        }

        private long InternalCount(bool sample, Func<int, List<string>, bool> matchPredicate)
        {
            var byGroupByPeople = GetContent(v => v.Split("\r\n").ToList(), "\r\n\r\n", sample: sample);

            return byGroupByPeople.Sum(group =>
                group
                    .SelectMany(g => g)
                    .GroupBy(k => k)
                    .Count(k => matchPredicate(k.Count(), group)));
        }
    }
}
