using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day04 : DayBase
    {
        private const int CardSize = 5;

        public Day04() : base(2021, 4) { }

        public override long GetFirstPartResult(bool sample)
        {
            ExtractDrawAndCards(sample, out List<int>  draw, out List<BingoCard>  cards);

            var bingoCardsValues = new List<long>();
            var n = 0;
            foreach (var number in draw)
            {
                var stop = false;
                foreach (var card in cards)
                {
                    card.Check(number);
                    var bingoValue = card.IsBingo();
                    if (bingoValue.HasValue)
                    {
                        bingoCardsValues.Add(bingoValue.Value);
                        stop = true;
                    }
                }
                if (stop)
                {
                    n = number;
                    break;
                }
            }

            return bingoCardsValues[0] * n;
        }

        public override long GetSecondPartResult(bool sample)
        {
            ExtractDrawAndCards(sample, out List<int> draw, out List<BingoCard> cards);

            var bingoCardsValues = new List<long>();
            var n = 0;
            foreach (var number in draw)
            {
                var cardsToRemove = new List<BingoCard>();
                foreach (var card in cards)
                {
                    card.Check(number);
                    var bingoValue = card.IsBingo();
                    if (bingoValue.HasValue)
                    {
                        cardsToRemove.Add(card);
                    }
                }
                if (cardsToRemove.Count > 0)
                {
                    if (cards.Count > 1)
                        cards.RemoveAll(_ => cardsToRemove.Contains(_));
                    else
                    {
                        n = number;
                        bingoCardsValues.Add(cardsToRemove[0].IsBingo().Value);
                        break;
                    }
                }
            }

            return bingoCardsValues[0] * n;
        }

        private void ExtractDrawAndCards(bool sample, out List<int> draw, out List<BingoCard> cards)
        {
            var rows = GetContent(v => v, sample: sample);
            draw = rows[0].Split(',').Select(_ => Convert.ToInt32(_)).ToList();
            cards = new List<BingoCard>();
            var i = 1;
            while (i < rows.Count)
            {
                if (string.IsNullOrWhiteSpace(rows[i]))
                {
                    i++;
                    continue;
                }
                cards.Add(new BingoCard(rows.Skip(i).Take(CardSize).ToArray()));
                i += CardSize;
            }
        }

        private class BingoCell
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Value { get; set; }
            public bool Checked { get; set; }
        }

        private class BingoCard
        {
            private List<BingoCell> _cells;

            public BingoCard(string[] rows)
            {
                _cells = new List<BingoCell>();
                for (var i = 0; i < rows.Length; i++)
                {
                    var line = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (var j = 0; j < line.Length; j++)
                    {
                        _cells.Add(new BingoCell
                        {
                            Checked = false,
                            Value = Convert.ToInt32(line[j]),
                            X = j,
                            Y = i
                        });
                    }
                }
            }

            public void Check(int value)
            {
                _cells.ForEach(x =>
                {
                    if (x.Value == value)
                        x.Checked = true;
                });
            }

            public long? IsBingo()
            {
                var hasRow = _cells.GroupBy(x => x.X).Any(x => x.All(_ => _.Checked));
                var hasCol = _cells.GroupBy(x => x.Y).Any(x => x.All(_ => _.Checked));
                if (!hasRow && !hasCol)
                {
                    return null;
                }

                return _cells.Where(_ => !_.Checked).Sum(_ => _.Value);
            }
        }
    }
}
