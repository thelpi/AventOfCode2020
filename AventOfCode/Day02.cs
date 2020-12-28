using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 2: Password Philosophy
    /// </summary>
    public sealed class Day02 : DayBase
    {
        public Day02() : base(2) { }

        public override long GetFirstPartResult(bool sample)
        {
            var baseList = GetContent(v => v, sample: sample);

            var tuples = new List<(int min, int max, char car, string val)>();
            foreach (var l in baseList)
            {
                var splitted = l.Split(new[] { ' ' });
                var min = Convert.ToInt32(splitted[0].Split('-')[0]);
                var max = Convert.ToInt32(splitted[0].Split('-')[1]);
                var car = splitted[1][0];
                var val = splitted[2];
                tuples.Add((min, max, car, val));
            }

            int countValid = 0;
            foreach (var (min, max, car, val) in tuples)
            {
                var countChar = val.Count(c => c == car);
                if (countChar >= min && countChar <= max)
                {
                    countValid++;
                }
            }

            return countValid;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var baseList = GetContent(v => v, sample: sample);

            var tuples = new List<(int min, int max, char car, string val)>();
            foreach (var l in baseList)
            {
                var splitted = l.Split(new[] { ' ' });
                var min = Convert.ToInt32(splitted[0].Split('-')[0]);
                var max = Convert.ToInt32(splitted[0].Split('-')[1]);
                var car = splitted[1][0];
                var val = splitted[2];
                tuples.Add((min, max, car, val));
            }

            int countValid = 0;
            foreach (var (min, max, car, val) in tuples)
            {
                if (
                    (val[min - 1] == car && val[max - 1] != car)
                    || (val[min - 1] != car && val[max - 1] == car))
                {
                    countValid++;
                }
            }

            return countValid;
        }
    }
}
