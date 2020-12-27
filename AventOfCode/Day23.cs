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

            var cupsArray = content.ToArray();

            var indexOfOne = LoopValues(ref cupsArray, PART_1_LOOP);

            var values = new List<char>();
            for (int k = indexOfOne + 1; k < cupsArray.Length; k++)
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

            var cupsArray = content.ToArray();

            var indexOfOne = LoopValues(ref cupsArray, PART_2_LOOP);

            var i1 = indexOfOne + 1;
            var i2 = indexOfOne + 2;
            if (indexOfOne == cupsArray.Length - 2)
            {
                i2 = 0;
            }
            else if (indexOfOne == cupsArray.Length - 1)
            {
                i1 = 0;
                i2 = 1;
            }

            return cupsArray[i1] * (long)cupsArray[i2];
        }

        private int LoopValues(ref int[] cupsArray, int loop)
        {
            var originalLength = cupsArray.Length;
            var minus3Length = originalLength - 3;
            var cupsArrayMinus3 = new int[minus3Length];
            var removed = new int[3];
            var cupsArrayCopy = new int[originalLength];
            
            var maxi1 = cupsArray.Max();
            var maxi2 = cupsArray.Where(k => k != maxi1).Max();
            var maxi3 = cupsArray.Where(k => k != maxi1 && k != maxi2).Max();
            var maxi4 = cupsArray.Where(k => k != maxi1 && k != maxi2 && k != maxi3).Max();
            var maxs = new[] { maxi1, maxi2, maxi3, maxi4 };

            for (int i = 0; i < loop; i++)
            {
                var currentCup = cupsArray[0];
                var minusOne = currentCup - 1;

                removed[2] = cupsArray[3];
                removed[1] = cupsArray[2];
                removed[0] = cupsArray[1];

                cupsArrayMinus3[0] = cupsArray[0];
                int u = 1;
                for (int p = 4; p < originalLength; p++)
                {
                    cupsArrayMinus3[u] = cupsArray[p];
                    u++;
                }
                cupsArray = cupsArrayMinus3;

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

                int indexOfMinus = -1;
                int kk = 0;
                while (indexOfMinus == -1)
                {
                    if (cupsArray[kk] == minusOne)
                    {
                        indexOfMinus = kk;
                    }
                    kk++;
                }

                int ic = 0;
                for (int k = 0; k < originalLength; k++)
                {
                    if (k >= indexOfMinus && k < indexOfMinus + 3)
                    {
                        cupsArrayCopy[indexOfMinus + ic] = removed[ic];
                        ic++;
                    }
                    else
                    {
                        cupsArrayCopy[k] = k == originalLength - 1
                            ? currentCup
                            : cupsArray[k - ic + 1];
                    }
                }

                cupsArray = cupsArrayCopy;
            }

            return Array.IndexOf(cupsArray, 1);
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
