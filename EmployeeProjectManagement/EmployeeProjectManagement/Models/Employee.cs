using System.ComponentModel.DataAnnotations;

namespace EmployeeProjectManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<Project>? Projects { get; set; }

    }
}
