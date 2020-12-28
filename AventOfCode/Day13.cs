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
            var content = GetContent(v => v, sample: sample);

            var timestamp = Convert.ToInt32(content[0]);
            var buses1 = content[1].Split(",").Where(v => v != "x").Select(v => Convert.ToInt32(v)).ToList();

            var currentBast = -1;
            var busOk = -1;
            foreach (var bus in buses1)
            {
                var ratio = timestamp / bus;
                var fromRatio = bus * ratio;
                if (fromRatio < timestamp)
                {
                    fromRatio += bus;
                }
                if (currentBast == -1 || fromRatio < currentBast)
                {
                    currentBast = fromRatio;
                    busOk = bus;
                }
            }

            return (currentBast - timestamp) * busOk;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var content = GetContent(v => v, sample: sample);

            var buses2 = content[1].Split(",").Select(v => v == "x" ? null : (int?)Convert.ToInt32(v)).ToList();

            var busDataList = new List<(int modulo, int delta)>();
            var i = 0;
            foreach (var bus in buses2)
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
    }
}
