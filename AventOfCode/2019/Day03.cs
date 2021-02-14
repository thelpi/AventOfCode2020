using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2019
{
    /// <summary>
    /// Day 3: Crossed Wires
    /// </summary>
    public sealed class Day03 : DayBase
    {
        public Day03() : base(2019, 3) { }

        public override long GetFirstPartResult(bool sample)
        {
            CommonTrunk(sample,
                out List<(int left, int top)> wire1Points,
                out List<(int left, int top)> wire2Points);

            return GetMinimalValue(
                wire1Points,
                wire2Points,
                _ => Math.Abs(_.Item1) + Math.Abs(_.Item2));
        }

        public override long GetSecondPartResult(bool sample)
        {
            CommonTrunk(sample,
                out List<(int left, int top)> wire1Points,
                out List<(int left, int top)> wire2Points);

            return GetMinimalValue(
                wire1Points,
                wire2Points,
                _ => wire1Points.IndexOf(_) + wire2Points.IndexOf(_) + 2);
        }

        private static int GetMinimalValue(List<(int left, int top)> wire1Points,
            List<(int left, int top)> wire2Points,
            Func<(int, int), int> minimalComputeCallback)
        {
            return wire1Points
                .Intersect(wire2Points)
                .Select(_ => minimalComputeCallback(_))
                .OrderBy(_ => _)
                .First();
        }

        private void CommonTrunk(bool sample, out List<(int left, int top)> wire1Points, out List<(int left, int top)> wire2Points)
        {
            var values = GetContent(
                v => v,
                sample: sample);

            var wire1Path = ToWirePath(values[0]);
            var wire2Path = ToWirePath(values[1]);

            wire1Points = GenerateWirePathPoints(wire1Path).ToList();
            wire2Points = GenerateWirePathPoints(wire2Path).ToList();
        }

        private static IEnumerable<(int left, int top)> GenerateWirePathPoints(List<(Direction dir, int val)> wire1Path)
        {
            var left = 0;
            var top = 0;
            foreach (var (dir, val) in wire1Path)
            {
                for (int i = 0; i < val; i++)
                {
                    switch (dir)
                    {
                        case Direction.D:
                            top += 1;
                            break;
                        case Direction.L:
                            left += 1;
                            break;
                        case Direction.R:
                            left -= 1;
                            break;
                        case Direction.U:
                            top -= 1;
                            break;
                    }
                    yield return (left, top);
                }
            }
        }

        private static List<(Direction dir, int val)> ToWirePath(string wireValues)
        {
            return wireValues
                .Split(',')
                .Select(v => (
                    Enum.Parse<Direction>(v.Substring(0, 1)),
                    Convert.ToInt32(v.Substring(1))))
                .ToList();
        }

        private enum Direction
        {
            D,
            L,
            R,
            U
        }
    }
}
