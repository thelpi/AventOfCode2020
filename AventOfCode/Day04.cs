using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    /// <summary>
    /// Day 4: Passport Processing
    /// </summary>
    public sealed class Day04 : DayBase
    {
        private const string BYR = "byr";
        private const string IYR = "iyr";
        private const string EYR = "eyr";
        private const string HGT = "hgt";
        private const string HCL = "hcl";
        private const string ECL = "ecl";
        private const string PID = "pid";
        private readonly string[] CRITERIA_CODES = new string[]
        {
            BYR, IYR, EYR, HGT, HCL, ECL, PID
        };

        private const int BYR_MIN = 1920;
        private const int BYR_MAX = 2002;

        private const int IYR_MIN = 2010;
        private const int IYR_MAX = 2020;

        private const int EYR_MIN = 2020;
        private const int EYR_MAX = 2030;

        private const string HGT_IN_UNIT = "in";
        private const string HGT_CM_UNIT = "cm";
        private static readonly IReadOnlyDictionary<string, (int, int)> HGT_UNIT_RANGE =
            new Dictionary<string, (int, int)>
            {
                { HGT_IN_UNIT, (59, 76) },
                { HGT_CM_UNIT, (150, 193) }
            };

        private const int PID_LENGTH = 9;
        private const string PID_ALLOWED_CARS = "0123456789";

        private const int HCL_LENGTH = 7;
        private const char HCL_FIRST_CAR = '#';
        private const string HCL_ALLOWED_CARS = "0123456789abcdef";

        private readonly string[] ALLOWED_ECL_COLORS = new string[]
        {
            "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
        };

        public Day04() : base(4) { }

        public override long GetFirstPartResult(bool sample)
        {
            return CountValidPassports(sample, valuesByCriteriaCode => true);
        }

        public override long GetSecondPartResult(bool sample)
        {
            return CountValidPassports(sample, valuesByCriteriaCode =>
            {
                bool isInvalidPassport = false;
                foreach (var criteriaCode in CRITERIA_CODES)
                {
                    var codeValue = valuesByCriteriaCode[criteriaCode];
                    switch (criteriaCode)
                    {
                        case BYR:
                            isInvalidPassport = CheckInvalidRangedValue(codeValue, (BYR_MIN, BYR_MAX));
                            break;
                        case IYR:
                            isInvalidPassport = CheckInvalidRangedValue(codeValue, (IYR_MIN, IYR_MAX));
                            break;
                        case EYR:
                            isInvalidPassport = CheckInvalidRangedValue(codeValue, (EYR_MIN, EYR_MAX));
                            break;
                        case HGT:
                            isInvalidPassport = (!codeValue.EndsWith(HGT_CM_UNIT) && !codeValue.EndsWith(HGT_IN_UNIT))
                                || CheckInvalidRangedValue(codeValue.Substring(0, codeValue.Length - 2), HGT_UNIT_RANGE[codeValue.Substring(codeValue.Length - 2)]);
                            break;
                        case HCL:
                            isInvalidPassport = codeValue[0] != HCL_FIRST_CAR
                                || codeValue.Length != HCL_LENGTH
                                || !codeValue.Substring(1, 6).All(c => HCL_ALLOWED_CARS.Contains(c));
                            break;
                        case ECL:
                            isInvalidPassport = !ALLOWED_ECL_COLORS.Contains(codeValue);
                            break;
                        case PID:
                            isInvalidPassport = codeValue.Length != PID_LENGTH
                                || !codeValue.All(chardd => PID_ALLOWED_CARS.Contains(chardd));
                            break;
                    }

                    if (isInvalidPassport)
                    {
                        break;
                    }
                }

                return !isInvalidPassport;
            });
        }

        private long CountValidPassports(bool sample,
            Func<Dictionary<string, string>, bool> validityCheck)
        {
            var passports = GetContent(v =>
                v.Replace("\r\n", " "),
                "\r\n\r\n",
                sample: sample);

            int countValidPassports = 0;
            foreach (var passport in passports)
            {
                var valuesByCriteriaCode = new Dictionary<string, string>();
                foreach (var passportRow in passport.Split(' '))
                {
                    var passportRowParts = passportRow.Split(':');
                    valuesByCriteriaCode.Add(
                        passportRowParts[0].ToLowerInvariant(),
                        passportRowParts[1].ToLowerInvariant());
                }

                if (CRITERIA_CODES.All(c => valuesByCriteriaCode.ContainsKey(c)))
                {
                    if (validityCheck(valuesByCriteriaCode))
                    {
                        countValidPassports++;
                    }
                }
            }

            return countValidPassports;
        }

        private bool CheckInvalidRangedValue(string codeValue, (int, int) inclusiveMinMax)
        {
            return !int.TryParse(codeValue, out int intValue)
                || intValue < inclusiveMinMax.Item1
                || intValue > inclusiveMinMax.Item2;
        }
    }
}
