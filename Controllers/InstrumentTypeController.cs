using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechAnalysis.Data;

namespace TechAnalysis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentTypeController : ControllerBase
    {
        private readonly TechAlertDbContext _context;

        public InstrumentTypeController(TechAlertDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<InstrumentType> Get()
        {
            return _context.InstrumentType.ToList();
        }
    }
}
