using System.Collections.Generic;
using System.Linq;

namespace AventOfCode._2021
{
    public sealed class Day14 : DayBase
    {
        public Day14() : base(2021, 14) { }

        public override long GetFirstPartResult(bool sample)
        {
            var values = GetContent(v => v, sample: sample);

            var trans = values.Skip(2).Select(x => x.Split(" -> ")).ToDictionary(x => (x[0][0], x[0][1]), x => x[1][0]);

            var charsFreq = TransformToCpt(values[0]);

            for (var i = 1; i <= 10; i++)
            {
                var newCharsFreq = new List<(char, int)>();

                var lasted = charsFreq[0].Item1;
                var lastedI = 1;
                newCharsFreq.Add((lasted, lastedI));

                var j = 0;
                var relativePosition = 1;
                while (j < (charsFreq.Count - 1) || (j == charsFreq.Count - 1 && relativePosition < charsFreq[j].Item2))
                {
                    var firstChar = charsFreq[j].Item1;
                    var secondChar = charsFreq[j].Item1;
                    if (charsFreq[j].Item2 == relativePosition)
                    {
                        j++;
                        secondChar = charsFreq[j].Item1;
                        relativePosition = 1;
                    }
                    else
                    {
                        relativePosition++;
                    }

                    if (trans.ContainsKey((firstChar, secondChar)))
                    {
                        var insert = trans[(firstChar, secondChar)];
                        if (insert == lasted)
                        {
                            lastedI++;
                            newCharsFreq[newCharsFreq.Count - 1] = (lasted, lastedI);
                        }
                        else
                        {
                            lastedI = 1;
                            lasted = insert;
                            newCharsFreq.Add((insert, lastedI));
                        }
                    }

                    if (secondChar == lasted)
                    {
                        lastedI++;
                        newCharsFreq[newCharsFreq.Count - 1] = (lasted, lastedI);
                    }
                    else
                    {
                        lastedI = 1;
                        lasted = secondChar;
                        newCharsFreq.Add((secondChar, lastedI));
                    }
                }

                charsFreq = newCharsFreq;
            }

            var groups = charsFreq
                .GroupBy(x => x.Item1)
                .OrderByDescending(x => x.Sum(v => v.Item2))
                .Select(x => x.Sum(v => v.Item2))
                .ToList();

            return groups[0] - groups[groups.Count - 1];
        }

        public override long GetSecondPartResult(bool sample)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var values = GetContent(v => v, sample: sample);

            var trans = values.Skip(2).Select(x => x.Split(" -> ")).ToDictionary(x => (x[0][0], x[0][1]), x => x[1][0]);

            /*var polyValueAr = InternalCompute(values[0].ToCharArray(), 20, trans);

            var polyValue = new string(polyValueAr.ToArray());

            InsertPolyValue(1, values[0], polyValue, sample);*/


            /*var subPolyCount = polyValue.Length - 1;
            for (var x = 0; x < polyValue.Length - 1; x++)
            {
                var newPolyKey = new string(new[] { polyValue[x], polyValue[x + 1] });

                var polyValueAr = InternalCompute(newPolyKey.ToCharArray(), 10, trans);

                polyValue = new string(polyValueAr.ToArray());

                InsertPolyValue(2, newPolyKey, polyValue, sample);
            }*/

            /*var keys = GetPolyKeys(sample);

            var whereAmI = 0;
            var polyValues = GetPolyValues(3, sample);
            foreach (var pv in polyValues)
            {
                for (var x = 0; x < pv.Length - 1; x++)
                {
                    var newPolyKey = new string(new[] { pv[x], pv[x + 1] });

                    List<char> polyValueAr;
                    if (keys.ContainsKey(newPolyKey))
                    {
                        polyValueAr = keys[newPolyKey];
                    }
                    else
                    {
                        polyValueAr = InternalCompute(newPolyKey.ToCharArray(), 10, trans);
                    }

                    var polyValue = new string(polyValueAr.ToArray());

                    InsertPolyValue(4, newPolyKey, polyValue, sample);
                }
                System.Diagnostics.Debug.WriteLine($"STEEEEEEEEEEEEEEEEEEP - {whereAmI}");
                whereAmI++;
            }*/

            var charsFreq = TransformToCpt(values[0]);

            for (var i = 1; i <= 40; i++)
            {
                var newCharsFreq = new List<(char, int)>();

                var lasted = charsFreq[0].Item1;
                var lastedI = 1;
                newCharsFreq.Add((lasted, lastedI));

                var j = 0;
                var relativePosition = 1;
                while (j < (charsFreq.Count - 1) || (j == charsFreq.Count - 1 && relativePosition < charsFreq[j].Item2))
                {
                    var firstChar = charsFreq[j].Item1;
                    var secondChar = charsFreq[j].Item1;
                    if (charsFreq[j].Item2 == relativePosition)
                    {
                        j++;
                        secondChar = charsFreq[j].Item1;
                        relativePosition = 1;
                    }
                    else
                    {
                        relativePosition++;
                    }

                    if (trans.ContainsKey((firstChar, secondChar)))
                    {
                        var insert = trans[(firstChar, secondChar)];
                        if (insert == lasted)
                        {
                            lastedI++;
                            newCharsFreq[newCharsFreq.Count - 1] = (lasted, lastedI);
                        }
                        else
                        {
                            lastedI = 1;
                            lasted = insert;
                            newCharsFreq.Add((insert, lastedI));
                        }
                    }

                    if (secondChar == lasted)
                    {
                        lastedI++;
                        newCharsFreq[newCharsFreq.Count - 1] = (lasted, lastedI);
                    }
                    else
                    {
                        lastedI = 1;
                        lasted = secondChar;
                        newCharsFreq.Add((secondChar, lastedI));
                    }
                }

                charsFreq = newCharsFreq;
            }

            var groups = charsFreq
                .GroupBy(x => x.Item1)
                .OrderByDescending(x => x.Sum(v => v.Item2))
                .Select(x => x.Sum(v => v.Item2))
                .ToList();

            return groups[0] - groups[groups.Count - 1];
        }

        /*private static Dictionary<string, List<char>> GetPolyKeys(bool sample)
        {
            var keys = new Dictionary<string, List<char>>();

            var connString = "Server=localhost;Database=day14;Uid=root;Pwd=";
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"select poly_key, min(poly_value) as pv from td14 where sample = {(sample ? 1 : 0)} group by poly_key";
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            keys.Add(rd.GetString("poly_key"), rd.GetString("pv").ToCharArray().ToList());
                        }
                    }
                }
            }

            return keys;
        }*/

        /*private static IEnumerable<string> GetPolyValues(int grade, bool sample)
        {
            var connString = "Server=localhost;Database=day14;Uid=root;Pwd=";
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"select poly_value from td14 where grade = {grade} and sample = {(sample ? 1 : 0)} order by id";
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            yield return rd.GetString("poly_value");
                        }
                    }
                }
            }
        }*/

        /*private static string GetPolyValue(int grade, string polyKey, bool sample)
        {
            string polyValue = null;

            var connString = "Server=localhost;Database=day14;Uid=root;Pwd=";
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"select poly_value from td14 where poly_key = '{polyKey}' and grade = {grade} and sample = {(sample ? 1 : 0)}";
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            polyValue = rd.GetString("poly_value");
                        }
                    }
                }
            }

            return polyValue;
        }*/

        /*private static void InsertPolyValue(int grade, string polyKey, string polyValue, bool sample)
        {
            var connString = "Server=localhost;Database=day14;Uid=root;Pwd=";
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"insert into td14 (poly_key, poly_value, grade, sample) values ('{polyKey}', '{polyValue}', {grade}, {(sample ? 1 : 0)})";
                    cmd.ExecuteNonQuery();
                }
            }
        }*/

        private List<char> InternalCompute(char[] basee, int steps, Dictionary<(char, char), char> trans)
        {
            var linked = new List<char>(basee);
            for (var step = 1; step <= steps; step++)
            {
                var x = 0;
                while (true)
                {
                    var w = (linked[x], linked[x + 1]);
                    if (trans.ContainsKey(w))
                    {
                        linked.Insert(x + 1, trans[w]);
                        x += 2;
                    }
                    else
                    {
                        x++;
                    }
                    if (x == linked.Count - 1)
                        break;
                }
            }

            return linked;
        }

        private List<(char, int)> TransformToCpt(IEnumerable<char> chars)
        {
            var result = new List<(char, int)>();

            char? currCh = null;
            int cpt = 0;
            foreach (var ch in chars)
            {
                if (currCh == null)
                    currCh = ch;
                else if (currCh != ch)
                {
                    result.Add((currCh.Value, cpt));
                    currCh = ch;
                    cpt = 0;
                }
                cpt++;
            }
            result.Add((currCh.Value, cpt));

            return result;
        }
    }
}
