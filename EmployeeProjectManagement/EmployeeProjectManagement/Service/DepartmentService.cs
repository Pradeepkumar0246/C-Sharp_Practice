using EmployeeProjectManagement.Interfaces;
using EmployeeProjectManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProjectManagement.Service
{
    public class DepartmentService(AppDbContext context): IDepartmentService
    {
        private readonly AppDbContext _context = context;
        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            
            return await _context.Departments
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .ToListAsync();
        }
        public async Task<Department> UpdateDepartmentAsync(int id, Department department)
        {
            var existingDepartment = await _context.Departments.FindAsync(id);
            if (existingDepartment == null)
            {
                return null;
            }
            existingDepartment.Name = department.Name;
            existingDepartment.ManagerId = department.ManagerId;
            existingDepartment.Location = department.Location;
            existingDepartment.Employees= department.Employees;
            existingDepartment.Manager= department.Manager;
            existingDepartment.DepartmentId= department.DepartmentId;
            
            await _context.SaveChangesAsync();
            return existingDepartment;
        }
    }
}
