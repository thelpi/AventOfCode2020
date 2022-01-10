using System;
using System.Collections.Generic;
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
            var values = GetContent(v => v.ToCharArray().Select(x => Convert.ToInt32(x.ToString())).ToList(), sample: sample);

            var bassins = new List<int>();
            for (var i = 0; i < values.Count; i++)
            {
                for (var j = 0; j < values[i].Count; j++)
                {
                    var curr = values[i][j];
                    var top = i == 0 ? 9 : values[i - 1][j];
                    var bottom = i == values.Count - 1 ? 9 : values[i + 1][j];
                    var left = j == 0 ? 9 : values[i][j - 1];
                    var right = j == values[i].Count - 1 ? 9 : values[i][j + 1];
                    if (curr < top && curr < bottom && curr < left && curr < right)
                    {
                        var sides = new List<(int, int, int)>
                        {
                            (i - 1, j, top),
                            (i + 1, j, bottom),
                            (i, j - 1, left),
                            (i, j + 1, right)
                        };
                        sides.RemoveAll(x => x.Item3 == 9);
                        if (sides.Count == 0)
                        {
                            bassins.Add(1);
                        }
                        else
                        {
                            RecursiveBassinsSearch(values, ref sides, new List<(int, int, int)> { (i, j, curr) });
                            if (!sides.Contains((i, j, curr)))
                                sides.Add((i, j, curr));
                            bassins.Add(sides.Count);
                        }
                    }
                }
            }

            long tot = 1;
            foreach (var t in bassins.OrderByDescending(x => x).Take(3))
            {
                tot *= t;
            }

            return tot;
        }

        private static void RecursiveBassinsSearch(
            List<List<int>> values,
            ref List<(int, int, int)> sides,
            List<(int, int, int)> excludeFromAnalyse)
        {
            var sidesCount = sides.Count;
            var sidesToAdd = new List<(int, int, int)>();
            foreach (var (si, sj, sv) in sides.Where(cc => !excludeFromAnalyse.Contains(cc)))
            {
                var top = si == 0 ? 9 : values[si - 1][sj];
                var bottom = si == values.Count - 1 ? 9 : values[si + 1][sj];
                var left = sj == 0 ? 9 : values[si][sj - 1];
                var right = sj == values[si].Count - 1 ? 9 : values[si][sj + 1];
                var subSides = new List<(int, int, int)>
                {
                    (si - 1, sj, top),
                    (si + 1, sj, bottom),
                    (si, sj - 1, left),
                    (si, sj + 1, right)
                };
                sidesToAdd.AddRange(subSides.Where(x => x.Item3 < 9));
                excludeFromAnalyse.Add((si, sj, sv));
            }
            sides.AddRange(sidesToAdd);
            sides = sides.GroupBy(x => x).Select(x => x.Key).ToList();
            if (sidesCount != sides.Count)
            {
                RecursiveBassinsSearch(values, ref sides, excludeFromAnalyse);
            }
        }
    }
}
