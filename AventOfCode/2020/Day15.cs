using System;
using System.Linq;

namespace AventOfCode._2020
{
    /// <summary>
    /// Day 15: Rambunctious Recitation
    /// </summary>
    public sealed class Day15 : DayBase
    {
        private const long QUOTES_COUNT_PART_1 = 2020;
        private const long QUOTES_COUNT_PART_2 = 30000000;

        public Day15() : base(2020, 15) { }

        public override long GetFirstPartResult(bool sample)
        {
            return CommonTrunk(sample, QUOTES_COUNT_PART_1);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CommonTrunk(sample, QUOTES_COUNT_PART_2);
        }

        private long CommonTrunk(bool sample, long finalQuotesCount)
        {
            var quotes = GetContent(v => Convert.ToInt32(v), sample: sample);
            
            var latestQuoteByValue = quotes
                .Take(quotes.Count - 1)
                .ToDictionary(v => v, v => quotes.IndexOf(v));

            var initialQuotesCount = quotes.Count;
            for (int i = initialQuotesCount; i < finalQuotesCount; i++)
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
    }
}
