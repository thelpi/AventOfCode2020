using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 19: Monster Messages
    /// </summary>
    public sealed class Day19 : DayBase
    {
        public Day19() : base(19) { }

        public override long GetFirstPartResult(bool sample)
        {
            var content = GetContent(v => v, "\r\n\r\n", sample: sample, part: 1);

            var rules = content[0].Split("\r\n").ToDictionary(v =>
                Convert.ToInt32(v.Split(":")[0]),
                v => v.Split(":")[1]);
            var messages = content[1].Split("\r\n");

            var results = MatchRuleId(rules, 0);
            return messages.Count(msg => results.Contains(msg));
        }

        public override long GetSecondPartResult(bool sample)
        {
            var content = GetContent(v => v, "\r\n\r\n", sample: sample, part: 2);

            var rules = content[0].Split("\r\n").ToDictionary(v =>
                Convert.ToInt32(v.Split(":")[0]),
                v => v.Split(":")[1]);
            var messages = content[1].Split("\r\n");

            var patterns42 = MatchRuleId(rules, 42);
            var patterns31 = MatchRuleId(rules, 31);

            List<string> valids = new List<string>();
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

            return valids.Count;
        }

        private bool IsFinalRule(Dictionary<int, string> rules, int ruleId)
        {
            return rules[ruleId].Contains("\"");
        }

        private char MatchFinalRule(Dictionary<int, string> rules, int ruleId)
        {
            return rules[ruleId].Trim().Replace("\"", string.Empty)[0];
        }

        private List<string> GroupRulePoss(Dictionary<int, string> rules, List<List<int>> rulesGroupIds)
        {
            List<string> oks = new List<string>();
            foreach (var rulesGroupId in rulesGroupIds)
            {
                var loc = GroupPos(rules, rulesGroupId);
                oks.AddRange(loc);
            }
            return oks;
        }

        private List<string> GroupPos(Dictionary<int, string> rules, List<int> ruleIds)
        {
            var possS = new List<string>();
            bool firstRule = true;
            foreach (int ruleId in ruleIds)
            {
                var strCurr = MatchRuleId(rules, ruleId);
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

        private List<string> MatchRuleId(Dictionary<int, string> rules, int ruleId)
        {
            List<string> oks = new List<string>();
            if (IsFinalRule(rules, ruleId))
            {
                oks.Add(MatchFinalRule(rules, ruleId).ToString());
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

                oks.AddRange(GroupRulePoss(rules, rule));
            }
            return oks;
        }
    }
}
