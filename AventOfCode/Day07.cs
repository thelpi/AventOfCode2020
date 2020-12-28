using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AventOfCode
{
    /// <summary>
    /// Day 7: Handy Haversacks
    /// </summary>
    public sealed class Day07 : DayBase
    {
        public Day07() : base(7) { }

        public override long GetFirstPartResult(bool sample)
        {
            var datas = GetContent(v => v, "\r\n", sample: sample);

            var finalList = new Dictionary<string, List<(int, string)>>();

            foreach (var d in datas)
            {
                var realD = d;
                if (realD.EndsWith("."))
                {
                    realD = realD.Substring(0, realD.Length - 1);
                }

                var sub = realD.Split(" bags contain ");

                List<(int, string)> subBags = new List<(int qty, string val)>();
                finalList.Add(sub[0], subBags);

                foreach (var dd in sub[1].Split(new[] { " bags, ", " bag, " }, StringSplitOptions.None))
                {
                    if (dd != "no other bags")
                    {
                        var ddd = dd.Split(' ');
                        var vall = string.Join(" ", ddd.Skip(1));
                        if (vall.EndsWith(" bags"))
                        {
                            vall = vall.Substring(0, vall.Length - 5);
                        }
                        else if (vall.EndsWith(" bag"))
                        {
                            vall = vall.Substring(0, vall.Length - 4);
                        }
                        subBags.Add((Convert.ToInt32(ddd[0]), vall));
                    }
                    else
                    {

                    }
                }
            }

            // part one
            void RecursiveSearchUp(Dictionary<string, List<(int, string)>> baseList,
                string search, List<string> finaLList)
            {
                List<string> bagsWithSearch = baseList.Where(kvp => kvp.Value.Any(v => v.Item2 == search)).Select(kvp => kvp.Key).ToList();
                finaLList.AddRange(bagsWithSearch);
                foreach (var bagWithSearch in bagsWithSearch)
                {
                    RecursiveSearchUp(baseList, bagWithSearch, finaLList);
                }
            }

            List<string> foundList = new List<string>();
            RecursiveSearchUp(finalList, "shiny gold", foundList);

            var count = foundList.Distinct().Count();

            return count;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var datas = GetContent(v => v, "\r\n", sample: sample);

            var finalList = new Dictionary<string, List<(int, string)>>();

            foreach (var d in datas)
            {
                var realD = d;
                if (realD.EndsWith("."))
                {
                    realD = realD.Substring(0, realD.Length - 1);
                }

                var sub = realD.Split(" bags contain ");

                List<(int, string)> subBags = new List<(int qty, string val)>();
                finalList.Add(sub[0], subBags);

                foreach (var dd in sub[1].Split(new[] { " bags, ", " bag, " }, StringSplitOptions.None))
                {
                    if (dd != "no other bags")
                    {
                        var ddd = dd.Split(' ');
                        var vall = string.Join(" ", ddd.Skip(1));
                        if (vall.EndsWith(" bags"))
                        {
                            vall = vall.Substring(0, vall.Length - 5);
                        }
                        else if (vall.EndsWith(" bag"))
                        {
                            vall = vall.Substring(0, vall.Length - 4);
                        }
                        subBags.Add((Convert.ToInt32(ddd[0]), vall));
                    }
                    else
                    {

                    }
                }
            }

            // part two
            void RecursiveSearchDown(Dictionary<string, List<(int, string)>> baseList,
            string search, List<(int, string)> finaLList)
            {
                var vals = baseList.Where(kvp => kvp.Key == search).SelectMany(kvp => kvp.Value).ToList();
                finaLList.AddRange(vals);
                foreach (var val in vals)
                {
                    for (int i = 0; i < val.Item1; i++)
                    {
                        RecursiveSearchDown(baseList, val.Item2, finaLList);
                    }
                }
            }

            var foundList2 = new List<(int, string)>();
            RecursiveSearchDown(finalList, "shiny gold", foundList2);

            return foundList2.Sum(kvp => kvp.Item1);
        }
    }
}
