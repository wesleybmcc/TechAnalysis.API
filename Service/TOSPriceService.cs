using Microsoft.AspNetCore.SignalR;
using TechAnalysis.Data;
using TechAnalysis.Hub;
using TechAnalysis.Model;
using TechAnalysis.Service;

namespace TechAnalysis.API.Service
{
    public class TOSPriceService : IHostedService
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public TOSPriceService(IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._hubContext = hubContext;
        }
        public void Run()
        {
        }

        public void SendMessage(string message)
        {
            _hubContext.Clients.All.SendMessage("PriceUpdate", message);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
