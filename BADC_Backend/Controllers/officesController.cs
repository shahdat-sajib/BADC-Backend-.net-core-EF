using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BADC_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class officesController : ControllerBase
    {
        private readonly BADCContext _context;

        public officesController(BADCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OfficeDetail>>> GetOffices()
        {
            return Ok(await _context.OfficeDetails.ToListAsync());
        }
    }
}
