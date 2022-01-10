using System;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day07 : DayBase
    {
        public Day07() : base(2021, 7) { }

        public override long GetFirstPartResult(bool sample)
        {
            return BaseAlgorithm(sample, (i, crab) =>
            {
                return crab > i ? crab - i : i - crab;
            });
        }

        public override long GetSecondPartResult(bool sample)
        {
            return BaseAlgorithm(sample, (i, crab) =>
            {
                var subSum = 0;
                var k = 1;
                for (var j = crab > i ? i : crab; j < (crab > i ? crab : i); j++)
                {
                    subSum += k++;
                }

                return subSum;
            });
        }

        private long BaseAlgorithm(bool sample, Func<int, int, int> subSumFunc)
        {
            var crabs = GetContent(x => x.Split(',').Select(_ => Convert.ToInt32(_)).ToList(), sample: sample).First();

            var bestMoveSum = long.MaxValue;
            for (var i = crabs.Min(); i <= crabs.Max(); i++)
            {
                long moveSum = crabs.Sum(x => (long)subSumFunc(i, x));
                if (moveSum < bestMoveSum)
                    bestMoveSum = moveSum;
                else if (moveSum > bestMoveSum)
                    break;
            }

            return bestMoveSum;
        }
    }
}
