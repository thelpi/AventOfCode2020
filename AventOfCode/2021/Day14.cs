using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day14 : DayBase
    {
        public Day14() : base(2021, 14) { }

        public override long GetFirstPartResult(bool sample)
        {
            return InternalCompute(sample, 10);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return InternalCompute(sample, 40);
        }

        private long InternalCompute(bool sample, int steps)
        {
            var values = GetContent(v => v, sample: sample);

            var linked = new LinkedList<char>(values[0].ToCharArray());
            var trans = values.Skip(2).Select(x => x.Split(" -> ")).ToDictionary(x => (x[0][0], x[0][1]), x => x[1][0]);

            for (var step = 1; step <= steps; step++)
            {
                var node = linked.First;
                while (true)
                {
                    var nextNode = node.Next;
                    var w = (node.Value, nextNode.Value);
                    if (trans.ContainsKey(w))
                    {
                        linked.AddAfter(node, trans[w]);
                        node = node.Next.Next;
                    }
                    else
                    {
                        node = nextNode;
                    }
                    if (node == linked.Last)
                        break;
                }
            }

            var groups = linked
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Count())
                .ToList();

            return groups[0] - groups[groups.Count - 1];
        }
    }
}
