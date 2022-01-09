using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day03 : DayBase
    {
        public Day03() : base(2021, 3) { }

        public override long GetFirstPartResult(bool sample)
        {
            var datas = GetDatas(sample);

            var baseLength = datas[0].Length;

            var gammaRateBits = new byte[baseLength];
            var epsilonRateBits = new byte[baseLength];

            for (var i = 0; i < baseLength; i++)
            {
                byte bit = GetMostCommonBit(datas, i);

                gammaRateBits[i] = bit;
                epsilonRateBits[i] = (byte)Math.Abs(1 - bit);
            }

            return GetLong(gammaRateBits) * GetLong(epsilonRateBits);
        }

        public override long GetSecondPartResult(bool sample)
        {
            var datas = GetDatas(sample);

            var baseLength = datas[0].Length;

            return GetCommonBitValue(datas, baseLength, true)
                * GetCommonBitValue(datas, baseLength, false);
        }

        private long GetCommonBitValue(List<byte[]> datas, int baseLength, bool common)
        {
            var filteredDatas = datas;
            for (var i = 0; i < baseLength; i++)
            {
                var bit = GetMostCommonBit(filteredDatas, i);
                bit = common ? bit : (byte)Math.Abs(1 - bit);
                filteredDatas = filteredDatas.Where(d => d[i] == bit).ToList();
                if (filteredDatas.Count == 1) break;
            }

            return GetLong(filteredDatas[0]);
        }

        private List<byte[]> GetDatas(bool sample)
        {
            return GetContent(v => v.ToCharArray().Select(x => Convert.ToByte(x.ToString())).ToArray(), sample: sample);
        }

        private static byte GetMostCommonBit(List<byte[]> datas, int i)
        {
            return datas
                .Select(d => d[i])
                .GroupBy(d => d)
                .OrderByDescending(d => d.Count())
                .ThenByDescending(d => d.Key)
                .First()
                .Key;
        }

        private long GetLong(byte[] bits)
        {
            long total = 0;

            var j = 0;
            for (var i = bits.Length - 1; i >= 0; i--)
            {
                total += bits[i] > 0 ? (long)Math.Pow(2, j) : 0;
                j++;
            }

            return total;
        }
    }
}
