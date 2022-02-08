using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using TechAnalysis.Model;

namespace TechAnalysis.Technical
{
    public class CamarillaPivot : Pivot
    {
        public CamarillaPivot(string instrument, DateTime date) : base(instrument, date) { }

        public override string Name => "CamarillaPivot";

        public override void Calculate(OHLC ohlc)
        {
            Pp = (ohlc.High + ohlc.Low + ohlc.Close) / 3;
            R1 = ohlc.Close + ((ohlc.High - ohlc.Low) * 1.0833);
            R2 = ohlc.Close + ((ohlc.High - ohlc.Low) * 1.1666);
            R3 = ohlc.Close + ((ohlc.High - ohlc.Low) * 1.25);
            R4 = ohlc.Close + ((ohlc.High - ohlc.Low) * 1.5);
            S1 = ohlc.Close - ((ohlc.High - ohlc.Low) * 1.0833);
            S2 = ohlc.Close - ((ohlc.High - ohlc.Low) * 1.1666);
            S3 = ohlc.Close - ((ohlc.High - ohlc.Low) * 1.25);
            S4 = ohlc.Close - ((ohlc.High - ohlc.Low) * 1.5);
        }
    }
}