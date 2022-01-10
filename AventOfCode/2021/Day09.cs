using System;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day09 : DayBase
    {
        public Day09() : base(2021, 9) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetContent(v => v.ToCharArray().Select(x => Convert.ToInt32(x.ToString())).ToList(), sample: sample);

            long sumRiskLevel = 0;
            for (var i = 0; i < values.Count; i++)
            {
                for (var j = 0; j < values[i].Count; j++)
                {
                    var curr = values[i][j];
                    var top = i == 0 ? int.MaxValue : values[i - 1][j];
                    var bottom = i == values.Count - 1 ? int.MaxValue : values[i + 1][j];
                    var left = j == 0 ? int.MaxValue : values[i][j - 1];
                    var right = j == values[i].Count - 1 ? int.MaxValue : values[i][j + 1];
                    if (curr < top && curr < bottom && curr < left && curr < right)
                    {
                        sumRiskLevel += curr + 1;
                    }
                }
            }

            return sumRiskLevel;
        }

        public override long GetSecondPartResult(bool sample)
        {
            throw new NotImplementedException();
        }
    }
}
