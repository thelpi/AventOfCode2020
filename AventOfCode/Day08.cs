using System;
using System.Collections.Generic;
using System.Text;

namespace AventOfCode
{
    /// <summary>
    /// Day 8: Handheld Halting
    /// </summary>
    public sealed class Day08 : DayBase
    {
        public Day08() : base(8) { }

        public override long GetFirstPartResult(bool sample)
        {
            var instructions = GetContent(v =>
                (v.Split(' ')[0], Convert.ToInt32(v.Split(' ')[1].Replace("+", ""))),
                sample: sample);

            var realAccumulateur = -1;

            bool realEnding = false;
            var localInstructions = new List<(string, int)>(instructions);

            var ij = instructions[0];

            int previousI = 0;
            int i = 0;
            List<int> passed = new List<int>();
            var accumulateur = 0;
            var stop = passed.Contains(i);
            while (!stop)
            {
                passed.Add(i);
                switch (localInstructions[i].Item1)
                {
                    case "nop":
                        previousI = i;
                        i += 1;
                        break;
                    case "acc":
                        accumulateur += localInstructions[i].Item2;
                        previousI = i;
                        i += 1;
                        break;
                    case "jmp":
                        previousI = i;
                        i += localInstructions[i].Item2;
                        break;
                    default:
                        break;
                }
                realEnding = i == localInstructions.Count;
                stop = passed.Contains(i) || realEnding;
            }

            realAccumulateur = accumulateur;

            return realAccumulateur;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var instructions = GetContent(v =>
                (v.Split(' ')[0], Convert.ToInt32(v.Split(' ')[1].Replace("+", ""))),
                sample: sample);

            var realAccumulateur = -1;

            bool realEnding = false;
            for (int j = 0; j < instructions.Count; j++)
            {
                var localInstructions = new List<(string, int)>(instructions);

                var ij = instructions[j];

                (string, int) newInstruction = ("", 0);
                if (ij.Item1 == "acc")
                {
                    continue;
                }
                else if (ij.Item1 == "nop")
                {
                    if (j + ij.Item2 < 0)
                    {
                        continue;
                    }
                    newInstruction = ("jmp", ij.Item2);
                }
                else if (instructions[j].Item1 == "jmp")
                {
                    newInstruction = ("nop", ij.Item2);
                }

                localInstructions[j] = newInstruction;

                int previousI = 0;
                int i = 0;
                List<int> passed = new List<int>();
                var accumulateur = 0;
                var stop = passed.Contains(i);
                while (!stop)
                {
                    passed.Add(i);
                    switch (localInstructions[i].Item1)
                    {
                        case "nop":
                            previousI = i;
                            i += 1;
                            break;
                        case "acc":
                            accumulateur += localInstructions[i].Item2;
                            previousI = i;
                            i += 1;
                            break;
                        case "jmp":
                            previousI = i;
                            i += localInstructions[i].Item2;
                            break;
                        default:
                            break;
                    }
                    realEnding = i == localInstructions.Count;
                    stop = passed.Contains(i) || realEnding;
                }

                if (realEnding)
                {
                    realAccumulateur = accumulateur;
                    break;
                }
            }

            return realAccumulateur;
        }
    }
}
