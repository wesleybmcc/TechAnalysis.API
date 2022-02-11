using Microsoft.AspNetCore.Mvc;
using TechAnalysis.Data;
using TechAnalysis.Technical;
using TechAnalysis.Model;

namespace TechAnalysis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TechnicalController : ControllerBase
    {
        //public TechnicalController(TechAlertDbContext context) : base(context)
        //{
        //}

        [HttpGet]
        [Route("pivots")]
        public IList<Pivot> GetPivots()
        {
            var pivots = new List<Pivot>();
            DateTime lastMarketDate = DateTime.MinValue;
            var ohlcList = new DataService().GetLastOHLC(lastMarketDate).ToList()
                .Select(n => new OHLC
                {
                    Symbol = n != null && n.Instrument != null && n.Instrument.Symbol != null ?
                                n.Instrument.Symbol : String.Empty,
                    Open = n != null ? n.Open : 0,
                    High = n != null ? n.High : 0,
                    Low = n != null ? n.Low : 0,
                    Close = n != null ? n.Close : 0,
                    StartDateTime = lastMarketDate,
                    EndDateTime = lastMarketDate
                }).ToList();

            ohlcList.ForEach(ohlc => {
                var camarillaPivot = new CamarillaPivot(ohlc.Symbol, ohlc.StartDateTime.Date);
                camarillaPivot.Calculate(new OHLC { Open = ohlc.Open, High = ohlc.High, Low = ohlc.Low, Close = ohlc.Close });
                pivots.Add(camarillaPivot);

                var woodiePivot = new WoodiePivot(ohlc.Symbol, ohlc.StartDateTime.Date);
                woodiePivot.Calculate(new OHLC { Open = ohlc.Open, High = ohlc.High, Low = ohlc.Low, Close = ohlc.Close });
                pivots.Add(woodiePivot);

            });
            //new DailyPriceService(_context).GetPreviousOHLC()
            //    .ToList().ForEach(d => {
            //        var camarillaPivot = new CamarillaPivot(d.Symbol, d.StartDateTime.Date);
            //        camarillaPivot.Calculate(new OHLC { Open = d.Open, High = d.High, Low = d.Low, Close = d.Close });
            //        pivots.Add(camarillaPivot);

            //        var woodiePivot = new WoodiePivot(d.Symbol, d.StartDateTime.Date);
            //        woodiePivot.Calculate(new OHLC { Open = d.Open, High = d.High, Low = d.Low, Close = d.Close });
            //        pivots.Add(woodiePivot);
            //    });

            return pivots;
        }

        [HttpGet]
        [Route("pivot/names")]
        public IList<string> GetPivotNames()
        {
            return new DataService().GetPivotNames();
            //var pivotNames = new List<string>();

            //if(!NullContext() && _context.TechnicalType != null)
            //{
            //    var technicalType = _context.TechnicalType.FirstOrDefault(tt => tt.Name == "Pivot");
            //    var technicalFeatures = new List<TechnicalFeature>();

            //    if (technicalType != null && _context.TechnicalFeature != null)
            //    {
            //        technicalFeatures.AddRange(_context.TechnicalFeature.Where(tf => tf.TechnicalTypeId == technicalType.Id));
            //        technicalFeatures.ForEach(tf => {
            //            if(tf != null && tf.Name != null)
            //            {
            //                pivotNames.Add(tf.Name);
            //            }
            //        });
            //    }
            //}

            //return pivotNames;
        }
    }
}
