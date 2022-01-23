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
            return Search(sample, 10, 5);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return Search(sample, 40, 20);
        }

        private long Search(bool sample, int maxI, int breakPoint)
        {
            var values = GetContent(v => v, sample: sample);

            var trans = values.Skip(2).Select(x => x.Split(" -> ")).ToDictionary(x => (x[0][0], x[0][1]), x => x[1][0]);

            var word = values[0];

            var subCounter = new Dictionary<(char, char), Dictionary<char, long>>();
            var counter = new Dictionary<char, long>();
            for (var x = 0; x < word.Length - 1; x++)
            {
                RecursiveSearch(word[x], word[x + 1], counter, subCounter, trans, 1, maxI, breakPoint);
            }

            var cLast = word[word.Length - 1];
            if (!counter.ContainsKey(cLast))
                counter.Add(cLast, 1);
            else
                counter[cLast]++;

            var orderedCounter = counter.OrderByDescending(_ => _.Value);

            return orderedCounter.First().Value - orderedCounter.Last().Value;
        }

        private Dictionary<char, long> RecursiveSearch(char c1, char c2,
            Dictionary<char, long> counter,
            Dictionary<(char, char), Dictionary<char, long>> subCounter,
            Dictionary<(char, char), char> substitutions,
            int i, int maxI, int breakPoint)
        {
            var localCounter = new Dictionary<char, long>();

            var isBreakPoint = i == breakPoint;

            var sub = substitutions[(c1, c2)];
            if (i == maxI)
            {
                AddOrUpd(c1, counter);
                AddOrUpd(sub, counter);
                AddOrUpd(c1, localCounter);
                AddOrUpd(sub, localCounter);
            }
            else if (isBreakPoint && subCounter.ContainsKey((c1, c2)))
            {
                foreach (var kvp in subCounter[(c1, c2)])
                {
                    AddOrUpd(kvp.Key, counter, kvp.Value);
                }
            }
            else
            {
                var subLocalCounter1 = RecursiveSearch(c1, sub, counter, subCounter, substitutions, i + 1, maxI, breakPoint);
                var subLocalCounter2 = RecursiveSearch(sub, c2, counter, subCounter, substitutions, i + 1, maxI, breakPoint);

                foreach (var kvp in subLocalCounter1)
                    AddOrUpd(kvp.Key, localCounter, kvp.Value);
                foreach (var kvp in subLocalCounter2)
                    AddOrUpd(kvp.Key, localCounter, kvp.Value);

                if (isBreakPoint)
                    subCounter.Add((c1, c2), localCounter);
            }

            return localCounter;
        }

        private static void AddOrUpd(char c1, Dictionary<char, long> counter, long x = 1)
        {
            if (!counter.ContainsKey(c1))
                counter.Add(c1, x);
            else
                counter[c1] += x;
        }
    }
}
