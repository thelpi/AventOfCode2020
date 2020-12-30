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

        public Day14() : base(14) { }

        public override long GetFirstPartResult(bool sample)
        {
            var datas = GetDatas(sample, true);

            var newDatas = new List<(string, List<(long, long)>)>();

            foreach (var maskOrigin in datas.Keys)
            {
                var bytes = datas[maskOrigin];
                var mask = new String(maskOrigin.Reverse().ToArray());
                var newBytes = new List<(long, long)>();
                foreach (var (adr, val) in bytes)
                {
                    byte[] bytesDatas = BitConverter.GetBytes(val);
                    var b = new BitArray(bytesDatas);
                    int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();

                    for (int j = 0; j < SIZE_MASK; j++)
                    {
                        if (mask[j] == '0')
                        {
                            bits[j] = 0;
                        }
                        else if (mask[j] == '1')
                        {
                            bits[j] = 1;
                        }
                    }

                    BitArray newBitArray = new BitArray(bits.Select(bb => bb == 1).ToArray());

                    newBytes.Add((adr, GetIntFromBitArray(newBitArray)));
                }
                newDatas.Add((mask, newBytes));
            }

            var cleanedDatas = newDatas.SelectMany(kvp => kvp.ToTuple().Item2).ToList();

            var ccCleaner = cleanedDatas.GroupBy(kvp => kvp.Item1).Select(kvp => kvp.Last()).ToList();

            return ccCleaner.Sum(cccc => cccc.Item2);
        }

        public override long GetSecondPartResult(bool sample)
        {
            var datas = GetDatas(sample, false);

            var newDatas = new List<(string, List<(long, long)>)>();

            foreach (var maskOrigin in datas.Keys)
            {
                var bytes = datas[maskOrigin];
                var mask = new String(maskOrigin.Reverse().ToArray());
                foreach (var (adr, val) in bytes)
                {
                    byte[] bytesDatas = BitConverter.GetBytes(adr);
                    var b = new BitArray(bytesDatas);
                    int?[] bits = b.Cast<bool>().Select(bit => bit ? (int?)1 : 0).ToArray();

                    for (int j = 0; j < SIZE_MASK; j++)
                    {
                        if (mask[j] == 'X')
                        {
                            bits[j] = null;
                        }
                        else if (mask[j] == '1')
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

                    var newVs = new List<(long, long)>();
                    foreach (var bi in allBits)
                    {
                        BitArray newBitArray = new BitArray(bi.Select(bb => bb == 1).ToArray());
                        long newKey = GetIntFromBitArray(newBitArray);
                        newVs.Add((newKey, val));
                    }
                    newDatas.Add((mask, newVs));
                }
            }

            var cleanedDatas = newDatas.SelectMany(kvp => kvp.ToTuple().Item2).ToList();

            var ccCleaner = cleanedDatas.GroupBy(kvp => kvp.Item1).Select(kvp => kvp.Last()).ToList();

            return ccCleaner.Sum(cccc => cccc.Item2);
        }

        private Dictionary<string, List<(long adr, long val)>> GetDatas(bool sample, bool firstPart)
        {
            return GetContent(v =>
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
        }

        private long GetIntFromBitArray(BitArray bitArray)
        {
            var array = new byte[bitArray.Count / 8];
            bitArray.CopyTo(array, 0);
            return BitConverter.ToInt64(array, 0);
        }
    }
}
