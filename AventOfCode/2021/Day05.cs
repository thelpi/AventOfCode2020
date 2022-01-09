using System;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day05 : DayBase
    {
        public Day05() : base(2021, 5) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetContent(v => new Line(v), sample: sample);

            values.RemoveAll(v => v.Invalid);

            var minX = values.Min(_ => _.Xs.Min());
            var minY = values.Min(_ => _.Ys.Min());
            var maxX = values.Max(_ => _.Xs.Max());
            var maxY = values.Max(_ => _.Ys.Max());

            long pointsCount = 0;
            for (var a = minX; a <= maxX; a++)
            {
                for (var b = minY; b <= maxY; b++)
                {
                    var intersections = values.Count(v => v.Xs.Contains(a) && v.Ys.Contains(b));
                    if (intersections > 1)
                        pointsCount++;
                }
            }


            return pointsCount;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var values = GetContent(v => Convert.ToInt32(v), sample: sample);

            throw new NotImplementedException();
        }

        private class Line
        {
            public int[] Xs { get; private set; }
            public int[] Ys { get; private set; }
            public bool Invalid { get; private set; }

            public Line(string lineRaw)
            {
                var pts = lineRaw
                    .Split(new[] { "->", ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(_ => Convert.ToInt32(_))
                    .ToArray();

                if (pts[0] != pts[2] && pts[1] != pts[3])
                {
                    Invalid = true;
                }
                else
                {
                    Xs = Fill(pts[0], pts[2]);
                    Ys = Fill(pts[1], pts[3]);
                }
            }

            private static int[] Fill(int x1, int x2)
            {
                if (x2 < x1)
                {
                    var tmp = x1;
                    x1 = x2;
                    x2 = tmp;
                }

                var xs = new int[(x2 - x1) + 1];
                var b = 0;
                for (var a = x1; a <= x2; a++)
                {
                    xs[b] = a;
                    b++;
                }

                return xs;
            }
        }
    }
}
