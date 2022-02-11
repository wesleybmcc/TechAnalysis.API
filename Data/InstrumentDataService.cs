using Microsoft.EntityFrameworkCore;
using OandaClient;
using TechAnalysis.Model;

namespace TechAnalysis.Data
{
    public class InstrumentDataService : DataService
    {
        public InstrumentDataService(TechAlertDbContext context) : base(context) { }

        public IList<string> GetInstruments(string name = "", string sector = "")
        {
            var instrumentList = new List<string>();
            var marketIds = new List<int>();

            if(_context != null && _context.Market != null && _context.Instrument != null)
            {
                Func<Market, bool> marketWhere = m => m.Name != null && m.Name.Equals(name) && 
                    !string.IsNullOrEmpty(sector) && m.Sector != null && m.Sector.Equals(sector);

                marketIds.AddRange(_context.Market.Where(marketWhere).Select(m => m.Id).ToList());

                _context.Instrument.Where(i => marketIds.Contains(i.MarketId)).
                    Select(i => i.Symbol).ToList().ForEach(i => { 
                        if(i != null)
                        {
                            instrumentList.Add(i);
                        }
                    });
            }

            return instrumentList;
        }
    }
}
