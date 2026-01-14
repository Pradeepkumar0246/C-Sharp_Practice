using EmployeeProjectManagement.Models;

namespace EmployeeProjectManagement.Interfaces
{
    public interface IDepartmentService 
    {
        Task<Department> CreateDepartmentAsync(Department department);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department> UpdateDepartmentAsync(int id, Department department);

    }
}
