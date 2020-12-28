using System;
using System.Collections.Generic;
using System.Linq;
using LpiLib;

namespace AventOfCode
{
    /// <summary>
    /// Day 10: Adapter Array
    /// </summary>
    public sealed class Day10 : DayBase
    {
        public Day10() : base(10) { }

        public override long GetFirstPartResult(bool sample)
        {
            var adapters = GetSortedAdapters(sample);

            var countByJoltsDelta = new Dictionary<int, int>
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 }
            };

            var foundVoltageAbove = true;
            var voltage = 0;
            while (foundVoltageAbove)
            {
                var matches = adapters
                    .Where(x => x > voltage && x <= voltage + 3);
                foundVoltageAbove = matches.Any();
                if (foundVoltageAbove)
                {
                    var nextVoltage = matches.Min();
                    countByJoltsDelta[nextVoltage - voltage]++;
                    voltage = nextVoltage;
                }
            }
            countByJoltsDelta[3]++;

            return countByJoltsDelta[1] * countByJoltsDelta[3];
        }

        public override long GetSecondPartResult(bool sample)
        {
            var adapters = GetSortedAdapters(sample);
            adapters.Add(adapters.Last() + 3);

            // each time there's a 3 jolts gap between adapters
            // a new subgroup is created
            var adaptersSubgroups = new List<List<int>>();
            var currentAdaptersSubGroup = new List<int>();
            var currentAdapter = 0;
            foreach (var adapter in adapters)
            {
                if (adapter - currentAdapter == 3)
                {
                    adaptersSubgroups.Add(new List<int>(currentAdaptersSubGroup));
                    currentAdaptersSubGroup = new List<int>();
                }
                currentAdaptersSubGroup.Add(adapter);
                currentAdapter = adapter;
            }

            var results = new List<int>();
            
            foreach (var adaptersSubgroup in adaptersSubgroups)
            {
                // generates every combination for the current subgroup of adapters
                var adaptersCombinations = new List<List<int>>();
                for (int i = 1; i <= adaptersSubgroup.Count; i++)
                {
                    adaptersCombinations.AddRange(Stat.Combination(adaptersSubgroup, i));
                }

                var combinationsCount = 0;
                foreach (var adaptersCombination in adaptersCombinations)
                {
                    // a combination is valid if:
                    // - contains the lowest element
                    // - contains the highest element
                    // - has no gap above 3 jolts
                    bool validCombination = false;
                    if (adaptersCombination.Contains(adaptersSubgroup[0])
                        && adaptersCombination.Contains(adaptersSubgroup.Last()))
                    {
                        validCombination = true;
                        int i = 1;
                        while (i < adaptersCombination.Count && validCombination)
                        {
                            if (adaptersCombination[i] - adaptersCombination[i - 1] > 3)
                            {
                                validCombination = false;
                            }
                            i++;
                        }
                    }
                    
                    if (validCombination)
                    {
                        combinationsCount++;
                    }
                }

                results.Add(combinationsCount);
            }

            return results.Aggregate((long)1, (x, v) => x *= v);
        }

        private List<int> GetSortedAdapters(bool sample)
        {
            var datas = GetContent(v => Convert.ToInt32(v), sample: sample);
            datas.Add(0);
            datas.Sort();
            return datas;
        }
    }
}
