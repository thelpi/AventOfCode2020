using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AventOfCode
{
    /// <summary>
    /// Day 20: Jurassic Jigsaw
    /// </summary>
    public sealed class Day20 : DayBase
    {
        public Day20() : base(20) { }

        public override long GetFirstPartResult(bool sample)
        {
            var content = GetContent(v =>
            {
                var rows = v.Split("\r\n");
                return (Convert.ToInt32(rows[0].Replace(":", "").Replace("Tile ", "")), rows.Skip(1)
                    .Select(_ => _.
                        Select(__ =>
                            Convert.ToInt32(__ == '.' ? 1 : 0))
                        .ToArray())
                    .ToArray());
            }, "\r\n\r\n", sample: sample).ToDictionary(kvp => kvp.Item1, kvp => kvp.Item2);

            var dim = (int)Math.Sqrt(content.Keys.Count);

            var rightPossibilities = new List<Cube>();
            var bottomPossibilities = new List<Cube>();

            var grid = new Cube[dim, dim];

            var cubPoses = content.Keys.SelectMany(k => ToCubeList(k, content[k])).ToList();

            grid = Sequencial(0, 0, grid, cubPoses, rightPossibilities, bottomPossibilities, dim);

            return (long)grid[0, 0].Id * grid[0, dim - 1].Id * grid[dim - 1, 0].Id * grid[dim - 1, dim - 1].Id;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var content = GetContent(v =>
            {
                var rows = v.Split("\r\n");
                return (Convert.ToInt32(rows[0].Replace(":", "").Replace("Tile ", "")), rows.Skip(1)
                    .Select(_ => _.
                        Select(__ =>
                            Convert.ToInt32(__ == '.' ? 1 : 0))
                        .ToArray())
                    .ToArray());
            }, "\r\n\r\n", sample: sample).ToDictionary(kvp => kvp.Item1, kvp => kvp.Item2);

            var dim = (int)Math.Sqrt(content.Keys.Count);

            var rightPossibilities = new List<Cube>();
            var bottomPossibilities = new List<Cube>();

            var grid = new Cube[dim, dim];

            var cubPoses = content.Keys.SelectMany(k => ToCubeList(k, content[k])).ToList();

            grid = Sequencial(0, 0, grid, cubPoses, rightPossibilities, bottomPossibilities, dim);

            var pixelSizeNoBorder = grid[0, 0].Bottom.Length - 2;
            var image = new int[dim * pixelSizeNoBorder, dim * pixelSizeNoBorder];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    for (int k = 0; k < grid[i, j].InsideContent.GetLength(0); k++)
                    {
                        for (int l = 0; l < grid[i, j].InsideContent.GetLength(1); l++)
                        {
                            image[(i * pixelSizeNoBorder) + k, (j * pixelSizeNoBorder) + l] = grid[i, j].InsideContent[k, l];
                        }
                    }
                }
            }

            var img2D = new int[dim * pixelSizeNoBorder][];
            for (int i = 0; i < image.GetLength(0); i++)
            {
                img2D[i] = new int[dim * pixelSizeNoBorder];
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    img2D[i][j] = image[i, j];
                }
            }

            var imgVersions = ToCubeList(1, img2D).Select(_ => _.FullContent).ToList();

            int resultCount = 0;
            foreach (var imgVersion in imgVersions)
            {
                // xxxxxxxxxxxxxxxxxx#x
                // #xxxx##xxxx##xxxx###
                // x#xx#xx#xx#xx#xx#xxx
                int countUsedAsMonster = 0;
                for (int i = 0; i < imgVersion.GetLength(0); i++)
                {
                    for (int j = 0; j < imgVersion.GetLength(1); j++)
                    {
                        if (imgVersion[i, j] == 0)
                        {
                            if (j > 17 && i < imgVersion.GetLength(0) - 2 && j < imgVersion.GetLength(1) - 1) // monster head
                            {
                                if (imgVersion[i + 1, j - 18] == 0
                                    && imgVersion[i + 1, j - 13] == 0
                                    && imgVersion[i + 1, j - 12] == 0
                                    && imgVersion[i + 1, j - 7] == 0
                                    && imgVersion[i + 1, j - 6] == 0
                                    && imgVersion[i + 1, j - 1] == 0
                                    && imgVersion[i + 1, j - 0] == 0
                                    && imgVersion[i + 1, j + 1] == 0) // monster body 1
                                {
                                    if (imgVersion[i + 2, j - 17] == 0
                                        && imgVersion[i + 2, j - 14] == 0
                                        && imgVersion[i + 2, j - 11] == 0
                                        && imgVersion[i + 2, j - 8] == 0
                                        && imgVersion[i + 2, j - 5] == 0
                                        && imgVersion[i + 2, j - 2] == 0) // monster body 2
                                    {
                                        countUsedAsMonster += 15;
                                    }
                                }
                            }
                        }
                    }
                }
                if (countUsedAsMonster > 0)
                {
                    for (int i = 0; i < imgVersion.GetLength(0); i++)
                    {
                        for (int j = 0; j < imgVersion.GetLength(1); j++)
                        {
                            if (imgVersion[i, j] == 0)
                            {
                                resultCount++;
                            }
                        }
                    }
                    resultCount -= countUsedAsMonster;
                }
            }

            return resultCount;
        }

        private int[][] Rotate(int[][] cube)
        {
            var rotated = new int[cube.Length][];
            for (int i = 0; i < cube.Length; i++)
            {
                for (int j = 0; j < cube.Length; j++)
                {
                    if (i == 0)
                    {
                        rotated[j] = new int[cube.Length];
                    }
                    rotated[j][(cube.Length - 1 - i)] = cube[i][j];
                }
            }
            return rotated;
        }

        private int[][] Flip(int[][] cube, int flipIndex)
        {
            switch (flipIndex)
            {
                case 1:
                    return cube.Reverse().ToArray();
                case 2:
                    return cube.Select(_ => _.Reverse().ToArray()).ToArray();
                case 3:
                    return cube.Reverse().Select(_ => _.Reverse().ToArray()).ToArray();
                default:
                    return cube.ToArray();
            }
        }

        private List<Cube> ToCubeList(int id, int[][] originalDatas)
        {
            var cubes = new List<Cube>();

            for (int iFlip = 0; iFlip < 4; iFlip++)
            {
                var currentDatas = Flip(originalDatas, iFlip);
                for (int iRotate = 0; iRotate < 4; iRotate++)
                {
                    currentDatas = iRotate == 0 ? currentDatas : Rotate(currentDatas);
                    cubes.Add(new Cube(id, currentDatas));
                }
            }

            for (int k = cubes.Count - 1; k >= 0; k--)
            {
                if (cubes.Any(c => cubes.IndexOf(c) < k && cubes[k].IsEqualTo(c)))
                {
                    cubes.RemoveAt(k);
                }
            }

            return cubes;
        }

        private Cube[,] Sequencial(int i, int j, Cube[,] localGrid, List<Cube> localCubes,
            List<Cube> rightPossibilities, List<Cube> bottomPossibilities, int dim)
        {
            if (i == dim)
            {
                return localGrid;
            }

            rightPossibilities.Clear();
            bottomPossibilities.Clear();

            if (i > 0)
            {
                var topper = localGrid[i - 1, j];
                bottomPossibilities.AddRange(localCubes.Where(lc => topper.MatchTop(lc)));
                if (bottomPossibilities.Count == 0)
                {
                    return null;
                }
            }

            if (j > 0)
            {
                var lefter = localGrid[i, j - 1];
                rightPossibilities.AddRange(localCubes.Where(lc => lefter.MatchLeft(lc)));
                if (rightPossibilities.Count == 0)
                {
                    return null;
                }
            }

            var possibilities = new List<Cube>();
            if (rightPossibilities.Count > 0 && bottomPossibilities.Count > 0)
            {
                var intersect = rightPossibilities.Intersect(bottomPossibilities);
                if (!intersect.Any())
                {
                    return null;
                }
                possibilities.AddRange(intersect);
            }
            else if (rightPossibilities.Count > 0)
            {
                possibilities.AddRange(rightPossibilities);
            }
            else if (bottomPossibilities.Count > 0)
            {
                possibilities.AddRange(bottomPossibilities);
            }
            else
            {
                possibilities.AddRange(localCubes);
            }

            foreach (var poss in possibilities)
            {
                var localCubesCopy = new List<Cube>(localCubes.Where(lcc => lcc.Id != poss.Id));

                var localGridCopy = new Cube[dim, dim];
                for (int k = 0; k < localGrid.GetLength(0); k++)
                {
                    for (int l = 0; l < localGrid.GetLength(1); l++)
                    {
                        localGridCopy[k, l] = localGrid[k, l];
                    }
                }
                localGridCopy[i, j] = poss;

                int newJ = j + 1;
                int newI = i;
                if (newJ == dim)
                {
                    newJ = 0;
                    newI += 1;
                }

                localGridCopy = Sequencial(newI, newJ, localGridCopy, localCubesCopy, rightPossibilities, bottomPossibilities, dim);
                if (localGridCopy != null)
                {
                    return localGridCopy;
                }
            }

            return null;
        }

        private class Cube
        {
            public string Top { get; }
            public string Left { get; }
            public string Right { get; }
            public string Bottom { get; }
            public int Id { get; }
            public int[,] InsideContent { get; }
            public int[,] FullContent { get; }

            public Cube(int id, int[][] content)
            {
                Id = id;
                FullContent = new int[content.Length, content.Length];
                InsideContent = new int[content.Length - 2, content.Length - 2];

                var top = new int[content.Length];
                var bottom = new int[content.Length];
                var left = new int[content.Length];
                var right = new int[content.Length];
                for (int i = 0; i < content.Length; i++)
                {
                    for (int j = 0; j < content.Length; j++)
                    {
                        if (i == 0)
                        {
                            top[j] = content[i][j];
                        }
                        if (i == content.Length - 1)
                        {
                            bottom[j] = content[i][j];
                        }
                        if (j == 0)
                        {
                            left[i] = content[i][j];
                        }
                        if (j == content.Length - 1)
                        {
                            right[i] = content[i][j];
                        }
                        if (j > 0 && j < content.Length - 1 && i > 0 && i < content.Length - 1)
                        {
                            InsideContent[i - 1, j - 1] = content[i][j];
                        }
                        FullContent[i, j] = content[i][j];
                    }
                }

                Top = string.Join(string.Empty, top);
                Bottom = string.Join(string.Empty, bottom);
                Left = string.Join(string.Empty, left);
                Right = string.Join(string.Empty, right);
            }

            public bool MatchTop(Cube other)
            {
                return Bottom == other.Top;
            }

            public bool MatchLeft(Cube other)
            {
                return Right == other.Left;
            }

            public bool IsEqualTo(Cube other)
            {
                return other.Top == Top
                    && other.Bottom == Bottom
                    && other.Left == Left
                    && other.Right == Right;
            }
        }
    }
}
