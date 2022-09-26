using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BADC_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeeDetailsController : ControllerBase
    {
        private readonly BADCContext _context;

        public employeeDetailsController(BADCContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDetail>>> GetEmployeeDetails()
        {
            return Ok(await _context.EmployeeDetails.ToListAsync());
        }
        
    }
}
