using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using TechAnalysis.Model;

namespace TechAnalysis.Technical
{
    public class WoodiePivot : Pivot
    {
        public WoodiePivot(string instrument, DateTime date) : base(instrument, date) { }

        public override string Name => "WoodiePivot";

        public override void Calculate(OHLC ohlc)
        {
            Pp = (ohlc.High + ohlc.Low + (2 * ohlc.Close)) / 4;

            R1 = (2 * Pp) - ohlc.Low;
            R2 = Pp + ohlc.High - ohlc.Low;
            R3 = ohlc.High + (2 * (Pp - ohlc.Low));

            S1 = (2 * Pp) - ohlc.High;
            S2 = Pp - ohlc.High + ohlc.Low;
            S3 = ohlc.Low - (2 * (ohlc.High - Pp));
        }
    }
}
