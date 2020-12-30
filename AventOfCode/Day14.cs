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
            return CommonTrunk(sample, true);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CommonTrunk(sample, false);
        }

        private long CommonTrunk(bool sample, bool firstPart)
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
                }, "\r\n\r\n", sample, sample ? (firstPart ? 1 : 2) : (int?)null)
                .ToDictionary(v => v.Item1, v => v.Item2);

            var newMemorySets = new List<(long, long)>();

            foreach (var reversedMask in memorySetsByMask.Keys)
            {
                var memorySet = memorySetsByMask[reversedMask];
                var mask = new String(reversedMask.Reverse().ToArray());
                var newMemorySet = new List<(long, long)>();
                foreach (var (address, value) in memorySet)
                {
                    if (firstPart)
                    {
                        byte[] bytesDatas = BitConverter.GetBytes(value);
                        var b = new BitArray(bytesDatas);
                        int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();

                        for (int j = 0; j < SIZE_MASK; j++)
                        {
                            if (mask[j] == ZERO)
                            {
                                bits[j] = 0;
                            }
                            else if (mask[j] == ONE)
                            {
                                bits[j] = 1;
                            }
                        }

                        BitArray newBitArray = new BitArray(bits.Select(bb => bb == 1).ToArray());

                        newMemorySet.Add((address, GetIntFromBitArray(newBitArray)));
                    }
                    else
                    {
                        byte[] bytesDatas = BitConverter.GetBytes(address);
                        var b = new BitArray(bytesDatas);
                        int?[] bits = b.Cast<bool>().Select(bit => bit ? (int?)1 : 0).ToArray();

                        for (int j = 0; j < SIZE_MASK; j++)
                        {
                            if (mask[j] == X)
                            {
                                bits[j] = null;
                            }
                            else if (mask[j] == ONE)
                            {
                                bits[j] = 1;
                            }
                        }

                        var allBits = new List<int?[]> { bits };
                        var countXToChange = bits.Count(bbb => !bbb.HasValue);
                        for (int k = 0; k < bits.Length; k++)
                        {
                            if (bits[k] != null)
                            {
                                continue;
                            }

                            var allBits2 = new List<int?[]>();
                            foreach (var albb in allBits)
                            {
                                int?[] bitZub0 = new int?[albb.Length];
                                int?[] bitZub1 = new int?[albb.Length];
                                albb.CopyTo(bitZub0, 0);
                                albb.CopyTo(bitZub1, 0);
                                bitZub0[k] = 0;
                                bitZub1[k] = 1;
                                allBits2.Add(bitZub0);
                                allBits2.Add(bitZub1);
                            }
                            allBits.Clear();
                            allBits.AddRange(allBits2);
                        }

                        allBits.RemoveAll(alb => alb.Contains(null));

                        foreach (var bi in allBits)
                        {
                            BitArray newBitArray = new BitArray(bi.Select(bb => bb == 1).ToArray());
                            long newKey = GetIntFromBitArray(newBitArray);
                            newMemorySets.Add((newKey, value));
                        }
                    }
                }
                newMemorySets.AddRange(newMemorySet);
            }

            // sum of the latest value for each address
            return newMemorySets
                .GroupBy(_ => _.Item1)
                .Select(_ => _.Last())
                .Sum(_ => _.Item2);
        }

        private long GetIntFromBitArray(BitArray bitArray)
        {
            var array = new byte[bitArray.Count / 8];
            bitArray.CopyTo(array, 0);
            return BitConverter.ToInt64(array, 0);
        }
    }
}
