using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 11: Seating System
    /// </summary>
    public sealed class Day11 : DayBase
    {
        public Day11() : base(11) { }

        public override long GetFirstPartResult(bool sample)
        {
            var datas = GetContent(v => v.ToArray(), sample: sample).ToArray();

            char[][] good1 = null;
            while (good1 == null)
            {
                bool change = false;
                var newDatas = new char[datas.Length][];
                for (int i = 0; i < datas.Length; i++)
                {
                    newDatas[i] = new char[datas[i].Length];
                    for (int j = 0; j < datas[i].Length; j++)
                    {
                        if (datas[i][j] == 'L')
                        {
                            var top =
                                i == 0
                                || datas[i - 1][j] == 'L'
                                || datas[i - 1][j] == '.'
                                    ? 1 : 0;
                            var top_right =
                                i == 0
                                || j + 1 == datas[i].Length
                                || datas[i - 1][j + 1] == 'L'
                                || datas[i - 1][j + 1] == '.'
                                    ? 1 : 0;
                            var right =
                                j + 1 == datas[i].Length
                                || datas[i][j + 1] == 'L'
                                || datas[i][j + 1] == '.'
                                    ? 1 : 0;
                            var bottom_right =
                                i + 1 == datas.Length
                                || j + 1 == datas[i].Length
                                || datas[i + 1][j + 1] == 'L'
                                || datas[i + 1][j + 1] == '.'
                                    ? 1 : 0;
                            var bottom =
                                i + 1 == datas.Length
                                || datas[i + 1][j] == 'L'
                                || datas[i + 1][j] == '.'
                                    ? 1 : 0;
                            var bottom_left =
                                i + 1 == datas.Length
                                || j == 0
                                || datas[i + 1][j - 1] == 'L'
                                || datas[i + 1][j - 1] == '.'
                                    ? 1 : 0;
                            var left =
                                j == 0
                                || datas[i][j - 1] == 'L'
                                || datas[i][j - 1] == '.'
                                    ? 1 : 0;
                            var top_left =
                                i == 0
                                || j == 0
                                || datas[i - 1][j - 1] == 'L'
                                || datas[i - 1][j - 1] == '.'
                                    ? 1 : 0;
                            if (top + top_right + right + bottom_right + bottom + bottom_left + left + top_left == 8)
                            {
                                newDatas[i][j] = '#';
                                change = true;
                            }
                            else
                            {
                                newDatas[i][j] = datas[i][j];
                            }
                        }
                        else if (datas[i][j] == '#')
                        {
                            var top =
                                 i != 0
                                 && datas[i - 1][j] == '#'
                                     ? 1 : 0;
                            var top_right =
                                i != 0
                                && j + 1 != datas[i].Length
                                && datas[i - 1][j + 1] == '#'
                                    ? 1 : 0;
                            var right =
                                j + 1 != datas[i].Length
                                && datas[i][j + 1] == '#'
                                    ? 1 : 0;
                            var bottom_right =
                                i + 1 != datas.Length
                                && j + 1 != datas[i].Length
                                && datas[i + 1][j + 1] == '#'
                                    ? 1 : 0;
                            var bottom =
                                i + 1 != datas.Length
                                && datas[i + 1][j] == '#'
                                    ? 1 : 0;
                            var bottom_left =
                                i + 1 != datas.Length
                                && j != 0
                                && datas[i + 1][j - 1] == '#'
                                    ? 1 : 0;
                            var left =
                                j != 0
                                && datas[i][j - 1] == '#'
                                    ? 1 : 0;
                            var top_left =
                                i != 0
                                && j != 0
                                && datas[i - 1][j - 1] == '#'
                                    ? 1 : 0;
                            if (top + top_right + right + bottom_right + bottom + bottom_left + left + top_left >= 4)
                            {
                                newDatas[i][j] = 'L';
                                change = true;
                            }
                            else
                            {
                                newDatas[i][j] = datas[i][j];
                            }
                        }
                        else
                        {
                            newDatas[i][j] = datas[i][j];
                        }
                    }
                }
                if (!change)
                {
                    good1 = datas;
                }
                else
                {
                    datas = newDatas;
                }
            }

            return good1.Sum(g => g.Sum(v => v == '#' ? 1 : 0));
        }

        public override long GetSecondPartResult(bool sample)
        {
            var datas = GetContent(v => v.ToArray(), sample: sample).ToArray();

            char[][] good = null;
            while (good == null)
            {
                bool change = false;
                var newDatas = new char[datas.Length][];
                for (int i = 0; i < datas.Length; i++)
                {
                    newDatas[i] = new char[datas[i].Length];
                    for (int j = 0; j < datas[i].Length; j++)
                    {
                        List<int> occupieds = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };

                        bool findOccupied = false;
                        bool findEmpty = false;
                        int k = i - 1;
                        while (k >= 0 && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][j] == '#';
                            findEmpty = datas[k][j] == 'L';
                            k--;
                        }
                        occupieds[0] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        k = i - 1;
                        var l = j + 1;
                        while (k >= 0 && l < datas[i].Length && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][l] == '#';
                            findEmpty = datas[k][l] == 'L';
                            k--;
                            l++;
                        }
                        occupieds[1] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        l = j + 1;
                        while (l < datas[i].Length && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[i][l] == '#';
                            findEmpty = datas[i][l] == 'L';
                            l++;
                        }
                        occupieds[2] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        k = i + 1;
                        l = j + 1;
                        while (k < datas.Length && l < datas[i].Length && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][l] == '#';
                            findEmpty = datas[k][l] == 'L';
                            k++;
                            l++;
                        }
                        occupieds[3] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        k = i + 1;
                        while (k < datas.Length && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][j] == '#';
                            findEmpty = datas[k][j] == 'L';
                            k++;
                        }
                        occupieds[4] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        k = i + 1;
                        l = j - 1;
                        while (k < datas.Length && l >= 0 && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][l] == '#';
                            findEmpty = datas[k][l] == 'L';
                            k++;
                            l--;
                        }
                        occupieds[5] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        l = j - 1;
                        while (l >= 0 && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[i][l] == '#';
                            findEmpty = datas[i][l] == 'L';
                            l--;
                        }
                        occupieds[6] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        k = i - 1;
                        l = j - 1;
                        while (k >= 0 && l >= 0 && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][l] == '#';
                            findEmpty = datas[k][l] == 'L';
                            k--;
                            l--;
                        }
                        occupieds[7] = findOccupied ? 1 : 0;

                        if (datas[i][j] == 'L')
                        {
                            if (occupieds.Sum() == 0)
                            {
                                newDatas[i][j] = '#';
                                change = true;
                            }
                            else
                            {
                                newDatas[i][j] = datas[i][j];
                            }
                        }
                        else if (datas[i][j] == '#')
                        {
                            if (occupieds.Sum() >= 5)
                            {
                                newDatas[i][j] = 'L';
                                change = true;
                            }
                            else
                            {
                                newDatas[i][j] = datas[i][j];
                            }
                        }
                        else
                        {
                            newDatas[i][j] = datas[i][j];
                        }
                    }
                }
                if (!change)
                {
                    good = datas;
                }
                else
                {
                    datas = newDatas;
                }
            }

            return good.Sum(g => g.Sum(v => v == '#' ? 1 : 0));
        }
    }
}
