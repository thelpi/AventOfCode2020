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
                    var moveTypeIndex = COORDINATES.IndexOf(moveType);
                    coordinatesValues_p1[moveTypeIndex] += moveValue;
                    point = GetNewPoint(move, point, moveType, moveValue,
                        moveTypeIndex % 2 == 1 ? NORTH : EAST);
                }
                else if (moveType == LEFT || moveType == RIGHT)
                {
                    var newAngle = moveValue / ROTATION_ANGLE;
                    for (int i = 0; i < newAngle; i++)
                    {
                        currentMoveType = GetTurnIndex(currentMoveType, moveType);
                        move = (GetTurnIndex(move.Item1, moveType),
                            GetTurnIndex(move.Item2, moveType));
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

        private int GetTurnIndex(int currentDirectionIndex, char direction)
        {
            return direction == LEFT
                ? (currentDirectionIndex == 0 ? (COORDINATES.Length - 1) : currentDirectionIndex - 1)
                : (currentDirectionIndex == (COORDINATES.Length - 1) ? 0 : currentDirectionIndex + 1);
        }

        private (int, int) GetNewPoint((int, int) move, (int, int) point,
            char moveType, int moveValue, char dir)
        {
            var dirIndex = COORDINATES.IndexOf(dir);
            var oppositeDirIndex = COORDINATES.IndexOf(dir) > 1
                ? COORDINATES.IndexOf(dir) - 2
                : COORDINATES.IndexOf(dir) + 2;

            int newPoint1 = point.Item1, newPoint2 = point.Item2;
            if (move.Item2 == dirIndex)
            {
                newPoint2 = moveType == dir ? point.Item2 + moveValue : point.Item2 - moveValue;
            }
            else if (move.Item2 == oppositeDirIndex)
            {
                newPoint2 = moveType == dir ? point.Item2 - moveValue : point.Item2 + moveValue;
            }
            else if (move.Item1 == dirIndex)
            {
                newPoint1 = moveType == dir ? point.Item1 + moveValue : point.Item1 - moveValue;
            }
            else if (move.Item1 == oppositeDirIndex)
            {
                newPoint1 = moveType == dir ? point.Item1 - moveValue : point.Item1 + moveValue;
            }
            return (newPoint1, newPoint2);
        }
    }
}
