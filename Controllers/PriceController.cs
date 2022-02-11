using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using TechAnalysis.Model;
using TechAnalysis.Data;

namespace TechAnalysis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {

        //public PriceController(TechAlertDbContext context) : base(context)
        //{
        //}

        [HttpGet]
        [Route("previousClose")]
        public OHLC GetPreviousClose([FromQuery] string symbol)
        {
            var ohlc = new OHLC();

            var dailyPrice = new DataService().GetDailyPrice(symbol)
                .OrderByDescending(dp => dp.Date).LastOrDefault();

            if(dailyPrice != null)
            {
                ohlc.Open = dailyPrice.Open;
                ohlc.High = dailyPrice.High;
                ohlc.Low = dailyPrice.Low;
                ohlc.Close = dailyPrice.Close;
            }

            //if(!NullContext() && _context.Instrument != null)
            //{
            //    var instrument = _context.Instrument.FirstOrDefault(i => i.Symbol == symbol);
            //    if (instrument != null)
            //    {
            //        if(_context.DailyPrice != null)
            //        {
            //            var dailyPrice = _context.DailyPrice.Where(d => d.InstrumentId == instrument.Id)
            //                .OrderByDescending(d => d.Date).Last();
            //            ohlc.Open = dailyPrice.Open;
            //            ohlc.High = dailyPrice.High;
            //            ohlc.Low = dailyPrice.Low;
            //            ohlc.Close = dailyPrice.Close;
            //        }
            //    }
            //}

            return ohlc;
        }
    }
}
