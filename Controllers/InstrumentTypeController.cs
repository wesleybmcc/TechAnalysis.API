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
        //public InstrumentTypeController(TechAlertDbContext context) : base(context)
        //{
        //}

        [HttpGet]
        public IEnumerable<InstrumentType> Get()
        {
            return new DataService().GetInstrumentTypes();
            //var list = new List<InstrumentType>();

            //if(!NullContext() && _context.InstrumentType != null)
            //{
            //    list.AddRange(_context.InstrumentType);
            //}

            //return list;
        }
    }
}
