using System;
using System.Linq;

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
                        var subToto = ComputeComplexExpressionValue(subExp, false);
                        exp = exp.Replace($"({subExp})", subToto.ToString());
                    }
                    else
                    {
                        sum += ComputeComplexExpressionValue(exp, false);
                        break;
                    }
                }
            }

            return sum;
        }

        public override long GetSecondPartResult(bool sample)
        {
            var expressions = GetContent(v => v, sample: sample, part: (sample ? 2 : (int?)null));

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
                        var subToto = ComputeComplexExpressionValue(subExp, true);
                        exp = exp.Replace($"({subExp})", subToto.ToString());
                    }
                    else
                    {
                        sum += ComputeComplexExpressionValue(exp, true);
                        break;
                    }
                }
            }

            return sum;
        }

        private long ComputeExpressionValue(string expression)
        {
            var expressionParts = expression.Split(" ");
            long total = Convert.ToInt32(expressionParts[0]);
            bool nextIsMultiply = false;
            foreach (var car in expressionParts.Skip(1))
            {
                if (car == "+") nextIsMultiply = false;
                else if (car == "*") nextIsMultiply = true;
                else if (nextIsMultiply) total *= Convert.ToInt32(car);
                else total += Convert.ToInt32(car);
            }
            return total;
        }

        private long ComputeComplexExpressionValue(string expression, bool applyMultiplyPriority)
        {
            return applyMultiplyPriority
                ? expression
                    .Split("*")
                    .Aggregate((long)1, (agg, v) => agg *= ComputeExpressionValue(v.Trim()))
                : ComputeExpressionValue(expression);
        }
    }
}
