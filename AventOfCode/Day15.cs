using System;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 15: Rambunctious Recitation
    /// </summary>
    public sealed class Day15 : DayBase
    {
        public Day15() : base(15) { }

        public override long GetFirstPartResult(bool sample)
        {
            var expectedQuotesCount = 2020;

            var quotes = GetContent(v => Convert.ToInt32(v), sample: sample);
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

        public override long GetSecondPartResult(bool sample)
        {
            var expectedQuotesCount = 30000000;

            var quotes = GetContent(v => Convert.ToInt32(v), sample: sample);
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
    }
}
