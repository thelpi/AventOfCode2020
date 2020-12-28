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

        private char[][] _seatsConfig;
        private int _i;
        private int _j;
        private bool _extended;
        private int _emptyOccupedSwitch;

        public Day11() : base(11) { }

        public override long GetFirstPartResult(bool sample)
        {
            _extended = false;
            _emptyOccupedSwitch = EMPTY_OCCUPIED_SWITCH_1;
            return CommonTrunk(sample);
        }

        public override long GetSecondPartResult(bool sample)
        {
            _extended = true;
            _emptyOccupedSwitch = EMPTY_OCCUPIED_SWITCH_2;
            return CommonTrunk(sample);
        }

        private bool IsOccupied(int kInc, int lInc)
        {
            bool findOccupied = false;
            bool findEmpty = false;
            int k = _i + kInc;
            int l = _j + lInc;
            while (k >= 0 && l >= 0
                && k < _seatsConfig.Length && l < _seatsConfig[k].Length
                && !findOccupied && !findEmpty)
            {
                findOccupied = _seatsConfig[k][l] == OCCUPIED;
                findEmpty = !_extended || _seatsConfig[k][l] == EMPTY;
                k += kInc;
                l += lInc;
            }
            return findOccupied;
        }

        private long CommonTrunk(bool sample)
        {
            _seatsConfig = GetContent(v => v.ToArray(), sample: sample).ToArray();
            
            var isNewConfiguration = true;
            while (isNewConfiguration)
            {
                isNewConfiguration = false;
                var newConfiguration = new char[_seatsConfig.Length][];
                for (_i = 0; _i < _seatsConfig.Length; _i++)
                {
                    newConfiguration[_i] = new char[_seatsConfig[_i].Length];
                    for (_j = 0; _j < _seatsConfig[_i].Length; _j++)
                    {
                        char? switchTo = null;
                        if (_seatsConfig[_i][_j] == EMPTY
                            && GetSurroundingEmptiness() == EMPTY_COUNT_SWITCH)
                        {
                            switchTo = OCCUPIED;
                        }
                        else if (_seatsConfig[_i][_j] == OCCUPIED
                            && GetSurroundingEmptiness() <= _emptyOccupedSwitch)
                        {
                            switchTo = EMPTY;
                        }

                        if (switchTo.HasValue)
                        {
                            newConfiguration[_i][_j] = switchTo.Value;
                            isNewConfiguration = true;
                        }
                        else
                        {
                            newConfiguration[_i][_j] = _seatsConfig[_i][_j];
                        }
                    }
                }
                _seatsConfig = newConfiguration;
            }

            return _seatsConfig.Sum(seatsRow => seatsRow.Count(v => v == OCCUPIED));
        }

        private int GetSurroundingEmptiness()
        {
            return new[]
            {
                IsOccupied(-1, 0),
                IsOccupied(-1, 1),
                IsOccupied(0, 1),
                IsOccupied(1, 1),
                IsOccupied(1, 0),
                IsOccupied(1, -1),
                IsOccupied(0, -1),
                IsOccupied(-1, -1)
            }.Count(_ => !_);
        }
    }
}
