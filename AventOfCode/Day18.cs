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
            return CommonTrunk(sample, 1, false);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CommonTrunk(sample, 2, true);
        }

        private long CommonTrunk(bool sample, int sampleIndex, bool multiplyPriority)
        {
            var expressions = GetContent(v => v, sample: sample, part: (sample ? sampleIndex : (int?)null));

            long sum = 0;

            foreach (var exp in expressions)
            {
                var editedExpression = exp;
                int parenthesisBeginIndex = 0;
                int parenthesisEndIndex = 0;
                while (parenthesisBeginIndex >= 0)
                {
                    parenthesisBeginIndex = -1;
                    parenthesisEndIndex = -1;
                    int i = 0;
                    foreach (var caracter in editedExpression)
                    {
                        if (caracter == '(')
                        {
                            parenthesisBeginIndex = i;
                        }
                        else if (caracter == ')')
                        {
                            parenthesisEndIndex = i;
                            break;
                        }
                        i++;
                    }

                    if (parenthesisBeginIndex > -1)
                    {
                        var expressionBetween = editedExpression.Substring(parenthesisBeginIndex + 1,
                            parenthesisEndIndex - parenthesisBeginIndex - 1);
                        editedExpression = editedExpression.Replace(
                            $"({expressionBetween})",
                            ComputeComplexExpressionValue(expressionBetween, multiplyPriority).ToString());
                    }
                    else
                    {
                        sum += ComputeComplexExpressionValue(editedExpression, multiplyPriority);
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
