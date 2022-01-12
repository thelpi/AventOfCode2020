using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day12 : DayBase
    {
        public Day12() : base(2021, 12) { }

        private const string End = "end";
        private const string Start = "start";

        public override long GetFirstPartResult(bool sample)
        {
            var segments = GetContent(v => v.Split('-'), sample: sample);
            
            var paths = new List<List<string>>();
            foreach (var segment in segments.Where(x => x.Contains(Start)))
            {
                var nextLoc = segment.Single(x => x != Start);
                var currentPath = new List<string> { Start, nextLoc };
                Recursive(segments, paths, ref currentPath, nextLoc);
            }

            return paths.Count;
        }

        private void Recursive(
            List<string[]> segments,
            List<List<string>> paths,
            ref List<string> currentPath,
            string loc)
        {
            foreach (var segment in segments.Where(x => x.Contains(loc)))
            {
                var nextLoc = segment.Single(x => x != loc);
                if (!currentPath.Contains(nextLoc) || nextLoc.ToUpper() == nextLoc)
                {
                    currentPath.Add(nextLoc);
                    if (nextLoc == End)
                    {
                        paths.Add(currentPath);
                        currentPath = currentPath.Take(currentPath.Count - 1).ToList();
                    }
                    else
                        Recursive(segments, paths, ref currentPath, nextLoc);
                }
            }
            currentPath = currentPath.Take(currentPath.Count - 1).ToList();
        }

        public override long GetSecondPartResult(bool sample)
        {
            var values = GetContent(v => v.ToCharArray().Select(_ => Convert.ToInt32(_.ToString())).ToList(), sample: sample);

            throw new NotImplementedException();
        }
    }
}
