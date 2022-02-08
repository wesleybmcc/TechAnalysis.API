using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TechAnalysis.Model;

namespace TechAnalysis.Technical
{
    public class PivotLevel
    {
        public string? Name { get; set; }
        public double Value { get; set; }
    }

    public abstract class Pivot
    {
        public double R4 { get; set; }
        public double R3 { get; set; }
        public double R2 { get; set; }
        public double R1 { get; set; }
        public double Pp { get; set; }
        public double S1 { get; set; }
        public double S2 { get; set; }
        public double S3 { get; set; }
        public double S4 { get; set; }
        public string Instrument { get; set; }
        public DateTime Date { get; set; }
        public abstract string Name { get; }
        public abstract void Calculate(OHLC ohlc);
        protected Pivot(string instrument, DateTime dateTime)
        {
            Instrument = instrument;
            Date = dateTime;
        }
    }
}
