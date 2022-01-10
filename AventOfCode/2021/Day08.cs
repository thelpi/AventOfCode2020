using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day08 : DayBase
    {
        public Day08() : base(2021, 8) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetDatas(sample);

            var match = new[] { 2, 4, 3, 7 };

            long count = 0;
            foreach (var (input, output) in values)
            {
                count += output.Count(_ => match.Contains(_.Length));
            }

            return count;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var values = GetDatas(sample);

            long sum = 0;
            foreach (var (inputs, outputs) in values)
            {
                var figures = new Dictionary<int, string>
                {
                    { 1, inputs.Single(x => x.Length == 2) },
                    { 7, inputs.Single(x => x.Length == 3) },
                    { 4, inputs.Single(x => x.Length == 4) },
                    { 8, inputs.Single(x => x.Length == 7) }
                };
                figures.Add(9, inputs.Single(x => x.Length == 6 && figures[4].All(_ => x.Contains(_))));
                figures.Add(3, inputs.Single(x => x.Length == 5 && figures[1].All(_ => x.Contains(_))));
                figures.Add(6, inputs.Single(x => x.Length == 6 && figures[1].Count(_ => x.Contains(_)) == figures[1].Length - 1));
                figures.Add(0, inputs.Single(x => x.Length == 6 && figures[1].All(_ => x.Contains(_)) && figures[4].Count(_ => x.Contains(_)) == figures[4].Length - 1));
                figures.Add(2, inputs.Single(x => x.Length == 5 && figures[9].Count(_ => x.Contains(_)) == figures[9].Length - 2));
                figures.Add(5, inputs.Single(x => !figures.Values.Contains(x)));

                var fullOutputNumber = "";
                foreach (var output in outputs)
                {
                    fullOutputNumber += figures.Single(x => x.Value.Length == output.Length && x.Value.All(_ => output.Contains(_))).Key.ToString();
                }

                var fullOuputInt = Convert.ToInt32(fullOutputNumber);

                sum += fullOuputInt;
            }

            return sum;
        }

        private List<(string[] input, string[] output)> GetDatas(bool sample)
        {
            return GetContent(v =>
            {
                var twoParts = v.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                var input = twoParts[0].Split(' ');
                var output = twoParts[1].Split(' ');
                return (input, output);
            }, sample: sample);
        }
    }
}
