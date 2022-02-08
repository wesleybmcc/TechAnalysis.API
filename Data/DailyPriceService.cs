using Microsoft.EntityFrameworkCore;
using OandaClient;
using TechAnalysis.Model;

namespace TechAnalysis.Data
{
    public class DailyPriceService : DataService
    {
        public DailyPriceService(TechAlertDbContext context) : base(context) { }

        public IList<OHLC> GetPreviousOHLC()
        {
            var lastMarketDate = LastMarketDay();
            var ohlcList = new List<OHLC>();

            if(_context != null && _context.DailyPrice != null && _context.Instrument != null)
            {
                ohlcList = _context.DailyPrice.Include(d => d.Instrument)
                    .Where(d => d.Date == lastMarketDate)
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
            }
            return ohlcList;
        }

        private DateTime LastMarketDay()
        {
            var marketDate = DateTime.Now.AddDays(-1);
            while (marketDate.DayOfWeek == DayOfWeek.Saturday && marketDate.DayOfWeek == DayOfWeek.Sunday)
            {
                marketDate = marketDate.AddDays(-1);
            }

            return new DateTime(marketDate.Year, marketDate.Month, marketDate.Day, 0, 0, 0);
        }
    }
}
