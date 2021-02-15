using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2019
{
    /// <summary>
    /// Day 6: Universal Orbit Map
    /// </summary>
    public sealed class Day06 : DayBase
    {
        public Day06() : base(2019, 6) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetContent(v => (v.Split(')')[0], v.Split(')')[1]), sample: sample);

            var planets = values.Select(_ => _.Item2).Distinct().ToList();

            long countOrbits = 0;
            foreach (var p in planets)
            {
                countOrbits += Recursive(values, p);
            }

            return countOrbits;
        }

        private int Recursive(List<(string, string)> values, string p)
        {
            var whereOrbit = values.Where(_ => _.Item2 == p).ToList();
            int countOrbits = whereOrbit.Count;
            var parentPlanet = whereOrbit.Select(_ => _.Item1).Distinct().ToList();
            foreach (var pp in parentPlanet)
            {
                countOrbits += Recursive(values, pp);
            }
            return countOrbits;
        }

        public override long GetSecondPartResult(bool sample)
        {
            throw new Exception();
        }
    }
}
