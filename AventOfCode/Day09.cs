using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 9: Encoding Error
    /// </summary>
    public sealed class Day09 : DayBase
    {
        private const int SAMPLE_SUM_SIZE = 5;
        private const int FULL_SUM_SIZE = 25;

        public Day09() : base(9) { }

        public override long GetFirstPartResult(bool sample)
        {
            var (outputsList, weaknessIndex) = FindXmasWeakness(sample);

            return weaknessIndex;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var (outputsList, weaknessIndex) = FindXmasWeakness(sample);

            var rangeIndexBegin = -1;
            var rangeIndexEnd = -1;
            for (int i = 0; i < outputsList.Count; i++)
            {
                long outputsSum = outputsList[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (outputsSum >= weaknessIndex)
                    {
                        break;
                    }
                    rangeIndexBegin = j;
                    outputsSum += outputsList[j];
                }

                if (outputsSum == weaknessIndex)
                {
                    rangeIndexEnd = i;
                    break;
                }
            }

            var outputsRange = outputsList
                .Skip(rangeIndexBegin)
                .Take(rangeIndexEnd - rangeIndexBegin);

            return outputsRange.Min() + outputsRange.Max();
        }

        private (List<long>, long) FindXmasWeakness(bool sample)
        {
            var outputsList = GetContent(v => Convert.ToInt64(v), sample: sample);

            int countToSum = sample ? SAMPLE_SUM_SIZE : FULL_SUM_SIZE;

            var noWeakness = true;
            var startAt = countToSum;
            var skipCount = 0;
            long weaknessIndex = -1;
            while (noWeakness)
            {
                var remainingOutputs = outputsList
                    .Skip(skipCount)
                    .Take(countToSum)
                    .ToArray();

                bool reachSumCount = false;
                for (int j = 0; j < countToSum; j++)
                {
                    for (int k = 0; k < countToSum; k++)
                    {
                        if (remainingOutputs[j] != remainingOutputs[k]
                            && remainingOutputs[j] + remainingOutputs[k] == outputsList[startAt])
                        {
                            reachSumCount = true;
                        }
                    }
                }

                noWeakness = reachSumCount;
                weaknessIndex = outputsList[startAt];
                startAt++;
                skipCount++;
            }

            return (outputsList, weaknessIndex);
        }
    }
}
