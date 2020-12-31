using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 22: Crab Combat
    /// </summary>
    public sealed class Day22 : DayBase
    {
        public Day22() : base(22) { }

        public override long GetFirstPartResult(bool sample)
        {
            GetPlayerDecks(sample, out List<int> p1Deck, out List<int> p2Deck);

            while (p1Deck.Count > 0 && p2Deck.Count > 0)
            {
                Round(p1Deck, p2Deck, false);
            }

            return ComputeScore(p1Deck.Count == 0 ? p2Deck : p1Deck);
        }

        public override long GetSecondPartResult(bool sample)
        {
            GetPlayerDecks(sample, out List<int> p1, out List<int> p2);

            var p1Win = RecursiveRound(p1, p2, new List<string>(), new List<string>());

            return ComputeScore(p1Win ? p1 : p2);
        }

        private void GetPlayerDecks(bool sample, out List<int> p1Deck, out List<int> p2Deck)
        {
            var datas = GetContent(v => v, "\r\n\r\n", sample: sample);
            p1Deck = datas[0].Split("\r\n").Skip(1).Select(v => Convert.ToInt32(v)).ToList();
            p2Deck = datas[1].Split("\r\n").Skip(1).Select(v => Convert.ToInt32(v)).ToList();
        }

        private long ComputeScore(List<int> winnerDeck)
        {
            long score = 0;
            var j = 1;
            for (int i = winnerDeck.Count - 1; i >= 0; i--)
            {
                score += winnerDeck[i] * j;
                j++;
            }
            return score;
        }

        private bool RecursiveRound(List<int> p1Deck, List<int> p2Deck,
            List<string> p1DecksHistory, List<string> p2DecksHistory)
        {
            while (p1Deck.Count > 0 && p2Deck.Count > 0)
            {
                var p1DeckString = ToString(p1Deck);
                var p2DeckString = ToString(p2Deck);
                for (int k = 0; k < p1DecksHistory.Count; k++)
                {
                    if (p1DecksHistory[k] == p1DeckString
                        && p2DecksHistory[k] == p2DeckString)
                    {
                        // Hard break
                        return true;
                    }
                }

                p1DecksHistory.Add(p1DeckString);
                p2DecksHistory.Add(p2DeckString);

                Round(p1Deck, p2Deck, true);
            }

            return p1Deck.Count > 0;
        }

        private void Round(List<int> p1Deck, List<int> p2Deck, bool recursive)
        {
            var p1Card = p1Deck[0];
            var p2Card = p2Deck[0];
            var isP1Win = recursive
                && p1Card <= p1Deck.Count - 1
                && p2Card <= p2Deck.Count - 1
                    ? RecursiveRound(
                        p1Deck.Skip(1).Take(p1Card).ToList(),
                        p2Deck.Skip(1).Take(p2Card).ToList(),
                        new List<string>(),
                        new List<string>())
                    : p1Card > p2Card;
            p1Deck.RemoveAt(0);
            p2Deck.RemoveAt(0);
            if (isP1Win)
            {
                p1Deck.Add(p1Card);
                p1Deck.Add(p2Card);
            }
            else
            {
                p2Deck.Add(p2Card);
                p2Deck.Add(p1Card);
            }
        }

        private string ToString(List<int> deck)
        {
            return string.Join(",", deck);
        }
    }
}
