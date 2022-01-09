using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day05 : DayBase
    {
        public Day05() : base(2021, 5) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetContent(v => GetPoints(v, true), sample: sample);

            return GetIntersectionsCount(values);
        }

        public override long GetSecondPartResult(bool sample)
        {
            var values = GetContent(v => GetPoints(v, false), sample: sample);

            return GetIntersectionsCount(values);
        }

        private static int GetIntersectionsCount(List<List<Point>> values)
        {
            return values.Where(x => x != null).SelectMany(_ => _).GroupBy(_ => _).Count(_ => _.Count() > 1);
        }

        private static List<Point> GetPoints(string lineRaw, bool firstPart)
        {
            var pts = lineRaw
                    .Split(new[] { "->", ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(_ => Convert.ToInt32(_))
                    .ToArray();

            var isDiag = pts[0] != pts[2] && pts[1] != pts[3];
            if (isDiag && firstPart)
            {
                return null;
            }

            var points = new List<Point>();

            if (pts[0] > pts[2])
            {
                var decal = 0;
                for (var a = pts[0]; a >= pts[2]; a--)
                {
                    if (pts[1] > pts[3])
                    {
                        var decal2 = 0;
                        for (var b = pts[1]; b >= pts[3]; b--)
                        {
                            if (!isDiag || decal == decal2)
                            {
                                points.Add(new Point(a, b));
                            }

                            decal2++;
                        }
                    }
                    else
                    {
                        var decal2 = 0;
                        for (var b = pts[1]; b <= pts[3]; b++)
                        {
                            if (!isDiag || decal == decal2)
                            {
                                points.Add(new Point(a, b));
                            }

                            decal2++;
                        }
                    }
                    decal++;
                }
            }
            else
            {
                var decal = 0;
                for (var a = pts[0]; a <= pts[2]; a++)
                {
                    if (pts[1] > pts[3])
                    {
                        var decal2 = 0;
                        for (var b = pts[1]; b >= pts[3]; b--)
                        {
                            if (!isDiag || decal == decal2)
                            {
                                points.Add(new Point(a, b));
                            }

                            decal2++;
                        }
                    }
                    else
                    {
                        var decal2 = 0;
                        for (var b = pts[1]; b <= pts[3]; b++)
                        {
                            if (!isDiag || decal == decal2)
                            {
                                points.Add(new Point(a, b));
                            }

                            decal2++;
                        }
                    }
                    decal++;
                }
            }

            return points;
        }
    }
}
