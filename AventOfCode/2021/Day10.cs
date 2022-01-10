using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day10 : DayBase
    {
        public Day10() : base(2021, 10) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetContent(v => v, sample: sample);

            long score = 0;
            for (var i = 0; i < values.Count; i++)
            {
                var v = values[i];
                while (true)
                {
                    var oldV = v;
                    v = v.Replace("{}", "").Replace("()", "").Replace("[]", "").Replace("<>", "");
                    if (string.IsNullOrEmpty(v))
                    {
                        break;
                    }
                    else if (oldV == v)
                    {
                        v = v.Replace("{", "").Replace("(", "").Replace("[", "").Replace("<", "");
                        if (v == "")
                            break;
                        switch (v[0])
                        {
                            case '>': score += 25137; break;
                            case '}': score += 1197; break;
                            case ']': score += 57; break;
                            case ')': score += 3; break;
                        }
                        break;
                    }
                }
            }

            return score;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var values = GetContent(v => v, sample: sample);

            var scores = new List<long>();
            for (var i = 0; i < values.Count; i++)
            {
                var v = values[i];
                while (true)
                {
                    var oldV = v;
                    v = v.Replace("{}", "").Replace("()", "").Replace("[]", "").Replace("<>", "");
                    if (string.IsNullOrEmpty(v))
                    {
                        break;
                    }
                    else if (oldV == v)
                    {
                        var nv = v.Replace("{", "").Replace("(", "").Replace("[", "").Replace("<", "");
                        if (nv == "")
                        {
                            var toAdd = "";
                            while (!string.IsNullOrWhiteSpace(v))
                            {
                                switch (v[v.Length - 1])
                                {
                                    case '<':
                                        toAdd += ">";
                                        break;
                                    case '(':
                                        toAdd += ")";
                                        break;
                                    case '[':
                                        toAdd += "]";
                                        break;
                                    case '{':
                                        toAdd += "}";
                                        break;
                                }
                                v = v.Substring(0, v.Length - 1);
                                while (v.Contains("{}")
                                    || v.Contains("()")
                                    || v.Contains("[]")
                                    || v.Contains("<>"))
                                {
                                    v = v.Replace("{}", "").Replace("()", "").Replace("[]", "").Replace("<>", "");
                                }
                            }
                            long score = 0;
                            foreach (var cc in toAdd)
                            {
                                score *= 5;
                                switch (cc)
                                {
                                    case '>':
                                        score += 4;
                                        break;
                                    case '}':
                                        score += 3;
                                        break;
                                    case ']':
                                        score += 2;
                                        break;
                                    case ')':
                                        score += 1;
                                        break;
                                }
                            }
                            scores.Add(score);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return scores.OrderBy(x => x).Skip((scores.Count - 1) / 2).First();
        }
    }
}
