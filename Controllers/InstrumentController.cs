using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechAnalysis.Data;

namespace TechAnalysis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentController : ControllerBase
    {
        private readonly TechAlertDbContext _context;

        public InstrumentController(TechAlertDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Instrument> Get()
        {
            return _context.Instrument.Where(i => i.Active).ToList();    
        }
    }
}
