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
            var datas = GetContent(v => v, "\r\n\r\n", sample: sample);
            var p1 = datas[0].Split("\r\n").Skip(1).Select(v => Convert.ToInt32(v)).ToList();
            var p2 = datas[1].Split("\r\n").Skip(1).Select(v => Convert.ToInt32(v)).ToList();

            List<int> winner;

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

            return Score(winner);
        }

        public override long GetSecondPartResult(bool sample)
        {
            var datas = GetContent(v => v, "\r\n\r\n", sample: sample);
            var p1 = datas[0].Split("\r\n").Skip(1).Select(v => Convert.ToInt32(v)).ToList();
            var p2 = datas[1].Split("\r\n").Skip(1).Select(v => Convert.ToInt32(v)).ToList();

            List<int> winner;
            
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

            return Score(winner);
        }

        private long Score(List<int> winnerLocal)
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
    }
}
