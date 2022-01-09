using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day06 : DayBase
    {
        private const int Days1 = 80;
        private const int Days2 = 256;

        public Day06() : base(2021, 6) { }

        public override long GetFirstPartResult(bool sample)
        {
            return BaseMethod(Days1, sample);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return BaseMethod(Days2, sample);
        }

        private long BaseMethod(int days, bool sample)
        {
            var fishes = GetContent(x => x.Split(',').Select(_ => Convert.ToInt32(_)).ToList(), sample: sample).First();

            var groupOfFishes = fishes
                .GroupBy(x => x)
                .Select(x => new KeyValuePair<int, long>(x.Key, x.Count()))
                .ToDictionary(x => x.Key, x => x.Value);
            
            for (var i = 1; i <= days; i++)
            {
                var groupOfFishesCopy = new Dictionary<int, long>();
                long toAdd = 0;
                foreach (var g in groupOfFishes)
                {
                    if (g.Key > 0)
                        groupOfFishesCopy.Add(g.Key - 1, g.Value);
                    else
                    {
                        toAdd += g.Value;
                    }
                }
                groupOfFishes = groupOfFishesCopy;
                if (!groupOfFishes.ContainsKey(8))
                    groupOfFishes.Add(8, 0);
                if (!groupOfFishes.ContainsKey(6))
                    groupOfFishes.Add(6, 0);
                groupOfFishes[8] += toAdd;
                groupOfFishes[6] += toAdd;
            }

            return groupOfFishes.Sum(x => x.Value);
        }
    }
}
