using System;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day11 : DayBase
    {
        public Day11() : base(2021, 11) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetContent(v => v.ToCharArray().Select(_ => Convert.ToInt32(_.ToString())).ToList(), sample: sample);

            var pts = Enumerable.Range(0, values.Count)
                .SelectMany(i => Enumerable.Range(0, values[0].Count)
                    .Select(j => new Pt { X = i, Y = j, Flashing = false, V = values[i][j]}))
                .ToList();

            long flashes = 0;
            for (var t = 1; t <= 100; t++)
            {
                pts.ForEach(pt => pt.V = pt.V + 1);
                var toFlash = pts.Where(pt => !pt.Flashing && pt.V > 9).ToList();
                while (toFlash.Count > 0)
                {
                    flashes += toFlash.Count;
                    toFlash.ForEach(pt => pt.Flashing = true);
                    foreach (var flashing in toFlash)
                    {
                        for (var i = flashing.X - 1; i <= flashing.X + 1; i++)
                        {
                            for (var j = flashing.Y - 1; j <= flashing.Y + 1; j++)
                            {
                                var subF = pts.SingleOrDefault(pt => pt.Y == j && pt.X == i);
                                if (subF?.Flashing == false)
                                    subF.V = subF.V + 1;
                            }
                        }
                    }
                    toFlash = pts.Where(pt => !pt.Flashing && pt.V > 9).ToList();
                }
                pts.ForEach(pt =>
                {
                    if (pt.Flashing)
                    {
                        pt.Flashing = false;
                        pt.V = 0;
                    }
                });
            }

            return flashes;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var values = GetContent(v => v.ToCharArray().Select(_ => Convert.ToInt32(_.ToString())).ToList(), sample: sample);

            var pts = Enumerable.Range(0, values.Count)
                .SelectMany(i => Enumerable.Range(0, values[0].Count)
                    .Select(j => new Pt { X = i, Y = j, Flashing = false, V = values[i][j] }))
                .ToList();

            long t = 0;
            while (true)
            {
                t++;
                var localFlashCount = 0;
                pts.ForEach(pt => pt.V = pt.V + 1);
                var toFlash = pts.Where(pt => !pt.Flashing && pt.V > 9).ToList();
                while (toFlash.Count > 0)
                {
                    localFlashCount += toFlash.Count;
                    toFlash.ForEach(pt => pt.Flashing = true);
                    foreach (var flashing in toFlash)
                    {
                        for (var i = flashing.X - 1; i <= flashing.X + 1; i++)
                        {
                            for (var j = flashing.Y - 1; j <= flashing.Y + 1; j++)
                            {
                                var subF = pts.SingleOrDefault(pt => pt.Y == j && pt.X == i);
                                if (subF?.Flashing == false)
                                    subF.V = subF.V + 1;
                            }
                        }
                    }
                    toFlash = pts.Where(pt => !pt.Flashing && pt.V > 9).ToList();
                }
                pts.ForEach(pt =>
                {
                    if (pt.Flashing)
                    {
                        pt.Flashing = false;
                        pt.V = 0;
                    }
                });
                if (localFlashCount == pts.Count)
                    break;
            }

            return t;
        }

        private class Pt
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool Flashing { get; set; }
            public int V { get; set; }
        }
    }
}
