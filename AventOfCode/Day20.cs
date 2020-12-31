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
            var piecesInfos = GetContent(v =>
            {
                var rows = v.Split("\r\n");
                return (Convert.ToInt32(rows[0].Replace(":", "").Replace("Tile ", "")), rows.Skip(1)
                    .Select(_ => _.
                        Select(__ =>
                            Convert.ToInt32(__ == '.' ? 1 : 0))
                        .ToArray())
                    .ToArray());
            }, "\r\n\r\n", sample: sample);

            var puzzleSize = (int)Math.Sqrt(piecesInfos.Count);

            return ResolvePuzzleRecursive(
                (0, 0),
                new OrientedPiece[puzzleSize, puzzleSize],
                piecesInfos.SelectMany(k => ToOrientedPieces(k.Item1, k.Item2)).ToList());
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

            // condition to exit: puzzle is done (ie. next row is too high)
            if (i == puzzleInProgress.GetLength(0))
            {
                return puzzleInProgress;
            }

            var piecesAvailable = new List<OrientedPiece>();
            if (i > 0 && j > 0)
            {
                // not first row, not first column:
                // we'll need a piece with
                // - a top side equals to the previous row bottom side
                // - a left side equals to the previous column right side
                var pieceOnTop = puzzleInProgress[i - 1, j];
                var pieceOnLeft = puzzleInProgress[i, j - 1];
                piecesAvailable.AddRange(remainingPieces.Where(p => pieceOnTop.MatchTop(p) && pieceOnLeft.MatchLeft(p)));
            }
            else if (i > 0)
            {
                // first column, not first row:
                // we'll need a piece with a top side equals to the previous row bottom side
                var pieceOnTop = puzzleInProgress[i - 1, j];
                piecesAvailable.AddRange(remainingPieces.Where(p => pieceOnTop.MatchTop(p)));
            }
            else if (j > 0)
            {
                // first row, not first column:
                // we'll need a piece with a left side equals to the previous column right side
                var pieceOnLeft = puzzleInProgress[i, j - 1];
                piecesAvailable.AddRange(remainingPieces.Where(p => pieceOnLeft.MatchLeft(p)));
            }
            else
            {
                // first row and first column:
                // all pieces available
                piecesAvailable.AddRange(remainingPieces);
            }

            // each available piece is an hypothesis we have to test
            foreach (var availablePiece in piecesAvailable)
            {
                // creates a new puzzle, identical to the current one
                var subPuzzle = new OrientedPiece[puzzleInProgress.GetLength(0), puzzleInProgress.GetLength(1)];
                for (int k = 0; k < puzzleInProgress.GetLength(0); k++)
                {
                    for (int l = 0; l < puzzleInProgress.GetLength(1); l++)
                    {
                        subPuzzle[k, l] = puzzleInProgress[k, l];
                    }
                }
                // and sets the available piece into the grid current point
                subPuzzle[i, j] = availablePiece;

                // computes next point
                (int newI, int newJ) newPoint = (i, j + 1);
                if (newPoint.newJ == puzzleInProgress.GetLength(1))
                {
                    newPoint = (newPoint.newI + 1, 0);
                }

                // try to solve by recursion with the current hypothesis
                // also remove the hypothetical piece from remaining available pieces
                subPuzzle = ResolvePuzzleRecursive(
                    newPoint,
                    subPuzzle,
                    remainingPieces.Where(p => p.Id != availablePiece.Id).ToList());
                if (subPuzzle != null)
                {
                    return subPuzzle;
                }
            }

            // no hypothesis, or all wrong
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
