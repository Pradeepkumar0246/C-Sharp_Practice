using System.ComponentModel.DataAnnotations;

namespace EmployeeProjectManagement.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public List<Employee>? Employees { get; set; }

    }
}
