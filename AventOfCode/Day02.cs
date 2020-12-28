using System;
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
            return GetItemsCountMatchingCondition(sample, (min, max, car, strValue) =>
            {
                var countChar = strValue.Count(c => c == car);
                return countChar >= min && countChar <= max;
            });
        }

        public override long GetSecondPartResult(bool sample)
        {
            return GetItemsCountMatchingCondition(sample, (min, max, car, strValue) =>
            {
                return (strValue[min - 1] == car && strValue[max - 1] != car)
                    || (strValue[min - 1] != car && strValue[max - 1] == car);
            });
        }

        private int GetItemsCountMatchingCondition(bool sample,
            Func<int, int, char, string, bool> condition)
        {
            var items = GetContent(v =>
            {
                var splitted = v.Split(new[] { ' ' });
                return (
                    Convert.ToInt32(splitted[0].Split('-')[0]),
                    Convert.ToInt32(splitted[0].Split('-')[1]),
                    splitted[1][0],
                    splitted[2]
                );
            }, sample: sample);

            return items.Count(v => condition(v.Item1, v.Item2, v.Item3, v.Item4));
        }
    }
}
