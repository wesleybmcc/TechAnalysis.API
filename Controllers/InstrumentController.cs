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
        [HttpGet]
        public IEnumerable<Instrument> Get()
        {
            return new DataService().GetInstruments();
        }
    }
}
