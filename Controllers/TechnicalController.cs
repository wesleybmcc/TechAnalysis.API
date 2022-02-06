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
        private readonly TechAlertDbContext _context;

        public TechnicalController(TechAlertDbContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        [Route("pivot/woodie/all")]
        public IList<Pivot> GetWoodiePivots()
        {
            var pivots = new List<Pivot>();
            new DailyPriceService(_context).GetPreviousOHLC()
                .ToList().ForEach(d => {
                    var woodiePivot = new WoodiePivot(d.Symbol, DateTime.Now);
                    woodiePivot.Calculate(new OHLC { Open = d.Open, High = d.High, Low = d.Low, Close = d.Close });
                    pivots.Add(woodiePivot);
                });

            return pivots;
        }

        [HttpGet]
        [Route("pivot/woodie")]
        public Pivot GetWoodiePivot([FromQuery] string symbol, [FromQuery] string day)
        {
            WoodiePivot woodiePivot = new WoodiePivot(symbol, DateTime.Now);
            var instrument = _context.Instrument.FirstOrDefault(i => i.Symbol == symbol);
            if (instrument != null)
            {
                var dp = _context.DailyPrice.Where(d => d.InstrumentId == instrument.Id);
                if(dp != null)
                {
                    var dailyPrice = dp.OrderBy(d => d.Date).FirstOrDefault();
                    if(dailyPrice != null)
                    {
                        woodiePivot.Calculate(new OHLC
                        {
                            Open = dailyPrice.Open,
                            High = dailyPrice.High,
                            Low = dailyPrice.Low,
                            Close = dailyPrice.Close
                        });
                    }
                }
            }
            return woodiePivot;
        }

        [HttpGet]
        [Route("pivots")]
        public IList<Pivot> GetPivots()
        {
            var pivots = new List<Pivot>();
            new DailyPriceService(_context).GetPreviousOHLC()
                .ToList().ForEach(d => {
                    var camarillaPivot = new CamarillaPivot(d.Symbol, d.StartDateTime.Date);
                    camarillaPivot.Calculate(new OHLC { Open = d.Open, High = d.High, Low = d.Low, Close = d.Close });
                    pivots.Add(camarillaPivot);

                    var woodiePivot = new WoodiePivot(d.Symbol, d.StartDateTime.Date);
                    woodiePivot.Calculate(new OHLC { Open = d.Open, High = d.High, Low = d.Low, Close = d.Close });
                    pivots.Add(woodiePivot);
                });

            return pivots;
        }

        [HttpGet]
        [Route("pivot/camarilla/all")]
        public IList<Pivot> GetCamarillaPivots()
        {
            var pivots = new List<Pivot>();
            new DailyPriceService(_context).GetPreviousOHLC()
                .ToList().ForEach(d => {
                    var camarillaPivot = new CamarillaPivot(d.Symbol, DateTime.Now);
                    camarillaPivot.Calculate(new OHLC { Open = d.Open, High = d.High, Low = d.Low, Close = d.Close });
                    pivots.Add(camarillaPivot);
                });

            return pivots;
        }

        [HttpGet]
        [Route("pivot/camarilla")]
        public Pivot GetCamarillaPivot([FromQuery] string symbol, [FromQuery] string day)
        {
            CamarillaPivot camarillaPivot = new CamarillaPivot(symbol, DateTime.Now);
            var instrument = _context.Instrument.FirstOrDefault(i => i.Symbol == symbol);
            if (instrument != null)
            {
                var dailyPrice = _context.DailyPrice.Where(d => d.InstrumentId == instrument.Id)
                    .OrderByDescending(d => d.Date).Last();
                camarillaPivot.Calculate(new OHLC
                {
                    Open = dailyPrice.Open,
                    High = dailyPrice.High,
                    Low = dailyPrice.Low,
                    Close = dailyPrice.Close
                });
            }
            return camarillaPivot;
        }

        [HttpGet]
        [Route("features")]
        public IList<TechnicalFeature> GetTechnicalFeature([FromQuery] string name)
        {
            var technicalType = _context.TechnicalType.FirstOrDefault(tt => tt.Name == name);
            var technicalFeatures = new List<TechnicalFeature>();

            if (technicalType != null)
            {
                technicalFeatures.AddRange(_context.TechnicalFeature.Where(tf => tf.TechnicalTypeId == technicalType.Id));
            }

            return technicalFeatures;
        }

        [HttpGet]
        [Route("pivot/names")]
        public IList<string> GetPivotNames()
        {
            var technicalType = _context.TechnicalType.FirstOrDefault(tt => tt.Name == "Pivot");
            var technicalFeatures = new List<TechnicalFeature>();

            if (technicalType != null)
            {
                technicalFeatures.AddRange(_context.TechnicalFeature.Where(tf => tf.TechnicalTypeId == technicalType.Id));
            }

            return technicalFeatures.Select(tf => tf.Name).ToList();
        }
    }
}
