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
            var prevousOHLC = (IList<OHLC>)_context.DailyPrice.Include(d => d.Instrument)
                .Where(d => d.Date == lastMarketDate)
                .Select(n => new OHLC
                {
                    Symbol = n.Instrument.Symbol,
                    Open = n.Open,
                    High = n.High,
                    Low = n.Low,
                    Close = n.Close,
                    StartDateTime = lastMarketDate,
                    EndDateTime = lastMarketDate
                }).ToList();

            if(prevousOHLC.Count() == 0)
            {
                RefreshDailyPrice();
            }
            return prevousOHLC;
        }

        private void RefreshDailyPrice()
        {
            var oandaDataService = new OandaDataService();
            _context.Instrument.Where(i => i.Active).ToList().ForEach(instrument => {
                var historicalDataResponsex = oandaDataService.GetHistorialData(instrument.Symbol);
            });
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
