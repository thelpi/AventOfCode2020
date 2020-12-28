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
            return CommonTrunk(sample, (char[][] seatsConfiguration, char[][] newConfiguration, int i, int j) =>
            {
                bool configurationChange = false;

                char? switchTo = null;
                if (seatsConfiguration[i][j] == EMPTY
                    && GetSurroundingEmptiness(seatsConfiguration, i, j) == 8)
                {
                    switchTo = OCCUPIED;
                }
                else if (seatsConfiguration[i][j] == OCCUPIED
                    && GetSurroundingEmptiness(seatsConfiguration, i, j) <= 4)
                {
                    switchTo = EMPTY;
                }

                if (switchTo.HasValue)
                {
                    newConfiguration[i][j] = switchTo.Value;
                    configurationChange = true;
                }
                else
                {
                    newConfiguration[i][j] = seatsConfiguration[i][j];
                }

                return configurationChange;
            });
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CommonTrunk(sample, (char[][] seatsConfiguration, char[][] newConfiguration, int i, int j) =>
            {
                bool configurationChange = false;

                List<int> occupieds = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };

                bool findOccupied = false;
                bool findEmpty = false;
                int k = i - 1;
                while (k >= 0 && !findOccupied && !findEmpty)
                {
                    findOccupied = seatsConfiguration[k][j] == OCCUPIED;
                    findEmpty = seatsConfiguration[k][j] == EMPTY;
                    k--;
                }
                occupieds[0] = findOccupied ? 1 : 0;

                findOccupied = false;
                findEmpty = false;
                k = i - 1;
                var l = j + 1;
                while (k >= 0 && l < seatsConfiguration[i].Length && !findOccupied && !findEmpty)
                {
                    findOccupied = seatsConfiguration[k][l] == OCCUPIED;
                    findEmpty = seatsConfiguration[k][l] == EMPTY;
                    k--;
                    l++;
                }
                occupieds[1] = findOccupied ? 1 : 0;

                findOccupied = false;
                findEmpty = false;
                l = j + 1;
                while (l < seatsConfiguration[i].Length && !findOccupied && !findEmpty)
                {
                    findOccupied = seatsConfiguration[i][l] == OCCUPIED;
                    findEmpty = seatsConfiguration[i][l] == EMPTY;
                    l++;
                }
                occupieds[2] = findOccupied ? 1 : 0;

                findOccupied = false;
                findEmpty = false;
                k = i + 1;
                l = j + 1;
                while (k < seatsConfiguration.Length && l < seatsConfiguration[i].Length && !findOccupied && !findEmpty)
                {
                    findOccupied = seatsConfiguration[k][l] == OCCUPIED;
                    findEmpty = seatsConfiguration[k][l] == EMPTY;
                    k++;
                    l++;
                }
                occupieds[3] = findOccupied ? 1 : 0;

                findOccupied = false;
                findEmpty = false;
                k = i + 1;
                while (k < seatsConfiguration.Length && !findOccupied && !findEmpty)
                {
                    findOccupied = seatsConfiguration[k][j] == OCCUPIED;
                    findEmpty = seatsConfiguration[k][j] == EMPTY;
                    k++;
                }
                occupieds[4] = findOccupied ? 1 : 0;

                findOccupied = false;
                findEmpty = false;
                k = i + 1;
                l = j - 1;
                while (k < seatsConfiguration.Length && l >= 0 && !findOccupied && !findEmpty)
                {
                    findOccupied = seatsConfiguration[k][l] == OCCUPIED;
                    findEmpty = seatsConfiguration[k][l] == EMPTY;
                    k++;
                    l--;
                }
                occupieds[5] = findOccupied ? 1 : 0;

                findOccupied = false;
                findEmpty = false;
                l = j - 1;
                while (l >= 0 && !findOccupied && !findEmpty)
                {
                    findOccupied = seatsConfiguration[i][l] == OCCUPIED;
                    findEmpty = seatsConfiguration[i][l] == EMPTY;
                    l--;
                }
                occupieds[6] = findOccupied ? 1 : 0;

                findOccupied = false;
                findEmpty = false;
                k = i - 1;
                l = j - 1;
                while (k >= 0 && l >= 0 && !findOccupied && !findEmpty)
                {
                    findOccupied = seatsConfiguration[k][l] == OCCUPIED;
                    findEmpty = seatsConfiguration[k][l] == EMPTY;
                    k--;
                    l--;
                }
                occupieds[7] = findOccupied ? 1 : 0;

                if (seatsConfiguration[i][j] == EMPTY)
                {
                    if (occupieds.Sum() == 0)
                    {
                        newConfiguration[i][j] = OCCUPIED;
                        configurationChange = true;
                    }
                    else
                    {
                        newConfiguration[i][j] = seatsConfiguration[i][j];
                    }
                }
                else if (seatsConfiguration[i][j] == OCCUPIED)
                {
                    if (occupieds.Sum() >= 5)
                    {
                        newConfiguration[i][j] = EMPTY;
                        configurationChange = true;
                    }
                    else
                    {
                        newConfiguration[i][j] = seatsConfiguration[i][j];
                    }
                }
                else
                {
                    newConfiguration[i][j] = seatsConfiguration[i][j];
                }

                return configurationChange;
            });
        }

        private long CommonTrunk(bool sample, Func<char[][], char[][], int, int, bool> checkSeats)
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
                        if (checkSeats(seatsConfiguration, newConfiguration, i, j))
                        {
                            isNewConfiguration = true;
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

        private int GetSurroundingEmptiness(char[][] seatsConfig, int i, int j)
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
    }
}
