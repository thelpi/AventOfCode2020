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
        public Day16() : base(16) { }

        public override long GetFirstPartResult(bool sample)
        {
            var datas = GetContent(v => v, "\r\n\r\n", sample);

            var myTicket = datas[1].Split("\r\n")[1].Split(",").Select(v => Convert.ToInt32(v)).ToList();
            var tickets = datas[2].Split("\r\n").Skip(1).Select(v => v.Split(",").Select(v2 => Convert.ToInt32(v2)).ToList()).ToList();
            var fields = datas[0].Split("\r\n").Select(v =>
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
            var invalidTickets = new List<int>();
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

        public override long GetSecondPartResult(bool sample)
        {
            var datas = GetContent(v => v, "\r\n\r\n", sample);

            var myTicket = datas[1].Split("\r\n")[1].Split(",").Select(v => Convert.ToInt32(v)).ToList();
            var tickets = datas[2].Split("\r\n").Skip(1).Select(v => v.Split(",").Select(v2 => Convert.ToInt32(v2)).ToList()).ToList();
            var fields = datas[0].Split("\r\n").Select(v =>
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
            var invalidTickets = new List<int>();
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
            var valuesByIndexes = new List<List<int>>();
            for (int i = 0; i < fields.Count; i++)
            {
                var valuesForField = new List<int>();
                foreach (var ticket in tickets)
                {
                    valuesForField.Add(ticket[i]);
                }
                valuesByIndexes.Add(valuesForField);
            }

            // for each field, finds indexes from "valuesByIndexes"
            // where every element of the index' sublist matches at least one range of the field
            var matchingIndexesByField = new Dictionary<string, List<int>>();
            foreach (var (name, range1, range2) in fields)
            {
                var matchingIndexes = new List<int>();
                var iIndex = 0;
                foreach (var indexValues in valuesByIndexes)
                {
                    if (indexValues.All(v =>
                        (v >= range1.Item1 && v <= range1.Item2)
                        || (v >= range2.Item1 && v <= range2.Item2)))
                    {
                        matchingIndexes.Add(iIndex);
                    }
                    iIndex++;
                }
                matchingIndexesByField.Add(name, matchingIndexes);
            }

            // sorts (asc) by the number of indexes that match the field, then rebuilds the dictionary
            // that way, the first field will have only one list
            // the second field two lists, etc...
            matchingIndexesByField = matchingIndexesByField
                .OrderBy(kvp => kvp.Value.Count)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            // for each field, sets the appropriate index from indexes list
            // as we clean indexes we use in the loop
            // it should always be one and one index possible for each field
            var indexPickByField = new Dictionary<string, int>();
            int fieldsCount = matchingIndexesByField.Count; // stores the count to avoid exception "the collection has changed"
            for (int i = 0; i < fieldsCount; i++)
            {
                var fieldWithIndexes = matchingIndexesByField.ElementAt(i);
                var singlePossibleIndex = fieldWithIndexes.Value.First();
                indexPickByField.Add(fieldWithIndexes.Key, singlePossibleIndex);
                // clean picked index from source list
                foreach (var localFieldWithIndexes in matchingIndexesByField)
                {
                    localFieldWithIndexes.Value.Remove(singlePossibleIndex);
                }
            }

            // builds "my ticket" values by field
            var myTicketValues = indexPickByField.ToDictionary(
                kvp => kvp.Key,
                kvp => myTicket[indexPickByField[kvp.Key]]);

            // note: value for sample has been made up (not in the original exercice)
            var EXPECTED_FIELDS_PATTERN = sample ? "a" : "departure";

            // sum of values, for my ticket, with a field name that matches the pattern
            long result = 1;
            foreach (var field in myTicketValues.Keys)
            {
                if (field.Contains(EXPECTED_FIELDS_PATTERN))
                {
                    result *= myTicketValues[field];
                }
            }

            return result;
        }
    }
}
