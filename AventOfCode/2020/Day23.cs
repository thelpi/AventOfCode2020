using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2020
{
    /// <summary>
    /// Day 23: Crab Cups
    /// </summary>
    public sealed class Day23 : DayBase
    {
        private const int PART_2_ELEMENTS_COUNT = 1000000;
        private const int PART_1_LOOP = 100;
        private const int PART_2_LOOP = 10000000;

        public Day23() : base(2020, 23) { }

        public override long GetFirstPartResult(bool sample)
        {
            var content = GetContent(v => Convert.ToInt32(v), sample: sample);

            var cupLinks = Loop(content.ToList(), PART_1_LOOP);

            var values = new List<char>();

            var currentCar = cupLinks[1];
            while (currentCar != 1)
            {
                values.Add(currentCar.ToString().First());
                currentCar = cupLinks[currentCar];
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

            var cupLinks = Loop(content.ToList(), PART_2_LOOP);

            return cupLinks[1] * (long)cupLinks[cupLinks[1]];
        }

        private Dictionary<int, int> Loop(List<int> cupsArray, int loop)
        {
            var maxCup = cupsArray.Max();

            var cupsLink = new Dictionary<int, int>();
            for (int i = 0; i < cupsArray.Count; i++)
            {
                cupsLink.Add(cupsArray[i], cupsArray[i + 1 == cupsArray.Count ? 0 : i + 1]);
            }

            var currentCup = cupsArray.First();
            for (int i = 0; i < loop; i++)
            {
                var pickedCup1 = cupsLink[currentCup];
                var pickedCup2 = cupsLink[pickedCup1];
                var pickedCup3 = cupsLink[pickedCup2];

                // the cup that follows "current cup" is now the one
                // that followed the third pick
                cupsLink[currentCup] = cupsLink[pickedCup3];

                // destination cup is greater than zero
                // and not one of the picks
                var destinationCup = currentCup - 1;
                while (destinationCup == 0
                    || pickedCup1 == destinationCup
                    || pickedCup2 == destinationCup
                    || pickedCup3 == destinationCup)
                {
                    destinationCup--;
                    if (destinationCup < 1)
                    {
                        destinationCup = maxCup;
                    }
                }

                // the 3 picks should now follow the destination cup
                var tmpCup = cupsLink[destinationCup];
                cupsLink[destinationCup] = pickedCup1;
                cupsLink[pickedCup3] = tmpCup;

                currentCup = cupsLink[currentCup];
            }

            return cupsLink;
        }
    }
}
