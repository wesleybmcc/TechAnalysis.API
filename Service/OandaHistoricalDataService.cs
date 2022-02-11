using OandaClient;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TechAnalysis.Hub;
using TechAnalysis.Model;
//using TechAnalysis.Data;

namespace TechAnalysis.API.Service
{
    public class OandaHistoricalDataService : BackgroundService
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public OandaHistoricalDataService(ILoggerFactory loggerFactory, IHubContext<BroadcastHub, IHubClient> hubContext) 
        {
            this._hubContext = hubContext;
        }

        public void Update()
        {
            var oandaDataService = new OandaDataService();
            var results = oandaDataService.GetHistorialData("EUR_USD", "D", 0);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            Update();

            var timer = new System.Timers.Timer(15000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            return Task.CompletedTask;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            _hubContext.Clients.All.SendMessage("OandaHistoricalDataService", DateTime.Now.ToLongTimeString());
        }
    }
}
