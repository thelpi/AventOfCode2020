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
