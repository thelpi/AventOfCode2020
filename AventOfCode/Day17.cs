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
        private const int CYCLES_COUNT = 6;
        private const int GRID_LENGTH = 25; // arbitrary; minimal for 8x8x8x8
        private const char ONE_VALUE = '#';
        private static readonly int GRID_CENTER = GRID_LENGTH / 2;

        public Day17() : base(17) { }

        public override long GetFirstPartResult(bool sample)
        {
            var content = GetContent(row => row.Select(v => v == ONE_VALUE ? 1 : 0).ToArray(), sample: sample).ToArray();

            // creates an empty grid
            var grid = AddDim(i => AddDim(j => AddDim(k => 0)));

            // fills with puzzle in the middle (barely) of the grid
            FillArraycenter(content, grid[GRID_CENTER]);

            // for each cycle
            for (int cycle = 0; cycle < CYCLES_COUNT; cycle++)
            {
                var coordinatesToSwitch = new List<(int i, int j, int k)>();
                // loops on each point
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        for (int k = 0; k < grid[i][j].Length; k++)
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
                                        else if (jAr >= grid[i].Length || iAr >= grid.Length || kAr >= grid[i][j].Length)
                                        {
                                            // exclude max border
                                            continue;
                                        }
                                        else if (grid[iAr][jAr][kAr] == 1)
                                        {
                                            count1++;
                                        }
                                    }
                                }
                            }
                            // Is "count1" apply to switch rules ?
                            if ((grid[i][j][k] == 0 && count1 == 3) ||
                                (grid[i][j][k] == 1 && count1 != 3 && count1 != 2))
                            {
                                coordinatesToSwitch.Add((i, j, k));
                            }
                        }
                    }
                }
                // reverse values
                foreach (var (i, j, k) in coordinatesToSwitch)
                {
                    grid[i][j][k] = Math.Abs(grid[i][j][k] - 1);
                }
            }
            // sums every "1"
            return grid.Sum(_0 => _0.Sum(_1 => _1.Sum()));
        }

        public override long GetSecondPartResult(bool sample)
        {
            var content = GetContent(row => row.Select(v => v == ONE_VALUE ? 1 : 0).ToArray(), sample: sample).ToArray();

            // creates an empty grid
            var grid = AddDim(i => AddDim(j => AddDim(k => AddDim(l => 0))));

            // fills with puzzle in the middle (barely) of the grid
            FillArraycenter(content, grid[GRID_CENTER][GRID_CENTER]);

            // for each cycle
            for (int cycle = 0; cycle < CYCLES_COUNT; cycle++)
            {
                var coordinatesToSwitch = new List<(int i, int j, int k, int l)>();
                // loops on each point
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        for (int k = 0; k < grid[i][j].Length; k++)
                        {
                            for (int l = 0; l < grid[i][j][k].Length; l++)
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
                                                else if (jAr >= grid[i].Length || iAr >= grid.Length || kAr >= grid[i][j].Length || lAr >= grid[i][j][k].Length)
                                                {
                                                    // exclude max border
                                                    continue;
                                                }
                                                else if (grid[iAr][jAr][kAr][lAr] == 1)
                                                {
                                                    count1++;
                                                }
                                            }
                                        }
                                    }
                                }
                                // Is "count1" apply to switch rules ?
                                if ((grid[i][j][k][l] == 0 && count1 == 3) ||
                                    (grid[i][j][k][l] == 1 && count1 != 3 && count1 != 2))
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
                    grid[i][j][k][l] = Math.Abs(grid[i][j][k][l] - 1);
                }
            }
            // sums every "1"
            return grid.Sum(_0 => _0.Sum(_1 => _1.Sum(_2 => _2.Sum())));
        }

        private TDim[] AddDim<TDim>(Func<int, TDim> callback)
        {
            return Enumerable
                .Range(0, GRID_LENGTH)
                .Select(_ => callback(_))
                .ToArray();
        }

        private void FillArraycenter(int[][] sourceContent, int[][] gridCenter)
        {
            for (int i = GRID_CENTER; i < GRID_CENTER + sourceContent[0].Length; i++)
            {
                for (int j = GRID_CENTER; j < GRID_CENTER + sourceContent[1].Length; j++)
                {
                    gridCenter[i][j] = sourceContent[i - GRID_CENTER][j - GRID_CENTER];
                }
            }
        }
    }
}
