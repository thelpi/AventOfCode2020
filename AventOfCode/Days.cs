using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AventOfCode
{
    public static class Days
    {
        // 91
        public static long Day17(bool firstPart, bool sample)
        {
            const int CYCLES_COUNT = 6;
            const int GRID_LENGTH = 25; // arbitrary; minimal for 8x8x8x8
            const char ONE_VALUE = '#';

            var content = GetContent(17, row => row.Select(v => v == ONE_VALUE ? 1 : 0).ToArray(), sample: sample).ToArray();

            if (firstPart)
            {
                // creates an empty grid
                var grid1 = Enumerable.Range(0, GRID_LENGTH)
                    .Select(_0 => Enumerable.Range(0, GRID_LENGTH)
                        .Select(_1 => Enumerable.Range(0, GRID_LENGTH)
                            .Select(_2 => 0)
                    .ToArray()).ToArray()).ToArray();

                // fills with puzzle in the middle (barely) of the grid
                var center1 = GRID_LENGTH / 2;
                for (int i = center1; i < center1 + content[0].Length; i++)
                {
                    for (int j = center1; j < center1 + content[0].Length; j++)
                    {
                        grid1[center1][i][j] = content[i - center1][j - center1];
                    }
                }

                // for each cycle
                for (int cycle = 0; cycle < CYCLES_COUNT; cycle++)
                {
                    var coordinatesToSwitch = new List<(int i, int j, int k)>();
                    // loops on each point
                    for (int i = 0; i < grid1.Length; i++)
                    {
                        for (int j = 0; j < grid1[i].Length; j++)
                        {
                            for (int k = 0; k < grid1[i][j].Length; k++)
                            {
                                // loops on every point around the current point
                                var count1 = 0;
                                for (int iAr = i - 1; iAr <= i + 1; iAr++)
                                {
                                    for (int jAr = j - 1; jAr <= j + 1; jAr++)
                                    {
                                        for (int kAr = k - 1; kAr <= k + 1; kAr++)
                                        {
                                            if (jAr == j && iAr == i && k == kAr)
                                            {
                                                // exclude current point
                                                continue;
                                            }
                                            else if (jAr < 0 || iAr < 0 || kAr < 0)
                                            {
                                                // exclude min border
                                                continue;
                                            }
                                            else if (jAr >= grid1[i].Length || iAr >= grid1.Length || kAr >= grid1[i][j].Length)
                                            {
                                                // exclude max border
                                                continue;
                                            }
                                            else if (grid1[iAr][jAr][kAr]== 1)
                                            {
                                                count1++;
                                            }
                                        }
                                    }
                                }
                                // Is "count1" apply to switch rules ?
                                if ((grid1[i][j][k] == 0 && count1 == 3) ||
                                    (grid1[i][j][k] == 1 && count1 != 3 && count1 != 2))
                                {
                                    coordinatesToSwitch.Add((i, j, k));
                                }
                            }
                        }
                    }
                    // reverse values
                    foreach (var (i, j, k) in coordinatesToSwitch)
                    {
                        grid1[i][j][k] = Math.Abs(grid1[i][j][k] - 1);
                    }
                }
                // sums every "1"
                return grid1.Sum(_0 => _0.Sum(_1 => _1.Sum()));
            }

            // creates an empty grid
            var grid2 = Enumerable.Range(0, GRID_LENGTH)
                .Select(_0 => Enumerable.Range(0, GRID_LENGTH)
                    .Select(_1 => Enumerable.Range(0, GRID_LENGTH)
                        .Select(_2 => Enumerable.Range(0, GRID_LENGTH)
                              .Select(_3 => 0)
                .ToArray()).ToArray()).ToArray()).ToArray();

            // fills with puzzle in the middle (barely) of the grid
            var center2 = GRID_LENGTH / 2;
            for (int i = center2; i < center2 + content[0].Length; i++)
            {
                for (int j = center2; j < center2 + content[0].Length; j++)
                {
                    grid2[center2][center2][i][j] = content[i - center2][j - center2];
                }
            }
            
            // for each cycle
            for (int cycle = 0; cycle < CYCLES_COUNT; cycle++)
            {
                var coordinatesToSwitch = new List<(int i, int j, int k, int l)>();
                // loops on each point
                for (int i = 0; i < grid2.Length; i++)
                {
                    for (int j = 0; j < grid2[i].Length; j++)
                    {
                        for (int k = 0; k < grid2[i][j].Length; k++)
                        {
                            for (int l = 0; l < grid2[i][j][k].Length; l++)
                            {
                                // loops on every point around the current point
                                var count1 = 0;
                                for (int iAr = i - 1; iAr <= i + 1; iAr++)
                                {
                                    for (int jAr = j - 1; jAr <= j + 1; jAr++)
                                    {
                                        for (int kAr = k - 1; kAr <= k + 1; kAr++)
                                        {
                                            for (int lAr = l - 1; lAr <= l + 1; lAr++)
                                            {
                                                if (jAr == j && iAr == i && k == kAr && lAr == l)
                                                {
                                                    // exclude current point
                                                    continue;
                                                }
                                                else if (jAr < 0 || iAr < 0 || kAr < 0 || lAr < 0)
                                                {
                                                    // exclude min border
                                                    continue;
                                                }
                                                else if (jAr >= grid2[i].Length || iAr >= grid2.Length || kAr >= grid2[i][j].Length || lAr >= grid2[i][j][k].Length)
                                                {
                                                    // exclude max border
                                                    continue;
                                                }
                                                else if (grid2[iAr][jAr][kAr][lAr] == 1)
                                                {
                                                    count1++;
                                                }
                                            }
                                        }
                                    }
                                }
                                // Is "count1" apply to switch rules ?
                                if ((grid2[i][j][k][l] == 0 && count1 == 3) ||
                                    (grid2[i][j][k][l] == 1 && count1 != 3 && count1 != 2))
                                {
                                    coordinatesToSwitch.Add((i, j, k, l));
                                }
                            }
                        }
                    }
                }
                // reverse values
                foreach (var (i, j, k, l) in coordinatesToSwitch)
                {
                    grid2[i][j][k][l] = Math.Abs(grid2[i][j][k][l] - 1);
                }
            }
            // sums every "1"
            return grid2.Sum(_0 => _0.Sum(_1 => _1.Sum(_2 => _2.Sum())));
        }

        // 116
        public static long Day16(bool firstPart)
        {
            var datas = GetContent(16, v => v, "\r\n\r\n");
            
            var myTicket = datas[1].Split("\r\n")[1].Split(",").Select(v => Convert.ToInt32(v)).ToList();
            var tickets = datas[2].Split("\r\n").Skip(1).Select(v => v.Split(",").Select(v2 => Convert.ToInt32(v2)).ToList()).ToList();
            var ranges = datas[0].Split("\r\n").Select(v =>
            {
                var withName = v.Split(": ");
                var name = withName[0];
                var bornes = withName[1].Split(" or ");
                var b1 = (Convert.ToInt32(bornes[0].Split("-")[0]), Convert.ToInt32(bornes[0].Split("-")[1]));
                var b2 = (Convert.ToInt32(bornes[1].Split("-")[0]), Convert.ToInt32(bornes[1].Split("-")[1]));
                return (name, b1, b2);
            }).ToList();

            long sum = 0;
            int iTicket = 0;
            var invalidTickets = new List<int>();
            foreach (var ticket in tickets)
            {
                foreach (var vv in ticket)
                {
                    bool isValid = false;
                    foreach (var (name, b1, b2) in ranges)
                    {
                        if ((vv >= b1.Item1 && vv <= b1.Item2)
                            || (vv >= b2.Item1 && vv <= b2.Item2))
                        {
                            isValid = true;
                        }
                    }
                    if (!isValid)
                    {
                        sum += vv;
                        invalidTickets.Add(iTicket);
                    }
                }
                iTicket++;
            }

            if (firstPart)
            {
                return sum;
            }

            invalidTickets.Sort();
            invalidTickets.Reverse();

            foreach (var it in invalidTickets)
            {
                tickets.RemoveAt(it);
            }

            tickets.Add(myTicket);
            var rangedIndex = new List<List<int>>();
            for (int i = 0; i < ranges.Count; i++)
            {
                var subList = new List<int>();
                foreach (var tt in tickets)
                {
                    subList.Add(tt[i]);
                }
                rangedIndex.Add(subList);
            }

            Dictionary<string, List<int>> matches = new Dictionary<string, List<int>>();
            foreach (var (name, b1, b2) in ranges)
            {
                List<int> iMatch = new List<int>();
                int currentRi = 0;
                foreach (var ri in rangedIndex)
                {
                    if (ri.All(vv => (vv >= b1.Item1 && vv <= b1.Item2)
                            || (vv >= b2.Item1 && vv <= b2.Item2)))
                    {
                        iMatch.Add(currentRi);
                    }
                    currentRi++;
                }
                matches.Add(name, iMatch);
            }

            matches = matches.OrderBy(kvp => kvp.Value.Count).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Dictionary<string, int> exhausted = new Dictionary<string, int>();
            int countii = matches.Count;
            for (int ii = 0; ii < countii; ii++)
            {
                var curKvp = matches.ElementAt(ii);
                var picked = curKvp.Value.First();
                exhausted.Add(curKvp.Key, picked);
                matches.All(locKvp =>
                {
                    locKvp.Value.Remove(picked);
                    return true;
                });
            }

            var myTicketInfo = new Dictionary<string, int>();
            foreach (var name in exhausted.Keys)
            {
                var index = exhausted[name];
                myTicketInfo.Add(name, myTicket[index]);
            }

            long result = 1;
            foreach (var key in myTicketInfo.Keys)
            {
                if (key.Contains("departure"))
                {
                    result *= myTicketInfo[key];
                }
            }

            return result;
        }

        // 28
        public static long Day15(bool firstPart, bool sample)
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
        public static long Day14(bool firstPart, bool sample)
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
        public static long Day13(bool firstPart, bool sample)
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

        // 120
        public static long Day12(bool partOne)
        {
            var instructions = GetContent(12, v => (v[0], Convert.ToInt32(v.Substring(1))));

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

            // initial value pt. 1
            var currentMoveType = coordinates.IndexOf(EAST);
            // initial values pt. 2
            (int, int) point = (10, 1);
            (int, int) move = (0, coordinates.Length - 1);

            foreach (var instruction in instructions)
            {
                var iType = instruction.Item1;
                var iMove = instruction.Item2;
                if (coordinates.Contains(iType))
                {
                    if (partOne)
                    {
                        coordinatesValues[coordinates.IndexOf(iType)] += iMove;
                    }
                    else
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
                }
                else if (iType == LEFT || iType == RIGHT)
                {
                    var newAngle = iMove / angleQuotient;
                    for (int i = 0; i < newAngle; i++)
                    {
                        if (partOne)
                        {
                            currentMoveType = iType == LEFT
                                ? (currentMoveType == 0 ? (coordinates.Length - 1) : currentMoveType - 1)
                                : (currentMoveType == (coordinates.Length - 1) ? 0 : currentMoveType + 1);
                        }
                        else
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
                }
                else if (iType == FORWARD)
                {
                    if (partOne)
                    {
                        coordinatesValues[currentMoveType] += iMove;
                    }
                    else
                    {
                        coordinatesValues[move.Item1] += point.Item1 * iMove;
                        coordinatesValues[move.Item2] += point.Item2 * iMove;
                    }
                }
            }

            return Math.Abs(coordinatesValues[1] - coordinatesValues[3])
                + Math.Abs(coordinatesValues[0] - coordinatesValues[2]);
        }

        // 289
        public static long Day11(bool partOne)
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
        public static long Day10(bool partOne)
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
        public static long Day09(long? badNumberFromFirstPart)
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
        public static long Day08()
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
        public static long Day07(bool partOne)
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
        public static long Day06()
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
        public static long Day05()
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
        public static long Day04()
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
        public static long Day03()
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
        public static long Day02()
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

        // 32
        public static long Day01(bool firstPart, bool sample)
        {
            const int SUM_EXPECT = 2020;

            var values = GetContent(1, v => Convert.ToInt32(v), sample: sample);

            for (int i = 0; i < values.Count - (firstPart ? 2 : 3); i++)
            {
                for (int j = i + 1; j < values.Count - (firstPart ? 1 : 2); j++)
                {
                    if (firstPart)
                    {
                        if (values[i] + values[j] == SUM_EXPECT)
                        {
                            return values[i] * values[j];
                        }
                    }
                    else
                    {
                        for (int k = j + 1; k < values.Count - 1; k++)
                        {
                            if (values[i] + values[j] + values[k] == SUM_EXPECT)
                            {
                                return values[i] * values[j] * values[k];
                            }
                        }
                    }
                }
            }

            return -1;
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
