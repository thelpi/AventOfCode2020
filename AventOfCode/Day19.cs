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

            // this is an observation from datas; no way to generalize that easily

            // p8 is one or more repetition of p42

            // p11 is one or more repetition of p42,
            // followed by one or more repetition of p31
            // both parts has the same number of repetition

            // p0 is based on p8 (once) followed by p11 (once)
            // so it's p42 (X) times, then p31 (X - 1) times
            // with X at least 2

            var patterns42 = GetRuleIdMessagesRecursive(rules, 42);
            var patterns31 = GetRuleIdMessagesRecursive(rules, 31);

            var messagesWithValidPattern = new List<string>();
            foreach (var message in messages)
            {
                var workingMessage = message;
                
                var pattern42Count = CountPatterns(patterns42, ref workingMessage);
                
                // at least two pattern 42
                // and the remaining message is not empty
                if (!string.IsNullOrWhiteSpace(workingMessage) && pattern42Count > 1)
                {
                    var countPattern31 = CountPatterns(patterns31, ref workingMessage);
                    // at least one pattern 31
                    // but less than pattern 42
                    // and no remaining
                    if (string.IsNullOrWhiteSpace(workingMessage) && pattern42Count > countPattern31)
                    {
                        messagesWithValidPattern.Add(message);
                    }
                }
            }

            return messagesWithValidPattern.Count;
        }

        private int CountPatterns(List<string> patterns, ref string workingMessage)
        {
            var patternsCount = 0;
            var foundAnyPattern = true;
            while (foundAnyPattern && !string.IsNullOrWhiteSpace(workingMessage))
            {
                bool foundCurrentPattern = false;
                foreach (var pattern in patterns)
                {
                    if (workingMessage.StartsWith(pattern))
                    {
                        workingMessage = workingMessage.Substring(pattern.Length);
                        patternsCount++;
                        foundCurrentPattern = true;
                        break;
                    }
                }
                foundAnyPattern = foundCurrentPattern;
            }
            return patternsCount;
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
