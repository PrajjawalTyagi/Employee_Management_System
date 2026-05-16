using Employee_Management_system.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_system.Controllers
{
    public class EmployeeController : Controller
    {
         private readonly Employee_DbContext _context;
        public EmployeeController(Employee_DbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        } 
    }
}
