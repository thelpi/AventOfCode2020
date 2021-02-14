using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2020
{
    /// <summary>
    /// Day 7: Handy Haversacks
    /// </summary>
    public sealed class Day07 : DayBase
    {
        private const string MY_BAG = "shiny gold";

        public Day07() : base(2020, 7) { }

        public override long GetFirstPartResult(bool sample)
        {
            var bagsInfos = ParseBagsInfos(sample);

            var parentBags = new List<string>();
            RecursiveParentSearch(bagsInfos, MY_BAG, parentBags);

            return parentBags.Distinct().Count();
        }

        public override long GetSecondPartResult(bool sample)
        {
            var bagsInfos = ParseBagsInfos(sample);

            var childrenBagsCount = new List<int>();
            RecursiveChildrenSearch(bagsInfos, MY_BAG, childrenBagsCount);

            return childrenBagsCount.Sum();
        }

        private Dictionary<string, List<(int childCount, string childBagName)>> ParseBagsInfos(bool sample)
        {
            var content = GetContent(v => v, "\r\n", sample: sample);

            var bagsInfos = new Dictionary<string, List<(int, string)>>();

            foreach (var rowContent in content)
            {
                var rowContentWithoutEndingDot =
                    rowContent.EndsWith(".")
                        ? rowContent.Substring(0, rowContent.Length - 1)
                        : rowContent;

                var rowElements = rowContentWithoutEndingDot.Split(" bags contain ");

                var subBags = new List<(int, string)>();
                bagsInfos.Add(rowElements[0], subBags);

                foreach (var childBagRow in rowElements[1].Split(new[] { " bags, ", " bag, " }, StringSplitOptions.None))
                {
                    if (childBagRow != "no other bags")
                    {
                        var childBagRowElements = childBagRow.Split(' ');
                        var childQty = Convert.ToInt32(childBagRowElements[0]);

                        var childName = string.Join(" ", childBagRowElements.Skip(1));
                        if (childName.EndsWith(" bags"))
                        {
                            childName = childName.Substring(0, childName.Length - 5);
                        }
                        else if (childName.EndsWith(" bag"))
                        {
                            childName = childName.Substring(0, childName.Length - 4);
                        }

                        subBags.Add((childQty, childName));
                    }
                }
            }

            return bagsInfos;
        }

        private void RecursiveParentSearch(Dictionary<string, List<(int childCount, string childBagName)>> baseList,
                string bagName,
                List<string> parentsList)
        {
            var immediateParentBags = baseList
                .Where(kvp => kvp.Value.Any(v => v.childBagName == bagName))
                .Select(kvp => kvp.Key)
                .ToList();
            parentsList.AddRange(immediateParentBags);
            foreach (var parentBag in immediateParentBags)
            {
                RecursiveParentSearch(baseList, parentBag, parentsList);
            }
        }

        private void RecursiveChildrenSearch(
            Dictionary<string, List<(int childCount, string childBagName)>> baseList,
            string bagName,
            List<int> childrenCountList)
        {
            var childrenDetails = baseList
                .Where(kvp => kvp.Key == bagName)
                .SelectMany(kvp => kvp.Value)
                .ToList();
            childrenCountList.AddRange(childrenDetails.Select(v => v.childCount));
            foreach (var (childCount, childBagName) in childrenDetails)
            {
                for (int i = 0; i < childCount; i++)
                {
                    RecursiveChildrenSearch(baseList, childBagName, childrenCountList);
                }
            }
        }
    }
}
