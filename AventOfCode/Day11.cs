using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 11: Seating System
    /// </summary>
    public sealed class Day11 : DayBase
    {
        private const char OCCUPIED = '#';
        private const char FLOOR = '.';
        private const char EMPTY = 'L';

        public Day11() : base(11) { }

        public override long GetFirstPartResult(bool sample)
        {
            return CommonTrunk(sample, (char[][] seatsConfiguration, int i, int j) =>
            {
                if (seatsConfiguration[i][j] == EMPTY
                    && GetDirectSurroundingEmptiness(seatsConfiguration, i, j) == 8)
                {
                    return OCCUPIED;
                }
                else if (seatsConfiguration[i][j] == OCCUPIED
                    && GetDirectSurroundingEmptiness(seatsConfiguration, i, j) <= 4)
                {
                    return EMPTY;
                }

                return null;
            });
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CommonTrunk(sample, (char[][] seatsConfiguration, int i, int j) =>
            {
                if (seatsConfiguration[i][j] == EMPTY
                    && GetDeepSurroundingEmptiness(seatsConfiguration, i, j) == 0)
                {
                    return OCCUPIED;
                }
                else if (seatsConfiguration[i][j] == OCCUPIED
                    && GetDeepSurroundingEmptiness(seatsConfiguration, i, j) >= 5)
                {
                    return EMPTY;
                }
                return null;
            });
        }

        private long CommonTrunk(bool sample, Func<char[][], int, int, char?> checkSeats)
        {
            var seatsConfiguration = GetContent(v => v.ToArray(), sample: sample).ToArray();
            
            var isNewConfiguration = true;
            while (isNewConfiguration)
            {
                isNewConfiguration = false;
                var newConfiguration = new char[seatsConfiguration.Length][];
                for (int i = 0; i < seatsConfiguration.Length; i++)
                {
                    newConfiguration[i] = new char[seatsConfiguration[i].Length];
                    for (int j = 0; j < seatsConfiguration[i].Length; j++)
                    {
                        var switchTo = checkSeats(seatsConfiguration, i, j);
                        if (switchTo.HasValue)
                        {
                            newConfiguration[i][j] = switchTo.Value;
                            isNewConfiguration = true;
                        }
                        else
                        {
                            newConfiguration[i][j] = seatsConfiguration[i][j];
                        }
                    }
                }
                seatsConfiguration = newConfiguration;
            }

            return seatsConfiguration.Sum(seatsRow => seatsRow.Count(v => v == OCCUPIED));
        }

        private bool EmptyOrFloor(char[][] seatsConfig, int i, int j)
        {
            return seatsConfig[i][j] == EMPTY
                || seatsConfig[i][j] == FLOOR;
        }

        private int GetDirectSurroundingEmptiness(char[][] seatsConfig, int i, int j)
        {
            return new[]
            {
                i == 0
                    || EmptyOrFloor(seatsConfig, i - 1, j),
                i == 0 || j + 1 == seatsConfig[i].Length
                    || EmptyOrFloor(seatsConfig, i - 1, j + 1),
                j + 1 == seatsConfig[i].Length
                    || EmptyOrFloor(seatsConfig, i, j + 1),
                i + 1 == seatsConfig.Length || j + 1 == seatsConfig[i].Length
                    || EmptyOrFloor(seatsConfig, i + 1, j + 1),
                i + 1 == seatsConfig.Length
                    || EmptyOrFloor(seatsConfig, i + 1, j),
                i + 1 == seatsConfig.Length || j == 0
                    || EmptyOrFloor(seatsConfig, i + 1, j - 1),
                j == 0
                    || EmptyOrFloor(seatsConfig, i, j - 1),
                i == 0 || j == 0
                    || EmptyOrFloor(seatsConfig, i - 1, j - 1)
            }.Count(_ => _);
        }

        private int GetDeepSurroundingEmptiness(char[][] seatsConfig, int i, int j)
        {
            int count = 0;

            bool findOccupied = false;
            bool findEmpty = false;
            int k = i - 1;
            while (k >= 0 && !findOccupied && !findEmpty)
            {
                findOccupied = seatsConfig[k][j] == OCCUPIED;
                findEmpty = seatsConfig[k][j] == EMPTY;
                k--;
            }
            if (findOccupied)
            {
                count++;
            }

            findOccupied = false;
            findEmpty = false;
            k = i - 1;
            var l = j + 1;
            while (k >= 0 && l < seatsConfig[i].Length && !findOccupied && !findEmpty)
            {
                findOccupied = seatsConfig[k][l] == OCCUPIED;
                findEmpty = seatsConfig[k][l] == EMPTY;
                k--;
                l++;
            }
            if (findOccupied)
            {
                count++;
            }

            findOccupied = false;
            findEmpty = false;
            l = j + 1;
            while (l < seatsConfig[i].Length && !findOccupied && !findEmpty)
            {
                findOccupied = seatsConfig[i][l] == OCCUPIED;
                findEmpty = seatsConfig[i][l] == EMPTY;
                l++;
            }
            if (findOccupied)
            {
                count++;
            }

            findOccupied = false;
            findEmpty = false;
            k = i + 1;
            l = j + 1;
            while (k < seatsConfig.Length && l < seatsConfig[i].Length && !findOccupied && !findEmpty)
            {
                findOccupied = seatsConfig[k][l] == OCCUPIED;
                findEmpty = seatsConfig[k][l] == EMPTY;
                k++;
                l++;
            }
            if (findOccupied)
            {
                count++;
            }

            findOccupied = false;
            findEmpty = false;
            k = i + 1;
            while (k < seatsConfig.Length && !findOccupied && !findEmpty)
            {
                findOccupied = seatsConfig[k][j] == OCCUPIED;
                findEmpty = seatsConfig[k][j] == EMPTY;
                k++;
            }
            if (findOccupied)
            {
                count++;
            }

            findOccupied = false;
            findEmpty = false;
            k = i + 1;
            l = j - 1;
            while (k < seatsConfig.Length && l >= 0 && !findOccupied && !findEmpty)
            {
                findOccupied = seatsConfig[k][l] == OCCUPIED;
                findEmpty = seatsConfig[k][l] == EMPTY;
                k++;
                l--;
            }
            if (findOccupied)
            {
                count++;
            }

            findOccupied = false;
            findEmpty = false;
            l = j - 1;
            while (l >= 0 && !findOccupied && !findEmpty)
            {
                findOccupied = seatsConfig[i][l] == OCCUPIED;
                findEmpty = seatsConfig[i][l] == EMPTY;
                l--;
            }
            if (findOccupied)
            {
                count++;
            }

            findOccupied = false;
            findEmpty = false;
            k = i - 1;
            l = j - 1;
            while (k >= 0 && l >= 0 && !findOccupied && !findEmpty)
            {
                findOccupied = seatsConfig[k][l] == OCCUPIED;
                findEmpty = seatsConfig[k][l] == EMPTY;
                k--;
                l--;
            }
            if (findOccupied)
            {
                count++;
            }

            return count;
        }
    }
}
