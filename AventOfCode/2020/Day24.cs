using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2020
{
    /// <summary>
    /// Day 24: Lobby Layout
    /// </summary>
    public sealed class Day24 : DayBase
    {
        // Arbitray value (to form a grid large enough; borders MUST stay white at all time)
        private const int GRID_SIZE = 500;
        private const int DAYS_COUNT = 100;

        public Day24() : base(2020, 24) { }

        public override long GetFirstPartResult(bool sample)
        {
            var tiles = GetInitialGrid(sample);

            return CountBlackTiles(tiles);
        }

        public override long GetSecondPartResult(bool sample)
        {
            var tiles = GetInitialGrid(sample);

            var tilesToSwitch = new List<(int, int)>();
            for (int k = 1; k <= DAYS_COUNT; k++)
            {
                tilesToSwitch.Clear();
                for (int i = 1; i < GRID_SIZE - 1; i++)
                {
                    for (int j = 1; j < GRID_SIZE - 1; j++)
                    {
                        int count = 0;
                        if (tiles[i][j - 1]) count++;
                        if (tiles[i - 1][j - 1]) count++;
                        if (tiles[i - 1][j]) count++;
                        if (tiles[i + 1][j]) count++;
                        if (tiles[i + 1][j + 1]) count++;
                        if (tiles[i][j + 1]) count++;

                        if ((tiles[i][j] && (count == 0 || count > 2))
                            || (!tiles[i][j] && count == 2))
                        {
                            tilesToSwitch.Add((i, j));
                        }
                    }
                }
                foreach (var (i, j) in tilesToSwitch)
                {
                    tiles[i][j] = !tiles[i][j];
                }
            }

            return CountBlackTiles(tiles);
        }

        private bool[][] GetInitialGrid(bool sample)
        {
            var instructions = GetInstructions(sample);

            var tiles = new bool[GRID_SIZE][];
            for (var i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new bool[GRID_SIZE];
            }

            var iCurrent = GRID_SIZE / 2;
            var jCurrent = GRID_SIZE / 2;
            foreach (var instructionsLine in instructions)
            {
                foreach (var instruction in instructionsLine)
                {
                    switch (instruction)
                    {
                        case Direction.SouthWest:
                            iCurrent++;
                            break;
                        case Direction.SouthEast:
                            jCurrent++;
                            iCurrent++;
                            break;
                        case Direction.NorthWest:
                            jCurrent--;
                            iCurrent--;
                            break;
                        case Direction.NorthEast:
                            iCurrent--;
                            break;
                        case Direction.East:
                            jCurrent++;
                            break;
                        case Direction.West:
                            jCurrent--;
                            break;
                    }
                }
                tiles[iCurrent][jCurrent] = !tiles[iCurrent][jCurrent];
                iCurrent = GRID_SIZE / 2;
                jCurrent = GRID_SIZE / 2;
            }

            return tiles;
        }

        private List<Direction>[] GetInstructions(bool sample)
        {
            var datas = GetContent(v => v, sample: sample);

            var instructions = new List<Direction>[datas.Count];
            for (int i = 0; i < datas.Count; i++)
            {
                var data = datas[i];
                var instructionsLine = new List<Direction>();
                var k = 0;
                while (k < data.Length)
                {
                    string directionValue;
                    if (data[k] == 's' || data[k] == 'n')
                    {
                        directionValue = new string(data.Skip(k).Take(2).ToArray());
                        k++;
                    }
                    else
                    {
                        directionValue = data[k].ToString();
                    }
                    instructionsLine.Add(GetDirection(directionValue));
                    k++;
                }
                instructions[i] = instructionsLine;
            }

            return instructions;
        }

        private long CountBlackTiles(bool[][] tiles)
        {
            return tiles.Sum(_ => _.Count(__ => __));
        }

        private Direction GetDirection(string directionValue)
        {
            switch (directionValue)
            {
                case "sw":
                    return Direction.SouthWest;
                case "se":
                    return Direction.SouthEast;
                case "nw":
                    return Direction.NorthWest;
                case "ne":
                    return Direction.NorthEast;
                case "e":
                    return Direction.East;
                case "w":
                    return Direction.West;
                default:
                    throw new NotImplementedException();
            }
        }

        private enum Direction
        {
            East,
            West,
            SouthWest,
            SouthEast,
            NorthEast,
            NorthWest
        }
    }
}
