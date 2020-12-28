using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 3: Toboggan Trajectory
    /// </summary>
    public sealed class Day03 : DayBase
    {
        public Day03() : base(3) { }

        public override long GetFirstPartResult(bool sample)
        {
            var fullList = GetContent(v => v.ToArray().Select(subV => subV == '#' ? 1 : 0).ToList(), sample: sample);

            var combos = new List<(int right, int down)>
            {
                (3, 1)
            };
            long treeMultiply = 1;

            foreach (var (right, down) in combos)
            {
                int treeCount = 0;
                int currentRight = 0;
                int lastIndexByRow = fullList[0].Count - 1;
                for (int i = 0; i < fullList.Count; i += down)
                {
                    if (fullList[i][currentRight] == 1)
                    {
                        treeCount++;
                    }
                    currentRight += right;
                    var diffRight = lastIndexByRow - currentRight;
                    if (diffRight < 0)
                    {
                        currentRight = Math.Abs(diffRight) - 1;
                    }
                }

                treeMultiply *= treeCount;
            }

            return treeMultiply;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var fullList = GetContent(v => v.ToArray().Select(subV => subV == '#' ? 1 : 0).ToList(), sample: sample);

            var combos = new List<(int right, int down)>
            {
                (3, 1)
            };
            combos.Add((1, 1));
            combos.Add((5, 1));
            combos.Add((7, 1));
            combos.Add((1, 2));
            long treeMultiply = 1;

            foreach (var (right, down) in combos)
            {
                int treeCount = 0;
                int currentRight = 0;
                int lastIndexByRow = fullList[0].Count - 1;
                for (int i = 0; i < fullList.Count; i += down)
                {
                    if (fullList[i][currentRight] == 1)
                    {
                        treeCount++;
                    }
                    currentRight += right;
                    var diffRight = lastIndexByRow - currentRight;
                    if (diffRight < 0)
                    {
                        currentRight = Math.Abs(diffRight) - 1;
                    }
                }

                treeMultiply *= treeCount;
            }

            return treeMultiply;
        }
    }
}
