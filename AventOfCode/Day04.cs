using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AventOfCode
{
    /// <summary>
    /// Day 4: Passport Processing
    /// </summary>
    public sealed class Day04 : DayBase
    {
        public Day04() : base(4) { }

        public override long GetFirstPartResult(bool sample)
        {

            var codes = new string[]
            {
                "byr", "iyr", "eyr", "hgt",
                "hcl", "ecl", "pid"
            };

            var passports = GetContent(v => v.Replace("\r\n", " "), "\r\n\r\n", sample: sample);

            int passportsValid = 0;
            foreach (var passport in passports)
            {
                var kpvList = new Dictionary<string, string>();
                foreach (var p in passport.Split(' '))
                {
                    var split = p.Split(':');
                    kpvList.Add(split[0].ToLowerInvariant(), split[1].ToLowerInvariant());
                }
                bool allCodesContained = codes.All(c => kpvList.ContainsKey(c));
                
                if (allCodesContained)
                {
                    passportsValid++;
                }
            }

            return passportsValid;
        }

        public override long GetSecondPartResult(bool sample)
        {

            var codes = new string[]
            {
                "byr", "iyr", "eyr", "hgt",
                "hcl", "ecl", "pid"
            };

            var passports = GetContent(v => v.Replace("\r\n", " "), "\r\n\r\n", sample: sample);

            int passportsValid = 0;
            foreach (var passport in passports)
            {
                var kpvList = new Dictionary<string, string>();
                foreach (var p in passport.Split(' '))
                {
                    var split = p.Split(':');
                    kpvList.Add(split[0].ToLowerInvariant(), split[1].ToLowerInvariant());
                }
                bool allCodesContained = codes.All(c => kpvList.ContainsKey(c));
                if (allCodesContained)
                {
                    bool invalid = false;
                    foreach (var c in codes)
                    {
                        var v = kpvList[c];
                        switch (c)
                        {
                            case "byr":
                                if (int.TryParse(v, out int byrReal))
                                {
                                    if (byrReal < 1920 || byrReal > 2002)
                                    {
                                        invalid = true;
                                    }
                                }
                                else
                                {
                                    invalid = true;
                                }
                                break;
                            case "iyr":
                                if (int.TryParse(v, out int iyrReal))
                                {
                                    if (iyrReal < 2010 || iyrReal > 2020)
                                    {
                                        invalid = true;
                                    }
                                }
                                else
                                {
                                    invalid = true;
                                }
                                break;
                            case "eyr":
                                if (int.TryParse(v, out int eyrReal))
                                {
                                    if (eyrReal < 2020 || eyrReal > 2030)
                                    {
                                        invalid = true;
                                    }
                                }
                                else
                                {
                                    invalid = true;
                                }
                                break;
                            case "hgt":
                                if (v.EndsWith("cm"))
                                {
                                    v = v.Substring(0, v.Length - 2);
                                    if (!int.TryParse(v, out int heightCm))
                                    {
                                        invalid = true;
                                    }
                                    else if (heightCm < 150 || heightCm > 193)
                                    {
                                        invalid = true;
                                    }
                                }
                                else if (v.EndsWith("in"))
                                {
                                    v = v.Substring(0, v.Length - 2);
                                    if (!int.TryParse(v, out int heightIn))
                                    {
                                        invalid = true;
                                    }
                                    else if (heightIn < 59 || heightIn > 76)
                                    {
                                        invalid = true;
                                    }
                                }
                                else
                                {
                                    invalid = true;
                                }
                                break;
                            case "hcl":
                                if (!v.StartsWith("#") || v.Length != 7)
                                {
                                    invalid = true;
                                }
                                else
                                {
                                    v = v.Substring(1, 6);
                                    var expected = "0123456789abcdef";
                                    if (!v.All(charr => expected.Contains(charr)))
                                    {
                                        invalid = true;
                                    }
                                }
                                break;
                            case "ecl":
                                string[] expectedd = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                if (!expectedd.Contains(v))
                                {
                                    invalid = true;
                                }
                                break;
                            case "pid":
                                var expecteddd = "0123456789";
                                if (v.Length != 9 || !v.All(chardd => expecteddd.Contains(chardd)))
                                {
                                    invalid = true;
                                }
                                break;
                        }
                    }
                    if (!invalid)
                    {
                        passportsValid++;
                    }
                }
            }

            return passportsValid;
        }
    }
}
