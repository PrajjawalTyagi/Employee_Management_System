using System.ComponentModel.DataAnnotations;

namespace Employee_Management_system.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string? EmployeeName { get; set; } = null;
        [Required]
        public string? EmployeeEmail { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = null;

    }
}
