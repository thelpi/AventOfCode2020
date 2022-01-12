using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day13 : DayBase
    {
        public Day13() : base(2021, 13) { }

        public string FinalForm { get; private set; }

        public override long GetFirstPartResult(bool sample)
        {
            var folds = new List<Fold>();
            var points = GetContent(v =>
            {
                if (v.StartsWith("fold"))
                {
                    var parts = v.Split('=');
                    folds.Add(new Fold { IsX = parts[0].Split(' ')[2] == "x", V = Convert.ToInt32(parts[1]) });
                }
                else if (!string.IsNullOrWhiteSpace(v))
                    return new Point(Convert.ToInt32(v.Split(',')[0]), Convert.ToInt32(v.Split(',')[1]));

                return default(Point?);
            }, sample: sample).Where(x => x != null).Select(x => x.Value).ToList();

            var maxX = points.Select(x => x.X).Max();
            var maxY = points.Select(x => x.Y).Max();

            long pts = 0;

            var f = folds.First();
            if (f.IsX)
            {
                for (var i = 0; i < f.V; i++)
                {
                    for (var j = 0; j <= maxY; j++)
                    {
                        if (points.Any(x => (x.X == i || x.X == (f.V * 2) - i) && x.Y == j))
                            pts++;
                    }
                }
            }
            else
            {
                for (var i = 0; i <= maxX; i++)
                {
                    for (var j = 0; j < f.V; j++)
                    {
                        if (points.Any(x => x.X == i && (x.Y == j || x.Y == (f.V * 2) - j)))
                            pts++;
                    }
                }
            }

            return pts;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var folds = new List<Fold>();
            var points = GetContent(v =>
            {
                if (v.StartsWith("fold"))
                {
                    var parts = v.Split('=');
                    folds.Add(new Fold { IsX = parts[0].Split(' ')[2] == "x", V = Convert.ToInt32(parts[1]) });
                }
                else if (!string.IsNullOrWhiteSpace(v))
                    return new Point(Convert.ToInt32(v.Split(',')[0]), Convert.ToInt32(v.Split(',')[1]));

                return default(Point?);
            }, sample: sample).Where(x => x != null).Select(x => x.Value).ToList();

            foreach (var f in folds)
            {
                var newPoints = new List<Point>();

                var maxX = points.Select(x => x.X).Max();
                var maxY = points.Select(x => x.Y).Max();

                if (f.IsX)
                {
                    for (var i = 0; i < f.V; i++)
                    {
                        for (var j = 0; j <= maxY; j++)
                        {
                            var pt = points.Where(x => (x.X == i || x.X == (f.V * 2) - i) && x.Y == j);
                            if (pt.Any())
                            {
                                var okPt = pt.First();
                                okPt = okPt.X == i ? okPt : new Point(i, okPt.Y);
                                newPoints.Add(okPt);
                            }
                        }
                    }
                }
                else
                {
                    for (var i = 0; i <= maxX; i++)
                    {
                        for (var j = 0; j < f.V; j++)
                        {
                            var pt = points.Where(x => x.X == i && (x.Y == j || x.Y == (f.V * 2) - j));
                            if (pt.Any())
                            {
                                var okPt = pt.First();
                                okPt = okPt.Y == j ? okPt : new Point(okPt.X, j);
                                newPoints.Add(okPt);
                            }
                        }
                    }
                }

                points = newPoints;
            }

            var maxX2 = points.Select(x => x.X).Max();
            var maxY2 = points.Select(x => x.Y).Max();

            var fullText = "";
            for (var i = 0; i <= maxX2; i++)
            {
                for (var j = 0; j <= maxY2; j++)
                {
                    if (points.Any(ppp => ppp.Y == j && ppp.X == i))
                        fullText += "1";
                    else
                        fullText += "0";
                    fullText += "\t";
                }
                fullText += "\r\n";
            }

            FinalForm = fullText;

            return 0;
        }

        private class Fold
        {
            public int V { get; set; }
            public bool IsX { get; set; }
        }
    }
}
