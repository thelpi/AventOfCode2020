using System;
using System.Collections.Generic;
using System.Linq;

namespace AventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(int.MaxValue);
        }

        private static void DayTwelve()
        {
            string rawDatas = "S1[TOTO]R270[TOTO]S5[TOTO]W2[TOTO]F63[TOTO]S3[TOTO]L90[TOTO]W4[TOTO]F59[TOTO]S1[TOTO]F21[TOTO]W4[TOTO]R90[TOTO]W1[TOTO]R180[TOTO]S2[TOTO]W2[TOTO]F91[TOTO]W5[TOTO]R270[TOTO]F97[TOTO]R90[TOTO]E2[TOTO]R90[TOTO]F6[TOTO]W1[TOTO]R90[TOTO]W3[TOTO]F1[TOTO]S4[TOTO]F1[TOTO]N3[TOTO]F76[TOTO]S4[TOTO]W5[TOTO]F88[TOTO]W4[TOTO]N3[TOTO]W2[TOTO]F48[TOTO]N1[TOTO]F50[TOTO]E3[TOTO]F18[TOTO]L90[TOTO]F30[TOTO]S3[TOTO]R90[TOTO]W1[TOTO]N5[TOTO]W1[TOTO]R90[TOTO]R90[TOTO]E1[TOTO]S2[TOTO]F73[TOTO]R90[TOTO]S4[TOTO]F89[TOTO]F34[TOTO]L90[TOTO]F11[TOTO]S3[TOTO]F20[TOTO]S5[TOTO]E3[TOTO]R180[TOTO]E3[TOTO]L90[TOTO]E2[TOTO]F1[TOTO]E3[TOTO]N3[TOTO]F84[TOTO]R90[TOTO]E4[TOTO]R180[TOTO]F24[TOTO]N3[TOTO]L90[TOTO]F15[TOTO]W4[TOTO]F52[TOTO]S5[TOTO]L180[TOTO]N4[TOTO]R90[TOTO]E5[TOTO]F11[TOTO]S4[TOTO]F27[TOTO]R180[TOTO]E4[TOTO]R180[TOTO]W3[TOTO]N2[TOTO]W1[TOTO]S3[TOTO]W4[TOTO]E5[TOTO]F97[TOTO]L180[TOTO]E3[TOTO]N4[TOTO]E3[TOTO]S4[TOTO]L90[TOTO]S4[TOTO]R90[TOTO]N5[TOTO]E1[TOTO]S5[TOTO]F19[TOTO]E1[TOTO]S2[TOTO]L180[TOTO]F36[TOTO]S2[TOTO]L90[TOTO]W1[TOTO]F8[TOTO]W1[TOTO]F67[TOTO]E3[TOTO]L90[TOTO]F33[TOTO]N4[TOTO]F35[TOTO]W2[TOTO]F33[TOTO]L180[TOTO]N1[TOTO]L90[TOTO]R90[TOTO]N3[TOTO]W4[TOTO]S1[TOTO]F36[TOTO]E2[TOTO]F2[TOTO]L90[TOTO]W3[TOTO]L90[TOTO]E5[TOTO]F4[TOTO]L90[TOTO]N1[TOTO]N5[TOTO]W4[TOTO]N5[TOTO]R90[TOTO]W4[TOTO]N5[TOTO]W2[TOTO]N5[TOTO]F43[TOTO]N3[TOTO]W3[TOTO]S2[TOTO]W2[TOTO]R90[TOTO]E1[TOTO]R90[TOTO]F26[TOTO]R90[TOTO]E4[TOTO]L270[TOTO]F97[TOTO]L180[TOTO]N2[TOTO]F2[TOTO]R90[TOTO]F33[TOTO]E2[TOTO]F85[TOTO]E4[TOTO]F80[TOTO]R90[TOTO]N2[TOTO]L90[TOTO]S5[TOTO]F96[TOTO]W1[TOTO]S5[TOTO]L180[TOTO]F54[TOTO]E3[TOTO]F84[TOTO]E3[TOTO]L90[TOTO]W1[TOTO]N2[TOTO]W4[TOTO]L90[TOTO]W4[TOTO]F26[TOTO]E5[TOTO]R180[TOTO]W1[TOTO]F43[TOTO]N4[TOTO]E1[TOTO]S4[TOTO]S3[TOTO]L90[TOTO]N3[TOTO]E1[TOTO]F14[TOTO]E1[TOTO]N2[TOTO]F93[TOTO]S1[TOTO]W3[TOTO]N5[TOTO]F15[TOTO]W5[TOTO]R90[TOTO]F93[TOTO]L90[TOTO]E5[TOTO]S4[TOTO]E4[TOTO]L90[TOTO]E2[TOTO]N4[TOTO]F98[TOTO]R90[TOTO]W3[TOTO]F100[TOTO]R90[TOTO]E2[TOTO]F100[TOTO]N5[TOTO]F9[TOTO]R90[TOTO]F36[TOTO]N3[TOTO]W3[TOTO]N4[TOTO]F35[TOTO]E3[TOTO]R90[TOTO]W4[TOTO]L90[TOTO]W3[TOTO]F15[TOTO]L90[TOTO]F73[TOTO]S2[TOTO]E1[TOTO]R180[TOTO]F93[TOTO]L270[TOTO]F37[TOTO]S1[TOTO]F36[TOTO]N1[TOTO]E1[TOTO]W1[TOTO]R90[TOTO]F46[TOTO]W2[TOTO]N4[TOTO]F50[TOTO]R90[TOTO]W4[TOTO]F90[TOTO]L90[TOTO]S3[TOTO]F2[TOTO]E1[TOTO]L90[TOTO]E5[TOTO]S2[TOTO]F91[TOTO]W2[TOTO]F21[TOTO]E2[TOTO]N2[TOTO]W5[TOTO]F79[TOTO]E1[TOTO]F77[TOTO]L90[TOTO]W5[TOTO]N2[TOTO]E3[TOTO]L180[TOTO]S2[TOTO]W1[TOTO]S1[TOTO]R90[TOTO]S5[TOTO]R180[TOTO]E2[TOTO]F55[TOTO]W4[TOTO]R90[TOTO]S3[TOTO]L90[TOTO]S1[TOTO]R180[TOTO]W4[TOTO]R180[TOTO]W5[TOTO]S5[TOTO]L180[TOTO]F35[TOTO]N1[TOTO]F72[TOTO]L90[TOTO]W4[TOTO]L180[TOTO]S1[TOTO]E1[TOTO]N5[TOTO]L90[TOTO]W5[TOTO]N1[TOTO]E2[TOTO]N4[TOTO]W3[TOTO]F3[TOTO]W4[TOTO]F96[TOTO]E1[TOTO]F20[TOTO]R90[TOTO]W4[TOTO]F99[TOTO]L90[TOTO]E4[TOTO]N3[TOTO]N3[TOTO]W3[TOTO]N5[TOTO]E2[TOTO]N4[TOTO]E4[TOTO]L90[TOTO]S2[TOTO]W3[TOTO]F3[TOTO]R90[TOTO]E2[TOTO]R90[TOTO]F23[TOTO]N5[TOTO]F39[TOTO]W3[TOTO]R90[TOTO]N3[TOTO]R180[TOTO]R90[TOTO]F94[TOTO]W1[TOTO]R90[TOTO]N3[TOTO]F16[TOTO]R90[TOTO]F61[TOTO]R90[TOTO]F67[TOTO]N4[TOTO]F72[TOTO]S2[TOTO]F39[TOTO]W1[TOTO]S1[TOTO]R90[TOTO]F67[TOTO]S1[TOTO]L90[TOTO]W5[TOTO]N5[TOTO]E3[TOTO]F65[TOTO]E2[TOTO]N1[TOTO]S4[TOTO]L90[TOTO]N4[TOTO]W5[TOTO]R90[TOTO]F49[TOTO]L180[TOTO]F22[TOTO]E2[TOTO]L90[TOTO]N3[TOTO]R90[TOTO]F61[TOTO]L180[TOTO]F57[TOTO]L90[TOTO]F90[TOTO]R90[TOTO]E5[TOTO]L180[TOTO]E1[TOTO]L180[TOTO]S3[TOTO]W4[TOTO]F55[TOTO]E1[TOTO]F95[TOTO]R180[TOTO]W5[TOTO]L180[TOTO]F23[TOTO]E3[TOTO]F97[TOTO]S1[TOTO]F19[TOTO]N2[TOTO]W4[TOTO]F10[TOTO]L90[TOTO]W4[TOTO]S1[TOTO]L90[TOTO]W5[TOTO]F64[TOTO]R90[TOTO]W4[TOTO]F60[TOTO]W4[TOTO]L90[TOTO]W3[TOTO]F15[TOTO]E5[TOTO]N5[TOTO]L90[TOTO]S2[TOTO]L180[TOTO]F64[TOTO]L180[TOTO]F93[TOTO]E5[TOTO]F13[TOTO]R270[TOTO]S4[TOTO]F58[TOTO]R180[TOTO]W5[TOTO]S1[TOTO]W4[TOTO]N1[TOTO]L270[TOTO]S4[TOTO]E4[TOTO]N5[TOTO]F38[TOTO]W4[TOTO]N2[TOTO]W2[TOTO]N1[TOTO]R90[TOTO]E1[TOTO]L90[TOTO]N2[TOTO]R90[TOTO]N3[TOTO]E3[TOTO]N3[TOTO]F90[TOTO]W2[TOTO]L90[TOTO]F95[TOTO]S1[TOTO]S4[TOTO]F48[TOTO]L270[TOTO]W2[TOTO]L90[TOTO]F34[TOTO]S3[TOTO]F23[TOTO]N2[TOTO]F13[TOTO]R180[TOTO]E2[TOTO]F95[TOTO]L90[TOTO]N2[TOTO]R90[TOTO]S2[TOTO]E3[TOTO]N1[TOTO]F41[TOTO]N2[TOTO]R180[TOTO]S4[TOTO]W3[TOTO]L90[TOTO]W5[TOTO]L90[TOTO]F35[TOTO]S5[TOTO]E2[TOTO]S5[TOTO]E3[TOTO]F81[TOTO]W4[TOTO]N3[TOTO]F28[TOTO]E1[TOTO]F93[TOTO]S3[TOTO]F53[TOTO]L90[TOTO]W5[TOTO]F59[TOTO]W1[TOTO]R90[TOTO]E2[TOTO]S5[TOTO]F80[TOTO]W3[TOTO]S5[TOTO]F6[TOTO]R90[TOTO]F8[TOTO]W1[TOTO]R180[TOTO]E2[TOTO]L270[TOTO]N3[TOTO]F59[TOTO]W5[TOTO]F51[TOTO]R90[TOTO]N2[TOTO]E4[TOTO]R90[TOTO]E4[TOTO]S1[TOTO]W2[TOTO]N1[TOTO]F45[TOTO]R90[TOTO]N5[TOTO]F28[TOTO]L90[TOTO]N4[TOTO]F78[TOTO]S1[TOTO]R90[TOTO]N5[TOTO]L90[TOTO]S2[TOTO]F92[TOTO]L180[TOTO]E3[TOTO]R90[TOTO]F26[TOTO]W1[TOTO]L180[TOTO]R90[TOTO]S3[TOTO]F51[TOTO]N1[TOTO]L90[TOTO]W2[TOTO]F84[TOTO]L180[TOTO]E1[TOTO]F54[TOTO]E4[TOTO]F65[TOTO]R90[TOTO]S5[TOTO]E2[TOTO]F78[TOTO]E1[TOTO]R90[TOTO]S1[TOTO]R90[TOTO]W3[TOTO]R180[TOTO]F99[TOTO]E5[TOTO]R90[TOTO]F44[TOTO]L90[TOTO]W3[TOTO]N3[TOTO]R180[TOTO]N4[TOTO]E1[TOTO]S4[TOTO]L180[TOTO]S4[TOTO]F59[TOTO]E4[TOTO]F1[TOTO]N5[TOTO]R180[TOTO]S5[TOTO]L180[TOTO]F38[TOTO]E4[TOTO]N3[TOTO]R180[TOTO]N1[TOTO]W4[TOTO]R90[TOTO]F30[TOTO]L90[TOTO]S3[TOTO]R90[TOTO]F71[TOTO]L90[TOTO]E5[TOTO]N4[TOTO]R90[TOTO]F50[TOTO]N2[TOTO]L180[TOTO]F3[TOTO]W5[TOTO]L90[TOTO]W5[TOTO]R90[TOTO]W5[TOTO]N5[TOTO]R180[TOTO]E2[TOTO]F39[TOTO]W5[TOTO]R90[TOTO]F72[TOTO]N5[TOTO]E3[TOTO]F37[TOTO]S5[TOTO]W1[TOTO]F11[TOTO]L180[TOTO]E3[TOTO]F55[TOTO]R90[TOTO]R90[TOTO]F85[TOTO]W4[TOTO]F53[TOTO]S1[TOTO]F33[TOTO]W4[TOTO]L90[TOTO]W5[TOTO]F64[TOTO]E5[TOTO]R90[TOTO]N1[TOTO]R90[TOTO]F14[TOTO]N4[TOTO]L180[TOTO]S3[TOTO]E1[TOTO]F21[TOTO]S2[TOTO]F26[TOTO]S5[TOTO]F6[TOTO]S2[TOTO]L90[TOTO]F50[TOTO]N2[TOTO]L180[TOTO]W4[TOTO]N2[TOTO]E2[TOTO]R90[TOTO]F35[TOTO]N1[TOTO]F69[TOTO]W3[TOTO]N2[TOTO]W3[TOTO]L90[TOTO]E1[TOTO]S3[TOTO]E4[TOTO]F58[TOTO]N1[TOTO]W5[TOTO]S5[TOTO]L90[TOTO]W1[TOTO]S3[TOTO]W1[TOTO]S4[TOTO]E4[TOTO]R90[TOTO]N5[TOTO]R180[TOTO]F57[TOTO]L90[TOTO]F69[TOTO]W4[TOTO]F2[TOTO]R90[TOTO]F1[TOTO]L90[TOTO]W1[TOTO]S2[TOTO]F40[TOTO]S1[TOTO]L180[TOTO]F31[TOTO]R180[TOTO]F24[TOTO]R90[TOTO]S3[TOTO]L180[TOTO]S1[TOTO]W2[TOTO]F64[TOTO]S1[TOTO]W1[TOTO]R180[TOTO]W5[TOTO]S3[TOTO]L90[TOTO]S5[TOTO]E5[TOTO]R90[TOTO]E1[TOTO]F5[TOTO]N5[TOTO]F3[TOTO]W3[TOTO]F57[TOTO]R180[TOTO]E3[TOTO]F94[TOTO]W1[TOTO]F54[TOTO]W4[TOTO]S2[TOTO]W2[TOTO]N1[TOTO]L90[TOTO]W5[TOTO]S4[TOTO]L180[TOTO]L90[TOTO]F100[TOTO]E3[TOTO]R90[TOTO]N5[TOTO]E1[TOTO]R90[TOTO]E5[TOTO]L90[TOTO]S5[TOTO]L90[TOTO]S1[TOTO]R90[TOTO]E4[TOTO]S1[TOTO]W4[TOTO]F65[TOTO]R90[TOTO]N3[TOTO]W5[TOTO]F64[TOTO]R90[TOTO]E5[TOTO]R180[TOTO]W5[TOTO]F28[TOTO]S5[TOTO]L180[TOTO]S5[TOTO]R90[TOTO]E4[TOTO]F82";
            string rawDatasSample = "F10[TOTO]N3[TOTO]F7[TOTO]R90[TOTO]F11";

            var datas = rawDatas.Split("[TOTO]").Select(v => (v[0], Convert.ToInt32(v.Substring(1)))).ToList();

            (int, int) currentPoint = (10, 1);
            (Wind, Wind) currentPointWind = (Wind.east, Wind.north);
            var east = 0;
            var south = 0;
            var north = 0;
            var west = 0;

            foreach (var k in datas)
            {
                switch (k.Item1)
                {
                    case 'N':
                        if (currentPointWind.Item2 == Wind.north)
                        {
                            currentPoint = (currentPoint.Item1, currentPoint.Item2 + k.Item2);
                        }
                        else if (currentPointWind.Item2 == Wind.south)
                        {
                            currentPoint = (currentPoint.Item1, currentPoint.Item2 - k.Item2);
                        }
                        else if (currentPointWind.Item1 == Wind.north)
                        {
                            currentPoint = (currentPoint.Item1 + k.Item2, currentPoint.Item2);
                        }
                        else
                        {
                            currentPoint = (currentPoint.Item1 - k.Item2, currentPoint.Item2);
                        }
                        break;
                    case 'S':
                        if (currentPointWind.Item2 == Wind.south)
                        {
                            currentPoint = (currentPoint.Item1, currentPoint.Item2 + k.Item2);
                        }
                        else if (currentPointWind.Item2 == Wind.north)
                        {
                            currentPoint = (currentPoint.Item1, currentPoint.Item2 - k.Item2);
                        }
                        else if (currentPointWind.Item1 == Wind.south)
                        {
                            currentPoint = (currentPoint.Item1 + k.Item2, currentPoint.Item2);
                        }
                        else
                        {
                            currentPoint = (currentPoint.Item1 - k.Item2, currentPoint.Item2);
                        }
                        break;
                    case 'E':
                        if (currentPointWind.Item2 == Wind.east)
                        {
                            currentPoint = (currentPoint.Item1, currentPoint.Item2 + k.Item2);
                        }
                        else if (currentPointWind.Item2 == Wind.west)
                        {
                            currentPoint = (currentPoint.Item1, currentPoint.Item2 - k.Item2);
                        }
                        else if (currentPointWind.Item1 == Wind.east)
                        {
                            currentPoint = (currentPoint.Item1 + k.Item2, currentPoint.Item2);
                        }
                        else
                        {
                            currentPoint = (currentPoint.Item1 - k.Item2, currentPoint.Item2);
                        }
                        break;
                    case 'W':
                        if (currentPointWind.Item2 == Wind.west)
                        {
                            currentPoint = (currentPoint.Item1, currentPoint.Item2 + k.Item2);
                        }
                        else if (currentPointWind.Item2 == Wind.east)
                        {
                            currentPoint = (currentPoint.Item1, currentPoint.Item2 - k.Item2);
                        }
                        else if (currentPointWind.Item1 == Wind.west)
                        {
                            currentPoint = (currentPoint.Item1 + k.Item2, currentPoint.Item2);
                        }
                        else
                        {
                            currentPoint = (currentPoint.Item1 - k.Item2, currentPoint.Item2);
                        }
                        break;
                    case 'L':
                        var newV = k.Item2 / 90;
                        for (int i = 0; i < newV; i++)
                        {
                            if (currentPointWind.Item1 == Wind.east)
                            {
                                currentPointWind = (Wind.north, currentPointWind.Item2);
                            }
                            else if (currentPointWind.Item1 == Wind.south)
                            {
                                currentPointWind = (Wind.east, currentPointWind.Item2);
                            }
                            else if (currentPointWind.Item1 == Wind.north)
                            {
                                currentPointWind = (Wind.west, currentPointWind.Item2);
                            }
                            else if (currentPointWind.Item1 == Wind.west)
                            {
                                currentPointWind = (Wind.south, currentPointWind.Item2);
                            }

                            if (currentPointWind.Item2 == Wind.east)
                            {
                                currentPointWind = (currentPointWind.Item1, Wind.north);
                            }
                            else if (currentPointWind.Item2 == Wind.south)
                            {
                                currentPointWind = (currentPointWind.Item1, Wind.east);
                            }
                            else if (currentPointWind.Item2 == Wind.north)
                            {
                                currentPointWind = (currentPointWind.Item1, Wind.west);
                            }
                            else if (currentPointWind.Item2 == Wind.west)
                            {
                                currentPointWind = (currentPointWind.Item1, Wind.south);
                            }
                        }
                        break;
                    case 'R':
                        var newV2 = k.Item2 / 90;
                        for (int i = 0; i < newV2; i++)
                        {
                            if (currentPointWind.Item1 == Wind.east)
                            {
                                currentPointWind = (Wind.south, currentPointWind.Item2);
                            }
                            else if (currentPointWind.Item1 == Wind.south)
                            {
                                currentPointWind = (Wind.west, currentPointWind.Item2);
                            }
                            else if (currentPointWind.Item1 == Wind.north)
                            {
                                currentPointWind = (Wind.east, currentPointWind.Item2);
                            }
                            else if (currentPointWind.Item1 == Wind.west)
                            {
                                currentPointWind = (Wind.north, currentPointWind.Item2);
                            }

                            if (currentPointWind.Item2 == Wind.east)
                            {
                                currentPointWind = (currentPointWind.Item1, Wind.south);
                            }
                            else if (currentPointWind.Item2 == Wind.south)
                            {
                                currentPointWind = (currentPointWind.Item1, Wind.west);
                            }
                            else if (currentPointWind.Item2 == Wind.north)
                            {
                                currentPointWind = (currentPointWind.Item1, Wind.east);
                            }
                            else if (currentPointWind.Item2 == Wind.west)
                            {
                                currentPointWind = (currentPointWind.Item1, Wind.north);
                            }
                        }
                        break;
                    case 'F':
                        if (currentPointWind.Item1 == Wind.east)
                        {
                            east += currentPoint.Item1 * k.Item2;
                        }
                        else if (currentPointWind.Item1 == Wind.west)
                        {
                            west += currentPoint.Item1 * k.Item2;
                        }
                        else if (currentPointWind.Item1 == Wind.north)
                        {
                            north += currentPoint.Item1 * k.Item2;
                        }
                        else if (currentPointWind.Item1 == Wind.south)
                        {
                            south += currentPoint.Item1 * k.Item2;
                        }
                        if (currentPointWind.Item2 == Wind.east)
                        {
                            east += currentPoint.Item2 * k.Item2;
                        }
                        else if (currentPointWind.Item2 == Wind.west)
                        {
                            west += currentPoint.Item2 * k.Item2;
                        }
                        else if (currentPointWind.Item2 == Wind.north)
                        {
                            north += currentPoint.Item2 * k.Item2;
                        }
                        else if (currentPointWind.Item2 == Wind.south)
                        {
                            south += currentPoint.Item2 * k.Item2;
                        }
                        break;
                }
            }

            // part 1
            /*var east = 0;
            var north = 0;
            var west = 0;
            var south = 0;
            var wind = Wind.east;

            foreach (var k in datas)
            {
                Wind nextWind = wind;
                switch (k.Item1)
                {
                    case 'N':
                        north += k.Item2;
                        break;
                    case 'S':
                        south += k.Item2;
                        break;
                    case 'E':
                        east += k.Item2;
                        break;
                    case 'W':
                        west += k.Item2;
                        break;
                    case 'L':
                        var newV = k.Item2 / 90;
                        for (int i = 0; i < newV; i++)
                        {
                            switch (wind)
                            {
                                case Wind.east:
                                    nextWind = Wind.north;
                                    break;
                                case Wind.north:
                                    nextWind = Wind.west;
                                    break;
                                case Wind.south:
                                    nextWind = Wind.east;
                                    break;
                                case Wind.west:
                                    nextWind = Wind.south;
                                    break;
                            }
                            wind = nextWind;
                        }
                        break;
                    case 'R':
                        var newV2 = k.Item2 / 90;
                        for (int i = 0; i < newV2; i++)
                        {
                            switch (wind)
                            {
                                case Wind.east:
                                    nextWind = Wind.south;
                                    break;
                                case Wind.north:
                                    nextWind = Wind.east;
                                    break;
                                case Wind.south:
                                    nextWind = Wind.west;
                                    break;
                                case Wind.west:
                                    nextWind = Wind.north;
                                    break;
                            }
                            wind = nextWind;
                        }
                        break;
                    case 'F':
                        switch (wind)
                        {
                            case Wind.east:
                                east += k.Item2;
                                break;
                            case Wind.north:
                                north += k.Item2;
                                break;
                            case Wind.south:
                                south += k.Item2;
                                break;
                            case Wind.west:
                                west += k.Item2;
                                break;
                        }
                        break;
                }
            }*/

            var norhtMinusSouth = Math.Abs(south - north);
            var eastLMinusWest = Math.Abs(east - west);
            var total = norhtMinusSouth + eastLMinusWest;
        }

        private static void DayEleven()
        {
            var datasRaw = "LLLLLLL.L.LL.L.LLLL.LLLLLLL.LLLLL.LLLLLL.LLLLLLL.L.LLL.LLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLL[TOTO]LLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLL.LLL..LLLLLLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLL.LLLL..LL.L.LLLLLLLLLLLLLLLLLLL.LLLL.[TOTO]LLLLLLLLL.LLLL.LLLL.LLL.LLL.LLLLL.L.LLLL.LLLL.LLLLLLLL.LLLLLLLLL.LL.LL.LLLLLLL.L.LLLL.LLLLL[TOTO]LLLLLLLLLLLLLL.LLLLLLLLLLL..LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLL[TOTO]LLLL.LLLL.LLLL.LLLL.LLLLLLL.LLLLL.LLLLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLL[TOTO]LLLLLLLLL..LLLLLLLL.LLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.L..L.LLLLLLL.LLLLL.LLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLL.LLLLL..LLLLLL.LLLLLLLLLLLL.LLLLLLLL.LLL.LL.LLLLLLLLL.LLLL.LLLLL[TOTO].L......LL..LL.LLL..L...L...L.............L........L.L......L..L...LLL....LLL..L..LL.....LL[TOTO]LLLLLLL.LLLL.L.LLLLLL.LLLLL.LLLLL.LLLLLL.LLL.LLLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LL.LL[TOTO]LLLLLLLLL.LLLL.LLLL..LLLLLL.LLLLL.LL.LL.LLLLLLLLLLLLL..LLL.LLLLLLLLLLLLLLL.LLLLL.LLLL.LLL.L[TOTO]LLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLL.LLLLLLL.L.LLL.LLLLLLLL.LLLLL..LLLLLLLLLLLLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLL..LLLLLLLLLLLLLLLLLLLLLLL.L.LLLLLLLLLL[TOTO]LLLLLLLLL.LLLL.L.LL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLL.LLLLLLLL..LLLLL.LLLLLLLLL.LLL..LLLLL[TOTO]LLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLL.LLLL.L.LLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLL.LLLLL[TOTO]LLLLLLLLLLLLLL.LLLLLLLLLLLL.L.LLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLL.LLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLLL.LLLLLL.LLLLL.LLL.LL.L.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLLLLLLLL.LLLLLLLL.L.LLLLLLLLLLLLLL.LLLL.LLLLL[TOTO].L....L..L....L...L..L..LL..L..L...LLL.LLL.L..........LL.L.LL..L.L...LLL..........L....LL.L[TOTO]LLLLLLLLL.LLLL.LLLL.LL.LLLLLLLL.L.LLLLLL..LLLLLL.LLLLL.LLLLL.LL.LLLLL..LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.LLLL.LLLLLLLL.LLLL.L.LLL.LLLLLLLLLLLLLLLLLL.LLLLL..LLLLLLLLL.LLLLLLLL.L[TOTO]LLL.LLLLL.LLLL.LLLL.LLLLLLL.LLLLL.LLLLLL.LL.LLLL.LLLL..LLLLLLLL.LL.LLLLLLLLLL.LL.LLLL.LLLLL[TOTO]LLLLLLLLL.LL.LLLLLLL.LLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLL.LLL.LLLL.LLLLLL.LLLLLLLLL.LLLLLLLLLL[TOTO]LL...LLLL.LLLL.LLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLL.LLLLL..LLLLLLLLL.LLLL.LLL.L[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLL.LLLLL..LLLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLL.L.LLLL.LLLL.LLLL.LLLLL[TOTO]..LL.LLLL.LLLLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL[TOTO]LL.LLLLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLLL.LLLLLLL..LLLLLL.LLLLLLLLL.LL.L.LLLL.[TOTO]LLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLL.LLLLLL.LLLLL.L.LLLLL.LLLLLLLL.LLLLLL.LLLL.LLLL.LLLLLLLLLL[TOTO]L........L.LL.....L..L...L....L....L.LL..L.........L..L..L......L.......L...L..L..........L[TOTO]LLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLL.LL.LLL.LLLLLLL.LLLLL.LLLLLLLL.L.LLLLL.LLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLLLLL.L.LLLL.LL.LLLLLLLL.L..LLLLLLLLLLLLL.LLLLLL.LLLLLLL..LLLLLLL.LLLLLL..LLLL.LLLLL[TOTO]LLLLLLLLL.L.LL.LLLL.LLLLLLL.LLLLL.LLLLLL.LLL.LL.LLLLL..LLLLLLLL.LLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLLL[TOTO]LLLLLLL.LLLLLLLLLL..LLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLLL.L.LLL.LL.LLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.L.LL.LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLL..LLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLL.[TOTO]..L.L.....LL.L.L..L.L....LLLL.L.L..L..L.L.L.......LL.L...LL..L.L.....L....L....LLL....L.L..[TOTO]LLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLL.LL[TOTO]LL.LLLLLLLL.LLLLLLLLLLLLLLL.LLLLL.LLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL[TOTO]LLLLLLLLLLLLLLL.LLL.L.LLLLL.LLLLL.LLLLLLLLLLLLLLLLL.LL.LLLLLLLL.LL..LLLLLLLLLLLL.LLLLLLLLLL[TOTO]LLLLLLLLL.LLLL.LLLLLLLLLLLL.LLLLL.LL.LLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLL..LLL.LLLLL[TOTO]LLLLLLL.L.LLLL.LLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLL.L.LLLLLLLL.LLLLLL.LLLLLLLLLLLLL..LLLLL[TOTO]LLLL.LLLL.LLLL.LLLL.LLLLLL.LLLLLL.LLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLL[TOTO]...L.........LL.L..L.L.L......LL.......L........L...LL...LL.LL.........L...LL...L.LLL..L.L.[TOTO]LLLLLLLLLLLLLL.LLLLL.LLLLLL.LLLLL.LLLLLL.LLLLLLLLLLLLLLLLLL.LLL.LLLLLLLLLLLLLL.L.LLLL.LLLLL[TOTO]LL..LLLLL.L.LL.LLLL.LLLL.LL.LLLLL.LLLLLL.LLLLL.LLLLLLL.LLLLLLLL.LLLLL..LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLLL.LLLLLL.LLLLL.LLL.L.LL.LLLLL[TOTO]LLLLLLLLLLLLLLLLLLL.LLLLLLL..LLLL.LLLLLL.LLLLL.L.LLL.LLLLLLLLLL.LLLLLL..LLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLL.LLLLL.LLLLLLLL.LLLLLL.LLLLLLLLLL.LLL.LLLLL[TOTO]..LL..LL....LL......L......LLL.L......L.L.L.L....L.LL....L...L.....L...L.L...LL....L.L.....[TOTO]LLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLL.LLLLL.L.LLLLL.LLLLL.LLLLLLLLL..LLLLLLLL.LLLLLLL.LL[TOTO]LLL.LLLLL.LLLLLL.LL.LLLLLLL.LLLLL.LLLLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLL.LLLLL.LLLLLLLLLLLL.L.LLLLL.LLLLLLLL.LLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLL.LLLLLL.LLLLLLL.L.LLL..LLLLLLLLLLL.LL.LLLLLLLLLLLL.L.LLLLL[TOTO]LLLLLLLLL.LLLL.L.LL.L.LLLLL.LLLLLLLLLLLL..LLLLL.LLLLL.LLL.LLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLL[TOTO]LLLLL.LLL.LLLL.LLLL.LLLLLLL.LLLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLL[TOTO]LLLLLLL.LLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLL.LLLLLLL.LLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLL[TOTO]LLLLLLLLL.LLLL.LLLLLLLLLLLLL.LLL.LLLLLLLLLLL.LLL.LLLLLLLLLLLLLL..LLLLLL.LLLLLLLLLLLLL.LLLLL[TOTO]L.L.LL.L.....L...L.........LLLL.....L.L..LL.LL..L.L.....L.....L..L.L.L....L.L..L..L..LL..LL[TOTO]LLLLL.LLL.LLLL.LLLL.LLLLLLL.LL.LL..LLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LL.L.LL.LL[TOTO]LLLLLLLLL.LLLL.LLL..LLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.LL.LLLL.LLLLL.LLL.LL.LL.LLLL.L.LLL.LLLLLLLLLLLLLLLLLLLLLL.LL..LLL.LLLLL[TOTO]LLLLLLLLL.LLLLLLL.L.LLLLLLL.LLLL..LLLLLL.LLL.LLL.LLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLL.LLL.LLLL.[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLLLLLL.L.LLLLLL..LLLLLL.LLLLL.LLLLLLL.LL.LLLLLLLLLLLLLLLLLLLLLLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLL.LLLLL.LLLLLL.LLLLLL..L.LLLLLLLLLLLL.LLLLLLLLLLL.LL.L...LL.LLLLL[TOTO]L.L.L.LLL.L....L...L...L.LL..LL....LLLLL.L..LLL...L..L.......L.LL...L.L.L......LL...L.L.L.L[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLL.LLLLL.L.LLLL.LLLLLLL.L.LLL.LLLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLL..LLLLLLLL.LLLLLLLLLLLLLLLL.LLL..LLLLL[TOTO]LLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLL.LLLLLLLLLL.LL.LLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLL[TOTO]LLL.LLLLL.LLLLL.LL..LLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.L.LLLLL.LLLLL.LLLLLL.LL.LLLLLLLLL..LLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLL[TOTO]LLLLLLLLLL.LLL.LLLL.LLLL.LL.LLLLL.LLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLL..LLLLL..LLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLL.LLLLLLL.LL[TOTO]LLLLLLL.LLLLL..LLLL.LLLLLLLLLLLLL.LLLLLL.L.LLLLL.LLLLLLLLLLLLLLLLLLLLL.L.LLLL.LL.LLLLLLLLLL[TOTO]LLLL.LLLL.LLLL.LLLLLLLLLLLL.LLLLL.LLLL.L.LLLLLLLLLLLLL.LLLLLLLL.LLLLLL.LLLLLLLLL.LLLLLLLLLL[TOTO]................L...LLL..LL....L.....L..L.LL..L....LL.L...LL.LL..L.L.L.....LLL.L....L.....L[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLL.LLLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLL.LLLLLL.LLLLLLLLLL.LLLLLLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLL..LLLLL.LL.LLL.LLLLLLLLLLLLL.LL.LLLLL.LLLLLL.LLL.LLLLL.LLLL.LLLLL[TOTO]LLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLLL.LLLL.LLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLL[TOTO]LLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLLLL.LLLL.LL.LLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLL.LLL..LLLLLLLLLLLLL.LLLLLLL.LLLLLLLL..LLLLLLLLLLLL.L.LLL[TOTO].LL...LLL.L.LL.LLLL.LLLLLLL.LLLL.LLLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLL.LL.LLL.LLLLLLLLLLL.L.LLLLLLLLLLLLLLL.LLLLLLLLL.LLL.LLLLLL[TOTO]LLLLLLLLL.LLLL.L.LL.LLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLL[TOTO]....L...L....LL.L.L..L.L..L...LL....LL.....L.L...LL.L.L.......LL.L....LLL...L..LL.L....LLLL[TOTO]LLLLLLLLL.LL.LLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLL.LLLLLLLL.LLLLLLLLLL[TOTO]LLLLLLLLLLLLLL.LLLL.L.LLLLL.LLLLLLLLLLLL..LLLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLL[TOTO]LLLLLLLL.L.LL..LLL..LLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLL.LLLLLLLL.LLLLLL.LLLLLLLLL.LLLLLLLLLL[TOTO]LLLLLLLLLLLLLLLLLLL.LLLL.LL.LLLLL.LLLLLL.LLLLLLL.L.LLL.LLLLLLLL.LLLLLLLLLLLLLLLL.LLLL.LLLLL[TOTO]LLLLLLLLL.LLLL.LLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLLL.LLLLLL.LLLLLLLLL.LLLLLLLLLL[TOTO]LLLLLLLLL.LLLL.LLLLLLLLLLL.LLLLLL.LLLLLL.LLLLLLL.LLLLL.LLLLLLLLLLLLLL..LLLLLLLLL.LLLLLLLLLL";
            //var datasRawSample = "L.LL.LL.LL[TOTO]LLLLLLL.LL[TOTO]L.L.L..L..[TOTO]LLLL.LL.LL[TOTO]L.LL.LL.LL[TOTO]L.LLLLL.LL[TOTO]..L.L.....[TOTO]LLLLLLLLLL[TOTO]L.LLLLLL.L[TOTO]L.LLLLL.LL";

            var datas = datasRaw.Split("[TOTO]").Select(v => v.ToArray()).ToArray();

            char[][] good = null;
            while (good == null)
            {
                bool change = false;
                var newDatas = new char[datas.Length][];
                for (int i = 0; i < datas.Length; i++)
                {
                    newDatas[i] = new char[datas[i].Length];
                    for (int j = 0; j < datas[i].Length; j++)
                    {
                        List<int> occupieds = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };

                        bool findOccupied = false;
                        bool findEmpty = false;
                        int k = i - 1;
                        while (k >= 0 && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][j] == '#';
                            findEmpty = datas[k][j] == 'L';
                            k--;
                        }
                        occupieds[0] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        k = i - 1;
                        var l = j + 1;
                        while (k >= 0 && l < datas[i].Length && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][l] == '#';
                            findEmpty = datas[k][l] == 'L';
                            k--;
                            l++;
                        }
                        occupieds[1] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        l = j + 1;
                        while (l < datas[i].Length && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[i][l] == '#';
                            findEmpty = datas[i][l] == 'L';
                            l++;
                        }
                        occupieds[2] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        k = i + 1;
                        l = j + 1;
                        while (k < datas.Length && l < datas[i].Length && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][l] == '#';
                            findEmpty = datas[k][l] == 'L';
                            k++;
                            l++;
                        }
                        occupieds[3] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        k = i + 1;
                        while (k < datas.Length && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][j] == '#';
                            findEmpty = datas[k][j] == 'L';
                            k++;
                        }
                        occupieds[4] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        k = i + 1;
                        l = j - 1;
                        while (k < datas.Length && l >= 0 && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][l] == '#';
                            findEmpty = datas[k][l] == 'L';
                            k++;
                            l--;
                        }
                        occupieds[5] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        l = j - 1;
                        while (l >= 0 && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[i][l] == '#';
                            findEmpty = datas[i][l] == 'L';
                            l--;
                        }
                        occupieds[6] = findOccupied ? 1 : 0;

                        findOccupied = false;
                        findEmpty = false;
                        k = i - 1;
                        l = j - 1;
                        while (k >= 0 && l >= 0 && !findOccupied && !findEmpty)
                        {
                            findOccupied = datas[k][l] == '#';
                            findEmpty = datas[k][l] == 'L';
                            k--;
                            l--;
                        }
                        occupieds[7] = findOccupied ? 1 : 0;

                        if (datas[i][j] == 'L')
                        {
                            if (occupieds.Sum() == 0)
                            {
                                newDatas[i][j] = '#';
                                change = true;
                            }
                            else
                            {
                                newDatas[i][j] = datas[i][j];
                            }
                        }
                        else if (datas[i][j] == '#')
                        {
                            if (occupieds.Sum() >= 5)
                            {
                                newDatas[i][j] = 'L';
                                change = true;
                            }
                            else
                            {
                                newDatas[i][j] = datas[i][j];
                            }
                        }
                        else
                        {
                            newDatas[i][j] = datas[i][j];
                        }
                    }
                }
                if (!change)
                {
                    good = datas;
                }
                else
                {
                    datas = newDatas;
                }
            }

            #region backup part 1
            /*char[][] good = null;
            while (good == null)
            {
                bool change = false;
                var newDatas = new char[datas.Length][];
                for (int i = 0; i < datas.Length; i++)
                {
                    newDatas[i] = new char[datas[i].Length];
                    for (int j = 0; j < datas[i].Length; j++)
                    {
                        if (datas[i][j] == 'L')
                        {
                            var top =
                                i == 0
                                || datas[i - 1][j] == 'L'
                                || datas[i - 1][j] == '.'
                                    ? 1 : 0;
                            var top_right =
                                i == 0
                                || j + 1 == datas[i].Length
                                || datas[i - 1][j + 1] == 'L'
                                || datas[i - 1][j + 1] == '.'
                                    ? 1 : 0;
                            var right =
                                j + 1 == datas[i].Length
                                || datas[i][j + 1] == 'L'
                                || datas[i][j + 1] == '.'
                                    ? 1 : 0;
                            var bottom_right =
                                i + 1 == datas.Length
                                || j + 1 == datas[i].Length
                                || datas[i + 1][j + 1] == 'L'
                                || datas[i + 1][j + 1] == '.'
                                    ? 1 : 0;
                            var bottom =
                                i + 1 == datas.Length
                                || datas[i + 1][j] == 'L'
                                || datas[i + 1][j] == '.'
                                    ? 1 : 0;
                            var bottom_left =
                                i + 1 == datas.Length
                                || j == 0
                                || datas[i + 1][j - 1] == 'L'
                                || datas[i + 1][j - 1] == '.'
                                    ? 1 : 0;
                            var left =
                                j == 0
                                || datas[i][j - 1] == 'L'
                                || datas[i][j - 1] == '.'
                                    ? 1 : 0;
                            var top_left =
                                i == 0
                                || j == 0
                                || datas[i - 1][j - 1] == 'L'
                                || datas[i - 1][j - 1] == '.'
                                    ? 1 : 0;
                            if (top + top_right + right + bottom_right + bottom + bottom_left + left + top_left == 8)
                            {
                                newDatas[i][j] = '#';
                                change = true;
                            }
                            else
                            {
                                newDatas[i][j] = datas[i][j];
                            }
                        }
                        else if (datas[i][j] == '#')
                        {
                            var top =
                                 i != 0
                                 && datas[i - 1][j] == '#'
                                     ? 1 : 0;
                            var top_right =
                                i != 0
                                && j + 1 != datas[i].Length
                                && datas[i - 1][j + 1] == '#'
                                    ? 1 : 0;
                            var right =
                                j + 1 != datas[i].Length
                                && datas[i][j + 1] == '#'
                                    ? 1 : 0;
                            var bottom_right =
                                i + 1 != datas.Length
                                && j + 1 != datas[i].Length
                                && datas[i + 1][j + 1] == '#'
                                    ? 1 : 0;
                            var bottom =
                                i + 1 != datas.Length
                                && datas[i + 1][j] == '#'
                                    ? 1 : 0;
                            var bottom_left =
                                i + 1 != datas.Length
                                && j != 0
                                && datas[i + 1][j - 1] == '#'
                                    ? 1 : 0;
                            var left =
                                j != 0
                                && datas[i][j - 1] == '#'
                                    ? 1 : 0;
                            var top_left =
                                i != 0
                                && j != 0
                                && datas[i - 1][j - 1] == '#'
                                    ? 1 : 0;
                            if (top + top_right + right + bottom_right + bottom + bottom_left + left + top_left >= 4)
                            {
                                newDatas[i][j] = 'L';
                                change = true;
                            }
                            else
                            {
                                newDatas[i][j] = datas[i][j];
                            }
                        }
                        else
                        {
                            newDatas[i][j] = datas[i][j];
                        }
                    }
                }
                if (!change)
                {
                    good = datas;
                }
                else
                {
                    datas = newDatas;
                }
            }*/
            #endregion

            var total = good.Sum(g => g.Sum(v => v == '#' ? 1 : 0));
        }

        private static void DayTen()
        {
            var baseDatas = "18[TOTO]47[TOTO]144[TOTO]147[TOTO]124[TOTO]45[TOTO]81[TOTO]56[TOTO]16[TOTO]59[TOTO]97[TOTO]83[TOTO]75[TOTO]150[TOTO]33[TOTO]165[TOTO]30[TOTO]159[TOTO]84[TOTO]141[TOTO]104[TOTO]25[TOTO]164[TOTO]90[TOTO]92[TOTO]88[TOTO]2[TOTO]8[TOTO]51[TOTO]24[TOTO]153[TOTO]63[TOTO]27[TOTO]123[TOTO]127[TOTO]58[TOTO]108[TOTO]52[TOTO]38[TOTO]15[TOTO]149[TOTO]66[TOTO]72[TOTO]21[TOTO]46[TOTO]89[TOTO]135[TOTO]55[TOTO]34[TOTO]37[TOTO]78[TOTO]65[TOTO]134[TOTO]148[TOTO]76[TOTO]138[TOTO]103[TOTO]162[TOTO]114[TOTO]109[TOTO]42[TOTO]77[TOTO]102[TOTO]163[TOTO]7[TOTO]105[TOTO]69[TOTO]39[TOTO]91[TOTO]111[TOTO]131[TOTO]130[TOTO]6[TOTO]137[TOTO]96[TOTO]82[TOTO]64[TOTO]3[TOTO]95[TOTO]136[TOTO]85[TOTO]9[TOTO]116[TOTO]17[TOTO]99[TOTO]12[TOTO]117[TOTO]62[TOTO]50[TOTO]110[TOTO]26[TOTO]115[TOTO]71[TOTO]57[TOTO]156[TOTO]120[TOTO]98[TOTO]1[TOTO]70";
            //var baseDatas = "28[TOTO]33[TOTO]18[TOTO]42[TOTO]31[TOTO]14[TOTO]46[TOTO]20[TOTO]48[TOTO]47[TOTO]24[TOTO]23[TOTO]49[TOTO]45[TOTO]19[TOTO]38[TOTO]39[TOTO]11[TOTO]1[TOTO]32[TOTO]25[TOTO]35[TOTO]8[TOTO]17[TOTO]7[TOTO]9[TOTO]4[TOTO]2[TOTO]34[TOTO]10[TOTO]3";
            //var baseDatas = "16[TOTO]10[TOTO]15[TOTO]5[TOTO]1[TOTO]11[TOTO]7[TOTO]19[TOTO]6[TOTO]12[TOTO]4";

            var datas = baseDatas.Split("[TOTO]").Select(v => Convert.ToInt32(v)).ToList();

            datas.Add(0);
            datas.Add(datas.Max() + 3);

            datas.Sort();

            List<List<int>> splitBy3 = new List<List<int>>();
            var subList = new List<int>();
            int current = 0;
            foreach (var d in datas)
            {
                if (d - current == 3)
                {
                    splitBy3.Add(new List<int>(subList));
                    subList = new List<int>();
                }
                subList.Add(d);
                current = d;
            }

            void Calculate(List<int> baseList, List<List<int>> listToAdd, List<int> currentIteration, int currentIndex, int currentCount, int countofSubGroup)
            {
                if (currentCount == countofSubGroup)
                {
                    listToAdd.Add(new List<int>(currentIteration));
                    return;
                }

                if (currentIndex >= baseList.Count)
                    return;

                currentIteration.Add(baseList[currentIndex]);
                Calculate(baseList, listToAdd, currentIteration, currentIndex + 1, currentCount + 1, countofSubGroup);
                currentIteration.Remove(baseList[currentIndex]);


                Calculate(baseList, listToAdd, currentIteration, currentIndex + 1, currentCount, countofSubGroup);

            }

            Dictionary<List<int>, int> combosCount = splitBy3.ToDictionary(v => v, v => 0);
            var keys = combosCount.Keys.ToList();

            foreach (var combo in keys)
            {
                var subgroups = new List<List<int>>();
                for (int i = 1; i <= combo.Count; i++)
                {
                    Calculate(combo, subgroups, new List<int>(), 0, 0, i);
                }

                var count = 0;
                foreach (var subgroup in subgroups)
                {
                    if (!subgroup.Contains(combo[0]) || !subgroup.Contains(combo.Last()))
                    {
                        continue;
                    }

                    bool breakNotGood = false;
                    for (int i = 1; i < subgroup.Count; i++)
                    {
                        if (subgroup[i] - subgroup[i - 1] > 3)
                        {
                            breakNotGood = true;
                            break;
                        }
                    }
                    if (!breakNotGood)
                    {
                        count++;
                    }
                }

                combosCount[combo] = count;
            }

            long total = 1;
            foreach (var combo in combosCount.Keys)
            {
                total = total * combosCount[combo];
            }

            // exercice 1
            /*int voltage = 0;
            bool found = true;
            var spreadCount = new Dictionary<int, int>
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 }
            };
            while (found)
            {
                var matches = datas.Where(x => x > voltage && x <= voltage + 3).ToList();
                if (matches.Count > 0)
                {
                    var nextVoltage = matches.Min();
                    spreadCount[nextVoltage - voltage]++;
                    voltage = nextVoltage;
                }
                found = matches.Count > 0;
            }
            spreadCount[3]++;

            var total = spreadCount[1] * spreadCount[3];*/
        }

        private static void DayNine()
        {
            var badNumber = 23278925; // from part 1

            string source = "13[TOTO]41[TOTO]12[TOTO]29[TOTO]40[TOTO]27[TOTO]22[TOTO]38[TOTO]4[TOTO]8[TOTO]33[TOTO]39[TOTO]16[TOTO]45[TOTO]47[TOTO]23[TOTO]37[TOTO]31[TOTO]1[TOTO]10[TOTO]24[TOTO]20[TOTO]9[TOTO]32[TOTO]46[TOTO]5[TOTO]11[TOTO]17[TOTO]6[TOTO]21[TOTO]7[TOTO]18[TOTO]22[TOTO]40[TOTO]44[TOTO]8[TOTO]15[TOTO]12[TOTO]25[TOTO]64[TOTO]13[TOTO]16[TOTO]14[TOTO]19[TOTO]29[TOTO]28[TOTO]26[TOTO]20[TOTO]23[TOTO]38[TOTO]24[TOTO]30[TOTO]27[TOTO]35[TOTO]31[TOTO]21[TOTO]32[TOTO]34[TOTO]39[TOTO]61[TOTO]22[TOTO]33[TOTO]36[TOTO]37[TOTO]40[TOTO]41[TOTO]42[TOTO]63[TOTO]55[TOTO]43[TOTO]44[TOTO]45[TOTO]50[TOTO]51[TOTO]53[TOTO]66[TOTO]78[TOTO]73[TOTO]52[TOTO]54[TOTO]56[TOTO]96[TOTO]58[TOTO]59[TOTO]65[TOTO]62[TOTO]75[TOTO]95[TOTO]80[TOTO]81[TOTO]83[TOTO]85[TOTO]101[TOTO]102[TOTO]87[TOTO]89[TOTO]97[TOTO]105[TOTO]103[TOTO]106[TOTO]108[TOTO]111[TOTO]170[TOTO]110[TOTO]193[TOTO]141[TOTO]117[TOTO]120[TOTO]121[TOTO]140[TOTO]294[TOTO]155[TOTO]197[TOTO]198[TOTO]186[TOTO]182[TOTO]172[TOTO]176[TOTO]184[TOTO]391[TOTO]211[TOTO]200[TOTO]218[TOTO]275[TOTO]214[TOTO]290[TOTO]221[TOTO]231[TOTO]227[TOTO]237[TOTO]238[TOTO]403[TOTO]241[TOTO]569[TOTO]398[TOTO]360[TOTO]407[TOTO]348[TOTO]383[TOTO]356[TOTO]801[TOTO]372[TOTO]376[TOTO]402[TOTO]411[TOTO]682[TOTO]414[TOTO]439[TOTO]435[TOTO]441[TOTO]452[TOTO]759[TOTO]597[TOTO]464[TOTO]817[TOTO]794[TOTO]589[TOTO]724[TOTO]736[TOTO]704[TOTO]720[TOTO]728[TOTO]731[TOTO]1134[TOTO]732[TOTO]748[TOTO]787[TOTO]778[TOTO]841[TOTO]1139[TOTO]849[TOTO]853[TOTO]1293[TOTO]887[TOTO]1200[TOTO]916[TOTO]1305[TOTO]1053[TOTO]1460[TOTO]1309[TOTO]1367[TOTO]1455[TOTO]1467[TOTO]2029[TOTO]2087[TOTO]1448[TOTO]1459[TOTO]1463[TOTO]2427[TOTO]1480[TOTO]1601[TOTO]1565[TOTO]1619[TOTO]1690[TOTO]2316[TOTO]1702[TOTO]3003[TOTO]2335[TOTO]2362[TOTO]3484[TOTO]2764[TOTO]2513[TOTO]2420[TOTO]4693[TOTO]3170[TOTO]3886[TOTO]4629[TOTO]2907[TOTO]2911[TOTO]2922[TOTO]4203[TOTO]2939[TOTO]5588[TOTO]3045[TOTO]5683[TOTO]3220[TOTO]7393[TOTO]3309[TOTO]3392[TOTO]5273[TOTO]4037[TOTO]4697[TOTO]4848[TOTO]8089[TOTO]4933[TOTO]5184[TOTO]5327[TOTO]5331[TOTO]6142[TOTO]5818[TOTO]6612[TOTO]5829[TOTO]5861[TOTO]5833[TOTO]5967[TOTO]5984[TOTO]10815[TOTO]6265[TOTO]6354[TOTO]6529[TOTO]6701[TOTO]11974[TOTO]7346[TOTO]11813[TOTO]10558[TOTO]8734[TOTO]10664[TOTO]10117[TOTO]10260[TOTO]12094[TOTO]10511[TOTO]10658[TOTO]11192[TOTO]12445[TOTO]11647[TOTO]23460[TOTO]11662[TOTO]11800[TOTO]12098[TOTO]16080[TOTO]12249[TOTO]17457[TOTO]12619[TOTO]12883[TOTO]13230[TOTO]14047[TOTO]17463[TOTO]17606[TOTO]20377[TOTO]20771[TOTO]18851[TOTO]20628[TOTO]20775[TOTO]21452[TOTO]21169[TOTO]21703[TOTO]21850[TOTO]33686[TOTO]23309[TOTO]23447[TOTO]32428[TOTO]30836[TOTO]25847[TOTO]24981[TOTO]24868[TOTO]25132[TOTO]25502[TOTO]44075[TOTO]34335[TOTO]30693[TOTO]31510[TOTO]35069[TOTO]36457[TOTO]59188[TOTO]43937[TOTO]40554[TOTO]60916[TOTO]65527[TOTO]42621[TOTO]61589[TOTO]47550[TOTO]56378[TOTO]58554[TOTO]46756[TOTO]48315[TOTO]49849[TOTO]56540[TOTO]84690[TOTO]50370[TOTO]50000[TOTO]110192[TOTO]94257[TOTO]84184[TOTO]71247[TOTO]83213[TOTO]66579[TOTO]75623[TOTO]77011[TOTO]83175[TOTO]97920[TOTO]87310[TOTO]132836[TOTO]116949[TOTO]90171[TOTO]94306[TOTO]95071[TOTO]158798[TOTO]98164[TOTO]122379[TOTO]146870[TOTO]137159[TOTO]100370[TOTO]121247[TOTO]116579[TOTO]125623[TOTO]161195[TOTO]143590[TOTO]153889[TOTO]148258[TOTO]152634[TOTO]286725[TOTO]264837[TOTO]252053[TOTO]222749[TOTO]182381[TOTO]181616[TOTO]184477[TOTO]188335[TOTO]185242[TOTO]189377[TOTO]193235[TOTO]198534[TOTO]214743[TOTO]247240[TOTO]318858[TOTO]216949[TOTO]237826[TOTO]242202[TOTO]269213[TOTO]273881[TOTO]291848[TOTO]296224[TOTO]333500[TOTO]378477[TOTO]453172[TOTO]363997[TOTO]367623[TOTO]396359[TOTO]387911[TOTO]366093[TOTO]386869[TOTO]369719[TOTO]382612[TOTO]374619[TOTO]391769[TOTO]581146[TOTO]413277[TOTO]452569[TOTO]459151[TOTO]480028[TOTO]454775[TOTO]507039[TOTO]516083[TOTO]543094[TOTO]565729[TOTO]769481[TOTO]750866[TOTO]898808[TOTO]730090[TOTO]748705[TOTO]731620[TOTO]754492[TOTO]735812[TOTO]740712[TOTO]744338[TOTO]752331[TOTO]1127581[TOTO]1144100[TOTO]1059177[TOTO]1493043[TOTO]865846[TOTO]920316[TOTO]975234[TOTO]934803[TOTO]1683508[TOTO]961814[TOTO]1072768[TOTO]1291799[TOTO]1108823[TOTO]1295819[TOTO]1461710[TOTO]1669021[TOTO]1467432[TOTO]1472332[TOTO]3145218[TOTO]1475958[TOTO]1476524[TOTO]1672647[TOTO]2020991[TOTO]1496669[TOTO]1618177[TOTO]2435899[TOTO]2168000[TOTO]2396274[TOTO]1786162[TOTO]1800649[TOTO]1910037[TOTO]2368587[TOTO]1896617[TOTO]3455183[TOTO]3145545[TOTO]2181591[TOTO]2400622[TOTO]2404642[TOTO]2757529[TOTO]5891082[TOTO]2939764[TOTO]2943390[TOTO]2948290[TOTO]2952482[TOTO]2972627[TOTO]2973193[TOTO]3114846[TOTO]3393286[TOTO]3406706[TOTO]5807328[TOTO]5730156[TOTO]5120482[TOTO]8755618[TOTO]12162324[TOTO]3697266[TOTO]6098027[TOTO]7626773[TOTO]5705819[TOTO]4582213[TOTO]4586233[TOTO]4805264[TOTO]5352932[TOTO]10599400[TOTO]8068772[TOTO]11828183[TOTO]5883154[TOTO]9212873[TOTO]5900772[TOTO]8198550[TOTO]7920110[TOTO]6088039[TOTO]10389541[TOTO]20231096[TOTO]7103972[TOTO]11435975[TOTO]8279479[TOTO]12865712[TOTO]11617376[TOTO]8283499[TOTO]8502530[TOTO]13551482[TOTO]9168446[TOTO]9387477[TOTO]10688418[TOTO]9391497[TOTO]32059279[TOTO]19938505[TOTO]14081704[TOTO]11783926[TOTO]15024082[TOTO]11971193[TOTO]11988811[TOTO]13004744[TOTO]13192011[TOTO]14008149[TOTO]15606502[TOTO]21825516[TOTO]15383451[TOTO]22472344[TOTO]25792075[TOTO]21171403[TOTO]17890007[TOTO]24809387[TOTO]22360457[TOTO]27273715[TOTO]18555923[TOTO]18559943[TOTO]33160762[TOTO]20079915[TOTO]32914089[TOTO]23755119[TOTO]23772737[TOTO]23960004[TOTO]24788670[TOTO]29391600[TOTO]30989953[TOTO]36480493[TOTO]30894751[TOTO]23278925[TOTO]36554854[TOTO]33943394[TOTO]33273458[TOTO]33939374[TOTO]38635838[TOTO]63904042[TOTO]36445930[TOTO]42699394[TOTO]37115866[TOTO]38639858[TOTO]47238929[TOTO]59759418[TOTO]48543789[TOTO]69534609[TOTO]48748674[TOTO]47034044[TOTO]47051662[TOTO]47732741[TOTO]54180270[TOTO]48067595[TOTO]64168209[TOTO]69753951[TOTO]57218299[TOTO]118084312[TOTO]56552383[TOTO]67882768[TOTO]95188221[TOTO]67212832[TOTO]81672115[TOTO]101214314[TOTO]93664229[TOTO]79815260[TOTO]75755724[TOTO]103604045[TOTO]95595451[TOTO]123927627[TOTO]104619978[TOTO]115280427[TOTO]96816269[TOTO]94766785[TOTO]104269961[TOTO]94784403[TOTO]101913011[TOTO]102247865[TOTO]105285894[TOTO]113770682[TOTO]123765215[TOTO]220332177[TOTO]199808199[TOTO]124435151[TOTO]135095600[TOTO]142968556[TOTO]174582045[TOTO]155570984[TOTO]172571993[TOTO]170522509[TOTO]199404381[TOTO]170540127[TOTO]189551188[TOTO]190362236[TOTO]191600672[TOTO]191583054[TOTO]218532000[TOTO]293830919[TOTO]229862385[TOTO]196697414[TOTO]207198905[TOTO]301652246[TOTO]366182717[TOTO]219056576[TOTO]237535897[TOTO]248200366[TOTO]290666584[TOTO]418340199[TOTO]367219923[TOTO]345933220[TOTO]298539540[TOTO]326093493[TOTO]326111111[TOTO]388280468[TOTO]362123181[TOTO]528401925[TOTO]360091315[TOTO]379913424[TOTO]381945290[TOTO]383183726[TOTO]403896319[TOTO]425730905[TOTO]579881140[TOTO]426255481[TOTO]415753990[TOTO]908315349[TOTO]538866950[TOTO]686202426[TOTO]467256942[TOTO]563629390[TOTO]636480834[TOTO]693331034[TOTO]624633033[TOTO]708056401[TOTO]989360295[TOTO]1006578323[TOTO]944155915[TOTO]814011373[TOTO]795667414[TOTO]722214496[TOTO]808914631[TOTO]1005612045[TOTO]1075276324[TOTO]1147945401[TOTO]787080045[TOTO]819650309[TOTO]893512423[TOTO]883010932[TOTO]1430270897[TOTO]1030886332[TOTO]1006123892[TOTO]1091889975[TOTO]1642604726[TOTO]1188262423[TOTO]1200110224[TOTO]1814526676[TOTO]1655519365[TOTO]1702661241[TOTO]1503723815[TOTO]1509294541[TOTO]2649183049[TOTO]1697022305[TOTO]1517881910[TOTO]1582747459[TOTO]2386734747[TOTO]1888622977[TOTO]2522311550[TOTO]1606730354[TOTO]2019760533[TOTO]2590534728[TOTO]1713162732[TOTO]2230996556[TOTO]1889134824[TOTO]2673491058[TOTO]2709404765[TOTO]2509847707[TOTO]2280152398[TOTO]2691986238[TOTO]3323821217[TOTO]2703834039[TOTO]3086471274[TOTO]3013018356[TOTO]3279769764[TOTO]3021605725[TOTO]3027176451[TOTO]3214904215[TOTO]3886882752[TOTO]3100629369[TOTO]5603973615[TOTO]4099897479[TOTO]3319893086[TOTO]4707359723[TOTO]4303697460[TOTO]6332911442[TOTO]8818877830[TOTO]4398982531[TOTO]4581121062[TOTO]6987512121[TOTO]4953643456[TOTO]4790000105[TOTO]5213681746[TOTO]4972138636[TOTO]7613886746[TOTO]5716852395[TOTO]5725439764[TOTO]6034624081[TOTO]9661003179[TOTO]6048782176[TOTO]7404326829[TOTO]6127805820[TOTO]6315533584[TOTO]9288480785[TOTO]10338321541[TOTO]7419790565[TOTO]8889897584[TOTO]11546593188[TOTO]8702679991[TOTO]12201193867[TOTO]9371121167[TOTO]8980103593[TOTO]11853245584[TOTO]9534764518[TOTO]9743643561[TOTO]9762138741[TOTO]18178378369[TOTO]10185820382[TOTO]10688991031[TOTO]11442292159[TOTO]15013920549[TOTO]19195767697[TOTO]12162429901[TOTO]15709785355[TOTO]18905885685[TOTO]12443339404[TOTO]15017703404[TOTO]15018213575[TOTO]16122470556[TOTO]16309688149[TOTO]16399894158[TOTO]18446323552[TOTO]17682783584[TOTO]18073801158[TOTO]22131283190[TOTO]18351224760[TOTO]18723747154[TOTO]19947959123[TOTO]19296903259[TOTO]20451129772[TOTO]35305779843[TOTO]20874811413[TOTO]28259621540[TOTO]22851420932[TOTO]31327391553[TOTO]24605769305[TOTO]33741450558[TOTO]27180133305[TOTO]37149496765[TOTO]35468833176[TOTO]27461042808[TOTO]51424234142[TOTO]53657004603[TOTO]32432158705[TOTO]32709582307[TOTO]46983368694[TOTO]35756584742[TOTO]36034008344[TOTO]36425025918[TOTO]56631396155[TOTO]37074971914[TOTO]38020650413[TOTO]54641176113[TOTO]45480580718[TOTO]41325941185[TOTO]53584393720[TOTO]50031554237[TOTO]47457190237[TOTO]50312463740[TOTO]89063554860[TOTO]58347219863[TOTO]60921583863[TOTO]74054658757[TOTO]60170625115[TOTO]87849260060[TOTO]63217627550[TOTO]106486817462[TOTO]103615947957[TOTO]129175201245[TOTO]68743590651[TOTO]91605044133[TOTO]71790593086[TOTO]77359949529[TOTO]79346591598[TOTO]98191275528[TOTO]154822671683[TOTO]83501231131[TOTO]94910334905[TOTO]86806521903[TOTO]105804410100[TOTO]97488744474[TOTO]97769653977[TOTO]116200780888[TOTO]110483088855[TOTO]118517844978[TOTO]119268803726[TOTO]129665174514[TOTO]156706541127[TOTO]139517216713[TOTO]131961218201[TOTO]135008220636[TOTO]234066490656[TOTO]180975897486[TOTO]189796319661[TOTO]223018447844[TOTO]189305641231[TOTO]149150542615[TOTO]162847822729[TOTO]177537867126[TOTO]170307753034[TOTO]266969438837[TOTO]199702012019[TOTO]203007302791[TOTO]184295266377[TOTO]195258398451[TOTO]207971833329[TOTO]378279586363[TOTO]226683869743[TOTO]237786648704[TOTO]248183019492[TOTO]261626392715[TOTO]264673395150[TOTO]288667759328[TOTO]271478434914[TOTO]315984118122[TOTO]365566151485[TOTO]434326257643[TOTO]330126440101[TOTO]311998365344[TOTO]319458295649[TOTO]347845620160[TOTO]604634010677[TOTO]361833133503[TOTO]354603019411[TOTO]387302569168[TOTO]464375407169[TOTO]503753562026[TOTO]398265701242[TOTO]550294152043[TOTO]403230231780[TOTO]753784553292[TOTO]464470518447[TOTO]526299787865[TOTO]576671760494[TOTO]780454636569[TOTO]666601384755[TOTO]553341154478[TOTO]706760864817[TOTO]583476800258[TOTO]627982483466[TOTO]677972060261[TOTO]649584735750[TOTO]966467144180[TOTO]674061315060[TOTO]709678753663[TOTO]702448639571[TOTO]716436152914[TOTO]741905588579[TOTO]752868720653[TOTO]785568270410[TOTO]1126965912537[TOTO]801495933022[TOTO]1041142278941[TOTO]867700750227[TOTO]929530019645[TOTO]1175884523615[TOTO]990770306312[TOTO]1079640942343[TOTO]1130012914972[TOTO]1277567219216[TOTO]1502004423324[TOTO]1136817954736[TOTO]1211459283724[TOTO]1233061536008[TOTO]1776338576722[TOTO]1323646050810[TOTO]1352033375321[TOTO]1376509954631[TOTO]1843402065451[TOTO]1782089581914[TOTO]1418884792485[TOTO]1458341741493[TOTO]2287572693734[TOTO]1538436991063[TOTO]1587064203432[TOTO]1842638211963[TOTO]1669196683249[TOTO]2252601562665[TOTO]1858471056539[TOTO]1920300325957[TOTO]2862083041873[TOTO]3166284262773[TOTO]2209653857315[TOTO]2348277238460[TOTO]3363402780154[TOTO]3991743439229[TOTO]2488851330057[TOTO]4720554098412[TOTO]3512598748700[TOTO]4638421618595[TOTO]5350934371930[TOTO]3005948995917[TOTO]2795394747116[TOTO]2877226533978[TOTO]2957321783548[TOTO]2996778732556[TOTO]4464290737410[TOTO]3125501194495[TOTO]3207633674312[TOTO]3256260886681[TOTO]4653865803655[TOTO]3527667739788[TOTO]6848075475910[TOTO]5345055971016[TOTO]4129954183272[TOTO]4557931095775[TOTO]4698505187372[TOTO]4837128568517[TOTO]5604538125141[TOTO]8347713104486[TOTO]5284246077173[TOTO]5366077864035[TOTO]6524446472344[TOTO]5672621281094[TOTO]5752716530664[TOTO]7657621923060[TOTO]5792173479672[TOTO]5834548317526[TOTO]9844854208466[TOTO]8409747271668[TOTO]6253039619237[TOTO]7824006381867[TOTO]14182261422012[TOTO]11200626181561[TOTO]7954766074053[TOTO]10162469220916[TOTO]10654400655616[TOTO]8687885279047[TOTO]8828459370644[TOTO]8967082751789[TOTO]9256436283147[TOTO]9535633755889[TOTO]10970615989176[TOTO]10650323941208[TOTO]10956867358267[TOTO]14077046001104[TOTO]11038699145129[TOTO]24027115630478[TOTO]15517475489560[TOTO]11544890010336[TOTO]13910661542297[TOTO]11626721797198[TOTO]12087587936763[TOTO]14207805693290[TOTO]20460845312527[TOTO]14940924898284[TOTO]19923950110056[TOTO]16642651353100[TOTO]16783225444697[TOTO]16921848825842[TOTO]17516344649691[TOTO]17944321562194[TOTO]17654968030836[TOTO]17795542122433[TOTO]18223519034936[TOTO]18792070039036[TOTO]20185957697097[TOTO]27681350498229[TOTO]21607191299475[TOTO]22583589155465[TOTO]22665420942327[TOTO]23126287081892[TOTO]28548570623040[TOTO]23171611807534[TOTO]50852962305763[TOTO]33705074270539[TOTO]33564500178942[TOTO]26295393630053[TOTO]29148730591574[TOTO]31583576251384[TOTO]31724150342981[TOTO]40642631731583[TOTO]33425876797797[TOTO]34438193475533[TOTO]39123535949166[TOTO]45791708024219[TOTO]35450510153269[TOTO]45476892620662[TOTO]36019061157369[TOTO]38409476732033[TOTO]38978027736133[TOTO]41793148996572[TOTO]44190780454940[TOTO]57057701452744[TOTO]58602650312834[TOTO]54709863333276[TOTO]62104314818025[TOTO]49467005437587[TOTO]52320342399108[TOTO]55444124221627[TOTO]60000467900592[TOTO]58019543973034[TOTO]57878969881437[TOTO]60732306842958[TOTO]69888703628802[TOTO]65150027140778[TOTO]75080825207116[TOTO]68876386951066[TOTO]93687891069409[TOTO]128491353941636[TOTO]73859986885302";

            var datas = source.Split("[TOTO]").Select(x => Convert.ToInt64(x)).ToList();

            // second part
            /*for (int i = 0; i < datas.Count; i++)
            {
                if (datas[i] == badNumber)
                {
                    continue;
                }

                long currentMax = 0;
                int j = i;
                while (currentMax < badNumber)
                {
                    currentMax += datas[j];
                    j++;
                }
                if (currentMax == badNumber)
                {

                }
            }*/

            // result of second part = 400 to 416
            var ranged = datas.Skip(400).Take(17).ToList();
            var sum = ranged.Sum();
            var min = ranged.Min();
            var max = ranged.Max();
            var summinmax = min + max;

            if (badNumber != sum)
            {
                // booouh
            }

            // first part
            /*bool ok = true;
            int i = 25;
            int skip = 0;
            long mark = -1;
            while (ok)
            {
                var last25 = datas.Skip(skip).Take(25).ToList();

                bool found = false;
                for (int j = 0; j < 25; j++)
                {
                    for (int k = 0; k < 25; k++)
                    {
                        if (last25[j] != last25[k])
                        {
                            if (last25[j] + last25[k] == datas[i])
                            {
                                found = true;
                            }
                        }
                    }
                }

                ok = found;
                mark = datas[i];
                i++;
                skip++;
            }*/
        }

        private static void DayEight()
        {
            string datas = "nop +81[TOTO]acc -17[TOTO]jmp +1[TOTO]acc +31[TOTO]jmp +211[TOTO]acc +30[TOTO]acc -7[TOTO]jmp +29[TOTO]acc +16[TOTO]nop +89[TOTO]jmp +163[TOTO]acc -9[TOTO]acc +40[TOTO]jmp +189[TOTO]jmp +111[TOTO]acc +0[TOTO]acc +6[TOTO]jmp +19[TOTO]acc +6[TOTO]acc +16[TOTO]jmp +78[TOTO]nop +178[TOTO]jmp +441[TOTO]acc +27[TOTO]acc +34[TOTO]jmp +3[TOTO]acc +9[TOTO]jmp +302[TOTO]acc -4[TOTO]acc +33[TOTO]jmp +417[TOTO]nop +80[TOTO]acc +34[TOTO]acc +11[TOTO]nop +181[TOTO]jmp -12[TOTO]jmp +143[TOTO]jmp +53[TOTO]jmp +52[TOTO]jmp +324[TOTO]acc +0[TOTO]acc -8[TOTO]acc +47[TOTO]jmp +1[TOTO]jmp +169[TOTO]acc +23[TOTO]acc -14[TOTO]acc -6[TOTO]acc -13[TOTO]jmp +267[TOTO]acc +24[TOTO]jmp +188[TOTO]acc +36[TOTO]jmp +160[TOTO]acc +14[TOTO]acc +34[TOTO]acc -18[TOTO]jmp +500[TOTO]jmp +137[TOTO]jmp +295[TOTO]acc +11[TOTO]jmp +393[TOTO]acc +24[TOTO]acc +37[TOTO]nop +258[TOTO]acc +20[TOTO]jmp -52[TOTO]acc +40[TOTO]jmp +1[TOTO]jmp +62[TOTO]acc +34[TOTO]nop +312[TOTO]acc +39[TOTO]nop +431[TOTO]jmp +386[TOTO]acc -17[TOTO]nop +282[TOTO]acc -8[TOTO]jmp +490[TOTO]jmp +148[TOTO]jmp -1[TOTO]jmp +201[TOTO]jmp -54[TOTO]acc +0[TOTO]acc +22[TOTO]jmp +110[TOTO]nop +443[TOTO]nop +388[TOTO]acc +28[TOTO]jmp +167[TOTO]nop +48[TOTO]acc +46[TOTO]jmp +406[TOTO]acc +11[TOTO]acc +17[TOTO]acc +23[TOTO]jmp +1[TOTO]jmp +286[TOTO]acc +0[TOTO]acc -15[TOTO]acc +1[TOTO]acc +6[TOTO]jmp +214[TOTO]acc +39[TOTO]acc +21[TOTO]acc +34[TOTO]jmp +341[TOTO]jmp +417[TOTO]jmp +400[TOTO]jmp -2[TOTO]jmp +117[TOTO]acc -10[TOTO]acc +14[TOTO]acc +10[TOTO]acc +10[TOTO]jmp +339[TOTO]jmp +162[TOTO]acc +16[TOTO]nop +20[TOTO]acc +12[TOTO]acc -11[TOTO]jmp +78[TOTO]acc +21[TOTO]acc +12[TOTO]jmp +181[TOTO]jmp +404[TOTO]nop +26[TOTO]jmp +46[TOTO]jmp +1[TOTO]jmp -93[TOTO]jmp -76[TOTO]acc -1[TOTO]nop +30[TOTO]acc +48[TOTO]jmp +238[TOTO]acc +6[TOTO]nop +244[TOTO]jmp +36[TOTO]acc +10[TOTO]acc +8[TOTO]acc +19[TOTO]acc +3[TOTO]jmp -72[TOTO]nop +225[TOTO]jmp +228[TOTO]acc +44[TOTO]acc -13[TOTO]jmp +349[TOTO]acc -8[TOTO]acc +45[TOTO]acc -11[TOTO]jmp +76[TOTO]acc +46[TOTO]jmp +196[TOTO]acc +4[TOTO]acc +45[TOTO]jmp +218[TOTO]acc +38[TOTO]jmp -77[TOTO]acc +10[TOTO]acc +46[TOTO]jmp +385[TOTO]acc +29[TOTO]jmp +159[TOTO]jmp +247[TOTO]jmp +1[TOTO]acc +26[TOTO]nop +357[TOTO]jmp +284[TOTO]nop +335[TOTO]acc -18[TOTO]acc +41[TOTO]jmp +326[TOTO]nop +181[TOTO]jmp +189[TOTO]nop -135[TOTO]acc +50[TOTO]nop +152[TOTO]jmp -53[TOTO]acc +0[TOTO]jmp +1[TOTO]acc +23[TOTO]jmp +167[TOTO]nop +131[TOTO]acc +18[TOTO]acc +42[TOTO]nop +13[TOTO]jmp +28[TOTO]jmp +284[TOTO]acc +10[TOTO]acc +43[TOTO]jmp +243[TOTO]jmp +64[TOTO]acc +17[TOTO]jmp +213[TOTO]acc +0[TOTO]acc +29[TOTO]jmp +25[TOTO]jmp -180[TOTO]nop +184[TOTO]jmp +90[TOTO]jmp -13[TOTO]jmp +1[TOTO]jmp -86[TOTO]jmp +1[TOTO]acc +20[TOTO]acc +49[TOTO]jmp +6[TOTO]jmp +188[TOTO]acc +24[TOTO]acc +0[TOTO]nop -16[TOTO]jmp +160[TOTO]jmp +2[TOTO]jmp +68[TOTO]acc +1[TOTO]acc +30[TOTO]jmp -52[TOTO]acc -19[TOTO]jmp +1[TOTO]acc -18[TOTO]jmp +153[TOTO]acc +0[TOTO]jmp -92[TOTO]nop -72[TOTO]acc +38[TOTO]jmp +13[TOTO]jmp +160[TOTO]acc +24[TOTO]acc +0[TOTO]jmp +111[TOTO]acc -4[TOTO]acc +45[TOTO]jmp -215[TOTO]acc +16[TOTO]acc +25[TOTO]acc +28[TOTO]acc +12[TOTO]jmp +348[TOTO]nop +144[TOTO]jmp -52[TOTO]acc +41[TOTO]jmp +1[TOTO]acc +12[TOTO]acc +14[TOTO]jmp +207[TOTO]jmp +1[TOTO]acc +26[TOTO]acc +4[TOTO]jmp +1[TOTO]jmp +15[TOTO]jmp +20[TOTO]acc +23[TOTO]acc +41[TOTO]jmp -8[TOTO]jmp +284[TOTO]nop +204[TOTO]acc +47[TOTO]acc +35[TOTO]acc +17[TOTO]jmp -58[TOTO]jmp +1[TOTO]acc +8[TOTO]nop +72[TOTO]jmp -210[TOTO]jmp +324[TOTO]acc -7[TOTO]acc +12[TOTO]acc +48[TOTO]acc +1[TOTO]jmp +269[TOTO]acc -19[TOTO]acc +18[TOTO]jmp +167[TOTO]jmp +1[TOTO]acc +48[TOTO]acc +2[TOTO]jmp +134[TOTO]jmp +204[TOTO]jmp +1[TOTO]acc -1[TOTO]jmp +191[TOTO]nop -203[TOTO]nop +104[TOTO]acc -16[TOTO]jmp +261[TOTO]acc +32[TOTO]acc +11[TOTO]acc +37[TOTO]jmp +74[TOTO]acc -16[TOTO]acc -4[TOTO]acc +10[TOTO]jmp +101[TOTO]acc +47[TOTO]acc +18[TOTO]jmp +122[TOTO]acc +42[TOTO]acc +30[TOTO]jmp -47[TOTO]nop -54[TOTO]acc +38[TOTO]nop +237[TOTO]acc +15[TOTO]jmp -58[TOTO]acc +50[TOTO]acc +37[TOTO]acc +20[TOTO]jmp -163[TOTO]nop +49[TOTO]acc +28[TOTO]acc +50[TOTO]acc -13[TOTO]jmp -305[TOTO]jmp +66[TOTO]jmp +92[TOTO]acc +30[TOTO]acc +0[TOTO]jmp -190[TOTO]nop +153[TOTO]acc -12[TOTO]jmp +73[TOTO]nop -241[TOTO]acc +25[TOTO]nop -310[TOTO]jmp +127[TOTO]acc +32[TOTO]acc +6[TOTO]jmp +55[TOTO]jmp -250[TOTO]acc +25[TOTO]acc -2[TOTO]acc +42[TOTO]nop +25[TOTO]jmp -264[TOTO]acc +47[TOTO]acc +47[TOTO]nop -297[TOTO]jmp -146[TOTO]jmp +1[TOTO]jmp -257[TOTO]acc +48[TOTO]acc +49[TOTO]acc -2[TOTO]jmp +232[TOTO]acc +25[TOTO]acc +9[TOTO]acc -6[TOTO]jmp +115[TOTO]jmp +53[TOTO]acc +4[TOTO]acc +19[TOTO]acc -5[TOTO]jmp -188[TOTO]acc +0[TOTO]acc -16[TOTO]jmp +132[TOTO]jmp +189[TOTO]acc -8[TOTO]jmp -54[TOTO]acc -19[TOTO]nop -338[TOTO]jmp -322[TOTO]acc +43[TOTO]acc +19[TOTO]acc +1[TOTO]jmp -238[TOTO]jmp -111[TOTO]acc +48[TOTO]jmp +49[TOTO]nop -225[TOTO]jmp +153[TOTO]jmp +55[TOTO]jmp -264[TOTO]acc +27[TOTO]acc -1[TOTO]acc -1[TOTO]acc +7[TOTO]jmp +208[TOTO]jmp +68[TOTO]jmp -218[TOTO]acc +13[TOTO]jmp +70[TOTO]acc +1[TOTO]jmp +12[TOTO]acc -7[TOTO]jmp +129[TOTO]jmp +1[TOTO]acc +7[TOTO]acc +11[TOTO]acc +2[TOTO]jmp -377[TOTO]acc +0[TOTO]jmp -241[TOTO]jmp +110[TOTO]jmp -355[TOTO]acc -13[TOTO]jmp +1[TOTO]jmp -120[TOTO]nop +83[TOTO]acc +19[TOTO]jmp -378[TOTO]acc +26[TOTO]jmp +72[TOTO]acc +9[TOTO]acc +0[TOTO]jmp -92[TOTO]nop -242[TOTO]jmp -200[TOTO]acc +29[TOTO]jmp -374[TOTO]acc -19[TOTO]acc +40[TOTO]acc +9[TOTO]nop -117[TOTO]jmp -144[TOTO]acc +6[TOTO]jmp +122[TOTO]acc +7[TOTO]acc +9[TOTO]acc +50[TOTO]jmp -367[TOTO]acc +18[TOTO]acc +18[TOTO]acc +6[TOTO]nop -212[TOTO]jmp -19[TOTO]acc +34[TOTO]acc -1[TOTO]jmp +1[TOTO]jmp -89[TOTO]acc -19[TOTO]acc +20[TOTO]jmp -70[TOTO]jmp +117[TOTO]acc +38[TOTO]acc +23[TOTO]acc +29[TOTO]acc +20[TOTO]jmp -330[TOTO]acc +30[TOTO]acc +38[TOTO]nop -2[TOTO]jmp +96[TOTO]acc +11[TOTO]acc +32[TOTO]jmp -194[TOTO]jmp -64[TOTO]acc +10[TOTO]acc -2[TOTO]acc -2[TOTO]jmp -320[TOTO]jmp -314[TOTO]jmp +115[TOTO]acc -1[TOTO]acc +38[TOTO]acc +30[TOTO]jmp -407[TOTO]acc +1[TOTO]jmp -32[TOTO]jmp +55[TOTO]acc +50[TOTO]jmp +84[TOTO]nop -69[TOTO]acc +0[TOTO]nop -270[TOTO]acc +38[TOTO]jmp -33[TOTO]acc +11[TOTO]acc +32[TOTO]acc -15[TOTO]jmp -122[TOTO]jmp -413[TOTO]acc -2[TOTO]jmp -322[TOTO]acc +49[TOTO]jmp +1[TOTO]acc +26[TOTO]nop -455[TOTO]jmp -105[TOTO]acc +26[TOTO]jmp -6[TOTO]nop +42[TOTO]acc +15[TOTO]jmp -149[TOTO]acc -7[TOTO]acc +34[TOTO]jmp +59[TOTO]acc -9[TOTO]acc -11[TOTO]jmp -122[TOTO]nop -89[TOTO]acc +28[TOTO]acc +34[TOTO]acc +14[TOTO]jmp -127[TOTO]jmp -89[TOTO]jmp -335[TOTO]acc +49[TOTO]acc +0[TOTO]acc +43[TOTO]acc +41[TOTO]jmp -314[TOTO]jmp -56[TOTO]acc +11[TOTO]jmp -443[TOTO]acc +7[TOTO]jmp -11[TOTO]acc +24[TOTO]acc +16[TOTO]acc +44[TOTO]jmp -29[TOTO]acc +38[TOTO]acc +8[TOTO]jmp +50[TOTO]acc +30[TOTO]acc +8[TOTO]acc +14[TOTO]jmp -160[TOTO]acc -10[TOTO]acc +46[TOTO]acc +2[TOTO]acc +21[TOTO]jmp -328[TOTO]acc +17[TOTO]acc +23[TOTO]jmp -374[TOTO]acc +20[TOTO]jmp -160[TOTO]acc +1[TOTO]acc +30[TOTO]acc +22[TOTO]jmp +1[TOTO]jmp -302[TOTO]jmp +1[TOTO]acc +3[TOTO]acc +19[TOTO]acc +28[TOTO]jmp +30[TOTO]acc +50[TOTO]acc +23[TOTO]jmp -244[TOTO]acc +20[TOTO]jmp +1[TOTO]acc +27[TOTO]jmp -6[TOTO]jmp -71[TOTO]acc +28[TOTO]acc +35[TOTO]nop -3[TOTO]jmp -62[TOTO]nop -386[TOTO]nop -217[TOTO]jmp -45[TOTO]acc +7[TOTO]acc -11[TOTO]jmp -104[TOTO]nop -279[TOTO]jmp +1[TOTO]acc -15[TOTO]acc -17[TOTO]jmp -478[TOTO]nop -11[TOTO]jmp -432[TOTO]acc -3[TOTO]acc +12[TOTO]jmp -558[TOTO]jmp -513[TOTO]acc +3[TOTO]acc +46[TOTO]jmp -532[TOTO]acc -14[TOTO]acc +32[TOTO]acc -8[TOTO]acc +25[TOTO]jmp -521[TOTO]acc +6[TOTO]acc +11[TOTO]acc +40[TOTO]acc +33[TOTO]jmp -266[TOTO]acc +17[TOTO]acc +11[TOTO]nop -203[TOTO]acc +2[TOTO]jmp -433[TOTO]acc +38[TOTO]jmp -476[TOTO]jmp -125[TOTO]jmp +1[TOTO]acc +24[TOTO]acc -11[TOTO]jmp +1[TOTO]jmp +1";
            //string copyDatas = "nop +0[TOTO]acc +1[TOTO]jmp +4[TOTO]acc +3[TOTO]jmp -3[TOTO]acc -99[TOTO]acc +1[TOTO]jmp -4[TOTO]acc +6";

            var instructions = datas
                .Split("[TOTO]")
                .Select(k => (k.Split(' ')[0], Convert.ToInt32(k.Split(' ')[1].Replace("+", ""))))
                .ToList();

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
                    break;
                }
            }
        }

        private static void DaySeven()
        {
            string content = "posh blue bags contain 5 plaid chartreuse bags, 3 plaid lime bags.clear teal bags contain 2 dotted salmon bags, 2 wavy red bags.faded blue bags contain 1 dotted chartreuse bag, 3 dim bronze bags.plaid black bags contain 5 muted beige bags, 2 pale gold bags, 3 wavy lavender bags, 5 dull yellow bags.bright cyan bags contain 2 vibrant teal bags.clear magenta bags contain 2 dim chartreuse bags.muted crimson bags contain 1 clear violet bag, 5 dark coral bags, 1 pale salmon bag, 3 light red bags.dotted green bags contain 3 muted plum bags.pale crimson bags contain 3 pale maroon bags, 2 mirrored tan bags.shiny black bags contain 1 wavy tomato bag.striped fuchsia bags contain 1 light chartreuse bag, 2 striped turquoise bags, 1 dim blue bag, 1 light teal bag.drab green bags contain 5 dotted tan bags, 3 dotted turquoise bags, 2 clear coral bags, 5 vibrant bronze bags.bright fuchsia bags contain 4 dark turquoise bags.mirrored silver bags contain 1 dotted lavender bag, 5 light black bags, 2 clear beige bags.dark tomato bags contain 3 drab cyan bags, 1 wavy crimson bag.bright crimson bags contain 3 mirrored olive bags, 2 vibrant tan bags, 3 shiny crimson bags.light maroon bags contain 4 bright lime bags, 3 wavy purple bags.faded lavender bags contain 4 striped crimson bags.light white bags contain 3 shiny gray bags, 1 bright gold bag, 1 light yellow bag.posh silver bags contain 1 bright lavender bag, 3 bright chartreuse bags.faded salmon bags contain 3 striped green bags, 3 dull lavender bags, 1 striped maroon bag.drab chartreuse bags contain 2 light plum bags, 2 bright plum bags, 2 pale maroon bags, 1 wavy red bag.bright green bags contain 4 dark magenta bags.striped beige bags contain 1 faded red bag, 2 muted gold bags, 2 shiny tomato bags.muted beige bags contain 1 plaid tan bag.wavy green bags contain 1 clear blue bag, 1 striped gold bag.shiny maroon bags contain 2 muted orange bags, 4 dull beige bags, 2 shiny crimson bags.faded yellow bags contain 1 dull gold bag, 3 bright fuchsia bags, 1 dark black bag.dotted crimson bags contain 5 posh blue bags, 3 drab silver bags, 5 muted turquoise bags, 2 bright indigo bags.light olive bags contain 4 drab tomato bags, 3 drab turquoise bags, 5 plaid fuchsia bags.dark purple bags contain 4 dotted blue bags, 1 drab crimson bag, 3 drab red bags.bright lime bags contain 3 mirrored orange bags, 1 wavy fuchsia bag, 3 muted plum bags.muted yellow bags contain 1 dotted white bag, 2 plaid green bags.clear gold bags contain 5 dark gray bags, 5 dotted tomato bags, 1 mirrored aqua bag.dull olive bags contain 1 vibrant green bag, 3 wavy fuchsia bags, 4 dull orange bags.dull teal bags contain 2 vibrant crimson bags, 5 shiny yellow bags.posh gold bags contain 2 muted yellow bags, 1 posh indigo bag, 4 bright salmon bags.clear crimson bags contain 5 mirrored silver bags, 5 muted red bags.faded indigo bags contain 3 light turquoise bags, 5 faded red bags, 2 wavy crimson bags.bright bronze bags contain 1 bright red bag, 5 bright lime bags, 1 dark green bag.vibrant crimson bags contain 1 wavy teal bag, 2 vibrant brown bags.wavy aqua bags contain 4 mirrored white bags.mirrored white bags contain 4 shiny teal bags, 5 light turquoise bags, 2 faded coral bags.bright gray bags contain 1 muted gold bag, 4 vibrant teal bags.light tomato bags contain 5 plaid bronze bags, 2 light violet bags.wavy tan bags contain 5 dark coral bags, 3 clear beige bags, 2 faded orange bags.muted indigo bags contain 2 wavy fuchsia bags.faded tan bags contain 5 faded violet bags, 4 pale turquoise bags, 4 vibrant bronze bags, 5 dotted lime bags.dotted magenta bags contain 5 bright tomato bags.mirrored cyan bags contain 4 plaid crimson bags.dark beige bags contain 1 clear teal bag.posh orange bags contain 1 posh indigo bag, 1 shiny aqua bag, 4 faded gray bags, 3 dotted lavender bags.pale chartreuse bags contain 4 clear violet bags, 4 clear orange bags.dotted bronze bags contain 3 pale brown bags, 1 plaid turquoise bag, 2 dim fuchsia bags.dim cyan bags contain 2 bright silver bags.light crimson bags contain 4 dim crimson bags.vibrant brown bags contain 5 dark olive bags, 4 pale salmon bags.dim tan bags contain 5 plaid bronze bags, 4 pale magenta bags, 4 dull bronze bags.shiny tomato bags contain no other bags.striped red bags contain 4 vibrant olive bags, 4 posh black bags, 4 bright gold bags, 2 vibrant coral bags.bright magenta bags contain 1 dull tomato bag, 5 bright lime bags, 3 mirrored white bags.posh maroon bags contain 5 plaid bronze bags, 3 bright silver bags, 3 plaid chartreuse bags.vibrant tan bags contain 3 plaid chartreuse bags, 4 striped silver bags.striped lime bags contain 2 dull beige bags, 4 plaid orange bags.wavy turquoise bags contain 1 striped teal bag, 4 dim orange bags, 3 faded silver bags, 1 shiny purple bag.clear coral bags contain 5 pale yellow bags, 1 bright silver bag, 1 clear tan bag.light violet bags contain 1 posh bronze bag.wavy lime bags contain 4 shiny coral bags, 2 faded bronze bags, 2 drab teal bags.dotted white bags contain 5 wavy fuchsia bags.dim blue bags contain 1 drab black bag.drab salmon bags contain 5 dull green bags, 2 mirrored olive bags.clear brown bags contain 5 bright maroon bags, 4 drab teal bags, 4 clear bronze bags.light turquoise bags contain 3 shiny aqua bags, 1 muted red bag, 2 wavy teal bags.plaid crimson bags contain 3 striped tomato bags, 3 plaid chartreuse bags, 4 light green bags.muted purple bags contain 5 drab plum bags, 5 drab salmon bags, 1 vibrant tan bag.pale lime bags contain 3 faded indigo bags, 5 dark indigo bags, 4 dull blue bags, 1 faded lavender bag.striped orange bags contain 1 vibrant red bag, 1 mirrored olive bag, 5 shiny blue bags, 3 bright tomato bags.posh purple bags contain 3 pale brown bags, 5 plaid turquoise bags, 4 dull aqua bags, 5 faded lavender bags.vibrant lavender bags contain 2 vibrant maroon bags, 4 muted olive bags, 3 clear coral bags.wavy purple bags contain 3 muted gold bags, 3 posh lime bags.dull crimson bags contain 4 drab violet bags, 5 wavy teal bags, 4 pale indigo bags, 1 pale white bag.posh plum bags contain 2 muted black bags, 2 clear maroon bags, 3 dotted red bags.dull tan bags contain 3 bright lavender bags, 1 dull green bag, 2 wavy teal bags, 5 plaid bronze bags.pale tan bags contain 4 pale fuchsia bags, 3 drab purple bags.pale red bags contain 4 vibrant bronze bags.striped turquoise bags contain 5 faded brown bags.clear cyan bags contain 4 bright bronze bags, 5 mirrored purple bags.dotted maroon bags contain 4 plaid silver bags, 4 plaid yellow bags, 1 dark chartreuse bag, 1 striped bronze bag.bright lavender bags contain 4 mirrored black bags, 5 shiny bronze bags, 2 wavy crimson bags.clear fuchsia bags contain 2 drab black bags, 3 faded yellow bags.dotted lime bags contain 5 striped purple bags.mirrored beige bags contain 3 dim fuchsia bags.posh lime bags contain 2 shiny tomato bags, 1 dark brown bag, 1 bright tomato bag, 5 pale salmon bags.bright maroon bags contain 5 clear violet bags, 1 clear orange bag, 5 mirrored olive bags.light lavender bags contain 5 muted purple bags, 5 shiny aqua bags, 2 plaid crimson bags, 1 muted white bag.wavy coral bags contain 5 bright maroon bags.striped green bags contain 4 pale salmon bags, 5 mirrored olive bags, 3 dark coral bags, 2 plaid white bags.vibrant cyan bags contain 4 dotted green bags, 4 bright tomato bags, 4 light fuchsia bags, 2 faded bronze bags.shiny magenta bags contain 3 mirrored lavender bags, 4 bright tomato bags, 2 dark brown bags, 5 vibrant black bags.shiny olive bags contain 1 shiny magenta bag, 2 dim olive bags.posh chartreuse bags contain 3 muted black bags, 2 posh yellow bags.dull red bags contain 5 mirrored beige bags, 2 dotted bronze bags, 2 dim brown bags, 5 dotted tan bags.dull cyan bags contain 1 faded bronze bag, 4 shiny plum bags, 2 dim olive bags, 3 faded olive bags.pale plum bags contain 1 dotted black bag.mirrored black bags contain 5 shiny bronze bags, 2 drab lime bags, 1 faded red bag, 2 mirrored orange bags.mirrored chartreuse bags contain 4 dotted plum bags.faded bronze bags contain 1 pale bronze bag, 5 bright chartreuse bags, 3 plaid green bags, 4 drab lime bags.muted olive bags contain 2 mirrored tan bags.clear red bags contain 4 dull fuchsia bags.plaid magenta bags contain 4 striped gray bags, 5 dim cyan bags.dark salmon bags contain 3 mirrored gray bags, 2 muted black bags.plaid coral bags contain 3 mirrored indigo bags, 5 dotted fuchsia bags, 5 pale black bags, 2 faded crimson bags.dull purple bags contain 1 drab gold bag, 3 plaid tan bags, 5 posh indigo bags.striped white bags contain 5 plaid purple bags, 5 dark coral bags, 4 dull beige bags, 5 posh bronze bags.bright silver bags contain 3 pale brown bags, 4 light black bags.dark bronze bags contain 4 wavy crimson bags, 4 wavy tan bags, 3 vibrant teal bags.wavy blue bags contain 2 clear coral bags.striped teal bags contain 2 striped bronze bags, 4 striped crimson bags.dull bronze bags contain 4 striped bronze bags, 4 dim lavender bags.posh salmon bags contain 4 faded bronze bags, 3 wavy crimson bags, 5 plaid tan bags.drab orange bags contain 1 wavy yellow bag, 4 dull bronze bags, 5 dull chartreuse bags.drab cyan bags contain 1 dark lime bag, 4 faded tomato bags, 3 pale brown bags, 2 posh bronze bags.faded magenta bags contain 1 shiny coral bag, 2 faded silver bags, 2 bright silver bags.dark green bags contain 5 pale aqua bags, 5 muted olive bags, 4 mirrored salmon bags, 1 light magenta bag.plaid blue bags contain 5 drab lavender bags, 2 dull aqua bags.wavy cyan bags contain 4 posh gold bags, 4 light teal bags.dull black bags contain 5 drab silver bags, 5 light cyan bags, 4 dim brown bags, 3 wavy teal bags.faded black bags contain 2 plaid magenta bags, 4 light chartreuse bags, 5 wavy gold bags.dim silver bags contain 4 wavy crimson bags, 3 clear bronze bags, 3 mirrored white bags.light coral bags contain 2 plaid gray bags, 3 vibrant violet bags, 3 dim fuchsia bags, 1 drab magenta bag.pale beige bags contain 3 dim teal bags, 1 light beige bag.bright indigo bags contain 4 posh fuchsia bags, 1 posh red bag.dotted fuchsia bags contain 4 muted black bags, 3 posh turquoise bags, 1 plaid tan bag, 2 light silver bags.dotted tan bags contain 3 drab tomato bags.light silver bags contain 4 pale brown bags, 1 mirrored orange bag.muted silver bags contain 2 wavy fuchsia bags, 2 shiny bronze bags, 5 dark olive bags.dim beige bags contain 1 light white bag, 2 mirrored gold bags, 2 dull gold bags.faded cyan bags contain 5 clear gray bags, 5 posh orange bags, 2 posh violet bags, 4 clear chartreuse bags.muted salmon bags contain 3 drab plum bags.dark turquoise bags contain 1 bright tomato bag, 2 plaid green bags, 3 muted turquoise bags.shiny green bags contain 3 dotted salmon bags, 4 faded olive bags, 1 dim maroon bag, 4 muted lavender bags.shiny beige bags contain 1 drab salmon bag, 4 dull green bags, 5 clear red bags, 4 muted brown bags.pale brown bags contain 5 striped green bags.posh tan bags contain 3 bright yellow bags.shiny gray bags contain 4 faded orange bags, 5 wavy aqua bags.light aqua bags contain 4 dotted white bags, 2 dotted black bags.dim yellow bags contain 5 wavy lime bags, 2 faded maroon bags, 5 wavy teal bags.striped bronze bags contain 4 shiny orange bags, 1 mirrored beige bag, 1 wavy maroon bag.striped tan bags contain 4 light plum bags.dim lime bags contain 1 wavy coral bag, 4 light plum bags, 5 posh tan bags, 2 dark black bags.dotted aqua bags contain 1 shiny teal bag.shiny brown bags contain 3 plaid yellow bags, 3 vibrant indigo bags, 1 muted tan bag, 2 shiny tomato bags.drab yellow bags contain 1 drab lime bag, 4 dull beige bags, 3 plaid gray bags.striped tomato bags contain 5 shiny gold bags.bright olive bags contain 5 dotted red bags, 2 wavy green bags, 4 drab magenta bags.mirrored bronze bags contain 4 drab cyan bags, 2 light chartreuse bags, 1 shiny yellow bag.wavy gold bags contain 5 pale yellow bags, 1 bright aqua bag, 5 striped crimson bags.wavy silver bags contain 4 plaid green bags.clear yellow bags contain 2 plaid yellow bags, 4 shiny gold bags, 2 drab magenta bags, 2 bright red bags.dark gold bags contain 5 mirrored cyan bags, 4 striped beige bags, 4 mirrored olive bags, 5 muted gold bags.vibrant bronze bags contain 3 clear orange bags.bright purple bags contain 2 bright lime bags, 1 mirrored turquoise bag.dull coral bags contain 3 striped tomato bags.bright coral bags contain 5 dark lime bags, 4 posh violet bags, 3 drab chartreuse bags, 3 dull blue bags.dark magenta bags contain 4 pale brown bags.light teal bags contain 3 striped purple bags.striped lavender bags contain 3 plaid tomato bags, 1 dark tomato bag, 3 mirrored black bags, 4 vibrant bronze bags.light red bags contain 5 dark brown bags.dull violet bags contain 3 bright indigo bags, 4 plaid tan bags, 4 faded lime bags, 3 muted aqua bags.wavy crimson bags contain 4 mirrored olive bags, 1 bright tomato bag, 5 striped silver bags, 1 dark salmon bag.faded tomato bags contain 3 bright silver bags.shiny fuchsia bags contain 2 drab crimson bags.faded crimson bags contain 3 bright lavender bags, 4 bright salmon bags, 4 pale aqua bags.dotted blue bags contain 3 shiny chartreuse bags.dull turquoise bags contain 2 shiny bronze bags, 2 striped green bags, 5 posh bronze bags.vibrant salmon bags contain 2 dim cyan bags, 3 dim bronze bags, 5 bright lavender bags.striped crimson bags contain 4 dull beige bags, 2 posh orange bags.pale yellow bags contain 2 mirrored black bags, 1 muted silver bag, 2 pale tomato bags, 2 muted plum bags.mirrored indigo bags contain 4 drab olive bags, 4 dull beige bags.posh lavender bags contain 4 vibrant olive bags, 2 clear red bags.pale lavender bags contain 3 light red bags, 5 dim chartreuse bags, 5 dull green bags.muted lavender bags contain 2 bright maroon bags.mirrored blue bags contain 4 posh bronze bags.dark violet bags contain 4 bright red bags, 4 mirrored yellow bags, 5 clear gray bags, 3 dark brown bags.dim tomato bags contain 5 muted crimson bags, 1 dim blue bag, 1 bright crimson bag, 5 shiny lime bags.faded silver bags contain 1 mirrored black bag, 2 muted indigo bags, 4 striped purple bags, 5 vibrant black bags.dull gold bags contain 5 striped white bags, 2 bright beige bags.dull chartreuse bags contain 1 shiny magenta bag, 5 bright lavender bags, 5 faded maroon bags, 5 shiny orange bags.plaid tan bags contain 1 shiny maroon bag, 1 pale white bag, 3 dark lime bags.posh tomato bags contain 4 faded coral bags, 2 dull chartreuse bags, 4 shiny teal bags, 3 light beige bags.vibrant blue bags contain 4 dark teal bags, 4 posh teal bags.plaid bronze bags contain 5 posh lime bags, 1 dark coral bag, 4 faded red bags.light purple bags contain 5 dim crimson bags.vibrant lime bags contain 1 pale turquoise bag, 5 muted turquoise bags.muted orange bags contain 3 dark fuchsia bags.dim white bags contain 1 muted teal bag, 3 dark white bags, 4 light cyan bags.vibrant purple bags contain 4 vibrant red bags, 4 posh gold bags, 1 vibrant crimson bag, 2 muted plum bags.plaid plum bags contain 1 light plum bag, 4 vibrant orange bags.clear plum bags contain 3 clear yellow bags, 3 faded silver bags, 1 vibrant red bag, 3 wavy lavender bags.striped gray bags contain 4 wavy chartreuse bags, 1 clear crimson bag, 3 striped beige bags.faded gold bags contain 4 vibrant yellow bags, 5 dotted indigo bags.faded maroon bags contain 3 drab lime bags, 5 plaid gray bags, 2 muted silver bags, 2 vibrant crimson bags.bright salmon bags contain 1 dim teal bag, 2 plaid green bags.vibrant orange bags contain 4 muted olive bags.pale coral bags contain 4 muted aqua bags, 3 bright indigo bags, 4 dim cyan bags.drab gray bags contain 4 posh blue bags, 5 shiny crimson bags.muted coral bags contain 5 plaid gray bags, 4 wavy teal bags, 3 muted turquoise bags.clear maroon bags contain 3 vibrant violet bags.drab violet bags contain 3 posh orange bags, 1 mirrored orange bag.dotted plum bags contain 4 plaid yellow bags, 4 posh lime bags.shiny violet bags contain 3 faded indigo bags, 3 muted tan bags.plaid gray bags contain 2 light beige bags, 3 shiny bronze bags.dotted cyan bags contain 1 wavy maroon bag, 1 dull coral bag.wavy beige bags contain 2 bright maroon bags, 4 posh teal bags, 2 shiny gold bags, 3 pale purple bags.muted gold bags contain 5 striped gold bags, 3 posh bronze bags.mirrored crimson bags contain 4 dull teal bags, 4 plaid gray bags.wavy olive bags contain 4 dark tan bags.dim orange bags contain 4 vibrant magenta bags, 3 plaid teal bags.mirrored orange bags contain 4 shiny tomato bags, 4 wavy fuchsia bags, 5 faded red bags.drab crimson bags contain 2 vibrant crimson bags, 2 clear gray bags.striped aqua bags contain 2 drab silver bags, 5 vibrant fuchsia bags.vibrant indigo bags contain 4 muted maroon bags.posh indigo bags contain 5 clear violet bags, 5 bright lime bags.drab plum bags contain 3 pale yellow bags, 4 faded orange bags, 5 muted brown bags.mirrored fuchsia bags contain 3 faded olive bags, 4 dull black bags, 1 plaid cyan bag, 2 dotted fuchsia bags.drab aqua bags contain 1 wavy blue bag, 2 plaid orange bags, 4 faded lavender bags.dim crimson bags contain 2 light brown bags.faded white bags contain 3 wavy purple bags, 1 clear yellow bag.dim plum bags contain 1 dotted plum bag.dim indigo bags contain 5 wavy purple bags, 3 plaid green bags.dim maroon bags contain 1 dim cyan bag, 1 vibrant olive bag, 4 muted tomato bags, 1 vibrant brown bag.shiny salmon bags contain 1 muted yellow bag, 2 clear silver bags.posh violet bags contain 1 posh fuchsia bag, 4 bright red bags, 2 plaid maroon bags, 2 bright beige bags.light gold bags contain 2 plaid olive bags.dotted teal bags contain 3 drab teal bags, 4 bright gold bags, 2 clear lavender bags.dark white bags contain 2 wavy red bags, 5 posh orange bags.muted black bags contain 5 dark coral bags.dim red bags contain 4 muted blue bags.plaid fuchsia bags contain 2 striped white bags.clear blue bags contain 1 dim yellow bag, 3 faded indigo bags, 5 clear tan bags, 2 clear crimson bags.clear salmon bags contain 3 dark indigo bags.faded red bags contain no other bags.striped maroon bags contain 2 muted blue bags, 3 dark olive bags, 5 striped white bags.vibrant gold bags contain 5 muted crimson bags, 5 clear magenta bags, 5 faded indigo bags, 5 vibrant coral bags.wavy red bags contain 2 striped beige bags.pale indigo bags contain 3 striped bronze bags, 3 pale blue bags.muted bronze bags contain 4 bright crimson bags, 4 muted orange bags, 4 wavy red bags.drab red bags contain 4 vibrant brown bags, 3 faded red bags, 4 mirrored olive bags.dark silver bags contain 4 dull chartreuse bags.dim olive bags contain 3 plaid white bags.plaid olive bags contain 4 mirrored gray bags.vibrant silver bags contain 4 wavy maroon bags, 1 bright gold bag.dim teal bags contain 5 mirrored red bags.vibrant fuchsia bags contain 3 plaid lime bags, 3 shiny orange bags.vibrant aqua bags contain 5 wavy white bags, 2 muted lavender bags, 1 posh gold bag.striped olive bags contain 5 bright bronze bags, 4 shiny chartreuse bags.clear purple bags contain 3 dark turquoise bags, 1 drab yellow bag, 2 light gray bags.posh green bags contain 4 dotted tomato bags.faded fuchsia bags contain 4 plaid tan bags, 2 wavy teal bags, 4 shiny gold bags.shiny chartreuse bags contain 3 dark olive bags, 5 dim lavender bags, 5 dotted white bags.plaid teal bags contain 3 vibrant crimson bags, 4 clear orange bags, 5 plaid turquoise bags.drab brown bags contain 1 striped silver bag, 1 wavy lime bag, 4 dotted white bags.plaid indigo bags contain 3 posh gray bags, 3 dotted turquoise bags, 5 dotted tomato bags.vibrant yellow bags contain 1 faded beige bag, 2 vibrant red bags.posh white bags contain 2 posh yellow bags, 2 drab turquoise bags.posh yellow bags contain 5 clear plum bags.dotted orange bags contain 1 bright crimson bag, 5 mirrored turquoise bags, 2 light plum bags, 4 dim turquoise bags.dull green bags contain 2 vibrant teal bags, 4 muted turquoise bags, 2 plaid white bags.striped chartreuse bags contain 3 light violet bags, 4 pale brown bags, 2 light olive bags, 3 muted red bags.dark crimson bags contain 3 dim magenta bags, 2 pale olive bags, 2 vibrant silver bags, 4 posh gold bags.muted violet bags contain 3 dim white bags, 4 muted orange bags.muted blue bags contain 2 shiny orange bags, 4 clear violet bags, 1 shiny bronze bag.clear tan bags contain 4 muted plum bags, 4 dark fuchsia bags, 4 muted indigo bags.pale turquoise bags contain 5 shiny bronze bags.striped indigo bags contain 5 faded fuchsia bags, 5 dotted bronze bags, 2 striped green bags, 2 faded coral bags.shiny lavender bags contain 3 shiny gold bags, 2 shiny magenta bags.clear lime bags contain 2 dotted salmon bags, 2 dull lime bags, 2 dark green bags, 1 dim black bag.dull fuchsia bags contain 4 dark fuchsia bags.faded beige bags contain 4 mirrored blue bags, 1 wavy crimson bag, 5 vibrant red bags, 1 drab teal bag.posh olive bags contain 1 muted blue bag, 4 muted yellow bags, 3 clear bronze bags, 4 dim fuchsia bags.pale gray bags contain 5 shiny plum bags, 2 striped green bags, 3 dark coral bags, 5 striped crimson bags.clear aqua bags contain 2 posh gray bags, 3 shiny red bags, 4 posh turquoise bags.dim turquoise bags contain 1 dull yellow bag.plaid cyan bags contain 2 mirrored cyan bags.muted gray bags contain 3 faded olive bags, 1 faded bronze bag.dotted violet bags contain 1 clear plum bag, 1 dark aqua bag.drab turquoise bags contain 5 bright gray bags, 3 shiny maroon bags, 3 dull aqua bags.dull white bags contain 2 shiny maroon bags, 2 dim olive bags, 5 dull turquoise bags.faded turquoise bags contain 1 plaid lime bag.posh bronze bags contain no other bags.dotted brown bags contain 4 dark black bags, 5 plaid gray bags.dotted gold bags contain 5 striped plum bags, 4 dim salmon bags, 4 light black bags, 3 striped indigo bags.dark plum bags contain 5 dim turquoise bags.mirrored violet bags contain 5 clear plum bags, 3 striped orange bags, 4 dull green bags, 3 light beige bags.clear gray bags contain 3 striped silver bags, 1 muted turquoise bag.mirrored maroon bags contain 4 dark olive bags.posh beige bags contain 2 muted beige bags, 4 drab tomato bags.muted maroon bags contain 1 clear violet bag.mirrored coral bags contain 2 dark turquoise bags, 4 bright fuchsia bags, 5 vibrant black bags, 3 striped cyan bags.drab bronze bags contain 5 dim tan bags, 2 light violet bags, 3 bright tan bags, 3 bright aqua bags.dull yellow bags contain 3 pale yellow bags, 5 bright maroon bags, 3 striped tomato bags, 4 muted brown bags.bright brown bags contain 5 dark bronze bags.muted lime bags contain 5 clear violet bags.dim brown bags contain 5 plaid olive bags.vibrant chartreuse bags contain 2 posh red bags, 1 faded lime bag, 4 wavy beige bags.faded orange bags contain 4 shiny magenta bags, 5 bright silver bags, 3 dull coral bags.dim lavender bags contain 3 dark brown bags, 3 faded indigo bags, 1 vibrant tan bag.dark olive bags contain 3 pale salmon bags, 5 posh bronze bags.bright red bags contain 2 clear gray bags.muted fuchsia bags contain 2 pale red bags, 4 dotted blue bags, 1 dim olive bag, 4 pale salmon bags.mirrored red bags contain 4 vibrant crimson bags, 4 wavy teal bags, 2 faded gray bags, 2 dark brown bags.pale aqua bags contain 2 dim lavender bags, 5 dim teal bags, 2 faded coral bags.light lime bags contain 2 plaid beige bags, 2 wavy lime bags, 2 mirrored aqua bags, 4 muted turquoise bags.shiny turquoise bags contain 2 dotted lavender bags, 3 vibrant tan bags, 5 light black bags.plaid salmon bags contain 3 dotted purple bags, 2 pale lavender bags, 3 wavy gold bags, 1 clear crimson bag.light black bags contain 1 muted silver bag, 3 pale bronze bags, 3 pale salmon bags.striped brown bags contain 3 bright magenta bags, 5 faded orange bags, 5 wavy beige bags, 2 plaid orange bags.pale green bags contain 4 mirrored beige bags, 5 faded indigo bags, 5 pale tomato bags.clear olive bags contain 4 wavy purple bags, 5 pale olive bags.plaid tomato bags contain 1 dotted green bag.pale tomato bags contain 5 light red bags, 1 bright maroon bag, 2 striped green bags, 3 plaid turquoise bags.wavy lavender bags contain 3 dark brown bags.dotted turquoise bags contain 2 vibrant fuchsia bags, 3 posh gold bags, 1 mirrored olive bag, 2 bright salmon bags.mirrored magenta bags contain 3 muted black bags, 1 dim chartreuse bag, 1 dim fuchsia bag, 1 light turquoise bag.pale black bags contain 1 pale tomato bag.shiny cyan bags contain 3 vibrant coral bags, 3 shiny bronze bags, 5 muted green bags.faded chartreuse bags contain 1 plaid olive bag, 1 dim plum bag.mirrored teal bags contain 2 dark maroon bags, 1 bright beige bag, 1 bright tan bag, 2 light violet bags.striped gold bags contain 5 clear violet bags, 3 muted turquoise bags.light salmon bags contain 2 faded brown bags, 5 pale lavender bags, 2 vibrant lime bags.dark brown bags contain 5 muted turquoise bags, 3 plaid white bags.shiny tan bags contain 1 light cyan bag, 2 wavy red bags, 4 dull purple bags.dull tomato bags contain 4 dotted lavender bags, 5 muted green bags, 1 dull green bag.plaid maroon bags contain 4 bright plum bags, 1 muted maroon bag, 3 striped purple bags, 3 posh gray bags.striped blue bags contain 4 pale magenta bags, 2 plaid lime bags.dotted indigo bags contain 1 bright fuchsia bag.drab teal bags contain 2 dark brown bags, 3 muted blue bags.clear lavender bags contain 3 posh gray bags, 1 plaid purple bag, 2 mirrored violet bags, 4 dull lime bags.pale fuchsia bags contain 4 dark silver bags, 5 clear yellow bags, 4 light black bags.faded green bags contain 3 dull crimson bags, 4 dotted indigo bags, 3 dull maroon bags, 4 muted blue bags.clear white bags contain 4 drab crimson bags, 3 shiny crimson bags, 1 vibrant indigo bag, 1 light turquoise bag.bright aqua bags contain 4 dotted bronze bags, 3 posh gold bags, 4 pale beige bags, 5 clear violet bags.pale gold bags contain 5 wavy red bags.mirrored yellow bags contain 1 bright white bag, 4 faded gray bags, 3 dark turquoise bags, 2 clear gray bags.drab black bags contain 3 vibrant green bags.plaid purple bags contain 1 dark salmon bag, 4 light red bags.drab gold bags contain 3 dark fuchsia bags.drab fuchsia bags contain 1 shiny bronze bag, 3 mirrored lime bags.clear black bags contain 1 faded coral bag, 4 dull tan bags.faded purple bags contain 2 clear magenta bags.bright yellow bags contain 2 shiny yellow bags, 4 striped plum bags, 1 mirrored silver bag, 1 plaid aqua bag.pale maroon bags contain 4 clear bronze bags.dull plum bags contain 5 pale beige bags, 2 pale olive bags, 5 dark turquoise bags, 1 dull gold bag.mirrored turquoise bags contain 1 dark lime bag.bright orange bags contain 2 pale green bags, 4 plaid white bags, 3 muted green bags.plaid red bags contain 1 dotted turquoise bag, 3 dark white bags.pale bronze bags contain 3 posh lime bags, 3 clear beige bags, 3 striped gold bags.vibrant coral bags contain 1 striped green bag, 4 muted crimson bags, 2 vibrant brown bags.plaid orange bags contain 5 faded bronze bags.posh brown bags contain 4 muted aqua bags, 3 dull lavender bags, 2 mirrored gold bags, 1 light brown bag.light blue bags contain 4 wavy teal bags, 1 posh turquoise bag.faded olive bags contain 3 drab silver bags, 1 drab green bag.posh coral bags contain 2 shiny crimson bags.mirrored lavender bags contain 1 wavy teal bag, 5 dull lime bags, 5 plaid turquoise bags, 5 pale brown bags.dark blue bags contain 4 mirrored silver bags, 5 vibrant black bags, 2 pale orange bags.dotted purple bags contain 3 posh fuchsia bags, 4 wavy beige bags.light yellow bags contain 3 pale magenta bags.posh aqua bags contain 2 muted white bags, 2 muted beige bags, 4 striped orange bags.clear turquoise bags contain 5 drab plum bags.mirrored plum bags contain 1 faded gray bag, 4 dim brown bags, 2 bright violet bags, 5 bright beige bags.bright tan bags contain 1 posh salmon bag, 3 dotted red bags, 1 vibrant red bag.bright plum bags contain 3 pale chartreuse bags, 4 plaid bronze bags, 4 faded gray bags, 1 muted tomato bag.light indigo bags contain 5 dull beige bags, 1 striped chartreuse bag, 5 vibrant coral bags, 2 pale turquoise bags.dull aqua bags contain 4 drab indigo bags, 5 vibrant black bags.dull brown bags contain 1 dotted black bag, 1 clear olive bag, 3 dull aqua bags, 1 drab magenta bag.plaid white bags contain no other bags.mirrored olive bags contain no other bags.mirrored green bags contain 3 clear teal bags, 4 clear magenta bags, 1 pale crimson bag.muted tomato bags contain 1 light magenta bag, 1 pale brown bag.muted white bags contain 5 striped teal bags, 2 drab brown bags.dark indigo bags contain 1 bright silver bag, 5 bright gold bags, 2 bright maroon bags.dark fuchsia bags contain 2 plaid white bags, 3 vibrant brown bags, 2 plaid gray bags.striped cyan bags contain 2 dim chartreuse bags, 3 mirrored silver bags, 3 dim cyan bags.bright violet bags contain 2 dim teal bags, 5 vibrant purple bags, 1 bright black bag.plaid aqua bags contain 3 light chartreuse bags.faded aqua bags contain 4 wavy crimson bags, 1 pale brown bag, 2 posh silver bags.muted chartreuse bags contain 3 shiny purple bags, 1 drab tomato bag.plaid chartreuse bags contain 1 muted indigo bag, 5 bright maroon bags, 4 faded maroon bags.wavy magenta bags contain 4 light white bags.dim violet bags contain 5 drab red bags, 5 muted plum bags, 4 striped crimson bags.dark maroon bags contain 5 light teal bags, 4 drab tan bags, 5 light aqua bags, 3 dim maroon bags.faded coral bags contain 2 muted crimson bags.mirrored lime bags contain 3 posh orange bags, 5 plaid yellow bags, 1 vibrant olive bag, 1 bright lime bag.shiny yellow bags contain 2 vibrant gold bags, 2 muted orange bags, 4 wavy salmon bags.bright gold bags contain 1 clear gray bag, 4 posh teal bags, 2 vibrant coral bags, 3 dotted salmon bags.plaid lime bags contain 4 plaid green bags, 1 bright maroon bag.mirrored aqua bags contain 4 striped gray bags, 3 vibrant olive bags, 2 dotted tan bags, 5 shiny lime bags.light green bags contain 3 dim lavender bags.muted turquoise bags contain no other bags.muted aqua bags contain 2 faded purple bags, 2 clear chartreuse bags, 5 posh teal bags, 4 plaid orange bags.drab tomato bags contain 5 mirrored olive bags, 1 muted turquoise bag, 1 striped silver bag.drab tan bags contain 5 shiny purple bags.vibrant turquoise bags contain 2 posh beige bags.striped coral bags contain 3 striped plum bags, 2 mirrored chartreuse bags, 4 pale lavender bags.mirrored brown bags contain 1 plaid salmon bag, 3 mirrored red bags.clear bronze bags contain 4 dull turquoise bags, 1 wavy teal bag, 1 dull green bag.striped silver bags contain 3 muted crimson bags, 5 clear orange bags.dim gold bags contain 2 striped orange bags, 1 bright violet bag.shiny blue bags contain 4 pale magenta bags, 4 drab lime bags.clear orange bags contain no other bags.wavy indigo bags contain 4 faded olive bags, 3 dotted crimson bags, 2 clear black bags.drab beige bags contain 3 mirrored salmon bags, 4 bright lavender bags.dotted yellow bags contain 4 mirrored brown bags, 4 faded red bags, 4 dotted gray bags, 3 plaid gray bags.striped purple bags contain 4 vibrant teal bags, 3 dark fuchsia bags, 3 bright chartreuse bags, 3 dull green bags.plaid gold bags contain 4 shiny aqua bags, 1 wavy tomato bag, 1 faded yellow bag.dim bronze bags contain 5 dark coral bags, 5 shiny beige bags, 5 posh indigo bags.drab lime bags contain 4 plaid green bags, 1 dark salmon bag.vibrant magenta bags contain 2 shiny magenta bags, 5 shiny yellow bags, 1 vibrant indigo bag.shiny purple bags contain 1 wavy teal bag.pale purple bags contain 1 mirrored silver bag, 2 clear beige bags.pale magenta bags contain 2 mirrored silver bags, 1 shiny gold bag, 3 dotted tomato bags, 4 dotted lavender bags.plaid turquoise bags contain 5 faded bronze bags, 1 striped gold bag, 3 dark salmon bags.dotted chartreuse bags contain 1 mirrored orange bag, 4 pale turquoise bags, 3 muted beige bags.striped black bags contain 5 dull beige bags, 2 clear red bags.wavy violet bags contain 3 bright plum bags, 5 dim maroon bags.dark aqua bags contain 5 shiny cyan bags, 4 vibrant bronze bags.shiny plum bags contain 3 dotted lavender bags, 1 clear red bag, 3 pale yellow bags, 2 muted crimson bags.posh fuchsia bags contain 1 striped tomato bag, 1 dull tan bag, 4 dark turquoise bags, 4 muted maroon bags.dark tan bags contain 1 drab salmon bag, 1 muted cyan bag.light fuchsia bags contain 4 dim red bags, 1 light silver bag.pale blue bags contain 3 light beige bags, 1 dotted lavender bag, 4 pale tomato bags, 3 striped white bags.plaid brown bags contain 4 bright violet bags, 1 light green bag, 4 striped lime bags.shiny white bags contain 4 clear silver bags.dark teal bags contain 3 muted gold bags.faded lime bags contain 5 mirrored plum bags, 2 faded red bags, 4 dull orange bags.mirrored salmon bags contain 3 muted turquoise bags, 1 dark salmon bag.bright chartreuse bags contain 2 muted red bags, 5 muted maroon bags, 1 vibrant brown bag, 4 dark coral bags.dotted black bags contain 1 striped white bag, 5 dull tan bags.dull maroon bags contain 1 faded maroon bag, 1 posh silver bag, 2 dotted turquoise bags.wavy bronze bags contain 2 dim indigo bags, 1 mirrored beige bag.wavy chartreuse bags contain 4 faded silver bags, 4 mirrored olive bags.vibrant red bags contain 4 shiny tomato bags, 5 mirrored gray bags, 2 plaid gray bags.dull lavender bags contain 2 muted lavender bags.shiny red bags contain 2 faded magenta bags.muted cyan bags contain 1 plaid bronze bag.drab white bags contain 5 light turquoise bags, 1 striped coral bag, 3 wavy teal bags.bright black bags contain 1 wavy fuchsia bag, 3 drab yellow bags.shiny aqua bags contain 4 mirrored orange bags, 3 wavy fuchsia bags.pale violet bags contain 3 dim fuchsia bags, 4 vibrant violet bags.wavy brown bags contain 4 dark violet bags.wavy plum bags contain 4 dark black bags, 2 light orange bags, 1 posh purple bag.shiny indigo bags contain 3 dull yellow bags, 1 striped lime bag, 3 striped purple bags.dark chartreuse bags contain 3 dark turquoise bags, 5 dark gold bags, 2 wavy purple bags, 4 dim gray bags.dull magenta bags contain 2 mirrored plum bags, 3 wavy lime bags.shiny orange bags contain no other bags.wavy tomato bags contain 3 light silver bags, 5 pale red bags, 1 shiny aqua bag.light gray bags contain 2 dark teal bags, 1 posh lime bag, 2 clear fuchsia bags.light chartreuse bags contain 1 muted silver bag.shiny coral bags contain 1 mirrored black bag, 5 muted silver bags.drab magenta bags contain 2 mirrored orange bags, 5 dark turquoise bags, 2 vibrant teal bags, 3 striped gold bags.dull beige bags contain 2 muted turquoise bags, 5 pale bronze bags, 2 plaid white bags, 2 dotted lavender bags.plaid beige bags contain 1 bright chartreuse bag, 1 vibrant red bag.dark orange bags contain 2 clear lavender bags, 1 dark gray bag, 4 plaid chartreuse bags, 3 plaid red bags.light magenta bags contain 1 plaid gray bag, 1 mirrored gray bag, 3 dark brown bags, 3 faded gray bags.posh magenta bags contain 4 clear green bags.bright tomato bags contain 1 dark brown bag.wavy gray bags contain 2 posh teal bags, 2 clear orange bags, 3 dim chartreuse bags, 2 drab lime bags.bright blue bags contain 2 wavy maroon bags, 2 pale red bags, 4 dotted tan bags.drab olive bags contain 4 vibrant black bags.muted red bags contain 4 muted plum bags.dull orange bags contain 4 shiny bronze bags, 1 shiny tomato bag, 3 pale yellow bags, 4 dotted plum bags.posh crimson bags contain 4 muted salmon bags, 2 pale aqua bags, 1 posh gold bag.plaid lavender bags contain 4 drab gray bags, 3 faded violet bags.muted tan bags contain 4 muted coral bags, 1 dull gray bag, 5 clear coral bags.muted plum bags contain 2 shiny orange bags, 2 shiny bronze bags, 5 bright tomato bags.pale silver bags contain 1 muted tomato bag, 5 dim coral bags, 3 posh black bags.pale white bags contain 1 mirrored lavender bag, 2 pale tomato bags.dull gray bags contain 2 plaid olive bags, 4 clear chartreuse bags.clear tomato bags contain 5 shiny purple bags.dotted gray bags contain 4 dim tan bags.vibrant olive bags contain 4 bright silver bags, 4 plaid gray bags, 4 muted yellow bags, 1 plaid white bag.posh black bags contain 1 striped purple bag.vibrant plum bags contain 5 pale tomato bags, 5 dotted beige bags, 1 drab plum bag, 5 faded maroon bags.mirrored gold bags contain 1 wavy lavender bag.wavy salmon bags contain 2 faded maroon bags, 2 shiny red bags, 4 plaid purple bags, 3 vibrant fuchsia bags.dim salmon bags contain 2 clear coral bags, 4 dim brown bags.muted green bags contain 1 pale magenta bag, 5 mirrored orange bags.dull silver bags contain 3 dark chartreuse bags, 5 bright violet bags, 5 dull cyan bags.drab purple bags contain 3 vibrant red bags.wavy yellow bags contain 3 muted cyan bags, 2 vibrant black bags, 1 posh olive bag.drab silver bags contain 3 drab plum bags, 1 drab cyan bag.clear beige bags contain 4 clear violet bags, 1 muted blue bag, 3 mirrored orange bags.posh red bags contain 4 wavy teal bags, 3 dotted salmon bags.vibrant violet bags contain 1 light green bag, 2 striped crimson bags.pale teal bags contain 3 dull beige bags, 5 drab olive bags, 4 bright violet bags, 2 drab black bags.bright teal bags contain 4 shiny teal bags, 4 shiny turquoise bags, 1 dotted chartreuse bag, 1 wavy lavender bag.wavy fuchsia bags contain 5 clear orange bags, 3 shiny tomato bags, 2 muted turquoise bags.wavy teal bags contain 1 clear violet bag, 1 posh bronze bag, 3 muted turquoise bags, 4 shiny tomato bags.striped plum bags contain 5 light chartreuse bags, 5 striped white bags.striped yellow bags contain 3 posh fuchsia bags.clear chartreuse bags contain 1 dim lavender bag, 1 posh lime bag, 5 dull lime bags.mirrored tan bags contain 2 mirrored lavender bags.posh turquoise bags contain 5 dim cyan bags, 3 shiny yellow bags, 4 dim brown bags, 5 posh gray bags.dark cyan bags contain 4 pale black bags, 3 light turquoise bags, 2 mirrored cyan bags, 1 wavy white bag.dim magenta bags contain 2 dull gold bags, 5 bright red bags, 4 clear aqua bags.mirrored tomato bags contain 2 posh gray bags, 2 faded silver bags.plaid violet bags contain 4 drab red bags, 2 pale gray bags, 2 muted lavender bags.wavy orange bags contain 4 muted coral bags, 3 bright plum bags, 3 faded coral bags, 4 muted turquoise bags.dim coral bags contain 1 light red bag, 5 bright silver bags, 4 pale magenta bags.dotted olive bags contain 2 striped orange bags.light orange bags contain 5 vibrant red bags, 2 light turquoise bags, 3 dark coral bags.faded brown bags contain 3 plaid maroon bags, 1 dull coral bag, 1 drab brown bag.dim black bags contain 5 vibrant violet bags, 3 muted blue bags, 4 posh yellow bags.plaid yellow bags contain 3 dark coral bags, 1 faded beige bag, 3 light orange bags, 1 drab lime bag.striped salmon bags contain 5 muted teal bags, 4 dotted brown bags, 2 dim bronze bags, 3 dark blue bags.vibrant teal bags contain 4 bright maroon bags, 1 muted maroon bag.faded teal bags contain 5 bright beige bags, 1 mirrored black bag, 5 muted lavender bags.striped violet bags contain 2 striped magenta bags.mirrored gray bags contain 5 light red bags, 2 pale chartreuse bags, 5 striped gold bags, 4 pale salmon bags.muted brown bags contain 3 dark salmon bags, 4 vibrant bronze bags, 2 plaid lime bags, 3 shiny bronze bags.plaid silver bags contain 1 bright black bag, 2 shiny cyan bags, 4 drab red bags, 2 faded indigo bags.shiny lime bags contain 1 dim purple bag, 3 shiny tomato bags.shiny bronze bags contain no other bags.drab indigo bags contain 2 dim chartreuse bags.wavy black bags contain 4 drab blue bags.dotted tomato bags contain 5 bright tomato bags, 5 drab tomato bags, 1 pale tomato bag, 3 mirrored olive bags.bright turquoise bags contain 4 posh yellow bags.clear green bags contain 3 dotted tomato bags.light brown bags contain 5 plaid fuchsia bags, 3 mirrored gray bags, 1 posh orange bag.clear silver bags contain 5 vibrant teal bags, 5 dim blue bags, 4 muted gray bags.dull salmon bags contain 2 plaid silver bags, 4 dim salmon bags, 5 dim red bags, 5 vibrant maroon bags.drab coral bags contain 5 pale fuchsia bags, 3 dull green bags, 3 drab olive bags.dim chartreuse bags contain 4 muted maroon bags.wavy white bags contain 5 mirrored turquoise bags.light bronze bags contain 1 striped tomato bag, 4 faded bronze bags.light plum bags contain 5 drab yellow bags, 5 drab teal bags, 5 faded silver bags, 1 light magenta bag.muted magenta bags contain 5 striped blue bags, 3 dull purple bags, 4 vibrant red bags.clear violet bags contain no other bags.posh cyan bags contain 5 wavy beige bags.light cyan bags contain 1 shiny red bag, 4 vibrant violet bags, 4 pale magenta bags, 4 shiny turquoise bags.dim aqua bags contain 2 plaid crimson bags, 2 posh fuchsia bags.clear indigo bags contain 2 dark turquoise bags, 1 striped orange bag, 3 light magenta bags.dull lime bags contain 2 muted silver bags, 5 faded maroon bags, 4 mirrored olive bags.dotted beige bags contain 2 dark coral bags, 5 striped gray bags, 3 dark aqua bags, 3 vibrant silver bags.dim gray bags contain 3 wavy chartreuse bags, 1 muted green bag, 3 shiny tomato bags.vibrant beige bags contain 5 plaid crimson bags, 4 drab crimson bags.vibrant gray bags contain 5 posh white bags, 4 clear beige bags.vibrant tomato bags contain 1 striped red bag, 3 light maroon bags, 3 shiny turquoise bags.striped magenta bags contain 1 wavy tomato bag, 4 vibrant salmon bags, 4 bright tomato bags, 4 drab teal bags.dark coral bags contain 1 shiny bronze bag, 5 shiny tomato bags, 4 bright tomato bags, 1 plaid white bag.vibrant maroon bags contain 1 muted coral bag, 2 drab tomato bags, 5 mirrored olive bags.shiny gold bags contain 5 pale brown bags, 2 light red bags, 3 drab lime bags.pale olive bags contain 1 dark turquoise bag.pale orange bags contain 2 posh maroon bags, 3 faded indigo bags.shiny teal bags contain 4 mirrored blue bags, 2 vibrant black bags.dull indigo bags contain 1 dull beige bag, 4 plaid purple bags.mirrored purple bags contain 5 dull green bags, 3 dotted cyan bags, 1 light red bag, 2 mirrored chartreuse bags.dotted coral bags contain 3 vibrant tan bags, 2 dark green bags.dotted salmon bags contain 3 wavy teal bags, 1 plaid bronze bag.faded violet bags contain 2 plaid olive bags, 4 striped maroon bags.dotted red bags contain 1 bright plum bag, 1 posh orange bag, 4 pale chartreuse bags.drab maroon bags contain 2 shiny crimson bags, 2 dim indigo bags, 2 pale turquoise bags, 1 plaid bronze bag.faded gray bags contain 2 dull turquoise bags, 3 pale chartreuse bags, 2 dark olive bags, 2 dark brown bags.vibrant green bags contain 3 pale green bags, 1 clear red bag, 2 dark fuchsia bags.drab lavender bags contain 2 bright crimson bags, 3 posh lime bags, 2 plaid lime bags, 1 vibrant fuchsia bag.dotted silver bags contain 1 faded silver bag.posh teal bags contain 5 posh indigo bags.dark black bags contain 1 faded silver bag.dark yellow bags contain 1 plaid violet bag, 2 bright gray bags, 1 mirrored gold bag.dim fuchsia bags contain 4 pale chartreuse bags, 3 faded bronze bags.pale salmon bags contain 3 shiny orange bags, 1 dark brown bag.light tan bags contain 5 pale maroon bags, 2 shiny maroon bags, 3 muted turquoise bags.drab blue bags contain 5 faded teal bags, 4 dotted beige bags, 1 dull orange bag.bright beige bags contain 5 muted maroon bags, 2 clear plum bags, 1 mirrored black bag, 4 vibrant yellow bags.dim green bags contain 4 dark fuchsia bags, 5 muted bronze bags, 4 dim blue bags.muted teal bags contain 1 vibrant orange bag, 4 dotted lime bags, 1 dark turquoise bag, 3 dim plum bags.vibrant white bags contain 4 dull red bags, 3 striped white bags.shiny silver bags contain 1 dim teal bag, 3 pale maroon bags, 2 plaid olive bags.pale cyan bags contain 3 dim turquoise bags.faded plum bags contain 2 pale purple bags, 2 dark white bags, 4 dotted chartreuse bags, 5 vibrant maroon bags.dotted lavender bags contain 1 shiny tomato bag, 5 striped gold bags, 5 pale brown bags.bright white bags contain 1 faded magenta bag, 2 mirrored salmon bags, 5 bright salmon bags.dark lavender bags contain 1 posh teal bag.posh gray bags contain 5 vibrant yellow bags, 5 dotted salmon bags, 3 shiny tomato bags, 2 clear beige bags.dark gray bags contain 3 striped gray bags, 3 wavy tan bags.dark lime bags contain 1 dark salmon bag, 5 pale green bags, 2 striped green bags, 5 mirrored blue bags.vibrant black bags contain 3 light red bags, 4 plaid lime bags, 3 posh lime bags, 2 dotted lavender bags.light beige bags contain 5 muted blue bags, 2 faded red bags, 1 muted turquoise bag.dark red bags contain 2 faded crimson bags, 1 wavy maroon bag, 2 clear indigo bags.shiny crimson bags contain 1 muted red bag, 5 shiny bronze bags, 1 plaid green bag, 5 mirrored orange bags.dim purple bags contain 5 striped purple bags, 2 vibrant bronze bags, 2 striped beige bags.wavy maroon bags contain 1 faded silver bag, 4 muted black bags.dull blue bags contain 2 bright gold bags, 3 pale salmon bags.plaid green bags contain 4 dark brown bags, 1 shiny orange bag";

            var datas = content.Split('.').ToList();

            var finalList = new Dictionary<string, List<(int, string)>>();

            foreach (var d in datas)
            {
                var sub = d.Split(" bags contain ");

                List<(int, string)> subBags = new List<(int qty, string val)>();
                finalList.Add(sub[0], subBags);

                foreach (var dd in sub[1].Split(new[] { " bags, ", " bag, " }, StringSplitOptions.None))
                {
                    if (dd != "no other bags")
                    {
                        var ddd = dd.Split(' ');
                        var vall = string.Join(" ", ddd.Skip(1));
                        if (vall.EndsWith(" bags"))
                        {
                            vall = vall.Substring(0, vall.Length - 5);
                        }
                        else if (vall.EndsWith(" bag"))
                        {
                            vall = vall.Substring(0, vall.Length - 4);
                        }
                        subBags.Add((Convert.ToInt32(ddd[0]), vall));
                    }
                    else
                    {

                    }
                }
            }

            // part one
            void RecursiveSearchUp(Dictionary<string, List<(int, string)>> baseList,
                string search, List<string> finaLList)
            {
                List<string> bagsWithSearch = baseList.Where(kvp => kvp.Value.Any(v => v.Item2 == search)).Select(kvp => kvp.Key).ToList();
                finaLList.AddRange(bagsWithSearch);
                foreach (var bagWithSearch in bagsWithSearch)
                {
                    RecursiveSearchUp(baseList, bagWithSearch, finaLList);
                }
            }

            List<string> foundList = new List<string>();
            RecursiveSearchUp(finalList, "shiny gold", foundList);

            var count = foundList.Distinct().Count();

            // part two
            void RecursiveSearchDown(Dictionary<string, List<(int, string)>> baseList,
            string search, List<(int, string)> finaLList)
            {
                var vals = baseList.Where(kvp => kvp.Key == search).SelectMany(kvp => kvp.Value).ToList();
                finaLList.AddRange(vals);
                foreach (var val in vals)
                {
                    for (int i = 0; i < val.Item1; i++)
                    {
                        RecursiveSearchDown(baseList, val.Item2, finaLList);
                    }
                }
            }

            var foundList2 = new List<(int, string)>();
            RecursiveSearchDown(finalList, "shiny gold", foundList2);

            var count2 = foundList2.Sum(kvp => kvp.Item1);
        }

        private static void DaySix()
        {
            var all = "atxmhdzkjgivwcqu[PS]conirfdgplhvsa[PS]ghbvdefsaniyc[GS]c[PS]c[PS]cas[PS]xc[PS]cz[GS]sdxtfzo[PS]stfzno[GS]t[PS]t[PS]t[PS]t[PS]t[GS]nkjexbhrswugov[PS]jxugwhbroves[GS]meqnof[PS]vxwhzpmqo[PS]jno[PS]bkoliycr[GS]u[PS]u[GS]rbyuds[PS]surjb[PS]lbrxsawhu[GS]sd[PS]dq[PS]ds[PS]ds[GS]zo[PS]z[PS]vz[GS]czhuijskmt[PS]utszkmhijc[PS]kzmuictsjh[PS]chimtzksuj[GS]uwhmbl[PS]wblur[PS]wublm[PS]bflesuw[GS]bo[PS]wcszvk[GS]htfsqoriyngzjbvx[PS]dujtmikcpzrwehaxl[GS]rubwcon[PS]vwo[PS]omwhl[PS]rxwbo[GS]aj[PS]aj[PS]faj[PS]aj[GS]nwfmajzslokrxhgtyq[PS]vicapdwkbuh[GS]vdwysctjq[PS]jmilqgh[PS]jqgf[GS]tnoemqphdcbj[PS]jfavhsqkntg[GS]qjrpfwckgbvenam[PS]qpucwvgmjfabro[GS]fmqwzhbytnacdr[PS]fmncdrhqywatzb[GS]r[PS]w[PS]w[GS]umrbzaypkwinh[PS]eyuwhi[PS]yhuwie[PS]ehiywu[PS]hwyui[GS]dxynjlhfbi[PS]fjxd[PS]mxdfj[PS]fdxmj[PS]jdfoxs[GS]ikdeutpqynboghfs[PS]yjfkmidnqtgueb[GS]jpzfsbwgdkvtiymneuca[PS]vbpkjgtdaucezymwsn[PS]ctmydbsjgapewnzuvk[GS]gyxjvqk[PS]gwkjfvi[PS]rkcbegvjm[GS]sgzakoq[PS]koszqa[GS]qmzjhtsodfurnpegy[PS]aurfdgojzmetpnbis[PS]gtezmrodujfpsyn[GS]qyknpixtrfuolw[PS]fkpwgntyxlqumrio[PS]yrflupnoqitxwak[PS]iypferukwqtonlx[PS]qurtxlnoiwkyfp[GS]xbweyquhnairjtzopvmg[PS]byhuwnaxqoimtzepvjrg[PS]jzxbqmrnwgvdpaeyotuhi[PS]nwtpovmruhqieyjxabgz[PS]yoeamwhqbrtjvgniupzx[GS]ic[PS]ic[PS]ic[PS]iuperc[PS]acsi[GS]oicl[PS]c[PS]c[PS]c[GS]uyxbejfrqhvpcknziowtlad[PS]fxhnwdebmjzpitkgqualrv[GS]me[PS]me[PS]wme[PS]yemc[PS]em[GS]zxgncvbdrewkyls[PS]lzbnwesxckgryvd[PS]krvsyadlgbzecxwn[PS]nwcblgzdsxrkevy[PS]vgwbrxleckzydns[GS]bdrhenpgofqyv[PS]uazwsjlitk[PS]wlcatxm[GS]jsdnlwkto[PS]onkdhysjtwl[PS]ojhkstnlfwd[PS]wfjeodnklts[PS]wkngdtqulaozjs[GS]jseag[PS]lazegosfj[PS]gaesj[PS]rjagse[GS]vycnwzfah[PS]yhwanzcvf[PS]fycvwzhna[GS]kdenoqr[PS]drnokqe[GS]fudosahtj[PS]hzygvbjdu[PS]qubhjdep[PS]ezdujxbhw[GS]asrfbcnuywm[PS]nyrawufmbcs[PS]mbyrasnufwc[PS]fusrncywmba[PS]racbyufmnsw[GS]eldyp[PS]pgdjb[PS]jdpb[GS]xiky[PS]ximqy[PS]yxinl[PS]iyx[PS]yiekx[GS]lzbmt[PS]otbpu[GS]upobyhamecgwtjkx[PS]kytepobcxhwuajgm[PS]kobtcgphxeujmwya[PS]tbpjehaukgycwomx[GS]lgjrbcymkatpx[PS]pbazritkysjmlx[PS]tkpymrejqxab[PS]tayxbjnlourdfpkwm[GS]kvqxyecmirno[PS]einsmcdxkyrvoq[PS]evxqrkoiymnc[PS]yvikqxecmron[PS]yqemnrickvox[GS]tlroieuszcwpkdbmh[PS]ypgxfdatn[PS]jqpdvt[GS]kuynfegcxrt[PS]ytnuzecgfxk[PS]xhgsflynecw[GS]q[PS]q[GS]mu[PS]um[PS]uwm[PS]mu[PS]um[GS]abyhrzfe[PS]yqhrfebz[PS]frhzeyb[PS]bkfreyazh[PS]ebrzyhf[GS]vdo[PS]se[PS]x[PS]x[GS]peckiwfxzqsal[PS]paiuofxlqyczeswk[PS]zxlarkseiwfcpnj[PS]lnkijaeswqpfzcx[PS]mtpilgsbchfwzexka[GS]vnuoec[PS]fveonub[PS]evsrniquo[PS]ondeuav[PS]nuovte[GS]ypnmo[PS]omypn[PS]ympon[GS]pgbej[PS]pjbg[PS]pjgb[PS]jpbg[GS]xwognfphakcjritb[PS]fvcoexrpughatk[PS]orahqctxfzgkp[PS]xgfrhcokmapt[GS]g[PS]ytab[GS]q[PS]yw[GS]ravlebmfjodkzgu[PS]rujyetlnszmkvad[GS]mgktpszhdeolvbqa[PS]oqnbagktzpvshdle[PS]sltvkgpezabqdh[PS]kpsghlqzedbaft[PS]dknetrlqgpzahbs[GS]rejugfqtbaklixcmhodwsnyzv[PS]gmukinscxjpvehbrodfqyawz[PS]aswfqonbuvhkdizjgmrxyec[PS]jrgiyhdmwcexuqfzoabkvsn[GS]nfcsiavmzglehorwd[PS]orcmwveigashnzdfl[PS]gcmhdvfawlsnzxrioe[PS]qfehovruzlgncwmsida[GS]qrufx[PS]frozu[PS]qfsrjub[PS]nvfuxr[PS]wcydflreu[GS]tawnehfqjsc[PS]ocaznquitbs[PS]pnaqcshtv[GS]twvz[PS]tzwv[PS]zvwt[GS]ejv[PS]vje[PS]ejv[GS]zicejtfhnuq[PS]hzjcquitenf[PS]vjznuqhtiefc[PS]tuqcnjefzih[PS]hitnjezfcuq[GS]w[PS]w[PS]f[GS]jufqelnptbragsmocdwk[PS]embpluswrkdovjnqcfg[GS]spzytuih[PS]tevqnxrhi[GS]nxeolsqucv[PS]losqenvu[PS]nveljqugso[PS]opurwesnvql[PS]vbeflqugwnosrp[GS]fcekwrx[PS]vczrowmxa[GS]ydtqbl[PS]ldytbq[PS]bdqltyv[PS]qytldb[GS]fzbucokxnimrdvsplta[PS]ztnkgarvdlxfiwu[PS]udzxtkfvhrnlia[GS]qnzmokyluv[PS]oczmvlnyqku[PS]kvlqzymuon[GS]qchbuvepxwm[PS]ubxvpcwd[PS]wsubcnvprdatx[PS]rvpbxydcwu[GS]ibeayjghko[PS]cslrtwdvmbxqpfnuoz[GS]uzp[PS]uzp[PS]pzu[PS]puz[PS]zup[GS]gqhbwupsmeklf[PS]ebmlkfgshpwuq[PS]mbsqkpgewulhf[PS]ufphbmsqlkgwe[GS]pxsqkfa[PS]pkmcrqefgx[PS]kfxpq[PS]pqkyfx[PS]kzdqfxp[GS]yimkxaqtcnospueg[PS]pngtsyqkcuoamiex[PS]ncygqsmatiupxkeo[PS]quichtngeypsaxkom[GS]jew[PS]eylr[GS]uc[PS]uc[PS]cu[GS]gapelusnokrw[PS]zloakewgpsrun[PS]pnrkwosagule[PS]nuwaesypkgomlrv[PS]iarpwkugolhesn[GS]qdyzmoitxflwbnver[PS]udwlojxfipkshacnqvg[GS]butecshxlvanoy[PS]octsbudkilhnzeyavrxg[PS]tyavloucspenbxh[PS]qebhpxsunovalmwjcty[PS]xhvstmbaulyceon[GS]vtspwicxbz[PS]spbzixvtcew[PS]vcxpwtsibz[PS]cizvpxstwb[PS]tiwcbxpszv[GS]avrgucfhxjblspwzmdtnyiqek[PS]wvlmbfipargeyxscjthznuk[GS]clzbqry[PS]lrebz[PS]zlbpr[PS]urlzb[PS]lbzr[GS]dvqtxlgowke[PS]idtvexwlog[PS]wvlotxgde[PS]dygtopxlvwe[GS]xuybmdgwacejltzkhr[PS]lojbxtwyrhdgufkpec[PS]lyebujkxhtrcwpdg[GS]zhxigcsotywpuelband[PS]girdhbonymwfpuvx[GS]profkjw[PS]nylxubzptsg[PS]vidrop[PS]ewpfh[GS]vc[PS]cuv[PS]vc[GS]gjytrlzpeonxwcdbafh[PS]dhxgwpyjlroazenftcb[GS]fymaqc[PS]afmcqy[GS]wxcazpmrfyb[PS]pnvrzhacfji[PS]zvctfapr[PS]tpzlchiafr[GS]izrdmuwebqk[PS]mreahwzsuqd[PS]ruqyezahwpdnm[GS]rj[PS]jr[PS]rj[PS]fjr[PS]rj[GS]txjnrfocwlemuiapbh[PS]lqjuaweo[PS]aujlkesoyw[PS]jwoealu[PS]ujodaelwvkgz[GS]zo[PS]zo[PS]z[PS]mzd[GS]dx[PS]c[PS]c[GS]mprvcwluqo[PS]tloukican[GS]odvtfhqjawgpzbxre[PS]tgoxqwrfhjcbaev[GS]fdaljwguepsiykxz[PS]lpseagdjzufkywix[PS]sywukzgjlfixaped[PS]bpuyjswgrkdaxliezf[GS]uncv[PS]icnv[PS]cnvu[GS]ktaqgr[PS]twgaqykrjm[PS]vqgpkfuxtchrae[GS]armwntdgzfxikehupj[PS]xtfhgjmrdzpaiunewk[GS]yxrkv[PS]vfykru[PS]rviesjyt[GS]plyfkjxasvuzdcgbtwi[PS]xzjiwylkpctbfvdugsa[PS]fkxjvlbactydpgzsuiw[PS]qgwcbfjtypzkvluxsdiam[PS]btzplfwigkdjasxyvuc[GS]gwloycsuz[PS]musyrzwlaoge[PS]uovyzhlswgc[GS]qndaivetjcgblwzsykhu[PS]agorkdnxvmswpfhqiuetzyc[GS]fgxopdsinm[PS]msgdeponfxhi[PS]xpodgmsinf[PS]nfmodxisgp[GS]rx[PS]x[PS]x[PS]oxed[PS]x[GS]twrjcfumd[PS]cvjbfuw[PS]oyasjulepkgwx[PS]umirnjw[GS]unhbzo[PS]hnuobz[PS]uzonhb[PS]ubhyonz[PS]uzhbon[GS]arfjnt[PS]netj[PS]etnqj[PS]yjxsntm[PS]fntjvg[GS]khqap[PS]aqhp[PS]pjovizqh[PS]qph[GS]uosyjc[PS]zrledfqmpi[PS]kjxotw[PS]tgay[GS]nrzckijesf[PS]ihrbgsjn[PS]jshbintrom[PS]hrmnsibj[PS]mjsirwn[GS]ilqbcavozr[PS]tarjqpolv[GS]piokgqecjz[PS]gfjkleochzip[PS]peczjiokg[PS]zkpjioegc[PS]zciekojgp[GS]pwi[PS]wip[PS]pi[PS]pi[PS]pih[GS]gmjlzhpkqbfiuvdsy[PS]djfvsyglzcikmqbup[PS]mzsjgidkewauvqflypb[PS]vzuglyndmftspikqjb[GS]l[PS]jl[GS]yiucsmkgalz[PS]iaulzghkmnc[GS]pny[PS]pkyn[GS]mgflvdoj[PS]vlmodfgj[PS]joglvmidf[PS]jdomlvgf[GS]bctiyxqnazrpd[PS]qautyfzjegx[PS]tyqaxzojv[PS]qajgytzfx[PS]xqazylt[GS]wmkauglpbyzno[PS]djrhciqfxs[GS]zvk[PS]zkv[GS]vrlencohidajmxub[PS]xordabecpnluvmhi[PS]njrieodvaclbhumx[PS]uebfcsiorldaynvxmh[GS]m[PS]m[PS]om[PS]m[GS]elyhutb[PS]ethub[PS]utebh[PS]txzuehdgbnr[PS]ubeth[GS]os[PS]o[GS]va[PS]hv[PS]hv[GS]espkqfnj[PS]neqp[PS]nepq[PS]enqp[PS]nqpre[GS]mzthqn[PS]drnmtzq[PS]tqmnxyizw[GS]kvt[PS]ftv[PS]vlt[GS]vasmgbthenrwxdicl[PS]xcbstgrnvedwauimhl[PS]eamctuvdgsrhxniblw[PS]bknedmhcxigrwtlvsa[GS]yomwcsxjienprztgubklvd[PS]ivfgqukempnbwaryj[GS]huvpmdyswlj[PS]wpyhvljmsud[PS]mdhwjvuspyl[PS]wlypuvmjdhs[PS]lmjwhyvspud[GS]lmwjpzcoavteiq[PS]mlwkogxvabrqejci[PS]ajmhcedvliqwo[PS]vomafiwqljcue[GS]mpukzsthlv[PS]vwzpkmhult[PS]kuvhwtzmlp[PS]vhmjztplku[PS]utmvczpkhl[GS]ghmjkozbcevyrdixwputf[PS]ejmyvnpgzkwbuxfoctdr[PS]gdjmetkfxourplyvwcbz[PS]rojxycmfteuvwbkpgzd[PS]eywujmctvqgfdzkxrobp[GS]thoagp[PS]btaphg[PS]ptaghwm[GS]vnmuxtqjifowya[PS]etqlonrwmfadzpxbuj[PS]gxjquatnmowvf[PS]onmfctjuqxakw[GS]beinxhzlmjatkc[PS]hmxctiklajnbz[PS]zlnkxctjhambi[PS]tlxzhknmwjacbui[GS]ycvpzimohndk[PS]imyzekhpcod[GS]peaxqrgofmjbytuzvd[PS]wduhliarofgxzntjev[PS]jgasdekoutvrfxbz[GS]pkstbjaclrzd[PS]kelpszrmg[PS]eojrskczltu[PS]ihrvlzxqfsyk[GS]rpjdlcybgniahuzqs[PS]zhpgruqjtcsabnidyl[PS]utljniqdrpsbzhaygc[PS]znojdrpcuiyqshablg[GS]xtnjlk[PS]xknjti[PS]nxkjt[PS]tkjxn[GS]hcleuvbargstowm[PS]bhwoulsegvtramc[PS]hmasguvceltwobr[PS]arutogvschmeblw[PS]servlmabghckwotu[GS]o[PS]o[PS]o[PS]oy[PS]o[GS]gtjbzkvas[PS]bgkjvtzsapl[PS]zrvtgwcakfjbso[PS]tjbkugvasz[PS]vbagszkjt[GS]gfeoirwlbmdjhk[PS]kirjwlhmoebfp[PS]rolkeiwbhmjf[PS]hbirkejwfmlo[GS]yzptkfhal[PS]tlzfkyhap[PS]tplzyhfka[PS]hfplztkay[GS]vmrqh[PS]vhjmxqgyidw[PS]qhmnv[GS]jdhwkilngubeoa[PS]sxpluz[GS]jusbk[PS]uxsz[PS]vylqdmugtpne[PS]azfu[GS]zxtbn[PS]tbnx[PS]tbxn[PS]btwxnu[PS]naxdbt[GS]v[PS]v[PS]v[PS]v[GS]ioruk[PS]uriko[GS]unmxsykzgcilw[PS]nokmu[PS]mjnuqk[PS]akunmv[GS]rfyibxnevstdz[PS]fsextzdnvbyir[GS]ehsdnwqugifbvjlk[PS]xkesuhnfldijbytgwv[PS]ivjqhwfdgskenulb[PS]vlwijqbsfkzudegnh[PS]ibudhwelgfkvsqnj[GS]whxsbrjkqy[PS]dxhkwfsg[PS]hxuonzvictapme[GS]ui[PS]ui[PS]iu[GS]ofzuh[PS]czquo[PS]zohu[PS]uzof[GS]akphewcvmiqzuxdsf[PS]frmsviubcqgkzdwxjnh[GS]jywpvmdhut[PS]xjeakczsi[GS]xaenzqsirfm[PS]xzsanmqifer[PS]xzfoqrsajmein[GS]ypirboxntkl[PS]yobrxintkpl[GS]benomiyjqdptszaxc[PS]ncayqsmbjfzpotx[GS]poygwzfkuahrvqimbnscjdexlt[PS]xqwnagemrlscbdouykhivjzftp[GS]vsphtodb[PS]dstvobp[PS]dvpsrbomt[PS]htovbdsp[PS]psodbtv[GS]dyxao[PS]oabtscl[PS]vhgnaui[PS]aesm[PS]eak[GS]gw[PS]krosgqelnc[GS]hvnfalkbdcexi[PS]beunfqcaxivkdl[PS]linxezbfcakdv[PS]kdxbiecfpavnl[GS]bp[PS]qul[PS]b[PS]p[PS]p[GS]wbvefx[PS]huqymact[PS]gpir[PS]moykz[PS]dju[GS]dt[PS]dt[PS]ted[PS]dt[PS]td[GS]elhjvm[PS]mu[PS]omnap[PS]fywtsmrc[PS]ogrzm[GS]efb[PS]bfr[PS]fb[GS]puszjmhfo[PS]axjwtomegyrku[PS]ldvbujchofmz[PS]jmdoupl[GS]bvweypzsfroah[PS]knpleztqcgrvdashfujmyio[GS]rgdtzhj[PS]ohswzxaijd[PS]mlhfduvznj[GS]faqdszhwtovk[PS]dhfvskonzalurmtqwc[GS]ectigrqjnhyzvxomlp[PS]gprjuxloceibv[PS]elricvspxjog[PS]fivcorpxjgel[PS]rclogpejxdiv[GS]cgshrel[PS]anfsk[GS]y[PS]smgwxh[PS]d[PS]d[PS]t[GS]xwvtlpayobgshjq[PS]tahyjpxlqogwsc[PS]slgwptojqhxy[PS]tzywskjlqhpxfg[GS]xakmubfreyop[PS]zsaxruky[PS]kayruxst[PS]axulykqsr[PS]yukrax[GS]gqhsy[PS]vdkc[PS]ikexpt[PS]alujfmnr[GS]qd[PS]dq[PS]cdspk[PS]dt[GS]kv[PS]lvk[GS]lcn[PS]msnyx[PS]uepnl[GS]idwqrmpjzo[PS]dojqzmpiw[GS]yboluqi[PS]xzbenhvwftos[GS]vsqmcylrugfezitxbhpnaw[PS]ebcxztpvgaswfyiuqolhmn[PS]ywqmpxzesuovtfighclanb[GS]fwpxel[PS]zlefpxwm[GS]xahkdvyig[PS]ugdixykhav[PS]hagkivydx[PS]ahykgjvdix[GS]fqypwlzaxcnh[PS]mbjfrzpakwd[GS]foajsvbkqnwurhmtic[PS]jfwxuhmlyetcpgra[GS]saynjgeklirmfozuth[PS]tskreflaogzcmnyiujh[PS]jiylarkmshonuftegz[PS]fjxrtdavnmgiyoeuzslhk[PS]glotsukjrfyahmeizn[GS]fgvzuiksxlptcqwmnohr[PS]oqztcmspnhwvijkdgu[GS]whfx[PS]kfh[PS]hfr[PS]bnjzhsdfi[PS]ufqch[GS]ncbfhpexm[PS]xremnpfc[PS]bencmpxfw[GS]rpyknb[PS]ktpcb[PS]cpzkb[GS]beou[PS]uej[GS]qgyudcrhfml[PS]pvkjzneo[GS]azosqblkfdjuipemwygr[PS]nxqjumytrglaohsidp[PS]uoamsqgyrjdiplx[PS]dlumpoyarsgjqci[GS]pkbhegfducs[PS]sukehcfbtjdg[GS]qfjm[PS]qkselfmob[PS]qfcxnvm[PS]jmqwf[PS]mfq[GS]ivmpywfqruhs[PS]rupmfhqiyswv[GS]dkav[PS]vadk[PS]kvda[GS]kincpbv[PS]cknuv[PS]vnuckxag[GS]flhdeonaxsciv[PS]descoflahnvix[PS]nofiacdvhxsel[PS]ehlfoisvxcnda[GS]hs[PS]ztedwx[PS]nlva[GS]meqycx[PS]cqmiye[PS]qgmotyce[PS]mcqgye[PS]emcqy[GS]dwshy[PS]swhyd[PS]hwyds[PS]swyhd[GS]wbqvtxal[GS]tlfdbvkyu[PS]flydbk[PS]bsrpfidqxky[GS]unwtfcv[PS]kvrfbnw[GS]xazgi[PS]agz[PS]ysga[PS]nawgv[GS]swtx[PS]gnqayohzm[GS]un[PS]z[GS]tr[PS]g[PS]g[PS]d[PS]k[GS]dl[PS]tl[PS]dl[GS]v[PS]youdan[PS]ejm[GS]arktbdczqfvx[PS]qtzxbdkarfcv[GS]gfve[PS]vefkg[GS]emojkagtqclzxdf[PS]jtamfedbocz[PS]hzpijrveasomwdfcyt[PS]metazdkcjfulo[GS]uplwm[PS]pwulm[PS]cmwup[PS]wupm[PS]umwp[GS]apjeybkdmq[PS]kdjqpmyea[GS]k[PS]k[PS]i[PS]k[PS]eng[GS]w[PS]wh[PS]f[PS]j[GS]rykcomu[PS]mcyorxuk[PS]muoyrck[PS]rcoykmu[PS]yukocrm[GS]uc[PS]mcn[PS]sfl[PS]exqazjb[PS]vdc[GS]hpoack[PS]cltek[GS]esjqog[PS]qeso[PS]seqo[PS]qesoy[PS]eqos[GS]d[PS]o[PS]v[PS]ag[GS]rnzgaehid[PS]parned[PS]dnaefr[PS]pdrnyake[PS]sernad[GS]xzhlvcnjykdmp[PS]zlvxihpwjkyn[PS]yzklnvxhgqjp[GS]v[PS]v[PS]vt[PS]v[GS]ksmfiwl[PS]mklsfwi[PS]sfkmwli[PS]ifkswlm[PS]imlsfwk[GS]nzogsphkcw[PS]hkgpowzcbsn[PS]gowhkscpnjxz[PS]hspwckgzon[GS]kqoxpyvzuw[PS]lorghcfmjte[GS]uldnticjqhrzwmx[PS]mnwuqclgzpjrske[PS]lfcynwrvmzjuqa[PS]lhnomxjzuqgcwr[GS]tdpxnfrj[PS]txpjdr[PS]ptjrdx[PS]dxjtrp[PS]rdpxtjb[GS]zfaeqorn[PS]qmezdfxr[PS]uqbyeizphrgtjsk[GS]ghizjpctfdnql[PS]rvoaecnykifdtp[GS]liszmpruehocfndgt[PS]bdiruxnsfplkgoe[GS]mzvcwhrqabpnstxjyoleifd[PS]mbwtcxlzosyeqpvfdinajrh[PS]hqenawizmxyjvlrptbcdsfo[PS]tzovqajmwdsepcyflhrxbin[GS]ehodx[PS]svycbltpmoa[PS]irohkxe[PS]fzjuo[GS]rv[PS]rv[PS]rv[PS]vr[PS]vr[GS]axoez[PS]zoexa[PS]xozae[PS]aoxze[PS]zoaex[GS]vmgthlaxsnbidk[PS]nqtzilcrhgsjauxm[GS]oahz[PS]hzqaoc[PS]ohaz[PS]hezao[GS]obkwvazgc[PS]kvsaegcopnwbdz[PS]zgkbwvoac[PS]kzgawbovc[PS]cgoakzbvwl[GS]klnmgi[PS]mciln[PS]scnpi[PS]yniw[GS]ekwcfunhsba[PS]sjuhcnfeakb[PS]sbefhaqkucn[PS]kaoudnferscbhy[GS]ebcoplsnuw[PS]camnjlepubo[PS]lsoebcnupz[GS]tfxyvgznocdleb[PS]tihbfsn[PS]tnfhbp[GS]eyojwm[PS]yjomex[PS]mjeyo[GS]wpvtdjzrcf[PS]xmfuncgiybjhpsqlkz[GS]tzcwnlei[PS]twceinl[PS]inlcvgtkew[PS]ilcwxetn[PS]ncmwtaiel[GS]hzwocd[PS]qvhkn[PS]hytliebm[PS]fshq[GS]sxlbnowmv[PS]msonwxb[GS]hdknsxog[PS]nfojk[PS]avelwctzqmripuy[GS]slgrm[PS]msrgl[PS]glsrm[GS]shjieplz[PS]zogimjcv[PS]rkfqxdynwbu[GS]oejgdcamtxzhyn[PS]jhcntdealyzxogq[PS]ejthagzcxonyd[PS]onxdjsmycgztaeh[GS]uyloghq[PS]yguhlqro[PS]uoyqlgh[PS]ouyhqgl[PS]yoluqhg[GS]oxqtmpjzieunbdak[PS]nlmhzwjedxouyisctfpvrg[GS]kmrnhzcad[PS]ahzrcndm[GS]sbcmuhfkanitw[PS]scbkmaftwhdinu[PS]swmbkhnacitfu[PS]ntcaukbwmshif[PS]kswhbufimctna[GS]nlhwqxvpjgmsr[PS]rvgmyjxhsplaqewn[PS]smvnlwgqxrphj[PS]qjnxpmlwhrsvg[PS]lmsjpqrwnxhgv[GS]fivwsrdz[PS]ekcq[PS]xg[GS]umhborsxcg[PS]bghsmqxuc[GS]jwnv[PS]wjnv[PS]vnjw[PS]vwjn[PS]wlvnj[GS]vlfhdjz[PS]hjlzdvf[PS]dozvmlhfj[PS]jlhvzfd[GS]fue[PS]ksmad[PS]l[GS]wcjsaepudqvionrt[PS]rlhydbgixmznkcjt[GS]cqh[PS]qc[PS]cql[PS]qc[GS]kwapzcyisfexgmolnhbrqv[PS]vfdlyxsmkotwhbpziraqcg[GS]ctmgd[PS]gtdm[GS]xwornpgqkmizhutfdlb[PS]nzdjoiwprvhtflkcgum[PS]trigoqlwhzmkpdufn[GS]nix[PS]xni[PS]nxi[GS]nrvcsp[PS]fjbkd[GS]fvdmgq[PS]fqdmvg[PS]mvqfgd[GS]blx[PS]x[PS]tv[PS]rkqzge[PS]l[GS]j[PS]d[PS]uc[PS]f[PS]j[GS]mnqbwykj[PS]nksfmwtbzepi[PS]mndjkwrqb[PS]dbkwnm[GS]eskvjnozwclrumqgiydhpat[PS]zptyjudvmlaehnqoiscgrwk[PS]epgmahlktynjdsvouqizwcr[PS]mnltkagqcxwyveidsourjzph[PS]dpmjiovtqswrzluhknyegca[GS]wd[PS]ws[PS]dhw[GS]hcs[PS]shc[PS]hcs[PS]chs[PS]sch[GS]fsajcbywgh[PS]fougyesbrcahjv[PS]bfhsjyagc[PS]hfacgbsjy[PS]yjagcsbhf[GS]ymnkoucts[PS]sykmzotc[PS]ouyktsmc[GS]v[PS]tv[PS]v[PS]v[PS]vbf[GS]uxplo[PS]upxl[PS]lxpu[PS]cunlxp[PS]lpux[GS]bclgqmi[PS]ibmlcg[PS]mlibgcan[PS]ligmcb[GS]je[PS]kje[PS]ecnhi[PS]jye[GS]xoy[PS]yxo[PS]oyx[GS]tdkglesr[PS]pqkrhevxulo[PS]rzsyetlakd[GS]gauz[PS]zuag[PS]zagu[PS]zgau[PS]zgua[GS]vsph[PS]huspgvl[PS]vpksh[PS]puhvg[PS]ahmpivodq[GS]uewjqlcdghxszbr[PS]ntrxwsljz[PS]lrojxkfaszw[PS]zjfipyxslwrv[GS]dqkswrctf[PS]svwfebmkdrzpyqjx[PS]rdswgqnfklt[GS]njwzbhkfilvec[PS]nvjcelwhbgfz[PS]efcwlhbxvzjn[PS]sefbhpljwzcvn[PS]nljfcvzwexhb[GS]tiflgjea[PS]ogjfaqvitl[GS]avrklgztmw[PS]mzwegvnkatlq[PS]vmtlakzgw[PS]magtzklfibwv[PS]vlaetnzkugwm[GS]vfa[PS]atvf[PS]fva[GS]pgxnohyielrtdbzk[PS]txfhrpyoedkgmn[GS]cry[PS]cry[PS]ycr[GS]sqogwpir[PS]irdoqxwpge[PS]gqrywipo[PS]pdwijgqor[PS]gfvobipwqmlr[GS]mb[PS]bzm[PS]z[PS]q[GS]bgowltrfchp[PS]gbhlopctfrw[PS]rpohbwlcfgstax[GS]gquyvhfizapblmdcnkewx[PS]mwsukfhcqbglexiavznyd[PS]iefbqnxvwlzmkuhcaydg[GS]wctkbxhpv[PS]ladpwgrzovshmt[PS]untwvihp[PS]etjwqphv[PS]yvptwfh[GS]eqsyvjwfctgplhxabzr[PS]munwkdibo[GS]dqlbhkcwzrsmtpi[PS]wklrtmsdczhabipq[GS]qhesvmjdyxw[PS]ivqetudjb[PS]javdteq[PS]joqdve[GS]krdltagi[PS]pcgqmxje[PS]fgmb[GS]olxaykprm[PS]mpylsaxr[GS]wm[PS]j[PS]j[PS]j[GS]fkcogpsdjbhmrlixwya[PS]dxozrtmjsycpiwbelqgf[PS]wgunpmldzxfeoiycsrbj[PS]locvwxgfjmsbtypdir[GS]ek[PS]ke[PS]ek[GS]jxsczemidvof[PS]ovfmdzicjxse[PS]edovzsmcxjif[PS]exfomdzvcjis[GS]bovesgqckmlnzd[PS]lozkvnegbmchsqd[PS]kglnesdvqobzcm[GS]iynrwcudgzpvmbhkl[PS]phybgwrjiznlavudc[GS]inhflg[PS]lghnfqis[PS]hrlxfngi[PS]ghinakwflyu[PS]ltrnhbigf[GS]eij[PS]luej[PS]wcjep[GS]cmbwja[PS]macrbwg[GS]gbnaxskwovjhqtyf[PS]nhofbspvktwqz[GS]pmq[PS]s[PS]c[PS]j[PS]vs[GS]t[PS]ty[PS]tn[GS]glxsy[PS]yskixgjld[PS]bswalux[PS]nxjls[GS]vueh[PS]uevh[GS]mjvlyedipz[PS]mvzdjeiwry[PS]mevizodyj[GS]brhntfpvglmo[PS]cmzvt[PS]viamct[GS]ymbviloeqth[PS]hkltyqcmoxudjnb[PS]bwqzmpytolh[PS]movehlytbwqi[GS]lbdqjzrfayh[PS]afgdebjthyl[PS]hdkjbalfyu[GS]yv[PS]gv[PS]v[GS]dxyqclmgvpahor[PS]ktjmr[PS]zbwfnrm[PS]mtzewjr[PS]rmsui[GS]ghksqe[PS]nlerhxqkmsvo[PS]qekshg[PS]heksqg[PS]qsgyhke[GS]jecfapg[PS]asgpmjnfw[GS]lshjykoirpuzcgmwdqv[PS]qwgzoudypclsvrhimjk[PS]drmjwylhqvpigcsuzok[GS]poclyq[PS]lpoycq[GS]wsfcn[PS]cisz[GS]o[PS]d[PS]o[PS]o[PS]o[GS]goqubkareptcj[PS]mkrcebtspaj[PS]pkbjracte[GS]lcwvagpbzi[PS]lwgap[PS]lwgpax[GS]nmxilaeurpkbcqt[PS]excklrinuatyqpb[PS]oxzrbcnqlgtapiuwe[PS]qbtodxcnreuail[PS]fqevniubrjclstaxh[GS]kbqclfmnrowuzh[PS]cromfwbznhkluq[PS]cfrunokbmhzlqw[PS]ucmfbnwkolzqhr[PS]lcunfhmzkboqrw[GS]zabujhtvnkiwlprse[PS]rwbxgszjhfdotvinpela[PS]ivptyewzmhdcnjalsbqr[GS]m[PS]mocztn[GS]docyu[PS]uzdocmy[PS]ocfsdyrut[GS]n[PS]n[PS]n[PS]ng[GS]zntxuekvgasqjbhdcpywir[PS]bzpakvruhewjqiycdgtxsn[PS]dwgubaxqkvepizsnjrcyth[PS]sthxpekqviydwazujgrbcn[GS]e[PS]ke[PS]ydv[PS]e[PS]k[GS]ausdlnoefwzyrxbqmjiv[PS]hrsizvqnwmejofabguxld[PS]edmfjzlvoinxyqprwaus[PS]ievajdrlfkzqcstnouxwm[GS]dkxoaplqsbz[PS]zdrxpfltkobywasq[GS]hpcniyojgsztdlub[PS]litbsnghpojcyzdu[PS]jdhbycapzuwgtnlsio[PS]hbsiltzyudcpngjo[GS]jkbog[PS]uvgok[PS]vog[PS]xgieom[GS]f[PS]y[PS]y[GS]zoswvb[PS]swgbzdvot[PS]wsrezbvoc[GS]gdutplihzvfocxa[PS]zpqonktlyrucaidmfvh[PS]tuavsxdhfozlgciebjpw[GS]htydg[PS]tlg[PS]meygtd[PS]tqjrg[GS]zhugty[PS]tzghy[PS]ezysgth[GS]eirgsfbqmhoxkyj[PS]wkhfsoeibmjgqyxr[PS]qgokmyxeishjrfb[PS]dfbsuriyjogeqvhxmk[GS]u[PS]ubi[PS]u[PS]u[PS]u[GS]cvseaypi[PS]iycpve[PS]pveiyc[PS]ivycpe[GS]ojgxqrzpf[PS]qfzrgoijxp[PS]qojgrxfzp[PS]gropqxjzf[PS]jrgxfqzpo[GS]oswduz[PS]ozuswd[PS]wozusd[PS]wosdzu[GS]zepyf[PS]wpe[PS]dep[GS]ptsoviyubhefwdg[PS]eugbfwotdvspy[PS]dabcyetvufgpos[GS]gvwjbspykdzoarinteh[PS]hjrecqndygmabifp[GS]belwimkrtvhnzojau[PS]nvaqblwkreohsmtcz[PS]ovaxdmgnzbeykrtlhw[PS]kwzorvhnbplqtema[GS]yskfpmjebdich[PS]exzjvwsbipomqr[PS]ijsbutamfheldpc[GS]xowyihcmreuqldkjgv[PS]ymqlrhduocepkzijxwv[PS]wdyljroqshcvfekbmuitxz[PS]eiolxkjvqcwmuyhard[GS]rifsactz[PS]dtrlaspjefbicozn[PS]wfizahcvrqkts[PS]vmtfyhqacirszg[GS]jgbdalcpw[PS]putak[PS]dzacrwop[PS]gopadq[GS]scotnlhavpyjqmfgzk[PS]ygtocpjnzfvmlkqa[PS]qcjlytnkfozvmpag[GS]iu[PS]bu[PS]dul[PS]u[PS]u[GS]gadyx[PS]jti[GS]f[PS]f[GS]da[PS]pxa[GS]mgbskecwd[PS]wgcktmse[PS]sgecmtkw[PS]cekbwsmdg[PS]saegcfvkwm[GS]jm[PS]mj[PS]mj[PS]kmj[PS]mj[GS]bdkzv[PS]ftloezbkdvy[PS]zbvxdk[PS]bzwkdv[PS]vkdbszu[GS]btkesqymhzuwcpd[PS]tcaiwjxsg[PS]wsct[PS]tinwcs[GS]amqgrkjsv[PS]jsgmqzakro[PS]aksmqgjr[PS]arkmgsqj[PS]graqjmsk[GS]vwbjpyehxfrcguzlit[PS]efskqzadontm[GS]t[PS]t[PS]t[PS]t[PS]t[GS]mnos[PS]jdvsnfomx[PS]aosnm[GS]zoh[PS]znoh[PS]ohf[PS]kdhto[GS]zb[PS]bzn[PS]jzb[PS]jzb[PS]zbj[GS]jomtfxgs[PS]nkqytilrace[GS]mzkberyufodx[PS]ujnpckbhxroz[PS]lkbxorzui[PS]uqozrcjbkx[PS]zorbxuik[GS]hklmwxyvtdcpgoq[PS]vjgpxqaohmdlwktc[PS]xftwhlpvkqgdmoc[PS]xqdpotmvhfylcwgk[GS]ocu[PS]cou[PS]cou[GS]ijanryulhzg[PS]ujainhlszgr[PS]lagnhrizjk[PS]ahnrbdgizjlv[GS]vdnce[PS]dcqne[PS]dnejc[PS]nectd[GS]eifwmbdut[PS]mdftwiube[PS]tuinmwfdbe[PS]mfdwitbeu[GS]ipsbgk[PS]jsai[GS]sqtucpvhbimroydkfjxlaz[PS]azmdqcrefjyubkwhsotpv[GS]ygczbjvlrnk[PS]lgjivzc[PS]clsgpvdzjqm[PS]ohjvzlmcg[GS]savmyfxg[PS]xeyfsmag[PS]qmsxgyfrw[PS]xvfkmgyahs[GS]ynzsbet[PS]bsrtnzv[PS]bdjwzhamfnqk[PS]nzbciex[PS]nobzgvps[GS]gjmaqcdiebhupywzfltvko[PS]ktqibcuvalsmnghefyprdoj[GS]mvqwdhflazokj[PS]okfqwvdmelhzaj[PS]zvjwacmuloqiskgtdyh[PS]flnpwzxvhqjdmroka[PS]qzmoalwkhpvjd[GS]n[PS]h[PS]th[PS]fsoxd[GS]peqynb[PS]qepbyw[PS]qeprby[PS]bpqayvel[PS]qyabpe[GS]sykhfvwmgnutbeadql[PS]gtkmuflbndvwhsyeaqc[PS]djwftvybqumneskhgal[PS]skwtqbzrmhegulanydvfi[GS]fuz[PS]fuz[PS]uzf[PS]uzfx[PS]zuf[GS]yrpkxfnzbmgqwvsluoa[PS]psyulngqwrazvkfxemo[PS]pmqwxayzobklrugnfevs[PS]xrgqnsivfpwazlkuoym[PS]jsglfrdaqvomxypzwknu[GS]arm[PS]rnhamv[PS]tlabjmx[GS]rxpzbehywfuts[PS]xruyvzwbmsef[PS]ryebwfqgsuxz[PS]zsrxbeuwyf[GS]bufrwlvodngkmxitpha[PS]loufnmdtqrkabghxiwvep[PS]hdutjkmafzxnrgvowpbil[PS]kxuphaodvbirwfmtlgn[GS]hgdeptiafxsujklr[PS]dskupraelhxtfivgj[PS]tuegfxjshdkprlia[GS]ejsbfhcvnx[PS]frtecbvxnjszh[GS]iouylrj[PS]uojlxyri[PS]fyuoikjlrm[GS]bteiydmrh[PS]edmairhwftb[GS]iygeubcal[PS]biycheplzagu[GS]xnpmz[PS]ycnmzpbdq[PS]zmnpk[PS]pnzm[PS]pnzm[GS]wzlhmaoq[PS]wafiyomc[PS]ptgawvoer[GS]tpynexdwkolrfhqj[PS]hlnprfxoytqwdjek[PS]qxwkortdnyfhljpe[PS]wnqkjyfxdlohpret[GS]psjucnhrbefvzyl[PS]dnwzqmauglcti[PS]zqudiclnk[GS]sg[PS]sg[PS]gs[GS]phbydkeljnzaow[PS]ajnkzbcige[PS]eakbjrcqxnz[GS]sjcdoehzu[PS]ceuoshdjz[PS]djocseuzh[GS]nkxlgspidmhwzqeojv[PS]fnhwxuiktzmjogqvdl[GS]doirbfxv[PS]oxysdbufri[PS]dboixvf[PS]ifndxob[PS]moixzdfbj[GS]dtbmegpvux[PS]nlhcjayz[PS]onjfrsqkw[GS]lqpamhfudgjtv[PS]lgjudvhfqtpam[PS]vtaglfumdhqpj[GS]z[PS]iz[PS]z[PS]z[GS]dewlyguxtivcqb[PS]xleqbcitgvduwy[PS]lbtwegqkcivdxshyu[GS]yrxqbsonfcui[PS]oszafcntugd[GS]obke[PS]kbeo[PS]ebok[PS]obek[PS]eobk[GS]wtoxd[PS]odxwt[PS]odwtx[GS]kndxiqheltrpacwbu[PS]idekwaovchjpxrtbunql[PS]builrdxnpcehtjwsqa[PS]iuabpznqrlhfdtemycxw[PS]ebrxiuaqpclkdwgtnh[GS]itvghlycjnz[PS]hyjltiznvg[PS]wnjzmklhvgity[PS]bhyizgtjvnl[PS]gnjviylzth[GS]jzp[PS]uki[PS]revlhqgayn[PS]fsjt[PS]biw[GS]yadxckevlw[PS]wlkcvydx[PS]xkdwvlyc[GS]xqsw[PS]qsxw[PS]sxwq[PS]qxws[PS]wsqxf[GS]dmqyrznsoifej[PS]wyge[PS]gktlabye[GS]rnyqsv[PS]nqsrvjy[GS]zuw[PS]z[GS]fawqurvtmopkc[PS]kcmquvwptfoa[PS]komcuavqtwpf[PS]uaovkwpqfcmjt[PS]ocmwvfupqakt[GS]ztlsuyribvogcpme[PS]ouvmrltbescizypg[PS]gmsvutbeoylricpz[PS]zmgticyleusobprv[GS]pfhniyksrwcvduqogat[PS]knfgaviyqrcusodh[PS]rukvogciqfandsyh[PS]fkacsgyqdoivurhn[GS]q[PS]e[PS]m[GS]cbr[PS]rbc[PS]brc[PS]rbc[PS]brc[GS]zlps[PS]zpsl[PS]spzl[PS]zjlps[PS]zlsp[GS]zvi[PS]v[GS]skfw[PS]sw[GS]tuygxsjhiczeapmbvwkqn[PS]tenjiavpshbyckwmqzugx[PS]gtsqkmneacvbzdjophuixw[GS]tbl[PS]lsyzjmcg[GS]ntofwi[PS]tnofi[PS]itjeofn[GS]o[PS]l[PS]l[GS]qoaujcnksbpiwgtheryvfxmlz[PS]anvhyiscfoekqupglxrzdtmjb[PS]lxscnzkqofbyeuvtmrhgiapj[GS]rakhwzxtclnymgbsiej[PS]rcustiyeagmnxbzkhwl[PS]bnfrtwslzyhcexqkamig[GS]tbo[PS]tbevu[PS]bt[GS]zfkgeyjmuplqsrxdbwtvhconia[PS]bremfqgkdlvsuyxazwpntocjhi[PS]jbimlwsznaktxhvrfoygcepuqd[PS]jaedlpixsfomuhgwqrzctbyvkn[GS]bqskzjafrehwu[PS]akwsjufzebqh[GS]eqfmkpjztwrxhugbyn[PS]ghrbtmfuqypexjkwnz[PS]ebptfnqxhryujwmkzg[PS]juzewkctxqlfmhpygbrn[PS]tbhrgmyfxqnkuzpwej[GS]afqpvgjxehwdo[PS]jgzbeafwdophvx[PS]xkaesfvdhpjgmow[PS]zhpuveldxwgfqjao[PS]xjzadovrepfhgwy[GS]hzfwtimqxyl[PS]wfylhxtqzmi[PS]qtxfhzwlimy[PS]thimxwlfyqz[GS]gyikxanutzjvrhod[PS]xedlmbopwfcrtnyjsazq[GS]yhznowsvmiplc[PS]lyizcvohsnxmw[PS]nywacvmirfbzlsgh[PS]sczlmwynivh[GS]xbjzeyamohuftwirpl[PS]yqwgjurichlevfbz[GS]grzilwbosadunexh[PS]zswunredgtaobkhxpl[GS]hpqsuokcydmwl[PS]inewxzrg[PS]zwvjb[PS]wg[PS]watr[GS]hdkjnms[PS]bmdhjscnk[PS]xsijavqmoklpf[GS]jelhuczo[PS]xpojuhlbqzrt[GS]orkbs[PS]cbs[PS]mxdbij[PS]br[GS]mkpna[PS]kapn[PS]pnak[GS]rpdw[PS]pwdr[GS]qc[PS]qc[PS]cq[PS]cq[PS]qch[GS]umqepd[PS]ceapd[PS]xqdpelh[PS]pukedf[GS]vfkdrqcbumxoian[PS]cnwmukjvqrbodai[GS]tbeizdphysfxwrlaokuq[PS]ywzaqsprukdtbheoxil[PS]rvkieodhtqsupywxcazl[PS]hsdiwzeqoryulpktax[PS]axoqulrigtnwehsdkzypm[GS]gvfkhzwtlm[PS]zrsmwnbuie[GS]zrxtwfnqod[PS]fvloabkyirwzmn[GS]iltbsmy[PS]tliybms[PS]bylsitm[GS]k[PS]g[PS]voh[PS]pm[GS]yrdneovzfghxalmspuckt[PS]tqnikyerogxuhmfvpzla[GS]ylckwbrtmsjv[PS]tkjlvcqrfea[GS]twjumlapesnz[PS]pmeoazub[PS]pmabuoez[GS]xmgyd[PS]xdymg[PS]dxygm[PS]dgymx[PS]gxudcvmy[GS]v[PS]vw[PS]pvd[PS]vu[PS]v[GS]qwmfrncxb[PS]drjqglsakpwtbi";

            var byGroupByPeople = all
                .Split(new[] { "[GS]" }, StringSplitOptions.None)
                .Select(byGroup => byGroup.Split(new[] { "[PS]" }, StringSplitOptions.None).ToList())
                .ToList();

            var yesCount = 0;

            foreach (var group in byGroupByPeople)
            {
                var datasGroup = group.SelectMany(g => g).ToList();

                var result = datasGroup.GroupBy(k => k).Where(k => k.Count() == group.Count);

                yesCount += result.Count();
            }
        }

        private static void DayFive()
        {
            var list = new List<string>
            {
                "BBFBBBBRRL",
                "FBFFFFBLRL",
                "FBFBBFFRLR",
                "FBFFFBFRLR",
                "FFBBFFFLRR",
                "FFBBBFFRRR",
                "BFBBFBFLRL",
                "BFFFBFFLRR",
                "FBBBFFBLLR",
                "BBFFBBFRRL",
                "BFBBBBBRLR",
                "FBBBBFFLLR",
                "FFBFFFBLLR",
                "FFBBFBFRRR",
                "BBFBFFFRRR",
                "FFBFFBBLLR",
                "FBBFFBBLRL",
                "FFBBBFBLLL",
                "FFBFFBBLRR",
                "FBFFBFBLLR",
                "FFFBBBFLLL",
                "BFBBFBFRLR",
                "BBFBBBFLLL",
                "FBBBFBBRLL",
                "FFBBBBFRRL",
                "BFBBBBFLRR",
                "BBFBBFBLRL",
                "FFBFFFBLRL",
                "BFBBBBBRRR",
                "FFFBFBFLLR",
                "BFBFBBBLLR",
                "FFBFBBBLRL",
                "FFFBFBBLRR",
                "BFFBFFFLLL",
                "BFFFBFBLRL",
                "BFBFFFBRLL",
                "BBFFFFBRLR",
                "FBBFFFBLRR",
                "BFFFFBFLLL",
                "BBBFFFFLLL",
                "BFBFFBBRLL",
                "BBFBFFFRRL",
                "BFBBFFFRLR",
                "BBFBFBFRRL",
                "FBBFFBFRRL",
                "BFBFBFFRRL",
                "FFBFFFFLLR",
                "FBBBFBBLLR",
                "BBFFBFBRLL",
                "BFFBFBBRLL",
                "FBBFFFFRRR",
                "BFFFBBBLRL",
                "FFBBFFBLLL",
                "FFFBBFFRRL",
                "FBFBBBBLRR",
                "FFBBBFFLLL",
                "FBFBFFBRRR",
                "FBBFFBBLLR",
                "FBFFBFFRLL",
                "BFBBBFFRLR",
                "FBFFBBBLRR",
                "FBFFFFBRLR",
                "BBFFBBFLRL",
                "FBFFBBFLRL",
                "FBFBBFFRRR",
                "BFBBBFBLRL",
                "FBFBFFFLLR",
                "FFFFBBBLLR",
                "BFBFFBBLLR",
                "BFFBBBFRLR",
                "BFBBBFFLRR",
                "BBFFFBBLLR",
                "BFFFBBFLRL",
                "FBFFBFBLRL",
                "FBBBFFFRRL",
                "FBFFFFBLLL",
                "BFBFFBBRLR",
                "BFBFBBBLRL",
                "BFFBFBBRLR",
                "FBBFBBBLLR",
                "FFBFBFFRLL",
                "FFFBBBBLRR",
                "BFBFFFFLLL",
                "BBFBFBBLLR",
                "BFFFBBBRLR",
                "FFBFFBFRLR",
                "FBBFBBBLRL",
                "BBFFFBBLLL",
                "FFBFFBBRRR",
                "FBBBBFBLLR",
                "BBFBBFFRLL",
                "BFBBBBFRLR",
                "BBFBFFBRLR",
                "FFBFFFFLLL",
                "BBFBFBFRLL",
                "FFBFFBBRLL",
                "FBBFFFFRLR",
                "FFBBBBBRRR",
                "BBFFBBBLRL",
                "BFFBBFBRLL",
                "BFFFBBFRLL",
                "BFFBFBFLRL",
                "FBFFFFFRRR",
                "BFFBFBBRRL",
                "FBFBBBFLLR",
                "FBFBFBBRLL",
                "BBBFFFFRRR",
                "BFBFBFFLRL",
                "FFFFBFBRLL",
                "FFBBFFBLRL",
                "BBFFBFBLLL",
                "BFFBBBBRLL",
                "BFFBBBBRRR",
                "BFBBBBFRRL",
                "BBBFFFBLRL",
                "FFBBFFFRRR",
                "BFFFFFBRLR",
                "FFFBBFBLLL",
                "BFBFBBFRLR",
                "FBBBFBFLRL",
                "BFBFBFFRLR",
                "BBFBBFFLRL",
                "BFFFBFBLLL",
                "BFFFFBBRLL",
                "FFBFFFFRRL",
                "BFFBFBBLLR",
                "FFFFBBBLLL",
                "FBBFFBBRRL",
                "BFBFFFFLLR",
                "FBFBFBFRLL",
                "FBBBBBBLRR",
                "BBFFFFBLRR",
                "FFFFBFBRRR",
                "FBBBBFBRLL",
                "BBFBFBBLRR",
                "FFBBFBFLLL",
                "BFBBFFBLRL",
                "FFFBBBBRRR",
                "BFBBFFFRLL",
                "BFBBBFBRRR",
                "FFFFBBFRLR",
                "FFBBFBFLRR",
                "FFFFFBBLLR",
                "BBFBBFBRLL",
                "FBFBBBBRLR",
                "BBFFFFBLRL",
                "FBBFFFBLLR",
                "FFBFFBBLLL",
                "FFFBBBFLLR",
                "FFFBBBFRRR",
                "FFBBBFBRRR",
                "FFFBBFFRRR",
                "FFBBFFBLLR",
                "BFBFFBFRRR",
                "FFBFBBFLLR",
                "BFFFFFFRRR",
                "FFBFFBFLRL",
                "BFFBFBBRRR",
                "FBFBFFFRLL",
                "BBBFFFBLLL",
                "BFBBFBFRRL",
                "BFFFFFBLRR",
                "FBBBBBFRRR",
                "FFBBBBFLRR",
                "BBFBBBBLRR",
                "BBFBFBFLLR",
                "FFFFBBFRRR",
                "FFBBBBBLLR",
                "BFFFBFBRLR",
                "FBBBFFBLLL",
                "FFFFFFFRRR",
                "FFFBFBFRRL",
                "BFBBFBBLRR",
                "FBBBBFBLRL",
                "FBBBBFBRRR",
                "BFFFFBFRRR",
                "BFFBBFFLLL",
                "FBBFBFBLRL",
                "BFBBFFFRRL",
                "FBFBFFBRLR",
                "FBFFBFFLRR",
                "BFFFBFBLLR",
                "BFBBFFBRRR",
                "BBFBBFBLLL",
                "BFFBFFFLRR",
                "FFFBBFFRLL",
                "BFBBFFFLLL",
                "BFFFBBBRLL",
                "FBFFBBFRRR",
                "FFBFBFBLLR",
                "FBFFFFBLRR",
                "FFBBFFFLLL",
                "FFFBBBBRRL",
                "BBFBFFFLLL",
                "BBFFBBFLLR",
                "BFBFBBBRRR",
                "FBBBBFBRRL",
                "FBFFFBFLLR",
                "FBFBBBFRRR",
                "BFFFBFBRRL",
                "FBFBBBFLRL",
                "BBFFBFFLRL",
                "BBFBBFFLLR",
                "FFFFBFFRLL",
                "FFFBBBBLRL",
                "FBBBFBFRLL",
                "BBFFFBBLRL",
                "FFFBFFBLRR",
                "BBFBFBBRRL",
                "FFFFBBBRRR",
                "FFBBBBBLRL",
                "FFFFFFBLLL",
                "FBFFFFFRRL",
                "FFFFFBBLRR",
                "BFFFBBBRRL",
                "FBBFFFFLRL",
                "FFFFFBBRLR",
                "FFBFFBFRLL",
                "FFFBBBFRRL",
                "BFBBBFFLRL",
                "FFFFFBFLRR",
                "BFBFBBBRLR",
                "FBFBBBFLLL",
                "BFBFFBFLRL",
                "FFBFBFFRRR",
                "FFBBFFFRLL",
                "BFBFBFFLLL",
                "FBFBFBBRLR",
                "BFFBBBFRRL",
                "FBFFBBBRRR",
                "FBFBFBBLRR",
                "BFBBBBFLLR",
                "FFFBFFFRLR",
                "BFBBFFBRRL",
                "BFFFBFFLRL",
                "BFBFBBFRRR",
                "FBBFFBFLLL",
                "FFFFFFBLRR",
                "FBFFBFBLRR",
                "FFBBBFFLRR",
                "FBBBFFBRLL",
                "BFFFBBBRRR",
                "FFBFFFFRLL",
                "BBFFFBFRRR",
                "BFFBFBBLLL",
                "BFBBFFBRLR",
                "FFBFBBBLRR",
                "FFFBFBBLLL",
                "FFFBBFFLLL",
                "FBBBBBBLRL",
                "BFBFBBBLLL",
                "BFBFFFFRRL",
                "FFBFBBFRRR",
                "FFBFBFBRRL",
                "FFFBBBBRLL",
                "BFFBFFBRLL",
                "BBFFFFBRRL",
                "FFBFBFBLLL",
                "FFBFBFBRLL",
                "FBFBBBFRRL",
                "FBFFBBFRLR",
                "BBBFFFFLRL",
                "FBFBFFFRRL",
                "FFFBFBFRLR",
                "FBFBFBBRRL",
                "BFBBFBBLLL",
                "FFBBBBBRLL",
                "BBFFBFBRRL",
                "FFFBFFFRRR",
                "FBBFBFBLLL",
                "BFFFBFFRLR",
                "FBFBFFBRLL",
                "BBFBBFFLLL",
                "FBBBBFFLRR",
                "FFBBBFFLRL",
                "FBBBFFBRRR",
                "FFBBFBBRLR",
                "FBFBBFFLLR",
                "BFBBBFFLLR",
                "FFFBBFFLRR",
                "FBFFBFFLRL",
                "BFBFBFFLRR",
                "BBFBFFFLLR",
                "FFFBBBBLLR",
                "FFBBFFBRLL",
                "BBBFFFBRLL",
                "FBFFBFBRRL",
                "BFBFFFFRLL",
                "FBFBFBFRLR",
                "BBFFFFFLLL",
                "FFBFBBBLLR",
                "FFBFBFFLRR",
                "FBBBBFBRLR",
                "FFBFBBBRLR",
                "BFFBBBBLRL",
                "FFBBBBBRLR",
                "BFBBBFFRRR",
                "FBFBBFBRLL",
                "FFBFFFBRRL",
                "BBFBFBFLLL",
                "BFBBBFBRLR",
                "BFBBFBFLLR",
                "FBBFBFFRLL",
                "FFBFBBFLRR",
                "BFFBFBFRLL",
                "FFBBFBBLRL",
                "FBFBFBBLRL",
                "BBFFFBFLLR",
                "BFBFBBBLRR",
                "BBFFBBBLLR",
                "BBFFFFBRRR",
                "BFFFFFBLRL",
                "FBBBFBBRRR",
                "BFBFFFBLLL",
                "FFFBBFFLLR",
                "BFFBBFFLLR",
                "BBFBBBBLRL",
                "FBBFBFFLRR",
                "FBFBFFBLLR",
                "BFFFFFFLLL",
                "BFFBBFFRLL",
                "BBFFFFFLLR",
                "FBFFBBFRRL",
                "FBBFFFFLLR",
                "BFBFFBBRRL",
                "FFBFFFBLLL",
                "BFFFFFBLLR",
                "FFBBBFBRRL",
                "FFBBBBFLLR",
                "BFBFFFBLLR",
                "FFFFBFFRLR",
                "BFBBFFBRLL",
                "FFBBBBBLLL",
                "FBBFBFFRRR",
                "BFFFFFFLLR",
                "FFBBBBBLRR",
                "FFFFFBFRRR",
                "BFFFBBBLLL",
                "BFFFBFFRRR",
                "FFBBBFBRLR",
                "BFFBBBBLRR",
                "BFBBBFFRRL",
                "BFBFBFFRRR",
                "BFBBFBBRLR",
                "BFBBBBFRLL",
                "FFBBBBFLLL",
                "FFFBBFBLRR",
                "FBBFBBFRLR",
                "BBFBBFFLRR",
                "FBBFBBBRRL",
                "BFFBFFFRRL",
                "BFFFFBFLRR",
                "FFBFBBFLLL",
                "FFBFBBBLLL",
                "FBFFBFBRRR",
                "FFFBFFBRLL",
                "BFFFFBFLRL",
                "FFFFBFFLLR",
                "BBFBBBBRLL",
                "FBFBBFBRRR",
                "BFFFBBBLRR",
                "FBFFFBFRLL",
                "FFBBBFBLRL",
                "FBFFFBBLRR",
                "FFBBFBFRLR",
                "FBBBBBFLRL",
                "FFFFBFBLRR",
                "BFBFBFBLRR",
                "FFBBFFFLRL",
                "BFFBBBFLLR",
                "FFFFFFBRLR",
                "FFBBBFBLRR",
                "FBFBBFFRLL",
                "BBFBFBFRLR",
                "FBBFFFFLLL",
                "BFBBFBFRRR",
                "BFFBBBFRRR",
                "FBFFFBFLRR",
                "FBBFFBFLRL",
                "BFBBFFFLRR",
                "FFBFFFFLRL",
                "BFFBFFBLLL",
                "FFFBFBBRRR",
                "BBFFBFFLRR",
                "BBBFFFFRRL",
                "FBBBFFBLRL",
                "FBBFFBBLRR",
                "FFBFBFFLLR",
                "FFFBBFFRLR",
                "FBBBFBBRLR",
                "FFFFBBBLRR",
                "BBFFBFBRRR",
                "FBFBBFFLRL",
                "FBBBBFFLLL",
                "FFBFFBBRLR",
                "BBFFFFFLRR",
                "FFBFBFBRLR",
                "FFBFBFBLRL",
                "FBBBFBBLRL",
                "FFFBFBBLRL",
                "FBFBFFFRRR",
                "BFFBFFFRLR",
                "BFBBFFBLLR",
                "BFBFFBFRLL",
                "FBFBFBFRRR",
                "FBFFFFBRLL",
                "FFFFFBBRRR",
                "FBBBFFFLRL",
                "FFFBFFBRLR",
                "BFBFFBFLRR",
                "FBBFBBFRRL",
                "BFBBBBFRRR",
                "BFFFFBBLRR",
                "FBFFFFFLLL",
                "BFBFFFBRRL",
                "FFFBFFBLRL",
                "FFBFFFBLRR",
                "FBBFFBFRLL",
                "BBFBFFBLLL",
                "BBFFBBFLLL",
                "FFBBBFFRLL",
                "BFBBFFFLRL",
                "FBBFBFFLLR",
                "FBFBFFBLLL",
                "FFBBBFFLLR",
                "FBBFFBFLRR",
                "FBBFBBFRRR",
                "BFFFFBBLLL",
                "FFFBFFBLLR",
                "FBFBFFFRLR",
                "FBFBFBBRRR",
                "FBFBBFBRRL",
                "BBFBBFBRRR",
                "FFFFBBBRLL",
                "FBFFBBBLRL",
                "BBBFFFFRLL",
                "FBFFFBFLRL",
                "BFFFFBFLLR",
                "FBFBBFFRRL",
                "BFFBFBBLRR",
                "FBFBBBBRRL",
                "FBFBFBBLLR",
                "FBFFBBFLRR",
                "FFFFBFFLLL",
                "BFBFFFFRRR",
                "BBFFBBBLRR",
                "FBFFFFFLLR",
                "BBFBFFFRLR",
                "BFFFFBBRLR",
                "FBFFFFFLRL",
                "FBBBFBBLRR",
                "BFFBBFBLLL",
                "BFFBFBBLRL",
                "BFFBBBFRLL",
                "FFBFFBFRRR",
                "BFBFBFBRLL",
                "BBFBBFBLLR",
                "FBFBBFBLRL",
                "FBFFFBBRLR",
                "BBFBFFBRLL",
                "BBFFFBFRLR",
                "FBBFFFBLLL",
                "BBFBBBBLLL",
                "BFFFFFFLRR",
                "FBBBBBFRLL",
                "BFFFBFBRRR",
                "BFFFFFFLRL",
                "FBBBBFBLRR",
                "FBFFBBBRLR",
                "FFBBFBFRRL",
                "FFBBFBBRRL",
                "FFFBFBFRRR",
                "FFBBBBFLRL",
                "BFBBFFFRRR",
                "FBFBBBBRLL",
                "FBFFBBFRLL",
                "FFBFFFFRRR",
                "BFFFFBBLLR",
                "FBFBBFBLLR",
                "BBFFBBBRRR",
                "FBBFBBBRLR",
                "BFBFBFFRLL",
                "BFFBBFBLRL",
                "BFFBFFFRRR",
                "FFBBBFBRLL",
                "FBFFBFFRRL",
                "FBBBBFFRRR",
                "FFFBBBFRLL",
                "BBFFFBBRLL",
                "BBFFFBBRLR",
                "FFBBFFFRRL",
                "BBFFBFBLRR",
                "BBFBFFBRRR",
                "BFBBBBBLRR",
                "BFFBBFFLRL",
                "BBFFFFBLLL",
                "FFFFBFBRRL",
                "FBBFFBBRRR",
                "FBBBFFFLRR",
                "FBBFBBFLRR",
                "FBBBFBBLLL",
                "FFFFBBFLRL",
                "FFFFFBBLLL",
                "BFBBBBBLLR",
                "BFBFFFFLRR",
                "FBFFFFBLLR",
                "BBFFBBBRLL",
                "FBFFBFFRRR",
                "FFBBFBFLLR",
                "BBFBBBFLRR",
                "FBBBBBBRLL",
                "FFFFFFBLLR",
                "FFFFFBFRLR",
                "FBFFBFBRLL",
                "BBFFBFFRRR",
                "BFFBFFFLLR",
                "FFBBFBBLRR",
                "BBFFBBBRLR",
                "FFBBFFBRRL",
                "FBBBBFFRRL",
                "BFBFFFFRLR",
                "BFBBBFBLLL",
                "BFBFFFBRRR",
                "FBBBFFFRLR",
                "BFBBFFBLRR",
                "BBFBBFFRLR",
                "BBFFFBBRRR",
                "FFFFBBBRRL",
                "FFBFBBFRLL",
                "FBFFFFBRRL",
                "FBBBFFBRLR",
                "FFBFFFBRRR",
                "FBBBBBBLLL",
                "BFFBFFBLRL",
                "FBFFBBBRLL",
                "BBFBBBFRLR",
                "BFBFBFBRLR",
                "BBFFFFBRLL",
                "FFBBFBBLLR",
                "FFBBFFBRLR",
                "BBFBBBBRLR",
                "BFBBBFBLLR",
                "FFFFBFFRRR",
                "BBFFFBFRRL",
                "FBBFBBBLLL",
                "FFFBFFFLRL",
                "BFFFFBBRRR",
                "FFFBFBFLRL",
                "BBFFBBFRRR",
                "FBBFFFFLRR",
                "FFFBBBFLRL",
                "BFFBBBFLLL",
                "BFBBFFBLLL",
                "FFFFFFBLRL",
                "FBFFBFFLLL",
                "FBBBBBBRRR",
                "FBBFFBBRLR",
                "BFFFBBBLLR",
                "BBFBBBBRRR",
                "BFBFBFFLLR",
                "BFBFFBFRLR",
                "FBBBFFFRRR",
                "FFBFBBFRLR",
                "FFFFFBFRLL",
                "FFBFBBBRRR",
                "BFBFFBBLLL",
                "FBBBBBFRLR",
                "FFBBFBBLLL",
                "BFBFFBBLRL",
                "FBBFBFBRRL",
                "BFFBBBBRRL",
                "FBBFFFBLRL",
                "FBBFBFBLLR",
                "FBBFBBBLRR",
                "BFBBBFBRRL",
                "FBBBFBFLLL",
                "BFFFBFFLLR",
                "FBBBFBFLRR",
                "FFBFFBBLRL",
                "BBFBBBBLLR",
                "BFFFBFFLLL",
                "FBFFFFFLRR",
                "BBFBFBBLRL",
                "BFBFBBFRRL",
                "FBFBFFBLRR",
                "BFFFFFFRRL",
                "BFFFFBFRLR",
                "BFBBFBBRLL",
                "BBFFFFFRLL",
                "FFBBFFFLLR",
                "FFFBFFFLRR",
                "FFFBFFBRRR",
                "BBFBFFBLLR",
                "BFFBFFFRLL",
                "FBFBFFBRRL",
                "BFBBBFFLLL",
                "BBFFBFBLRL",
                "FBFBBFFLRR",
                "FBBFBBBRRR",
                "FFFBBFBRLL",
                "FBBFBFBRRR",
                "BFFFBBFLLL",
                "FBBBFFBLRR",
                "BFBFFBBRRR",
                "FFFFFFBRLL",
                "BBFFFBFLRL",
                "BFBFBFBRRR",
                "BFFFBBFRLR",
                "BFBFFFBLRR",
                "FFFBFFBRRL",
                "BBFFFBBRRL",
                "BFBBBFBRLL",
                "BFBFFFBLRL",
                "FFFBFFFLLR",
                "BFFBFFFLRL",
                "BBFBBFBLRR",
                "FBBBFBBRRL",
                "FBBFBFFRLR",
                "FBFFFFFRLR",
                "FBBBBFFRLR",
                "BFBFBBFRLL",
                "BBFBFBFRRR",
                "BFBFBFBRRL",
                "FBBBBBBRLR",
                "BFBFBBFLLR",
                "BFFFBBFRRL",
                "BBBFFFFRLR",
                "BBBFFFBLLR",
                "FBFBBBFLRR",
                "FBFFFBBLRL",
                "FBFFBBBLLR",
                "BFBFBBFLRR",
                "BFBBFBBLRL",
                "BFFFFFBRRL",
                "FFBBFFFRLR",
                "BFFBBFFRLR",
                "BFBFBFBLRL",
                "BFFBFBFRLR",
                "FFBBFFBRRR",
                "BFBBBBBLLL",
                "BBFFFFFRRL",
                "BBFFFFFLRL",
                "FFFBBFFLRL",
                "BFBBFBFRLL",
                "FFFBBBBLLL",
                "FFFFFBFLRL",
                "FFFFBBFLRR",
                "FBFFFBFRRR",
                "BFFBBBBLLL",
                "BBFBBFFRRL",
                "BFFFBBFLLR",
                "FBBBFFFLLL",
                "FFBFFBBRRL",
                "BFBBBFBLRR",
                "BFFBBBFLRL",
                "BFBBBBBRLL",
                "FFFBBBFRLR",
                "FFFFBFFRRL",
                "FFBFBFFLLL",
                "BBFBFFFLRL",
                "BFFFBBFLRR",
                "FFFBFBFRLL",
                "BFBFFBBLRR",
                "FFFBFBBLLR",
                "BBFFFFFRLR",
                "FFBFBFFRRL",
                "FFFFFBBLRL",
                "FBBBFBFRRL",
                "FBBBBFBLLL",
                "FFFFBBBRLR",
                "FBBBBFFLRL",
                "BFBBBBBRRL",
                "BBFFBFBLLR",
                "FBFBFFFLRL",
                "FBFFFBFRRL",
                "FFFBBFBLRL",
                "BFFFFFBLLL",
                "BFFBFBFLLL",
                "FFFFBBFRRL",
                "FFFBFBBRLR",
                "FBFBBBBRRR",
                "FBFFBBBLLL",
                "FFBBBBFRRR",
                "BFFFFBFRLL",
                "BBFBFBBRLR",
                "BFFBBBFLRR",
                "FBBFBFFRRL",
                "FFFFFBFLLL",
                "BBFBFBFLRR",
                "FFBFBBFLRL",
                "BFFBBFBRLR",
                "FFBBBFFRLR",
                "FFFBBFBRLR",
                "FBFBBBBLLR",
                "BFFBBBBLLR",
                "BBFBFBFLRL",
                "BBFFFFFRRR",
                "FFFBFFFRRL",
                "FBBFFBFRRR",
                "BBFFBFFRLL",
                "FFBBFBFRLL",
                "FFFFBFBLLR",
                "BBFFBBFRLL",
                "BFBBBBFLRL",
                "FBFFBFFRLR",
                "BFBFBBFLLL",
                "FFFFBBFLLL",
                "BFBBBBBLRL",
                "FFBFBFBLRR",
                "BFFFFFBRRR",
                "FBFBBBBLRL",
                "FBBFBBFLLR",
                "FBBFFFFRRL",
                "FBFFFBFLLL",
                "FBFFBBBRRL",
                "FFBFFFFRLR",
                "FBBFBBBRLL",
                "FFFFBFBRLR",
                "FFBFBBBRRL",
                "BFFBFBFRRL",
                "FFBFFBFLLL",
                "BFFBFBFLRR",
                "BBFBFFBLRL",
                "BBFFBFFLLR",
                "BFBBBBFLLL",
                "BBFBBFFRRR",
                "BBFFFBBLRR",
                "BFBFFBFRRL",
                "FBBFBFBLRR",
                "BBFBBBFRRR",
                "FFFBBFBLLR",
                "FFFBFFFLLL",
                "FBBBFBFLLR",
                "BFBBFBFLLL",
                "BFBFBFBLLL",
                "BBFFBBFLRR",
                "FFFBFBFLRR",
                "BFFFFFFRLR",
                "BBFBFBBRRR",
                "BBFFFBFRLL",
                "FFFFBBFRLL",
                "FBBFBBFRLL",
                "FBFFFFBRRR",
                "FBFFBBFLLR",
                "BFFBFFBLLR",
                "FFBFFBFLRR",
                "FBFFBFBRLR",
                "FBFBBFFLLL",
                "FBBFFFBRRL",
                "FBFBFBFRRL",
                "FFBFBFBRRR",
                "FBFBFBFLRL",
                "FFFBFBBRLL",
                "FBBBFFFLLR",
                "FFBBBBFRLL",
                "FBFFFBBRLL",
                "BFFBFFBLRR",
                "FBBFBBFLRL",
                "FBFFFBBRRR",
                "FBFFFBBLLR",
                "BFFBFFBRRR",
                "FBBBFBFRRR",
                "FBFFFFFRLL",
                "BBFBBBFRLL",
                "FFFBFFBLLL",
                "FFBFFFFLRR",
                "FBFFFBBRRL",
                "BBFFBFFRLR",
                "FBFBFBBLLL",
                "FBBBBBBLLR",
                "FBFBBFBLLL",
                "BBFBFFFLRR",
                "BFFFFBBRRL",
                "BBFFFBFLRR",
                "FFBFFFBRLL",
                "FFFFBBBLRL",
                "BFBBBFFRLL",
                "BBFBFFFRLL",
                "FBFBBBBLLL",
                "BBFBBFBRLR",
                "BBFFBFBRLR",
                "BFBFFFFLRL",
                "FBBBFBFRLR",
                "FFBFFFBRLR",
                "FBBBBBFLLR",
                "FFBBBFBLLR",
                "BFFBBFBRRL",
                "BBFFBFFRRL",
                "FFFFFFBRRR",
                "FFBBFBBRRR",
                "FBBBBBBRRL",
                "BFFBBFFRRL",
                "FBBFBFBRLR",
                "FBBFFFFRLL",
                "FBBBBBFLLL",
                "FBBFFFBRRR",
                "BFFFFBBLRL",
                "FFFFBFBLLL",
                "FBFBFFFLLL",
                "FBFBBFBLRR",
                "FFFFBFFLRR",
                "FFFBBBFLRR",
                "FBFFBFFLLR",
                "BBFFBFFLLL",
                "FFBFFBFRRL",
                "BFBBFBBRRR",
                "BBFFFBFLLL",
                "FBFFBFBLLL",
                "BFFBFFBRRL",
                "BBFBFFBLRR",
                "FBFBFFFLRR",
                "BFBBFBBLLR",
                "BFFBBFFRRR",
                "FFFFFFBRRL",
                "BBBFFFFLLR",
                "BFBFFBFLLL",
                "FBBBBBFRRL",
                "BFFBBBBRLR",
                "FFBBFBFLRL",
                "FBFBFFBLRL",
                "FFBBBBFRLR",
                "BBFBBFBRRL",
                "FFFFFBFLLR",
                "FBFBFBFLLL",
                "BFBFBFBLLR",
                "FFFBFFFRLL",
                "BFFBBFBLLR",
                "FFBBFBBRLL",
                "FFFBBFBRRL",
                "FBBFFBBLLL",
                "FFFBBBBRLR",
                "FFFBBFBRRR",
                "BBFFBBBRRL",
                "FBBFBFFLRL",
                "FBBBBBFLRR",
                "BBFBFFBRRL",
                "FFFBFBFLLL",
                "FBBBFFFRLL",
                "BFFBFBFLLR",
                "FFBBBBBRRL",
                "BFFBBFFLRR",
                "FBBFBFBRLL",
                "BFFFBFFRRL",
                "BBFFFFBLLR",
                "BBFFBBFRLR",
                "BFFFBBFRRR",
                "FBFBBFBRLR",
                "FFFFFBBRLL",
                "FBBFFFBRLL",
                "BFFFFFBRLL",
                "BFFFBFBLRR",
                "BFFBFFBRLR",
                "FFFFBFBLRL",
                "FFBFFBFLLR",
                "FBBFBFFLLL",
                "BFFBFBFRRR",
                "BBFBBBFLRL",
                "BBBFFFFLRR",
                "BFBBFFFLLR",
                "FBBFFFBRLR",
                "FFFFFBFRRL",
                "FFFBFBBRRL",
                "BBBFFFBLRR",
                "FFBFBBFRRL",
                "FFBBFFBLRR",
                "BBFFBBBLLL",
                "BFBFBBBRRL",
                "BFFFBFBRLL",
                "FFBFBBBRLL",
                "FBFBFBFLRR",
                "FBFFFBBLLL",
                "FBBFFBFLLR",
                "BFFFFBFRRL",
                "FFBBBFFRRL",
                "FFBFBFFLRL",
                "BBFBBBFLLR",
                "FBBFFBFRLR",
                "FBBFFBBRLL",
                "BFBFFFBRLR",
                "BFFFBFFRLL",
                "BBFBFBBRLL",
                "BFFFFFFRLL",
                "FBFBBBFRLL",
                "BFBBFBFLRR",
                "BFBFBBBRLL",
                "BBFBBBFRRL",
                "BFFBBFBRRR",
                "BFBFFBFLLR",
                "FBFBFBFLLR",
                "FFFFFBBRRL",
                "FBFBBBFRLR",
                "FBFFBBFLLL",
                "FFBFBFFRLR",
                "BBFBFBBLLL",
                "FFFFBFFLRL",
                "FBBFBBFLLL",
                "BFBFBBFLRL",
                "FFFFBBFLLR",
                "BFBBFBBRRL",
                "FBBBFFBRRL",
                "FBBBBFFRLL"
            };

            var ids = new List<int>();

            foreach (string board in list)
            {
                string rowInfo = board.Substring(0, 7);
                string colInfo = board.Substring(7);

                (int, int) rangeRow = (0, 127);
                (int, int) rangeCol = (0, 7);

                foreach (var c in rowInfo)
                {
                    int currentHalf = (rangeRow.Item2 - rangeRow.Item1) / 2;
                    if (c == 'F')
                    {
                        rangeRow = (rangeRow.Item1, rangeRow.Item1 + currentHalf);
                    }
                    else if (c == 'B')
                    {
                        rangeRow = (rangeRow.Item1 + currentHalf + 1, rangeRow.Item2);
                    }
                    else
                    {

                    }
                }

                foreach (var c in colInfo)
                {
                    int currentHalf = (rangeCol.Item2 - rangeCol.Item1) / 2;
                    if (c == 'L')
                    {
                        rangeCol = (rangeCol.Item1, rangeCol.Item1 + currentHalf);
                    }
                    else if (c == 'R')
                    {
                        rangeCol = (rangeCol.Item1 + currentHalf + 1, rangeCol.Item2);
                    }
                    else
                    {

                    }
                }

                ids.Add((rangeRow.Item1 * 8) + rangeCol.Item1);
            }

            var max = ids.Max();

            var match = -1;
            for (int i = 0; i < max; i++)
            {
                if (!ids.Contains(i))
                {
                    if (ids.Contains(i - 1) && ids.Contains(i + 1))
                    {
                        match = i;
                    }
                }
            }
        }

        private static void DayFour()
        {
            var codes = new string[]
                        {
                "byr", "iyr", "eyr", "hgt",
                "hcl", "ecl", "pid"
                        };

            var passports = new List<string>
            {
                "eyr:2021 hgt:168cm hcl:#fffffd pid:180778832 byr:1923 ecl:amb iyr:2019 cid:241",
                "hcl:#341e13 ecl:lzr eyr:2024 iyr:2014 pid:161cm byr:1991 cid:59 hgt:150cm",
                "iyr:2018 eyr:2027 hgt:153cm pid:642977294 ecl:gry hcl:#c0946f byr:1999",
                "pid:#534f2e eyr:2022 ecl:amb cid:268 iyr:2028 hcl:2b079f byr:2008 hgt:185cm",
                "byr:2000 hgt:161cm ecl:blu eyr:2030 pid:647793597 hcl:#a97842 iyr:2011",
                "hcl:#3e335d hgt:75cm iyr:2010 byr:1940 ecl:#e0f130 pid:434016528 cid:138 eyr:2017",
                "hcl:#6b5442 cid:185 hgt:163cm eyr:2023 pid:510706612 byr:2001 ecl:amb iyr:2019",
                "hcl:#6b5442 byr:1942 eyr:2022 iyr:2016 pid:969898152 ecl:amb",
                "ecl:blu pid:734638153 byr:1968 hcl:#733820 eyr:2020 hgt:160cm iyr:2019",
                "iyr:2014 eyr:2020 byr:1996 hgt:158cm ecl:oth pid:920487833 hcl:#888785",
                "byr:1948 hcl:#341e13 cid:117 pid:802002577 hgt:188cm eyr:2028 ecl:blu iyr:2010",
                "pid:9572562 hgt:65cm ecl:#ac200e iyr:2028 byr:2002 eyr:2031 hcl:z",
                "byr:2024 hcl:#866857 ecl:dne eyr:2031 pid:#a28d39 iyr:1920 hgt:158in",
                "pid:023850020 hgt:163cm iyr:2017 byr:1966 cid:145 ecl:grn eyr:2027 hcl:#ceb3a1",
                "hcl:z byr:2008 eyr:2020 ecl:#e810c9 hgt:76cm pid:0485860220",
                "hgt:154cm hcl:#fffffd ecl:grn byr:1929 iyr:2019 pid:868514160 eyr:2026",
                "cid:181 byr:1991 eyr:2026 hgt:166cm hcl:#cfa07d iyr:2010 ecl:hzl pid:248467397",
                "eyr:2036 hgt:60cm byr:2023 ecl:#7f7a50 iyr:1964 hcl:z pid:189cm cid:233",
                "ecl:#8b23b5 iyr:1940 hcl:#341e13 pid:806874850 hgt:150cm eyr:2033 byr:1930",
                "hcl:#efcc98 ecl:#cf8dd0 byr:1939 hgt:75cm eyr:2023 pid:7912576181 iyr:2014",
                "cid:282 hcl:#18171d ecl:blu pid:475471726 hgt:158cm byr:1948 eyr:2030 iyr:2018",
                "eyr:2030 iyr:2013 pid:843774570 hgt:186cm ecl:amb byr:1961 hcl:#7d3b0c",
                "cid:239 eyr:2021 pid:814286281 ecl:gry byr:1945 iyr:2016 hcl:#efcc98 hgt:167cm",
                "byr:1931 hcl:#cfa07d pid:148883217 iyr:2011 hgt:172cm eyr:2026 ecl:gry",
                "hcl:z eyr:2037 ecl:#bbb299 iyr:2015 byr:1931 hgt:186in pid:8019203964",
                "hgt:178 hcl:bf28b4 eyr:2028 ecl:zzz pid:184cm byr:1935 iyr:2017",
                "cid:195 byr:1936 eyr:2028 hgt:168cm hcl:#a69e3b pid:836680712 ecl:amb iyr:2020",
                "hgt:65in pid:580748663 eyr:2028 iyr:2018 ecl:amb hcl:#866857 byr:1969",
                "iyr:2021 hcl:94dc65 eyr:2027 byr:2011 pid:172cm ecl:#84a05a hgt:72cm",
                "pid:138102285 hcl:#efcc98 iyr:2019 ecl:grn cid:270 byr:1969 hgt:187cm eyr:2027",
                "eyr:2022 hgt:151cm pid:505032844 ecl:brn iyr:2020 hcl:#cfa07d byr:1965",
                "hcl:#7d3b0c ecl:blu eyr:2024 pid:7946112272 iyr:2010 cid:337 hgt:180in byr:2011",
                "hgt:65in iyr:2011 pid:774065195 eyr:2020 ecl:brn byr:1993 hcl:#c0946f",
                "ecl:blu hgt:65in iyr:2014 hcl:#6b5442 byr:1948 pid:672157135",
                "hcl:#2e5fe2 hgt:182cm byr:1989 cid:205 iyr:2010 pid:116603730 eyr:2020 ecl:oth",
                "ecl:zzz iyr:2029 pid:152cm hcl:z hgt:67cm eyr:2032 byr:1942",
                "iyr:2012 hgt:180cm byr:1951 pid:777840558 cid:324 eyr:2029 ecl:blu hcl:#341e13",
                "hcl:z cid:320 byr:1995 eyr:2022 pid:#0830f1 hgt:63 ecl:#9db56f iyr:2017",
                "eyr:1996 iyr:2018 ecl:gmt hgt:182cm pid:523450129 hcl:#6660a6 cid:76 byr:1959",
                "iyr:2013 pid:427856678 eyr:2027 cid:146 ecl:hzl hgt:171cm",
                "eyr:2027 hgt:158cm pid:54529307 hcl:z ecl:hzl byr:2018 iyr:1980",
                "iyr:2010 eyr:2026 ecl:amb hcl:#a97842 pid:404930776 cid:277 byr:1994 hgt:184cm",
                "eyr:2028 hgt:150cm pid:#534041 iyr:2022 hcl:#733820 cid:130 ecl:blu byr:1963",
                "ecl:blu hgt:160cm hcl:#ceb3a1 byr:1951 eyr:2029 pid:655280714 iyr:2020",
                "cid:248 byr:1966 iyr:2017 eyr:2025 ecl:blu pid:930670644 hcl:#866857",
                "ecl:amb eyr:2028 cid:308 byr:1951 hgt:183cm pid:260537189 iyr:2011 hcl:#cfa07d",
                "byr:1993 hcl:#7d3b0c pid:787304941 iyr:2017 eyr:2024 hgt:178cm cid:314 ecl:hzl",
                "ecl:#62c438 hcl:915943 iyr:1958 pid:1027793033 byr:2015 hgt:90 eyr:2035",
                "hcl:#b6652a eyr:2028 ecl:gry hgt:168cm byr:1921 pid:130528933 iyr:2020",
                "eyr:2023 pid:675106386 ecl:brn byr:2021 iyr:2011 hgt:153cm hcl:#888785",
                "iyr:2010 pid:586165419 eyr:2023 ecl:gry hgt:169cm hcl:#623a2f byr:1993",
                "iyr:2015 pid:332903175 eyr:2021 hgt:154cm hcl:#733820 ecl:gry byr:1951",
                "hcl:e58fa1 byr:1932 ecl:dne cid:272 eyr:2026 hgt:175cm iyr:1936 pid:408053740",
                "iyr:2013 hgt:151cm pid:151cm hcl:#888785 byr:2014 cid:207 eyr:2023 ecl:#51625d",
                "iyr:2016 cid:112 ecl:amb pid:727316519 eyr:2020 byr:1947 hcl:#ceb3a1 hgt:180cm",
                "eyr:2036 hcl:z ecl:gmt pid:11080111 byr:1972 hgt:161in iyr:2030",
                "iyr:2013 ecl:gry eyr:2030 hcl:#602927 byr:1968 hgt:160cm pid:888357737",
                "eyr:2026 pid:259305913 iyr:2012 hgt:166cm ecl:amb byr:1951 hcl:#b6652a",
                "byr:1939 hgt:158cm cid:232 eyr:2022 ecl:amb hcl:#fffffd pid:312632405 iyr:2016",
                "ecl:amb hgt:166cm pid:138763305 hcl:#a97842 byr:1972 eyr:2020 iyr:2020",
                "hgt:155cm hcl:#733820 byr:2010 pid:138766753 ecl:grt eyr:2032 cid:50 iyr:2002",
                "eyr:2029 ecl:gry iyr:2013 byr:1924 hgt:181cm hcl:#fffffd pid:194780722 cid:216",
                "eyr:2020 pid:1817301064 hcl:#b6652a ecl:grn iyr:2014 byr:2000 hgt:171cm",
                "hcl:#03f240 iyr:2017 ecl:oth byr:1921 pid:464020404 eyr:2025 cid:348 hgt:179cm",
                "cid:284 hcl:23f681 pid:190cm iyr:2023 eyr:2032 hgt:61cm ecl:#6da9d9 byr:2029",
                "hgt:175cm byr:1959 ecl:amb eyr:2030 cid:315 hcl:#ceb3a1 pid:795101457 iyr:2013",
                "eyr:2027 hgt:170cm cid:100 ecl:grn iyr:2011 hcl:#d6b2ee pid:760346767 byr:1950",
                "eyr:2014 hcl:#a97842 ecl:blu pid:5560121737 hgt:73in iyr:2010",
                "byr:1945 hcl:#7d3b0c eyr:2024 ecl:brn iyr:2013 pid:433715275",
                "eyr:2022 ecl:gry byr:1982 hcl:#6b5442 iyr:2019 pid:650096889 hgt:65in",
                "iyr:2010 ecl:oth hgt:154cm eyr:2024 cid:122 hcl:#341e13 byr:1929 pid:264796724",
                "eyr:2026 cid:225 byr:1928 pid:479832664 hcl:#cfa07d iyr:2020 hgt:192cm ecl:gry",
                "pid:460595787 hgt:157cm iyr:2018 ecl:oth hcl:#ceb3a1 eyr:2021",
                "iyr:2018 pid:787208686 hgt:178cm cid:118 hcl:#ceb3a1 ecl:oth eyr:2030 byr:1949",
                "hcl:#efcc98 byr:1934 hgt:175cm ecl:oth iyr:2019 cid:326 pid:337273951 eyr:2024",
                "hcl:#6b5442 pid:422717762 iyr:2010 ecl:gry eyr:2024 hgt:165cm byr:1950",
                "pid:712203563 eyr:2023 hgt:151cm iyr:2010 byr:1950 hcl:#ceb3a1 ecl:grn",
                "hcl:#888785 eyr:2020 iyr:2016 hgt:191cm byr:1927 pid:848960326 ecl:hzl",
                "byr:1999 iyr:2016 hgt:62in hcl:#7d3b0c eyr:2028",
                "cid:195 iyr:1957 eyr:2023 byr:1993 hgt:176cm pid:316550627 hcl:68f2e3 ecl:amb",
                "hcl:#623a2f pid:780723069 byr:1936 cid:271 eyr:2022 hgt:188cm iyr:2017 ecl:grn",
                "eyr:2021 pid:209774111 hgt:192cm hcl:#6b5442 ecl:amb iyr:2018 byr:1983",
                "hcl:#edeee4 byr:2001 cid:68 pid:717560044 ecl:hzl eyr:2030 iyr:2016 hgt:191cm",
                "eyr:1968 cid:222 ecl:gry pid:90867093 hcl:#866857 iyr:2026 hgt:72 byr:1965",
                "eyr:2028 hgt:152cm pid:759034572 iyr:2017 hcl:#a97842 ecl:brn cid:168 byr:1987",
                "hcl:453e20 eyr:2011 ecl:gry hgt:75cm byr:1994 pid:41067436 iyr:2024",
                "ecl:blu hgt:61cm byr:1988 eyr:2022 iyr:2020 pid:219813481 hcl:#ceb3a1",
                "pid:635783992 byr:1950 eyr:2029 hgt:182cm hcl:#c0946f ecl:oth",
                "iyr:2016 ecl:amb pid:393320246 hgt:156cm hcl:#fffffd byr:1988 eyr:2028",
                "pid:689161094 hcl:#623a2f iyr:2011 eyr:2020 byr:1953 hgt:153cm ecl:brn",
                "hgt:185cm hcl:#ceb3a1 pid:751921928 iyr:2019 ecl:grn eyr:2028 byr:1943",
                "hcl:#b6652a eyr:2025 iyr:2016 ecl:hzl hgt:169cm byr:1931 pid:486548422",
                "hgt:160cm pid:49931386 ecl:gry iyr:2010 eyr:2021 hcl:#341e13 cid:64 byr:1933",
                "byr:1927 pid:415362434 ecl:gmt eyr:2028 hgt:153cm hcl:#18171d iyr:2017 cid:163",
                "byr:1949 pid:427698686 eyr:2027 iyr:2018 ecl:hzl hgt:159cm hcl:#ceb3a1 cid:132",
                "hcl:#7d3b0c iyr:2013 byr:2023 eyr:2037 cid:83 ecl:#05c60a hgt:160 pid:429836535",
                "hgt:174cm eyr:1937 pid:149685914 byr:2004 iyr:2017 hcl:#623a2f cid:303 ecl:blu",
                "hgt:60cm pid:47770642 byr:2020 eyr:2032 ecl:#cc7bc6 cid:144 iyr:2025 hcl:z",
                "iyr:2010 ecl:amb pid:#5f3343 hcl:#733820 eyr:2021 byr:1933 hgt:169cm",
                "hcl:#efcc98 hgt:172cm eyr:2020 ecl:oth byr:2001 pid:027554330 iyr:1983 cid:165",
                "byr:2026 hgt:158cm iyr:2016 hcl:#733820 ecl:hzl cid:117 eyr:2037 pid:37781880",
                "hcl:#602927 cid:248 byr:1999 hgt:181cm eyr:2029 pid:554270506 iyr:2016 ecl:blu",
                "byr:1952 iyr:2014 ecl:oth hcl:#cfa07d hgt:186cm pid:875655050 eyr:2024",
                "eyr:2030 hgt:186cm hcl:#18171d pid:038705513 ecl:grn cid:100 byr:1927 iyr:2015",
                "cid:98 eyr:2022 byr:1957 ecl:grn hgt:182cm pid:607781478 hcl:#ceb3a1",
                "eyr:1977 iyr:2021 hgt:178cm cid:186 byr:2026 pid:#b15551 ecl:utc hcl:z",
                "pid:334408791 hgt:158cm hcl:#6b5442 cid:83 byr:1983 iyr:2012 ecl:grn eyr:2030",
                "eyr:2028 iyr:2015 ecl:amb pid:352112783 cid:345 byr:1938 hgt:71in hcl:#6b5442",
                "byr:2028 pid:380227894 eyr:2025 ecl:blu hgt:189cm hcl:a51656 iyr:1956",
                "hgt:184cm iyr:2016 ecl:hzl pid:485327910 hcl:#fffffd byr:1970 eyr:2027",
                "byr:1992 iyr:2018 eyr:2030 hcl:#888785 hgt:168cm pid:535221295 ecl:blu",
                "hgt:165cm hcl:#fffffd byr:1961 ecl:gry pid:639998127 eyr:2028 iyr:2011",
                "hgt:74in iyr:2015 cid:284 pid:035643775 byr:1978 hcl:#623a2f ecl:grn eyr:2023",
                "byr:1954 ecl:#16e7c4 hgt:164cm eyr:2029 iyr:2015 pid:377679333 hcl:#a97842 cid:233",
                "eyr:2026 pid:266604186 byr:1981 ecl:brn iyr:2012 hgt:156cm hcl:#c0946f",
                "cid:189 hcl:z ecl:#40f51a hgt:180cm iyr:2014 pid:0942329667 byr:1946 eyr:2025",
                "eyr:2020 hgt:165cm byr:1961 iyr:2013 hcl:#888785 ecl:blu pid:156cm",
                "cid:126 hcl:#623a2f pid:153152767 hgt:163cm ecl:grn eyr:2030 iyr:2020 byr:1959",
                "byr:1935 pid:990549858 hcl:#623a2f ecl:blu iyr:2012 cid:160 eyr:2028 hgt:172cm",
                "hcl:111b82 byr:1955 pid:765740335 hgt:150cm ecl:amb iyr:2019 eyr:1937",
                "hgt:59cm byr:2023 eyr:2032 pid:652161761 cid:61 ecl:brn iyr:2011 hcl:#623a2f",
                "byr:1951 eyr:2023 iyr:2017 hcl:#18171d ecl:brn cid:306 pid:446746225 hgt:187cm",
                "hgt:160cm ecl:blu pid:855958582 byr:1988 hcl:#6f97ba iyr:2016 eyr:2026",
                "iyr:2010 byr:1948 cid:336 ecl:hzl eyr:2030 pid:475243853 hgt:175cm hcl:#ceb3a1",
                "hgt:168cm eyr:2021 ecl:oth hcl:#229bb0 iyr:2016 byr:1949 pid:720804107",
                "iyr:2011 eyr:2025 ecl:gry cid:330 byr:1927 pid:699837182 hcl:#b6652a hgt:161cm",
                "byr:1988 eyr:2026 ecl:gry hgt:162cm pid:924306872 iyr:2013 hcl:#888785",
                "byr:1934 ecl:brn pid:0774345729 iyr:1964 hcl:z hgt:170in cid:262",
                "eyr:2028 byr:1989 iyr:2014 ecl:blu pid:388512489 hcl:#7bc6b9 cid:212 hgt:187cm",
                "byr:1960 pid:#e494ee eyr:2026 hgt:192cm hcl:a82f5a iyr:1999 ecl:#89848d",
                "byr:2006 pid:#3bac86 cid:297 hcl:55d36e iyr:1985 ecl:#538688 eyr:1923",
                "ecl:hzl iyr:1925 eyr:2030 pid:1231954396 hgt:154cm byr:2009 hcl:#c0946f",
                "hgt:63in pid:229535785 ecl:oth hcl:#9e34cd iyr:2020 eyr:2021 byr:1943 cid:73",
                "hgt:63cm hcl:z byr:2029 eyr:1928 pid:4559542479 cid:258 iyr:2024 ecl:#7058ad",
                "ecl:hzl hcl:z pid:146884476 iyr:2011 cid:158 byr:1991 eyr:2030 hgt:156cm",
                "byr:2030 iyr:2017 pid:19198146 hcl:#7d3b0c ecl:#af1431 eyr:2023 hgt:74cm",
                "hcl:#6b5442 hgt:168cm eyr:2020 cid:260 byr:1920 ecl:hzl",
                "byr:1971 cid:186 hgt:60 eyr:2022 pid:160cm hcl:z iyr:2013 ecl:blu",
                "hcl:#7d3b0c cid:218 eyr:2022 pid:015062066 ecl:hzl iyr:2010 hgt:170cm byr:2001",
                "iyr:1984 byr:2027 eyr:2033 hcl:94d9ab hgt:148 ecl:gmt cid:288 pid:160cm",
                "hcl:#74c9e7 eyr:2026 hgt:168cm byr:1994 ecl:brn pid:651587465",
                "hgt:160cm ecl:gry cid:182 byr:1929 pid:890454205 hcl:#efcc98 eyr:2029 iyr:2020",
                "ecl:brn hgt:156in eyr:2022 cid:289 iyr:2022 hcl:e34ec4 pid:#206e1c byr:1938",
                "eyr:2030 pid:99239063 cid:166 hgt:153cm hcl:0a3633 byr:1990 iyr:2024 ecl:grn",
                "byr:2019 hgt:189cm hcl:#cfa07d iyr:1927 ecl:#bafabd pid:161cm eyr:2024",
                "hcl:#ceb3a1 iyr:2010 hgt:163cm eyr:2020 pid:948123697 ecl:brn byr:1973",
                "pid:691623749 iyr:2016 hcl:#18171d byr:1972 eyr:2030 hgt:173cm ecl:hzl",
                "hcl:#ceb3a1 cid:271 iyr:2010 byr:1977 hgt:161cm eyr:2022 pid:460185976 ecl:hzl",
                "eyr:2028 ecl:hzl cid:98 pid:828517281 hgt:154cm iyr:2016 hcl:#866857 byr:1924",
                "hgt:99 iyr:2030 byr:2003 eyr:2039 pid:184cm ecl:lzr cid:71 hcl:z",
                "eyr:2029 pid:864807599 iyr:2013 hcl:#866857 ecl:grn byr:1961 hgt:185cm",
                "hcl:#866857 hgt:66in ecl:oth iyr:2018 eyr:2026 cid:170 byr:1999 pid:538451102",
                "iyr:2024 byr:2015 cid:271 pid:69951601 hgt:190cm ecl:xry eyr:2003 hcl:#c0946f",
                "hgt:178cm hcl:#ceb3a1 byr:1942 pid:583281865 iyr:2015 eyr:2020 ecl:grn",
                "eyr:2020 hcl:#866857 ecl:oth hgt:153cm cid:212 byr:1972 iyr:2012 pid:198849319",
                "ecl:blu cid:222 hgt:174cm hcl:#866857 byr:1971 iyr:2016 eyr:2030",
                "ecl:blu pid:521480106 iyr:2020 eyr:2027 byr:1942 hcl:#733820 hgt:153cm cid:106",
                "cid:57 pid:685649434 eyr:2026 hcl:#efcc98 ecl:grn iyr:2013 byr:1968 hgt:157cm",
                "cid:63 pid:195592844 hcl:#efcc98 byr:1980 ecl:gry iyr:2016 eyr:2023 hgt:178cm",
                "hcl:z byr:2024 hgt:179cm iyr:2017 eyr:1998 ecl:#d087a7",
                "pid:673581655 eyr:2023 byr:1924 hcl:#18171d ecl:blu hgt:187cm iyr:2015 cid:69",
                "byr:1979 eyr:2020 pid:925293477 ecl:amb cid:145 hcl:#1fc76d hgt:188cm iyr:2013",
                "pid:833495286 hcl:#cfa07d ecl:brn byr:1993 eyr:2020 cid:209 hgt:165cm iyr:2018",
                "hgt:181cm hcl:#efcc98 pid:264709463 iyr:2019 eyr:2026 cid:313 byr:1926 ecl:gry",
                "pid:798909144 iyr:2015 ecl:brn hgt:183cm hcl:#623a2f byr:1979 eyr:2023",
                "cid:257 ecl:grn pid:203787314 hcl:#fffffd iyr:2020 hgt:192cm byr:1964",
                "pid:15955243 eyr:1962 byr:2012 hgt:155cm iyr:2025 hcl:z",
                "cid:126 hgt:156cm byr:1936 pid:495593265 ecl:brn hcl:ee357b iyr:2030 eyr:2014",
                "pid:182cm eyr:2022 ecl:#c8bb8a iyr:2021 byr:1922 cid:270 hcl:#866857 hgt:190cm",
                "eyr:2030 byr:1963 cid:224 ecl:gry iyr:2020 hgt:192cm hcl:#8117b1 pid:845227725",
                "byr:2028 pid:168cm eyr:1989 ecl:blu hcl:311389 hgt:173cm cid:227 iyr:2015",
                "byr:1949 hcl:#a97842 hgt:162cm pid:100263539 eyr:2027 ecl:grn iyr:2015",
                "ecl:#6f9669 eyr:2033 byr:2003 hcl:z iyr:2019 pid:223282429 hgt:172",
                "pid:#8bc2c0 hgt:74cm ecl:zzz hcl:5afd12 eyr:1922 byr:2019 iyr:1924 cid:50",
                "hcl:#66518f hgt:187cm byr:1989 eyr:2027 iyr:2018 ecl:blu pid:656263178",
                "pid:257605814 iyr:2013 eyr:2026 ecl:grn hgt:170cm byr:2018 hcl:e9d195",
                "ecl:grt byr:2010 eyr:2033 pid:35619145 iyr:2025 hgt:64cm hcl:z cid:221",
                "eyr:1997 pid:221307345 hgt:120 iyr:2019 ecl:zzz byr:2009 hcl:#fffffd",
                "hgt:192cm byr:1932 cid:213 hcl:#ceb3a1 ecl:oth iyr:2018 eyr:2023 pid:232126505",
                "iyr:2020 cid:225 eyr:2025 pid:456238536 byr:1932 hcl:#fffffd ecl:oth hgt:170cm",
                "eyr:2023 pid:113720753 hgt:173cm hcl:#efcc98 ecl:blu byr:1977 iyr:2010",
                "hcl:#866857 pid:240698984 byr:1973 ecl:amb iyr:2014 hgt:159cm eyr:2020",
                "eyr:2026 iyr:2019 pid:150506583 byr:1984 cid:249 ecl:brn hgt:176cm hcl:#18171d",
                "iyr:2012 hgt:189cm byr:1970 pid:152682317 eyr:2025 cid:315 ecl:oth hcl:#6b5442",
                "hgt:167cm eyr:1923 hcl:4a53cb pid:392236104 iyr:2018 ecl:gry byr:1922",
                "byr:1966 hgt:191cm iyr:2011 cid:167 ecl:brn eyr:2024 hcl:#29000d",
                "byr:1964 hgt:177 eyr:2037 pid:4494972428 hcl:#7d3b0c ecl:utc cid:205 iyr:2019",
                "hcl:#cfa07d iyr:2028 pid:165cm ecl:#e2a3e0 cid:147 eyr:2025 hgt:169in byr:2010",
                "hgt:162cm hcl:#866857 eyr:2024 byr:1962 iyr:2020 pid:246010906 ecl:oth",
                "pid:145361253 ecl:brn iyr:2019 eyr:2025 hcl:#ceb3a1 hgt:164cm byr:1938",
                "hgt:157cm ecl:#f6feaa iyr:2015 hcl:#623a2f cid:290 eyr:2034 pid:058787629",
                "hcl:#ceb3a1 iyr:2011 pid:468547313 cid:175 byr:1991 eyr:2021 hgt:158cm ecl:blu",
                "ecl:hzl eyr:2026 pid:448134141 hgt:186cm iyr:2016 byr:1929 hcl:#c0946f",
                "hgt:64cm eyr:2027 ecl:#277bd0 hcl:df2be7 iyr:2023 pid:167286554 byr:2004",
                "pid:739664020 eyr:2026 hgt:61in iyr:2011 byr:1959 ecl:grn hcl:#602927",
                "eyr:2039 hgt:183cm hcl:z pid:5208130216 ecl:blu cid:161 iyr:1932 byr:2004",
                "iyr:2015 pid:509173428 eyr:2030 ecl:#14471f hcl:z hgt:177in byr:1994",
                "byr:1951 iyr:2012 hcl:#733820 pid:799059999 hgt:70in eyr:2026 ecl:hzl",
                "eyr:2028 byr:1925 hgt:181cm ecl:grn iyr:2016 hcl:#cfa07d pid:558448804",
                "pid:675014385 iyr:2012 ecl:oth hgt:183cm hcl:#623a2f byr:1997 eyr:2026 cid:311",
                "eyr:1972 hcl:c452d2 ecl:gmt byr:2010 iyr:2015 hgt:66cm cid:266 pid:021900882",
                "ecl:gry hgt:65in cid:182 hcl:#c0946f pid:558235233 eyr:2027 byr:1946 iyr:2017",
                "hcl:#b6652a pid:846441761 iyr:1971 hgt:59cm eyr:2027 byr:2010 ecl:amb cid:144",
                "cid:77 hgt:180in eyr:2024 hcl:b6c2c6 pid:159cm iyr:2002 ecl:#62e506 byr:1976",
                "iyr:1969 eyr:2024 cid:143 pid:#f31765 ecl:brn hgt:68cm hcl:7f9598 byr:1949",
                "byr:1964 hcl:#341e13 ecl:gry hgt:168cm eyr:2028 iyr:2012 pid:714678484",
                "hgt:185cm eyr:2028 hcl:#b6652a byr:1945 iyr:2012 ecl:hzl",
                "iyr:2015 hgt:191cm ecl:blu hcl:#888785 pid:206356787 eyr:2021 byr:1920",
                "eyr:1937 hcl:b3eb9c hgt:175cm iyr:2012 ecl:brn pid:62490997 cid:267 byr:2024",
                "hcl:#866857 byr:1960 pid:021105433 hgt:174cm eyr:2022 iyr:2017 ecl:blu cid:123",
                "hcl:#ceb3a1 byr:1976 pid:306207321 iyr:2019 cid:262 hgt:175cm eyr:2025 ecl:oth",
                "byr:1945 cid:346 eyr:2030 hcl:#1f6f6f iyr:2013 hgt:65in pid:857729755 ecl:blu",
                "byr:1934 ecl:oth hgt:174cm eyr:2030 cid:263 hcl:#47e20e pid:545880650",
                "pid:190920088 byr:1995 hcl:b4f162 iyr:2019 ecl:gry eyr:2020 hgt:176cm",
                "byr:1984 hcl:#7d3b0c pid:947573713 hgt:154cm ecl:blu eyr:2023 iyr:2017",
                "hcl:#ceb3a1 pid:645117349 cid:213 eyr:2022 ecl:brn iyr:2017 hgt:151cm byr:1997",
                "byr:1929 hcl:#18171d hgt:184cm pid:378639521 ecl:amb iyr:2018 eyr:2022",
                "pid:567411452 hgt:158cm byr:1998 eyr:2030 iyr:2013 hcl:#fffffd ecl:grn",
                "iyr:1962 pid:184cm eyr:2034 cid:62 ecl:gry hcl:z hgt:156in",
                "eyr:2022 byr:2015 pid:193cm ecl:#ca25ab hcl:eb0dfc cid:136 hgt:150cm iyr:1977",
                "pid:087678152 hcl:#ecdb8b hgt:162cm iyr:2015 eyr:2024 byr:1939 ecl:grn",
                "eyr:2024 hgt:150cm iyr:2023 ecl:#ca3855 hcl:#888785 byr:1943 pid:4402658120",
                "pid:107396492 hcl:#341e13 hgt:145 ecl:oth iyr:2013 eyr:2025 cid:128 byr:2023",
                "eyr:2020 hgt:167cm byr:1997 hcl:#888785 ecl:oth pid:609333522 iyr:2017",
                "pid:172cm eyr:1930 iyr:1966 ecl:#f98bd9 hgt:179in hcl:a1d424",
                "ecl:hzl byr:1924 iyr:2018 eyr:2020 pid:505733566 hcl:#733820 hgt:151cm",
                "eyr:2011 pid:176cm hgt:163in iyr:1964 hcl:z ecl:#9e90ad byr:2010",
                "ecl:brn iyr:2011 pid:932000043 byr:1995 eyr:2025 hgt:150cm hcl:#6b5442",
                "pid:347820679 iyr:2010 ecl:#aa4902 hcl:56faf0 hgt:70cm byr:1923 eyr:2024",
                "ecl:blu hgt:160cm iyr:2015 pid:706725204 byr:1987 eyr:2030 hcl:#cfa07d",
                "hcl:#763a5b iyr:2011 byr:1965 pid:834192733 cid:302 ecl:blu eyr:2028 hgt:170cm",
                "byr:1967 hgt:193cm ecl:hzl pid:598436934 cid:262 iyr:2014 hcl:#b6652a eyr:2021",
                "pid:336728648 eyr:2030 hcl:#888785 hgt:150cm ecl:hzl byr:1926 iyr:2015",
                "pid:073366341 byr:1984 hcl:#cfa07d iyr:2019 hgt:178cm ecl:grn eyr:2026",
                "iyr:1923 pid:19933565 ecl:#16b3c1 hgt:162 eyr:1945 hcl:e0e20c byr:2028",
                "hgt:159in pid:171cm eyr:2023 iyr:2022 ecl:#c073e6 hcl:22ed05 byr:2011",
                "byr:2003 eyr:2022 cid:336 ecl:grt iyr:2020 hgt:156cm hcl:#c0946f pid:716113144",
                "ecl:hzl iyr:2019 hgt:171cm hcl:#9855d4 byr:1974 eyr:2025 pid:260661320",
                "hgt:165cm byr:2016 pid:203313454 iyr:2011 hcl:z ecl:blu eyr:2023",
                "eyr:2016 hgt:182cm iyr:2029 byr:2004 ecl:gmt hcl:25d3a1 pid:4435010716",
                "ecl:blu pid:159928755 hgt:177 hcl:74fd3f eyr:2023 cid:244 byr:1956 iyr:2016",
                "hcl:#c5c154 iyr:2011 ecl:gry byr:1971 hgt:75in cid:251 eyr:2025",
                "eyr:2023 hgt:155cm byr:1943 iyr:2020 ecl:amb hcl:#ceb3a1 pid:591194126",
                "cid:123 byr:1950 iyr:2022 hgt:154cm ecl:hzl pid:555951199 hcl:#efcc98 eyr:2022",
                "cid:145 iyr:2028 hgt:163 byr:2007 ecl:#ca0e61 pid:#b57087 eyr:1985 hcl:#b6652a",
                "ecl:utc iyr:1953 eyr:2034 hcl:#602927 cid:150 pid:166cm hgt:72cm byr:2003",
                "iyr:2012 pid:585191659 byr:1959 eyr:2027 hgt:150cm ecl:blu hcl:#888785",
                "ecl:#483899 eyr:2032 pid:#4d59f7 iyr:2020 byr:2005 hcl:a8a13c hgt:140",
                "ecl:brn pid:#8d9fe0 cid:265 byr:2029 hgt:68cm iyr:1989 hcl:4df783 eyr:1990",
                "cid:110 hgt:165cm ecl:grn iyr:2017 eyr:2025 byr:1923",
                "byr:1986 iyr:2020 hgt:69in pid:815979778 hcl:#ceb3a1 eyr:2027 ecl:blu",
                "pid:345227220 eyr:2030 byr:1954 ecl:hzl hcl:#733820 hgt:151cm iyr:2016",
                "hgt:152 byr:2016 ecl:grt hcl:z eyr:1994 pid:463925189 iyr:2013",
                "hcl:#341e13 hgt:169cm byr:1990 iyr:2015 ecl:blu eyr:2034 pid:120750202",
                "iyr:2020 pid:589274468 byr:1995 ecl:blu eyr:2025 hgt:168cm hcl:#888785",
                "hcl:#888785 hgt:169cm iyr:2016 byr:1930 ecl:grn pid:864871732 eyr:2022",
                "eyr:2021 cid:73 hgt:186cm hcl:#8092f6 byr:1957 pid:151353277 ecl:blu iyr:2018",
                "hcl:5afb32 byr:2027 pid:179cm cid:222 hgt:59cm ecl:grt eyr:2040 iyr:1980",
                "hcl:#a97842 pid:403342198 eyr:2026 byr:1976 ecl:gry hgt:150cm iyr:2015",
                "hgt:63in eyr:2023 hcl:#6b5442 pid:371994667 iyr:2020 byr:1991 ecl:gry",
                "pid:247978507 hgt:175cm iyr:2016 eyr:2022 byr:1945 hcl:#b6652a ecl:gry",
                "hgt:150cm cid:254 hcl:#18171d ecl:blu eyr:2030 byr:1922 pid:450204714 iyr:2015",
                "iyr:2016 pid:470585547 hgt:60in eyr:2024 byr:1946 ecl:oth hcl:#b6652a",
                "iyr:2020 eyr:2026 hcl:#cfa07d pid:524717559 hgt:99 cid:303 byr:1967 ecl:amb",
                "cid:178 byr:2021 hcl:7234f4 hgt:192in eyr:2038 iyr:2020 pid:466801711 ecl:amb",
                "pid:597934488 iyr:2011 cid:336 hcl:#81434f ecl:grt hgt:185cm eyr:2034 byr:2014",
                "eyr:2038 byr:2017 hgt:70cm cid:283 ecl:brn pid:392669975 iyr:2013 hcl:#602927",
                "pid:#c85b65 hgt:60cm iyr:2001 eyr:2035 hcl:e28fae ecl:#32a45c byr:1924",
                "iyr:2011 byr:1945 hgt:164cm ecl:gry eyr:2029 hcl:#18171d pid:402905843",
                "pid:5602590426 byr:2013 eyr:2024 ecl:zzz iyr:2014 hgt:173cm hcl:#733820",
                "ecl:hzl eyr:1964 pid:508473248 byr:1961 hgt:181cm iyr:2020 hcl:#623a2f",
                "hcl:z hgt:121 pid:635654838 eyr:2020 iyr:1968 byr:1954",
                "byr:1974 pid:759133744 iyr:2010 eyr:2027 cid:266 ecl:hzl hgt:153cm",
                "ecl:oth byr:1960 eyr:2022 iyr:2014 hgt:62in hcl:#623a2f pid:155340768",
                "hgt:187cm hcl:#866857 pid:725526503 cid:134 iyr:2017 ecl:grn byr:1982 eyr:2020",
                "hgt:154cm byr:1953 ecl:blu pid:212064297 cid:69 eyr:2022 hcl:#c0946f iyr:2015",
                "ecl:gry hgt:183cm iyr:2017 pid:995219023 eyr:2025 byr:1960 hcl:#7d3b0c",
                "byr:1935 ecl:oth cid:235 pid:978368915 hcl:#b6652a iyr:2019 hgt:69in eyr:2028",
                "iyr:2005 eyr:2028 hgt:192in hcl:#9ced60 byr:2004 pid:102299023 cid:348 ecl:hzl",
                "hcl:6cbe91 pid:191cm iyr:1962 byr:2007 hgt:192in eyr:1963",
                "pid:020385831 hgt:173cm ecl:amb hcl:fdbb66 cid:287 eyr:2034 byr:2024 iyr:2018",
                "eyr:2024 byr:1952 hgt:186cm cid:250 pid:852070008 ecl:blu hcl:#c0946f iyr:2010",
                "ecl:#914e86 pid:164cm hgt:170cm iyr:2011 byr:2014 eyr:2026 hcl:z",
                "byr:1952 hgt:176in hcl:#e49400 pid:011105160 eyr:2026 cid:103 ecl:oth iyr:2011",
                "ecl:#362113 hgt:155in pid:859337122 cid:133 eyr:2025 byr:1997 iyr:2012",
                "ecl:hzl eyr:2025 iyr:2013 pid:669359650 byr:1922 hcl:#efcc98 cid:149 hgt:169cm",
                "iyr:2028 hgt:177in cid:75 eyr:2036 byr:2007 pid:48265132 ecl:zzz hcl:z",
                "hgt:66in eyr:2030 hcl:#623a2f iyr:2010 pid:458699137 byr:1980 ecl:amb",
                "hgt:171cm ecl:amb iyr:2011 hcl:#888785 byr:1923 eyr:2020 pid:312162952",
                "byr:1963 hcl:#18171d pid:316505921 ecl:blu iyr:2017 hgt:155cm eyr:2029",
                "ecl:gry byr:1973 iyr:2011 pid:479606625 eyr:2028 hcl:#888785 cid:108 hgt:160cm"
            };

            int passportsValid = 0;
            foreach (var passport in passports)
            {
                var kpvList = new Dictionary<string, string>();
                foreach (var p in passport.Split(' '))
                {
                    var split = p.Split(':');
                    kpvList.Add(split[0].ToLowerInvariant(), split[1].ToLowerInvariant());
                }
                if (codes.All(c => kpvList.ContainsKey(c)))
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
        }

        private static void DayThree()
        {
            var fullList = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                new List<int> { 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0 },
                new List<int> { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1 },
                new List<int> { 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0 },
                new List<int> { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0 },
                new List<int> { 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                new List<int> { 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0 },
                new List<int> { 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1 },
                new List<int> { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
                new List<int> { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1 },
                new List<int> { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1 },
                new List<int> { 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1 },
                new List<int> { 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
                new List<int> { 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1 },
                new List<int> { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0 },
                new List<int> { 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1 },
                new List<int> { 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                new List<int> { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0 },
                new List<int> { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 1 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0 },
                new List<int> { 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 1 },
                new List<int> { 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1 },
                new List<int> { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1 },
                new List<int> { 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1 },
                new List<int> { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1 },
                new List<int> { 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0 },
                new List<int> { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1 },
                new List<int> { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
                new List<int> { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1 },
                new List<int> { 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1 },
                new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                new List<int> { 0, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1 },
                new List<int> { 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0 },
                new List<int> { 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0 },
                new List<int> { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                new List<int> { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                new List<int> { 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0 },
                new List<int> { 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1 },
                new List<int> { 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                new List<int> { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1 },
                new List<int> { 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0 },
                new List<int> { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
                new List<int> { 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1 },
                new List<int> { 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new List<int> { 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0 },
                new List<int> { 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0 },
                new List<int> { 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0 },
                new List<int> { 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0 },
                new List<int> { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0 },
                new List<int> { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1 },
                new List<int> { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1 },
                new List<int> { 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
                new List<int> { 0, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                new List<int> { 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
                new List<int> { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0 },
                new List<int> { 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1 },
                new List<int> { 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1 },
                new List<int> { 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1 },
                new List<int> { 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                new List<int> { 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                new List<int> { 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0 },
                new List<int> { 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 1, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0 },
                new List<int> { 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0 },
                new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1 },
                new List<int> { 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1 },
                new List<int> { 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
                new List<int> { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0 },
                new List<int> { 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1 },
                new List<int> { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                new List<int> { 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
                new List<int> { 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0 },
                new List<int> { 1, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new List<int> { 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                new List<int> { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1 },
                new List<int> { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                new List<int> { 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
                new List<int> { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1 },
                new List<int> { 0, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0 },
                new List<int> { 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0 },
                new List<int> { 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0 },
                new List<int> { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0 },
                new List<int> { 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1 },
                new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1 },
                new List<int> { 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                new List<int> { 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0 },
                new List<int> { 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new List<int> { 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1 },
                new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0 },
                new List<int> { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
                new List<int> { 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0 },
                new List<int> { 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0 },
                new List<int> { 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 },
                new List<int> { 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
                new List<int> { 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0 },
                new List<int> { 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0 },
                new List<int> { 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                new List<int> { 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0 },
                new List<int> { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0 }
            };

            var combos = new List<(int right, int down)>
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2),
            };
            var trees = new List<int>();

            foreach (var (right, down) in combos)
            {
                int treeCount = 0;
                int currentRight = 0;
                int lastIndexByRow = fullList[0].Count - 1;
                for (int i = 0; i < fullList.Count; i += down)
                {
                    if (fullList[i][currentRight] == 1)
                    {
                        treeCount++;
                    }
                    currentRight += right;
                    var diffRight = lastIndexByRow - currentRight;
                    if (diffRight < 0)
                    {
                        currentRight = Math.Abs(diffRight) - 1;
                    }
                }

                trees.Add(treeCount);
            }
        }

        private static void DayTwo()
        {
            var baseList = new List<string>
            {
                "14-15 v: vdvvvvvsvvvvvfpv", "3-11 k: kkqkkfkkvkgfknkx", "6-10 j: jjjjjjjjjj", "5-10 s: nskdmzwrmpmhsrzts", "13-15 v: vvvvvvkvvvvjzvv", "11-13 h: hhhhhbhhhhdhhh", "14-15 r: rrrrrrrrzrrrrrtl", "2-9 c: llhctjgbz", "13-15 s: ssssxssssssssjs", "6-8 c: lccccqcc", "8-9 n: nnnnnmnch", "4-5 n: jnnnmmpxngbrknzb", "4-7 n: knlnqnnndnn", "13-18 g: ggggggggnggggggggggp", "5-6 m: mmmmgm", "5-10 l: lvlllglllpll", "7-12 z: pszgzqzzzzkw", "1-2 j: pjjqw", "15-16 n: nnnnnnnnnnnnnnpn", "8-14 z: mzzzjzzzzhzzzztznzz", "5-19 q: rnsdfgkqlqjdvrmtsqqh", "1-5 f: ffffff", "4-5 h: hhhhh", "1-7 g: cglgjgflgggxv", "2-3 g: gggpg", "2-8 m: gbsmqmmmsmh", "1-2 j: jjhkmqr", "10-12 s: sssstsstpsssssp", "9-15 k: tkbkkknkcnkgwkfkkkpk", "6-7 m: mmmmmmmm", "6-7 s: lsspssss", "9-13 k: kkgjrvkkkkkkmkkkkzd", "3-5 m: lbmmmzpwm", "2-12 x: xxgwxxtbttcxzmlfwx", "10-13 k: kkkkvkkkkkgkwkzkkkk", "10-12 t: ttdftttttrtqt", "4-8 z: zbzzzzzz", "8-11 g: gctgdgwtspgg", "2-5 l: lllvl", "4-5 f: fwdspfmtts", "5-8 z: zzhzmzzdzzz", "11-12 x: xxxxwxxxxxxx", "17-18 h: hhhhhhhhhhhhhhhhqm", "9-14 j: jtkjwxjgjjjjjzjq", "5-6 p: ddgdbkpdsd", "2-5 c: xczcczc", "6-15 t: ttgjktpwqthftfrt", "13-16 t: tttttttttttttttq", "9-11 t: tgttttttftttc", "4-9 z: zzmzzzzzzzzzc", "5-8 d: sddtvddb", "5-6 l: llllpd", "15-16 s: sssssssssssssssb", "14-16 p: ppppppppppppppph", "2-10 r: mjnczrrnlnv", "9-10 s: ssspsssssrd", "3-5 d: dddddq", "2-3 v: llfv", "7-12 n: dnnnlnbnnnncn", "5-6 g: gsgggg", "5-9 t: tltbtttttt", "1-20 r: rtqtcmmgzfqmxtxqhdrn", "2-6 l: hlkkll", "4-6 c: cwccccc", "3-4 c: gcrdcz", "1-8 v: vvlvdgpvg", "6-17 g: gjccgdglgzgtcggdx", "1-17 l: nlczbmbrwcvgtjmcvcq", "5-11 z: nzppckcknfwllzzzrpp", "6-11 s: smsdjvsssss", "3-4 t: cttt", "1-4 q: tbcq", "2-4 m: jmmmmm", "2-8 h: hhhhhhhm", "9-11 h: phrhhhvhchqhmhh", "6-9 v: vvvvvmvvrvvvvv", "1-2 f: nxfgjfffp", "5-8 w: wwwwtnckwd", "6-12 x: xxnxscxkxxtf", "8-11 l: lllllllllstmllllll", "9-11 p: ppppppppvtfpp", "5-17 f: ffvwffpkfjffbtlfnftl", "2-6 b: gbbgbbbbrbxk", "8-9 t: trtftttttt", "13-17 r: rrgrrvrrrrrbrrzrqr", "10-11 k: kkkkkkrkkkk", "9-11 c: cccccccccncc", "2-5 j: jdfwzrjjtjt", "10-13 r: zrrprxhrrxzmmrbr", "8-13 s: sssjsssgssssbs", "5-6 b: bbbhhkh", "8-9 z: fzrzzzzxgfz", "7-9 l: bllllmllhl", "5-11 g: mqbfgrlgxfgcgggjdstc", "4-11 m: mmmgmmmmmmmxms", "14-17 p: lpppppppppzpppppp", "7-9 d: ddddddddd", "14-15 n: nnnnnnnnnnnnntz", "8-17 n: nnnbgzqbnndnzfsnmsmj", "12-15 l: lllkqllwdxlllvl", "3-11 t: lpdztztgmdwtztj", "2-5 m: rslsm", "5-11 c: ckptcgwqshct", "3-4 v: vvvdv", "4-8 d: dddrhddhddd", "2-5 n: brnnnnn", "1-4 p: qtpp", "5-7 l: lxblllflwl", "16-17 t: ttttttttttttttthm", "5-18 h: hhhthhhhhhhhhhhhhh", "9-17 j: jjjjjjjjbnjjjjjjjjj", "6-7 g: gfggnggrgg", "4-6 n: nnnnwq", "8-9 z: zzzczxzpwzlzdcsz", "7-10 w: wwswwwvwwtwww", "6-8 w: whwwwwlww", "2-14 c: cpccccccrccccck", "1-3 t: bqtbfdrdltn", "3-8 w: qwjhwrnjwsb", "2-4 g: gghg", "2-11 d: htdtljjxrnddxbdnfkwf", "12-14 b: bgbglrlpckgsxbjvqm", "9-14 q: qqgvqqqqqqmqqq", "2-16 m: mbmmmmmmhmmmmmzsbm", "11-12 n: nnxnnnnnnnnn", "6-12 r: rbrfbrnrrrprrczrqr", "1-3 n: nmnqtz", "17-18 h: hhhhhhhhhhhhhhhhfs", "11-13 k: rkmkwrknzfkkm", "2-3 w: bwwwwz", "8-12 s: mssssssssssc", "8-10 f: vzpcxfdfvqjpdkdh", "1-2 b: kbbx", "2-11 d: gqddddcdddf", "3-9 z: lzzqztpzzlzlz", "8-12 k: gkkfkkkmpkkkkktk", "1-4 l: lsqm", "9-11 m: mmzmmmmmmmv", "16-18 f: fffchfffffffffffffw", "7-8 v: wfhbqvxrvqpqvv", "15-16 v: vvvvvvvvvvvvvvtvv", "1-8 c: scwcrqclccccc", "12-15 d: bpdvrddgdtfdgdd", "2-4 k: gkkk", "14-15 x: lxsxljxfxwxxjcwnxxv", "6-7 p: hjxqnppmknskpb", "7-13 b: bbbbbbcblbbbbbvb", "7-9 j: gjjjpjjjhvqj", "3-6 n: nnnnnnn", "7-12 h: wxlhhhbjhhhhxhm", "3-5 t: ttttt", "3-4 n: ntnn", "8-16 b: bhrjmbbbsbbbfbbbpbb", "4-10 p: npsjlpppzgncww", "4-6 p: pvpfxqp", "1-2 f: fvxjf", "3-6 t: trnktdttt", "3-5 v: vvvvvmd", "3-6 z: bzmdfpbwckf", "3-4 h: hhhh", "2-4 x: tshbsbxlkpgs", "1-4 p: ppppbppppppppppp", "2-4 c: cccwc", "6-11 w: sbwwwwwqwmkw", "1-2 f: bxff", "3-8 h: rshhnqkvhh", "2-4 l: lpllll", "9-13 m: ltlmvcnnmmgtm", "4-5 j: szjjjmjb", "6-11 h: hkhdhkhhhhh", "1-4 v: vvlq", "16-17 b: pbdnsbbxbxgbdcqcr", "1-18 n: nnnnnmbnnnnnnnnnnn", "7-12 p: ppwtxzpvpppf", "4-5 r: rrrrr", "13-14 s: sgmdvqpxqqtstgspskf", "4-7 h: hhhwchwh", "7-18 d: ddlddddhjhbdddjdddd", "4-6 l: llllll", "15-16 n: nnnnnnnnnnnnnnzn", "11-16 p: pppdplppppgpppmppppt", "4-5 w: fwzbn", "1-3 p: sjpfb", "3-4 b: bbgbb", "2-13 n: pdnnjnnnnnnnnnn", "6-11 w: wwwkwdwwvcmwg", "1-6 t: dhtmfk", "4-7 d: wgrtpqldqldl", "2-15 z: zjzzzzzzgzzzzjzpzh", "1-6 h: hshhch", "1-2 n: kdnnnnnqnnnnn", "6-8 m: mdfjcclk", "7-19 d: ddwdddddfnddddddddj", "12-15 q: snqnppbsfjzvkxgkfc", "6-7 n: nnnnnnn", "3-4 x: xxghmxsz", "5-6 t: tttgtsjts", "3-5 f: mftfffcgwc", "12-13 w: wpwwwwwwwwwzw", "3-7 m: mmmmmmmmm", "15-18 x: xxxtxxwdvxxxxxxxxkxs", "4-5 w: wnpwwzw", "17-19 n: nnnnnnnnnnnnqnnnndn", "7-8 d: ddddddrf", "9-11 t: ttqtttthttxttt", "1-4 c: gccbr", "5-11 w: wwwwtwmwwwwlw", "6-8 v: vvmwvhvxvgsvftv", "2-11 s: lkvssdschmsgqbbws", "3-7 k: kmkxkckvg", "3-10 l: llxllllllglrllhl", "1-3 b: gbbb", "18-19 v: vvvsvvvvvvvvvvvvvvv", "8-9 d: tzddvdddddd", "2-4 t: tgtbpcv", "1-3 r: hrzrt", "2-4 f: ffqq", "5-6 c: cccjzh", "3-4 j: jjln", "6-8 l: lllllllllll", "9-10 n: nnnnnnnnfr", "8-9 x: xxxxxxxvcx", "5-10 w: wpwwwbwwww", "14-15 p: pppppppppppdphrppp", "9-19 h: whhcthhxhhhhhhghjtwz", "9-13 z: zzzzzpzzzhtzvnzzzzz", "11-13 l: llllllllzlqql", "6-11 b: bhlwpmbbbjzbcxwzmtc", "2-3 q: fqqhfqr", "12-14 m: mmmmdmmmmmmmsm", "1-3 t: gggctqtfpxtrt", "2-3 k: kbkk", "11-14 d: dddddcdddfddddd", "8-19 n: pnnnjnnnwgnnnnsnnnd", "9-10 r: rrtrrrvrqrrrpr", "4-12 k: kxskkkckkkzkz", "1-10 h: tjvhhphpzhjrlhhht", "8-9 c: pkcccccmc", "3-5 h: slwlgwnhcxxdhk", "1-8 l: cllllllqll", "3-4 q: wzqthkjvqct", "4-6 d: ddddddddddd", "2-6 q: qqqbxm", "6-9 b: bbbbbbqbsw", "3-6 c: ccwkpdjccfvc", "9-10 r: rrrrtrrrrr", "1-5 d: phzdmtzshlz", "5-7 q: fqqqqqrqq", "4-5 v: vvvvr", "3-5 k: kkgkk", "3-7 h: wxhgkfhhhqnhdfhg", "5-7 m: mmmwmmmmm", "1-3 z: qsvrzwnxzvl", "7-12 x: tpzblhzfdmxqqmmjfwq", "9-12 m: mmmqmmmmmdmmmm", "15-18 t: ttttttttttttttthtt", "2-12 b: tblhkbgnbbfqvd", "2-3 m: rmqv", "8-17 m: jmcndnqmdjdtqnbvmpn", "5-14 l: lxlfvjnbllllmlllllsb", "4-5 r: rtlmrxxrrnrt", "6-7 k: kkksmkg", "16-19 q: bkwfqstbmqqhzqvqvcqd", "12-13 l: lllllllllllpll", "2-9 m: zgxdbmzrmbbdbw", "7-9 d: bdddddzdk", "18-19 g: wfwggwhxrnnspmvgjrg", "17-18 w: wwwwwwwwwwwwwwwwwwww", "2-6 z: kzzzfzbh", "3-4 c: pcqk", "5-6 t: tthtpx", "10-13 x: xxxxxxxtdtkxqxqxxxx", "1-2 b: qbwd", "13-19 l: llhxsxlllllpllllllfl", "14-15 n: nnnnmnnnnnnnnnqn", "6-7 m: mjmhsdmmm", "3-5 r: qqshck", "8-15 c: clbcccrccscccpcwcc", "9-12 k: kkcwkklkkkcnkkxkk", "4-5 v: vvvppvv", "2-8 t: dxtgttjj", "1-8 r: tqrlhfzk", "8-9 n: zhmtnfsrr", "10-15 d: ddddmldddzddgnk", "13-17 z: jzpzzzzzzzvwnzzbz", "1-5 d: ddkdd", "4-6 x: xsxgbf", "3-8 k: wkckkkcw", "5-7 r: ndprnrxrrrbzrpnrz", "4-6 n: nnnnnnn", "7-8 q: qbmxfhqqqqmhqqq", "9-10 k: swgkcrkdkkjfmkkkjl", "6-8 s: kzqbsxrchhvvfvkqhz", "3-4 h: hmgh", "10-11 b: bsbfbkbwbhh", "9-13 z: nnzzbvzzrzkjnbzqfzzp", "1-11 x: xsxnqgjsqzxxnxd", "12-13 m: mmmmmmmmmmmvm", "11-20 n: vjsnfnnsgnnnmnnnnnwn", "4-11 q: qqqhqnpqbnrqhpd", "10-16 s: hszrsssktsspdtsrssss", "1-4 m: ldmhj", "3-14 l: llxjlmllflzdbll", "11-17 m: mmmmmmmmmmmmmmpmmmm", "1-7 c: jcccccl", "15-16 x: xjxxxxxxxxxxxxxxx", "5-7 v: cvtvcvv", "7-12 p: npppqpgptpjkjpdp", "12-16 c: cwvmnknsbccvccrckqcf", "5-13 v: vrvvvjvvpvvvwvbv", "2-14 l: bkllllllllllldlllk", "4-6 x: qxxxpxs", "9-11 s: sbssssssssm", "7-8 q: vgctvvqq", "3-8 g: ggtgggggggg", "5-6 b: pbbctbbbvnbjbbb", "1-2 w: jwww", "12-14 z: zszzzzznzzztzz", "2-3 j: fnmgcjbjt", "4-9 c: cccphccccpthcwwc", "5-12 g: ggsgxggggsgqggggg", "4-5 v: vvvvvv", "8-17 q: hdhtqlwpzqqqqqpqqhq", "9-15 s: sschdsssnvssvss", "7-8 d: sdhkdtpcdwgddtdd", "1-2 d: ddjdd", "5-9 b: zbzbbbklzbbb", "9-10 g: gggggggggg", "2-4 t: kttt", "6-13 t: pttsttttttttzt", "16-17 h: hhhhhhhhmhhhhhhtdhh", "4-10 r: rmpldrbrqcfqrkhbnqc", "6-14 z: zjzcpzzxzzzctzjz", "6-17 v: hsfctvxwpgsvfnfxwncq", "14-16 p: ppppppppppppplpppppp", "15-18 l: lllllslllllllgnllf", "7-15 v: vvvvvvfpvnvvsvvgvv", "3-4 x: xxsx", "8-13 z: zzwzzrzzzzzqqz", "7-8 r: hrsrrrrzrb", "3-4 b: bzfg", "5-7 h: dhhthhhhr", "1-4 v: vcvv", "5-6 k: pkkkqkkk", "13-20 j: jjjjjsjjjjjjjjjjjjjj", "3-6 p: pgtpptpxptvc", "1-3 v: tvvvv", "6-15 b: mbbbbbbbbbbbbkbb", "11-15 q: qmqqqqqhqqqqqqqqdqcs", "2-6 g: dggggr", "1-4 j: jjldsjjhfg", "2-4 h: vhkwhhnhbhx", "3-5 z: zzzzzz", "2-4 s: stmw", "12-13 k: wkbcmmkhpklkdnnkdvk", "19-20 b: bbbbbbbbbbbbbbbbbbbj", "6-9 w: vwwwtcpwwgw", "3-5 j: jbsjpjj", "10-13 c: cdccqpccccccc", "7-9 q: qpqqqqqqw", "15-16 p: ppppppppppppppbd", "6-13 n: nnnnnqnnnnndknnnnnn", "11-14 t: ttttqtttttjtttt", "4-6 t: tttltz", "3-5 n: nnnrj", "2-13 h: hhhhhhshhmhlkh", "1-6 x: xxxxxcxxxx", "4-7 v: ddswdvq", "3-5 d: xjksdvdddddwcrqzj", "6-7 x: xxxxxfxx", "3-6 b: bbqbbll", "9-12 p: pppppppplppj", "12-13 w: wwwwwwwwwwwwzww", "5-11 q: qztqqwvldnm", "1-4 m: qmmj", "3-7 l: llpllwllt", "2-8 h: hmhhhhhrsfhh", "8-10 g: gggggggqgv", "5-7 g: pggzgggggggb", "4-7 v: gvvxvrv", "3-4 l: llkf", "2-6 q: wqzpqqvdhhjlhkhmwtft", "2-3 n: nnnrd", "1-5 h: kfqqk", "7-12 z: qczzzzdlclzzdpfgzzz", "2-4 m: vrjmnqrmrmvm", "4-6 h: hhhbkhpghh", "5-7 z: zzzzgwbz", "5-7 d: ddddkfdbdnd", "8-10 q: qqxqqgtxqwqg", "5-14 b: bbbbzbbrbbrbbnbbbbbb", "8-10 z: vzzpzkzzgzzzzz", "8-9 w: wwwwwwwwb", "5-11 d: ddqdhddgddddd", "2-9 h: fhhhhhhhhhh", "7-12 b: bbjbbwxbcwbbnb", "1-3 m: tmmdmmmm", "2-3 b: bqtnkbjhlrvz", "2-9 z: nzrbzzrzlzzzvzt", "2-4 v: vvmv", "9-10 q: fccjqpwhqqq", "2-12 q: qqqqqfqqqqqqvqqq", "1-4 c: cxnc", "5-6 q: qqzhqqzqqqj", "2-3 k: vkkk", "8-9 n: nnmnnnxnnnnnqtwp", "2-3 b: jrbzvcb", "4-5 w: wwlnk", "4-15 d: wdpddddmdddddddddd", "10-14 d: dddqdxfddjbfddd", "5-6 t: pttttmttp", "3-4 b: bbgdbbb", "5-6 b: rgtqbbb", "7-14 b: pwpbbhbvbzxfbbb", "6-10 p: zppvhbpmcpwpprp", "1-15 p: bpfdpppxxmkppppmg", "9-14 w: hmlxdbdcqmxxhw", "1-9 t: zrqqtdbwpqdd", "4-6 n: knrnlnznn", "4-9 l: gclwdmllglblnlzn", "5-7 c: ckccbvvgtlc", "8-11 p: ppppppppxpp", "13-14 w: wwwwwwwwwwwdwh", "17-18 k: kkkkkkkkkkkkkkkkkk", "7-11 c: qccmcnccccc", "2-7 m: vmbnrmmngtqkjlmmt", "9-12 m: mtmmmmmmmxnr", "8-12 j: rjjdjvdjjfhj", "14-16 h: hhlhwhhhhhhhhgbhh", "10-12 w: dxwwwwlwwwwkwlwpwdl", "1-3 w: wmwcwrfbpwtzwf", "1-6 j: bjjjjjjj", "8-13 f: ffffffffffffgf", "1-6 g: lghdgt", "6-8 s: sssslsfb", "16-17 c: cccccccccnmcccmkc", "3-4 z: zmzz", "8-11 c: cccccccdcccc", "8-15 p: lcnvhbjldhfsgwfvtbp", "3-4 q: qqqq", "5-7 b: bcpqbdq", "1-4 t: ttttttttttttdtttt", "3-14 v: cvlrwvzvjkdbdd", "4-8 l: fcdhlwwl", "4-5 m: mmmmpm", "3-4 h: hhqlhl", "5-6 r: mrrrqrr", "4-5 c: cvccc", "11-15 p: pppppppshpjpppszppp", "6-8 j: fjzbjjjjvkjj", "3-7 q: qqsqqqqq", "1-16 p: jpppqppppppvppdwp", "2-5 g: jgwlxzgbhpmqp", "5-6 p: pppppplppp", "7-18 r: wmbbsjrmmzzdlxbwcfhp", "1-4 w: wvwqn", "6-7 p: pppppcmp", "15-16 h: zhhhhhhhhhhhhhhhhh", "2-16 h: hrhhhhlthhwhqjhht", "14-17 k: kkkkkdkkkkxkkskkxkk", "15-16 d: dddddddddddddddf", "2-17 v: vwvvvvvvvvvbvvmvvr", "7-8 v: vvvvvvtd", "1-4 f: lftr", "2-4 h: hhrq", "10-15 s: qsnnssxsvtfssdssss", "16-17 n: nnnnnnnnnnnnnnnnn", "1-4 r: bldfswjgvrsf", "10-11 n: lnxknqwlnnxc", "9-14 k: tjxclnrddxnpmg", "3-10 v: tvvvqmvsvcvsc", "3-4 v: vnxrv", "1-6 k: kkgkdkmj", "3-4 h: jhbrh", "8-9 c: ctczkccknntcccrc", "13-14 t: ttsttdtcttttttj", "1-9 b: bfwjbbxbd", "9-10 m: xmdvtsbmgg", "5-6 w: wwwwww", "2-6 l: djlwlwkl", "5-6 h: hhvjtrkhh", "3-5 b: bsbbl", "5-7 p: vxpwppsppp", "2-4 d: zbnddd", "3-4 s: msjss", "4-7 l: llqllll", "6-18 w: wwwwwwwwwwwwwwwwwlw", "13-14 h: hqnlxqhfwlvhhh", "7-9 p: ppppppcphpp", "5-8 x: bjfxkbqxpzxhxwvxx", "4-5 h: hhhpphgh", "4-5 c: sczcccccc", "4-10 n: nnfnnnsdgnnsj", "5-6 j: jwjjmjj", "1-9 c: hcrlmrcdjwhqn", "3-5 x: xxjxvx", "7-13 x: xxvxxblxxnxxlx", "3-6 w: wwjwwwf", "14-18 m: mnmmmmmmmmmmmmjmmmm", "3-5 t: tslttjqvnb", "1-2 v: sfkvhj", "2-4 c: ccctc", "5-10 r: rrqptljvxtkrwsfdbr", "3-4 q: qbwqngvm", "1-4 t: nttnt", "8-10 f: fqmfrffftv", "6-7 h: hkhhhhhv", "9-17 f: hfzhbmrxsfwfxdffh", "1-10 t: tthttgtgtgttctt", "2-3 b: tlbsbcxzbfplpjlsvncg", "8-16 t: tdtttttpttttttttttt", "8-16 k: jkkmzlkkgvkkkwtj", "13-16 v: vvvvvvvnvvdvhvvw", "7-9 v: vvvvxvhlqvzmc", "4-6 l: gdjscq", "9-17 f: fffffqffsfffffffhff", "4-5 g: ggggb", "2-4 w: wnmh", "7-8 g: ggjgrqfgg", "11-13 k: rrkgxzkkqnljs", "11-15 v: vsvvvqvvvvwvvjcvvv", "13-15 c: ccccccccccccccvccc", "1-6 n: jpmcnjdbdn", "3-4 v: xvlffppmgzwvv", "6-12 j: jjjjjslsjbpj", "10-11 l: lrhljlqllldblll", "8-11 h: hdhghhczmxhhhhhw", "2-3 z: ztnt", "6-8 x: jxxxxqxmm", "2-6 n: nwnnntnnjt", "8-13 z: ztzzzzzbzzzzq", "4-13 v: vxvvvxvmvvvvvvhvv", "11-13 t: ntttftttxtstttwt", "5-6 d: dddznd", "10-15 t: trxttttttbbstttt", "2-4 t: tblp", "8-11 l: xllllllwlldl", "12-13 m: mmsmmmmmmmmvcm", "3-4 t: tthb", "10-12 c: cpsclccmccctccc", "11-12 k: pkkkrkkkkqkfkk", "11-13 v: vvbvvlvvvvvvt", "6-11 p: xkxfdpkkrdpb", "13-14 h: hhqskrdhrhphbb", "2-6 r: rdrrrr", "1-4 p: nppg", "5-6 h: hgpbhh", "4-5 l: mrgzlxlchgjgwrlmvxl", "6-11 b: bbbbbbbbbbbbb", "2-5 s: svsvss", "10-18 j: jjjdjjjjzjfjjjjjbj", "1-14 p: tjphtjfnbhhgrmzdp", "2-4 v: vvvv", "5-7 q: vqvnbqdqhwqxqv", "6-7 m: mmmmmlj", "9-10 g: ggggggggggg", "7-13 n: sqnjnnrnnfnnn", "2-4 f: fbrfkhfkfcgjfp", "2-3 b: wfwjlbx", "16-17 r: rrrrrrrrrdrrrrrrr", "3-7 b: vkksbzbbhpwb", "2-4 m: fmcr", "9-20 v: vfvvxnvvdwhvxvvvqlvj", "6-9 b: jgjrcbnftrlbhp", "4-9 x: hrqtpwzjxxx", "7-9 h: hhhhhxnhdh", "7-8 k: kkkkrtsphkk", "6-7 n: jnnnblnnj", "10-15 d: dddddddddkddddt", "2-8 p: npbdhcgpl", "9-10 x: xqxxxxxzxvx", "5-9 k: khtkkwkkxqm", "1-5 t: stttttttgttttt", "5-13 w: wwhfjkshrwfpnlwjjmq", "4-9 x: rzfrxzcxvxxx", "3-4 g: hgfgg", "2-3 n: nnnn", "11-14 j: jjjjjjjjjjjjjj", "9-10 m: mmmmmmmmmm", "7-8 m: mmmmzmkmjhhwzmmwp", "2-5 r: rrzrr", "3-4 w: vnwpww", "5-9 h: hzhhhhhjgmswvbxfr", "6-10 h: cvhhhlhhhz", "4-5 g: xxgggzg", "1-2 d: dddcf", "5-8 v: vvvvvvvpxv", "7-9 b: bbkbjbpsbbbbtkblmr", "6-8 f: fffffmfgfff", "2-8 f: zfskzfjjwfjsf", "4-5 v: lvdvdvv", "4-5 p: ppbkrjp", "6-14 z: zzzzzrzzzzzzzhzzw", "5-7 g: cbbfngwggzs", "2-4 n: nfpnnhnkpgmjdgc", "11-14 h: hhhqchbhhhwhhhqjjhhn", "5-7 q: qqqqqqq", "2-3 s: sssjs", "11-17 w: wwwxwwwwwwhwwwwwrwww", "12-13 n: nnhtsnxqndxnlnnn", "8-10 j: jjjjjjjhjj", "15-16 z: zzzzzzzzzzzzzzzg", "2-5 j: jfjpk", "1-10 z: mzfzzzzzzpzzz", "13-15 v: vcvvrvdvvvvvvvvvvv", "11-12 j: jljjljqjvjmhjjj", "1-7 c: cctccvv", "6-17 s: slqssbsswsssszswsss", "16-17 s: klksgsgtpsnrpslzs", "12-13 m: mmmmmmmmmxmmfm", "18-20 v: vvvvvvrvvvvvvvvvvlvs", "18-19 d: ddddddddddddddddddv", "4-5 p: srsjp", "2-5 d: czvdk", "5-11 w: pwgbslprbkk", "15-16 b: bbbbbbbbbbjbbbbqnb", "7-8 h: hhhhhwxt", "11-12 g: ggggggggtqggg", "10-11 m: mmmmmmmmmfk", "4-6 m: qvlmmbmmmdrmpcqmmfq", "1-10 r: xrrrrdrrrnrvzrrrrmrr", "5-9 p: pljpvppkgc", "13-14 j: jjjjjjjqjjjjwv", "6-8 g: gggggggqg", "2-7 b: bbkkdwb", "3-16 q: fqqqqlqqqqqqqqqhqqqh", "3-5 x: xfjxv", "1-2 h: hhtkkpvhk", "1-13 d: dddddddddddddddddd", "7-8 x: kxxvngmqxcrqsxxlx", "1-4 m: zvmr", "1-11 n: wnfnnnsnftrnnfn", "6-13 h: gcrjcphhhhpgh", "1-4 h: jghv", "7-10 m: mvtqpjmvvmvgp", "4-7 j: pjjhjjjj", "4-5 c: ccmcc", "1-3 d: ddddd", "2-4 g: gdglgwn", "3-8 z: mbzznvds", "3-11 k: fkjttkdkkqbkkkkr", "5-10 n: nnnnwvnnncnnnnn", "1-5 p: wdnxzn", "2-4 h: phhhhhth", "10-12 p: ppwpwkpgppvppppr", "2-6 r: cdrxrrfrrztbq", "6-15 g: gpjggfgcglqgfggw", "3-4 q: qfqgq", "2-6 m: mmmmmf", "10-11 f: fffffffffff", "5-12 g: bvggjfggkggggrqn", "5-16 q: qbqjqqqxzqqqnqmhqq", "3-5 g: gggggg", "3-6 w: wzpxfbkkwtfdswwq", "6-7 x: xccxxrwfp", "12-13 q: qqqqqqqqqqqqq", "7-12 k: kpkkkktkkkkf", "5-7 f: kjlffrf", "9-12 b: rnlzpmxcbbbbbzb", "7-16 t: tztqtdvrrtgtzjtbtpt", "14-15 g: ghkblgpbgbrtdgg", "6-10 h: hdtqhhhhmlhh", "6-13 g: gggggzgggwggl", "7-9 v: kvtqvdsvvvwvpvgkhfl", "10-12 b: bbbbbbbbbmbtbbbb", "11-18 d: ddbddldhgzpkdcdddwd", "12-13 k: kkklkkkkkkkkkk", "3-4 v: rdvztvgv", "4-9 n: zzjtntjcdlt", "11-14 r: rrrrgrrrrbrrrrrrrrr", "1-4 q: qkvq", "2-9 z: wgpmpmxdz", "13-19 p: pmpqjpppppppjpppppkp", "3-4 s: smxwrsmt", "1-5 m: mmsmhmm", "11-14 p: pptmpppnpppspp", "11-12 c: crcccpccfpcncccc", "17-18 x: xnqxxxxxxxxxxxxxxxxx", "1-2 v: cppsvk", "4-6 p: gnpppg", "2-9 r: krbjwprvrrsmrbrjcfl", "2-12 x: cnqxhvppvzkxc", "1-4 g: bgggg", "3-4 j: jjjj", "4-6 l: lwnlljgsdtl", "1-8 v: vvfhxlcq", "11-17 s: wsssmjsjbfstglsss", "6-10 p: pprkpdpsgvm", "13-15 r: rrqrrrrrrrrrrrrr", "3-4 v: vvvj", "1-10 k: kxprmfhcqkcknpqqggt", "9-10 k: lrkkkkkkxtk", "2-14 r: rrdtrmxjwrxgrv", "8-12 q: qqqqqqqwqqqqq", "4-7 v: vvddhcs", "3-4 h: ghhzsvfkghshhz", "9-12 z: zzwctlnpzlzzzbhz", "14-16 w: wwwwwwwwwwwwwlwlwwww", "11-16 r: frrrrrrrrgrnfrrcdr", "2-3 l: jrlkln", "11-12 w: dhwpwzdpwzkf", "8-12 h: shpthhjhlhhhsd", "4-5 n: nnnnnnnnnnnnn", "5-9 d: dddtqdddm", "2-8 p: kpkhwtptjl", "1-9 k: rhvfjdgmjfckqnbjkxk", "8-12 s: srsfbqgqcjgstkldlzbj", "10-11 x: xkmxbndwvxx", "10-19 k: zksnmwtkdkzkkxnvkjk", "4-5 f: qjnfpsfqqfgmf", "1-9 f: fvfffprxffffsphpfff", "2-9 j: njgjjjbqjnmjxbhj", "2-5 z: zzzxzbfp", "8-15 f: ffffdqflmfffffrfw", "5-15 c: cxmltcccmcmgvjg", "2-3 p: pzqp", "2-8 d: fttcqdzdq", "6-10 p: sgphkqkspxbpfsjd", "5-6 p: pppppf", "5-15 r: rrrgrrrrsrcrrrnr", "11-12 t: ttttttttttlt", "10-11 w: wwwwwwwhxtwwww", "9-10 h: wklhbssjkr", "9-14 j: rjjgjjjfhjjpnbjjjj", "2-3 d: dddd", "6-14 q: qqqqqkqmqqqqqqq", "14-15 w: wwwwwwwwwwlwwxw", "5-9 s: vzssssssn", "13-14 n: nnnnnnnnnnnnxt", "1-9 w: cpwtwvngszwwzpwwcw", "1-2 n: nnnnnn", "7-18 b: bbbbbwbbbbbbbbbbrbb", "4-7 f: pfgfwhw", "7-13 q: qqqqqqsqqqqqhqqqq", "3-10 n: gnpjzgndrntnb", "9-13 q: qlqqqqqqqqrrqpqh", "16-19 m: mrqcmmpmmmmmmmmcqmfm", "5-11 p: fgkdvbqwpsfbpjpprgp", "7-11 q: fqqwdqfkqqqrssqqtp", "5-6 t: trtfkvg", "17-18 h: hhhhhhhhhhhhhhhhhh", "6-18 l: lllllklllllllllllbll", "4-9 q: hqqxqqqql", "1-5 j: jjjjnjjjj", "3-4 g: jxggg", "14-16 j: zljnjjsjjjjjjjjjfjjj", "7-9 m: pmzmmzjmxpcbrqnmmmm", "3-7 z: zlczjzlnrtkfss", "2-15 s: xzswpvgnwwjkzws", "15-16 z: zkzzzzzztzqzzzwzzzz", "6-12 f: fcffffffpfffhx", "9-14 p: kptdgpcvplhjhnppst", "9-11 h: hhhhhhhhhhmhx", "2-3 c: cccc", "8-18 s: sszslksjsrsssssssws", "1-6 h: rgvjlphbbhhhnkzz", "2-7 r: rlzrhrrrk", "17-19 h: hhhhhhhhhhhhhhhhhhhh", "2-4 j: wjzjqj", "5-6 b: bbbvdx", "7-13 k: ztqlwthlsdkrdww", "1-2 m: tmmm", "16-19 d: ddcddddddjdjdddpddd", "2-3 n: tvxj", "13-14 z: zzzzzzzzzzzzpz", "6-7 x: xxxxxxl", "2-3 q: qnrw", "7-10 l: ljlvfhgrmllkhlxlq", "2-4 b: bbbq", "16-17 h: hshhhhhhhmhhhhhckh", "1-6 r: rrkrrr", "14-16 n: nnnnnnnnnnnnnnqnnn", "5-11 h: fhhlhhhhhhjktdhngj", "3-4 g: gzgdvgqgq", "2-4 r: hvrg", "7-11 b: bbgcbbbqbwsbgbbbk", "5-9 m: hfpmxpmvmb", "17-20 v: vvvtvtvvvvvvvvvvqvvb", "1-20 z: pszbttwrmqvlrgkmmlwz", "9-16 h: hhhhhhhhhhhhhbhth", "1-2 n: nhnhh", "1-10 n: wnnnnnnfnrnn", "1-5 k: sjkkk", "1-7 k: lklkkkpkk", "4-6 n: nnnznwn", "14-15 s: sssssssssssssds", "9-14 z: zzzzjzbzzzzzzzz", "16-19 g: ggggfrgzgggggggnggg", "9-13 v: vphvvvvvvjvvvmvv", "2-3 l: lvvxpvvqzhdzrk", "4-7 c: qdhclzccwcbmvcsz", "5-8 s: stsskssws", "3-4 c: kbxp", "2-10 b: dtlqbbsvzbbklbgbf", "8-10 s: smsslsbrsbcvsjsts", "2-4 k: kkkkl", "15-16 x: xxzxfxxrdxxfxpxrxn", "11-18 h: hhnrdhhhhhhhhhhhjxh", "1-2 n: plzvhknwjn", "4-9 w: wwzkwwwwxww", "2-3 l: lllp", "3-9 j: fkzjnhqzpjjd", "4-6 k: skkltk", "3-4 k: klvkkkk", "3-4 k: kkkg", "10-11 d: bqdkzpxnfdd", "12-14 r: rqrrrrrrrrrlfxrr", "2-3 r: znrf", "1-4 j: hgzjjtnw", "1-6 w: mwwtwwww", "14-16 d: spddddtddzjsbdcx", "3-4 x: xxbf", "11-12 r: vrrrkdrsrnhrnrvrr", "1-4 c: clmw", "3-8 t: ztvndgtx", "7-10 z: zzzzzzzzzzzzzv", "4-12 t: tbrthtwtchtt", "1-7 h: hwhqrvhqhfh", "4-7 s: ssfssss", "5-13 s: kjtsspjmzrfxp", "4-7 z: zzzzzzzz", "5-15 h: gvhhrscmwmdhhhghhn", "7-8 r: rrrrrrns", "6-9 r: zrrrrrddr", "7-15 v: vvghgtjwwvzwhrk", "14-17 c: cccccsccccccnbtchc", "2-3 k: kgrgr", "15-17 k: kkkkkkkkkkkkkkvkk", "10-11 f: fffffffffvj", "6-8 r: prdnmrrzg", "3-4 f: kcfx", "4-5 k: kkkkkz", "4-15 t: ztttttqhcpstwtt", "1-6 g: cvgghtg", "9-15 j: jtrxvjtjhjjjsjj", "9-10 f: fffcffffff", "10-11 r: hjflczjkqrq", "3-8 k: jssmkkkbpkkjsvnhwkh", "6-10 g: ngggkggmbggtcgg", "15-16 x: xxxxxxxxxxxcxxjx", "8-9 k: kkkkkkkkn", "7-8 b: rbbbbbxdbb", "2-5 w: wwwdwmkhvd", "1-6 v: hfpwkxgvv", "12-14 z: zzzzzzzzzzzjzz", "14-16 s: ssrsmssssssssssss", "3-6 z: zdmzjkc", "2-4 m: mmbb", "13-18 w: lwwwwwkrwwwwwwwwwksw", "5-6 r: bwjrjgrrrrjbg", "5-9 r: rrxmrrlrrj", "2-4 g: gggk", "5-10 s: ssssgmssrscptfrc", "6-8 q: qqqqqzqqq", "16-17 m: kmmmmmqmxmlpsmmmm", "7-10 t: thxvtttztttjttvtkrcc", "2-4 p: pppp", "4-8 q: njdqbqqqrxd", "2-5 w: gwmwklnkfmwjjggw", "10-16 m: mmmmmmmmmzkmmmmw", "1-2 w: btkxj", "1-3 z: pzphlh", "7-10 j: jjjjrpcpjgjjkz", "3-5 j: jjljjj", "1-5 l: lkzflppcgpll", "4-6 m: mmmmmrm", "2-4 m: vmzmmmdhcmntntlrgqk", "8-9 x: xxwxxxlbxxx", "1-2 s: rwrbhvt", "1-5 d: dfdhdd", "6-7 z: zzzzzfz", "12-14 v: vvvdlvqvvnvkkm", "2-7 s: skftlhmfdgpsp", "9-11 q: rlqcqvqqqqqqqqq", "5-6 g: ggmgwtg", "5-7 m: mmmmmmmmmmmmmm", "4-12 f: qffmdmffzfdff", "8-10 k: lkwlkvkkkkkkkkkqk", "15-17 p: qppppqppppppppzpv", "3-4 x: xxxxx", "7-8 x: xxqxdxxxxx", "6-10 b: bbbbmsnkfbdrbnbtlnvb", "3-16 d: ddmdddddrddddddp", "8-11 n: nnnnnnnmnjdd", "3-4 v: vvgd", "11-13 n: nnnnnnnnnnfnn", "5-10 n: nnnnpjnngcnqnn", "7-11 w: wtwbbtzswqt", "1-6 f: fffffwfff", "8-10 q: qqvqqqqqqq", "2-3 h: hhhh", "17-18 m: mmmmmmmmmmmmmmmmqmmm", "10-11 f: ffffffffffdff", "2-4 z: zzzz", "5-6 g: gggghz", "6-19 n: nnnnnqnnnnnxnvnknnnn", "2-6 h: rhhdbk", "2-5 w: fnkwgww", "4-5 c: cqcdgtmcccrbcckng", "1-12 h: hkwptjwxmmgfhbvgj", "4-5 g: pbhtb", "1-11 h: hhhhhhhhhhhhh", "5-11 v: gfrfvfqmgsnrtqkvq", "13-14 s: sstssssscssdssss", "3-8 b: tzjqgnkbbzzvrsb", "8-9 b: bbbbbbbvb", "7-13 r: rrhdcvrrtxmrzrmfxr", "3-6 s: lsshsk", "2-6 g: rqzpqtxmbggsgg", "4-5 b: lbbffb", "3-4 m: kmpm", "8-18 w: wwwwhwwhwwwwmwwpbdw", "6-7 n: nnnnnjn", "6-9 r: ggrrsqrrrqrhbmrqzgd", "7-9 g: rggggggzc", "1-8 n: nnltwnnwn", "6-8 r: rrrrrpxvr", "4-12 c: ccccccccccchcccc", "1-3 g: mrbgf", "6-12 p: zfpsppknppvpmlrspbn", "1-4 g: jxmmns", "1-11 q: zdzhtqsxkcrklwk", "2-4 x: svqmxxl", "7-8 l: lllrwllll", "9-18 v: zkhlxtqvvcvndkzkvvt", "2-9 f: fksffshzx", "2-5 j: jkjnj", "4-15 j: qjjjmvjjpvmjjjbj", "1-5 p: kpppx", "1-6 v: vjttbvffvdhvk", "4-17 l: wlsqvxkrjlltlnxnmds", "1-3 p: pdzqnp", "1-3 h: hhhh", "2-14 z: mmvzzvzzkzhzszvqzzf", "3-6 q: qqrjsxqqq", "3-5 h: hrhvr", "1-8 k: kkskktnkklzdkjgk", "17-18 p: ppppvpppqppppmpppxpp", "2-8 f: fffjsfbp", "9-10 v: vvvfvvvtvxltsvv", "6-12 j: jpvptjqpkjwjr", "15-16 v: vvvvvvvvvvvvvvvp", "6-8 q: qqpqbqqvqq", "10-12 n: nnnnnnnnnnnjn", "13-14 n: nnnnnnwnnnnnxgnn", "2-3 k: kkkxl", "2-3 w: ldmm", "14-19 m: fphmmmmmmkmmmbmdmmw", "4-7 w: wwwgjwww", "8-9 d: dddwdddddd", "6-7 w: wwwfwfvtw", "2-6 j: hlcpkj", "1-3 m: xsmmc", "1-9 b: bbbbbbbbbbb", "1-4 z: zsgz", "2-12 v: vpvvvvvvvvvmvv", "2-16 c: vccjrtcckcccckcsc", "4-15 d: cqxpptqpwmqbvsvvt", "2-14 q: qqqfqwpqzqsmqqvqrxjr", "9-10 w: wvkfhfkhwjvw", "6-10 q: tqqmqktxqfvq", "4-11 f: kvqlfqxfrsf", "7-14 m: rmxmmmmmmmmmmmmxmm", "18-19 v: vvvvvvvsvvvvvvvvvvvv", "7-8 x: fxnxxjjx", "5-6 d: dzddrd", "9-11 b: bbbbbrbssqtbb", "14-16 x: sxxxlxxxxxsxxxxxxxx", "5-9 t: wtttttbptttttqttmtt", "11-13 l: lllllflllwsll", "7-8 r: rrrmprjcv", "6-9 p: plvpdzzppptpkpkpgp", "2-13 g: chmjgvkvsplztzvtlzl", "6-8 z: czzzzjzkg", "1-5 l: jlltpfwlrl", "6-7 d: jddcggqmdddd", "3-5 c: cxbbc", "13-14 p: ppqpppppppppbs", "3-7 w: rwwnqlw", "4-5 v: vvvvv", "9-10 v: vvvvvvvvvm", "3-5 z: zmxzlz", "7-8 c: cccccchdc", "2-4 d: drddctmgd", "3-4 n: nnnn", "3-10 q: cbqszqfqqqbvrrtsfq", "4-17 p: pppkppppppppppppwp", "11-12 n: nnnnnnnnnnnn", "14-15 d: dddddddddddddxn", "6-11 k: gbmbzkcmzskpkhp", "2-10 z: zrzzzzzzzjzzz", "1-2 q: wvqq", "11-14 d: ddddddddddhddn", "2-7 h: hhhhhhhhxh", "10-19 m: mmkmmmmdmmmmmqhvpldm", "2-10 j: jbmjjjrcjj", "7-9 c: ccccplccccc", "7-19 c: cckcbwlcccccccccczp", "9-13 z: zzzzzzjmzzzzp", "16-20 j: vjkjjcjjrjjmtnbjjjnj"
            };

            var tuples = new List<(int min, int max, char car, string val)>();
            foreach (var l in baseList)
            {
                var splitted = l.Split(new[] { ' ' });
                var min = Convert.ToInt32(splitted[0].Split('-')[0]);
                var max = Convert.ToInt32(splitted[0].Split('-')[1]);
                var car = splitted[1][0];
                var val = splitted[2];
                tuples.Add((min, max, car, val));
            }

            int countValid = 0;
            foreach (var (min, max, car, val) in tuples)
            {
                if (
                    (val[min - 1] == car && val[max - 1] != car)
                    || (val[min - 1] != car && val[max - 1] == car))
                {
                    countValid++;
                }
                /*var countChar = val.Count(c => c == car);
                if (countChar >= min && countChar <= max)
                {
                    countValid++;
                }*/
            }

            Console.WriteLine(countValid.ToString());
        }

        private static void DayOne()
        {
            var values = new List<int>
            {
                1981, 1415, 1767, 1725, 1656, 1860, 1272, 1582, 1668, 1202, 1360, 1399, 1517, 1063, 1773, 1194, 1104, 1652, 1316, 1883, 1117, 522, 1212, 1081, 1579, 1571, 1393, 243, 1334, 1934, 1912, 1784, 1648, 1881, 1362, 1974, 1592, 1639, 1578, 1650, 1771, 1384, 1374, 1569, 1785, 1964, 1910, 1787, 1865, 1373, 1678, 1708, 1147, 1426, 1323, 855, 1257, 1497, 1326, 1764, 1793, 1993, 1926, 1387, 1441, 1332, 1018, 1949, 1807, 1431, 1933, 2009, 1840, 1628, 475, 1601, 1903, 1294, 1942, 1080, 1817, 1848, 1097, 1600, 1833, 1665, 1919, 1408, 1963, 1140, 1558, 1847, 1491, 1367, 1826, 1454, 1714, 2003, 1378, 1301, 1520, 1269, 1820, 1252, 1760, 1135, 1893, 1904, 1956, 1344, 1743, 1358, 1489, 1174, 1675, 1765, 1093, 1543, 1940, 1634, 1778, 1732, 1423, 1308, 1855, 962, 1873, 1692, 1485, 1766, 1287, 1388, 1671, 1002, 1524, 1891, 1627, 1155, 1185, 1122, 1603, 1989, 1343, 1745, 1868, 1166, 1253, 1136, 1803, 1733, 1310, 1762, 1319, 1930, 1637, 1726, 1446, 266, 1121, 1851, 1819, 1284, 1959, 1449, 1965, 1687, 1079, 1808, 1839, 1626, 1359, 1935, 1247, 1932, 1951, 1318, 1597, 1268, 643, 1938, 1741, 1721, 1640, 1238, 1976, 1237, 1960, 1805, 1757, 1990, 1276, 1157, 1469, 1794, 1914, 1982, 1115, 1907, 1846, 1674
            };

            var response = -1;

            for (int i = 0; i < values.Count - 3; i++)
            {
                for (int j = i + 1; j < values.Count - 2; j++)
                {
                    for (int k = j + 1; k < values.Count - 1; k++)
                    {
                        if (values[i] + values[j] + values[k] == 2020)
                        {
                            response = values[i] * values[j] * values[k];
                        }
                    }
                }
            }
        }
    }

    enum Wind
    {
        east = 0,
        south,
        west,
        north
    }
}
