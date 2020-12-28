using System;
using System.Collections.Generic;

namespace AventOfCode
{
    /// <summary>
    /// Day 8: Handheld Halting
    /// </summary>
    public sealed class Day08 : DayBase
    {
        private const string ACC = "acc";
        private const string JMP = "jmp";
        private const string NOP = "nop";

        public Day08() : base(8) { }

        public override long GetFirstPartResult(bool sample)
        {
            return Accumulate(sample, true);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return Accumulate(sample, false);
        }

        private long Accumulate(bool sample, bool firstPart)
        {
            var initialInstructions = GetContent(v =>
                {
                    var type = v.Split(' ')[0];
                    var value = Convert.ToInt32(v.Split(' ')[1].Replace("+", ""));
                    return (type, value);
                },
                sample: sample);

            var accResult = -1;

            for (int j = 0; j < initialInstructions.Count; j++)
            {
                var instructions = new List<(string type, int value)>(initialInstructions);

                if (!firstPart)
                {
                    switch (instructions[j].type)
                    {
                        case ACC:
                            continue;
                        case NOP:
                            if (j + instructions[j].value < 0)
                                continue;
                            instructions[j] = (JMP, instructions[j].value);
                            break;
                        case JMP:
                            instructions[j] = (NOP, instructions[j].value);
                            break;
                    }
                }

                var resolvedLoop = false;
                var i = 0;
                var instructionsHistory = new List<int>();
                var accumulateur = 0;
                while (!instructionsHistory.Contains(i) && !resolvedLoop)
                {
                    instructionsHistory.Add(i);
                    switch (instructions[i].type)
                    {
                        case NOP:
                            i += 1;
                            break;
                        case ACC:
                            accumulateur += instructions[i].value;
                            i += 1;
                            break;
                        case JMP:
                            i += instructions[i].value;
                            break;
                    }
                    resolvedLoop = i == instructions.Count;
                }

                if (resolvedLoop || firstPart)
                {
                    accResult = accumulateur;
                    break;
                }
            }

            return accResult;
        }
    }
}
