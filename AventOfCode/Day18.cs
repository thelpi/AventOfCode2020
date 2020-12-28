using System;

namespace AventOfCode
{
    /// <summary>
    /// Day 18: Operation Order
    /// </summary>
    public sealed class Day18 : DayBase
    {
        public Day18() : base(18) { }

        public override long GetFirstPartResult(bool sample)
        {
            var expressions = GetContent(v => v, sample: sample, part: (sample ? 1 : (int?)null));

            long SubSub(string subExp)
            {
                var cars = subExp.Split(" ");
                long subTot = -1;
                bool nextIsMultiply = false;
                foreach (var car in cars)
                {
                    if (subTot == -1)
                    {
                        subTot = Convert.ToInt32(car);
                    }
                    else if (car == "+")
                    {
                        nextIsMultiply = false;
                    }
                    else if (car == "*")
                    {
                        nextIsMultiply = true;
                    }
                    else
                    {
                        if (nextIsMultiply)
                        {
                            subTot = subTot * Convert.ToInt32(car);
                        }
                        else
                        {
                            subTot = subTot + Convert.ToInt32(car);
                        }
                    }
                }
                return subTot;
            }

            long ComputeSubTot(string subExp)
            {
                return SubSub(subExp);
            }

            long sum = 0;

            for (int k = 0; k < expressions.Count; k++)
            {
                string exp = expressions[k];
                while (true)
                {
                    int parenthesePos = -1;
                    int endParenthesePos = -1;
                    int i = 0;
                    foreach (var car in exp)
                    {
                        if (car == '(')
                        {
                            parenthesePos = i;
                        }
                        else if (car == ')')
                        {
                            endParenthesePos = i;
                            break;
                        }
                        i++;
                    }
                    if (parenthesePos > -1)
                    {
                        var subExp = exp.Substring(parenthesePos + 1, endParenthesePos - parenthesePos - 1);
                        var subToto = ComputeSubTot(subExp);
                        exp = exp.Replace($"({subExp})", subToto.ToString());
                    }
                    else
                    {
                        sum += ComputeSubTot(exp);
                        break;
                    }
                }
            }

            return sum;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var expressions = GetContent(v => v, sample: sample, part: (sample ? 2 : (int?)null));

            long SubSub(string subExp)
            {
                var cars = subExp.Split(" ");
                long subTot = -1;
                bool nextIsMultiply = false;
                foreach (var car in cars)
                {
                    if (subTot == -1)
                    {
                        subTot = Convert.ToInt32(car);
                    }
                    else if (car == "+")
                    {
                        nextIsMultiply = false;
                    }
                    else if (car == "*")
                    {
                        nextIsMultiply = true;
                    }
                    else
                    {
                        if (nextIsMultiply)
                        {
                            subTot = subTot * Convert.ToInt32(car);
                        }
                        else
                        {
                            subTot = subTot + Convert.ToInt32(car);
                        }
                    }
                }
                return subTot;
            }

            long ComputeSubTot(string subExp)
            {
                var subSubExp = subExp.Split("*");
                long tot = 1;
                foreach (var sse in subSubExp)
                {
                    var subTot = SubSub(sse.Trim());
                    tot = tot * subTot;
                }
                return tot;
            }

            long sum = 0;

            for (int k = 0; k < expressions.Count; k++)
            {
                string exp = expressions[k];
                while (true)
                {
                    int parenthesePos = -1;
                    int endParenthesePos = -1;
                    int i = 0;
                    foreach (var car in exp)
                    {
                        if (car == '(')
                        {
                            parenthesePos = i;
                        }
                        else if (car == ')')
                        {
                            endParenthesePos = i;
                            break;
                        }
                        i++;
                    }
                    if (parenthesePos > -1)
                    {
                        var subExp = exp.Substring(parenthesePos + 1, endParenthesePos - parenthesePos - 1);
                        var subToto = ComputeSubTot(subExp);
                        exp = exp.Replace($"({subExp})", subToto.ToString());
                    }
                    else
                    {
                        sum += ComputeSubTot(exp);
                        break;
                    }
                }
            }

            return sum;
        }
    }
}
