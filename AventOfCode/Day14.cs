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
        public Day14() : base(14) { }

        public override long GetFirstPartResult(bool sample)
        {
            var datas = GetContent(v =>
            {
                var parts = v.Split("\r\n");
                var mask = parts[0].Replace("mask = ", "");
                var bytes = parts
                    .Skip(1)
                    .Select(p =>
                    {
                        var e1 = p.Split(" = ")[0].Replace("mem[", "").Replace("]", "");
                        var e2 = p.Split(" = ")[1];
                        return (Convert.ToInt64(e1), Convert.ToInt64(e2));
                    })
                    .ToList();

                return (mask, bytes);
            }, "\r\n\r\n", sample, sample ? 1 : (int?)null);

            const int SIZE_MASK = 36;

            var newDatas = new List<(string, List<(long, long)>)>();

            long GetIntFromBitArray(BitArray bitArray)
            {
                var array = new byte[8];
                bitArray.CopyTo(array, 0);
                return BitConverter.ToInt64(array, 0);
            }

            for (int i = 0; i < datas.Count; i++)
            {
                var (mask, bytes) = datas[i];
                mask = new String(mask.Reverse().ToArray());
                var newBytes = new List<(long, long)>();
                foreach (var singleByteDatas in bytes)
                {
                    byte[] bytesDatas = BitConverter.GetBytes(singleByteDatas.Item2);
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

                    newBytes.Add((singleByteDatas.Item1, GetIntFromBitArray(newBitArray)));
                }
                newDatas.Add((mask, newBytes));
            }

            var cleanedDatas = newDatas.SelectMany(kvp => kvp.ToTuple().Item2).ToList();

            var ccCleaner = cleanedDatas.GroupBy(kvp => kvp.Item1).Select(kvp => kvp.Last()).ToList();

            return ccCleaner.Sum(cccc => cccc.Item2);
        }

        public override long GetSecondPartResult(bool sample)
        {
            var datas = GetContent(v =>
            {
                var parts = v.Split("\r\n");
                var mask = parts[0].Replace("mask = ", "");
                var bytes = parts
                    .Skip(1)
                    .Select(p =>
                    {
                        var e1 = p.Split(" = ")[0].Replace("mem[", "").Replace("]", "");
                        var e2 = p.Split(" = ")[1];
                        return (Convert.ToInt64(e1), Convert.ToInt64(e2));
                    })
                    .ToList();

                return (mask, bytes);
            }, "\r\n\r\n", sample, sample ? 2 : (int?)null);

            const int SIZE_MASK = 36;

            var newDatas = new List<(string, List<(long, long)>)>();

            long GetIntFromBitArray(BitArray bitArray)
            {
                var array = new byte[8];
                bitArray.CopyTo(array, 0);
                return BitConverter.ToInt64(array, 0);
            }

            foreach (var data in datas)
            {
                var (mask, bytes) = data;
                mask = new String(mask.Reverse().ToArray());
                foreach (var singleByteDatas in bytes)
                {
                    byte[] bytesDatas = BitConverter.GetBytes(singleByteDatas.Item1);
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
                        newVs.Add((newKey, singleByteDatas.Item2));
                    }
                    newDatas.Add((mask, newVs));
                }
            }

            var cleanedDatas = newDatas.SelectMany(kvp => kvp.ToTuple().Item2).ToList();

            var ccCleaner = cleanedDatas.GroupBy(kvp => kvp.Item1).Select(kvp => kvp.Last()).ToList();

            return ccCleaner.Sum(cccc => cccc.Item2);
        }
    }
}
