using System;
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
        private const int EMPTY_COUNT_SWITCH = 8;
        private const int EMPTY_OCCUPIED_SWITCH_1 = 4;
        private const int EMPTY_OCCUPIED_SWITCH_2 = 3;

        public Day11() : base(11) { }

        public override long GetFirstPartResult(bool sample)
        {
            return CommonTrunk(sample, GetDirectSurroundingEmptiness, EMPTY_OCCUPIED_SWITCH_1);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CommonTrunk(sample, GetDeepSurroundingEmptiness, EMPTY_OCCUPIED_SWITCH_2);
        }

        private long CommonTrunk(bool sample,
            Func<char[][], int, int, int> countEmptinessCallback,
            int occupiedCountToSwitch)
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
                        char? switchTo = null;
                        if (seatsConfiguration[i][j] == EMPTY
                            && countEmptinessCallback(seatsConfiguration, i, j) == EMPTY_COUNT_SWITCH)
                        {
                            switchTo = OCCUPIED;
                        }
                        else if (seatsConfiguration[i][j] == OCCUPIED
                            && countEmptinessCallback(seatsConfiguration, i, j) <= occupiedCountToSwitch)
                        {
                            switchTo = EMPTY;
                        }

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

        private bool OccupiedDirect(char[][] seatsConfig, int k, int l, int kInc, int lInc)
        {
            return (k + kInc) >= 0
                && (l + lInc) >= 0
                && (k + kInc) < seatsConfig.Length
                && (l + lInc) < seatsConfig[(k + kInc)].Length
                && seatsConfig[(k + kInc)][(l + lInc)] == OCCUPIED;
        }

        private int GetDirectSurroundingEmptiness(char[][] seatsConfig, int i, int j)
        {
            return new[]
            {
                OccupiedDirect(seatsConfig, i, j, -1, 0),
                OccupiedDirect(seatsConfig, i, j, -1, 1),
                OccupiedDirect(seatsConfig, i, j, 0, 1),
                OccupiedDirect(seatsConfig, i, j, 1, 1),
                OccupiedDirect(seatsConfig, i, j, 1, 0),
                OccupiedDirect(seatsConfig, i, j, 1, -1),
                OccupiedDirect(seatsConfig, i, j, 0, -1),
                OccupiedDirect(seatsConfig, i, j, -1, -1)
            }.Count(_ => !_);
        }

        private bool OccupiedDeep(char[][] seatsConfig, int k, int l, int kInc, int lInc)
        {
            bool findOccupied = false;
            bool findEmpty = false;
            k += kInc;
            l += lInc;
            while (k >= 0 && l >= 0
                && k < seatsConfig.Length && l < seatsConfig[k].Length
                && !findOccupied && !findEmpty)
            {
                findOccupied = seatsConfig[k][l] == OCCUPIED;
                findEmpty = seatsConfig[k][l] == EMPTY;
                k += kInc;
                l += lInc;
            }
            return findOccupied;
        }

        private int GetDeepSurroundingEmptiness(char[][] seatsConfig, int i, int j)
        {
            return new[]
            {
                OccupiedDeep(seatsConfig, i, j, -1, 0),
                OccupiedDeep(seatsConfig, i, j, -1, 1),
                OccupiedDeep(seatsConfig, i, j, 0, 1),
                OccupiedDeep(seatsConfig, i, j, 1, 1),
                OccupiedDeep(seatsConfig, i, j, 1, 0),
                OccupiedDeep(seatsConfig, i, j, 1, -1),
                OccupiedDeep(seatsConfig, i, j, 0, -1),
                OccupiedDeep(seatsConfig, i, j, -1, -1)
            }.Count(_ => !_);
        }
    }
}
