using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AventOfCode
{
    public abstract class DayBase
    {
        private const string DEFAULT_SEPARATOR = "\r\n";
        private const string SAMPLE_FOLDER = "Samples";
        private const string DATAS_FOLDER = "Datas";
        private const string DATAS_EXTENSION = "txt";

        public int DayNumber { get; }

        protected DayBase(int dayNumber)
        {
            DayNumber = dayNumber;
        }

        protected List<T> GetContent<T>(Func<string, T> converter,
            string separator = DEFAULT_SEPARATOR,
            bool sample = false,
            int? part = null)
        {
            var subFolder = sample ? $"{SAMPLE_FOLDER}\\" : string.Empty;
            var dayFileName = DayNumber.ToString().PadLeft(2, '0');
            var daySubPart = part.HasValue ? $"_{part.Value}" : string.Empty;
            var assemblyName = Assembly.GetExecutingAssembly().Location;

            var path = Path.Combine(Path.GetDirectoryName(assemblyName),
                $"{DATAS_FOLDER}\\{subFolder}{dayFileName}{daySubPart}.{DATAS_EXTENSION}");

            using (var rd = new StreamReader(path))
            {
                return rd.ReadToEnd().Split(separator).Select(v => converter(v)).ToList();
            }
        }

        public abstract long GetFirstPartResult(bool sample);

        public abstract long GetSecondPartResult(bool sample);
    }
}
