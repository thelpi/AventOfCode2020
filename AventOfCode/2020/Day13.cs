using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2020
{
    /// <summary>
    /// Day 13: Shuttle Search
    /// </summary>
    public sealed class Day13 : DayBase
    {
        public Day13() : base(2020, 13) { }

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
            var (timestamp, enumerableBusList) = GetBusList(sample);

            var busList = enumerableBusList.ToList();
            var busDatas = busList
                .Where(_ => _.HasValue)
                .OrderByDescending(_ => _.Value)
                .Select(_ => (modulo: _.Value, delta: busList.IndexOf(_)))
                .ToArray();
            
            long finalTimestamp = 1;
            var notModulableBusList = true;
            while (notModulableBusList)
            {
                notModulableBusList = false;
                foreach (var (modulo, delta) in busDatas)
                {
                    if ((finalTimestamp + delta) % modulo != 0)
                    {
                        finalTimestamp += busDatas
                            .TakeWhile(_ => _.modulo > modulo)
                            .Aggregate((long)1, (agg, bus) => agg *= bus.modulo);
                        notModulableBusList = true;
                        break;
                    }
                }
            }

            return finalTimestamp;
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
