using System;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 9: Encoding Error
    /// </summary>
    public sealed class Day09 : DayBase
    {
        public Day09() : base(9) { }

        public override long GetFirstPartResult(bool sample)
        {
            var datas = GetContent(v => Convert.ToInt64(v), sample: sample);

            int baseP = sample ? 5 : 25;

            bool ok = true;
            int p = baseP;
            int skip = 0;
            long mark = -1;
            while (ok)
            {
                var lastPCount = datas.Skip(skip).Take(baseP).ToList();

                bool found = false;
                for (int j = 0; j < baseP; j++)
                {
                    for (int k = 0; k < baseP; k++)
                    {
                        if (lastPCount[j] != lastPCount[k])
                        {
                            if (lastPCount[j] + lastPCount[k] == datas[p])
                            {
                                found = true;
                            }
                        }
                    }
                }

                ok = found;
                mark = datas[p];
                p++;
                skip++;
            }

            return mark;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var datas = GetContent(v => Convert.ToInt64(v), sample: sample);

            int baseP = sample ? 5 : 25;

            bool ok = true;
            int p = baseP;
            int skip = 0;
            long mark = -1;
            while (ok)
            {
                var lastPCount = datas.Skip(skip).Take(baseP).ToList();

                bool found = false;
                for (int j = 0; j < baseP; j++)
                {
                    for (int k = 0; k < baseP; k++)
                    {
                        if (lastPCount[j] != lastPCount[k])
                        {
                            if (lastPCount[j] + lastPCount[k] == datas[p])
                            {
                                found = true;
                            }
                        }
                    }
                }

                ok = found;
                mark = datas[p];
                p++;
                skip++;
            }

            int okFirstIndex = -1;
            int okLastIndex = -1;
            for (int i = 0; i < datas.Count; i++)
            {
                int localOkIndex = -1;
                long currentSum = datas[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (currentSum >= mark)
                    {
                        break;
                    }
                    localOkIndex = j;
                    currentSum += datas[j];
                }
                if (currentSum == mark)
                {
                    okLastIndex = i;
                    okFirstIndex = localOkIndex;
                    break;
                }
            }

            var ranged = datas.Skip(okFirstIndex).Take(okLastIndex - okFirstIndex).ToList();

            return ranged.Min() + ranged.Max();
        }
    }
}
