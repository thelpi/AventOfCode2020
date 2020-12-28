using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 5: Binary Boarding
    /// </summary>
    public sealed class Day05 : DayBase
    {
        private const int ROW_MAX = 128;
        private const int COL_MAX = 8;
        private const char FRONT = 'F';
        private const char BACK = 'B';
        private const char LEFT = 'L';
        private const char RIGHT = 'R';

        public Day05() : base(5) { }

        public override long GetFirstPartResult(bool sample)
        {
            return GetBoardingIdList(sample).Max();
        }

        public override long GetSecondPartResult(bool sample)
        {
            var idList = GetBoardingIdList(sample);

            for (int i = idList.Max() - 1; i >= 0; i--)
            {
                if (!idList.Contains(i)
                    && idList.Contains(i - 1)
                    && idList.Contains(i + 1))
                {
                    return i;
                }
            }

            return -1;
        }

        private List<int> GetBoardingIdList(bool sample)
        {
            var boardList = GetContent(v => v, sample: sample);

            var idList = new List<int>();

            foreach (string board in boardList)
            {
                var rowIndex = GetIndex(board.Substring(0, COL_MAX - 1), ROW_MAX - 1, FRONT, BACK);
                var colIndex = GetIndex(board.Substring(COL_MAX - 1), COL_MAX - 1, LEFT, RIGHT);
                idList.Add((rowIndex * COL_MAX) + colIndex);
            }

            return idList;
        }

        private int GetIndex(string boardSequence,
            int initialMax, char firstHalfIndicator, char secondHalfIndicator)
        {
            (int Min, int Max) range = (0, initialMax);
            foreach (var sequenceElement in boardSequence)
            {
                int rangeHalf = (range.Max - range.Min) / 2;
                if (sequenceElement == firstHalfIndicator)
                {
                    range = (range.Min, range.Min + rangeHalf);
                }
                else if (sequenceElement == secondHalfIndicator)
                {
                    range = (range.Min + rangeHalf + 1, range.Max);
                }
            }
            return range.Min;
        }
    }
}
