using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2019
{
    /// <summary>
    /// Day 4: Secure Container
    /// </summary>
    public sealed class Day04 : DayBase
    {
        public Day04() : base(2019, 4) { }

        public override long GetFirstPartResult(bool sample)
        {
            return CommonTrunk(sample, false);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CommonTrunk(sample, true);
        }

        private long CommonTrunk(bool sample, bool twoLimited)
        {
            var values = GetContent(
                v => (v.Split('-')[0], v.Split('-')[1]),
                sample: sample);

            var rangeMin = Convert.ToInt32(values[0].Item1);
            var rangeMax = Convert.ToInt32(values[0].Item2);

            int countOk = 0;
            for (int i = rangeMin; i <= rangeMax; i++)
            {
                var iStr = i.ToString();
                var c = iStr[0];
                bool okUp = true;
                var currentDual = new List<List<char>> { new List<char>() };
                for (int j = 1; j < 6; j++)
                {
                    var newC = iStr[j];
                    if (c == newC)
                    {
                        currentDual.Last().Add(c);
                    }
                    else
                    {
                        currentDual.Add(new List<char>());
                    }
                    if (Char.GetNumericValue(newC) < Char.GetNumericValue(c))
                    {
                        okUp = false;
                        break;
                    }
                    c = newC;
                }

                if (currentDual.Any(_ => twoLimited ? _.Count == 1 : _.Count > 0) && okUp)
                {
                    countOk++;
                }
            }

            return countOk;
        }
    }
}
