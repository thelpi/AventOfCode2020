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
        private const int START_RULE_ID = 0;
        private const int SPECIFIC_RULE_ID_1 = 42;
        private const int SPECIFIC_RULE_ID_2 = 31;

        public Day19() : base(19) { }

        public override long GetFirstPartResult(bool sample)
        {
            var rules = GetRulesAndMessages(sample, 1, out string[] messages);

            var results = GetRuleIdMessagesRecursive(rules, START_RULE_ID);

            return messages.Count(_ => results.Contains(_));
        }

        public override long GetSecondPartResult(bool sample)
        {
            var rules = GetRulesAndMessages(sample, 2, out string[] messages);

            var patterns42 = GetRuleIdMessagesRecursive(rules, SPECIFIC_RULE_ID_1);
            var patterns31 = GetRuleIdMessagesRecursive(rules, SPECIFIC_RULE_ID_2);

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

        private Dictionary<int, string> GetRulesAndMessages(bool sample, int samplePartIndex, out string[] expectedMessages)
        {
            var content = GetContent(v => v, "\r\n\r\n", sample: sample, part: samplePartIndex);

            expectedMessages = content[1].Split("\r\n");

            return content[0]
                .Split("\r\n")
                .ToDictionary(
                    v => Convert.ToInt32(v.Split(":")[0]),
                    v => v.Split(":")[1]);
        }

        private List<string> GetRuleIdMessagesRecursive(Dictionary<int, string> rules, int ruleId)
        {
            var messages = new List<string>();
            if (IsFinalRule(rules, ruleId))
            {
                messages.Add(GetFinalRuleIdMessage(rules, ruleId).ToString());
            }
            else
            {
                var rule = rules[ruleId]
                    .Split("|")
                    .Select(r => r
                        .Trim()
                        .Split(" ")
                        .Select(_ => Convert.ToInt32(_))
                        .ToList())
                    .ToList();

                messages.AddRange(rule
                    .SelectMany(r => GetNonFinalRuleMessages(rules, r))
                    .ToList());
            }
            return messages;
        }

        private bool IsFinalRule(Dictionary<int, string> rules, int ruleId)
        {
            return rules[ruleId].Contains("\"");
        }

        private string GetFinalRuleIdMessage(Dictionary<int, string> rules, int ruleId)
        {
            return rules[ruleId].Trim().Replace("\"", string.Empty)[0].ToString();
        }

        private List<string> GetNonFinalRuleMessages(Dictionary<int, string> rules, List<int> ruleIds)
        {
            var messages = new List<string>();
            var firstRule = true;
            foreach (int ruleId in ruleIds)
            {
                var subMessages = GetRuleIdMessagesRecursive(rules, ruleId);
                if (subMessages.Count == 0)
                {
                    return new List<string>();
                }
                else if (firstRule)
                {
                    messages.AddRange(subMessages);
                    firstRule = false;
                }
                else
                {
                    messages = messages
                        .SelectMany(m =>
                            subMessages
                                .Select(sm => string.Concat(m, sm)))
                        .ToList();
                }
            }

            return messages;
        }
    }
}
