using System;
using System.Collections.Generic;
using System.Linq;

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
            var datas = GetContent(v => Convert.ToInt32(v), sample: sample);

            datas.Add(0);

            datas.Sort();

            int voltage = 0;
            bool found = true;
            var spreadCount = new Dictionary<int, int>
                {
                    { 1, 0 },
                    { 2, 0 },
                    { 3, 0 }
                };
            while (found)
            {
                var matches = datas.Where(x => x > voltage && x <= voltage + 3).ToList();
                if (matches.Count > 0)
                {
                    var nextVoltage = matches.Min();
                    spreadCount[nextVoltage - voltage]++;
                    voltage = nextVoltage;
                }
                found = matches.Count > 0;
            }
            spreadCount[3]++;

            var total = spreadCount[1] * spreadCount[3];

            return total;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var datas = GetContent(v => Convert.ToInt32(v), sample: sample);

            datas.Add(0);
            datas.Add(datas.Max() + 3);

            datas.Sort();

            List<List<int>> splitBy3 = new List<List<int>>();
            var subList = new List<int>();
            int current = 0;
            foreach (var d in datas)
            {
                if (d - current == 3)
                {
                    splitBy3.Add(new List<int>(subList));
                    subList = new List<int>();
                }
                subList.Add(d);
                current = d;
            }

            void Calculate(List<int> baseList, List<List<int>> listToAdd, List<int> currentIteration, int currentIndex, int currentCount, int countofSubGroup)
            {
                if (currentCount == countofSubGroup)
                {
                    listToAdd.Add(new List<int>(currentIteration));
                    return;
                }

                if (currentIndex >= baseList.Count)
                    return;

                currentIteration.Add(baseList[currentIndex]);
                Calculate(baseList, listToAdd, currentIteration, currentIndex + 1, currentCount + 1, countofSubGroup);
                currentIteration.Remove(baseList[currentIndex]);


                Calculate(baseList, listToAdd, currentIteration, currentIndex + 1, currentCount, countofSubGroup);

            }

            Dictionary<List<int>, int> combosCount = splitBy3.ToDictionary(v => v, v => 0);
            var keys = combosCount.Keys.ToList();

            foreach (var combo in keys)
            {
                var subgroups = new List<List<int>>();
                for (int i = 1; i <= combo.Count; i++)
                {
                    Calculate(combo, subgroups, new List<int>(), 0, 0, i);
                }

                var count = 0;
                foreach (var subgroup in subgroups)
                {
                    if (!subgroup.Contains(combo[0]) || !subgroup.Contains(combo.Last()))
                    {
                        continue;
                    }

                    bool breakNotGood = false;
                    for (int i = 1; i < subgroup.Count; i++)
                    {
                        if (subgroup[i] - subgroup[i - 1] > 3)
                        {
                            breakNotGood = true;
                            break;
                        }
                    }
                    if (!breakNotGood)
                    {
                        count++;
                    }
                }

                combosCount[combo] = count;
            }

            long total2 = 1;
            foreach (var combo in combosCount.Keys)
            {
                total2 = total2 * combosCount[combo];
            }

            return total2;
        }
    }
}
