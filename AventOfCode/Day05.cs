using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AventOfCode
{
    /// <summary>
    /// Day 5: Binary Boarding
    /// </summary>
    public sealed class Day05 : DayBase
    {
        public Day05() : base(5) { }

        public override long GetFirstPartResult(bool sample)
        {
            var list = GetContent( v => v, sample: sample);

            var ids = new List<int>();

            foreach (string board in list)
            {
                string rowInfo = board.Substring(0, 7);
                string colInfo = board.Substring(7);

                (int, int) rangeRow = (0, 127);
                (int, int) rangeCol = (0, 7);

                foreach (var c in rowInfo)
                {
                    int currentHalf = (rangeRow.Item2 - rangeRow.Item1) / 2;
                    if (c == 'F')
                    {
                        rangeRow = (rangeRow.Item1, rangeRow.Item1 + currentHalf);
                    }
                    else if (c == 'B')
                    {
                        rangeRow = (rangeRow.Item1 + currentHalf + 1, rangeRow.Item2);
                    }
                    else
                    {

                    }
                }

                foreach (var c in colInfo)
                {
                    int currentHalf = (rangeCol.Item2 - rangeCol.Item1) / 2;
                    if (c == 'L')
                    {
                        rangeCol = (rangeCol.Item1, rangeCol.Item1 + currentHalf);
                    }
                    else if (c == 'R')
                    {
                        rangeCol = (rangeCol.Item1 + currentHalf + 1, rangeCol.Item2);
                    }
                    else
                    {

                    }
                }

                ids.Add((rangeRow.Item1 * 8) + rangeCol.Item1);
            }

            var max = ids.Max();

            return max;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var list = GetContent( v => v, sample: sample);

            var ids = new List<int>();

            foreach (string board in list)
            {
                string rowInfo = board.Substring(0, 7);
                string colInfo = board.Substring(7);

                (int, int) rangeRow = (0, 127);
                (int, int) rangeCol = (0, 7);

                foreach (var c in rowInfo)
                {
                    int currentHalf = (rangeRow.Item2 - rangeRow.Item1) / 2;
                    if (c == 'F')
                    {
                        rangeRow = (rangeRow.Item1, rangeRow.Item1 + currentHalf);
                    }
                    else if (c == 'B')
                    {
                        rangeRow = (rangeRow.Item1 + currentHalf + 1, rangeRow.Item2);
                    }
                    else
                    {

                    }
                }

                foreach (var c in colInfo)
                {
                    int currentHalf = (rangeCol.Item2 - rangeCol.Item1) / 2;
                    if (c == 'L')
                    {
                        rangeCol = (rangeCol.Item1, rangeCol.Item1 + currentHalf);
                    }
                    else if (c == 'R')
                    {
                        rangeCol = (rangeCol.Item1 + currentHalf + 1, rangeCol.Item2);
                    }
                    else
                    {

                    }
                }

                ids.Add((rangeRow.Item1 * 8) + rangeCol.Item1);
            }

            var max = ids.Max();

            var match = -1;
            for (int i = 0; i < max; i++)
            {
                if (!ids.Contains(i))
                {
                    if (ids.Contains(i - 1) && ids.Contains(i + 1))
                    {
                        match = i;
                    }
                }
            }

            return match;
        }
    }
}
