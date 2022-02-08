using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechAnalysis.Data;

namespace TechAnalysis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentController : CustomBaseController
    {
        public InstrumentController(TechAlertDbContext context) : base(context)
        {
        }

        [HttpGet]
        public IEnumerable<Instrument> Get()
        {
            var list = new List<Instrument>();

            if(!NullContext() && _context.Instrument != null)
            {
                list.AddRange(_context.Instrument.Where(i => i.Active));
            }
            return list;
        }
    }
}
