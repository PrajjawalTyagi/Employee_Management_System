using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_system.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API Working");
        }
    }
}