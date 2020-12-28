using System;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 12: Rain Risk
    /// </summary>
    public sealed class Day12 : DayBase
    {
        public Day12() : base(12) { }

        public override long GetFirstPartResult(bool sample)
        {
            var instructions = GetContent(v => (v[0], Convert.ToInt32(v.Substring(1))), sample: sample);

            const char EAST = 'E';
            const char SOUTH = 'S';
            const char WEST = 'W';
            const char NORTH = 'N';
            const char LEFT = 'L';
            const char RIGHT = 'R';
            const char FORWARD = 'F';
            string coordinates = $"{EAST}{SOUTH}{WEST}{NORTH}";
            int[] coordinatesValues = new int[coordinates.Length];
            int angleQuotient = 360 / coordinates.Length;
            
            var currentMoveType = coordinates.IndexOf(EAST);

            foreach (var instruction in instructions)
            {
                var iType = instruction.Item1;
                var iMove = instruction.Item2;
                if (coordinates.Contains(iType))
                {
                    coordinatesValues[coordinates.IndexOf(iType)] += iMove;
                }
                else if (iType == LEFT || iType == RIGHT)
                {
                    var newAngle = iMove / angleQuotient;
                    for (int i = 0; i < newAngle; i++)
                    {
                        currentMoveType = iType == LEFT
                                ? (currentMoveType == 0 ? (coordinates.Length - 1) : currentMoveType - 1)
                                : (currentMoveType == (coordinates.Length - 1) ? 0 : currentMoveType + 1);
                    }
                }
                else if (iType == FORWARD)
                {
                    coordinatesValues[currentMoveType] += iMove;
                }
            }

            return Math.Abs(coordinatesValues[1] - coordinatesValues[3])
                + Math.Abs(coordinatesValues[0] - coordinatesValues[2]);
        }

        public override long GetSecondPartResult(bool sample)
        {
            var instructions = GetContent(v => (v[0], Convert.ToInt32(v.Substring(1))), sample: sample);

            const char EAST = 'E';
            const char SOUTH = 'S';
            const char WEST = 'W';
            const char NORTH = 'N';
            const char LEFT = 'L';
            const char RIGHT = 'R';
            const char FORWARD = 'F';
            string coordinates = $"{EAST}{SOUTH}{WEST}{NORTH}";
            int[] coordinatesValues = new int[coordinates.Length];
            int angleQuotient = 360 / coordinates.Length;
            
            (int, int) point = (10, 1);
            (int, int) move = (0, coordinates.Length - 1);

            foreach (var instruction in instructions)
            {
                var iType = instruction.Item1;
                var iMove = instruction.Item2;
                if (coordinates.Contains(iType))
                {
                    if (iType == NORTH || iType == SOUTH)
                    {
                        int newPoint1 = point.Item1, newPoint2 = point.Item2;
                        if (move.Item2 == coordinates.IndexOf(NORTH))
                        {
                            newPoint2 = iType == NORTH ? point.Item2 + iMove : point.Item2 - iMove;
                        }
                        else if (move.Item2 == coordinates.IndexOf(SOUTH))
                        {
                            newPoint2 = iType == NORTH ? point.Item2 - iMove : point.Item2 + iMove;
                        }
                        else if (move.Item1 == coordinates.IndexOf(NORTH))
                        {
                            newPoint1 = iType == NORTH ? point.Item1 + iMove : point.Item1 - iMove;
                        }
                        else if (move.Item1 == coordinates.IndexOf(SOUTH))
                        {
                            newPoint1 = iType == NORTH ? point.Item1 - iMove : point.Item1 + iMove;
                        }
                        point = (newPoint1, newPoint2);
                    }
                    else if (iType == EAST || iType == WEST)
                    {
                        int newPoint1 = point.Item1, newPoint2 = point.Item2;
                        if (move.Item2 == coordinates.IndexOf(EAST))
                        {
                            newPoint2 = iType == EAST ? point.Item2 + iMove : point.Item2 - iMove;
                        }
                        else if (move.Item2 == coordinates.IndexOf(WEST))
                        {
                            newPoint2 = iType == EAST ? point.Item2 - iMove : point.Item2 + iMove;
                        }
                        else if (move.Item1 == coordinates.IndexOf(EAST))
                        {
                            newPoint1 = iType == EAST ? point.Item1 + iMove : point.Item1 - iMove;
                        }
                        else if (move.Item1 == coordinates.IndexOf(WEST))
                        {
                            newPoint1 = iType == EAST ? point.Item1 - iMove : point.Item1 + iMove;
                        }
                        point = (newPoint1, newPoint2);
                    }
                }
                else if (iType == LEFT || iType == RIGHT)
                {
                    var newAngle = iMove / angleQuotient;
                    for (int i = 0; i < newAngle; i++)
                    {
                        if (iType == LEFT)
                        {
                            move = (move.Item1 == 0 ? (coordinates.Length - 1) : move.Item1 - 1,
                                move.Item2 == 0 ? (coordinates.Length - 1) : move.Item2 - 1);
                        }
                        else
                        {
                            move = (move.Item1 == (coordinates.Length - 1) ? 0 : move.Item1 + 1,
                                move.Item2 == (coordinates.Length - 1) ? 0 : move.Item2 + 1);
                        }
                    }
                }
                else if (iType == FORWARD)
                {
                    coordinatesValues[move.Item1] += point.Item1 * iMove;
                    coordinatesValues[move.Item2] += point.Item2 * iMove;
                }
            }

            return Math.Abs(coordinatesValues[1] - coordinatesValues[3])
                + Math.Abs(coordinatesValues[0] - coordinatesValues[2]);
        }
    }
}
