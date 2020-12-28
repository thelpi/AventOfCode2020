using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var byGroupByPeople = GetContent(v => v.Split("\r\n").ToList(), "\r\n\r\n", sample: sample);

            var yesCount = 0;

            foreach (var group in byGroupByPeople)
            {
                var datasGroup = group.SelectMany(g => g).ToList();

                var result = datasGroup
                    .GroupBy(k => k)
                    .Where(k => k.Count() > 0);

                yesCount += result.Count();
            }

            return yesCount;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var byGroupByPeople = GetContent(v => v.Split("\r\n").ToList(), "\r\n\r\n", sample: sample);

            var yesCount = 0;

            foreach (var group in byGroupByPeople)
            {
                var datasGroup = group.SelectMany(g => g).ToList();

                var result = datasGroup
                    .GroupBy(k => k)
                    .Where(k => k.Count() == group.Count);

                yesCount += result.Count();
            }

            return yesCount;
        }
    }
}
