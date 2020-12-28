using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 17: Conway Cubes
    /// </summary>
    public sealed class Day17 : DayBase
    {
        public Day17() : base(17) { }

        public override long GetFirstPartResult(bool sample)
        {
            const int CYCLES_COUNT = 6;
            const int GRID_LENGTH = 25; // arbitrary; minimal for 8x8x8x8
            const char ONE_VALUE = '#';

            var content = GetContent(row => row.Select(v => v == ONE_VALUE ? 1 : 0).ToArray(), sample: sample).ToArray();

            // creates an empty grid
            var grid1 = Enumerable.Range(0, GRID_LENGTH)
                .Select(_0 => Enumerable.Range(0, GRID_LENGTH)
                    .Select(_1 => Enumerable.Range(0, GRID_LENGTH)
                        .Select(_2 => 0)
                .ToArray()).ToArray()).ToArray();

            // fills with puzzle in the middle (barely) of the grid
            var center1 = GRID_LENGTH / 2;
            for (int i = center1; i < center1 + content[0].Length; i++)
            {
                for (int j = center1; j < center1 + content[0].Length; j++)
                {
                    grid1[center1][i][j] = content[i - center1][j - center1];
                }
            }

            // for each cycle
            for (int cycle = 0; cycle < CYCLES_COUNT; cycle++)
            {
                var coordinatesToSwitch = new List<(int i, int j, int k)>();
                // loops on each point
                for (int i = 0; i < grid1.Length; i++)
                {
                    for (int j = 0; j < grid1[i].Length; j++)
                    {
                        for (int k = 0; k < grid1[i][j].Length; k++)
                        {
                            // loops on every point around the current point
                            var count1 = 0;
                            for (int iAr = i - 1; iAr <= i + 1; iAr++)
                            {
                                for (int jAr = j - 1; jAr <= j + 1; jAr++)
                                {
                                    for (int kAr = k - 1; kAr <= k + 1; kAr++)
                                    {
                                        if (jAr == j && iAr == i && k == kAr)
                                        {
                                            // exclude current point
                                            continue;
                                        }
                                        else if (jAr < 0 || iAr < 0 || kAr < 0)
                                        {
                                            // exclude min border
                                            continue;
                                        }
                                        else if (jAr >= grid1[i].Length || iAr >= grid1.Length || kAr >= grid1[i][j].Length)
                                        {
                                            // exclude max border
                                            continue;
                                        }
                                        else if (grid1[iAr][jAr][kAr] == 1)
                                        {
                                            count1++;
                                        }
                                    }
                                }
                            }
                            // Is "count1" apply to switch rules ?
                            if ((grid1[i][j][k] == 0 && count1 == 3) ||
                                (grid1[i][j][k] == 1 && count1 != 3 && count1 != 2))
                            {
                                coordinatesToSwitch.Add((i, j, k));
                            }
                        }
                    }
                }
                // reverse values
                foreach (var (i, j, k) in coordinatesToSwitch)
                {
                    grid1[i][j][k] = Math.Abs(grid1[i][j][k] - 1);
                }
            }
            // sums every "1"
            return grid1.Sum(_0 => _0.Sum(_1 => _1.Sum()));
        }

        public override long GetSecondPartResult(bool sample)
        {
            const int CYCLES_COUNT = 6;
            const int GRID_LENGTH = 25; // arbitrary; minimal for 8x8x8x8
            const char ONE_VALUE = '#';

            var content = GetContent(row => row.Select(v => v == ONE_VALUE ? 1 : 0).ToArray(), sample: sample).ToArray(); 

            // creates an empty grid
            var grid2 = Enumerable.Range(0, GRID_LENGTH)
                .Select(_0 => Enumerable.Range(0, GRID_LENGTH)
                    .Select(_1 => Enumerable.Range(0, GRID_LENGTH)
                        .Select(_2 => Enumerable.Range(0, GRID_LENGTH)
                              .Select(_3 => 0)
                .ToArray()).ToArray()).ToArray()).ToArray();

            // fills with puzzle in the middle (barely) of the grid
            var center2 = GRID_LENGTH / 2;
            for (int i = center2; i < center2 + content[0].Length; i++)
            {
                for (int j = center2; j < center2 + content[0].Length; j++)
                {
                    grid2[center2][center2][i][j] = content[i - center2][j - center2];
                }
            }

            // for each cycle
            for (int cycle = 0; cycle < CYCLES_COUNT; cycle++)
            {
                var coordinatesToSwitch = new List<(int i, int j, int k, int l)>();
                // loops on each point
                for (int i = 0; i < grid2.Length; i++)
                {
                    for (int j = 0; j < grid2[i].Length; j++)
                    {
                        for (int k = 0; k < grid2[i][j].Length; k++)
                        {
                            for (int l = 0; l < grid2[i][j][k].Length; l++)
                            {
                                // loops on every point around the current point
                                var count1 = 0;
                                for (int iAr = i - 1; iAr <= i + 1; iAr++)
                                {
                                    for (int jAr = j - 1; jAr <= j + 1; jAr++)
                                    {
                                        for (int kAr = k - 1; kAr <= k + 1; kAr++)
                                        {
                                            for (int lAr = l - 1; lAr <= l + 1; lAr++)
                                            {
                                                if (jAr == j && iAr == i && k == kAr && lAr == l)
                                                {
                                                    // exclude current point
                                                    continue;
                                                }
                                                else if (jAr < 0 || iAr < 0 || kAr < 0 || lAr < 0)
                                                {
                                                    // exclude min border
                                                    continue;
                                                }
                                                else if (jAr >= grid2[i].Length || iAr >= grid2.Length || kAr >= grid2[i][j].Length || lAr >= grid2[i][j][k].Length)
                                                {
                                                    // exclude max border
                                                    continue;
                                                }
                                                else if (grid2[iAr][jAr][kAr][lAr] == 1)
                                                {
                                                    count1++;
                                                }
                                            }
                                        }
                                    }
                                }
                                // Is "count1" apply to switch rules ?
                                if ((grid2[i][j][k][l] == 0 && count1 == 3) ||
                                    (grid2[i][j][k][l] == 1 && count1 != 3 && count1 != 2))
                                {
                                    coordinatesToSwitch.Add((i, j, k, l));
                                }
                            }
                        }
                    }
                }
                // reverse values
                foreach (var (i, j, k, l) in coordinatesToSwitch)
                {
                    grid2[i][j][k][l] = Math.Abs(grid2[i][j][k][l] - 1);
                }
            }
            // sums every "1"
            return grid2.Sum(_0 => _0.Sum(_1 => _1.Sum(_2 => _2.Sum())));
        }
    }
}
