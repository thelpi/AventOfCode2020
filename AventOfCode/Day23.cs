using System;
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
            for (int i = 0; i < loop; i++)
            {
                var currentCup = cupsArray[0];

                var removed = new int[3];
                int j = 2;
                for (int k = 3; k >= 1; k--)
                {
                    removed[j] = cupsArray[k];
                    RemoveAt(ref cupsArray, k);
                    j--;
                }

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

                var cupsArrayCopy = new int[cupsArray.Length + removed.Length];
                for (int k = 0; k <= indexofminus; k++)
                {
                    cupsArrayCopy[k] = cupsArray[k];
                }
                for (int k = 0; k < 3; k++)
                {
                    cupsArrayCopy[k + indexofminus + 1] = removed[k];
                }
                for (int k = indexofminus + 1; k < cupsArray.Length; k++)
                {
                    cupsArrayCopy[k + 3] = cupsArray[k];
                }
                cupsArray = cupsArrayCopy;

                for (int k = 0; k < cupsArray.Length; k++)
                {
                    cupsArray[k] = k == cupsArray.Length - 1
                        ? currentCup
                        : cupsArray[k + 1];
                }
            }

            return Array.IndexOf(cupsArray, 1);
        }

        private void RemoveAt(ref int[] source, int index)
        {
            var dest = new int[source.Length - 1];
            if (index > 0)
            {
                Array.Copy(source, 0, dest, 0, index);
            }

            if (index < source.Length - 1)
            {
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);
            }

            source = dest;
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
