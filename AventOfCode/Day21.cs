using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 21: Allergen Assessment
    /// </summary>
    public sealed class Day21 : DayBase
    {
        public string Part2CanonicalResult { get; private set; }

        public Day21() : base(21) { }

        public override long GetFirstPartResult(bool sample)
        {
            throw new NotImplementedException($"Use '{nameof(GetSecondPartResult)}' to get result for this day.");
        }

        public override long GetSecondPartResult(bool sample)
        {
            var datas = GetContent(v => v, sample: sample);

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

            Part2CanonicalResult = canonical;

            return notUsed;
        }
    }
}
