using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = DayTwelve(true);
            Console.WriteLine($"Result is {result}");
            System.Threading.Thread.Sleep(int.MaxValue);
        }

        // 28
        private static long DayFifteen(bool firstPart, bool sample)
        {
            var expectedQuotesCount = firstPart ? 2020 : 30000000;

            var quotes = GetContent(15, v => Convert.ToInt32(v), sample: sample);
            var initialQuotesCount = quotes.Count;

            var latestQuoteByValue = quotes
                .Take(quotes.Count - 1)
                .ToDictionary(v => v, v => quotes.IndexOf(v));

            for (int i = initialQuotesCount; i < expectedQuotesCount; i++)
            {
                var currentQuotedValue = quotes[i - 1];
                var isCurrentValueAlreadyQuoted = latestQuoteByValue.ContainsKey(currentQuotedValue);
                var currentQuotedLatestQuote = !isCurrentValueAlreadyQuoted
                    ? 0
                    : i - (latestQuoteByValue[currentQuotedValue] + 1);
                quotes.Add(currentQuotedLatestQuote);
                if (!isCurrentValueAlreadyQuoted)
                {
                    latestQuoteByValue.Add(currentQuotedValue, 0);
                }
                latestQuoteByValue[currentQuotedValue] = quotes.Count - 2;
            }

            return quotes.Last();
        }

        // 131
        private static long DayFourteen(bool firstPart, bool sample)
        {
            var datas = GetContent(14, v =>
            {
                var parts = v.Split("\r\n");
                var mask = parts[0].Replace("mask = ", "");
                var bytes = parts
                    .Skip(1)
                    .Select(p =>
                    {
                        var e1 = p.Split(" = ")[0].Replace("mem[", "").Replace("]", "");
                        var e2 = p.Split(" = ")[1];
                        return (Convert.ToInt64(e1), Convert.ToInt64(e2));
                    })
                    .ToList();

                return (mask, bytes);
            }, "\r\n\r\n", sample);

            const int SIZE_MASK = 36;

            var newDatas = new List<(string, List<(long, long)>)>();

            long GetIntFromBitArray(BitArray bitArray)
            {
                var array = new byte[8];
                bitArray.CopyTo(array, 0);
                return BitConverter.ToInt64(array, 0);
            }

            if (firstPart)
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    var (mask, bytes) = datas[i];
                    mask = new String(mask.Reverse().ToArray());
                    var newBytes = new List<(long, long)>();
                    foreach (var singleByteDatas in bytes)
                    {
                        byte[] bytesDatas = BitConverter.GetBytes(singleByteDatas.Item2);
                        var b = new BitArray(bytesDatas);
                        int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();

                        for (int j = 0; j < SIZE_MASK; j++)
                        {
                            if (mask[j] == '0')
                            {
                                bits[j] = 0;
                            }
                            else if (mask[j] == '1')
                            {
                                bits[j] = 1;
                            }
                        }

                        BitArray newBitArray = new BitArray(bits.Select(bb => bb == 1).ToArray());
                        
                        newBytes.Add((singleByteDatas.Item1, GetIntFromBitArray(newBitArray)));
                    }
                    newDatas.Add((mask, newBytes));
                }
            }
            else
            {
                foreach (var data in datas)
                {
                    var (mask, bytes) = data;
                    mask = new String(mask.Reverse().ToArray());
                    foreach (var singleByteDatas in bytes)
                    {
                        byte[] bytesDatas = BitConverter.GetBytes(singleByteDatas.Item1);
                        var b = new BitArray(bytesDatas);
                        int?[] bits = b.Cast<bool>().Select(bit => bit ? (int?)1 : 0).ToArray();

                        for (int j = 0; j < SIZE_MASK; j++)
                        {
                            if (mask[j] == 'X')
                            {
                                bits[j] = null;
                            }
                            else if (mask[j] == '1')
                            {
                                bits[j] = 1;
                            }
                        }

                        var allBits = new List<int?[]> { bits };
                        var countXToChange = bits.Count(bbb => !bbb.HasValue);
                        for (int k = 0; k < bits.Length; k++)
                        {
                            if (bits[k] != null)
                            {
                                continue;
                            }

                            var allBits2 = new List<int?[]>();
                            foreach (var albb in allBits)
                            {
                                int?[] bitZub0 = new int?[albb.Length];
                                int?[] bitZub1 = new int?[albb.Length];
                                albb.CopyTo(bitZub0, 0);
                                albb.CopyTo(bitZub1, 0);
                                bitZub0[k] = 0;
                                bitZub1[k] = 1;
                                allBits2.Add(bitZub0);
                                allBits2.Add(bitZub1);
                            }
                            allBits.Clear();
                            allBits.AddRange(allBits2);
                        }

                        allBits.RemoveAll(alb => alb.Contains(null));

                        var newVs = new List<(long, long)>();
                        foreach (var bi in allBits)
                        {
                            BitArray newBitArray = new BitArray(bi.Select(bb => bb == 1).ToArray());
                            long newKey = GetIntFromBitArray(newBitArray);
                            newVs.Add((newKey, singleByteDatas.Item2));
                        }
                        newDatas.Add((mask, newVs));
                    }
                }
            }

            var cleanedDatas = newDatas.SelectMany(kvp => kvp.ToTuple().Item2).ToList();

            var ccCleaner = cleanedDatas.GroupBy(kvp => kvp.Item1).Select(kvp => kvp.Last()).ToList();

            return ccCleaner.Sum(cccc => cccc.Item2);
        }

        // 79
        private static long DayThirteen(bool firstPart, bool sample)
        {
            var content = GetContent(13, v => v, sample: sample);

            if (firstPart)
            {
                var timestamp = Convert.ToInt32(content[0]);
                var buses1 = content[1].Split(",").Where(v => v != "x").Select(v => Convert.ToInt32(v)).ToList();

                var currentBast = -1;
                var busOk = -1;
                foreach (var bus in buses1)
                {
                    var ratio = timestamp / bus;
                    var fromRatio = bus * ratio;
                    if (fromRatio < timestamp)
                    {
                        fromRatio += bus;
                    }
                    if (currentBast == -1 || fromRatio < currentBast)
                    {
                        currentBast = fromRatio;
                        busOk = bus;
                    }
                }

                return (currentBast - timestamp) * busOk;
            }
            else
            {
                var buses2 = content[1].Split(",").Select(v => v == "x" ? null : (int?)Convert.ToInt32(v)).ToList();

                var busDataList = new List<(int modulo, int delta)>();
                var i = 0;
                foreach (var bus in buses2)
                {
                    if (bus.HasValue)
                    {
                        busDataList.Add((bus.Value, i));
                    }
                    i++;
                }

                var busDatas = busDataList.OrderByDescending(bd => bd.modulo).ToArray();

                long response = -1;
                
                long j = 1;
                while (response < 0)
                {
                    long addedToStart = 0;
                    bool atLeastOneNoMatch = false;
                    int iBus = 0;
                    while (!atLeastOneNoMatch && iBus < busDatas.Length)
                    {
                        if ((j + busDatas[iBus].delta) % busDatas[iBus].modulo == 0)
                        {
                            addedToStart += busDatas[iBus].modulo;
                        }
                        else
                        {
                            atLeastOneNoMatch = true;
                        }
                        iBus++;
                    }

                    if (atLeastOneNoMatch)
                    {
                        j += (addedToStart == 0 ? 1 : addedToStart);
                    }
                    else
                    {
                        response = j;
                    }
                }

                return response;
            }
        }

        // 297
        private static long DayTwelve(bool partOne)
        {
            var instructions = GetContent(12, v => (v[0], Convert.ToInt32(v.Substring(1))));

            int[] coordinatesValues = new int[4];
            string coordinates = "ESWN";

            if (partOne)
            {
                var wind = 0;

                foreach (var k in instructions)
                {
                    var nextWind = wind;
                    if (coordinates.Contains(k.Item1))
                    {
                        coordinatesValues[coordinates.IndexOf(k.Item1)] += k.Item2;
                    }
                    else if (k.Item1 == 'L')
                    {
                        var newV = k.Item2 / 90;
                        for (int i = 0; i < newV; i++)
                        {
                            switch (wind)
                            {
                                case 0:
                                    nextWind = 3;
                                    break;
                                case 3:
                                    nextWind = 2;
                                    break;
                                case 1:
                                    nextWind = 0;
                                    break;
                                case 2:
                                    nextWind = 1;
                                    break;
                            }
                            wind = nextWind;
                        }
                    }
                    else if (k.Item1 == 'R')
                    {
                        var newV2 = k.Item2 / 90;
                        for (int i = 0; i < newV2; i++)
                        {
                            switch (wind)
                            {
                                case 0:
                                    nextWind = 1;
                                    break;
                                case 3:
                                    nextWind = 0;
                                    break;
                                case 1:
                                    nextWind = 2;
                                    break;
                                case 2:
                                    nextWind = 3;
                                    break;
                            }
                            wind = nextWind;
                        }
                    }
                    else if (k.Item1 == 'F')
                    {
                        coordinatesValues[wind] += k.Item2;
                    }
                }
            }
            else
            {
                (int, int) currentPoint = (10, 1);
                (int, int) currentPointWind = (0, 3);

                foreach (var k in instructions)
                {
                    switch (k.Item1)
                    {
                        case 'N':
                            if (currentPointWind.Item2 == 3)
                            {
                                currentPoint = (currentPoint.Item1, currentPoint.Item2 + k.Item2);
                            }
                            else if (currentPointWind.Item2 == 1)
                            {
                                currentPoint = (currentPoint.Item1, currentPoint.Item2 - k.Item2);
                            }
                            else if (currentPointWind.Item1 == 3)
                            {
                                currentPoint = (currentPoint.Item1 + k.Item2, currentPoint.Item2);
                            }
                            else
                            {
                                currentPoint = (currentPoint.Item1 - k.Item2, currentPoint.Item2);
                            }
                            break;
                        case 'S':
                            if (currentPointWind.Item2 == 1)
                            {
                                currentPoint = (currentPoint.Item1, currentPoint.Item2 + k.Item2);
                            }
                            else if (currentPointWind.Item2 == 3)
                            {
                                currentPoint = (currentPoint.Item1, currentPoint.Item2 - k.Item2);
                            }
                            else if (currentPointWind.Item1 == 1)
                            {
                                currentPoint = (currentPoint.Item1 + k.Item2, currentPoint.Item2);
                            }
                            else
                            {
                                currentPoint = (currentPoint.Item1 - k.Item2, currentPoint.Item2);
                            }
                            break;
                        case 'E':
                            if (currentPointWind.Item2 == 0)
                            {
                                currentPoint = (currentPoint.Item1, currentPoint.Item2 + k.Item2);
                            }
                            else if (currentPointWind.Item2 == 2)
                            {
                                currentPoint = (currentPoint.Item1, currentPoint.Item2 - k.Item2);
                            }
                            else if (currentPointWind.Item1 == 0)
                            {
                                currentPoint = (currentPoint.Item1 + k.Item2, currentPoint.Item2);
                            }
                            else
                            {
                                currentPoint = (currentPoint.Item1 - k.Item2, currentPoint.Item2);
                            }
                            break;
                        case 'W':
                            if (currentPointWind.Item2 == 2)
                            {
                                currentPoint = (currentPoint.Item1, currentPoint.Item2 + k.Item2);
                            }
                            else if (currentPointWind.Item2 == 0)
                            {
                                currentPoint = (currentPoint.Item1, currentPoint.Item2 - k.Item2);
                            }
                            else if (currentPointWind.Item1 == 2)
                            {
                                currentPoint = (currentPoint.Item1 + k.Item2, currentPoint.Item2);
                            }
                            else
                            {
                                currentPoint = (currentPoint.Item1 - k.Item2, currentPoint.Item2);
                            }
                            break;
                        case 'L':
                            var newV = k.Item2 / 90;
                            for (int i = 0; i < newV; i++)
                            {
                                if (currentPointWind.Item1 == 0)
                                {
                                    currentPointWind = (3, currentPointWind.Item2);
                                }
                                else if (currentPointWind.Item1 == 1)
                                {
                                    currentPointWind = (0, currentPointWind.Item2);
                                }
                                else if (currentPointWind.Item1 == 3)
                                {
                                    currentPointWind = (2, currentPointWind.Item2);
                                }
                                else if (currentPointWind.Item1 == 2)
                                {
                                    currentPointWind = (1, currentPointWind.Item2);
                                }

                                if (currentPointWind.Item2 == 0)
                                {
                                    currentPointWind = (currentPointWind.Item1, 3);
                                }
                                else if (currentPointWind.Item2 == 1)
                                {
                                    currentPointWind = (currentPointWind.Item1, 0);
                                }
                                else if (currentPointWind.Item2 == 3)
                                {
                                    currentPointWind = (currentPointWind.Item1, 2);
                                }
                                else if (currentPointWind.Item2 == 2)
                                {
                                    currentPointWind = (currentPointWind.Item1, 1);
                                }
                            }
                            break;
                        case 'R':
                            var newV2 = k.Item2 / 90;
                            for (int i = 0; i < newV2; i++)
                            {
                                if (currentPointWind.Item1 == 0)
                                {
                                    currentPointWind = (1, currentPointWind.Item2);
                                }
                                else if (currentPointWind.Item1 == 1)
                                {
                                    currentPointWind = (2, currentPointWind.Item2);
                                }
                                else if (currentPointWind.Item1 == 3)
                                {
                                    currentPointWind = (0, currentPointWind.Item2);
                                }
                                else if (currentPointWind.Item1 == 2)
                                {
                                    currentPointWind = (3, currentPointWind.Item2);
                                }

                                if (currentPointWind.Item2 == 0)
                                {
                                    currentPointWind = (currentPointWind.Item1, 1);
                                }
                                else if (currentPointWind.Item2 == 1)
                                {
                                    currentPointWind = (currentPointWind.Item1, 2);
                                }
                                else if (currentPointWind.Item2 == 3)
                                {
                                    currentPointWind = (currentPointWind.Item1, 0);
                                }
                                else if (currentPointWind.Item2 == 2)
                                {
                                    currentPointWind = (currentPointWind.Item1, 3);
                                }
                            }
                            break;
                        case 'F':
                            if (currentPointWind.Item1 == 0)
                            {
                                coordinatesValues[0] += currentPoint.Item1 * k.Item2;
                            }
                            else if (currentPointWind.Item1 == 2)
                            {
                                coordinatesValues[2] += currentPoint.Item1 * k.Item2;
                            }
                            else if (currentPointWind.Item1 == 3)
                            {
                                coordinatesValues[3] += currentPoint.Item1 * k.Item2;
                            }
                            else if (currentPointWind.Item1 == 1)
                            {
                                coordinatesValues[1] += currentPoint.Item1 * k.Item2;
                            }
                            if (currentPointWind.Item2 == 0)
                            {
                                coordinatesValues[0] += currentPoint.Item2 * k.Item2;
                            }
                            else if (currentPointWind.Item2 == 2)
                            {
                                coordinatesValues[2] += currentPoint.Item2 * k.Item2;
                            }
                            else if (currentPointWind.Item2 == 3)
                            {
                                coordinatesValues[3] += currentPoint.Item2 * k.Item2;
                            }
                            else if (currentPointWind.Item2 == 1)
                            {
                                coordinatesValues[1] += currentPoint.Item2 * k.Item2;
                            }
                            break;
                    }
                }
            }

            return Math.Abs(coordinatesValues[1] - coordinatesValues[3])
                + Math.Abs(coordinatesValues[0] - coordinatesValues[2]);
        }

        // 290
        private static long DayEleven(bool partOne)
        {
            var datas = GetContent(11, v => v.ToArray()).ToArray();

            if (partOne)
            {
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

        // 117
        private static long DayTen(bool partOne)
        {
            var datas = GetContent(10, v => Convert.ToInt32(v));

            datas.Add(0);
            datas.Add(datas.Max() + 3);

            datas.Sort();

            // exercice 1
            if (partOne)
            {
                int voltage = 0;
                bool found = true;
                var spreadCount = new Dictionary<int, int>
                {
                    { 1, 0 },
                    { 2, 0 },
                    { 3, 0 }
                };
                while (found)
                {
                    var matches = datas.Where(x => x > voltage && x <= voltage + 3).ToList();
                    if (matches.Count > 0)
                    {
                        var nextVoltage = matches.Min();
                        spreadCount[nextVoltage - voltage]++;
                        voltage = nextVoltage;
                    }
                    found = matches.Count > 0;
                }
                spreadCount[3]++;

                var total = spreadCount[1] * spreadCount[3];

                return total;
            }

            List<List<int>> splitBy3 = new List<List<int>>();
            var subList = new List<int>();
            int current = 0;
            foreach (var d in datas)
            {
                if (d - current == 3)
                {
                    splitBy3.Add(new List<int>(subList));
                    subList = new List<int>();
                }
                subList.Add(d);
                current = d;
            }

            void Calculate(List<int> baseList, List<List<int>> listToAdd, List<int> currentIteration, int currentIndex, int currentCount, int countofSubGroup)
            {
                if (currentCount == countofSubGroup)
                {
                    listToAdd.Add(new List<int>(currentIteration));
                    return;
                }

                if (currentIndex >= baseList.Count)
                    return;

                currentIteration.Add(baseList[currentIndex]);
                Calculate(baseList, listToAdd, currentIteration, currentIndex + 1, currentCount + 1, countofSubGroup);
                currentIteration.Remove(baseList[currentIndex]);


                Calculate(baseList, listToAdd, currentIteration, currentIndex + 1, currentCount, countofSubGroup);

            }

            Dictionary<List<int>, int> combosCount = splitBy3.ToDictionary(v => v, v => 0);
            var keys = combosCount.Keys.ToList();

            foreach (var combo in keys)
            {
                var subgroups = new List<List<int>>();
                for (int i = 1; i <= combo.Count; i++)
                {
                    Calculate(combo, subgroups, new List<int>(), 0, 0, i);
                }

                var count = 0;
                foreach (var subgroup in subgroups)
                {
                    if (!subgroup.Contains(combo[0]) || !subgroup.Contains(combo.Last()))
                    {
                        continue;
                    }

                    bool breakNotGood = false;
                    for (int i = 1; i < subgroup.Count; i++)
                    {
                        if (subgroup[i] - subgroup[i - 1] > 3)
                        {
                            breakNotGood = true;
                            break;
                        }
                    }
                    if (!breakNotGood)
                    {
                        count++;
                    }
                }

                combosCount[combo] = count;
            }

            long total2 = 1;
            foreach (var combo in combosCount.Keys)
            {
                total2 = total2 * combosCount[combo];
            }

            return total2;
        }

        // 68
        private static long DayNine(long? badNumberFromFirstPart)
        {
            var datas = GetContent(9, v => Convert.ToInt64(v));

            if (!badNumberFromFirstPart.HasValue)
            {
                bool ok = true;
                int i = 25;
                int skip = 0;
                long mark = -1;
                while (ok)
                {
                    var last25 = datas.Skip(skip).Take(25).ToList();

                    bool found = false;
                    for (int j = 0; j < 25; j++)
                    {
                        for (int k = 0; k < 25; k++)
                        {
                            if (last25[j] != last25[k])
                            {
                                if (last25[j] + last25[k] == datas[i])
                                {
                                    found = true;
                                }
                            }
                        }
                    }

                    ok = found;
                    mark = datas[i];
                    i++;
                    skip++;
                }

                return mark;
            }

            // second part
            // I DONT REMEMBER THE POINT OF THIS LOOP
            for (int i = 0; i < datas.Count; i++)
            {
                if (datas[i] == badNumberFromFirstPart.Value)
                {
                    continue;
                }

                long currentMax = 0;
                int j = i;
                while (currentMax < badNumberFromFirstPart.Value)
                {
                    currentMax += datas[j];
                    j++;
                }
                if (currentMax == badNumberFromFirstPart.Value)
                {

                }
            }

            // I DONT REMEMBER WHERE 400 AND 17 COMES FROM
            var ranged = datas.Skip(400).Take(17).ToList();
            var sum = ranged.Sum();
            var min = ranged.Min();
            var max = ranged.Max();

            return min + max;
        }

        // 73
        private static long DayEight()
        {
            var instructions = GetContent(8, v =>
                (v.Split(' ')[0], Convert.ToInt32(v.Split(' ')[1].Replace("+", ""))));

            var realAccumulateur = -1;

            bool realEnding = false;
            for (int j = 0; j < instructions.Count; j++)
            {
                var localInstructions = new List<(string, int)>(instructions);

                var ij = instructions[j];

                (string, int) newInstruction = ("", 0);
                if (ij.Item1 == "acc")
                {
                    continue;
                }
                else if (ij.Item1 == "nop")
                {
                    if (j + ij.Item2 < 0)
                    {
                        continue;
                    }
                    newInstruction = ("jmp", ij.Item2);
                }
                else if (instructions[j].Item1 == "jmp")
                {
                    newInstruction = ("nop", ij.Item2);
                }

                localInstructions[j] = newInstruction;

                int previousI = 0;
                int i = 0;
                List<int> passed = new List<int>();
                var accumulateur = 0;
                var stop = passed.Contains(i);
                while (!stop)
                {
                    passed.Add(i);
                    switch (localInstructions[i].Item1)
                    {
                        case "nop":
                            previousI = i;
                            i += 1;
                            break;
                        case "acc":
                            accumulateur += localInstructions[i].Item2;
                            previousI = i;
                            i += 1;
                            break;
                        case "jmp":
                            previousI = i;
                            i += localInstructions[i].Item2;
                            break;
                        default:
                            break;
                    }
                    realEnding = i == localInstructions.Count;
                    stop = passed.Contains(i) || realEnding;
                }

                if (realEnding)
                {
                    realAccumulateur = accumulateur;
                    break;
                }
            }

            return realAccumulateur;
        }

        // 78
        private static long DaySeven(bool partOne)
        {
            var datas = GetContent(7, v => v, ".\r\n");

            var finalList = new Dictionary<string, List<(int, string)>>();

            foreach (var d in datas)
            {
                var sub = d.Split(" bags contain ");

                List<(int, string)> subBags = new List<(int qty, string val)>();
                finalList.Add(sub[0], subBags);

                foreach (var dd in sub[1].Split(new[] { " bags, ", " bag, " }, StringSplitOptions.None))
                {
                    if (dd != "no other bags")
                    {
                        var ddd = dd.Split(' ');
                        var vall = string.Join(" ", ddd.Skip(1));
                        if (vall.EndsWith(" bags"))
                        {
                            vall = vall.Substring(0, vall.Length - 5);
                        }
                        else if (vall.EndsWith(" bag"))
                        {
                            vall = vall.Substring(0, vall.Length - 4);
                        }
                        subBags.Add((Convert.ToInt32(ddd[0]), vall));
                    }
                    else
                    {

                    }
                }
            }

            if (partOne)
            {
                // part one
                void RecursiveSearchUp(Dictionary<string, List<(int, string)>> baseList,
                    string search, List<string> finaLList)
                {
                    List<string> bagsWithSearch = baseList.Where(kvp => kvp.Value.Any(v => v.Item2 == search)).Select(kvp => kvp.Key).ToList();
                    finaLList.AddRange(bagsWithSearch);
                    foreach (var bagWithSearch in bagsWithSearch)
                    {
                        RecursiveSearchUp(baseList, bagWithSearch, finaLList);
                    }
                }

                List<string> foundList = new List<string>();
                RecursiveSearchUp(finalList, "shiny gold", foundList);

                var count = foundList.Distinct().Count();

                return count;
            }

            // part two
            void RecursiveSearchDown(Dictionary<string, List<(int, string)>> baseList,
            string search, List<(int, string)> finaLList)
            {
                var vals = baseList.Where(kvp => kvp.Key == search).SelectMany(kvp => kvp.Value).ToList();
                finaLList.AddRange(vals);
                foreach (var val in vals)
                {
                    for (int i = 0; i < val.Item1; i++)
                    {
                        RecursiveSearchDown(baseList, val.Item2, finaLList);
                    }
                }
            }

            var foundList2 = new List<(int, string)>();
            RecursiveSearchDown(finalList, "shiny gold", foundList2);

            return foundList2.Sum(kvp => kvp.Item1);
        }

        // 17
        private static long DaySix()
        {
            var byGroupByPeople = GetContent(6, v => v.Split("\r\n").ToList(), "\r\n\r\n");

            var yesCount = 0;

            foreach (var group in byGroupByPeople)
            {
                var datasGroup = group.SelectMany(g => g).ToList();

                var result = datasGroup.GroupBy(k => k).Where(k => k.Count() == group.Count);

                yesCount += result.Count();
            }

            return yesCount;
        }

        // 67
        private static long DayFive()
        {
            var list = GetContent(5, v => v);

            var ids = new List<int>();

            foreach (string board in list)
            {
                string rowInfo = board.Substring(0, 7);
                string colInfo = board.Substring(7);

                (int, int) rangeRow = (0, 127);
                (int, int) rangeCol = (0, 7);

                foreach (var c in rowInfo)
                {
                    int currentHalf = (rangeRow.Item2 - rangeRow.Item1) / 2;
                    if (c == 'F')
                    {
                        rangeRow = (rangeRow.Item1, rangeRow.Item1 + currentHalf);
                    }
                    else if (c == 'B')
                    {
                        rangeRow = (rangeRow.Item1 + currentHalf + 1, rangeRow.Item2);
                    }
                    else
                    {

                    }
                }

                foreach (var c in colInfo)
                {
                    int currentHalf = (rangeCol.Item2 - rangeCol.Item1) / 2;
                    if (c == 'L')
                    {
                        rangeCol = (rangeCol.Item1, rangeCol.Item1 + currentHalf);
                    }
                    else if (c == 'R')
                    {
                        rangeCol = (rangeCol.Item1 + currentHalf + 1, rangeCol.Item2);
                    }
                    else
                    {

                    }
                }

                ids.Add((rangeRow.Item1 * 8) + rangeCol.Item1);
            }

            var max = ids.Max();

            var match = -1;
            for (int i = 0; i < max; i++)
            {
                if (!ids.Contains(i))
                {
                    if (ids.Contains(i - 1) && ids.Contains(i + 1))
                    {
                        match = i;
                    }
                }
            }

            return match;
        }

        // 136
        private static long DayFour()
        {
            var codes = new string[]
            {
                "byr", "iyr", "eyr", "hgt",
                "hcl", "ecl", "pid"
            };

            var passports = GetContent(4, v => v.Replace("\r\n", " "), "\r\n\r\n");

            int passportsValid = 0;
            foreach (var passport in passports)
            {
                var kpvList = new Dictionary<string, string>();
                foreach (var p in passport.Split(' '))
                {
                    var split = p.Split(':');
                    kpvList.Add(split[0].ToLowerInvariant(), split[1].ToLowerInvariant());
                }
                if (codes.All(c => kpvList.ContainsKey(c)))
                {
                    bool invalid = false;
                    foreach (var c in codes)
                    {
                        var v = kpvList[c];
                        switch (c)
                        {
                            case "byr":
                                if (int.TryParse(v, out int byrReal))
                                {
                                    if (byrReal < 1920 || byrReal > 2002)
                                    {
                                        invalid = true;
                                    }
                                }
                                else
                                {
                                    invalid = true;
                                }
                                break;
                            case "iyr":
                                if (int.TryParse(v, out int iyrReal))
                                {
                                    if (iyrReal < 2010 || iyrReal > 2020)
                                    {
                                        invalid = true;
                                    }
                                }
                                else
                                {
                                    invalid = true;
                                }
                                break;
                            case "eyr":
                                if (int.TryParse(v, out int eyrReal))
                                {
                                    if (eyrReal < 2020 || eyrReal > 2030)
                                    {
                                        invalid = true;
                                    }
                                }
                                else
                                {
                                    invalid = true;
                                }
                                break;
                            case "hgt":
                                if (v.EndsWith("cm"))
                                {
                                    v = v.Substring(0, v.Length - 2);
                                    if (!int.TryParse(v, out int heightCm))
                                    {
                                        invalid = true;
                                    }
                                    else if (heightCm < 150 || heightCm > 193)
                                    {
                                        invalid = true;
                                    }
                                }
                                else if (v.EndsWith("in"))
                                {
                                    v = v.Substring(0, v.Length - 2);
                                    if (!int.TryParse(v, out int heightIn))
                                    {
                                        invalid = true;
                                    }
                                    else if (heightIn < 59 || heightIn > 76)
                                    {
                                        invalid = true;
                                    }
                                }
                                else
                                {
                                    invalid = true;
                                }
                                break;
                            case "hcl":
                                if (!v.StartsWith("#") || v.Length != 7)
                                {
                                    invalid = true;
                                }
                                else
                                {
                                    v = v.Substring(1, 6);
                                    var expected = "0123456789abcdef";
                                    if (!v.All(charr => expected.Contains(charr)))
                                    {
                                        invalid = true;
                                    }
                                }
                                break;
                            case "ecl":
                                string[] expectedd = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                if (!expectedd.Contains(v))
                                {
                                    invalid = true;
                                }
                                break;
                            case "pid":
                                var expecteddd = "0123456789";
                                if (v.Length != 9 || !v.All(chardd => expecteddd.Contains(chardd)))
                                {
                                    invalid = true;
                                }
                                break;
                        }
                    }
                    if (!invalid)
                    {
                        passportsValid++;
                    }
                }
            }

            return passportsValid;
        }

        // 38
        private static long DayThree()
        {
            var fullList = GetContent(3, v => v.ToArray().Select(subV => subV == '#' ? 1 : 0).ToList());

            var combos = new List<(int right, int down)>
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2),
            };
            long treeMultiply = 1;

            foreach (var (right, down) in combos)
            {
                int treeCount = 0;
                int currentRight = 0;
                int lastIndexByRow = fullList[0].Count - 1;
                for (int i = 0; i < fullList.Count; i += down)
                {
                    if (fullList[i][currentRight] == 1)
                    {
                        treeCount++;
                    }
                    currentRight += right;
                    var diffRight = lastIndexByRow - currentRight;
                    if (diffRight < 0)
                    {
                        currentRight = Math.Abs(diffRight) - 1;
                    }
                }

                treeMultiply *= treeCount;
            }

            return treeMultiply;
        }

        // 33
        private static long DayTwo()
        {
            var baseList = GetContent(2, v => v);

            var tuples = new List<(int min, int max, char car, string val)>();
            foreach (var l in baseList)
            {
                var splitted = l.Split(new[] { ' ' });
                var min = Convert.ToInt32(splitted[0].Split('-')[0]);
                var max = Convert.ToInt32(splitted[0].Split('-')[1]);
                var car = splitted[1][0];
                var val = splitted[2];
                tuples.Add((min, max, car, val));
            }

            int countValid = 0;
            foreach (var (min, max, car, val) in tuples)
            {
                if (
                    (val[min - 1] == car && val[max - 1] != car)
                    || (val[min - 1] != car && val[max - 1] == car))
                {
                    countValid++;
                }
                /*var countChar = val.Count(c => c == car);
                if (countChar >= min && countChar <= max)
                {
                    countValid++;
                }*/
            }

            return countValid;
        }

        // 22
        private static long DayOne()
        {
            var values = GetContent(1, v => Convert.ToInt32(v));

            var response = -1;

            for (int i = 0; i < values.Count - 3; i++)
            {
                for (int j = i + 1; j < values.Count - 2; j++)
                {
                    for (int k = j + 1; k < values.Count - 1; k++)
                    {
                        if (values[i] + values[j] + values[k] == 2020)
                        {
                            response = values[i] * values[j] * values[k];
                        }
                    }
                }
            }

            return response;
        }

        private static List<T> GetContent<T>(int day,
            Func<string, T> converter,
            string separator = "\r\n",
            bool sample = false)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                $"Datas\\{(sample ? "Samples\\" : string.Empty)}{day.ToString().PadLeft(2, '0')}.txt");
            string[] datas;
            using (var rd = new StreamReader(path))
            {
                datas = rd.ReadToEnd().Split(separator);
            }

            return datas.Select(v => converter(v)).ToList();
        }
    }
}
