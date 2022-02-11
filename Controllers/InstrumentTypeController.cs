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
        [HttpGet]
        public IEnumerable<InstrumentType> Get()
        {
            return new DataService().GetInstrumentTypes();
        }
    }
}
