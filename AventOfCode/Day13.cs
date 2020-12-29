using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 13: Shuttle Search
    /// </summary>
    public sealed class Day13 : DayBase
    {
        public Day13() : base(13) { }

        public override long GetFirstPartResult(bool sample)
        {
            var (timestamp, busListNullable) = GetBusList(sample);

            var busList = busListNullable
                .Where(_ => _.HasValue)
                .Select(_ => _.Value)
                .ToList();

            var timestampOfBestBus = -1;
            var bestBus = -1;
            foreach (var bus in busList)
            {
                // note: it's an Euclidean division
                // so these 2 operations does not cancel each other 
                var countBusPassBeforeTimestamp = timestamp / bus;
                var closestBusPassTimestamp = countBusPassBeforeTimestamp * bus;

                if (closestBusPassTimestamp < timestamp)
                {
                    closestBusPassTimestamp += bus;
                }
                if (timestampOfBestBus == -1 || closestBusPassTimestamp < timestampOfBestBus)
                {
                    timestampOfBestBus = closestBusPassTimestamp;
                    bestBus = bus;
                }
            }

            return (timestampOfBestBus - timestamp) * bestBus;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var (timestamp, busList) = GetBusList(sample);

            var busDataList = new List<(int modulo, int delta)>();
            var i = 0;
            foreach (var bus in busList)
            {
                if (bus.HasValue)
                {
                    busDataList.Add((bus.Value, i));
                }
                i++;
            }

            var busDatas = busDataList.OrderByDescending(bd => bd.modulo).ToArray();

            long response = -1;

            long j = 1;
            while (response < 0)
            {
                long addedToStart = 0;
                bool atLeastOneNoMatch = false;
                int iBus = 0;
                while (!atLeastOneNoMatch && iBus < busDatas.Length)
                {
                    if ((j + busDatas[iBus].delta) % busDatas[iBus].modulo != 0)
                    {
                        long modulator = 1;
                        for (int kk = 0; kk < iBus; kk++)
                        {
                            modulator *= busDatas[kk].modulo;
                        }
                        addedToStart += modulator;
                        atLeastOneNoMatch = true;
                    }
                    iBus++;
                }

                if (atLeastOneNoMatch)
                {
                    j += addedToStart;
                }
                else
                {
                    response = j;
                }
            }

            return response;
        }

        private (int, IEnumerable<int?>) GetBusList(bool sample)
        {
            var content = GetContent(v => v, sample: sample);
            return (
                Convert.ToInt32(content[0]),
                content[1]
                    .Split(",")
                    .Select(v => v == "x" ? null : (int?)Convert.ToInt32(v))
            );
        }
    }
}
