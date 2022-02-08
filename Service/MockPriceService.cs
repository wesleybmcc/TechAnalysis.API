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
    public class MockPriceService : IPriceService
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly TechAlertDbContext _context;

        private IDictionary<string, OHLC> mockedData = new Dictionary<string, OHLC>();

        private IList<string> _instruments = new List<string> { "EUR/USD", "USD/JPY", "GBP/USD", "USD/CHF", "AUD/USD", "USD/CAD",
            "NZD/USD", "EUR/GBP", "AUD/JPY", "EUR/JPY", "GBP/JPY" };

        public MockPriceService(IHubContext<BroadcastHub, IHubClient> hubContext, TechAlertDbContext context, bool useMock = true)
        {
            this._hubContext = hubContext;
            this._context = context;
        }

        public void Run()
        {
            var dataService = new DailyPriceService(this._context);
            var previousOHLC = dataService.GetPreviousOHLC();
            previousOHLC.ToList().ForEach(ohlc => {
                mockedData.Add(ohlc.Symbol, ohlc);
            });

            var timer = new System.Timers.Timer(2500);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var oandaDataService = new OandaDataService();
            mockedData.Keys.ToList().ForEach(key => {
                var askClose = mockedData[key].Close;

                var factorRandomDirectionUp = System.DateTime.Now.Millisecond % 2 == 0 ?
                    key.Contains("JPY") ? -0.01 : .0001 :
                    key.Contains("JPY") ? 0.01 : -.0001;

                askClose = askClose += factorRandomDirectionUp;
                var bidAskResponse = new BidAskResponse
                {
                    StartDateTime = System.DateTime.MaxValue,
                    EndDateTime = System.DateTime.MaxValue,
                    Ask = new OHLC { Close = askClose },
                    Bid = new OHLC { Close = askClose },
                    Instrument = key,
                    Volume = 100
                };
                string responseData = responseData = bidAskResponse != null ?
                    JsonSerializer.Serialize(bidAskResponse) : string.Empty;
                _hubContext.Clients.All.SendMessage("PriceUpdate", responseData);
            });
        }
    }
}
