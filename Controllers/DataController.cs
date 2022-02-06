using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAnalysis.Data;
using TechAnalysis.Hub;
using TechAnalysis.Model;
using TechAnalysis.Service;

namespace TechAnalysis.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        const bool MOCK_DATA = true;

        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly TechAlertDbContext _context;

        public DataController(TechAlertDbContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._hubContext = hubContext;
            this._context = context;
        }

        [HttpGet]
        public async Task Get()
        {
            if(MOCK_DATA)
            {
                var mockPriceService = new MockPriceService(_hubContext, this._context);
                await Task.Run(() => {
                    mockPriceService.Run();
                });
            }
            else
            {
                var priceService = new PriceService(_hubContext, this._context);
                await Task.Run(() => {
                    priceService.Run();
                });
            }
        }              
    }
}