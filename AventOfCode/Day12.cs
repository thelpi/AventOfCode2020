using System;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 12: Rain Risk
    /// </summary>
    public sealed class Day12 : DayBase
    {
        private const char EAST = 'E';
        private const char SOUTH = 'S';
        private const char WEST = 'W';
        private const char NORTH = 'N';
        private const char LEFT = 'L';
        private const char RIGHT = 'R';
        private const char FORWARD = 'F';
        private static readonly string COORDINATES = $"{EAST}{SOUTH}{WEST}{NORTH}";
        private static readonly int ROTATION_ANGLE = 360 / COORDINATES.Length;

        private static readonly (int, int) START_POINT_PART2 = (10, 1);
        private static readonly (int, int) INIT_MOVE_PART2 = (0, COORDINATES.Length - 1);
        private static readonly int INIT_MOVE_TYPE_PART1 = COORDINATES.IndexOf(EAST);

        public Day12() : base(12) { }

        public override long GetFirstPartResult(bool sample)
        {
            return CommonTrunk(sample).part1;
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CommonTrunk(sample).part2;
        }

        public (long part1, long part2) CommonTrunk(bool sample)
        {
            var instructions = GetContent(v =>
            {
                var moveType = v[0];
                var moveValue = Convert.ToInt32(v.Substring(1));
                return (moveType, moveValue);
            }, sample: sample);

            var coordinatesValues_p1 = new int[COORDINATES.Length];
            var coordinatesValues_p2 = new int[COORDINATES.Length];

            var currentMoveType = INIT_MOVE_TYPE_PART1;
            var point = START_POINT_PART2;
            var move = INIT_MOVE_PART2;

            foreach (var (moveType, moveValue) in instructions)
            {
                if (COORDINATES.Contains(moveType))
                {
                    coordinatesValues_p1[COORDINATES.IndexOf(moveType)] += moveValue;
                    if (moveType == NORTH || moveType == SOUTH)
                    {
                        int newPoint1 = point.Item1, newPoint2 = point.Item2;
                        if (move.Item2 == COORDINATES.IndexOf(NORTH))
                        {
                            newPoint2 = moveType == NORTH ? point.Item2 + moveValue : point.Item2 - moveValue;
                        }
                        else if (move.Item2 == COORDINATES.IndexOf(SOUTH))
                        {
                            newPoint2 = moveType == NORTH ? point.Item2 - moveValue : point.Item2 + moveValue;
                        }
                        else if (move.Item1 == COORDINATES.IndexOf(NORTH))
                        {
                            newPoint1 = moveType == NORTH ? point.Item1 + moveValue : point.Item1 - moveValue;
                        }
                        else if (move.Item1 == COORDINATES.IndexOf(SOUTH))
                        {
                            newPoint1 = moveType == NORTH ? point.Item1 - moveValue : point.Item1 + moveValue;
                        }
                        point = (newPoint1, newPoint2);
                    }
                    else if (moveType == EAST || moveType == WEST)
                    {
                        int newPoint1 = point.Item1, newPoint2 = point.Item2;
                        if (move.Item2 == COORDINATES.IndexOf(EAST))
                        {
                            newPoint2 = moveType == EAST ? point.Item2 + moveValue : point.Item2 - moveValue;
                        }
                        else if (move.Item2 == COORDINATES.IndexOf(WEST))
                        {
                            newPoint2 = moveType == EAST ? point.Item2 - moveValue : point.Item2 + moveValue;
                        }
                        else if (move.Item1 == COORDINATES.IndexOf(EAST))
                        {
                            newPoint1 = moveType == EAST ? point.Item1 + moveValue : point.Item1 - moveValue;
                        }
                        else if (move.Item1 == COORDINATES.IndexOf(WEST))
                        {
                            newPoint1 = moveType == EAST ? point.Item1 - moveValue : point.Item1 + moveValue;
                        }
                        point = (newPoint1, newPoint2);
                    }
                }
                else if (moveType == LEFT || moveType == RIGHT)
                {
                    var newAngle = moveValue / ROTATION_ANGLE;
                    for (int i = 0; i < newAngle; i++)
                    {
                        if (moveType == LEFT)
                        {
                            currentMoveType = currentMoveType == 0 ? (COORDINATES.Length - 1) : currentMoveType - 1;
                            move = (move.Item1 == 0 ? (COORDINATES.Length - 1) : move.Item1 - 1,
                                move.Item2 == 0 ? (COORDINATES.Length - 1) : move.Item2 - 1);
                        }
                        else
                        {
                            currentMoveType = currentMoveType == (COORDINATES.Length - 1) ? 0 : currentMoveType + 1;
                            move = (move.Item1 == (COORDINATES.Length - 1) ? 0 : move.Item1 + 1,
                                move.Item2 == (COORDINATES.Length - 1) ? 0 : move.Item2 + 1);
                        }
                    }
                }
                else if (moveType == FORWARD)
                {
                    coordinatesValues_p1[currentMoveType] += moveValue;
                    coordinatesValues_p2[move.Item1] += point.Item1 * moveValue;
                    coordinatesValues_p2[move.Item2] += point.Item2 * moveValue;
                }
            }

            return (GetCoordinatesSum(coordinatesValues_p1),
                GetCoordinatesSum(coordinatesValues_p2));
        }

        private long GetCoordinatesSum(int[] coordinatesValues)
        {
            return Math.Abs(coordinatesValues[1] - coordinatesValues[3])
                + Math.Abs(coordinatesValues[0] - coordinatesValues[2]);
        }
    }
}
