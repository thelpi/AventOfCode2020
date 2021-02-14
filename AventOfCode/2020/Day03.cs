using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2020
{
    /// <summary>
    /// Day 3: Toboggan Trajectory
    /// </summary>
    public sealed class Day03 : DayBase
    {
        private const char TREE = '#';

        public Day03() : base(2020, 3) { }

        public override long GetFirstPartResult(bool sample)
        {
            return CountTreeForEachSlide(sample,
                new List<(int, int)>
                {
                    (3, 1)
                });
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CountTreeForEachSlide(sample,
                new List<(int, int)>
                {
                    (3, 1), (1, 1), (5, 1), (7, 1), (1, 2)
                });
        }

        private long CountTreeForEachSlide(bool sample, List<(int right, int down)> moveCombos)
        {
            var slideGrid = GetContent(v =>
                v.Select(subV => subV == TREE).ToList(),
                sample: sample);

            long treeMultiply = 1;

            foreach (var (right, down) in moveCombos)
            {
                treeMultiply *= CountTreeOnSlide(slideGrid, right, down);
            }

            return treeMultiply;
        }

        private static int CountTreeOnSlide(List<List<bool>> slideGrid, int right, int down)
        {
            // Assumes X-axis is the same for each row
            int lastIndexAxisX = slideGrid[0].Count - 1;

            int treeCount = 0;
            int currentRight = 0;
            for (int currentDown = 0; currentDown < slideGrid.Count; currentDown += down)
            {
                if (slideGrid[currentDown][currentRight])
                {
                    treeCount++;
                }
                currentRight += right;
                var rightOverflow = lastIndexAxisX - currentRight;
                if (rightOverflow < 0)
                {
                    currentRight = Math.Abs(rightOverflow) - 1;
                }
            }

            return treeCount;
        }
    }
}
