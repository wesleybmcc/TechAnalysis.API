using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TechAnalysis.Model;

namespace TechAnalysis.Hub
{
    public class BroadcastHub : Hub<IHubClient>
    {
        public async Task SendMessage(string user, string message)
        {
            var echoMessage = string.Format("echo 1 {0}", message);
            await Clients.All.SendMessage(user, echoMessage);
        }
    }
}
