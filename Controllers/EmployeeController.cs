using Employee_Management_system.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_system.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly Employee_DbContext _context;

        public EmployeeController( Employee_DbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok("API Working");
        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            return _context.Employees != null ? Ok(_context.Employees.ToList()) : NotFound();
        }

        [HttpPost]
        public IActionResult EmployeeData( Employee employee)
        {
            if(employee == null)
                return BadRequest("Employee data is null.");

            //more validation update step 2
            if(string.IsNullOrEmpty(employee.EmployeeName) || string.IsNullOrEmpty(employee.EmployeeEmail))
                return BadRequest("Employee name and email are required.");
               
            //chech condition salry more than 1000;
            if(employee.Salary.HasValue && employee.Salary.Value < 1000)
                return BadRequest("Salary must be at least 1000.");

            var newEmployee = new Employee
            {
                EmployeeName = employee.EmployeeName,
                EmployeeEmail = employee.EmployeeEmail,
                CreatedDate = DateTime.Now,
                Salary = employee.Salary
            };
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
            return Ok(newEmployee);
        }

        [HttpPut]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = _context.Employees.Find(id);
            if (existingEmployee == null)
                return NotFound("Employee not found.");
            existingEmployee.EmployeeName = employee.EmployeeName;
            existingEmployee.EmployeeEmail = employee.EmployeeEmail;
            _context.SaveChanges();
            return Ok(existingEmployee);
        }

        [HttpDelete]
        public IActionResult Employee_Delete( int id)
        {
            if (id == null)
                return BadRequest( new { message="Not found"});
            var result = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            if (result is null)
                return NotFound("Id not found in  Database");
            _context.Employees.Remove(result);
            _context.SaveChanges();
            return Ok();
        }
    }

}