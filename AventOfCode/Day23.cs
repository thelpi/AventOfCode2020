using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 23: Crab Cups
    /// </summary>
    public sealed class Day23 : Day
    {
        private const int PART_2_ELEMENTS_COUNT = 1000000;
        private const int PART_1_LOOP = 100;
        private const int PART_2_LOOP = 10000000;

        public Day23() : base(23) { }

        public override long GetFirstPartResult(bool sample)
        {
            var content = GetContent(v => Convert.ToInt32(v), sample: sample);

            var cupsArray = content.ToList();

            var indexOfOne = LoopValues(ref cupsArray, PART_1_LOOP);

            var values = new List<char>();
            for (int k = indexOfOne + 1; k < cupsArray.Count; k++)
            {
                values.Add(cupsArray[k].ToString().First());
            }
            for (int k = 0; k < indexOfOne; k++)
            {
                values.Add(cupsArray[k].ToString().First());
            }

            return Convert.ToInt64(new string(values.ToArray()));
        }

        public override long GetSecondPartResult(bool sample)
        {
            var content = GetContent(v => Convert.ToInt32(v), sample: sample);

            var max = content.Max() + 1;
            for (int i = max; i <= PART_2_ELEMENTS_COUNT; i++)
            {
                content.Add(i);
            }

            var cupsArray = content.ToList();

            var indexOfOne = LoopValues(ref cupsArray, PART_2_LOOP);

            var i1 = indexOfOne + 1;
            var i2 = indexOfOne + 2;
            if (indexOfOne == cupsArray.Count - 2)
            {
                i2 = 0;
            }
            else if (indexOfOne == cupsArray.Count - 1)
            {
                i1 = 0;
                i2 = 1;
            }

            return cupsArray[i1] * (long)cupsArray[i2];
        }

        private int LoopValues(ref List<int> cupsArray, int loop)
        {
            var originalLength = cupsArray.Count;
            var removed = new int[3];
            
            var maxi1 = cupsArray.Max();
            var maxi2 = cupsArray.Where(k => k != maxi1).Max();
            var maxi3 = cupsArray.Where(k => k != maxi1 && k != maxi2).Max();
            var maxi4 = cupsArray.Where(k => k != maxi1 && k != maxi2 && k != maxi3).Max();
            var maxs = new[] { maxi1, maxi2, maxi3, maxi4 };

            var i1 = originalLength - 1;
            var i2 = originalLength - 2;
            var i3 = originalLength - 3;

            int currentI = 0;

            for (int i = 0; i < loop; i++)
            {
                var currentCup = cupsArray[currentI];
                var minusOne = currentCup - 1;

                removed[2] = cupsArray[currentI == i1 ? 2 : (currentI == i2 ? 1 : (currentI == i3 ? 0 : currentI + 3))];
                removed[1] = cupsArray[currentI == i1 ? 1 : (currentI == i2 ? 0 : currentI + 2)];
                removed[0] = cupsArray[currentI == i1 ? 0 : currentI + 1];

                if (currentI == i1)
                {
                    cupsArray.RemoveAt(0);
                    cupsArray.RemoveAt(0);
                    cupsArray.RemoveAt(0);
                }
                else
                {
                    cupsArray.RemoveAt(currentI + 1);
                    if (currentI == i2)
                    {
                        cupsArray.RemoveAt(0);
                        cupsArray.RemoveAt(0);
                    }
                    else
                    {
                        cupsArray.RemoveAt(currentI + 1);
                        if (currentI == i3)
                        {
                            cupsArray.RemoveAt(0);
                        }
                        else
                        {
                            cupsArray.RemoveAt(currentI + 1);
                        }
                    }
                }

                bool contains = true;
                while (contains)
                {
                    bool localContains = false;
                    int m = 0;
                    while (m < 3 && !localContains)
                    {
                        if (removed[m] == minusOne)
                        {
                            localContains = true;
                            minusOne--;
                        }
                        m++;
                    }
                    if (!localContains)
                    {
                        contains = false;
                    }
                }

                if (minusOne == 0)
                {
                    var localMax = 0;

                    bool containsMax = true;
                    while (containsMax)
                    {
                        bool localContainsMax = false;
                        int m = 0;
                        while (m < 3 && !localContainsMax)
                        {
                            if (removed[m] == maxs[localMax])
                            {
                                localContainsMax = true;
                                localMax++;
                            }
                            m++;
                        }
                        if (!localContainsMax)
                        {
                            containsMax = false;
                        }
                    }

                    minusOne = maxs[localMax];
                }

                int indexOfMinus = cupsArray.IndexOf(minusOne);

                if (indexOfMinus == i1)
                {
                    cupsArray.Insert(0, removed[2]);
                    cupsArray.Insert(0, removed[1]);
                    cupsArray.Insert(0, removed[0]);
                }
                else
                {
                    cupsArray.Insert(indexOfMinus + 1, removed[2]);
                    cupsArray.Insert(indexOfMinus + 1, removed[1]);
                    cupsArray.Insert(indexOfMinus + 1, removed[0]);
                }

                currentI = cupsArray.IndexOf(currentCup);
                if (currentI == i1)
                {
                    currentI = -1;
                }
                currentI++;
            }

            return cupsArray.IndexOf(1);
        }

        private bool Contains(int[] values, int value)
        {
            for (int k = 0; k < values.Length; k++)
            {
                if (values[k] == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
