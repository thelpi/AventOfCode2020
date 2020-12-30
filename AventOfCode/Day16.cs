using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 16: Ticket Translation
    /// </summary>
    public sealed class Day16 : DayBase
    {
        private const string EXPECTED_FIELDS_PATTERN = "departure";

        public Day16() : base(16) { }

        public override long GetFirstPartResult(bool sample)
        {
            return CommonTrunk(sample, out List<int> myTicket, out List<List<int>> tickets,
                out List<(string name, (int, int) range1, (int, int) range2)> fields,
                out List<int> invalidTickets);
        }

        public override long GetSecondPartResult(bool sample)
        {
            CommonTrunk(sample, out List<int> myTicket, out List<List<int>> tickets,
                out List<(string name, (int, int) range1, (int, int) range2)> fields,
                out List<int> invalidTickets);

            // exclude invalid tickets...
            invalidTickets.Sort();
            invalidTickets.Reverse();
            foreach (var invalidTicket in invalidTickets)
            {
                tickets.RemoveAt(invalidTicket);
            }

            // ...then includes mine
            tickets.Add(myTicket);

            // groups tickets values by field
            var valuesByIndexes = Enumerable
                .Range(0, fields.Count)
                .Select(i => tickets.Select(t => t[i]));

            // for each field, finds indexes from "valuesByIndexes"
            // where every element of the index' sublist matches at least one range of the field
            var matchingIndexesByField = new Dictionary<string, List<int>>();
            foreach (var (name, range1, range2) in fields)
            {
                matchingIndexesByField.Add(
                    name,
                    Enumerable.Range(0, valuesByIndexes.Count())
                        .Where(i => valuesByIndexes.ElementAt(i).All(v =>
                            (v >= range1.Item1 && v <= range1.Item2)
                            || (v >= range2.Item1 && v <= range2.Item2)))
                        .ToList());
            }

            // sorts (asc) by the number of indexes that match the field, then builds the dictionary
            // that way, the first field will have only one list
            // the second field two lists, etc...
            var indexPickByField = new Dictionary<string, int>();
            foreach (var fieldWithIndexes in matchingIndexesByField.OrderBy(kvp => kvp.Value.Count))
            {
                // for each field, sets the appropriate index from indexes list
                // as we clean indexes we use in the loop
                // it should always be one and one index possible for each field
                var singlePossibleIndex = fieldWithIndexes.Value.First();
                indexPickByField.Add(fieldWithIndexes.Key, singlePossibleIndex);
                // clean picked index from source list
                foreach (var localFieldWithIndexes in matchingIndexesByField)
                {
                    localFieldWithIndexes.Value.Remove(singlePossibleIndex);
                }
            }

            // sum of values, for my ticket, with a field name that matches the pattern
            // note: value for sample has been made up (not in the original exercice)
            return indexPickByField
                .Where(kvp => kvp.Key.Contains(sample ? "a" : EXPECTED_FIELDS_PATTERN))
                .Aggregate((long)1, (agg, kvp) => agg *= myTicket[kvp.Value]);
        }

        private long CommonTrunk(bool sample, out List<int> myTicket, out List<List<int>> tickets, out List<(string name, (int, int) range1, (int, int) range2)> fields, out List<int> invalidTickets)
        {
            var datas = GetContent(v => v, "\r\n\r\n", sample);

            myTicket = datas[1].Split("\r\n")[1].Split(",").Select(v => Convert.ToInt32(v)).ToList();
            tickets = datas[2].Split("\r\n").Skip(1).Select(v => v.Split(",").Select(v2 => Convert.ToInt32(v2)).ToList()).ToList();
            fields = datas[0].Split("\r\n").Select(v =>
            {
                var withName = v.Split(": ");
                var name = withName[0];
                var bornes = withName[1].Split(" or ");
                var range1 = (Convert.ToInt32(bornes[0].Split("-")[0]), Convert.ToInt32(bornes[0].Split("-")[1]));
                var range2 = (Convert.ToInt32(bornes[1].Split("-")[0]), Convert.ToInt32(bornes[1].Split("-")[1]));
                return (name, range1, range2);
            }).ToList();

            // for each ticket, find values that doesn't match any range
            long invalidTicketsValuesSum = 0;
            int iTicket = 0;
            invalidTickets = new List<int>();
            foreach (var ticket in tickets)
            {
                foreach (var ticketValue in ticket)
                {
                    bool isValid = false;
                    foreach (var (name, range1, range2) in fields)
                    {
                        if ((ticketValue >= range1.Item1 && ticketValue <= range1.Item2)
                            || (ticketValue >= range2.Item1 && ticketValue <= range2.Item2))
                        {
                            isValid = true;
                        }
                    }
                    if (!isValid)
                    {
                        invalidTicketsValuesSum += ticketValue;
                        invalidTickets.Add(iTicket);
                    }
                }
                iTicket++;
            }

            return invalidTicketsValuesSum;
        }
    }
}
