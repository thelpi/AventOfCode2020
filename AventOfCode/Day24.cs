using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 24: Lobby Layout
    /// </summary>
    public sealed class Day24 : Day
    {
        // Arbitray value (to form a grid large enough)
        private const int GRID_SIZE = 500;
        private const int DAYS_COUNT = 100;

        public Day24() : base(24) { }

        public override long GetFirstPartResult(bool sample)
        {
            var tiles = GetInitialGrid(sample);

            return CountBlackTiles(tiles);
        }

        public override long GetSecondPartResult(bool sample)
        {
            var tiles = GetInitialGrid(sample);

            var toSwitch = new List<(int, int)>();
            for (int k = 1; k <= DAYS_COUNT; k++)
            {
                toSwitch.Clear();
                for (int i = 0; i < GRID_SIZE; i++)
                {
                    for (int j = 0; j < GRID_SIZE; j++)
                    {
                        int count = 0;
                        if (j > 0 && tiles[i][j - 1])
                        {
                            count++;
                        }
                        if (i > 0 && j > 0 && tiles[i - 1][j - 1])
                        {
                            count++;
                        }
                        if (i > 0 && tiles[i - 1][j])
                        {
                            count++;
                        }
                        if (i < (GRID_SIZE - 1) && tiles[i + 1][j])
                        {
                            count++;
                        }
                        if (i < (GRID_SIZE - 1) && j < (GRID_SIZE - 1) && tiles[i + 1][j + 1])
                        {
                            count++;
                        }
                        if (j < (GRID_SIZE - 1) && tiles[i][j + 1])
                        {
                            count++;
                        }

                        if (tiles[i][j])
                        {
                            if (count == 0 || count > 2)
                            {
                                toSwitch.Add((i, j));
                            }
                        }
                        else
                        {
                            if (count == 2)
                            {
                                toSwitch.Add((i, j));
                            }
                        }
                    }
                }
                foreach (var (a, b) in toSwitch)
                {
                    tiles[a][b] = !tiles[a][b];
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
