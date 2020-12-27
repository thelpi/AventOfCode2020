﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
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
            var cupsArrayMinus3 = new int[cupsArray.Length - 3];
            var originalLength = cupsArray.Length;
            var removed = new int[3];
            var cupsArrayCopy = new int[originalLength];

            for (int i = 0; i < loop; i++)
            {
                var currentCup = cupsArray[0];

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

                var minusOne = currentCup - 1;
                while (Contains(removed, minusOne))
                {
                    minusOne -= 1;
                }
                if (!Contains(cupsArray, minusOne))
                {
                    minusOne = cupsArray.Max();
                }

                var indexofminus = Array.IndexOf(cupsArray, minusOne);

                for (int k = 0; k <= indexofminus; k++)
                {
                    cupsArrayCopy[k] = cupsArray[k];
                }
                cupsArrayCopy[0 + indexofminus + 1] = removed[0];
                cupsArrayCopy[1 + indexofminus + 1] = removed[1];
                cupsArrayCopy[2 + indexofminus + 1] = removed[2];
                for (int k = indexofminus + 1; k < cupsArray.Length; k++)
                {
                    cupsArrayCopy[k + 3] = cupsArray[k];
                }
                cupsArray = cupsArrayCopy;

                for (int k = 0; k < originalLength; k++)
                {
                    cupsArray[k] = k == originalLength - 1
                        ? currentCup
                        : cupsArray[k + 1];
                }
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
