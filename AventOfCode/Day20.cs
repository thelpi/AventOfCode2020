using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 20: Jurassic Jigsaw
    /// </summary>
    public sealed class Day20 : DayBase
    {
        private static readonly List<(int k, int l)> MONSTER = new List<(int, int)>
        {
            (0, 18),
            (1, 0), (1, 5), (1, 6), (1, 11), (1, 12), (1, 17), (1, 18), (1, 19),
            (2, 1), (2, 4), (2, 7), (2, 10), (2, 13), (2, 16),
        };

        public Day20() : base(20) { }

        public override long GetFirstPartResult(bool sample)
        {
            var puzzle = CommonTrunk(sample);

            return (long)puzzle[0, 0].Id
                * puzzle[0, puzzle.GetLength(1) - 1].Id
                * puzzle[puzzle.GetLength(0) - 1, 0].Id
                * puzzle[puzzle.GetLength(0) - 1, puzzle.GetLength(1) - 1].Id;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var puzzle = CommonTrunk(sample);

            // removes borders for each piece of the puzzle
            // and assembles the inner content of each piece into an image
            var pieceSize = puzzle[0, 0].InsideContent.GetLength(0);
            var puzzleImage = new int[puzzle.GetLength(0) * pieceSize, puzzle.GetLength(1) * pieceSize];
            for (int i = 0; i < puzzle.GetLength(0); i++)
            {
                for (int j = 0; j < puzzle.GetLength(1); j++)
                {
                    for (int k = 0; k < puzzle[i, j].InsideContent.GetLength(0); k++)
                    {
                        for (int l = 0; l < puzzle[i, j].InsideContent.GetLength(1); l++)
                        {
                            puzzleImage[(i * pieceSize) + k, (j * pieceSize) + l] = puzzle[i, j].InsideContent[k, l];
                        }
                    }
                }
            }

            // transforms the puzzle image into an array of arrays
            // it's easier to apply flip and rotation that way (cf. next step)
            var imgArOfAr = new int[puzzle.GetLength(0) * pieceSize][];
            for (int i = 0; i < puzzleImage.GetLength(0); i++)
            {
                imgArOfAr[i] = new int[puzzle.GetLength(1) * pieceSize];
                for (int j = 0; j < puzzleImage.GetLength(1); j++)
                {
                    imgArOfAr[i][j] = puzzleImage[i, j];
                }
            }

            // loops on every possible orientation and flip of the final image
            var resultCount = 0;
            foreach (var puzzleContent in ToOrientedPieces(1, imgArOfAr).Select(_ => _.FullContent))
            {
                var monsterCount = 0;
                for (var i = 0; i < puzzleContent.GetLength(0); i++)
                {
                    for (var j = 0; j < puzzleContent.GetLength(1); j++)
                    {
                        // for each "pixel" of the image
                        // tries to establish if the monster can be drawn
                        // by converting coordinates into a relative position (0, 0)
                        var matchingMonster = true;
                        foreach (var (k, l) in MONSTER)
                        {
                            var relativeI = i + k;
                            var relativej = j + l;
                            if (relativeI < 0
                                || relativej < 0
                                || relativeI >= puzzleContent.GetLength(0)
                                || relativej >= puzzleContent.GetLength(1)
                                || puzzleContent[relativeI, relativej] != 0)
                            {
                                matchingMonster = false;
                                break;
                            }
                        }
                        if (matchingMonster)
                        {
                            monsterCount++;
                        }
                    }
                }
                if (monsterCount > 0)
                {
                    // number total of piece
                    // minus pieces with "1" value
                    // minus monster pieces
                    resultCount += (
                        puzzleContent.Cast<int>().Count()
                        - puzzleContent.Cast<int>().Sum()
                    ) - (monsterCount * MONSTER.Count);
                    // note: there's only one solution
                    break;
                }
            }

            return resultCount;
        }

        private OrientedPiece[,] CommonTrunk(bool sample)
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

            var grid = new OrientedPiece[dim, dim];

            var cubPoses = content.Keys.SelectMany(k => ToOrientedPieces(k, content[k])).ToList();

            return ResolvePuzzleRecursive((0, 0), grid, cubPoses);
        }

        private int[][] RotateGrid(int[][] cube)
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

        private IEnumerable<OrientedPiece> ToOrientedPieces(int id, int[][] cubeDatas)
        {
            for (int iFlip = 0; iFlip < 2; iFlip++)
            {
                var currentDatas = iFlip == 0
                    ? cubeDatas
                    : cubeDatas.Reverse().ToArray();
                for (int iRotate = 0; iRotate < 4; iRotate++)
                {
                    currentDatas = iRotate == 0
                        ? currentDatas
                        : RotateGrid(currentDatas);
                    yield return new OrientedPiece(id, currentDatas);
                }
            }
        }

        private OrientedPiece[,] ResolvePuzzleRecursive((int i, int j) currentPieceIndex, OrientedPiece[,] puzzleInProgress, List<OrientedPiece> remainingPieces)
        {
            var (i, j) = currentPieceIndex;

            if (i == puzzleInProgress.GetLength(0))
            {
                return puzzleInProgress;
            }

            var rightPossibilities = new List<OrientedPiece>();
            var bottomPossibilities = new List<OrientedPiece>();

            if (i > 0)
            {
                var topper = puzzleInProgress[i - 1, j];
                bottomPossibilities.AddRange(remainingPieces.Where(lc => topper.MatchTop(lc)));
                if (bottomPossibilities.Count == 0)
                {
                    return null;
                }
            }

            if (j > 0)
            {
                var lefter = puzzleInProgress[i, j - 1];
                rightPossibilities.AddRange(remainingPieces.Where(lc => lefter.MatchLeft(lc)));
                if (rightPossibilities.Count == 0)
                {
                    return null;
                }
            }

            var possibilities = new List<OrientedPiece>();
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
                possibilities.AddRange(remainingPieces);
            }

            foreach (var poss in possibilities)
            {
                var localCubesCopy = new List<OrientedPiece>(remainingPieces.Where(lcc => lcc.Id != poss.Id));

                var localGridCopy = new OrientedPiece[puzzleInProgress.GetLength(0), puzzleInProgress.GetLength(1)];
                for (int k = 0; k < puzzleInProgress.GetLength(0); k++)
                {
                    for (int l = 0; l < puzzleInProgress.GetLength(1); l++)
                    {
                        localGridCopy[k, l] = puzzleInProgress[k, l];
                    }
                }
                localGridCopy[i, j] = poss;

                int newJ = j + 1;
                int newI = i;
                if (newJ == puzzleInProgress.GetLength(1))
                {
                    newJ = 0;
                    newI += 1;
                }

                localGridCopy = ResolvePuzzleRecursive((newI, newJ), localGridCopy, localCubesCopy);
                if (localGridCopy != null)
                {
                    return localGridCopy;
                }
            }

            return null;
        }

        private class OrientedPiece
        {
            private readonly string _top;
            private readonly string _left;
            private readonly string _right;
            private readonly string _bottom;

            public int Id { get; }
            public int[,] InsideContent { get; }
            public int[,] FullContent { get; }

            public OrientedPiece(int id, int[][] content)
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

                _top = string.Join(string.Empty, top);
                _bottom = string.Join(string.Empty, bottom);
                _left = string.Join(string.Empty, left);
                _right = string.Join(string.Empty, right);
            }

            public bool MatchTop(OrientedPiece other)
            {
                return _bottom == other._top;
            }

            public bool MatchLeft(OrientedPiece other)
            {
                return _right == other._left;
            }
        }
    }
}
