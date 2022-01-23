using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day14 : DayBase
    {
        public Day14() : base(2021, 14) { }

        public override long GetFirstPartResult(bool sample)
        {
            return Search(sample, 10);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return Search(sample, 40);
        }

        private long Search(bool sample, int maxI)
        {
            var values = GetContent(v => v, sample: sample);

            var trans = values.Skip(2).Select(x => x.Split(" -> ")).ToDictionary(x => (x[0][0], x[0][1]), x => x[1][0]);

            var word = values[0];

            var counter = new Dictionary<char, long>();
            for (var x = 0; x < word.Length - 1; x++)
            {
                RecursiveSearch(word[x], word[x + 1], counter, trans, 1, maxI);
            }

            var cLast = word[word.Length - 1];
            if (!counter.ContainsKey(cLast))
                counter.Add(cLast, 1);
            else
                counter[cLast]++;

            var orderedCounter = counter.OrderByDescending(_ => _.Value);

            return orderedCounter.First().Value - orderedCounter.Last().Value;
        }

        private void RecursiveSearch(char c1, char c2,
            Dictionary<char, long> counter,
            Dictionary<(char, char), char> substitutions,
            int i, int maxI)
        {
            var sub = substitutions[(c1, c2)];
            if (i == maxI)
            {
                if (!counter.ContainsKey(c1))
                    counter.Add(c1, 1);
                else
                    counter[c1]++;

                if (!counter.ContainsKey(sub))
                    counter.Add(sub, 1);
                else
                    counter[sub]++;
            }
            else
            {
                RecursiveSearch(c1, sub, counter, substitutions, i + 1, maxI);
                RecursiveSearch(sub, c2, counter, substitutions, i + 1, maxI);
            }
        }
    }
}
