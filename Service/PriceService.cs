using Microsoft.AspNetCore.SignalR;
using OandaClient;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TechAnalysis.Data;
using TechAnalysis.Hub;
using TechAnalysis.Model;

namespace TechAnalysis.Service
{
    public class PriceService : IPriceService
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly TechAlertDbContext _context;

        private IList<string> _instruments = new List<string> { "EUR/USD", "USD/JPY", "GBP/USD", "USD/CHF", "AUD/USD", "USD/CAD",
            "NZD/USD", "EUR/GBP", "AUD/JPY", "EUR/JPY", "GBP/JPY" };

        public PriceService(IHubContext<BroadcastHub, IHubClient> hubContext, TechAlertDbContext context, bool useMock = true)
        {
            this._hubContext = hubContext;
            this._context = context;
        }

        public void Run()
        {
            var timer = new System.Timers.Timer(750);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var oandaDataService = new OandaDataService();
            this._instruments.ToList().ForEach(i =>
            {
                var response = oandaDataService.GetBidAsk(i.Replace('/', '_'));
                var responseData = response != null ? JsonSerializer.Serialize(response) : string.Empty;

                _hubContext.Clients.All.SendMessage("PriceUpdate", responseData);
            });
        }
    }
}
