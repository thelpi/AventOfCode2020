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
        // 184
        public static long Day24(bool firstPart, bool sample)
        {
            var datas = GetContent(24, v => v, sample: sample);

            var instructions = new List<List<string>>();
            foreach (var data in datas)
            {
                var instructionsLine = new List<string>();
                var k = 0;
                while (k < data.Length)
                {
                    if (data[k] == 's' || data[k] == 'n')
                    {
                        instructionsLine.Add(new string(data.Skip(k).Take(2).ToArray()));
                        k++;
                    }
                    else
                    {
                        instructionsLine.Add(data[k].ToString());
                    }
                    k++;
                }
                instructions.Add(instructionsLine);
            }

            const int middle = 20000;

            var tiles = new bool[middle * 2][];
            for (var i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new bool[middle * 2];
            }

            var iMin = middle;
            var iMax = middle;
            var jMin = middle;
            var jMax = middle;

            var iCurrent = middle;
            var jCurrent = middle;
            foreach (var instructionsLine in instructions)
            {
                foreach (var instruction in instructionsLine)
                {
                    switch (instruction)
                    {
                        case "sw":
                            iCurrent++;
                            break;
                        case "se":
                            jCurrent++;
                            iCurrent++;
                            break;
                        case "nw":
                            jCurrent--;
                            iCurrent--;
                            break;
                        case "ne":
                            iCurrent--;
                            break;
                        case "e":
                            jCurrent++;
                            break;
                        case "w":
                            jCurrent--;
                            break;
                    }
                }
                tiles[iCurrent][jCurrent] = !tiles[iCurrent][jCurrent];
                if (tiles[iCurrent][jCurrent])
                {
                    if (iCurrent< iMin)
                    {
                        iMin = iCurrent;
                    }
                    else if (iCurrent > iMax)
                    {
                        iMax = iCurrent;
                    }
                    if (jCurrent < jMin)
                    {
                        jMin = jCurrent;
                    }
                    else if (jCurrent > jMax)
                    {
                        jMax = jCurrent;
                    }
                }
                iCurrent = middle;
                jCurrent = middle;
            }

            if (firstPart)
            {
                return tiles.SelectMany(t => t).Count(t => t);
            }

            var toSwitch = new List<(int, int)>(middle * middle);
            for (int k = 1; k <= 100; k++)
            {
                toSwitch.Clear();
                iMin -= 1;
                jMin -= 1;
                iMax += 1;
                jMax += 1;
                int nextIMin = iMin;
                int nextJMin = jMin;
                int nextIMax = iMax;
                int nextJMax = jMax;
                for (int i = iMin; i <= iMax; i++)
                {
                    for (int j = jMin; j <= jMax; j++)
                    {
                        int count = 0;
                        if (tiles[i][j - 1])
                        {
                            count++;
                        }
                        if (tiles[i - 1][j - 1])
                        {
                            count++;
                        }
                        if (tiles[i - 1][j])
                        {
                            count++;
                        }
                        if (tiles[i + 1][j])
                        {
                            count++;
                        }
                        if (tiles[i + 1][j + 1])
                        {
                            count++;
                        }
                        if (tiles[i][j + 1])
                        {
                            count++;
                        }

                        if (tiles[i][j])
                        {
                            if (count == 0 || count > 2)
                            {
                                toSwitch.Add((i, j));
                            }
                        }
                        else
                        {
                            if (count == 2)
                            {
                                toSwitch.Add((i, j));
                                if (i < nextIMin)
                                {
                                    nextIMin = i;
                                }
                                else if (i > nextIMax)
                                {
                                    nextIMax = i;
                                }
                                if (j < nextJMin)
                                {
                                    nextJMin = j;
                                }
                                else if (j > nextJMax)
                                {
                                    nextJMax = j;
                                }
                            }
                        }
                    }
                }
                iMin = nextIMin - 1;
                jMin = nextJMin - 1;
                iMax = nextIMax + 1;
                jMax = nextJMax + 1;
                foreach (var (a, b) in toSwitch)
                {
                    tiles[a][b] = !tiles[a][b];
                }
                //System.Diagnostics.Debug.WriteLine($"day {k} - {tiles.SelectMany(t => t).Count(t => t)}");
            }

            return tiles.SelectMany(t => t).Count(t => t);
        }

        // 120 (part one only)
        public static string Day23(bool firstPart, bool sample)
        {
            var cups2 = GetContent(23, v => Convert.ToInt32(v), sample: sample).ToList();

            if (!firstPart)
            {
                var max = cups2.Max() + 1;
                for (int i = max; i <= 1000000; i++)
                {
                    cups2.Add(i);
                }
            }

            var cupsArray = cups2.ToArray();

            int LOOP = firstPart ? 100 : 10000000;

            void RemoveAt(ref int[] source, int index)
            {
                var dest = new int[source.Length - 1];
                if (index > 0)
                {
                    Array.Copy(source, 0, dest, 0, index);
                }

                if (index < source.Length - 1)
                {
                    Array.Copy(source, index + 1, dest, index, source.Length - index - 1);
                }

                source = dest;
            }

            for (int i = 0; i < LOOP; i++)
            {
                var currentCup = cupsArray[0];

                var removed = new int[3];
                int j = 2;
                for (int k = 3; k >= 1; k--)
                {
                    removed[j] = cupsArray[k];
                    RemoveAt(ref cupsArray, k);
                    j--;
                }

                bool Contains(int[] values, int value)
                {
                    for (int k = 0; k < values.Length; k++)
                    {
                        if (values[k] == value)
                        {
                            return true;
                        }
                    }
                    return false;
                }

                var minusOne = currentCup - 1;
                while (Contains(removed, minusOne))
                {
                    minusOne -= 1;
                }
                if (!Contains(cupsArray, minusOne))
                {
                    minusOne = cupsArray.Max();
                }

                var indexofminus = Array.IndexOf(cupsArray, minusOne);

                var cupsArrayCopy = new int[cupsArray.Length + removed.Length];
                for (int k = 0; k <= indexofminus; k++)
                {
                    cupsArrayCopy[k] = cupsArray[k];
                }
                for (int k = 0; k < 3; k++)
                {
                    cupsArrayCopy[k + indexofminus + 1] = removed[k];
                }
                for (int k = indexofminus + 1; k < cupsArray.Length; k++)
                {
                    cupsArrayCopy[k + 3] = cupsArray[k];
                }
                cupsArray = cupsArrayCopy;

                for (int k = 0; k < cupsArray.Length; k++)
                {
                    cupsArray[k] = k == cupsArray.Length - 1
                        ? currentCup
                        : cupsArray[k + 1];
                }
            }

            var indexOfOne = Array.IndexOf(cupsArray, 1);
            if (firstPart)
            {
                List<char> values = new List<char>();
                for (int k = indexOfOne + 1; k < cupsArray.Length; k++)
                {
                    values.Add(cupsArray[k].ToString().First());
                }
                for (int k = 0; k < indexOfOne; k++)
                {
                    values.Add(cupsArray[k].ToString().First());
                }

                return new string(values.ToArray());
            }
            else
            {
                if (indexOfOne >= cupsArray.Length - 1)
                {

                }
                var nb1 = cupsArray[indexOfOne + 1];
                var nb2 = cupsArray[indexOfOne + 2];

                return (nb1 * (long)nb2).ToString();
            }
        }

        // 92
        public static long Day22(bool firstPart, bool sample)
        {
            var datas = GetContent(22, v => v, "\r\n\r\n", sample: sample);
            var p1 = datas[0].Split("\r\n").Skip(1).Select(v => Convert.ToInt32(v)).ToList();
            var p2 = datas[1].Split("\r\n").Skip(1).Select(v => Convert.ToInt32(v)).ToList();

            List<int> winner;

            if (firstPart)
            {
                while (p1.Count > 0 && p2.Count > 0)
                {
                    var p1Card = p1[0];
                    var p2Card = p2[0];
                    p1.RemoveAt(0);
                    p2.RemoveAt(0);
                    if (p1Card > p2Card)
                    {
                        p1.Add(p1Card);
                        p1.Add(p2Card);
                    }
                    else
                    {
                        p2.Add(p2Card);
                        p2.Add(p1Card);
                    }
                }

                winner = p1.Count == 0 ? p2 : p1;
            }
            else
            {
                bool Round(List<int> p1Bis, List<int> p2Bis, List<List<int>> p1Decks, List<List<int>> p2Decks)
                {
                    while (p1Bis.Count > 0 && p2Bis.Count > 0)
                    {
                        for (int k = 0; k < p1Decks.Count; k++)
                        {
                            if (p1Decks[k].SequenceEqual(p1Bis) && p2Decks[k].SequenceEqual(p2Bis))
                            {
                                return true;
                            }
                        }

                        p1Decks.Add(new List<int>(p1Bis));
                        p2Decks.Add(new List<int>(p2Bis));

                        bool isP1Win;
                        var p1Card = p1Bis[0];
                        var p2Card = p2Bis[0];
                        if (p1Card <= p1Bis.Count - 1 && p2Card <= p2Bis.Count - 1)
                        {
                            isP1Win = Round(p1Bis.Skip(1).Take(p1Card).ToList(), p2Bis.Skip(1).Take(p2Card).ToList(), new List<List<int>>(), new List<List<int>>());
                        }
                        else
                        {
                            isP1Win = p1Card > p2Card;
                        }
                        p1Bis.RemoveAt(0);
                        p2Bis.RemoveAt(0);
                        if (isP1Win)
                        {
                            p1Bis.Add(p1Card);
                            p1Bis.Add(p2Card);
                        }
                        else
                        {
                            p2Bis.Add(p2Card);
                            p2Bis.Add(p1Card);
                        }
                    }
                    return p1Bis.Count > 0;
                }

                var p1Win = Round(p1, p2, new List<List<int>>(), new List<List<int>>());
                winner = p1Win ? p1 : p2;
            }

            long Score(List<int> winnerLocal)
            {
                long score = 0;
                int j = 1;
                for (int i = winnerLocal.Count - 1; i >= 0; i--)
                {
                    score += winnerLocal[i] * j;
                    j++;
                }
                return score;
            }

            return Score(winner);
        }

        // 131
        public static (long, string) Day21(bool sample)
        {
            var datas = GetContent(21, v => v, sample: sample);

            var food = new List<(List<string> ingredients, List<string> allergenes)>();
            foreach (var data in datas)
            {
                if (data.Contains("("))
                {
                    var parts = data.Split("(");
                    var ingredients = parts[0].Trim().Split(" ");
                    var allergenes = parts[1].Replace(")", "").Replace("contains", "").Trim().Split(", ");
                    food.Add((ingredients.ToList(), allergenes.ToList()));
                }
                else
                {
                    food.Add((data.Split(" ").ToList(), new List<string>()));
                }
            }

            List<(List<string> ingredients, List<string> allergenes)> Copy(List<(List<string> ingredients, List<string> allergenes)> localFood)
            {
                return localFood.Select(lf => (new List<string>(lf.ingredients), new List<string>((lf.allergenes)))).ToList();
            }

            bool IsValid(List<(List<string> ingredients, List<string> allergenes)> localFood)
            {
                if (localFood.Any(lf => lf.allergenes.Count > lf.ingredients.Count))
                {
                    return false;
                }
                foreach (var alg in localFood.SelectMany(lf => lf.allergenes))
                {
                    if (localFood.Where(lf => lf.allergenes.Contains(alg) && lf.ingredients.Count == 1).SelectMany(lf => lf.ingredients).Distinct().Count() > 1)
                    {
                        return false;
                    }
                }
                return true;
            }

            bool Pick((string igLoc, string algLoc) hypo,
                List<(List<string> ingredients,
                List<string> allergenes)> localFood,
                Dictionary<string, string> picks)
            {
                foreach (var (ingredients, allergenes) in localFood)
                {
                    if (allergenes.Contains(hypo.algLoc))
                    {
                        if (ingredients.Contains(hypo.igLoc))
                        {
                            ingredients.Remove(hypo.igLoc);
                            allergenes.Remove(hypo.algLoc);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ingredients.Remove(hypo.igLoc);
                    }
                }
                if (!IsValid(localFood))
                {
                    return false;
                }
                if (!localFood.Any(lf => lf.allergenes.Count > 0))
                {
                    return true;
                }
                var firstPick = localFood.First(lf => lf.allergenes.Count > 0);
                var alg = firstPick.allergenes.First();
                bool found = false;
                foreach (var ig in firstPick.ingredients)
                {
                    var localPick = new Dictionary<string, string>();
                    var isOk = Pick((ig, alg), Copy(localFood), localPick);
                    if (isOk)
                    {
                        found = true;
                        picks.Add(alg, ig);
                        foreach (var k in localPick.Keys)
                        {
                            picks.Add(k, localPick[k]);
                        }
                        break;
                    }
                }
                return found;
            }

            var finalPicks = new Dictionary<string, string>();

            bool doStuff = true;
            while (doStuff)
            {
                var (ingredients, allergenes) = food.First(lf => lf.allergenes.Count > 0);
                var alg = allergenes.First();
                foreach (var ig in ingredients)
                {
                    var myLocalPicks = new Dictionary<string, string>();
                    if (Pick((ig, alg), Copy(food), myLocalPicks))
                    {
                        finalPicks.Add(alg, ig);
                        foreach (var k in myLocalPicks.Keys)
                        {
                            finalPicks.Add(k, myLocalPicks[k]);
                        }
                        doStuff = false;
                        break;
                    }
                }
            }

            var usedIg = finalPicks.Select(mp => mp.Value).ToList();
            var notUsed = food.SelectMany(f => f.ingredients).Where(f => !usedIg.Contains(f)).Count();

            string canonical = "";
            bool first = true;
            finalPicks = finalPicks.OrderBy(fp => fp.Key).ToDictionary(fp => fp.Key, fp => fp.Value);
            foreach (var k in finalPicks.Keys)
            {
                canonical += $"{(first ? "" : ",")}{finalPicks[k]}";
                first = false;
            }

            return (notUsed, canonical);
        }

        // 415
        public static long Day20(bool firstPart, bool sample)
        {
            var content = GetContent(20, v =>
            {
                var rows = v.Split("\r\n");
                return (Convert.ToInt32(rows[0].Replace(":", "").Replace("Tile ", "")), rows.Skip(1)
                    .Select(_ => _.
                        Select(__ =>
                            Convert.ToInt32(__ == '.' ? 1 : 0))
                        .ToArray())
                    .ToArray());
            }, "\r\n\r\n", sample:sample).ToDictionary(kvp => kvp.Item1, kvp => kvp.Item2);

            int[][] Rotate(int[][] cube)
            {
                var rotated = new int[cube.Length][];
                for (int i = 0; i < cube.Length; i++)
                {
                    for (int j = 0; j < cube.Length; j++)
                    {
                        if (i == 0)
                        {
                            rotated[j] = new int[cube.Length];
                        }
                        rotated[j][(cube.Length - 1 - i)] = cube[i][j];
                    }
                }
                return rotated;
            }

            int[][] Flip(int[][] cube, int flipIndex)
            {
                switch (flipIndex)
                {
                    case 1:
                        return cube.Reverse().ToArray();
                    case 2:
                        return cube.Select(_ => _.Reverse().ToArray()).ToArray();
                    case 3:
                        return cube.Reverse().Select(_ => _.Reverse().ToArray()).ToArray();
                    default:
                        return cube.ToArray();
                }
            }

            List<Cube> ToCubeList(int id, int[][] originalDatas)
            {
                var cubes = new List<Cube>();

                for (int iFlip = 0; iFlip < 4; iFlip++)
                {
                    var currentDatas = Flip(originalDatas, iFlip);
                    for (int iRotate = 0; iRotate < 4; iRotate++)
                    {
                        currentDatas = iRotate == 0 ? currentDatas : Rotate(currentDatas);
                        cubes.Add(new Cube(id, currentDatas));
                    }
                }

                for (int k = cubes.Count - 1; k >= 0; k--)
                {
                    if (cubes.Any(c => cubes.IndexOf(c) < k && cubes[k].IsEqualTo(c)))
                    {
                        cubes.RemoveAt(k);
                    }
                }

                return cubes;
            }

            var dim = (int)Math.Sqrt(content.Keys.Count);

            var rightPossibilities = new List<Cube>();
            var bottomPossibilities = new List<Cube>();

            Cube[,] Sequencial(int i, int j, Cube[,] localGrid, List<Cube> localCubes)
            {
                if (i == dim)
                {
                    return localGrid;
                }

                rightPossibilities.Clear();
                bottomPossibilities.Clear();

                if (i > 0)
                {
                    var topper = localGrid[i - 1, j];
                    bottomPossibilities.AddRange(localCubes.Where(lc => topper.MatchTop(lc)));
                    if (bottomPossibilities.Count == 0)
                    {
                        return null;
                    }
                }

                if (j > 0)
                {
                    var lefter = localGrid[i, j - 1];
                    rightPossibilities.AddRange(localCubes.Where(lc => lefter.MatchLeft(lc)));
                    if (rightPossibilities.Count == 0)
                    {
                        return null;
                    }
                }

                var possibilities = new List<Cube>();
                if (rightPossibilities.Count > 0 && bottomPossibilities.Count > 0)
                {
                    var intersect = rightPossibilities.Intersect(bottomPossibilities);
                    if (!intersect.Any())
                    {
                        return null;
                    }
                    possibilities.AddRange(intersect);
                }
                else if (rightPossibilities.Count > 0)
                {
                    possibilities.AddRange(rightPossibilities);
                }
                else if (bottomPossibilities.Count > 0)
                {
                    possibilities.AddRange(bottomPossibilities);
                }
                else
                {
                    possibilities.AddRange(localCubes);
                }

                foreach (var poss in possibilities)
                {
                    var localCubesCopy = new List<Cube>(localCubes.Where(lcc => lcc.Id != poss.Id));

                    var localGridCopy = new Cube[dim, dim];
                    for (int k = 0; k < localGrid.GetLength(0); k++)
                    {
                        for (int l = 0; l < localGrid.GetLength(1); l++)
                        {
                            localGridCopy[k, l] = localGrid[k, l];
                        }
                    }
                    localGridCopy[i, j] = poss;

                    int newJ = j + 1;
                    int newI = i;
                    if (newJ == dim)
                    {
                        newJ = 0;
                        newI += 1;
                    }

                    localGridCopy = Sequencial(newI, newJ, localGridCopy, localCubesCopy);
                    if (localGridCopy != null)
                    {
                        return localGridCopy;
                    }
                }

                return null;
            }

            var grid = new Cube[dim, dim];

            var cubPoses = content.Keys.SelectMany(k => ToCubeList(k, content[k])).ToList();

            grid = Sequencial(0, 0, grid, cubPoses);

            if (firstPart)
            {
                return (long)grid[0, 0].Id * grid[0, dim - 1].Id * grid[dim - 1, 0].Id * grid[dim - 1, dim - 1].Id;
            }

            var pixelSizeNoBorder = grid[0, 0].Bottom.Length - 2;
            var image = new int[dim * pixelSizeNoBorder, dim * pixelSizeNoBorder];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    for (int k = 0; k < grid[i, j].InsideContent.GetLength(0); k++)
                    {
                        for (int l = 0; l < grid[i, j].InsideContent.GetLength(1); l++)
                        {
                            image[(i * pixelSizeNoBorder) + k, (j * pixelSizeNoBorder) + l] = grid[i, j].InsideContent[k, l];
                        }
                    }
                }
            }

            var img2D = new int[dim * pixelSizeNoBorder][];
            for (int i = 0; i < image.GetLength(0); i++)
            {
                img2D[i] = new int[dim * pixelSizeNoBorder];
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    img2D[i][j] = image[i, j];
                }
            }

            var imgVersions = ToCubeList(1, img2D).Select(_ => _.FullContent).ToList();

            int resultCount = 0;
            foreach (var imgVersion in imgVersions)
            {
                // xxxxxxxxxxxxxxxxxx#x
                // #xxxx##xxxx##xxxx###
                // x#xx#xx#xx#xx#xx#xxx
                int countUsedAsMonster = 0;
                for (int i = 0; i < imgVersion.GetLength(0); i++)
                {
                    for (int j = 0; j < imgVersion.GetLength(1); j++)
                    {
                        if (imgVersion[i, j] == 0)
                        {
                            if (j > 17 && i < imgVersion.GetLength(0) - 2 && j < imgVersion.GetLength(1) - 1) // monster head
                            {
                                if (imgVersion[i + 1, j - 18] == 0
                                    && imgVersion[i + 1, j - 13] == 0
                                    && imgVersion[i + 1, j - 12] == 0
                                    && imgVersion[i + 1, j - 7] == 0
                                    && imgVersion[i + 1, j - 6] == 0
                                    && imgVersion[i + 1, j - 1] == 0
                                    && imgVersion[i + 1, j - 0] == 0
                                    && imgVersion[i + 1, j + 1] == 0) // monster body 1
                                {
                                    if (imgVersion[i + 2, j - 17] == 0
                                        && imgVersion[i + 2, j - 14] == 0
                                        && imgVersion[i + 2, j - 11] == 0
                                        && imgVersion[i + 2, j - 8] == 0
                                        && imgVersion[i + 2, j - 5] == 0
                                        && imgVersion[i + 2, j - 2] == 0) // monster body 2
                                    {
                                        countUsedAsMonster += 15;
                                    }
                                }
                            }
                        }
                    }
                }
                if (countUsedAsMonster > 0)
                {
                    for (int i = 0; i < imgVersion.GetLength(0); i++)
                    {
                        for (int j = 0; j < imgVersion.GetLength(1); j++)
                        {
                            if (imgVersion[i, j] == 0)
                            {
                                resultCount++;
                            }
                        }
                    }
                    resultCount -= countUsedAsMonster;
                }
            }

            return resultCount;
        }

        public class Cube
        {
            public string Top { get; }
            public string Left { get; }
            public string Right { get; }
            public string Bottom { get; }
            public int Id { get; }
            public int[,] InsideContent { get; }
            public int[,] FullContent { get; }

            public Cube(int id, int[][] content)
            {
                Id = id;
                FullContent = new int[content.Length, content.Length];
                InsideContent = new int[content.Length - 2, content.Length - 2];

                var top = new int[content.Length];
                var bottom = new int[content.Length];
                var left = new int[content.Length];
                var right = new int[content.Length];
                for (int i = 0; i < content.Length; i++)
                {
                    for (int j = 0; j < content.Length; j++)
                    {
                        if (i == 0)
                        {
                            top[j] = content[i][j];
                        }
                        if (i == content.Length - 1)
                        {
                            bottom[j] = content[i][j];
                        }
                        if (j == 0)
                        {
                            left[i] = content[i][j];
                        }
                        if (j == content.Length - 1)
                        {
                            right[i] = content[i][j];
                        }
                        if (j > 0 && j < content.Length - 1 && i > 0 && i < content.Length - 1)
                        {
                            InsideContent[i - 1, j - 1] = content[i][j];
                        }
                        FullContent[i, j] = content[i][j];
                    }
                }

                Top = string.Join(string.Empty, top);
                Bottom = string.Join(string.Empty, bottom);
                Left = string.Join(string.Empty, left);
                Right = string.Join(string.Empty, right);
            }

            public bool MatchTop(Cube other)
            {
                return Bottom == other.Top;
            }

            public bool MatchLeft(Cube other)
            {
                return Right == other.Left;
            }

            public bool IsEqualTo(Cube other)
            {
                return other.Top == Top
                    && other.Bottom == Bottom
                    && other.Left == Left
                    && other.Right == Right;
            }
        }

        // 175
        public static long Day19(bool firstPart, bool sample)
        {
            var content = GetContent(19, v => v, "\r\n\r\n", sample: sample, part: firstPart ? 1 : 2);

            var rules = content[0].Split("\r\n").ToDictionary(v =>
                Convert.ToInt32(v.Split(":")[0]),
                v => v.Split(":")[1]);
            var messages = content[1].Split("\r\n");
            
            bool IsFinalRule(int ruleId)
            {
                return rules[ruleId].Contains("\"");
            }

            char MatchFinalRule(int ruleId)
            {
                return rules[ruleId].Trim().Replace("\"", string.Empty)[0];
            }

            List<string> GroupRulePoss(List< List<int>> rulesGroupIds)
            {
                List<string> oks = new List<string>();
                foreach (var rulesGroupId in rulesGroupIds)
                {
                    var loc = GroupPos(rulesGroupId);
                    oks.AddRange(loc);
                }
                return oks;
            }

            List<string> GroupPos(List<int> ruleIds)
            {
                var possS = new List<string>();
                bool firstRule = true;
                foreach (int ruleId in ruleIds)
                {
                    var strCurr = MatchRuleId(ruleId);
                    if (strCurr.Count == 0)
                    {
                        return new List<string>();
                    }

                    if (firstRule)
                    {
                        possS.AddRange(strCurr);
                    }
                    else
                    {
                        var newPossS = new List<string>();
                        foreach (var p in possS)
                        {
                            foreach (var k in strCurr)
                            {
                                newPossS.Add(string.Concat(p, k));
                            }
                        }
                        possS = newPossS;
                    }

                    firstRule = false;
                }

                return possS;
            }

            List<string> MatchRuleId(int ruleId)
            {
                List<string> oks = new List<string>();
                if (IsFinalRule(ruleId))
                {
                    oks.Add(MatchFinalRule(ruleId).ToString());
                }
                else
                {
                    var ruleTxt = rules[ruleId].Trim();
                    var ruleTxtSplit = ruleTxt.Split("|");
                    var rule = ruleTxtSplit.Select(vBis =>
                    {
                        var ttt = vBis.Trim().Split(" ").Select(vTer =>
                            Convert.ToInt32(vTer)).ToList();
                        return ttt;
                    }).ToList();

                    oks.AddRange(GroupRulePoss(rule));
                }
                return oks;
            }

            var patterns = new List<string>();

            if (firstPart)
            {
                patterns = MatchRuleId(0);
                return messages.Count(msg => patterns.Contains(msg));
            }
            else
            {
                var patterns42 = MatchRuleId(42);
                var patterns31 = MatchRuleId(31);
                //var msgFilterd = messages.Where(msg => patterns42.Any(p42 => msg.StartsWith(p42))).ToList();

                List<string> valids = new List<string>();
                List<string> valids2 = new List<string>();
                foreach (var msg in messages)
                {
                    var localMsg = msg;
                    int subCount = 0;
                    bool found = true;
                    while (found && localMsg != "")
                    {
                        bool locFound = false;
                        foreach (var p42 in patterns42)
                        {
                            if (localMsg.StartsWith(p42))
                            {
                                localMsg = localMsg.Substring(p42.Length);
                                subCount++;
                                locFound = true;
                                break;
                            }
                        }
                        found = locFound;
                    }
                    if (localMsg != "" && subCount > 0)
                    {
                        int subCount2 = 0;
                        found = true;
                        while (found && localMsg != "")
                        {
                            bool locFound = false;
                            foreach (var p31 in patterns31)
                            {
                                if (localMsg.StartsWith(p31))
                                {
                                    localMsg = localMsg.Substring(p31.Length);
                                    subCount2++;
                                    locFound = true;
                                    break;
                                }
                            }
                            found = locFound;
                        }
                        if (localMsg == "" && subCount > subCount2)
                        {
                            valids.Add(msg);
                        }
                    }
                }

                var expected = new List<string>
                {
                    "bbabbbbaabaabba",
"babbbbaabbbbbabbbbbbaabaaabaaa",
"aaabbbbbbaaaabaababaabababbabaaabbababababaaa",
"bbbbbbbaaaabbbbaaabbabaaa",
"bbbababbbbaaaaaaaabbababaaababaabab",
"ababaaaaaabaaab",
"ababaaaaabbbaba",
"baabbaaaabbaaaababbaababb",
"abbbbabbbbaaaababbbbbbaaaababb",
"aaaaabbaabaaaaababaa",
"aaaabbaabbaaaaaaabbbabbbaaabbaabaaa",
"aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba"

                };

                var rest = expected.Except(valids).ToList();
                var rest2 = valids.Except(expected).ToList();
                var rest3 = valids2.Except(expected).ToList();

                // var invalid = messages.Except(valids);

                return valids.Count;
            }
        }

        // 96
        public static long Day18(bool firstPart, bool sample)
        {
            var expressions = GetContent(18, v =>  v, sample: sample, part: (sample ? (firstPart ? 1 : 2) : (int?)null));

            long SubSub(string subExp)
            {
                var cars = subExp.Split(" ");
                long subTot = -1;
                bool nextIsMultiply = false;
                foreach (var car in cars)
                {
                    if (subTot == -1)
                    {
                        subTot = Convert.ToInt32(car);
                    }
                    else if (car == "+")
                    {
                        nextIsMultiply = false;
                    }
                    else if (car == "*")
                    {
                        nextIsMultiply = true;
                    }
                    else
                    {
                        if (nextIsMultiply)
                        {
                            subTot = subTot * Convert.ToInt32(car);
                        }
                        else
                        {
                            subTot = subTot + Convert.ToInt32(car);
                        }
                    }
                }
                return subTot;
            }

            long ComputeSubTot(string subExp)
            {
                if (firstPart)
                {
                    return SubSub(subExp);
                }
                else
                {
                    var subSubExp = subExp.Split("*");
                    long tot = 1;
                    foreach (var sse in subSubExp)
                    {
                        var subTot = SubSub(sse.Trim());
                        tot = tot * subTot;
                    }
                    return tot;
                }
            }

            long sum = 0;

            for (int k = 0; k < expressions.Count; k++)
            {
                string exp = expressions[k];
                while (true)
                {
                    int parenthesePos = -1;
                    int endParenthesePos = -1;
                    int i = 0;
                    foreach (var car in exp)
                    {
                        if (car == '(')
                        {
                            parenthesePos = i;
                        }
                        else if (car == ')')
                        {
                            endParenthesePos = i;
                            break;
                        }
                        i++;
                    }
                    if (parenthesePos > -1)
                    {
                        var subExp = exp.Substring(parenthesePos + 1, endParenthesePos - parenthesePos - 1);
                        var subToto = ComputeSubTot(subExp);
                        exp = exp.Replace($"({subExp})", subToto.ToString());
                    }
                    else
                    {
                        sum += ComputeSubTot(exp);
                        break;
                    }
                }
            }

            return sum;
        }

        // 172
        public static long Day17(bool firstPart, bool sample)
        {
            const int CYCLES_COUNT = 6;
            const int GRID_LENGTH = 25; // arbitrary; minimal for 8x8x8x8
            const char ONE_VALUE = '#';

            var content = GetContent(17, row => row.Select(v => v == ONE_VALUE ? 1 : 0).ToArray(), sample: sample).ToArray();

            // note: no generic method regardless of cube dimension
            // so there's a ton of duplicated code
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

        // 134
        public static long Day16(bool firstPart, bool sample)
        {
            var datas = GetContent(16, v => v, "\r\n\r\n", sample);
            
            var myTicket = datas[1].Split("\r\n")[1].Split(",").Select(v => Convert.ToInt32(v)).ToList();
            var tickets = datas[2].Split("\r\n").Skip(1).Select(v => v.Split(",").Select(v2 => Convert.ToInt32(v2)).ToList()).ToList();
            var fields = datas[0].Split("\r\n").Select(v =>
            {
                var withName = v.Split(": ");
                var name = withName[0];
                var bornes = withName[1].Split(" or ");
                var range1 = (Convert.ToInt32(bornes[0].Split("-")[0]), Convert.ToInt32(bornes[0].Split("-")[1]));
                var range2 = (Convert.ToInt32(bornes[1].Split("-")[0]), Convert.ToInt32(bornes[1].Split("-")[1]));
                return (name, range1, range2);
            }).ToList();

            // for each ticket, find values that doesn't match any range
            long invalidTicketsValuesSum = 0;
            int iTicket = 0;
            var invalidTickets = new List<int>();
            foreach (var ticket in tickets)
            {
                foreach (var ticketValue in ticket)
                {
                    bool isValid = false;
                    foreach (var (name, range1, range2) in fields)
                    {
                        if ((ticketValue >= range1.Item1 && ticketValue <= range1.Item2)
                            || (ticketValue >= range2.Item1 && ticketValue <= range2.Item2))
                        {
                            isValid = true;
                        }
                    }
                    if (!isValid)
                    {
                        invalidTicketsValuesSum += ticketValue;
                        invalidTickets.Add(iTicket);
                    }
                }
                iTicket++;
            }

            if (firstPart)
            {
                return invalidTicketsValuesSum;
            }

            // exclude invalid tickets...
            invalidTickets.Sort();
            invalidTickets.Reverse();
            foreach (var invalidTicket in invalidTickets)
            {
                tickets.RemoveAt(invalidTicket);
            }

            // ...then includes mine
            tickets.Add(myTicket);

            // groups tickets values by field
            var valuesByIndexes = new List<List<int>>();
            for (int i = 0; i < fields.Count; i++)
            {
                var valuesForField = new List<int>();
                foreach (var ticket in tickets)
                {
                    valuesForField.Add(ticket[i]);
                }
                valuesByIndexes.Add(valuesForField);
            }

            // for each field, finds indexes from "valuesByIndexes"
            // where every element of the index' sublist matches at least one range of the field
            var matchingIndexesByField = new Dictionary<string, List<int>>();
            foreach (var (name, range1, range2) in fields)
            {
                var matchingIndexes = new List<int>();
                var iIndex = 0;
                foreach (var indexValues in valuesByIndexes)
                {
                    if (indexValues.All(v =>
                        (v >= range1.Item1 && v <= range1.Item2)
                        || (v >= range2.Item1 && v <= range2.Item2)))
                    {
                        matchingIndexes.Add(iIndex);
                    }
                    iIndex++;
                }
                matchingIndexesByField.Add(name, matchingIndexes);
            }

            // sorts (asc) by the number of indexes that match the field, then rebuilds the dictionary
            // that way, the first field will have only one list
            // the second field two lists, etc...
            matchingIndexesByField = matchingIndexesByField
                .OrderBy(kvp => kvp.Value.Count)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            // for each field, sets the appropriate index from indexes list
            // as we clean indexes we use in the loop
            // it should always be one and one index possible for each field
            var indexPickByField = new Dictionary<string, int>();
            int fieldsCount = matchingIndexesByField.Count; // stores the count to avoid exception "the collection has changed"
            for (int i = 0; i < fieldsCount; i++)
            {
                var fieldWithIndexes = matchingIndexesByField.ElementAt(i);
                var singlePossibleIndex = fieldWithIndexes.Value.First();
                indexPickByField.Add(fieldWithIndexes.Key, singlePossibleIndex);
                // clean picked index from source list
                foreach (var localFieldWithIndexes in matchingIndexesByField)
                {
                    localFieldWithIndexes.Value.Remove(singlePossibleIndex);
                }
            }

            // builds "my ticket" values by field
            var myTicketValues = indexPickByField.ToDictionary(
                kvp => kvp.Key,
                kvp => myTicket[indexPickByField[kvp.Key]]);

            // note: value for sample has been made up (not in the original exercice)
            var EXPECTED_FIELDS_PATTERN = sample ? "a" : "departure";

            // sum of values, for my ticket, with a field name that matches the pattern
            long result = 1;
            foreach (var field in myTicketValues.Keys)
            {
                if (field.Contains(EXPECTED_FIELDS_PATTERN))
                {
                    result *= myTicketValues[field];
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
            }, "\r\n\r\n", sample, sample ? (firstPart ? 1 : 2) : (int?)null);

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
                        if ((j + busDatas[iBus].delta) % busDatas[iBus].modulo != 0)
                        {
                            long modulator = 1;
                            for (int kk = 0; kk < iBus; kk++)
                            {
                                modulator *= busDatas[kk].modulo;
                            }
                            addedToStart += modulator;
                            atLeastOneNoMatch = true;
                        }
                        iBus++;
                    }

                    if (atLeastOneNoMatch)
                    {
                        j += addedToStart;
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
        public static long Day12(bool firstPart, bool sample)
        {
            var instructions = GetContent(12, v => (v[0], Convert.ToInt32(v.Substring(1))), sample: sample);

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
                    if (firstPart)
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
                        if (firstPart)
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
                    if (firstPart)
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
        public static long Day11(bool firstPart, bool sample)
        {
            var datas = GetContent(11, v => v.ToArray(), sample: sample).ToArray();

            if (firstPart)
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
        public static long Day10(bool firstPart, bool sample)
        {
            var datas = GetContent(10, v => Convert.ToInt32(v), sample: sample);

            datas.Add(0);
            if (!firstPart)
            {
                datas.Add(datas.Max() + 3);
            }

            datas.Sort();

            // exercice 1
            if (firstPart)
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
        public static long Day09(bool firstPart, bool sample)
        {
            var datas = GetContent(9, v => Convert.ToInt64(v), sample: sample);

            int baseP = sample ? 5 : 25;

            bool ok = true;
            int p = baseP;
            int skip = 0;
            long mark = -1;
            while (ok)
            {
                var lastPCount = datas.Skip(skip).Take(baseP).ToList();

                bool found = false;
                for (int j = 0; j < baseP; j++)
                {
                    for (int k = 0; k < baseP; k++)
                    {
                        if (lastPCount[j] != lastPCount[k])
                        {
                            if (lastPCount[j] + lastPCount[k] == datas[p])
                            {
                                found = true;
                            }
                        }
                    }
                }

                ok = found;
                mark = datas[p];
                p++;
                skip++;
            }

            if (firstPart)
            {
                return mark;
            }

            int okFirstIndex = -1;
            int okLastIndex = -1;
            for (int i = 0; i < datas.Count; i++)
            {
                int localOkIndex = -1;
                long currentSum = datas[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (currentSum >= mark)
                    {
                        break;
                    }
                    localOkIndex = j;
                    currentSum += datas[j];
                }
                if (currentSum == mark)
                {
                    okLastIndex = i;
                    okFirstIndex = localOkIndex;
                    break;
                }
            }

            var ranged = datas.Skip(okFirstIndex).Take(okLastIndex - okFirstIndex).ToList();

            return ranged.Min() + ranged.Max();
        }

        // 73
        public static long Day08(bool firstPart, bool sample)
        {
            var instructions = GetContent(8, v =>
                (v.Split(' ')[0], Convert.ToInt32(v.Split(' ')[1].Replace("+", ""))),
                sample: sample);

            var realAccumulateur = -1;

            bool realEnding = false;
            for (int j = 0; j < instructions.Count; j++)
            {
                var localInstructions = new List<(string, int)>(instructions);

                var ij = instructions[j];

                if (!firstPart)
                {
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
                }

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

                if (realEnding || firstPart)
                {
                    realAccumulateur = accumulateur;
                    break;
                }
            }

            return realAccumulateur;
        }

        // 78
        public static long Day07(bool firstPart, bool sample)
        {
            var datas = GetContent(7, v => v, "\r\n", sample: sample);

            var finalList = new Dictionary<string, List<(int, string)>>();

            foreach (var d in datas)
            {
                var realD = d;
                if (realD.EndsWith("."))
                {
                    realD = realD.Substring(0, realD.Length - 1);
                }

                var sub = realD.Split(" bags contain ");

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

            if (firstPart)
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
        public static long Day06(bool firstPart, bool sample)
        {
            var byGroupByPeople = GetContent(6, v => v.Split("\r\n").ToList(), "\r\n\r\n", sample: sample);

            var yesCount = 0;

            foreach (var group in byGroupByPeople)
            {
                var datasGroup = group.SelectMany(g => g).ToList();

                var result = datasGroup
                    .GroupBy(k => k)
                    .Where(k => firstPart ? (k.Count() > 0) : (k.Count() == group.Count));

                yesCount += result.Count();
            }

            return yesCount;
        }

        // 67
        public static long Day05(bool firstPart, bool sample)
        {
            var list = GetContent(5, v => v, sample: sample);

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

            if (firstPart)
            {
                return max;
            }

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
        public static long Day04(bool firstPart, bool sample)
        {
            var codes = new string[]
            {
                "byr", "iyr", "eyr", "hgt",
                "hcl", "ecl", "pid"
            };

            var passports = GetContent(4, v => v.Replace("\r\n", " "), "\r\n\r\n", sample: sample);

            int passportsValid = 0;
            foreach (var passport in passports)
            {
                var kpvList = new Dictionary<string, string>();
                foreach (var p in passport.Split(' '))
                {
                    var split = p.Split(':');
                    kpvList.Add(split[0].ToLowerInvariant(), split[1].ToLowerInvariant());
                }
                bool allCodesContained = codes.All(c => kpvList.ContainsKey(c));
                if (!firstPart && allCodesContained)
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
                else if (firstPart && allCodesContained)
                {
                    passportsValid++;
                }
            }

            return passportsValid;
        }

        // 38
        public static long Day03(bool firstPart, bool sample)
        {
            var fullList = GetContent(3, v => v.ToArray().Select(subV => subV == '#' ? 1 : 0).ToList(), sample: sample);

            var combos = new List<(int right, int down)>
            {
                (3, 1)
            };
            if (!firstPart)
            {
                combos.Add((1, 1));
                combos.Add((5, 1));
                combos.Add((7, 1));
                combos.Add((1, 2));
            }
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

        // 39
        public static long Day02(bool firstPart, bool sample)
        {
            var baseList = GetContent(2, v => v, sample: sample);

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
                if (firstPart)
                {
                    var countChar = val.Count(c => c == car);
                    if (countChar >= min && countChar <= max)
                    {
                        countValid++;
                    }
                }
                else
                {
                    if (
                    (val[min - 1] == car && val[max - 1] != car)
                    || (val[min - 1] != car && val[max - 1] == car))
                    {
                        countValid++;
                    }
                }
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
            bool sample = false,
            int? part = null)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                $"Datas\\{(sample ? "Samples\\" : string.Empty)}{day.ToString().PadLeft(2, '0')}{(part.HasValue ? $"_{part.Value}" : string.Empty)}.txt");
            string[] datas;
            using (var rd = new StreamReader(path))
            {
                datas = rd.ReadToEnd().Split(separator);
            }

            return datas.Select(v => converter(v)).ToList();
        }
    }
}
