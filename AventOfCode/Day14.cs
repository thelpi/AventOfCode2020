using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 14: Docking Data
    /// </summary>
    public sealed class Day14 : DayBase
    {
        private const int SIZE_MASK = 36;
        private const char ZERO = '0';
        private const char ONE = '1';
        private const char X = 'X';

        public Day14() : base(14) { }

        public override long GetFirstPartResult(bool sample)
        {
            return CommonTrunk(sample, 1, (mask, address, value) =>
            {
                var bits = ToBitsArray(mask, value, X);
                return Enumerable.Repeat((address, ToLong(bits)), 1);
            });
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CommonTrunk(sample, 2, (mask, address, value) =>
            {
                var bits = ToBitsArray(mask, address, ZERO);

                var bitsCollection = new List<bool?[]> { bits };
                for (int i = 0; i < bits.Length; i++)
                {
                    if (!bits[i].HasValue)
                    {
                        // replace each undefined mask bit by
                        // one version with 0
                        // one version with 1
                        var replacementBitsCollection = new List<bool?[]>();
                        foreach (var localBits in bitsCollection)
                        {
                            replacementBitsCollection.Add(CopyAndSwitch(localBits, i, false));
                            replacementBitsCollection.Add(CopyAndSwitch(localBits, i, true));
                        }
                        bitsCollection.Clear();
                        bitsCollection.AddRange(replacementBitsCollection);
                    }
                }

                return bitsCollection.Select(_ => (ToLong(_), value));
            });
        }

        private long CommonTrunk(bool sample, int samplePart,
            Func<string, long, long, IEnumerable<(long, long)>> memorySetsCallback)
        {
            var memorySetsByMask = GetContent(v =>
                {
                    var parts = v.Split("\r\n");
                    return (
                        parts[0].Replace("mask = ", ""),
                        parts
                            .Skip(1)
                            .Select(p =>
                            {
                                return (
                                    Convert.ToInt64(p.Split(" = ")[0].Replace("mem[", "").Replace("]", "")),
                                    Convert.ToInt64(p.Split(" = ")[1])
                                );
                            })
                            .ToList()
                    );
                }, "\r\n\r\n", sample, sample ? samplePart : (int?)null)
                .ToDictionary(v => v.Item1, v => v.Item2);

            var newMemorySets = new List<(long, long)>();

            foreach (var reversedMask in memorySetsByMask.Keys)
            {
                var memorySet = memorySetsByMask[reversedMask];
                var mask = new String(reversedMask.Reverse().ToArray());
                foreach (var (address, value) in memorySet)
                {
                    newMemorySets.AddRange(memorySetsCallback(mask, address, value));
                }
            }

            // sum of the latest value for each address
            return newMemorySets
                .GroupBy(_ => _.Item1)
                .Select(_ => _.Last())
                .Sum(_ => _.Item2);
        }

        private long ToLong(bool?[] bits)
        {
            BitArray bitArray = new BitArray(bits.Select(bb => bb == true).ToArray());
            var tmpArray = new byte[bitArray.Count / 8];
            bitArray.CopyTo(tmpArray, 0);
            return BitConverter.ToInt64(tmpArray, 0);
        }

        private bool?[] ToBitsArray(string mask, long value, char exclude)
        {
            var bits = new BitArray(BitConverter.GetBytes(value))
                .Cast<bool?>()
                .ToArray();

            for (int j = 0; j < SIZE_MASK; j++)
            {
                if (exclude != mask[j])
                {
                    if (mask[j] == X) bits[j] = null;
                    else if (mask[j] == ONE) bits[j] = true;
                    else if (mask[j] == ZERO) bits[j] = false;
                }
            }

            return bits;
        }

        private bool?[] CopyAndSwitch(bool?[] bits, int i, bool value)
        {
            var switchedBits = new bool?[bits.Length];
            bits.CopyTo(switchedBits, 0);
            switchedBits[i] = value;
            return switchedBits;
        }
    }
}
