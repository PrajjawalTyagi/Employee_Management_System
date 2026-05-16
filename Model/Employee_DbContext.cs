using Microsoft.EntityFrameworkCore;

namespace Employee_Management_system.Model
{
    public class Employee_DbContext(DbContextOptions<Employee_DbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
