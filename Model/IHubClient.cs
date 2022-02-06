using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechAnalysis.Model
{
    public interface IHubClient
    {
        Task BroadcastMessage();
        Task SendMessage(string user, string message);
    }
}
